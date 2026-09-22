using Application;
using Application.Factories;
using Application.Services;
using GymTraining.ConsoleApp.UI;
using Infrastructure.Repositories;

var userRepository = new InMemoryUserRepository();

var userService = new UserService(userRepository);
var routineService = new RoutineService(userRepository);
var exerciseService = new ExerciseService(userRepository);

var generatorResolver = new RoutineGeneratorResolver();
var nutritionPlanResolver = new NutritionPlanResolver();

var session = new AppSession();

var exerciseMenu = new ExerciseMenu(exerciseService, session);
var routineMenu = new RoutineMenu(routineService, session, exerciseMenu, generatorResolver);
var nutritionMenu = new NutritionMenu(nutritionPlanResolver, session);

var app = new ConsoleApp(userService, session, routineMenu, nutritionMenu);

app.Run();
