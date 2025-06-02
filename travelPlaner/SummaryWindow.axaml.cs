using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace travelPlaner;

public partial class SummaryWindow : Window
{
    public SummaryWindow(string summaryText, string imagePath)
    {
        InitializeComponent();
        
        
        SummaryStackPanel.Children.Add(new TextBlock
        {
            Text = summaryText,
            TextWrapping = Avalonia.Media.TextWrapping.Wrap
        });
        
        
        var uri = new Uri(imagePath);
        using var stream = Avalonia.Platform.AssetLoader.Open(uri);
        var bitmap = new Avalonia.Media.Imaging.Bitmap(stream);

        SummaryStackPanel.Children.Add(new Avalonia.Controls.Image
        {
            Source = bitmap,
            Width = 200,
            Height = 200,
            Margin = new Avalonia.Thickness(0, 10, 0, 10),
            Stretch = Avalonia.Media.Stretch.Uniform
        });
    }
}