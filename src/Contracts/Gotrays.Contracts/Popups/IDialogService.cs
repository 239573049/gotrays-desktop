namespace Gotrays.Contracts.Popups
{
    public interface IDialogService
    {
        Task Error(string message);

        Task Success(string message);

        Task Warning(string message);

        Task Info(string message);
    }
}
