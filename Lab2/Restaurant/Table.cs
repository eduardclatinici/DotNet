using System;
using System.Collections.Generic;

namespace Restaurant
{
    public class Table
    {
        public Guid Id;
        public int Capacity;
        public List<Reservation> Reservations { get; set; }=new List<Reservation>();

        public Table(int Capacity)
        {
            if(Capacity>0)
                this.Capacity = Capacity;
            else throw new BusinessException("Capacity should not be null");
        }

        private bool IsInWorkingHours(TimeSpan StartDate, TimeSpan EndDate)
        {
            if (StartDate.Hours >= 10 && EndDate.Hours <= 22)
                return true;
            throw new BusinessException("Reservation hours must be between 10 and 22");

        }

        private bool IsInCapacity(int NumberOfPeople)
        {
            if (this.Capacity >= NumberOfPeople)
                return true;
            throw new BusinessException("Number of people must be no more than "+this.Capacity);
        }

        private bool IsOverlapping(TimeSpan StartDate, TimeSpan EndDate)
        {
            if (Reservations.TrueForAll(r => r.StartDate.CompareTo(EndDate) >= 0
                                             || r.EndDate.CompareTo(StartDate) <= 0))
                return true;
            throw new BusinessException("This reservation is overlapping an already existing reservation");
        }

        public void CreateReservation(TimeSpan StartDate, TimeSpan EndDate, int NumberOfPeople)
        {
            if (IsInWorkingHours(StartDate, EndDate)&&
                    IsInCapacity(NumberOfPeople)&&
                    IsOverlapping(StartDate,EndDate))
            {
                Reservation Reservation=new Reservation(StartDate,EndDate,NumberOfPeople);
                Reservations.Add(Reservation);
            }
        }

        public List<Reservation> AllReservations(TimeSpan StartDate, TimeSpan EndDate)
        {
            return Reservations.FindAll(r =>
                r.StartDate.CompareTo(StartDate) >= 0 && r.EndDate.CompareTo(EndDate) <= 0);
        }
    }
}
