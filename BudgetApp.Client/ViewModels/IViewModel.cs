using System.ComponentModel;

namespace BudgetApp.Client.ViewModels
{
    public interface IViewModel
    {
        event PropertyChangedEventHandler? PropertyChanged;
        event PropertyChangingEventHandler? PropertyChanging;
    }
}
