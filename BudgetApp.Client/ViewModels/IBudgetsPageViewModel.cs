using Blazored.LocalStorage;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BudgetApp.Client.ViewModels
{
    public interface IBudgetsPageViewModel : IViewModel
    {
        List<IBudgetViewModel> Budgets { get; set; }
        List<IExpenseViewModel> Expenses { get; set; }
        Task Initialize();
        double GetBudgetExpensesAmount(Guid? budgetId = null);
        double GetBudgetsMax();
        Task AddBudget(IBudgetViewModel budget);
        Task AddExpense(IExpenseViewModel expense);
        Task DeleteBudget(IBudgetViewModel budget);
        Task DeleteExpense(IExpenseViewModel expense);
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
            _budgets = new();
            _expenses = new();
        }

        public async Task Initialize()
        {
            _budgets = (await _localStorage.GetItemAsync<List<BudgetViewModel>>("budgets"))?
                .Cast<IBudgetViewModel>()
                .ToList()
                ?? new();
            _expenses = (await _localStorage.GetItemAsync<List<ExpenseViewModel>>("expenses"))?
                .Cast<IExpenseViewModel>()
                .ToList()
                ?? new();
        }

        public double GetBudgetExpensesAmount(Guid? budgetId = null)
        {
            if (budgetId == null)
            {
                return _expenses.Sum(x => x.Amount);
            }
            return _expenses.Where(x => x.BudgetId == budgetId)
                .Sum(x => x.Amount);
        }

        public double GetBudgetsMax()
        {
            return _budgets.Sum(x => x.Max);
        }

        public async Task AddBudget(IBudgetViewModel budget)
        {
            _budgets.Add(budget);
            await UpdateBudgets();
        }

        public async Task AddExpense(IExpenseViewModel expense)
        {
            _expenses.Add(expense);
            await UpdateExpenses();
        }

        public async Task DeleteBudget(IBudgetViewModel budget)
        {
            _budgets.Remove(budget);
            await UpdateBudgets();
        }

        public async Task DeleteExpense(IExpenseViewModel expense)
        {
            _expenses.Remove(expense);
            await UpdateExpenses();
        }

        private async Task UpdateBudgets()
        {
            OnPropertyChanged(nameof(Budgets));
            await _localStorage.SetItemAsync("budgets", Budgets);
        }

        private async Task UpdateExpenses()
        {
            OnPropertyChanged(nameof(Expenses));
            await _localStorage.SetItemAsync("expenses", Expenses);
        }
    }
}
