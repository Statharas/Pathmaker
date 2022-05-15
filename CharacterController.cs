using System.Text.Json;

namespace Pathmaker
{
    public static class CharacterController
    {
        public static event Action? Refresh;
        public static event Action? OnActiveCharacterChange;

        public static List<Character> Characters { get; private set; } =
            new List<Character> { new Character(), new Character() };

        public static Character? ActiveCharacter = Characters[0];

        public static string CharactersSerialized()
        {
            var z = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var a = JsonSerializer.Serialize(Characters, z);
            return a;
        }

        public static void SetRoster(List<Character> list)
        {
            Characters = new List<Character>(0);
            Refresh?.Invoke();
            Characters = list;
            if (Characters.Count > 0)
                ActiveCharacter = Characters[0];
            Refresh?.Invoke();
            Console.WriteLine("Uploaded");
        }

        public static void SetRosterFromFile()
        {
            SetRoster(IO.GetRosterFromFile());
        }

        public static void SetCharacterActive(Character character)
        {
            ActiveCharacter = character;
            OnActiveCharacterChange?.Invoke();
        }

        public static void CreateCharacter()
        {
            Characters.Add(new());
            Refresh?.Invoke();
        }
    }
}