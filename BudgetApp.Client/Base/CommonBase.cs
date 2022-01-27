using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Base
{
    public abstract class CommonBase : ComponentBase
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

        protected virtual void CheckParentIfNull<TParent, TChild>(TParent parent, TChild child)
        {
            if (parent == null)
            {
                Type parentType = typeof(TParent);
                Type childType = typeof(TChild);
                string message = $"{childType} must be inside of {parentType}.";
                throw new ArgumentNullException(nameof(parent), message);
            }
        }
    }
}
