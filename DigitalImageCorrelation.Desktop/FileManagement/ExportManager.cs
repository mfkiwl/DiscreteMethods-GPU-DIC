using DigitalImageCorrelation.Core;
using System.Collections.Concurrent;
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
            var imageContainers = e.Argument as ConcurrentDictionary<int, ImageContainer>;
            var firstImg = imageContainers.First().Value;
            XElement doc = new XElement("dic");
            XElement imagesMetadata = new XElement("ImagesMetadata");
            imagesMetadata.Add(new XElement("Width", firstImg.BitmapWidth));
            imagesMetadata.Add(new XElement("Height", firstImg.BitmapHeight));
            imagesMetadata.Add(new XElement("NumberOfImages", imageContainers.Count));
            doc.Add(imagesMetadata);
            XElement ImagesResults = new XElement("ImagesResults");
            Parallel.ForEach(imageContainers, container =>
            {
                XElement ImagesResult = new XElement("ImageResult");
                ImagesResult.Add(new XElement("Index", container.Value.Index));
                ImagesResult.Add(new XElement("VertexSize", container.Value.Result.Vertexes.Count()));
                foreach (var vertex in container.Value.Result.Vertexes)
                {
                    XElement node = new XElement("V");
                    node.Add(new XElement("X", vertex.X));
                    node.Add(new XElement("Y", vertex.Y));
                    node.Add(new XElement("dX", vertex.dX));
                    node.Add(new XElement("dY", vertex.dY));
                    //Strain
                    node.Add(new XElement("EX", vertex.strain.X));
                    node.Add(new XElement("EY", vertex.strain.Y));
                    node.Add(new XElement("EXY", vertex.strain.XY));
                    //Stress
                    node.Add(new XElement("SX", vertex.stress.X));
                    node.Add(new XElement("SY", vertex.stress.Y));
                    node.Add(new XElement("SEq", vertex.stress.Eq));
                    ImagesResult.Add(node);
                }
                ImagesResults.Add(ImagesResult);
                ReportProgress(container.Value.Index);
            });
            doc.Add(ImagesResults);
            doc.Save(path);
        }
    }
}
