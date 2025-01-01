using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using 仓库管理系统.DAL;
using 仓库管理系统.Entities;
using 仓库管理系统.Views;

namespace 仓库管理系统.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // 定义一个 Member 对象，用于存储用户输入的用户名和密码
        // 这个对象会在视图模型中与视图进行绑定，用户输入的内容会更新到这个对象中
        public Member Member { get; set; } = new Member();

        // 定义登录命令 (ICommand)，当用户点击“登录”按钮时触发
        public ICommand LoginCommand { get; }

        // 定义退出命令 (ICommand)，当用户点击“关闭”按钮时触发
        public ICommand ExitCommand { get; }

        // 构造函数，初始化命令
        public LoginViewModel()
        {
#if DEBUG
            Member.Name = "AD";
            Member.Password = "123";
#endif
            // 初始化登录命令，关联到 OnLoginCommand 方法
            LoginCommand = new RelayCommand(OnLoginCommand);

            // 初始化退出命令，关联到 OnExitCommand 方法
            ExitCommand = new RelayCommand(OnExitCommand);
        }

        /// <summary>
        /// 处理退出命令，关闭应用程序。
        /// </summary>
        private void OnExitCommand()
        {
            AppData.MainWindow?.Close();
        }

        /// <summary>
        /// 处理登录命令，验证用户输入的用户名和密码，并尝试登录。
        /// </summary>
        private void OnLoginCommand()
        {

            // 检查用户名是否为空
            if (string.IsNullOrEmpty(Member.Name))
            {
                // 如果用户名为空，弹出提示框告知用户
                MessageBox.Show("用户名不能为空");
                return; // 中止登录过程
            }

            // 检查密码是否为空
            if (string.IsNullOrEmpty(Member.Password))
            {
                // 如果密码为空，弹出提示框告知用户
                MessageBox.Show("密码不能为空");
                return; // 中止登录过程
            }

            // 创建 MemberRepository 实例，用于访问数据库或数据源
            MemberRepository memberRepository = new MemberRepository();

            // 从数据库中获取所有成员，并查找是否存在匹配的用户名和密码
            var member = memberRepository.GetAll()
                .Find(p => p.Name == Member.Name && p.Password == Member.Password);

            // 如果没有找到匹配的用户
            if (member == null)
            {
                // 弹出提示框告知用户用户名或密码错误
                MessageBox.Show("用户名或密码错误");
                return; // 中止登录过程
            }
            else
            {
                // 登录成功，弹出提示框告知用户
                MessageBox.Show("登录成功");

                // 在这里可以添加登录成功后的处理逻辑，例如导航到主页面、保存用户信息等
                AppData.CurrentUser = member;
                AppData.Container.Content = new MainView();
                AppData.MainWindow.Width = 1800;
                AppData.MainWindow.Height = 900;
                AppData.MainWindow.Left = (SystemParameters.WorkArea.Width-AppData.MainWindow.Width)/2;
                AppData.MainWindow.Top = (SystemParameters.WorkArea.Height-AppData.MainWindow.Height)/2;
            }
        }
    }
} 