namespace WebAPIVk.Services
{
    public interface IConverterToDb<T0,T1>
    {
        public Task<T0> DicToListStr(T1 value);
    }
}
