using System;
using System.Text.Json.Serialization;

namespace Pathmaker
{
    public class AbilityScore
    {
        public event Action Refresh;

        public AbilityScore()
        {
            Reset();
        }

        public enum PointBuy
        {
            EpicFantasy = 25,
            HighFantasy = 20,
            StandardFantasy = 15,
            LowFantasy = 10
        }

        public Ability Strength { get; set; } = new("Strength");
        public Ability Dexterity { get; set; } = new("Dexterity");
        public Ability Constitution { get; set; } = new("Constitution");
        public Ability Intelligence { get; set; } = new("Intelligence");
        public Ability Wisdom { get; set; } = new("Wisdom");
        public Ability Charisma { get; set; } = new("Charisma");

        public PointBuy StartingPoints { get; set; } = PointBuy.StandardFantasy;

        public int Points => (int)StartingPoints - Strength.PointCost - Dexterity.PointCost
                             - Constitution.PointCost - Intelligence.PointCost
                             - Wisdom.PointCost - Charisma.PointCost;
        

        public void SetToPointBuy(PointBuy x)
        {
            StartingPoints = x;
            OnUpdate();
        }

        void Reset()
        {
            Strength.Set(10);
            Dexterity.Set(10);
            Constitution.Set(10);
            Intelligence.Set(10);
            Wisdom.Set(10);
            Charisma.Set(10);
        }

        public void OnUpdate() => Refresh?.Invoke();
    }
}