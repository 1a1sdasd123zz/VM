using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using VM.Start.Dialogs.ViewModels;


namespace VM.Start.Dialogs.Views
{
    /// <summary>
    /// MessageView.xaml 的交互逻辑
    /// </summary>
    public partial class EditRemarksView : MetroWindow
    {
        public EditRemarksView()
        {
            InitializeComponent();
            DataContext = new EditRemarksViewModel();
        }
        private static EditRemarksView _instance;
        public static EditRemarksView Ins
        {
            get
            {
                Application.Current.Dispatcher.Invoke(() => { _instance = new EditRemarksView(); });
                return _instance;
            }
        }

        public string MessageBoxShow(string message)
        {
            tbMessage.Text = message;
            var vm = DataContext as EditRemarksViewModel;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                try
                {
                    this.Topmost = true;
                    vm.ToolBarMsg = "编辑备注";
                    vm.Icon = new BitmapImage(new Uri(@"/Assets/Images/Info.png", UriKind.Relative));
                    ShowDialog();
                }
                catch (Exception ex)
                {
                }
            }));
            return tbMessage.Text;

        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbMessage.Focus();
            tbMessage.SelectAll();
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnConfirm_Click(null, null);
            }
        }
    }
}
