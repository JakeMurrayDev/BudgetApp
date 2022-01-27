using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class ModalClose : ComponentBase
    {
        [CascadingParameter]
        public Modal? Parent { get; set; }
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Parent == null)
            {
                throw new ArgumentNullException(nameof(Parent), "ModalClose should be inside of Modal.");
            }
        }
    }
}
