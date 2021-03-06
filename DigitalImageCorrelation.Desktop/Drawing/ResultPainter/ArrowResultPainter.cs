﻿using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class ArrowResultPainter : IResultPainter
    {
        private readonly Pen _arrowPen = new Pen(Color.FromArgb(255, 0, 0, 255), 3);


        public Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                var startingPoints = request.AnalyzeResults.StartingVertexes;
                var g = Graphics.FromImage(bitmap);
                foreach (var (endpoint, index) in result.Vertexes.WithIndex())
                {
                    _arrowPen.StartCap = LineCap.Flat;
                    _arrowPen.EndCap = LineCap.ArrowAnchor;
                    g.DrawLine(_arrowPen, startingPoints[index].Point, endpoint.Point);
                }
            }
            return bitmap;
        }
    }
}
