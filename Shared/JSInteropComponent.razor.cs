using System.Security.Cryptography.Xml;
using Microsoft.JSInterop;

namespace PassLongStringFromClient.Shared;

public partial class JSInteropComponent {
    IJSObjectReference? module;
    int length = 0;
    protected override async Task OnAfterRenderAsync(bool firstRender) {
        if (firstRender) {
            module = await jsRuntime.InvokeAsync<IJSObjectReference>("import", "./script.js");
        }
    }

    async void CallJS() {
        string? str = null;
        IJSStreamReference? jsStream = await Prompt("After you will press ok, long string will be generated");
        if (jsStream != null) {
            using Stream referenceStream = await jsStream.OpenReadStreamAsync();
            byte[] byteArray = new byte[referenceStream.Length];
            int byteArrayCount = await referenceStream.ReadAsync(byteArray);
            str =  System.Text.Encoding.Default.GetString(byteArray, 0, byteArrayCount);
        }
        length = str?.Length ?? 0;
        this.StateHasChanged();
    }

    public async ValueTask<IJSStreamReference?> Prompt(string message) => module is not null ? await module.InvokeAsync<IJSStreamReference>("showPrompt", message) : null;
}
