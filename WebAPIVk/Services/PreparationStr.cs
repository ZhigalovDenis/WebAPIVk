using System;

namespace WebAPIVk.Services
{
    public class PreparationStr : IPreparationStr<List<string>>
    {
        List<string> posts = new List<string>();

        /// <summary>
        /// Приводит строки к нижнему регистру, удаляет все кроме букв.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public async Task<List<string>> OnlyLetters(List<string> list)
        {
            return await Task.Run(() =>
            {
                foreach (var item in list)
                {
                    string lowerReg = item.ToLower();
                    string preparetedStr = new String(lowerReg.Where(Char.IsLetter).ToArray());
                    posts.Add(preparetedStr);
                }               
                return posts;
            });
        }
    }
}
