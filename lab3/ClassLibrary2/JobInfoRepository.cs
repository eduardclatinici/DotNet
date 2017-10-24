using System;
using System.Collections.Generic;
using System.Linq;

namespace SecondEx
{
    public class JobInfoRepository
    {
        private List<JobInfo> JobList=new List<JobInfo>();
        public JobInfoRepository()
        {
            JobInfo job1=new JobInfo("Junior Tehnician",0,"OOP principles + Java or .Net basics",2000);
            JobInfo job2=new JobInfo("Medior Tehnician",1,"OOP principles+Java or .Net+good/bad practices+design patterns",4000);
            JobInfo job3=new JobInfo("Senior Tehnician",3,"a lot of stuff",6000);

            JobList.Add(job1);
            JobList.Add(job2);
            JobList.Add(job3);
        }

        public List<JobInfo> GetJobByTitle(string title)
        {

            return JobList.Where(job => job.Title.Equals(title)).ToList();
        }

        public List<JobInfo> FindAllJobs()
        {
            return JobList;
        }

        public void AddJob(JobInfo job)
        {
            JobList.Add(job);
        }

        public JobInfo GetJobByPosition(int position)
        {
            checkIntegers(position);
            return JobList[position];
        }

        public void RemoveJobsWithTitle(string title)
        {
            for(int i=0;i<JobList.Count;i++)
            {
                if (JobList[i].Title.Equals(title))
                {
                    JobList.Remove(GetJobByPosition(i));
                }
            }
        }

        public List<JobInfo> GetJobsWithSalaryHigherThan(int salary)
        {
            checkIntegers(salary);
            return JobList.Where(job => job.Salary > salary).ToList();
        }

        private void checkIntegers(int number)
        {
            if (number<0)
                throw new ArgumentException("why are you even searching for this?");
        }

    }
}