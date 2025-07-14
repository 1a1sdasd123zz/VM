using System.Windows.Controls;
using VM.Start.ViewModels.Dock;

namespace VM.Start.Views.Dock
{
    /// <summary>
    /// DataView.xaml 的交互逻辑
    /// </summary>
    public partial class DataView : UserControl
    {
        #region Singleton
        private static readonly DataView _instance = new DataView();
        private DataView()
        {
            InitializeComponent();
            DataContext = DataViewModel.Ins;
        }
        public static DataView Ins
        {
            get { return _instance; }
        }
        #endregion
    }
}
