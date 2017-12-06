using System.IO;
using System.Windows.Forms;

namespace AoC
{
    public class WebHelper
    {
        
        public static string GetInput(int year, int day)
        {
            var filename = Path.Combine(Path.GetTempPath(), $"{year}{day:00}.aoc");
            if (File.Exists(filename))
                return File.ReadAllText(filename);

            var wb = new WebBrowser();
            wb.Navigate($"http://adventofcode.com/{year}/day/{day}/input");
            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
            var s = wb.Document?.Body?.InnerText;
            if (s == null) return null;
            if (s.Contains("HTTP 404")) return null;
            File.WriteAllText(filename, s);
            return s;
        }

        public static void SubmitAnswer(int year, int day, string answer, int part)
        {
            var wb = new WebBrowser();
            wb.Navigate($"http://adventofcode.com/{year}/day/{day}/input");
            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }

            var eInput = wb.Document?.GetElementById($"part{part}");
            eInput?.SetAttribute("value", answer);
            var eSubmit = wb.Document?.GetElementById($"part{part}");
            eSubmit?.InvokeMember("click");
        }

    }
}