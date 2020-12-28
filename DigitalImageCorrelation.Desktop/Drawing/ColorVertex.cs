using DigitalImageCorrelation.Desktop.Structures;
using System.Drawing;

namespace DigitalImageCorrelation.Drawing
{
    public class ColorVertex : Vertex
    {
        public Color color;

        public ColorVertex(Vertex vertex) : base(vertex) { }
    }
}
