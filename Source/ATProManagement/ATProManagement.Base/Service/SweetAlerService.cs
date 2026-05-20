using Microsoft.JSInterop;

namespace ATProManagement.Base
{
    public class SweetAlerService : ISweetAlertService
    {
        private readonly IJSRuntime _js;
        private bool _isOpen = false;
        public SweetAlerService(IJSRuntime js)
        {
            _js = js;
        }
        public async Task Success(string title, string message)
        {
            await CloseCurrent();
            await _js.InvokeVoidAsync(
                "swalService.success",
                title,
                message
            );
            _isOpen = true;
        }

        public async Task Error(string title, string message)
        {
            await CloseCurrent();
            await _js.InvokeVoidAsync(
                "swalService.error",
                title,
                message
            );
            _isOpen = true;
        }

        public async Task Warning(string title, string message)
        {
            await CloseCurrent();
            await _js.InvokeVoidAsync(
                "swalService.warning",
                title,
                message
            );
            _isOpen = true;
        }

        public async Task<bool> Confirm(string title, string message)
        {
            await CloseCurrent();
            _isOpen = true;
            return await _js.InvokeAsync<bool>(
                "swalService.confirm",
                title,
                message
            );
        }

        public async Task Loading(string title = "Loading...")
        {
            await CloseCurrent();
            await _js.InvokeVoidAsync(
                "swalService.loading",
                title
            );
            _isOpen = true;
        }

        public async Task Close()
        {
            await _js.InvokeVoidAsync(
                "swalService.close"
            );
            _isOpen = false;
        }

        public async Task Toast(string message)
        {
            await CloseCurrent();
            await _js.InvokeVoidAsync(
                "swalService.toast",
                message
            );
            _isOpen = true;
        }

        private async Task CloseCurrent()
        {
            if (_isOpen)
            {
                await _js.InvokeVoidAsync("swalService.close");

                _isOpen = false;

                await Task.Delay(100);
            }
        }
    }
}
