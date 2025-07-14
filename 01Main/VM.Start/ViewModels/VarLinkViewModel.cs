using System.Collections.ObjectModel;
using EventMgrLib;
using VM.Start.Common.Helper;
using VM.Start.Events;
using VM.Start.Models;
using VM.Start.Views;

namespace VM.Start.ViewModels
{
    public class VarLinkViewModel : NotifyPropertyBase
    {
        #region Singleton

        private static readonly VarLinkViewModel _instance = new VarLinkViewModel();

        private VarLinkViewModel()
        {
            EventMgr.Ins.GetEvent<OpenVarLinkViewEvent>().Subscribe(OnOpenVarLinkViewEvent);
        }
        public static VarLinkViewModel Ins
        {
            get { return _instance; }
        }

        #endregion

        #region Prop
        public ObservableCollection<ModuleList> Modules { get; set; } = new ObservableCollection<ModuleList>();
        public int ModuleIndex { get; set; }
        public VarModel Var { get; set; } = new VarModel();
        public VarChangedEventParamModel VarChangedEventParam { get; set; } = new VarChangedEventParamModel();
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
                        if (VarLinkView.Ins.IsClosed)
                        {
                            VarLinkView.Ins.IsClosed = false;
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
                        if (ModuleIndex == -1 || Var == null) return;
                        string linkName = $"&{Modules[ModuleIndex].DisplayName}.{Var.Name}";
                        VarChangedEventParam.LinkName = linkName;
                        VarChangedEventParam.Name = Var.Name;
                        VarChangedEventParam.DataType = Var.DataType;
                        EventMgr.Ins.GetEvent<VarChangedEvent>().Publish(VarChangedEventParam);
                        VarLinkView.Ins.Close();
                    });
                }
                return _ConfirmCommand;
            }
        }
        #endregion

        #region Method
        private void OnOpenVarLinkViewEvent(string sendName)
        {
            VarChangedEventParam.SendName = sendName;
            string[] strings = sendName.Split(',');
            if (strings.Length>=3)
            {
                if (strings[2] == "IsAdd")
                {
                    VarChangedEventParam.IsAdd = true;
                }
                else
                {
                    VarChangedEventParam.IsAdd = false;
                }
            }
            else
            {
                VarChangedEventParam.IsAdd = false;
            }
            VarLinkView.Ins.ModuleListSelectFirst();
            VarLinkView.Ins.ShowDialog();

        }
        #endregion
    }
}
