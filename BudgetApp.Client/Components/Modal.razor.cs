using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class Modal : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
        [Parameter]
        public RenderFragment? Header { get; set; }
        [Parameter]
        public RenderFragment? Body { get; set; }
        [Parameter]
        public RenderFragment? Footer { get; set; }

        bool _isDisplayed;
        public void Show()
        {
            _isDisplayed = true;
        }
        public void Close()
        {
            _isDisplayed = false;
        }
    }
}
