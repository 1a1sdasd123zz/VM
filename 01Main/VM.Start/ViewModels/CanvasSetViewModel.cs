using VM.Start.Common.Helper;
using VM.Start.Services;
using VM.Start.Views;
using VM.Start.Views.Dock;

namespace VM.Start.ViewModels
{
    public class CanvasSetViewModel : NotifyPropertyBase
    {
        #region Singleton

        private static readonly CanvasSetViewModel _instance = new CanvasSetViewModel();

        private CanvasSetViewModel()
        {

        }
        public static CanvasSetViewModel Ins
        {
            get { return _instance; }
        }

        #endregion

        #region Prop

        #endregion

        #region Command

        private CommandBase _ActivatedCommand;
        public CommandBase ActivatedCommand
        {
            get
            {
                if (_ActivatedCommand == null)
                {
                    _ActivatedCommand = new CommandBase((obj) =>
                    {
                        if (CanvasSetView.Ins.IsClosed)
                        {
                            CanvasSetView.Ins.IsClosed = false;

                        }

                    });
                }
                return _ActivatedCommand;
            }
        }
        private CommandBase _ConfirmCommand;
        public CommandBase ConfirmCommand
        {
            get
            {
                if (_ConfirmCommand == null)
                {
                    _ConfirmCommand = new CommandBase((obj) =>
                    {

                        VisionView.Ins.ViewMode = Solution.Ins.ViewMode;
                        CanvasSetView.Ins.Close();
                    });
                }
                return _ConfirmCommand;
            }
        }

        #endregion
    }
}
