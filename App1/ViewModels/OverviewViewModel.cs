using App1.Contracts;
using App1.Models;
using App1.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace App1.ViewModels;
public class OverviewViewModel : ObservableObject, INavigationAware
{
    private readonly IDataService dataService;
    private readonly INavigationService navigationService;
    public IRelayCommand LoadCommand { get; private set; }
    public IRelayCommand<Employee> SelectCommand { get; private set; }

    public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();

    //private ObservableCollection<Employee> _employees;
    //public ObservableCollection<Employee> Employees
    //{
    //    get => _employees;
    //    set { SetProperty(ref _employees, value); }
    //}

    public OverviewViewModel(IDataService dataService, INavigationService navigationService)
    {
        this.dataService = dataService;
        this.navigationService = navigationService;
        InitializeCommands();
        LoadEmployees();
    }

    private void InitializeCommands()
    {
        LoadCommand = new RelayCommand(LoadEmployees);
        SelectCommand = new RelayCommand<Employee>(SelectEmployee);
    }

    private void SelectEmployee(Employee item)
    {
        var selectedEmployee = new ObservableEmployee(item);
        this.navigationService.NavigateTo(typeof(DetailsPage), selectedEmployee);
    }

    private void LoadEmployees()
    {
        Employees.Clear();
        foreach (var employee in this.dataService.GetAll())
        {
            Employees.Add(employee);
        }
    }

    public void OnNavigatedTo(object parameter)
    {
        LoadEmployees();
    }

    public void OnNavigatedFrom()
    {
    }
}
