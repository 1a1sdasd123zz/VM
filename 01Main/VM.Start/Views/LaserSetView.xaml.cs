using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using VM.Start.ViewModels;

namespace VM.Start.Views
{
    /// <summary>
    /// LaserSetView.xaml 的交互逻辑
    /// </summary>
    public partial class LaserSetView : MetroWindow
    {
        #region Singleton
        private static readonly LaserSetView _instance = new LaserSetView();

        private LaserSetView()
        {
            InitializeComponent();
            DataContext = LaserSetViewModel.Ins;
        }

        public static LaserSetView Ins
        {
            get { return _instance; }
        }

        #endregion

        #region Prop
        public bool IsClosed { get; set; } = true;
        #endregion

        #region Method
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true; // cancels the window close
            IsClosed = true;
            this.Hide(); // Programmatically hides the window
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void dg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e) { }

        private void cmbLaserType_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
    }
}
