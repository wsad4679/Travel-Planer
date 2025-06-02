using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace travelPlaner;

public partial class SummaryWindow : Window
{
    public SummaryWindow(string summaryText)
    {
        InitializeComponent();
        
        
        SummaryStackPanel.Children.Add(new TextBlock
        {
            Text = summaryText,
            TextWrapping = Avalonia.Media.TextWrapping.Wrap
        });
    }
}