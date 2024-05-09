using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfMvvm5.Models;

namespace WpfMvvm5.Views
{
    /// <summary>
    /// MemberInfoView.xaml에 대한 상호 작용 논리
    /// </summary>
    /// Binding이 이뤄지기 위해서는 반드시 필요한 조건이 있는데, Binding 하려는 속성이 DependencyProperty(의존 속성) 여야 한다
    public partial class MemberInfoView : UserControl
    {
        public static readonly DependencyProperty MemberDataProperty    
            = DependencyProperty.Register("MemberData", 
                                          typeof(MemberInfoModel),
                                          typeof(MemberInfoView),
                                          new PropertyMetadata(null));
        // DependencyProperty의 이름은 실제 사용할 속성 명 뒤에 Property를 붙여서 지정한다.
        // <속성 이름>, <속성의 타입>, <속성을 사용할 컨트롤의 타입>, <속성 메타 데이터 개체>); 와 같이 인수를 지정한다.

        private MemberInfoModel _memberData;
        public MemberInfoModel MemberData
        {
            set => SetValue(MemberDataProperty, value);
            get => (MemberInfoModel)GetValue(MemberDataProperty);
        }
        
        public MemberInfoView()
        {
            InitializeComponent();
        }
    }
}
