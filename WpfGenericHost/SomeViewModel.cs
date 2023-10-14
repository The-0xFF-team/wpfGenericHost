using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WpfGenericHost;

public class SomeViewModel : INotifyPropertyChanged
{
    private readonly ILogger<SomeViewModel> _logger;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public SomeViewModel(ITextService textService, ILogger<SomeViewModel> logger,
        IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
        Text = textService.Text;
        _logger.LogInformation("Application started");
        OpenAnotherWindowCommand = new RelayCommand(Alma);
    }

    public string Text { get; set; }
    public ICommand OpenAnotherWindowCommand { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void Alma()
    {
        var anotherWindow = _serviceScopeFactory.CreateScope().ServiceProvider.GetService<AnotherWindow>();
        anotherWindow.Show();
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}