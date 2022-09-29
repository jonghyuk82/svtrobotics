namespace SVTRobotics.API.Models
{
    public class ClosestRobot
    {
        public int robotId { get; set; }
        public double distanceToGoal { get; set; }
        public int batteryLevel { get; set; }
    }
}