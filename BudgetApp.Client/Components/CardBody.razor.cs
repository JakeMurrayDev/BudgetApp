using BudgetApp.Client.Base;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class CardBody : CommonBase
    {
        [CascadingParameter]
        public Card? Parent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CheckParentIfNull(Parent, this);
        }
    }
}
