using Application.Services;
using Domain.Enums;
using Infrastructure.Repositories;

var userRepository = new InMemoryUserRepository();

var userService = new UserService(userRepository);
var routineService = new RoutineService(userRepository);

var user = userService.CreateUser("Diego");

var routine = routineService.CreateRoutine(user.Id, "Full Body", TrainingGoal.GeneralFitness);

Console.WriteLine($"User: {user.Name}");
Console.WriteLine($"Routine: {routine?.Name}");
