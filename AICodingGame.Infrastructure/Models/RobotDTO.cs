namespace AICodingGame.Infrastructure.Services.Models
{
    [Serializable]
    public class RobotDto
    {
        public string Name { get; set; } = null!;
        public string Image { get; set; }
        public string ProjectPath { get; set; } = null!;
        public DateTime LastUpdated { get; set; }
    }   
}
