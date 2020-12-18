using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;
using System.Linq;

namespace DigitalImageCorrelation.Drawing
{
    public static class ColorHelper
    {
        public static IEnumerable<ColorVertex> CalculateDisplacementColorsDX(double maxDx, double minDx, Vertex[] vertexes)
        {
            var denominatorDx = (maxDx - minDx) != 0 ? (maxDx - minDx) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.dX, minDx, denominatorDx) });
        }

        public static IEnumerable<ColorVertex> CalculateDisplacementColorsDY(double maxDy, double minDy, Vertex[] vertexes)
        {
            var denominatorDy = (maxDy - minDy) != 0 ? (maxDy - minDy) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.dY, minDy, denominatorDy) });
        }

        public static IEnumerable<ColorVertex> CalculateStrainColorsXX(double maxStrainXX, double minxStrainXX, Vertex[] vertexes)
        {
            var denominatorXX = (maxStrainXX - minxStrainXX) != 0 ? (maxStrainXX - minxStrainXX) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.strain.XX, minxStrainXX, denominatorXX) });
        }

        public static IEnumerable<ColorVertex> CalculateStrainColorsXY(double maxStrainXY, double minxStrainXY, Vertex[] vertexes)
        {
            var denominatorXY = (maxStrainXY - minxStrainXY) != 0 ? (maxStrainXY - minxStrainXY) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.strain.XY, minxStrainXY, denominatorXY) });
        }

        public static IEnumerable<ColorVertex> CalculateStrainColorsYY(double maxStrainYY, double minxStrainYY, Vertex[] vertexes)
        {
            var denominatorYY = (maxStrainYY - minxStrainYY) != 0 ? (maxStrainYY - minxStrainYY) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.strain.YY, minxStrainYY, denominatorYY) });
        }
    }
}
