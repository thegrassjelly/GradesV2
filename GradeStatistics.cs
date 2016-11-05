namespace GradesV2
{
    class GradeStatistics
    {
       public float AverageGrade;
       public float HighestGrade;
       public float LowestGrade;

        public GradeStatistics()
        {
            HighestGrade = 0;
            LowestGrade = float.MaxValue;
        }
    }
}