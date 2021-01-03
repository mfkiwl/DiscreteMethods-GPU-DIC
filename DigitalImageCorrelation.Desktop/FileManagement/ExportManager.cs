using DigitalImageCorrelation.Core.Structures;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DigitalImageCorrelation.FileManagement
{
    public class ExportManager : BackgroundWorker
    {
        string path;
        public ExportManager(string filePath)
        {

            DoWork += DoExport;
            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            path = filePath;
        }

        private void DoExport(object sender, DoWorkEventArgs e)
        {
            var results = e.Argument as AnalyzeResult;
            ValidateMetadata(results);
            var firstImg = results.ImageResults.First();
            XElement document = new XElement("dic",
                new XElement("AnalyzeRequestBase",
                   new XElement("BitmapWidth", results.Request.BitmapWidth),
                   new XElement("BitmapHeight", results.Request.BitmapHeight),
                   new XElement("Size", results.ImageResults.Count),
                   new XElement("PointsinX", results.Request.PointsinX),
                   new XElement("PointsinY", results.Request.PointsinY),
                   new XElement("SubsetDelta", results.Request.SubsetDelta),
                   new XElement("WindowDelta", results.Request.WindowDelta),
                   new XElement("Square",
                        new XElement("Height", results.Request.Square.Height),
                        new XElement("Width", results.Request.Square.Width),
                        new XElement("Left", results.Request.Square.Left),
                        new XElement("Top", results.Request.Square.Top)
                    )
                )
            );
            XElement ImagesResults = new XElement("ImagesResults");
            Parallel.ForEach(results.ImageResults, container =>
            {
                XElement ImagesResult = new XElement("ImageResult");
                ImagesResult.Add(new XElement("Index", container.Value.Index));
                ImagesResult.Add(new XElement("VertexSize", container.Value.Vertexes.Count()));
                foreach (var vertex in container.Value.Vertexes)
                {
                    XElement node = new XElement("V",
                        new XElement("X", vertex.X),
                        new XElement("Y", vertex.Y),
                        vertex.dX != 0 ? new XElement("dX", vertex.dX) : null,
                         vertex.dY != 0 ? new XElement("dY", vertex.dY) : null,
                         vertex.strain.X != 0 ? new XElement("EX", vertex.strain.X) : null,
                         vertex.strain.Y != 0 ? new XElement("EY", vertex.strain.Y) : null,
                         vertex.strain.XY != 0 ? new XElement("EXY", vertex.strain.XY) : null,
                         vertex.stress.X != 0 ? new XElement("SX", vertex.stress.X) : null,
                         vertex.stress.Y != 0 ? new XElement("SY", vertex.stress.Y) : null,
                         vertex.stress.Eq != 0 ? new XElement("SEq", vertex.stress.Eq) : null
                    );
                    ImagesResult.Add(node);
                }
                ImagesResults.Add(ImagesResult);
                ReportProgress(container.Value.Index);
            });
            document.Add(ImagesResults);
            document.Save(path);
            e.Result = path;
        }

        private bool ValidateMetadata(AnalyzeResult results)
        {
            if (!results.ImageResults.Any())
            {
                throw new System.Exception($"Unable to export metadata. There is no data to export. Please make sure that the data has been analyzed and it is ready to export.");
            }
            var firstResult = results.ImageResults.First().Value;
            if (!firstResult.Vertexes.Any())
            {
                throw new System.Exception($"Unable to export metadata. There is no analyzed data to export. Please make sure that the data has been analyzed and it is ready to export.");
            }
            return true;
        }
    }
}
