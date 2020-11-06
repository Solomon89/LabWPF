using LabWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LabWPF.VIewModels
{
    class TransformatorsVM : INotifyPropertyChanged
    {
        public ObservableCollection<Transformator> Transformators { get; set; }
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
                if (value.Voltage == 30 && Transformators.Count ==3)
                {
                    Transformators.Add(new Transformator() { Id = 50, Name = $"Трансформатор - {50}", Resistance = 7 * (10), Voltage = 100 });
                }
                OnPropertyChanged();
            }

        }

        public TransformatorsVM()
        {
            Transformators = new ObservableCollection<Transformator>();
            int id = 0;
            Transformators.Add(new Transformator() { Id = id++, Name = $"Трансформатор - {id + 1}", Resistance = 7 * (id), Voltage = 100 });
            Transformators.Add(new Transformator() { Id = id++, Name = $"Трансформатор - {id + 1} ", Resistance = 7 * (id), Voltage = 100 });
            Transformators.Add(new Transformator() { Id = id++, Name = $"Трансформатор - {id + 1} ", Resistance = 7 * (id), Voltage = 100 });
        }

        #region IPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
