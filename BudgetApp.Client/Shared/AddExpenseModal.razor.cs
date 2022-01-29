using System.ComponentModel;
using BudgetApp.Client.Components;
using BudgetApp.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Shared
{
    public partial class AddExpenseModal : ComponentBase, IDisposable
    {
        [CascadingParameter]
        public IBudgetsPageViewModel BudgetsPageViewModel { get; set; }

        private Modal _modal;
        private PropertyChangedEventHandler _eventHandler;
        private IExpenseViewModel _expense;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _expense = new ExpenseViewModel();
            _eventHandler = (s, e) => StateHasChanged();
            _expense.PropertyChanged += _eventHandler;
        }

        public async Task Show(Guid? budgetId = null)
        {
            if (budgetId != null)
            {
                _expense.BudgetId = (Guid)budgetId;
            }
            await _modal.Show();
        }

        private async Task AddExpense()
        {
            _expense.Id = Guid.NewGuid();
            await BudgetsPageViewModel.AddExpense(_expense);
            await _modal.Close();
        }

        private Task ResetViewModel()
        {
            _expense = new ExpenseViewModel();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _expense.PropertyChanged -= _eventHandler;
        }
    }
}
