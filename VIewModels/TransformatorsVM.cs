using LabWPF.Core;
using LabWPF.Models;
using LabWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabWPF.VIewModels
{
    class TransformatorsVM :BaseVM
    {
        public DataModel DataModel { get; set; }
        private Transformator selectedTransformator = new Transformator();
        public Transformator SelectedTransformator
        {
            get
            {
                return selectedTransformator;
            }
            set
            {
                selectedTransformator = value;
                if (value!= null && value.Voltage == 30 && DataModel.Transformators.Count ==3)
                {
                    DataModel.Transformators.Add(new Transformator() { Id = 50, Name = $"Трансформатор - {50}", Resistance = 7 * (10), Voltage = 100 });
                }
                OnPropertyChanged();
            }
        }
        public TransformatorsVM()
        {
            DataModel = new DataModel();
        }
        private void DeleteTranformator()
        {
            if (selectedTransformator != null)
            {
                DataModel.Transformators.Remove(selectedTransformator);
            }
        }
        private void ShowTranformatorInfo()
        {

            var view = new ShowTranformatorInfo();
            TranformatorInfoVM VM = (TranformatorInfoVM)view.DataContext;
            VM.Transformator = selectedTransformator;
            VM.Close = view.Close;
            view.Show();
        }
        #region ICommand
        public ICommand DeleteTranformatorCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    DeleteTranformator();
                });
            }
        }
        public ICommand ShowTranformatorInfoCommand
        {
            get
            {
                return new ActionCommand(() =>
                {
                    ShowTranformatorInfo();
                });
            }
        }
        #endregion

    }
}
