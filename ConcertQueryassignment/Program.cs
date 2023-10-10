// See https://aka.ms/new-console-template for more information

using ConcertQueryassignment;
using System.Text.Json;

string concertData = File.ReadAllText("C:\\Users\\bhuva\\source\\repos\\ConcertQueryassignment\\ConcertQueryassignment\\concert_data.json");

List<Concert> concerts = JsonSerializer.Deserialize<List<Concert>>(concertData);

// Queries 1

List<Concert> sortedByDate = concerts
        .Where(c => c.Date >= DateTime.Now)
        .OrderBy(c => c.Date)
        .ToList();
Console.WriteLine("\nConcerts at the Arena of the Ticket Office!!\n");
Console.WriteLine("Concerts ordered by Date from the present date:\n");
PrintConcerts(sortedByDate);


//  Queries 2

List<Concert> ReducedVenuetrue = concerts
           .Where(c => c.ReducedVenue)
           .ToList();
Console.WriteLine("\nConcerts with ReducedVenue(true):\n");
PrintConcerts(ReducedVenuetrue);


//  Queries 3
List<Concert> concerts2024 = concerts
           .Where(c => c.Date.Year == 2024)
           .ToList();
Console.WriteLine("\nConcerts during the year 2024:\n");
PrintConcerts(concerts2024);


//  Queries 4
List<Concert> biggest5SalesConcerts = concerts
           .OrderByDescending(c => c.FullCapacitySales)
           .Take(5)
           .ToList();
Console.WriteLine("\nThe five concerts with the biggest projected sales figures:\n");
PrintConcerts(biggest5SalesConcerts);


//  Queries 5
List<Concert> fridayConcerts = concerts
           .Where(c => c.Date.DayOfWeek == DayOfWeek.Friday)
           .ToList();
Console.WriteLine("\nConcerts taking place on a Friday:\n");
PrintConcerts(fridayConcerts);

static void PrintConcerts(List<Concert> concerts)
{
    foreach (var concert in concerts)
    {
        Console.WriteLine($"ID: {concert.Id}, Date: {concert.Date}, Performer: {concert.Performer}, BeginsAt:{concert.BeginsAt}, FullCapacitySales: {concert.FullCapacitySales} ");
    }
}

















