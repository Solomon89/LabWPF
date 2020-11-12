using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWPF
{
    static class Extentions
    {
        public static ObservableCollection<T> AddRange<T>(this ObservableCollection<T> currentCollection, ObservableCollection<T> CollectionToLoad)
        {
            foreach (var item in CollectionToLoad)
            {
                currentCollection.Add(item);
            }
            return currentCollection;
        }
    }
}
