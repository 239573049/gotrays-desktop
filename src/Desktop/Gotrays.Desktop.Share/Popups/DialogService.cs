using Gotrays.Contracts.Popups;
using Masa.Blazor;
using Token.Dependency;

namespace Gotrays.Desktop.Share.Popups
{
    public class DialogService : IDialogService, IScopedDependency
    {
        private readonly IPopupService _popupService;

        public DialogService(IPopupService popupService)
        {
            _popupService = popupService;
        }

        public async Task Error(string message)
        {
            await _popupService.EnqueueSnackbarAsync(message, AlertTypes.Error);
        }

        public async Task Info(string message)
        {
            await _popupService.EnqueueSnackbarAsync(message, AlertTypes.Info);
        }

        public async Task Success(string message)
        {
            await _popupService.EnqueueSnackbarAsync(message, AlertTypes.Success);
        }

        public async Task Warning(string message)
        {
            await _popupService.EnqueueSnackbarAsync(message, AlertTypes.Warning);
        }
    }
}
