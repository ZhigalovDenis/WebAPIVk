using System.Globalization;

namespace WebAPIVk.Services
{
    public class TimeLoger : ITimeLoger<bool, string, TimeSpan>
    {
        public async Task<bool> SaveTimeToFile(string start, TimeSpan finish)
        {
            
            return await Task.Run(() =>
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Log.txt";

                string _finish = start + finish;

                // добавление в файл
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                     writer.WriteLine("Начало выполненмя расчета-" + start);
                     writer.WriteLine("Начало выполненмя расчета-" + _finish);
                }
                return true;
            });
        }
    }
}
