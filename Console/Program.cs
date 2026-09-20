using Application;
using Application.Services;
using GymTraining.ConsoleApp.UI;
using Infrastructure.Repositories;

var userRepository = new InMemoryUserRepository();

var userService = new UserService(userRepository);
var routineService = new RoutineService(userRepository);
var exerciseService = new ExerciseService(userRepository);

var session = new AppSession();

var exerciseMenu = new ExerciseMenu(exerciseService, session);
var routineMenu = new RoutineMenu(routineService, session, exerciseMenu);

var app = new ConsoleApp(userService, session, routineMenu);

app.Run();
