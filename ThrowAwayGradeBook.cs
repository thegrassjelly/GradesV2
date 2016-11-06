using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradesV2
{
    public  class ThrowAwayGradeBook : GradeBook
    {
        public GradeStatistics ComputeStatistcs()
        {
            Console.WriteLine("ThrowAwayGradeBook::ComputeStatistcs");

            float lowest = float.MaxValue;
            foreach (float grade in _grades)
            {
                lowest = Math.Min(grade, lowest);
            }
            _grades.Remove(lowest);
            return base.ComputeStatistics();
        }

        internal override void WriteGrade(StreamWriter outputFile)
        {
            throw new NotImplementedException();
        }
    }
}
