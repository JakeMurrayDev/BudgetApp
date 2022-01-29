using FluentValidation;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BudgetApp.Client.ViewModels
{
    public interface IExpenseViewModel : IViewModel
    {
        Guid Id { get; set; }
        Guid BudgetId { get; set; }
        string Description { get; set; }
        double Amount { get; set; }
    }

    public class ExpenseViewModel : ObservableObject, IExpenseViewModel
    {
        //Backing Fields
        private Guid _id;
        private Guid _budgetId;
        private string _description;
        private double _amount;

        //Properties
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public Guid BudgetId
        {
            get => _budgetId;
            set => SetProperty(ref _budgetId, value, nameof(BudgetId));
        }
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value, nameof(Description));
        }
        public double Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value, nameof(Amount));
        }

    }

    public class ExpenseValidator : AbstractValidator<ExpenseViewModel>
    {
        public ExpenseValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.BudgetId).NotEmpty()
                .WithMessage("Please select a budget.");
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty()
                .WithMessage("Amount must not be empty and must be greater than zero.");
        }
    }
}
