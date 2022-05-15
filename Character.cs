
namespace Pathmaker
{
    public class Character
    {
        public event Action Refresh;
        public AbilityScore Scores { get; set; } = new();
        public string Name { get; set; } = "Unnamed Character" + new Random().Next(0, 500);
        public string Image = Images.Nissa;

    }
}
