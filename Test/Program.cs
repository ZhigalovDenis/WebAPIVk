
using Test;
using VkNet.Model.RequestParams;
using VkNet.Model;
using VkNet;

var wallGet = new WallGet();
 wallGet.GetPostsFromWall();
var calc = new Calc();
calc.Counter();


var api = new VkApi();

api.Authorize(new ApiAuthParams
{
    AccessToken = "a8beca84a8beca84a8beca842cabafac41aa8bea8beca84cbd529d0520b8a151a658206"
});


Console.WriteLine(api.Token);

var get = api.Wall.Get(new WallGetParams
{
    OwnerId = 19888422,
    Count = 5,
});

int postsCount  = 0;
List<string> data = new List<string>();
foreach (var post in get.WallPosts)
{
    Console.WriteLine($"{postsCount} пост");
    Console.WriteLine(post.Text);
   var postDesc = post.Text;
    Console.WriteLine($"Дата публикации: {post.Date}");
  var  postDate = (DateTime)post.Date;
    data.Add(post.Text);
    postsCount++;
}


Console.ReadLine();


Console.WriteLine("Hello, World!");
