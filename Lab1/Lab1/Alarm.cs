using System;

namespace Lab1
{
    public abstract class Alarm
    {
        public Guid Id { get; private set; }
        public DateTime AlertTime { get; private set; }
        public abstract string Trigger();

        public void SetAlertTime()
        {
            this.AlertTime = DateTime.Now;
        }
    }
}
