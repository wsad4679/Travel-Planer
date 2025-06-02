using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace travelPlaner;

public partial class SummaryWindow : Window
{
    public SummaryWindow(string summaryText, string imagePath)
    {
        InitializeComponent();

        var textBlock = this.FindControl<TextBlock>("SummaryTextBlock");
        var image = this.FindControl<Image>("SummaryImage");

        textBlock.Text = summaryText;

        try
        {
            var uri = new Uri(imagePath);
            using var stream = AssetLoader.Open(uri);
            var bitmap = new Bitmap(stream);
            image.Source = bitmap;
        }
        catch (Exception e)
        {
            textBlock.Text += $"\n\n[Nie udało się załadować obrazu: {e.Message}]";
        }
    }
}