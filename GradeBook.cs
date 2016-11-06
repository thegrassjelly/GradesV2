using System;
using System.Collections.Generic;
using System.IO;

namespace GradesV2
{
    public class GradeBook
    {
        private List<float> _grades;

        private string _name;

        public NameChangedDelegate NameChanged;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }

                if (_name != value)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    //NameChanged(this, args);
                }

                _name = value;
            }
        }

        public GradeBook()
        {
            _name = "Empty";
            _grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            _grades.Add(grade);
        }

        public GradeStatistics ComputeStatistics()
        {
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

        public void WriteGrade(TextWriter destinaton)
        {
            for (int i = 0; i < _grades.Count; i++)
            {
                destinaton.WriteLine(_grades[i]);
            }
        }
    }
}
