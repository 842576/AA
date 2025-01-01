using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MahApps.Metro.Controls;
using 仓库管理系统.DAL;
using 仓库管理系统.Views;

namespace 仓库管理系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            AppData.MainWindow = this;
            AppData.Container =this.container;

        }

     private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
 
            UserControl view= new LoginView();
//设置成免登录
#if DEBUG
            view = new MainView();
            AppData.MainWindow.Width = 1800;
            AppData.MainWindow.Height = 900;
            AppData.MainWindow.Left = (SystemParameters.WorkArea.Width - AppData.MainWindow.Width) / 2;
            AppData.MainWindow.Top = (SystemParameters.WorkArea.Height - AppData.MainWindow.Height) / 2;
            MemberRepository memberRepository = new MemberRepository();

            var member = memberRepository.GetAll()
                .Find(p => p.Name == "AD");
            AppData.CurrentUser = member;
#endif
            container.Content = view;

        }
        
    }
}
