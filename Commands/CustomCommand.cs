using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Commands
{
    //Allgemeine generische Commandklasse, welche individuell befüllt werden kann.

    //ICommand ermöglicht dieser Klasse, als Command verwendet zu werden
    public class CustomCommand : ICommand
    {
        //Anmeldung des Commands im CommandManager
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Delegates zum Speichern der Logik
        public Action<object> ExecuteMethode { get; set; }
        public Func<object, bool> CanExecuteMethode { get; set; }


        //Bedingung für die Ausführung
        public bool CanExecute(object? parameter) => CanExecuteMethode(parameter);

        //Aktion bei Ausführung
        public void Execute(object? parameter) => ExecuteMethode(parameter);


        //Konstruktor
        public CustomCommand(Action<object>exe, Func<object, bool>can)
        {
            ExecuteMethode= exe;
            CanExecuteMethode= can;
        }
    }
}
