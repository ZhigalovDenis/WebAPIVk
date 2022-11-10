using System.Diagnostics;
using System.Globalization;

namespace WebAPIVk.Services
{
    public class CalculateLetters : ICalculateLetters<List<SortedDictionary<char, int>>, List<string>>
    {
        /// <summary>
        /// Считает вхождения букв в стоках
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<SortedDictionary<char, int>>> Calculate(List<string> value)
        {
            return await Task.Run(() =>
            {
                int counter = 0;
                List<SortedDictionary<char, int>> listdic = new List<SortedDictionary<char, int>>();

                Stopwatch stopWatch = new Stopwatch();
                string startTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff",
                                            CultureInfo.InvariantCulture);
                startTime = startTime.Replace("-", ".");
                stopWatch.Start();

                foreach (var str in value)
                {
                    SortedDictionary<char, int> letters = new SortedDictionary<char, int>();

                    foreach (var item in str)
                    {
                        if (letters.ContainsKey(item) == false)
                        {
                            counter = 0;    
                            letters.Add(item, counter);
                        }
                        else
                        {
                            counter += 1;
                            letters[item] = counter;
                        }
                    }
                    listdic.Add(letters);
                    
                }
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                var timeLoger = new TimeLoger();
                timeLoger.SaveTimeToFile(startTime, ts);

                return listdic;
            });
        }
    }   
}
