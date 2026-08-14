using Application;
using Application.Services;

namespace GymTraining.ConsoleApp.UI;

public class RoutineMenu
{
    private readonly RoutineService _routineService;
    private readonly AppSession _session;

    public RoutineMenu(
        RoutineService routineService,
        AppSession session)
    {
        _routineService = routineService;
        _session = session;
    }

    public void Run()
    {
        var running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== Routines ===");
            Console.WriteLine();

            Console.WriteLine("1. Create routine");
            Console.WriteLine("2. View routines");
            Console.WriteLine("3. Back");
            Console.WriteLine();

            Console.Write("Select an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateRoutine();
                    break;

                case "2":
                    ViewRoutines();
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

    private void CreateRoutine()
    {
        var user = _session.CurrentUser;

        if (user is null)
        {
            return;
        }

        Console.Clear();

        Console.WriteLine("=== Create Routine ===");
        Console.WriteLine();

        Console.Write("Name: ");
        var name = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("Training goal:");
        Console.WriteLine("1. General Fitness");
        Console.WriteLine("2. Strength");
        Console.WriteLine("3. Muscle Gain");
        Console.WriteLine("4. Weight Loss");
        Console.WriteLine();

        Console.Write("Select a goal: ");
        var goalInput = Console.ReadLine();

        if (!TryParseTrainingGoal(goalInput, out var goal))
        {
            Console.WriteLine("Invalid training goal.");
            Console.ReadKey();
            return;
        }

        try
        {
            var routine = _routineService.CreateRoutine(
                user.Id,
                name ?? string.Empty,
                goal);

            if (routine is null)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    $"Routine created successfully: {routine.Name}");
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }

    private void ViewRoutines()
    {
        var user = _session.CurrentUser;

        if (user is null)
        {
            return;
        }

        Console.Clear();

        Console.WriteLine("=== My Routines ===");
        Console.WriteLine();

        if (user.Routines.Count == 0)
        {
            Console.WriteLine("No routines registered.");
        }
        else
        {
            var number = 1;

            foreach (var routine in user.Routines)
            {
                Console.WriteLine(
                    $"{number}. {routine.Name} - {routine.TrainingGoal}");

                number++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static bool TryParseTrainingGoal(
        string? input,
        out Domain.Enums.TrainingGoal goal)
    {
        goal = default;

        return input switch
        {
            "1" => SetGoal(
                Domain.Enums.TrainingGoal.GeneralFitness,
                out goal),

            "2" => SetGoal(
                Domain.Enums.TrainingGoal.Strength,
                out goal),

            "3" => SetGoal(
                Domain.Enums.TrainingGoal.MuscleGain,
                out goal),

            "4" => SetGoal(
                Domain.Enums.TrainingGoal.WeightLoss,
                out goal),

            _ => false
        };
    }

    private static bool SetGoal(    
        Domain.Enums.TrainingGoal value,
        out Domain.Enums.TrainingGoal goal)
    {
        goal = value;
        return true;
    }
}