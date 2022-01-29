using BudgetApp.Client.Base;
using BudgetApp.Client.Enumerations;
using Microsoft.AspNetCore.Components;

namespace BudgetApp.Client.Components
{
    public partial class Button : CommonBase
    {
        [Parameter]
        public ButtonVariant Variant { get; set; }

        private string VariantClass
        {
            get
            {
                return Variant switch
                {
                    ButtonVariant.Primary => "btn-primary",
                    ButtonVariant.Secondary => "btn-secondary",
                    ButtonVariant.Warning => "btn-warning",
                    ButtonVariant.Info => "btn-info",
                    ButtonVariant.Danger => "btn-danger",
                    ButtonVariant.Light => "btn-light",
                    ButtonVariant.Dark => "btn-dark",
                    ButtonVariant.OutlinePrimary => "btn-outline-primary",
                    ButtonVariant.OutlineSecondary => "btn-outline-secondary",
                    ButtonVariant.OutlineWarning => "btn-outline-warning",
                    ButtonVariant.OutlineInfo => "btn-outline-info",
                    ButtonVariant.OutlineDanger => "btn-outline-danger",
                    _ => "btn-primary"
                };
            }
        }
    }
}
