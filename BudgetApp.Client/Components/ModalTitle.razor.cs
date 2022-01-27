using BudgetApp.Client.Base;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class ModalTitle : CommonBase
    {
        [CascadingParameter]
        public Modal? Parent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CheckParentIfNull(Parent, this);
        }
    }
}
