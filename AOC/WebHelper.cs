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
            {
                return File.ReadAllText(filename);
            }
            else
            {
                var wb = new WebBrowser();
                wb.Navigate($"http://adventofcode.com/{year}/day/{day}/input");
                while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }
                var s = wb.Document.Body.InnerText;
                File.WriteAllText(filename, s);
                return s;
            }
        }
    }
}