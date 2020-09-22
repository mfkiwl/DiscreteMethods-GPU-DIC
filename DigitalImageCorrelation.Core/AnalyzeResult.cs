﻿using System.Collections.Generic;
using System.Drawing;

namespace DigitalImageCorrelation.Core
{
    public class AnalyzeResult
    {
        public IEnumerable<Point> Points;
        public IEnumerable<Point> StartingPoints;
        public int Index;
    }
}
