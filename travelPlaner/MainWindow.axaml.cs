using System;
using System.Collections.Generic;
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



    private void FinishPlanButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
        var name = nameTextBox.Text;
        DateTime? startDateTime = StartDateOfTravel.SelectedDate;
        string startDate = startDateTime?.ToShortDateString();
        string selectedTransport = "";
        
        List<string> selectedOptions = new List<string>();
        List<string> cityNames = new List<string>();

        if (FirstCheckBox.IsChecked == true)
            selectedOptions.Add("Restauracje");

        if (SecondCheckBox.IsChecked == true)
            selectedOptions.Add("Muzea");

        if (ThirdCheckBox.IsChecked == true)
            selectedOptions.Add("Zabytki");

        if (FourthCheckBox.IsChecked == true)
            selectedOptions.Add("Parki Narodowe");

        if (FifthCheckBox.IsChecked == true)
            selectedOptions.Add("Imprezowanie");
        
        
        foreach (var item in CitiesListBox.Items)
        {
            if (item is Label label && label.Content is string cityName)
            {
                cityNames.Add(cityName);
            }
        }
        

        if (PlaneRadio.IsChecked == true)
            selectedTransport = PlaneRadio.Content.ToString();
        else if (TrainRadio.IsChecked == true)
            selectedTransport = TrainRadio.Content.ToString();
        else if (BusRadio.IsChecked == true)
            selectedTransport = BusRadio.Content.ToString();
        else if (FerryRadio.IsChecked == true)
            selectedTransport = FerryRadio.Content.ToString();
        
        

        
    }
    
    

        
}