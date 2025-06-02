using System;
using System.Collections.Generic;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

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
        int travelPrice = country switch
        {
            "Francja" => 1200,
            "Japonia" => 4000,
            "Grecja" => 1500,
            "Australia" => 5000,
            _ => 1000 // domyślna cena
        };
    
        string imagePath =  country switch
        {
            "Francja" => "avares://travelPlaner/Assets/francja.png",
            "Japonia" => "avares://travelPlaner/Assets/japonia.png",
            "Grecja" => "avares://travelPlaner/Assets/grecja.png",
            "Australia" => "avares://travelPlaner/Assets/australia.png",
            _ => "avares://travelPlaner/Assets/default.png"
        };
        
        
        
        
        var name = nameTextBox.Text;
        DateTime? startDateTime = StartDateOfTravel.SelectedDate;
        string startDate = startDateTime?.ToShortDateString();
        string selectedTransport = "";
        var summaryTravel = "Dane podróży: \n";
        
        List<string> selectedOptions = new List<string>();

        if (FirstCheckBox.IsChecked == true)
        {
            selectedOptions.Add("Restauracje");
            travelPrice += 320;
        }
        
        if (SecondCheckBox.IsChecked == true) 
        {
                selectedOptions.Add("Muzea");
                travelPrice +=100 ; }


        if (ThirdCheckBox.IsChecked == true)
        {
                selectedOptions.Add("Zabytki");
                travelPrice += 60;
        }


        if (FourthCheckBox.IsChecked == true)
        {
                selectedOptions.Add("Parki Narodowe");
                travelPrice += 40;
        }


        if (FifthCheckBox.IsChecked == true)
        {
                selectedOptions.Add("Imprezowanie");
                travelPrice += 1000;
        }
            
        else
        {
            selectedOptions.Add("Bez pomysłu");
        }
        
        
        
        

        if (PlaneRadio.IsChecked == true)
        {
            selectedTransport = PlaneRadio.Content.ToString();
            travelPrice += 800;
        }
        else if (TrainRadio.IsChecked == true)
        {
            selectedTransport = TrainRadio.Content.ToString();
            travelPrice += 400;
        }
        else if (BusRadio.IsChecked == true)
        {
            selectedTransport = BusRadio.Content.ToString();
            travelPrice += 200;
        }
        else if (FerryRadio.IsChecked == true)
        {
            selectedTransport = FerryRadio.Content.ToString();
            travelPrice += 300;
        }

       
        summaryTravel += $"Imie: {name}\n";
        summaryTravel += $"Wybrane państwo {country}\n";
        summaryTravel += $"Środek transportu: {selectedTransport}\n";
        summaryTravel += $"Rozpoczęcie podróży: {selectedTransport}\n";
        summaryTravel += "Miasta do odwiedzenia: ";
        foreach (var item in CitiesListBox.Items)
        {
            
            if (item is Label label && label.Content is string cityName)
            {
                summaryTravel += $"{cityName}, ";
            }
        }
        summaryTravel += "\nRzeczy do zwiedzenia: ";
    
        foreach (var item in selectedOptions)
        {
            summaryTravel += $"{item}, ";
            
        }

        summaryTravel += $"\nRozpoczęcie podróży {startDate}\n";
        summaryTravel += $"Koszt podróży: {travelPrice}\n";
        var popupWindow = new SummaryWindow(summaryTravel, imagePath);
        popupWindow.Show();
        
        var desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

// Pełna ścieżka do pliku
        var filePath = Path.Combine(desktopPath, "travelPlan.txt");

// Jeśli plik nie istnieje – utwórz go
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose(); 
        }
        
        using var writer = new StreamWriter(filePath); 
        writer.WriteLine(summaryTravel);
       
        

    }


    private void CountryComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var country = (CountryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
        string imagePath =  country switch
        {
            "Francja" => "avares://travelPlaner/Assets/francja.png",
            "Japonia" => "avares://travelPlaner/Assets/japonia.png",
            "Grecja" => "avares://travelPlaner/Assets/grecja.png",
            "Australia" => "avares://travelPlaner/Assets/australia.png",
            _ => "avares://travelPlaner/Assets/default.png"
        };
        var uri = new Uri(imagePath);
        using var stream = AssetLoader.Open(uri);
        CountryImage.Source = new Bitmap(stream);
    }
}