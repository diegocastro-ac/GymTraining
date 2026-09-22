using Application;
using Application.Factories;
using Domain.Enums;

namespace GymTraining.ConsoleApp.UI;

public class NutritionMenu
{
    private readonly NutritionPlanResolver _resolver;
    private readonly AppSession _session;

    public NutritionMenu(NutritionPlanResolver resolver, AppSession session)
    {
        _resolver = resolver;
        _session = session;
    }

    public void Run()
    {
        var user = _session.CurrentUser;

        if (user is null)
        {
            return;
        }

        Console.Clear();

        Console.WriteLine("=== Nutrition Plan ===");
        Console.WriteLine();

        Console.WriteLine("Training goal:");
        Console.WriteLine("1. Strength");
        Console.WriteLine("2. Weight Loss");
        Console.WriteLine();

        Console.Write("Select a goal: ");

        var input = Console.ReadLine();

        var goal = input switch
        {
            "1" => (TrainingGoal?)TrainingGoal.Strength,

            "2" => (TrainingGoal?)TrainingGoal.WeightLoss,

            _ => null
        };

        if (goal is null)
        {
            Console.WriteLine("Invalid option.");
            Console.ReadKey();
            return;
        }

        var factory = _resolver.Resolve(goal.Value);

        var plan = factory.CreatePlan();

        Console.Clear();

        Console.WriteLine("=== Nutrition Plan Generated ===");
        Console.WriteLine();
        Console.WriteLine($"User: {user.Name}");
        Console.WriteLine($"Goal: {goal.Value}");
        Console.WriteLine();

        Console.WriteLine(plan.Execute());

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}