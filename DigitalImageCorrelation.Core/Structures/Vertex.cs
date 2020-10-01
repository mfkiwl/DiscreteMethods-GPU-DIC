using DigitalImageCorrelation.Core.Structures;
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
        public int dX;
        public int dY;
        public Strain strain = new Strain();
        public Color ColorDx;
        public Color ColorDy;

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
        public Vertex(int x, int y, int dx, int dy)
        {
            X = x;
            Y = y;
            dX = dx;
            dY = dy;
        }

        public Point Point
        {
            get { return new Point() { X = X, Y = Y }; }
        }
    }
}
