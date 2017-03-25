using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahlentheorie
{
    public struct Result
    {
        public int A;
        public int B;
        public int X;
        public int Y;

        public List<int> lstA;
        public List<int> lstB;
        public List<int> lstQ;
        public List<int> lstR;
        public List<int> lstX;
        public List<int> lstY;

        public Result(int A, int B, int X, int Y, List<int> lstA, List<int> lstB, List<int> lstQ, List<int> lstR, List<int> lstX, List<int> lstY)
        {
            this.A = A;
            this.B = B;
            this.X = X;
            this.Y = Y;
            this.lstA = lstA;
            this.lstB = lstB;
            this.lstQ = lstQ;
            this.lstR = lstR;
            this.lstX = lstX;
            this.lstY = lstY;
        }
    }
}
