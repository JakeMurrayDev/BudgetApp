using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Base
{
    public abstract class CommonBase : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
    }
}
