using System.Text;

namespace WebAPIVk.Services
{
    public class ConverterToDb : IConverterToDb<List<string>, List<SortedDictionary<char, int>>>
    {
        /// <summary>
        /// Конвертирует список словарей в список строк
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<string>> DicToListStr(List<SortedDictionary<char, int>> value)
        {
            return await Task.Run(() =>
            {
                List<string> letter = new List<string>();
                foreach (var list in value)
                {
                    StringBuilder strToList = new StringBuilder();
                    foreach (var str in list)
                    {
                        var outputStr = str.Key.ToString() + str.Value.ToString() + ';';  
                        strToList.Append(outputStr);
                    }
                    string start = "НачалоПостаНомер-" + letter.Count  + ";";
                    string finish = "КонецПостаНомер-" + letter.Count + ";";
                    strToList.Insert(0, start);
                    strToList.Insert(strToList.Length, finish);
                    letter.Add(strToList.ToString());
                }
                return letter;
            });
        }
    }
}
