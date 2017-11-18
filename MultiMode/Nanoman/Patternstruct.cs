using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace MultiMode.Nanoman
{
   public class Patternstruct
    {
        public List<PointF[]> patternLine;
        public List<PointF[]> patternCircle;
        public List<PointF[]> patternArc;
        public Patternstruct()
        {
            patternLine = new List<PointF[]>();
            patternCircle = new List<PointF[]>();
            patternArc= new List<PointF[]>();
        }
    }
}
