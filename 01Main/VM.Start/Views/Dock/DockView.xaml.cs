using System.Windows.Controls;
using VM.Start.ViewModels.Dock;

namespace VM.Start.Views.Dock
{
    /// <summary>
    /// DockView.xaml 的交互逻辑
    /// </summary>
    public partial class DockView : UserControl
    {
        #region Singleton
        private static DockView _instance ;
        private DockView()
        {
            InitializeComponent();
            DataContext = DockViewModel.Ins;
        }

        public static DockView Ins
        {
            get 
            { 
                if (_instance == null)
                    _instance = new DockView();
                return _instance; 
            }
        }

        #endregion

    }
}
