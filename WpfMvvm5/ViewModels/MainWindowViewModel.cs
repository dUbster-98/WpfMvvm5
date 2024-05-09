using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using WpfMvvm5.Common;
using WpfMvvm5.Models;

namespace WpfMvvm5.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel
    {
        private string _searchID;
        public string SearchID
        {
            get => _searchID;
            set => SetProperty(ref _searchID, value);
        }

        private MemberInfoModel _memberInfo;
        public MemberInfoModel MemberInfo
        {
            get => _memberInfo;
            set => SetProperty(ref _memberInfo, value);
        }
        
        public ICommand MainWindowCommand { get; }

        public MainWindowViewModel()
        {
            MainWindowCommand = new RelayCommand<string>(execute, canExecute);
        }
        // 커멘드 실행 주체 → RelayCommand<T>.Execute() → _execute.Invoke() → MainWindowViewModel.execute()
        // xaml의 커맨드파라미터를 excute의 인수로 지정함
        private void execute(string paramerter)
        {
            switch (paramerter)
            {
                case "Search":
                    if (string.IsNullOrWhiteSpace(SearchID))
                    {
                        MessageBox.Show("ID를 입력하세요.");
                    }
                    else
                    {
                        searchById(SearchID);
                    }
                    break;
            }
        }
        private bool canExecute(string parameter)
        {
            if (parameter != null)
            {
                switch (parameter)
                {
                    case "Search":
                        return true;
                }
            }

            return false;
        }

        private void searchById(string id)
        {
            var result = DataManager.FindMemberInfo(id);

            MemberInfo = result;
        }
    }
}

//Default	기본값이다. Binding될 속성에 따라 다른 데이터 흐름으로 동작한다.
//일반적으로 사용자가 상호작용을 통해 편집 가능한 속성들은 TwoWay 방식으로 동작하고, 이를 제외한 대부분의 속성들은 OneWay 방식으로 동작한다.

//OneTime 프로그램이 시작되는 시점 또는 View의 DataContext로 지정된 개체가 변경되는 시점에서 1회에 한하여
//바인딩 대상의 값을 바인딩 소스의 값으로 업데이트한다. (ViewModel → View)

//OneWay 바인딩 소스의 값이 변경되면 바인딩 대상의 값이 업데이트된다. (ViewModel → View)

//OneWayToSource 바인딩 대상의 값이 변경되면 바인딩 소스의 값을 업데이트한다. (View → ViewModel)

//TwoWay 바인딩 소스 또는 바인딩 대상의 값이 변경되면 다른 쪽의 값도 업데이트한다. (View ↔ ViewModel
