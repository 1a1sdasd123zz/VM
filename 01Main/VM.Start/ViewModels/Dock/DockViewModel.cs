using VM.Start.Common.Helper;

namespace VM.Start.ViewModels.Dock
{
    public class DockViewModel : NotifyPropertyBase
    {
        #region Singleton
        private static readonly DockViewModel _instance = new DockViewModel();

        private DockViewModel()
        {
        }
        public static DockViewModel Ins
        {
            get { return _instance; }
        }
        #endregion

    }
}
