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
using 仓库管理系统.ViewModels;


namespace 仓库管理系统.Views
{
    /// <summary>
    /// CargoView.xaml 的交互逻辑
    /// </summary>
    public partial class CargoView : UserControl
    {

        private CargoViewModel vm =new CargoViewModel();
        
            
        public CargoView()
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
