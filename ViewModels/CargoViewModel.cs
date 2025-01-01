using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using 仓库管理系统.DAL;
using 仓库管理系统.Entities;
using MessageBox = System.Windows.MessageBox;


namespace 仓库管理系统.ViewModels
{
    internal class CargoViewModel : ObservableObject
    {
        private CargoRepository CargoRepository { get; } = new CargoRepository();
        
        private Cargo cargo = new Cargo();

        public Cargo Cargo
        {
            get => cargo;
            set => SetProperty(ref cargo, value); 
            
        }

       
       private List<Cargo> cargos;

        public List<Cargo> Cargos
        {
            get => cargos;
            set => SetProperty(ref cargos, value); 

        }


        public ICommand LoadedCommand { get;  }
        public ICommand CreateCommand { get; }
        public ICommand AddOrUpdateCommand { get; }
        public ICommand DeleteCommand { get; }




        public CargoViewModel()
        {
            
            LoadedCommand = new RelayCommand(OnLoadedCommand);
            CreateCommand = new RelayCommand(OnCreateCommand);
            AddOrUpdateCommand = new RelayCommand(OnAddOrUpdateCommand);
            DeleteCommand = new RelayCommand<Cargo>(OnDeleteCommand);
        }

        private void OnDeleteCommand(Cargo cargo)
        {
            if (cargo == null || cargo.Id == 0) return;

            if(MessageBox.Show("确定要删除吗？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
          
            int Count = CargoRepository.Delete(cargo);
            if (Count > 0)
            {
                MessageBox.Show("删除成功");
                Load();
            }
            else
            {
                MessageBox.Show("删除失败", "提示");
            }
        }

        

        private void OnAddOrUpdateCommand()
        {
           if(cargo== null)
            {
                MessageBox.Show("物资对象不能为空");
                return;
            }
            if (string.IsNullOrEmpty(cargo.Name))
            {
                MessageBox.Show("物资名称不能为空");
                return;
            }
            if(cargo.Id== 0)
            {
                int cont = CargoRepository.Insert(cargo);
                if (cont > 0)
                {
                    MessageBox.Show("添加成功");
                    Load();
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            else
            {
                int cont = CargoRepository.Update(cargo);
                if (cont > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
        }


        private void OnLoadedCommand()
        {
            Load();
        }
        private void OnCreateCommand()
        {
            
            cargo = new Cargo();
        }

        private void Load()
        {
            Cargos = CargoRepository.GetAll();
        }
    }
}