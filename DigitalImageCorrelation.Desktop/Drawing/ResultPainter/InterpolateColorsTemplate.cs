﻿using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Drawing;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public abstract class InterpolateColorsTemplate
    {
        public abstract Bitmap Paint(Bitmap bitmap, DrawRequest request);

        public Bitmap Paint(Bitmap bitmap, IEnumerable<ColorVertex> vertexes)
        {
            var g = Graphics.FromImage(bitmap);
            var trianguled = MIConvexHull.DelaunayTriangulation<ColorVertex, Cell>.Create(vertexes.ToArray(), 0.001);
            foreach (var triangle in trianguled.Cells)
            {
                PathGradientBrush pthGrBrush = new PathGradientBrush(triangle.Points)
                {
                    SurroundColors = triangle.Colors,
                    CenterColor = triangle.InterpolateColor(triangle.Colors)
                };
                g.FillPolygon(pthGrBrush, triangle.Points);
            }
            return bitmap;
        }
    }
}
