﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvm5.Common
{
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
