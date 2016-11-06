using System;
using System.Collections.Generic;
using System.IO;

namespace GradesV2
{
    public abstract class GradeBook : GradeTracker
    {
        protected List<float> _grades;

        public GradeBook()
        {
            _name = "Empty";
            _grades = new List<float>();
        }

        public override void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("Gradebook::ComputeStatistics");

            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in _grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum / _grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter destination)
        {
            for (int i = 0; i < _grades.Count; i++)
            {
                destination.WriteLine(_grades[i]);
            }
        }
    }
}
