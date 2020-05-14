using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public sealed class TrulyObservableCollection<T> : ObservableCollection<T>
    {
        private readonly bool _inpcHookup;
        public bool NotifyPropertyChangedHookup => _inpcHookup;

        public TrulyObservableCollection()
        {
            CollectionChanged += TrulyObservableCollectionChanged;
            _inpcHookup = typeof(INotifyPropertyChanged).GetTypeInfo().IsAssignableFrom(typeof(T));
        }
        public TrulyObservableCollection(IEnumerable<T> items) : this()
        {
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        private void TrulyObservableCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (NotifyPropertyChangedHookup && e.NewItems != null && e.NewItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.NewItems)
                {
                    item.PropertyChanged += ItemPropertyChanged;
                }
            }
            if (NotifyPropertyChangedHookup && e.OldItems != null && e.OldItems.Count > 0)
            {
                foreach (INotifyPropertyChanged item in e.OldItems)
                {
                    item.PropertyChanged -= ItemPropertyChanged;
                }
            }
        }
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, sender, sender, IndexOf((T)sender));
            OnCollectionChanged(args);
        }
    }
}
