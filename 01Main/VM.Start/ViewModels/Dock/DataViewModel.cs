namespace VM.Start.ViewModels.Dock
{
    public class DataViewModel
    {
        #region Singleton
        private static readonly DataViewModel _instance = new DataViewModel();
        private DataViewModel()
        {
        }
        public static DataViewModel Ins
        {
            get { return _instance; }
        }
        #endregion

    }
}
