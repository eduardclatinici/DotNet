using System;
using System.Collections.Generic;

namespace Lab1
{
    public class AlertService:AlertServiceInterface
    {
        private List<Alarm> alarmList = new List<Alarm>();
        public AlertService()
        {
            Alarm alarm1=new HouseAlarm();
            Alarm alarm2=new CarAlarm();
            Alarm alarm3=new HouseAlarm();
            this.alarmList.Add(alarm1);
            this.alarmList.Add(alarm2);
            this.alarmList.Add(alarm3);
        }

        public void SoundAlarm(int id)
        {
            int ok = 0;
            foreach (Alarm alarm in alarmList)
            {
                if (alarm.Id.Equals(id))
                {
                    alarm.Trigger();
                    ok = 1;
                    break;
                }

            }
            if (ok == 0)
            {
                Console.Write("Alarm with id "+id+" could not be found");
            }
            else
            {
                Console.Write("Alarm triggered");
            }

        }
    }
}