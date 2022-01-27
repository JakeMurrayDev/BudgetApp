using BudgetApp.Client.Base;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class Modal : CommonBase
    {
        [Parameter]
        public bool Centered { get; set; }

        bool _isDisplayed;

        public void Show()
        {
            _isDisplayed = true;
        }
        public void Close()
        {
            _isDisplayed = false;
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
