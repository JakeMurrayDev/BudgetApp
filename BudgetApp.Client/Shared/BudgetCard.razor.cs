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
        [Parameter]
        public bool IsGray { get; set; }
        [Parameter]
        public bool IsHideButtons { get; set; }
        [Parameter]
        public Func<Task>? OnAddExpenseClick { get; set; }
        [Parameter]
        public Func<Task>? OnViewExpensesClick { get; set; }

        private string Variant
        {
            get
            {
                var ratio = Amount / Max;
                return ratio switch
                {
                    < 0.5 => "bg-primary",
                    < 0.75 => "bg-warning",
                    _ => "bg-danger"
                };
            }
        }

        private string? CardBackgroundColor
        {
            get
            {
                if (IsGray)
                {
                    return "bg-light";
                }
                return Amount > Max ? "bg-danger bg-opacity-10" : null;
            }
        }

        private async Task AddExpense()
        {
            if (OnAddExpenseClick != null)
            {
                await OnAddExpenseClick.Invoke();
            }
        }

        private async Task ViewExpenses()
        {
            if (OnViewExpensesClick != null)
            {
                await OnViewExpensesClick.Invoke();
            }
        }
    }
}
