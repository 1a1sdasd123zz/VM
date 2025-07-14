using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Windows;
using VM.Start.Events;
using VM.Start.ViewModels;

namespace VM.Start.Views
{
    /// <summary>
    /// SystemParamView.xaml 的交互逻辑
    /// </summary>
    public partial class CommunicationSetView : MetroWindow
    {
        #region Singleton
        private static CommunicationSetView _instance = new CommunicationSetView();

        private CommunicationSetView()
        {
            InitializeComponent();
            this.DataContext = CommunicationSetViewModel.Ins;
        }
        public static CommunicationSetView Ins
        {
            get { return _instance; }
        }
        #endregion
        #region Prop

        #endregion

        #region Method

        public bool IsClosed { get; set; } = true;

        protected override void OnClosing(CancelEventArgs e)
        {
            EventMgrLib.EventMgr.Ins.GetEvent<HardwareChangedEvent>().Publish();
            e.Cancel = true;  // cancels the window close
            IsClosed = true;
            this.Hide();      // Programmatically hides the window
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {           
            this.Close();
        }
        #endregion

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
