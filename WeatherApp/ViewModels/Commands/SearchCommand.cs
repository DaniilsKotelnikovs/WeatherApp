using System;
using System.Windows.Input;

namespace WeatherApp.ViewModels.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherWM VM { get; set; }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public SearchCommand(WeatherWM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            string? query = parameter as string;

            if(string.IsNullOrWhiteSpace(query))
                return false;

            return true;
        }

        public void Execute(object? parameter)
        {
            VM.MakeQuery();
        }
    }
}
