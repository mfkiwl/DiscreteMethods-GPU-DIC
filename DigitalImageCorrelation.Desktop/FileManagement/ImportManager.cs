using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigitalImageCorrelation.FileManagement
{
    public class ImportManager : BackgroundWorker
    {
        string path;
        public ImportManager(string filePath)
        {
            DoWork += DoImport;
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            path = filePath;
        }

        private void DoImport(object sender, DoWorkEventArgs e)
        {
            var imageContainers = e.Argument as ConcurrentDictionary<int, ImageContainer>;
            var xml = XDocument.Load(path).Root;
            var imagesMetadata = xml.Descendants("AnalyzeRequestBase");

            var square = imagesMetadata.Descendants("Square").First();

            var request = new AnalyzeRequestBase
            {
                BitmapHeight = int.Parse(imagesMetadata.Descendants("BitmapHeight").First().Value),
                BitmapWidth = int.Parse(imagesMetadata.Descendants("BitmapWidth").First().Value),
                PointsinX = int.Parse(imagesMetadata.Descendants("PointsinX").First().Value),
                PointsinY = int.Parse(imagesMetadata.Descendants("PointsinY").First().Value),
                SubsetDelta = int.Parse(imagesMetadata.Descendants("SubsetDelta").First().Value),
                WindowDelta = int.Parse(imagesMetadata.Descendants("WindowDelta").First().Value),
                Size = int.Parse(imagesMetadata.Descendants("Size").First().Value),
                Square = new SquareLocation()
                {
                    Height = int.Parse(square.Descendants("Height").First().Value),
                    Width = int.Parse(square.Descendants("Width").First().Value),
                    Left = int.Parse(square.Descendants("Left").First().Value),
                    Top = int.Parse(square.Descendants("Top").First().Value),
                }
            };
            int width = int.Parse(imagesMetadata.Descendants("BitmapWidth").First().Value);
            ValidateMetadata(request.BitmapWidth, request.BitmapHeight, request.Size, imageContainers);
            var imagesResults = xml.Descendants("ImagesResults");
            var analyzeResult = new AnalyzeResult
            {
                StartingVertexes = GetStartingVertexes(imagesResults.Descendants("ImageResult").First()),
                Request = request
            };
            Parallel.ForEach(imagesResults.Descendants("ImageResult"), resultNode =>
            {
                ImageResult imageResult = new ImageResult();
                int index = int.Parse(resultNode.Descendants("Index").First().Value);
                int size = int.Parse(resultNode.Descendants("VertexSize").First().Value);
                imageResult.Vertexes = new Vertex[size];
                foreach (var (vertexNode, i) in resultNode.Descendants("V").WithIndex())
                {
                    var vertex = new Vertex()
                    {
                        X = int.Parse(vertexNode.Descendants("X").First().Value),
                        Y = int.Parse(vertexNode.Descendants("Y").First().Value),
                        dX = int.Parse(vertexNode.Descendants("dX").First().Value),
                        dY = int.Parse(vertexNode.Descendants("dY").First().Value),
                        strain = new Strain
                        {
                            X = double.Parse(vertexNode.Descendants("EX").First().Value, CultureInfo.InvariantCulture),
                            Y = double.Parse(vertexNode.Descendants("EY").First().Value, CultureInfo.InvariantCulture),
                            XY = double.Parse(vertexNode.Descendants("EXY").First().Value, CultureInfo.InvariantCulture),
                        },
                        stress = new Stress
                        {
                            X = double.Parse(vertexNode.Descendants("SX").First().Value, CultureInfo.InvariantCulture),
                            Y = double.Parse(vertexNode.Descendants("SY").First().Value, CultureInfo.InvariantCulture),
                            Eq = double.Parse(vertexNode.Descendants("SEq").First().Value, CultureInfo.InvariantCulture),
                        }
                    };
                    imageResult.Vertexes[i] = vertex;
                }
                analyzeResult.ImageResults[index] = imageResult;
                imageContainers[index].Result = imageResult;
                ReportProgress(index);
            });
            e.Result = analyzeResult;
        }

        private Vertex[] GetStartingVertexes(XElement resultNode)
        {
            int size = int.Parse(resultNode.Descendants("VertexSize").First().Value);
            var startingVertexes = new Vertex[size];
            foreach (var (vertexNode, i) in resultNode.Descendants("V").WithIndex())
            {
                var vertex = new Vertex()
                {
                    X = int.Parse(vertexNode.Descendants("X").First().Value),
                    Y = int.Parse(vertexNode.Descendants("Y").First().Value)
                };
                startingVertexes[i] = vertex;
            }
            return startingVertexes;
        }

        private bool ValidateMetadata(int width, int height, int size, ConcurrentDictionary<int, ImageContainer> imageContainers)
        {

            if (!imageContainers.Any())
            {
                throw new System.Exception($"Unable to import metadata. There are no images loaded to application. Please make sure that proper raw images are loaded. Selected metadata describes {size} images of size: {width}x{height}");
            }

            var firstContainer = imageContainers.First().Value;
            if (!imageContainers.Any() ||
                width != firstContainer.BitmapWidth ||
                height != firstContainer.BitmapHeight ||
                size != imageContainers.Count)
            {
                throw new System.Exception($"Unable to load metadata. Metadata file describing diffrent images than loaded. Metadata describes {size} images of size: {width}x{height}");
            }
            return true;
        }
    }
}
