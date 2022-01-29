using Blazored.LocalStorage;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BudgetApp.Client.ViewModels
{
    public interface IBudgetsPageViewModel : IViewModel
    {
        List<IBudgetViewModel> Budgets { get; set; }
        List<IExpenseViewModel> Expenses { get; set; }
        double GetBudgetExpensesAmount(Guid budgetId);
        void AddBudget(IBudgetViewModel budget);
        void AddExpense(IExpenseViewModel expense);
        void DeleteBudget(IBudgetViewModel budget);
        void DeleteExpense(IExpenseViewModel expense);
    }

    public class BudgetsPageViewModel : ObservableObject, IBudgetsPageViewModel
    {
        private readonly ILocalStorageService _localStorage;

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

        public BudgetsPageViewModel(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public double GetBudgetExpensesAmount(Guid budgetId)
        {
            return _expenses.Where(x => x.BudgetId == budgetId)
                .Sum(x => x.Amount);
        }

        public void AddBudget(IBudgetViewModel budget)
        {
            _budgets.Add(budget);
            OnPropertyChanged(nameof(Budgets));
        }

        public void AddExpense(IExpenseViewModel expense)
        {
            _expenses.Add(expense);
            OnPropertyChanged(nameof(Expenses));
        }

        public void DeleteBudget(IBudgetViewModel budget)
        {
            _budgets.Remove(budget);
            OnPropertyChanged(nameof(Budgets));
        }

        public void DeleteExpense(IExpenseViewModel expense)
        {
            _expenses.Add(expense);
            OnPropertyChanged(nameof(Expenses));
        }
    }
}
