using DigitalImageCorrelation.Desktop.Structures;
using MIConvexHull;
using System.Drawing;
using System.Linq;

namespace DigitalImageCorrelation.Desktop.Drawing
{
    public class Cell : TriangulationCell<Vertex, Cell>
    {
        public Point[] Points
        {
            get { return Vertices.Select(x => x.Point).ToArray(); }
        }
        public Color[] ColorsDx
        {
            get { return Vertices.Select(x => x.ColorDx).ToArray(); }
        }
        public Color[] ColorsDy
        {
            get { return Vertices.Select(x => x.ColorDy).ToArray(); }
        }
        public Color[] ColorsXX
        {
            get { return Vertices.Select(x => x.strain.ColorXX).ToArray(); }
        }
        public Color[] ColorsYY
        {
            get { return Vertices.Select(x => x.strain.ColorYY).ToArray(); }
        }
        public Color[] ColorsXY
        {
            get { return Vertices.Select(x => x.strain.ColorXY).ToArray(); }
        }

        public Color InterpolateColor(Color[] Colors)
        {
            var Color1 = Colors[0];
            var Color2 = Colors[1];
            var Color3 = Colors[2];
            return Color.FromArgb(150, Average(Color1.R, Color2.R, Color3.R), Average(Color1.G, Color2.G, Color3.G), Average(Color1.B, Color2.B, Color3.B));
        }

        byte Average(byte a, byte b, byte c)
        {
            return (byte)((a + b + c) / 3);
        }
    }
}
