using LabWPF.Core;
using LabWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabWPF.VIewModels
{
    class TranformatorInfoVM:BaseVM
    {
        public DataModel DataModel { get; set; }
        private Transformator transformator;
        public Transformator Transformator { get => transformator; 
            set  { transformator = value; OnPropertyChanged(); } 
        }
        internal Action Close;
        

        public TranformatorInfoVM()
        {
            Transformator = new Transformator();
        }
        public TranformatorInfoVM(Transformator Transformator, Action Close)
        {
            this.Transformator = Transformator;
            this.Close = Close;
        }
        private void SaveAndCloseForm()
        {
            DataModel.Transformators.Add(Transformator);
            Close();
        }
        #region ICommand
        public ICommand SaveAndCloseFormCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    SaveAndCloseForm();
                });
            }
        }
        public ICommand CloseFormCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    Close();
                });
            }
        }
        #endregion
    }
}
