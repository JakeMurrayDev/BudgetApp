using BudgetApp.Client.Base;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class Modal : CommonBase
    {
        [Parameter]
        public bool Centered { get; set; }
        [Parameter]
        public Func<Task>? OnClose { get; set; }

        bool _isDisplayed;

        public Task Show()
        {
            _isDisplayed = true;
            StateHasChanged();
            return Task.CompletedTask;
        }
        public async Task Close()
        {
            if (OnClose != null)
            {
                await OnClose.Invoke();
            }
            _isDisplayed = false;
            StateHasChanged();
        }

        private string? GetModalCenterClass()
        {
            if (Centered)
            {
                return "modal-dialog-centered";
            }
            return null;
        }
    }
}
