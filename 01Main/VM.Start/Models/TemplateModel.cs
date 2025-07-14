using System;
using System.Collections.ObjectModel;
using VM.Start.Common.Helper;

namespace VM.Start.Models
{
    [Serializable]
    public class TemplateModel : NotifyPropertyBase
    {
        public int ID { get; set; }
        public string FileName { get; set; }

        public string FullPath { get; set; }
        private int inputStart = 1;
        public int InputStart
        {
            get { return inputStart; }
            set { inputStart = value; this.RaisePropertyChanged(); }
        }
        private int outputFinish = 1;
        public int OutputFinish
        {
            get { return outputFinish; }
            set { outputFinish = value; this.RaisePropertyChanged(); }
        }
        private ObservableCollection<ObjectModel> _ObjectList = new ObservableCollection<ObjectModel>();
        public ObservableCollection<ObjectModel> ObjectList
        {
            get { return _ObjectList; }
            set { _ObjectList = value; this.RaisePropertyChanged(); }
        }
    }
}
