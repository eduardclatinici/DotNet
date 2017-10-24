using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecondEx;

namespace SecondExTests
{
    [TestClass]
    public class JobInfoRepositoryTest
    {
        JobInfoRepository jobInfoRepository = new JobInfoRepository();

        [TestMethod]
        public void shouldFindThreeJobInfoObjects()
        {
            jobInfoRepository.FindAllJobs().Count.Should().Be(3);
        }

        [TestMethod]
        public void shouldFindOneJobInfoWithName()
        {
            jobInfoRepository.GetJobByTitle("Junior Tehnician").Count.Should().Be(1);
            jobInfoRepository.GetJobByTitle("Senior Tehnician")[0].Salary.Should().Be(6000);
        }

        [TestMethod]
        public void shouldAddOneMoreJobInfo()
        {
            JobInfo ExtraJob=new JobInfo("Extra",5,"some of them",3000);
            jobInfoRepository.AddJob(ExtraJob);
            jobInfoRepository.FindAllJobs().Count.Should().Be(4);
            jobInfoRepository.FindAllJobs()[3].Title.Should().Be("Extra");
        }

        [TestMethod]
        public void shouldFindCorrectJobInfoAtAGivenPosition()
        {
            jobInfoRepository.GetJobByPosition(1).Salary.Should().Be(4000);
            jobInfoRepository.GetJobByPosition(2).Title.Should().Be("Senior Tehnician");
        }

        [TestMethod]
        public void shouldRemoveJobInfoWithName()
        {
            jobInfoRepository.FindAllJobs().Count.Should().Be(3);
            jobInfoRepository.RemoveJobsWithTitle("Junior Tehnician");
            jobInfoRepository.FindAllJobs().Count.Should().Be(2);
        }

        [TestMethod]
        public void shouldReturnCorrectNumberOfJobsWithSalaryHigherThan()
        {
            jobInfoRepository.GetJobsWithSalaryHigherThan(2500).Count.Should().Be(2);
            jobInfoRepository.GetJobsWithSalaryHigherThan(4500).Count.Should().Be(1);
        }
    }
}