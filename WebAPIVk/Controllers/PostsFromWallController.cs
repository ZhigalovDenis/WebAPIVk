using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPIVk.Models;
using WebAPIVk.Repositories;
using WebAPIVk.Services;

namespace WebAPIVk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsFromWallController : ControllerBase
    {
        private readonly IPosts<List<string>, int> _posts;
        private readonly IPreparationStr<List<string>> _preparationStr;
        private readonly ICalculateLetters<List<SortedDictionary<char, int>>, List<string>> _calculateLetters;
        private readonly IConverterToDb<List<string>, List<SortedDictionary<char, int>>> _convert;
        private readonly IBaseRepository<LetterFromPost> _letterFromPost;
        public PostsFromWallController(IPosts<List<string>, int> posts, IPreparationStr<List<string>> preparationStr
            ,ICalculateLetters<List<SortedDictionary<char, int>>, List<string>> calculateLetters
            , IConverterToDb<List<string>, List<SortedDictionary<char, int>>> convert
            , IBaseRepository<LetterFromPost> letterFromPost)
        {
            _posts = posts;
            _preparationStr = preparationStr;
            _calculateLetters = calculateLetters;
            _convert = convert;
            _letterFromPost = letterFromPost;
        }



        [HttpPost("{OwnerId}")]
        public async Task<IActionResult> Run(int OwnerId)
        {
            var posts = await _posts.GivePosts(OwnerId);    
            var preparatedPost = await _preparationStr.OnlyLetters(posts);
            var lettersDic = await _calculateLetters.Calculate(preparatedPost);
            var converted = await _convert.DicToListStr(lettersDic);

            LetterFromPost obj = new LetterFromPost{
                letters = converted
            };
            await _letterFromPost.Insert(obj);
            await _letterFromPost.Save();
            var y = 5;
            return Ok();
        }
    }
}
