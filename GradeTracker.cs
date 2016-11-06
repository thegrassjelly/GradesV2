﻿
using System;
using System.IO;

namespace GradesV2
{
    public abstract class GradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

        protected string _name;

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

        internal abstract void WriteGrade(StreamWriter outputFile);
    }
}
