using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Webapplication.User.Database.AppDbContexModels;

namespace ConsoleAppUser
{
    public class UserServices
    {
        public class UserService
        {
            private readonly HttpClient _client;

            public UserService(string baseUrl)
            {
                _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
            }

            public async Task GetUsersAsync()
            {
                var users = await _client.GetFromJsonAsync<List<TblUser>>("users");
                if (users != null && users.Any())
                {
                    foreach (var u in users)
                    {
                        Console.WriteLine($"{u.UserId}: {u.Name} ({u.Department}) - {u.Email} - {u.MobileNo} - {u.Address} - Salary: {u.Salary} - Deleted: {u.IsDelete}");
                    }
                }
                else
                {
                    Console.WriteLine("No users found.");
                }
            }

            public async Task GetUserByIdAsync()
            {
                Console.Write("Enter User ID: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var user = await _client.GetFromJsonAsync<TblUser>($"users/{id}");
                    if (user != null)
                    {
                        Console.WriteLine($"{user.UserId}: {user.Name} ({user.Department}) - {user.Email} - {user.MobileNo} - {user.Address} - Salary: {user.Salary} - Deleted: {user.IsDelete}");
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
            }

            public async Task AddUserAsync()
            {
                var user = new TblUser();

                Console.Write("Name: "); user.Name = Console.ReadLine() ?? "";
                Console.Write("Department: "); user.Department = Console.ReadLine() ?? "";
                Console.Write("Email: "); user.Email = Console.ReadLine() ?? "";
                Console.Write("Salary: "); user.Salary = decimal.TryParse(Console.ReadLine(), out var salary) ? salary : 0;
                Console.Write("Mobile No: "); user.MobileNo = Console.ReadLine() ?? "";
                Console.Write("Address: "); user.Address = Console.ReadLine() ?? "";
                user.IsDelete = false;

                var response = await _client.PostAsJsonAsync("users", user);
                Console.WriteLine(response.IsSuccessStatusCode ? "User added successfully." : "Error adding user.");
            }

            public async Task UpdateUserAsync()
            {
                Console.Write("Enter User ID to update: ");
                if (!int.TryParse(Console.ReadLine(), out int id)) return;

                var existing = await _client.GetFromJsonAsync<TblUser>($"users/{id}");
                if (existing == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                Console.Write($"Name ({existing.Name}): ");
                var name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) existing.Name = name;

                Console.Write($"Department ({existing.Department}): ");
                var dept = Console.ReadLine();
                if (!string.IsNullOrEmpty(dept)) existing.Department = dept;

                Console.Write($"Email ({existing.Email}): ");
                var email = Console.ReadLine();
                if (!string.IsNullOrEmpty(email)) existing.Email = email;

                Console.Write($"Salary ({existing.Salary}): ");
                var salaryStr = Console.ReadLine();
                if (decimal.TryParse(salaryStr, out var salary)) existing.Salary = salary;

                Console.Write($"MobileNo ({existing.MobileNo}): ");
                var mobile = Console.ReadLine();
                if (!string.IsNullOrEmpty(mobile)) existing.MobileNo = mobile;

                Console.Write($"Address ({existing.Address}): ");
                var address = Console.ReadLine();
                if (!string.IsNullOrEmpty(address)) existing.Address = address;

                Console.Write($"IsDelete ({existing.IsDelete}): ");
                var delStr = Console.ReadLine();
                if (bool.TryParse(delStr, out var isDelete)) existing.IsDelete = isDelete;

                var response = await _client.PutAsJsonAsync($"users/{id}", existing);
                Console.WriteLine(response.IsSuccessStatusCode ? "User updated successfully." : "Error updating user.");
            }

            public async Task DeleteUserAsync()
            {
                Console.Write("Enter User ID to delete (soft): ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var response = await _client.DeleteAsync($"users/{id}");
                    Console.WriteLine(response.IsSuccessStatusCode ? "User soft-deleted successfully." : "Error deleting user.");
                }
            }
        }
    }
}
