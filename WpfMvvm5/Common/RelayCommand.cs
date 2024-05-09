using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvm5.Common
{
    //처리되어야 하는 기능을 구현하되, 외부의 기능 처리 요청을 Command 개체를 통해 주고 받음으로
    //외부와 내부의 결합을 떨어뜨리고 클래스의 재사용성을 높게 한다.
    internal class RelayCommand<T> : ICommand
    {
        private Action<T?> _execute;
        private Predicate<T?> _canExecute;

        public RelayCommand(Action<T?> execute) : this(execute, null) { }
        public RelayCommand(Action<T?> execute, Predicate<T?> canExecute)
        {           
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute?.Invoke((T?)parameter) ?? true;
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke((T?)parameter);
        }
    }
}
