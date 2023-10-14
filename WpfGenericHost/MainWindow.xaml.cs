using System.Windows;

namespace WpfGenericHost;

public partial class MainWindow : Window
{
    public MainWindow(SomeViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}

