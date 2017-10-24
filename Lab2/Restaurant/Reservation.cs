using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Reservation
    {
        public Guid Id { get; private set; }
        public TimeSpan StartDate { get; private set; }
        public TimeSpan EndDate { get; private set; }
        public int NrOfPeople { get; private set; }

        public Reservation(TimeSpan StartDate, TimeSpan EndDate, int NrOfPeople)
        {
                this.StartDate = StartDate;
                this.EndDate = EndDate;
                this.NrOfPeople = NrOfPeople;
        }

    }
}
