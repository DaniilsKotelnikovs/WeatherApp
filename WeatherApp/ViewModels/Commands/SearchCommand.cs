using System;
using System.Windows.Input;

namespace WeatherApp.ViewModels.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherWM VM { get; set; }

        public event EventHandler? CanExecuteChanged;

        public SearchCommand(WeatherWM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.MakeQuery();
        }
    }
}
