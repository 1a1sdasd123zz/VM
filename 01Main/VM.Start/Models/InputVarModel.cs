﻿using System;
using VM.Start.Common.Enums;
using VM.Start.Common.Helper;

namespace VM.Start.Models
{
    [Serializable]
    public class InputVarModel : NotifyPropertyBase
    {
		private string _Name;

		public string Name
		{
			get { return _Name; }
			set { _Name = value; RaisePropertyChanged(); }
        }
        private eTypes _Type;

        public eTypes Type
        {
            get { return _Type; }
            set { _Type = value; RaisePropertyChanged(); }
        }
        public Array Types { get; set; } = Enum.GetValues(typeof(eTypes));
        private LinkVarModel _Var=new LinkVarModel();

        public LinkVarModel Var
        {
            get { return _Var; }
            set { _Var = value; RaisePropertyChanged(); }
        }
        public CommandBase LinkCommand { get; set; }

    }
}
