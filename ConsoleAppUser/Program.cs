
using static ConsoleAppUser.UserServices;

class Program
{
    static async Task Main()
    {
        var service = new UserService("https://localhost:7220/api/"); 
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n--- User Management ---");
            Console.WriteLine("1. View all users");
            Console.WriteLine("2. View user by ID");
            Console.WriteLine("3. Add user");
            Console.WriteLine("4. Update user");
            Console.WriteLine("5. Delete user (soft delete)");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": await service.GetUsersAsync(); break;
                case "2": await service.GetUserByIdAsync(); break;
                case "3": await service.AddUserAsync(); break;
                case "4": await service.UpdateUserAsync(); break;
                case "5": await service.DeleteUserAsync(); break;
                case "0": running = false; break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
