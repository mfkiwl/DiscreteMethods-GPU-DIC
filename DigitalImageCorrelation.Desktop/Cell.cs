﻿using DigitalImageCorrelation.Desktop.Structures;
using MIConvexHull;
using System.Drawing;
using System.Linq;

namespace DigitalImageCorrelation.Desktop
{
    public class Cell : TriangulationCell<Vertex, Cell>
    {
        public Point[] Points
        {
            get { return Vertices.Select(x => x.Point).ToArray(); }
        }
        public Color[] Colors
        {
            get { return Vertices.Select(x => x.Color).ToArray(); }
        }

        public Color InterpolateColor
        {
            get
            {
                var Color1 = Colors[0];
                var Color2 = Colors[1];
                var Color3 = Colors[2];
                return Color.FromArgb(100, Average(Color1.R, Color2.R, Color3.R), Average(Color1.G, Color2.G, Color3.G), Average(Color1.B, Color2.B, Color3.B));
            }
        }

        byte Average(byte a, byte b, byte c)
        {
            return (byte)((a + b + c) / 3);
        }
    }
}
