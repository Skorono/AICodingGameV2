namespace AICodingGame.Database.Model;

public class Robot
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string DllPath { get; set; } = null!;
}