using System;
using System.Reflection.Metadata.Ecma335;

namespace Lab1
{
    public class Task
    {
        public Guid id { get; private set; }
        public string title { get; private set; }
        public string description { get; private set; }
        public DateTime startDate { get; private set; }
        public string assignee { get; private set; }
        public int estimation { get; private set; }

        public DateTime checkStartDate(DateTime startDate)
        {
            if (startDate.CompareTo(DateTime.Now) < 0)
            {
                Console.Write("Start date cannot be in the past => start date for this task is today");
                return DateTime.Now;
            }
            else
            {
                return startDate;
            }
        }

        public int checkEstimation(int estimation)
        {
        if (estimation <= 0)
            {
                return 1;
            }
            else
        {
            return estimation;
        }
        }

        public Task(Guid id, string title, string description, DateTime startDate, string assignee, int estimation)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.startDate = checkStartDate(startDate);
            this.assignee = assignee;
            this.estimation = checkEstimation(estimation);
        }

        public bool isOnTrack()
        {
            if ((DateTime.Now - this.startDate).TotalDays<estimation)
                return true;
            return false;
        }

        public int calculateRemainingEstimate()
        {
            return this.estimation - (int)(DateTime.Now - this.startDate).TotalDays;
        }
    }
}