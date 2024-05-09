using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvm5.ViewModels
{
    internal abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        //[CallerMemberName] 특성은 propertyName 매개변수에 자동으로 해당 메서드를 호출한 멤버 메서드 또는 속성의 이름을 지정해주는 특성이다. 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T member, T value, [CallerMemberName] string? propertyName = null)
        {
        //현재 속성의 값이 새로 지정된 속성의 값과 같지 않다면 값을 지정한 다음 NotifyPropertyChanged()를 호출한다.
            if (EqualityComparer<T>.Default.Equals(member, value)) return false;

            member = value;

            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}
