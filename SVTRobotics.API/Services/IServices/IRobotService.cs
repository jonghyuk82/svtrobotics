using SVTRobotics.API.Models;

namespace SVTRobotics.API.Services.IServices
{
    public interface IRobotService
    {
        Task<List<RobotList>> getRobotList();
        Task<ClosestRobot> getClosestRobot(LoadCoordinate payload);
    }
}