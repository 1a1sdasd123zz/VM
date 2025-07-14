using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows;
using VM.Start.ViewModels;

namespace VM.Start.Views
{
    /// <summary>
    /// SystemParamView.xaml 的交互逻辑
    /// </summary>
    public partial class SolutionListView : MetroWindow
    {
        #region Singleton
        private static readonly SolutionListView _instance = new SolutionListView();

        private SolutionListView()
        {
            InitializeComponent();
            this.DataContext = SolutionListViewModel.Ins;
        }
        public static SolutionListView Ins
        {
            get { return _instance; }
        }

        #endregion

        public bool IsClosed { get; set; } = true;
        public bool IsOpen { get; set; } = false;
        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;  // cancels the window close
            IsClosed = true;
            IsOpen = false;
            this.Hide();      // Programmatically hides the window
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
