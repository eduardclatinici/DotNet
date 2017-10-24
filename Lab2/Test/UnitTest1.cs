using System;
using FluentAssertions;
using Restaurant;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void shouldCreateReservation()
        {
            Table table=new Table(5);
            table.CreateReservation(new TimeSpan(10,0,0),new TimeSpan(22,0,0), 4);
            table.Reservations.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void shouldFailStartDateOffHours()
        {
            Table table = new Table(5);
            Action action = ()=> table.CreateReservation(new TimeSpan(8, 0, 0), new TimeSpan(22, 0, 0), 4);
            action.ShouldThrow<BusinessException>();
        }

        [Fact]
        public void shouldFailOverlapping()
        {
            Table table = new Table(5);
            table.CreateReservation(new TimeSpan(12, 0, 0), new TimeSpan(22, 0, 0), 4);
            Action action = () => table.CreateReservation(new TimeSpan(14, 0, 0), new TimeSpan(22, 0, 0), 4);
        
            action.ShouldThrow<BusinessException>();
        }

        [Fact]
        public void shouldFailNumberOfPeopleGreaterThanCapacity()
        {
            Table table = new Table(5);
            Action action = () => table.CreateReservation(new TimeSpan(14, 0, 0), new TimeSpan(20, 0, 0), 6);

            action.ShouldThrow<BusinessException>();
        }

        [Fact]
        public void shouldCountAllReservations()
        {
            Table table = new Table(5);
            table.CreateReservation(new TimeSpan(10, 0, 0), new TimeSpan(12, 0, 0), 4);
            table.CreateReservation(new TimeSpan(14, 0, 0), new TimeSpan(16, 0, 0), 4);
            table.Reservations.Count.Should().Be(2);

        }

        [Fact]
        public void shouldFailCreatingTableCapacityNegative()
        {
            Action action =()=> new Table(-1);

            action.ShouldThrow<BusinessException>();
        }
    }
}
