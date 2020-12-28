using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;
using System.Linq;

namespace DigitalImageCorrelation.Drawing
{
    public static class ColorHelper
    {
        public static IEnumerable<ColorVertex> CalculateDisplacementColorsDX(double max, double min, Vertex[] vertexes)
        {
            var denominatorDx = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.dX, min, denominatorDx) });
        }

        public static IEnumerable<ColorVertex> CalculateDisplacementColorsDY(double max, double min, Vertex[] vertexes)
        {
            var denominatorDy = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.dY, min, denominatorDy) });
        }

        public static IEnumerable<ColorVertex> CalculateStrainColorsX(double max, double min, Vertex[] vertexes)
        {
            var denominatorXX = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.strain.X, min, denominatorXX) });
        }

        public static IEnumerable<ColorVertex> CalculateStrainColorsXY(double max, double min, Vertex[] vertexes)
        {
            var denominatorXY = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.strain.XY, min, denominatorXY) });
        }

        public static IEnumerable<ColorVertex> CalculateStrainColorsY(double max, double min, Vertex[] vertexes)
        {
            var denominatorYY = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.strain.Y, min, denominatorYY) });
        }

        public static IEnumerable<ColorVertex> CalculateStressColorsX(double max, double min, Vertex[] vertexes)
        {
            var denominatorYY = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.stress.X, min, denominatorYY) });
        }
        public static IEnumerable<ColorVertex> CalculateStressColorsY(double max, double min, Vertex[] vertexes)
        {
            var denominatorYY = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.stress.Y, min, denominatorYY) });
        }
        public static IEnumerable<ColorVertex> CalculateStressColorsEq(double max, double min, Vertex[] vertexes)
        {
            var denominatorYY = (max - min) != 0 ? (max - min) : 1;
            return vertexes.AsParallel().Select(vertex => new ColorVertex(vertex) { color = Utils.GetColor(vertex.stress.Eq, min, denominatorYY) });
        }
    }
}
