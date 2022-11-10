namespace WebAPIVk.Services
{
    public interface ITimeLoger<T0,T1,T2>
    {
        public Task<T0>  SaveTimeToFile(T1 start,T2 finish);
    }
}
