using Gotrays.Contracts.Users;
using System.Text;
using Token.Dependency;

namespace Gotrays.Desktop.Service.Users
{
    public class StorageService : IStorageService, ISingletonDependency
    {
        private string? token;

        public string? Token
        {
            get
            {
                return token;
            }

            set
            {
                token = value;
                TokenChange?.Invoke();
            }
        }

        public Action? TokenChange { get; set; }
    }
}
