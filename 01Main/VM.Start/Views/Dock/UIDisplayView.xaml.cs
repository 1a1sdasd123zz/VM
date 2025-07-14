using System.Windows.Controls;

namespace VM.Start.Views.Dock
{
    /// <summary>
    /// UIDisplayView.xaml 的交互逻辑
    /// </summary>
    public partial class UIDisplayView : UserControl
    {
        public UIDisplayView()
        {
            InitializeComponent();
        }

        public static UIDisplayView Ins
        {
            get { return _instance; }
        }

        // Token: 0x040001B1 RID: 433
        private static readonly UIDisplayView _instance = new UIDisplayView();
    }
}
