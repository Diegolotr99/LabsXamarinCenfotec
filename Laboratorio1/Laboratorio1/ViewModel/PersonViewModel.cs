using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Laboratorio1.Model;
using Laboratorio1.View;
using Xamarin.Forms;

namespace Laboratorio1.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        #region Singleton
        private static PersonViewModel instance = null;
        public PersonViewModel() {
            InitClass();
            InitCommands();
        }
        public static PersonViewModel GetInstance() {

            if (instance == null)
                instance = new PersonViewModel();

            return instance;
        }
        #endregion
        #region Instances
        private ObservableCollection<Person> initialLstPersons = new ObservableCollection<Person>();
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
        private Person _ActualClient { get; set; }

        public Person ActualClient
        {
            get
            {
                return _ActualClient;
            }
            set
            {
                _ActualClient = value;
                OnPropertyChanged("ActualClient");
            }
        }
        public ICommand SeePersonDetailCommand{ get; set;}
        #endregion

       


        private async void InitClass()
        {
           
            lstPersons = await Person.GetPersons();
            initialLstPersons = lstPersons;
        }
        private void InitCommands()
        {
            SeePersonDetailCommand = new Command<string>(SeePersonDetail);


        }

        private void SeePersonDetail(string pID)
        {

            ActualClient = initialLstPersons.Where(x => x.IDPerson == pID).FirstOrDefault();
            //Dummy data For list of Invoices   
            ActualClient.LstInvoice = new List<Invoice>() { new Invoice() { ID = 1, Description = "Two Headsets", Amount = 100.00 },
                                                            new Invoice() { ID = 2, Description = "Three Monitors", Amount = 500.00} };

            App.Current.MainPage = new PersonDetailView();

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
