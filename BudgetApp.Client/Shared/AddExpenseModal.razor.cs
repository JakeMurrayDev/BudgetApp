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

        public void Show()
        {
            _modal.Show();
        }

        private void AddExpense()
        {
            _expense.Id = Guid.NewGuid();
            BudgetsPageViewModel.AddExpense(_expense);
            _expense = new ExpenseViewModel();
            _modal.Close();
        }

        public void Dispose()
        {
            _expense.PropertyChanged -= _eventHandler;
        }
    }
}
