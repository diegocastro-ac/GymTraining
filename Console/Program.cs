using Application;
using Application.Services;
using GymTraining.ConsoleApp.UI;
using Infrastructure.Repositories;

var userRepository = new InMemoryUserRepository();

var userService = new UserService(userRepository);

var session = new AppSession();

var app = new ConsoleApp(userService, session);

app.Run();
