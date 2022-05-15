using Microsoft.JSInterop;
using System.Text;
using System.Text.Json;
using BlazorDownloadFile;

namespace Pathmaker
{
    public static class IO
    {
        public static string File = "";

        public static async Task DownloadFile(string data, IJSRuntime runtime)
        {
            Console.WriteLine(data);
            var stream = Streamify(data);
            var downloadData = new DotNetStreamReference(stream);

            await runtime.InvokeVoidAsync("downloadFileFromStream", "Roster.Pathmaker", downloadData);
        }

        public static Stream Streamify(string data = "Invalid String") =>
            new MemoryStream(Encoding.ASCII.GetBytes(data));

        public static List<Character> GetRosterFromFile()
        {
            var q=JsonSerializer.Deserialize<List<Character>>(File);
            Console.WriteLine(q[0].Scores.Strength);
            return q;
        }
    }
}