using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BudgetApp.Client.ViewModels
{
    public interface IBudgetsPageViewModel : IViewModel
    {
        List<IBudgetViewModel> Budgets { get; set; }
        List<IExpenseViewModel> Expenses { get; set; }
        void GetBudgetExpenses(Guid budgetId);
        void AddBudget(IBudgetViewModel budget);
        void AddExpense(IExpenseViewModel expense);
        void DeleteBudget(IBudgetViewModel budget);
        void DeleteExpense(IExpenseViewModel expense);
    }

    public class BudgetsPageViewModel : ObservableObject, IBudgetsPageViewModel
    {
        //Backing Fields
        private List<IBudgetViewModel> _budgets;
        private List<IExpenseViewModel> _expenses;

        //Properties
        public List<IBudgetViewModel> Budgets
        {
            get => _budgets;
            set => SetProperty(ref _budgets, value, nameof(Budgets));
        }
        public List<IExpenseViewModel> Expenses
        {
            get => _expenses;
            set => SetProperty(ref _expenses, value, nameof(Expenses));
        }

        public void GetBudgetExpenses(Guid budgetId)
        {
            throw new NotImplementedException();
        }

        public void AddBudget(IBudgetViewModel budget)
        {
            throw new NotImplementedException();
        }

        public void AddExpense(IExpenseViewModel expense)
        {
            throw new NotImplementedException();
        }

        public void DeleteBudget(IBudgetViewModel budget)
        {
            throw new NotImplementedException();
        }

        public void DeleteExpense(IExpenseViewModel expense)
        {
            throw new NotImplementedException();
        }
    }
}
