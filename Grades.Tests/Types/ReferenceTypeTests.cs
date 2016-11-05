﻿using System;
using GradesV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "scoot";
            name = name.ToUpper();

            Assert.AreEqual("SCOOT", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date =  new DateTime(2015, 01, 01);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }


        [TestMethod]
        public void ValTypesPassByVal()
        {
            int x = 46;
            IncNum(x);

            Assert.AreEqual(x, 46);
        }

        private void IncNum(int number)
        {
            number += 1;
        }

        [TestMethod]
        public void RefTypesPassByVal()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);
        }

        private void GiveBookAName(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComp()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = String.Equals(name1, name2, 
                StringComparison.InvariantCultureIgnoreCase);
        }

        [TestMethod]
        public void IntVarHoldVal()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void VarsHoldRef()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Steven's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
