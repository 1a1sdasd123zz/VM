using System.Windows;
using VM.Start.Core;

namespace Plugin.Blob.Views
{
    /// <summary>
    /// SaveImageView.xaml 的交互逻辑
    /// </summary>
    public partial class BlobView : ModuleViewBase
    {
        public BlobView()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
