using BlazorComponent;
using Microsoft.JSInterop;

namespace Gotrays.Desktop.Share.Compontens
{
    public partial class GMenu
    {
        private StringNumber _selectedItem = 0;
        private Item[] _items = new Item[]
        {
           new Item { Text= "My Files", Icon= "mdi-folder" },
           new Item { Text= "Shared with me", Icon= "mdi-account-multiple" },
           new Item { Text= "Starred", Icon= "mdi-star" },
           new Item { Text= "Recent", Icon= "mdi-history" },
           new Item { Text= "Offline", Icon= "mdi-check-circle" },
           new Item { Text= "Uploads", Icon= "mdi-upload" },
           new Item { Text= "Backups", Icon= "mdi-cloud-upload" }
        };

        class Item
        {
            public string Text { get; set; }
            public string Icon { get; set; }
        }

        private async Task OnGitHub()
        {
            await JSRuntime.InvokeVoidAsync("open", "https://github.com/239573049/gotrays-desktop");
        }
    }
}
