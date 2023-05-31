namespace Gotrays.Contracts.Users
{
    public interface IStorageService
    {
       public string Token { get; set; }

        public Action TokenChange { get; set; }
    }
}
