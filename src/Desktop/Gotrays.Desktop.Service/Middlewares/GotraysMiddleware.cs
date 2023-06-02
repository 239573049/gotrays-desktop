using Gotrays.Contracts.Popups;

namespace Gotrays.Desktop.Service.Middlewares
{
    public class GotraysMiddleware : ICallerMiddleware
    {
        private readonly IStorageService _storageService;
        private readonly IDialogService _dialogService;

        public GotraysMiddleware(IStorageService storageService, IDialogService dialogService)
        {
            _storageService = storageService;
            _dialogService = dialogService;
        }

        public async Task HandleAsync(MasaHttpContext masaHttpContext, CallerHandlerDelegate next, CancellationToken cancellationToken = default)
        {
            try
            {
                if (!string.IsNullOrEmpty(_storageService.Token))
                {
                    masaHttpContext.RequestMessage.Headers.Remove("Authorization");
                    masaHttpContext.RequestMessage.Headers.Add("Authorization", "Bearer " + _storageService.Token);
                }

                await next();

            }
            catch (Exception ex)
            {
                await _dialogService.Error(ex.Message);
            }
        }
    }
}
