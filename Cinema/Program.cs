using Cinema;
using Cinema.Models;
using static System.Console;

try
{
    Write("1 - Visitor\n2 - Admin\n: ");
    var choice = ReadKey().Key;

    Clear();
    if (choice == ConsoleKey.D1)
    {
        HandleVisitor();
    }
    else if (choice == ConsoleKey.D2)
    {
        HandleAdmin();
    }
    else throw new Exception("Invalid choice");
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}

void HandleAdmin()
{
    while (true)
    {
        Write("Esc - Exit\n1 - Remove customer\n2 - Remove hall\n3 - Remove movie\n4 - Remove session\n5 - Remove ticket\n6 - Add hall\n7 - Add movie\n8 - Add session\n9 - Show all customers\n0 - Show all tickets\n: ");
        var choice = ReadKey().Key;

        Clear();
        switch (choice)
        {
            case ConsoleKey.Escape:
                WriteLine("Goodbye!");
                return;
            case ConsoleKey.D1:
                Admin.RemoveCustomer();
                break;
            case ConsoleKey.D2:
                Admin.RemoveHall();
                break;
            case ConsoleKey.D3:
                Admin.RemoveMovie();
                break;
            case ConsoleKey.D4:
                Admin.RemoveSession();
                break;
            case ConsoleKey.D5:
                Admin.RemoveTicket();
                break;
            case ConsoleKey.D6:
                Admin.AddHall();
                break;
            case ConsoleKey.D7:
                Admin.AddMovie();
                break;
            case ConsoleKey.D8:
                Admin.AddSession();
                break;
            case ConsoleKey.D9:
                CinemaInfo.ShowAllCustomers();
                break;
            case ConsoleKey.D0:
                CinemaInfo.ShowAllTickets();
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
    while (true)
    {
        Write("Esc - Exit\n1 - Show all halls\n2 - Show all movies\n3 - Show all sessions\n4 - Book a ticket\n: ");
        var choice = ReadKey().Key;

        Clear();
        switch (choice)
        {
            case ConsoleKey.Escape:
                WriteLine("Goodbye!");
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
                string firstName, lastName, email, phoneNumber;

                Write("Enter first name: ");
                firstName = ReadLine() ?? throw new Exception("Invalid first name input");
                Write("Enter last name: ");
                lastName = ReadLine() ?? throw new Exception("Invalid last name input");
                Write("Email: ");
                email = ReadLine() ?? throw new Exception("Invalid email input");
                Write("Phone number: ");
                phoneNumber = ReadLine() ?? throw new Exception("Invalid phone number input");

                Visitor visitor = new(firstName, lastName, email, phoneNumber);
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
