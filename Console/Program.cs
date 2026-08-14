using Application.Services;
using Domain.Enums;
using Infrastructure.Repositories;

var userRepository = new InMemoryUserRepository();

var userService = new UserService(userRepository);
var routineService = new RoutineService(userRepository);
var exerciseService = new ExerciseService(userRepository);

var user = userService.CreateUser("Diego");

var routine = routineService.CreateRoutine(
    user.Id,
    "Full Body",
    TrainingGoal.GeneralFitness);

if (routine is null)
{
    return;
}

exerciseService.AddStrengthExercise(
    user.Id,
    routine.Id,
    "Squat",
    MuscleGroup.Legs,
    3,
    10,
    60);

exerciseService.AddStrengthExercise(
    user.Id,
    routine.Id,
    "Bench Press",
    MuscleGroup.Chest,
    3,
    10,
    50);

exerciseService.AddCardioExercise(
    user.Id,
    routine.Id,
    "Running",
    MuscleGroup.Legs,
    TimeSpan.FromMinutes(20),
    3);

//exerciseService.AddStrengthExercise(
//    user.Id,
//    routine.Id,
//    "Invalid Exercise",
//    MuscleGroup.Legs,
//    -3,
//    10,
//    60);

Console.WriteLine($"User: {user.Name}");
Console.WriteLine($"Routine: {routine.Name}");
Console.WriteLine();

foreach (var exercise in routine.Exercises)
{
    Console.WriteLine(exercise.Execute());
}