using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;

namespace travelPlaner;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddCityButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var city = CityTextBox.Text;
        Label label = new Label
        {
            Margin = new Thickness(3),
            Padding= new Thickness(3),
            Content = city
        };

        CitiesListBox.Items.Add(label);
        CityTextBox.Text = "";

    }

    private void EndDateOfTravel_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        DateTime? startDateTime = StartDateOfTravel.SelectedDate;
        string startDate = startDateTime?.ToShortDateString();

    }
}