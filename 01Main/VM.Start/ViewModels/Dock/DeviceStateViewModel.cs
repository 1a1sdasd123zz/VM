namespace VM.Start.ViewModels.Dock
{
    public class DeviceStateViewModel
    {
        #region Singleton
        private static readonly DeviceStateViewModel _instance = new DeviceStateViewModel();
        public DeviceStateViewModel()
        {
        }
        public static DeviceStateViewModel Ins
        {
            get { return _instance; }
        }
        #endregion

    }
}
