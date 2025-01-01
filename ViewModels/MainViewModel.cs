using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace 仓库管理系统.ViewModels
{
    internal class MainViewModel
    {               
        public ICommand NavigationCommand { get; }

        public MainViewModel()
        {
            NavigationCommand = new RelayCommand<string>(OnNavigationCommand);
        }

        private void OnNavigationCommand(string viewName)
        {
          
                var type = Type.GetType("仓库管理系统.Views." + viewName);

                object view = Activator.CreateInstance(type);
                AppData.MainRegion.Content = view;
            

            //catch ( Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
          
        }
            
        
    }
}
