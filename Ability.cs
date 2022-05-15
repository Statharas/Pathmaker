using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pathmaker
{
    public class Ability
    {
        public string Name { get; set; }

        public Ability(string name)
        {
            Name = name;
        }

        public event Action? Refresh;

        [JsonIgnore] private readonly int[] _pointCosts =
        {
            -30, -25,
            -20, -16,
            -12, -9,
            -6, -4,
            -2, -1,
            0, 1,
            2, 3,
            5, 7,
            10, 13,
            17, 21,
            26, 31
        };

        [JsonIgnore] public int Modifier => (int)Math.Floor((decimal)(Total - 10) / 2);
        [JsonIgnore] public string ModifierStringified => Modifier < 0 ? $"{Modifier}" : $"+{Modifier}";

        public int Value { get; set; } = 10;
        public int Temp { get; set; } = 0;
        public int Misc { get; set; } = 0;

        [JsonIgnore]
        public int Total =>
            Value + Temp + Misc;

        [JsonIgnore]
        public int PointCost =>
            _pointCosts[Value];

        [JsonIgnore]
        public int NextCost =>
            _pointCosts[Value + 1] - _pointCosts[Value];

        public void Add(int a, int maxPoints)
        {
            if (Value + a is < 7 or > 18)
                return;
            if (a > 0 && _pointCosts[Value + a] > maxPoints + _pointCosts[Value])
                return;
            Value += a;
            OnUpdate();
        }

        public void Set(int a)
        {
            if (a < 7)
                a = 7;
            if (a > 18)
                a = 18;
            Value = a;
            OnUpdate();
        }

        public bool CanGoTo(int target, int maxPoints)
        {
            if (target is < 7 or > 18)
                return false;
            return _pointCosts[target] - _pointCosts[Value] <= maxPoints;
        }

        void OnUpdate() => Refresh?.Invoke();
    }
}