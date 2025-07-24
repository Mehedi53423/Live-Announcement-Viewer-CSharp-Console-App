using Microsoft.AspNetCore.SignalR.Client;

class Program
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5080/announcement")
            .Build();

        connection.On<object>("ReceiveAnnouncement", announcement =>
        {
            Console.WriteLine("Announcement received:");
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(announcement, new System.Text.Json.JsonSerializerOptions { WriteIndented = true }));
        });

        await connection.StartAsync();
        Console.WriteLine("Connected to SignalR hub.");

        Console.ReadLine();
    }
}
