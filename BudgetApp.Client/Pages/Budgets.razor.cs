using System.ComponentModel;
using BudgetApp.Client.Shared;
using BudgetApp.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Pages
{
    public partial class Budgets : ComponentBase, IDisposable
    {
        [Inject]
        public IBudgetsPageViewModel BudgetsPageViewModel { get; set; }

        private AddBudgetModal _addBudgetModal;
        private AddExpenseModal _addExpenseModal;
        private ViewExpensesModal _viewExpensesModal;
        private PropertyChangedEventHandler _budgetsPagePropertyChangedEventHandler;

        protected override async Task OnInitializedAsync()
        {
            _budgetsPagePropertyChangedEventHandler = (s, e) => StateHasChanged();
            BudgetsPageViewModel.PropertyChanged += _budgetsPagePropertyChangedEventHandler;
            await BudgetsPageViewModel.Initialize();
        }

        public void Dispose()
        {
            BudgetsPageViewModel.PropertyChanged -= _budgetsPagePropertyChangedEventHandler;
        }
    }
}
