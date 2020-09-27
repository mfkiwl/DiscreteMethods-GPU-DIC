using MIConvexHull;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.Structures
{
    public class Vertex : IVertex
    {
        public double[] Position
        {
            get { return new double[] { X, Y }; }
            set { X = (int)value[0]; Y = (int)value[1]; }
        }
        public int X;
        public int Y;

        public Color Color
        {
            get { return Color.Red; }
        }

        public Vertex(Point point)
        {
            X = point.X;
            Y = point.Y;
        }
        public Vertex(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point Point
        {
            get { return new Point() { X = X, Y = Y }; }
        }
    }
}
