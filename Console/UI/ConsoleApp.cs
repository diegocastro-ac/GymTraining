using Application;
using Application.Services;

namespace GymTraining.ConsoleApp.UI;

public class ConsoleApp
{
    private readonly UserService _userService;
    private readonly AppSession _session;

    public ConsoleApp(
        UserService userService,
        AppSession session)
    {
        _userService = userService;
        _session = session;
    }

    public void Run()
    {
        var running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("=== Gym Training ===");
            Console.WriteLine();

            if (_session.CurrentUser is not null)
            {
                Console.WriteLine(
                    $"Current user: {_session.CurrentUser.Name}");
                Console.WriteLine();
            }

            Console.WriteLine("1. Create user");
            Console.WriteLine("2. Select user");
            Console.WriteLine("3. Exit");
            Console.WriteLine();

            Console.Write("Select an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateUser();
                    break;

                case "2":
                    SelectUser();
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

    private void CreateUser()
    {
        Console.Clear();

        Console.WriteLine("=== Create User ===");
        Console.WriteLine();

        Console.Write("Name: ");

        var name = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Name cannot be empty.");
            Console.ReadKey();
            return;
        }

        try
        {
            var user = _userService.CreateUser(name);

            Console.WriteLine();
            Console.WriteLine(
                $"User created successfully: {user.Name}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine();
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }

    private void SelectUser()
    {
        var users = _userService.GetAllUsers();

        Console.Clear();

        Console.WriteLine("=== Select User ===");
        Console.WriteLine();

        if (users.Count == 0)
        {
            Console.WriteLine("No users registered.");
            Console.ReadKey();
            return;
        }

        var userList = users.ToList();

        for (var i = 0; i < userList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {userList[i].Name}");
        }

        Console.WriteLine();
        Console.Write("Select a user: ");

        var input = Console.ReadLine();

        if (!int.TryParse(input, out var selection) ||
            selection < 1 ||
            selection > userList.Count)
        {
            Console.WriteLine("Invalid selection.");
            Console.ReadKey();
            return;
        }

        _session.SelectUser(userList[selection - 1]);

        Console.WriteLine(
            $"User selected: {_session.CurrentUser.Name}");

        Console.ReadKey();
    }
}