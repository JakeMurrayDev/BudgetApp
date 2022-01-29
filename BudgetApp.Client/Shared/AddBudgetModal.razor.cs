using System.ComponentModel;
using BudgetApp.Client.Components;
using BudgetApp.Client.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Shared
{
    public partial class AddBudgetModal : ComponentBase, IDisposable
    {
        [CascadingParameter]
        public IBudgetsPageViewModel BudgetsPageViewModel { get; set; }

        private Modal _modal;
        private PropertyChangedEventHandler _eventHandler;
        private IBudgetViewModel _budget;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _budget = new BudgetViewModel();
            _eventHandler = (s, e) => StateHasChanged();
            _budget.PropertyChanged += _eventHandler;
        }

        public void Show()
        {
            _modal.Show();
        }

        public void Close()
        {
            _modal.Close();
        }

        private void AddBudget()
        {
            _budget.Id = Guid.NewGuid();
            BudgetsPageViewModel.AddBudget(_budget);
            _budget = new BudgetViewModel();
            _modal.Close();
        }

        public void Dispose()
        {
            _budget.PropertyChanged -= _eventHandler;
        }
    }
}
