namespace Lab1
{
    public class HouseAlarm:Alarm
    {
        public const string Address = "Canta";

        public override string Trigger()
        {
            this.SetAlertTime();
            return "“House alarm triggered, calling cops";

        }
    }
}