using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondEx;

namespace SecondExTests
{
    [TestClass]
    public class JobInfoTest
    {
        [TestMethod]
        public void ShouldCreateObject()
        {
            JobInfo Job=new JobInfo("Test",9,"All of them",1450);
            Job.Title.Should().Be("Test");
            Job.MinimumYearsOfExperience.Should().Be(9);
            Job.Requirements.Should().Be("All of them");
            Job.Salary.Should().Be(1450);
        }

        [TestMethod]
        public void ShouldFailCreatingObjectYearsGreaterThanTen()
        {
            Action action=()=>new JobInfo("Test", 11, "All of them", 1450);
            action.ShouldThrow<ArgumentException>("minimum years of experience must be between 0 and 10");
        }

        [TestMethod]
        public void ShouldFailCreatingObjectYearsLowerThanZero()
        {
            Action action = () => new JobInfo("Test", -1, "All of them", 1450);
            action.ShouldThrow<ArgumentException>("minimum years of experience must be between 0 and 10");
        }

        [TestMethod]
        public void ShouldFailCreatingObjectSalaryLowerThanMinimum()
        {
            Action action = () => new JobInfo("Test", 5, "All of them", 1000);
            action.ShouldThrow<ArgumentException>("salary must be greater than 1450");
        }
    }
}