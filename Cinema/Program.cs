using Microsoft.EntityFrameworkCore;
using Cinema.Models;
using System.ComponentModel.Design;
using Cinema;
using static System.Console;

try
{
    Write("1 - Visitor\n2 - Employee\n: ");
    var choice = ReadKey().Key;

    Clear();
    if (choice == ConsoleKey.D1)
    {
        HandleVisitor();
    }
    else if (choice == ConsoleKey.D2)
    {
        HandleEmployee();
    }
    else throw new Exception("Invalid choice");
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}

void HandleEmployee()
{
    //Write("Enter first name: ");
    //var firstName = ReadLine() ?? throw new Exception("Invalid first name input");
    //Write("Enter last name: ");
    //var lastName = ReadLine() ?? throw new Exception("Invalid last name input");
    //Write("Enter age: ");
    //if (!uint.TryParse(ReadLine(), out var age)) throw new Exception("Invalid age input");
    //Write("Email: ");
    //var email = ReadLine() ?? throw new Exception("Invalid email input");
    //Write("Phone number: ");
    //var phoneNumber = ReadLine() ?? throw new Exception("Invalid phone number input");

    //Employee employee = new(firstName, lastName, age, email, phoneNumber);
    Employee employee = new();
    while (true)
    {
        Write("Esc - Exit\n1 - Remove customer\n2 - Remove hall\n3 - Remove movie\n4 - Remove session\n5 - Remove ticket\n6 - Add hall\n7 - Add movie\n8 - Add session\n: ");
        var choice = ReadKey().Key;

        Clear();
        switch (choice)
        {
            case ConsoleKey.Escape:
                WriteLine("GoodBye!");
                return;
            case ConsoleKey.D1:
                employee.RemoveCustomer();
                break;
            case ConsoleKey.D2:
                employee.RemoveHall();
                break;
            case ConsoleKey.D3:
                employee.RemoveMovie();
                break;
            case ConsoleKey.D4:
                employee.RemoveSession();
                break;
            case ConsoleKey.D5:
                employee.RemoveTicket();
                break;
            case ConsoleKey.D6:
                employee.AddHall();
                break;
            case ConsoleKey.D7:
                employee.AddMovie();
                break;
            case ConsoleKey.D8:
                employee.AddSession();
                break;
            default:
                WriteLine("Invalid choice");
                break;
        }
        Write("Press any button...");
        ReadKey();
        Clear();
    }
}
void HandleVisitor()
{
    Visitor visitor = new();
    while (true)
    {
        Write("Esc - Exit\n1 - Show all halls\n2 - Show all movies\n3 - Show all sessions\n4 - Book a ticket\n: ");
        var choice = ReadKey().Key;

        Clear();
        switch (choice)
        {
            case ConsoleKey.Escape:
                WriteLine("GoodBye!");
                return;
            case ConsoleKey.D1:
                CinemaInfo.ShowAllHalls();
                break;
            case ConsoleKey.D2:
                CinemaInfo.ShowAllMovies();
                break;
            case ConsoleKey.D3:
                CinemaInfo.ShowAllSessions();
                break;
            case ConsoleKey.D4:
                visitor = new();
                visitor.BookSession();
                break;
            default:
                WriteLine("Invalid choice");
                break;
        }
        Write("Press any button...");
        ReadKey();
        Clear();
    }
}