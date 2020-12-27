using DigitalImageCorrelation.Core;
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
            var imagesMetadata = xml.Descendants("ImagesMetadata");
            int width = int.Parse(imagesMetadata.Descendants("Width").First().Value);
            int height = int.Parse(imagesMetadata.Descendants("Height").First().Value);
            int numberOfImages = int.Parse(imagesMetadata.Descendants("NumberOfImages").First().Value);
            ValidateMetadata(width, height, numberOfImages, imageContainers);
            var imagesResults = xml.Descendants("ImagesResults");
            var analyzeResult = new AnalyzeResult
            {
                StartingVertexes = GetStartingVertexes(imagesResults.Descendants("ImageResult").First())
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

        private bool ValidateMetadata(int width, int height, int numberOfImages, ConcurrentDictionary<int, ImageContainer> imageContainers)
        {
            var firstContainer = imageContainers.First().Value;
            if (width != firstContainer.BitmapWidth ||
                height != firstContainer.BitmapHeight ||
                numberOfImages != imageContainers.Count)
            {
                throw new System.Exception($"Unable to load metadata. Metadata file describing diffrent images than loaded. Metadata describes {numberOfImages} images of size: {width}x{height}");
            }
            return true;
        }
    }
}
