﻿using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Drawing;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class InterpolateDisplacementdX : InterpolateColorsTemplate, IResultPainter
    {
        public override Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                double min = request.AnalyzeResults.MaxDx;
                double max = request.AnalyzeResults.MinDx;
                var vertexes = ColorHelper.CalculateDisplacementColorsDX(min, max, result.Vertexes);
                return Paint(bitmap, vertexes);
            }
            return bitmap;
        }
    }
}
