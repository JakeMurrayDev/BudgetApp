using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Shared
{
    public partial class BudgetCard : ComponentBase
    {
        [Parameter]
        public string? Name { get; set; }
        [Parameter]
        public double Amount { get; set; }
        [Parameter]
        public double Max { get; set; }

        internal string? Variant
        {
            get
            {
                var ratio = Amount / Max;
                if (ratio < 0.5)
                {
                    return "bg-primary";
                }
                else if (ratio < 0.75)
                {
                    return "bg-warning";
                }
                return "bg-danger";
            }
        }
    }
}
