namespace WebAPIVk.Services
{
    public interface IPreparationStr<T>
    {
        public Task<T> OnlyLetters(T list);
    }
}
