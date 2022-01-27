using BudgetApp.Client.Base;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class ProgressBar : CommonBase
    {
        [CascadingParameter]
        public Progress? Parent { get; set; }
        [Parameter]
        [EditorRequired]
        public double? Min { get; set; }
        [Parameter]
        [EditorRequired]
        public double? Value { get; set; }
        [Parameter]
        [EditorRequired]
        public double? Max { get; set; }

        internal double? Percentage => Value / Max * 100;
    }
}
