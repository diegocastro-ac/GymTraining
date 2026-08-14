using Application;
using Application.Services;
using GymTraining.ConsoleApp.UI;
using Infrastructure.Repositories;

var userRepository = new InMemoryUserRepository();

var userService = new UserService(userRepository);
var routineService = new RoutineService(userRepository);

var session = new AppSession();

var routineMenu = new RoutineMenu(
    routineService,
    session);

var app = new ConsoleApp(
    userService,
    session,
    routineMenu);

app.Run();