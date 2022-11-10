namespace WebAPIVk.Services
{
    public interface ICalculateLetters<T0,T1>
    {
        public Task<T0> Calculate(T1 value);    
    }
}
