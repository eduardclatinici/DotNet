using System;

namespace SecondEx
{
    public class JobInfo
    {
        public Guid Id { get; private set; }
        public string Title { get; }
        public int MinimumYearsOfExperience { get; }
        public string Requirements { get; }
        public int Salary { get; }

        public JobInfo(string title, int minimumYearsOfExperience, string requirements, int salary)
        {
            checkArguments(minimumYearsOfExperience, salary);
            Title = title;
            MinimumYearsOfExperience = minimumYearsOfExperience;
            Requirements = requirements;
            Salary = salary;
        }

        private void checkArguments(int minimumYearsOfExperience, int salary)
        {
            checkMinimumYearsOfExperience(minimumYearsOfExperience);
            checkSalary(salary);
        }

        private void checkMinimumYearsOfExperience(int minimumYearsOfExperience)
        {
            if (minimumYearsOfExperience < 0 || minimumYearsOfExperience > 10)
                throw new ArgumentException("minimum years of experience must be between 0 and 10");
        }

        private void checkSalary(int salary)
        {
            if (salary < 1450)
                throw new ArgumentException("salary must be greater than 1450");
        }

    }

}
