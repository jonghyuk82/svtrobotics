# SVT Robotics

## Purpose

Chooses the optimal robot for pick up by calculating the distance between the pallet and battery level.

## Preview

### Using VS Code and postman

<img src='./resource/vscode.gif' />

### Using Visual Studio and swagger

<img src='./resource/visualstudio.gif' />

## Instructions

1. Clone the repository onto your local machine.
2. On your preferred IDE, open and run the code.
   - VS Code: In the terminal, go to the SVTRobotics.API folder and run ‘dotnet run’.
     - You should have a server listening on _https://localhost:5001/api/robots/closest_
   - Visual Studio: Open the solution file ‘SVTRobotics.sln’.
     - Start debugging by clicking on the green arrow near the top.
     - The swagger page will open.
3. By either using swagger or postman, send POST requests to _https://localhost:5001/api/robots/closest_ with the payload.
   - Example payload:
     ...
     {
     "loadId": 100,
     "x": 5,
     "y": 3
     }
     ...
4. The API will respond with the closest robot:
   - Example response:
     ...
     {
     "robotId": 4,
     "distanceToGoal": 5,
     "batteryLevel": 37
     }
     ...

## Enhancements

1. Feature idea: Implement a function to send robots that are lower than a specified battery percentage to the closest charging station.
2. More robust and scalable API: To implement Data Transfer Objects, the domain model and service layer can be decoupled. Then the domain model does not directly need exposure from the UI. If the domain model needs to be modified, it won’t have an effect on the current logic.
3. Logging: Since the API can run into issues at any time, I would like to implement a logging function to help to track down and debug.
4. Testing: Adding unit tests can help catch bugs early on.
5. Caching: Instead of calling the entire list of robots every time the API gets called, storing the entire robot list in the cache and only updating the information of the robots that have moved can save resources.
6. Matching: The provided API returns the robotid as a string but in the example response, the robotid gets returned as an integer. I would like to suggest matching these two types by either a string or integer.
