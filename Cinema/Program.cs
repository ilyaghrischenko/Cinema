using Cinema;
using Microsoft.EntityFrameworkCore;
using static System.Console;

try
{
    CinemaInfo.ShowAllTickets();
}
catch (Exception ex)
{
    WriteLine(ex.Message);
}