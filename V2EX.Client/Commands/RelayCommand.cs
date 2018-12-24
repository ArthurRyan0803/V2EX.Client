﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace V2EX.Foundation.Commands
{
    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = _ => execute.Invoke();
            _canExecute = _ => canExecute?.Invoke() ?? true;
        }

        public RelayCommand(Action<T> execute, Func<T , bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke((T)parameter);
        }
    }
}
