using BudgetApp.Client.Components;
using BudgetApp.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Shared
{
    public partial class ViewExpensesModal : ComponentBase
    {
        [CascadingParameter]
        public IBudgetsPageViewModel BudgetsPageViewModel { get; set; }

        private Modal _modal;
        private IBudgetViewModel? _budget;

        public async Task Show(Guid budgetId)
        {
            if (budgetId == Guid.Empty)
            {
                _budget = new BudgetViewModel()
                {
                    Id = Guid.Empty,
                    Name = "Uncategorized",
                    Max = 0
                };
            }
            else
            {
                _budget = BudgetsPageViewModel.Budgets
                    .FirstOrDefault(x => x.Id == budgetId);
            }

            await _modal.Show();
        }

        private async Task DeleteBudget(IBudgetViewModel budget)
        {
            await BudgetsPageViewModel.DeleteBudget(_budget);
            await _modal.Close();
        }
    }
}
