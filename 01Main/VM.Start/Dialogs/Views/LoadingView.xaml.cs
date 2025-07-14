using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using VM.Start.Dialogs.ViewModels;
using VM.Start.Localization;


namespace VM.Start.Dialogs.Views
{
    /// <summary>
    /// LoadingView.xaml 的交互逻辑
    /// </summary>
    public partial class LoadingView : MetroWindow
    {
        public LoadingView()
        {
            InitializeComponent();
            DataContext = new LoadingViewModel();
        }
        private static LoadingView _instance;
        public static LoadingView Ins
        {
            get
            {
                Application.Current.Dispatcher.Invoke(() => { _instance = new LoadingView(); });
                return _instance;
            }
        }
        public void LoadingShow(string msg)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    var vm = DataContext as LoadingViewModel;
                    vm.Message = msg;
                    this.Topmost = true;
                    vm.ToolBarMsg = Resource.Info;
                    vm.Icon = new BitmapImage(new Uri(@"/Assets/Images/Info.png", UriKind.Relative));
                    Show();
                }
                catch (Exception ex)
                {
                }
            });

        }

    }
}
