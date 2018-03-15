using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Laboratorio1.Model;
namespace Laboratorio1.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {


        #region Instances

        private ObservableCollection<Person> _lstPersons = new ObservableCollection<Person>();
        public ObservableCollection<Person> lstPersons {
            get {
                return _lstPersons;
            }

            set {
                _lstPersons = value;
                OnPropertyChanged("lstPersons");

            }

        }
        #endregion

        public PersonViewModel() {
            InitClass();
        }


        private async void InitClass()
        {
           
            lstPersons = await Person.GetPersons();
        }

        #region INotifyPropertyChange Interface Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {

            if (propertyName != null && PropertyChanged!= null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        #endregion
    }



}
