using System.Windows.Controls;
using VM.Start.ViewModels.Dock;

namespace VM.Start.Views.Dock
{
    /// <summary>
    /// ModuleOutView.xaml 的交互逻辑
    /// </summary>
    public partial class ModuleOutView : UserControl
    {
        #region Singleton
        private static readonly ModuleOutView _instance = new ModuleOutView();
        private ModuleOutView()
        {
            InitializeComponent();
            DataContext = ModuleOutViewModel.Ins;
        }
        public static ModuleOutView Ins
        {
            get { return _instance; }
        }
        #endregion
    }
}
