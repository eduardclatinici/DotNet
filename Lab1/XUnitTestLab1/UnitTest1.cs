using System;
using Lab1;
using Xunit;

namespace XUnitTestLab1
{
    public class UnitTest1
    {
        [Fact]
        public void shouldCreateTaskObjectWithActualStartDate()
        {
            DateTime tomorow= DateTime.Now.AddDays(1);
            Task task=new Task(new Guid(), "TestTask","TestDescription",tomorow,"TestAssignee",10);
            Assert.Equal(task.estimation,10);
            Assert.True(task.startDate.CompareTo(tomorow)==0);
        }

        [Fact]
        public void shouldCreateTaskObjectWithPresentDateBecauseStartDateInPast()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            Task task = new Task(new Guid(), "TestTask", "TestDescription", yesterday, "TestAssignee", 10);
            Assert.True(task.startDate.CompareTo(yesterday) >0);
        }

        [Fact]
        public void shouldGiveTrueOnCheckingIfTaskIsOnTrack()
        {
            DateTime tomorow = DateTime.Now.AddDays(1);
            Task task = new Task(new Guid(), "TestTask", "TestDescription", tomorow, "TestAssignee", 10);
            Assert.True(task.isOnTrack());
        }

        [Fact]
        public void shouldComputeNumberOfRemainingDays()
        {
            DateTime tomorow = DateTime.Now.AddDays(1);
            Task task = new Task(new Guid(), "TestTask", "TestDescription", tomorow, "TestAssignee", 10);
            Assert.True(task.calculateRemainingEstimate()==10);
        }
    }
}
