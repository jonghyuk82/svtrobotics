using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using SVTRobotics.API.Models;
using SVTRobotics.API.Services.IServices;

namespace SVTRobotics.API.Services
{
    public class RobotService : IRobotService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public RobotService(IConfiguration config, HttpClient httpClient)
        {
            _config = config;
            _httpClient = httpClient;
        }
        public async Task<ClosestRobot> getClosestRobot(LoadCoordinate payload)
        {
            // Get Robots
            var robotLists = await getRobotList();

            List<ClosestRobot> closestRobots = new List<ClosestRobot>();

            if (robotLists != null)
            {
                // Calculate distance 
                foreach (var robot in robotLists)
                {
                    var distance = Math.Sqrt(Math.Pow(payload.x - robot.x, 2) + Math.Pow(payload.y - robot.y, 2));
                    var closeRobot = new ClosestRobot()
                    {
                        robotId = Convert.ToInt32(robot.robotId),
                        distanceToGoal = distance,
                        batteryLevel = robot.batteryLevel
                    };
                    closestRobots.Add(closeRobot);
                }

                // Take 1 robot which is the closest and has more battery robot.
                var closestRobot = closestRobots
                    .OrderBy(closest => closest.distanceToGoal)
                    .ThenByDescending(closest => closest.batteryLevel)
                    .Take(1)
                    .FirstOrDefault();

                return closestRobot;
            }

            return new ClosestRobot();
        }

        public async Task<List<RobotList>> getRobotList()
        {
            List<RobotList> robotLists = new List<RobotList>();

            // Get endpoint URL from the configuration
            var endPoint = _config.GetSection("ApiOptions:EndPoint").Value;
            var objResponse = await _httpClient.GetAsync(endPoint);

            if (objResponse.StatusCode == HttpStatusCode.OK)
            {
                robotLists = await objResponse.Content.ReadFromJsonAsync<List<RobotList>>();
            }

            return robotLists;
        }
    }
}