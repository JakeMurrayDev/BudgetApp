using Blazored.LocalStorage;
using BudgetApp.Client;
using BudgetApp.Client.ViewModels;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//ViewModels
builder.Services.AddScoped<IBudgetsPageViewModel, BudgetsPageViewModel>();
//Validation
builder.Services.AddTransient<IValidator<BudgetViewModel>, BudgetValidator>();
builder.Services.AddTransient<IValidator<ExpenseViewModel>, ExpenseValidator>();
await builder.Build().RunAsync();
