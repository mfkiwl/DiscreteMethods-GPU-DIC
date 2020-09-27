﻿using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Desktop.Structures;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public class InterpolateDisplacementdX : IResultPainter
    {
        public async Task<Bitmap> Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                var g = Graphics.FromImage(bitmap);
                var trianguled = MIConvexHull.DelaunayTriangulation<Vertex, Cell>.Create(result.Vertexes.ToList(), 0.001);
                foreach (var triangle in trianguled.Cells)
                {
                    PathGradientBrush pthGrBrush = new PathGradientBrush(triangle.Points)
                    {
                        SurroundColors = triangle.ColorsDx,
                        CenterColor = triangle.InterpolateColor(triangle.ColorsDx)
                    };
                    g.FillPolygon(pthGrBrush, triangle.Points);
                }
            }
            return bitmap;
        }
    }
}