namespace Lab1
{
    public class CarAlarm:Alarm
    {
        public string Location { get; private set; }

        public override string Trigger()
        {
            this.SetAlertTime();
            return "Car alarm activated at "+this.Location+" calling cops.";

        }
    }
}