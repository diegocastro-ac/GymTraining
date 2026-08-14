using Application;
using Application.Services;
using Domain.Enums;

namespace GymTraining.ConsoleApp.UI;

public class ExerciseMenu
{
    private readonly ExerciseService _exerciseService;
    private readonly AppSession _session;

    public ExerciseMenu(
        ExerciseService exerciseService,
        AppSession session)
    {
        _exerciseService = exerciseService;
        _session = session;
    }

    public void Run()
    {
        var running = true;

        while (running)
        {
            Console.Clear();

            var routine = _session.CurrentRoutine;

            if (routine is null)
            {
                return;
            }

            Console.WriteLine(
                $"=== {routine.Name} ===");

            Console.WriteLine();

            Console.WriteLine("1. Add exercise");
            Console.WriteLine("2. View exercises");
            Console.WriteLine("3. Back");
            Console.WriteLine();

            Console.Write("Select an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddExercise();
                    break;

                case "2":
                    ViewExercises();
                    break;

                case "3":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ViewExercises()
    {
        var routine = _session.CurrentRoutine;

        if (routine is null)
        {
            return;
        }

        Console.Clear();

        Console.WriteLine(
            $"=== Exercises: {routine.Name} ===");

        Console.WriteLine();

        if (routine.Exercises.Count == 0)
        {
            Console.WriteLine("No exercises registered.");
        }
        else
        {
            var number = 1;

            foreach (var exercise in routine.Exercises)
            {
                Console.WriteLine(
                    $"{number}. {exercise.Name}");

                Console.WriteLine(
                    $"   {exercise.Execute()}");

                number++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private void AddExercise()
    {
        var routine = _session.CurrentRoutine;

        if (routine is null)
        {
            return;
        }

        Console.Clear();

        Console.WriteLine("=== Add Exercise ===");
        Console.WriteLine();

        Console.WriteLine("1. Strength");
        Console.WriteLine("2. Cardio");
        Console.WriteLine();

        Console.Write("Select exercise type: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddStrengthExercise();
                break;

            case "2":
                AddCardioExercise();
                break;

            default:
                Console.WriteLine("Invalid option.");
                Console.ReadKey();
                break;
        }
    }

    private void AddStrengthExercise()
    {
        Console.Clear();

        Console.WriteLine("=== Add Strength Exercise ===");
        Console.WriteLine();

        Console.Write("Name: ");
        var name = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Muscle group:");
        Console.WriteLine("1. Chest");
        Console.WriteLine("2. Back");
        Console.WriteLine("3. Legs");
        Console.WriteLine("4. Shoulders");
        Console.WriteLine("5. Arms");
        Console.WriteLine();

        Console.Write("Select a muscle group: ");

        var muscleGroupInput = Console.ReadLine();

        if (!TryParseMuscleGroup(
                muscleGroupInput,
                out var muscleGroup))
        {
            Console.WriteLine("Invalid muscle group.");
            Console.ReadKey();
            return;
        }

        Console.Write("Sets: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out var sets))
        {
            Console.WriteLine("Invalid number of sets.");
            Console.ReadKey();
            return;
        }

        Console.Write("Repetitions: ");

        if (!int.TryParse(
                Console.ReadLine(),
                out var repetitions))
        {
            Console.WriteLine("Invalid number of repetitions.");
            Console.ReadKey();
            return;
        }

        Console.Write("Weight (kg): ");

        if (!decimal.TryParse(
                Console.ReadLine(),
                out var weight))
        {
            Console.WriteLine("Invalid weight.");
            Console.ReadKey();
            return;
        }

        var user = _session.CurrentUser;
        var routine = _session.CurrentRoutine;

        if (user is null || routine is null)
        {
            return;
        }

        try
        {
            var exercise = _exerciseService.AddStrengthExercise(
                user.Id,
                routine.Id,
                name ?? string.Empty,
                muscleGroup,
                sets,
                repetitions,
                weight);

            if (exercise is null)
            {
                Console.WriteLine("Routine not found.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Exercise created successfully: {exercise.Name}");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }

    private void AddCardioExercise()
    {
        Console.Clear();

        Console.WriteLine("=== Add Cardio Exercise ===");
        Console.WriteLine();

        Console.Write("Name: ");
        var name = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Muscle group:");
        Console.WriteLine("1. Chest");
        Console.WriteLine("2. Back");
        Console.WriteLine("3. Legs");
        Console.WriteLine("4. Shoulders");
        Console.WriteLine("5. Arms");
        Console.WriteLine();

        Console.Write("Select a muscle group: ");

        var muscleGroupInput = Console.ReadLine();

        if (!TryParseMuscleGroup(
                muscleGroupInput,
                out var muscleGroup))
        {
            Console.WriteLine("Invalid muscle group.");
            Console.ReadKey();
            return;
        }

        Console.Write("Duration (minutes): ");

        if (!double.TryParse(
                Console.ReadLine(),
                out var durationMinutes))
        {
            Console.WriteLine("Invalid duration.");
            Console.ReadKey();
            return;
        }

        Console.Write("Distance (km): ");

        if (!decimal.TryParse(
                Console.ReadLine(),
                out var distance))
        {
            Console.WriteLine("Invalid distance.");
            Console.ReadKey();
            return;
        }

        var user = _session.CurrentUser;
        var routine = _session.CurrentRoutine;

        if (user is null || routine is null)
        {
            return;
        }

        try
        {
            var exercise = _exerciseService.AddCardioExercise(
                user.Id,
                routine.Id,
                name ?? string.Empty,
                muscleGroup,
                TimeSpan.FromMinutes(durationMinutes),
                distance);

            if (exercise is null)
            {
                Console.WriteLine("Routine not found.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Exercise created successfully: {exercise.Name}");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }

    private static bool TryParseMuscleGroup(
    string? input,
    out MuscleGroup muscleGroup)
    {
        muscleGroup = default;

        return input switch
        {
            "1" => SetMuscleGroup(
                MuscleGroup.Chest,
                out muscleGroup),

            "2" => SetMuscleGroup(
                MuscleGroup.Back,
                out muscleGroup),

            "3" => SetMuscleGroup(
                MuscleGroup.Legs,
                out muscleGroup),

            "4" => SetMuscleGroup(
                MuscleGroup.Shoulders,
                out muscleGroup),

            "5" => SetMuscleGroup(
                MuscleGroup.Arms,
                out muscleGroup),

            _ => false
        };
    }

    private static bool SetMuscleGroup(
    MuscleGroup value,
    out MuscleGroup muscleGroup)
    {
        muscleGroup = value;
        return true;
    }
}