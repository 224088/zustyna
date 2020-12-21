using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Presentation.ViewModel.AdditionalInterfaces
{
    public class ModelCommand : ICommand
    {

        private readonly Action execute = null;
        private readonly Predicate<object> canExecute = null;

        public ModelCommand(Action execute)
            : this(execute, null) { }

        public ModelCommand(Action execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }




        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return canExecute != null ? canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
           
            this.execute();

        }

        public void OnCanExecuteChanged()
        {
        
            CanExecuteChanged(this, EventArgs.Empty);
        }

 
      
    }
}
