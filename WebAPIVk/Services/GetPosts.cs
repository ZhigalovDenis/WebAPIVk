using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace WebAPIVk.Services
{
    public class GetPosts : IPosts<List<string>, int>
    {
        const int COUNT = 5;
        VkApi api = new VkApi();
        List<string> posts = new List<string>();

        /// <summary>
        /// Получить посты со стены
        /// </summary>
        /// <param name="_OwnerId"></param>
        /// <returns></returns>
        public async Task<List<string>> GivePosts(int _OwnerId)
        {
            return await Task.Run(() =>
            {
                GetAccess();
                var get = api.Wall.Get(new WallGetParams
                {
                    OwnerId = _OwnerId,
                    Count = COUNT,
                });

                foreach (var post in get.WallPosts)
                {
                    posts.Add(post.Text);
                }

                return posts;
            });
        }

        /// <summary>
        /// Получаем доступ к API через сервисный ключ
        /// </summary>
        /// <returns></returns>
        private  void GetAccess()
        {
            api.Authorize(new ApiAuthParams
            {
                AccessToken = "a8beca84a8beca84a8beca842cabafac41aa8bea8beca84cbd529d0520b8a151a658206"
            });
        }



    }
}
