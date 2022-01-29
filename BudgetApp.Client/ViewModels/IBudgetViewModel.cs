using FluentValidation;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace BudgetApp.Client.ViewModels
{
    public interface IBudgetViewModel : IViewModel
    {
        Guid Id { get; set; }
        string? Name { get; set; }
        double Max { get; set; }
    }

    public class BudgetViewModel : ObservableObject, IBudgetViewModel
    {
        //Backing Fields
        private Guid _id;
        private string? _name;
        private double _max;

        //Properties
        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }
        public double Max
        {
            get => _max;
            set => SetProperty(ref _max, value, nameof(Max));
        }
    }

    public class BudgetValidator : AbstractValidator<BudgetViewModel>
    {
        public BudgetValidator()
        {
            //RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Max).NotEmpty()
                .WithMessage("Max must not be empty and must be greater than zero.");
        }
    }
}
