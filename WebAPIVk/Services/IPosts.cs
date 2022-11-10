namespace WebAPIVk.Services
{
    public interface IPosts<T0,T1>
    { 
        public Task<T0> GivePosts(T1 _OwnerId);
    }
}
