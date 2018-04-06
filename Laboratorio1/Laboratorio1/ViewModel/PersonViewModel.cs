using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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
            InitMenu();
        }
        public static PersonViewModel GetInstance() {

            if (instance == null)
                instance = new PersonViewModel();

            return instance;
        }
        #endregion
        #region Instances
        private ObservableCollection<MenuItem> _InitialMenu = new ObservableCollection<MenuItem>();
        public ObservableCollection<MenuItem> InitialMenu
        {
            get
            {
                return _InitialMenu;
            }

            set
            {
                _InitialMenu = value;
                OnPropertyChanged("InitalMenu");

            }
        }
        public bool EditModeInvoice { get; set; }
        private string _AddEditModeTitle { get; set; }
        public string AddEditModeTitle
        {
            get
            {
                return _AddEditModeTitle;
            }

            set
            {
                _AddEditModeTitle = value;
                OnPropertyChanged("AddEditModeTitle");

            }
        }
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

        //Invoice Instances

        
        private int _IDNewInvoice { get; set; }
        public int IDNewInvoice
        {
            get
            {
                return _IDNewInvoice;
            }
            set
            {
                _IDNewInvoice = value;
                OnPropertyChanged("IDNewInvoice");

            }
        }

        private string _DescriptionNewInvoice { get; set; }
        public string DescriptionNewInvoice
        {
            get
            {
                return _DescriptionNewInvoice;
            }
            set
            {
                _DescriptionNewInvoice = value;
                OnPropertyChanged("DescriptionNewInvoice");

            }
        }

        private double _AmountNewInvoice { get; set; }
        public double AmountNewInvoice
        {
            get
            {
                return _AmountNewInvoice;
            }
            set
            {
                _AmountNewInvoice = value;
                OnPropertyChanged("AmountNewInvoice");

            }
        }

        private string _TypeNewInvoice { get; set; }
        public string TypeNewInvoice
        {
            get
            {
                return _TypeNewInvoice;
            }
            set
            {
                _TypeNewInvoice = value;
                OnPropertyChanged("TypeNewInvoice");

            }
        }


       
        private Invoice _ActualInvoiceSelected { get; set; }

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
        public Invoice ActualInvoiceSelected
        {
            get
            {
                return _ActualInvoiceSelected;
            }
            set
            {
                _ActualInvoiceSelected = value;
                OnPropertyChanged("ActualInvoiceSelected");
            }
        }
        

        public ICommand SeePersonDetailCommand{ get; set;}
        public ICommand AddInvoiceCommand { get; set; }
        public ICommand AddNewInvoiceToPersonCommand { get; set; }
        public ICommand SetActualInvoiceCommand { get; set; }
        public ICommand EditInvoiceCommand { get; set; }
        public ICommand RemoveInvoiceCommand { get; set; }
        #endregion




        private async void InitClass()
        {
           
            lstPersons = await Person.GetPersons();
            initialLstPersons = lstPersons;
        }
        private void InitCommands()
        {
            SeePersonDetailCommand = new Command<string>(SeePersonDetail);
            AddInvoiceCommand = new Command<string>(AddInvoice);
            EditInvoiceCommand = new Command<string>(EditInvoice);
            RemoveInvoiceCommand = new Command(RemoveInvoice);
            SetActualInvoiceCommand = new Command<int>(SetActualInvoice);
            AddNewInvoiceToPersonCommand = new Command(AddNewInvoiceToPerson);
        }
        private void InitMenu()
        {
            InitialMenu = new ObservableCollection<MenuItem>() { new MenuItem() {Logo="Home_48px", Text="Home Page", Description="This will take you to the Home Page"},
                                                                 new MenuItem() {Logo="BarChart_48px", Text="Sales Stats", Description="This will take you to the Sales Stats Page" },
                                                                 new MenuItem() {Logo="Calculator_48px", Text="Calculate Sale Invoice", Description="This will take you to the Calculate Sale"},
                                                                new MenuItem() {Logo="ShoppingBag_48px", Text="List Of Articles", Description="This will take you to the Articles Page" }, };

        }
        private void AddNewInvoiceToPerson()
        {
            if (AddEditModeTitle.Contains("Add"))
            {
                Invoice NewInvoice = new Invoice() { ID = IDNewInvoice, Amount = AmountNewInvoice, Description = DescriptionNewInvoice, Type = TypeNewInvoice };
                if (ActualClient.LstInvoice != null)
                    ActualClient.LstInvoice.Add(NewInvoice);

                else
                    ActualClient.LstInvoice = new ObservableCollection<Invoice>() { NewInvoice };

               
            }
            else {
                Invoice InvoiceToEdit = ActualClient.LstInvoice.Where(x => x.ID == IDNewInvoice).FirstOrDefault();

                InvoiceToEdit.ID = IDNewInvoice;
                InvoiceToEdit.Description = DescriptionNewInvoice;
                InvoiceToEdit.Amount = AmountNewInvoice;
                InvoiceToEdit.Type = TypeNewInvoice;
                int index = ActualClient.LstInvoice.IndexOf(InvoiceToEdit);
                ActualClient.LstInvoice.Remove(InvoiceToEdit);
                ActualClient.LstInvoice.Insert(index, InvoiceToEdit);

                //ActualClient.LstInvoice.Where(x => x.ID == IDNewInvoice).FirstOrDefault().Description=DescriptionNewInvoice;
                //ActualClient.LstInvoice.Where(x => x.ID == IDNewInvoice).FirstOrDefault().Amount = AmountNewInvoice;
                //ActualClient.LstInvoice.Where(x => x.ID == IDNewInvoice).FirstOrDefault().Type= TypeNewInvoice;
                
                //ActualClient.LstInvoice.OrderBy(Invoice =>"ID");

                
            }

            OnPropertyChanged("ActualClient");
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();


        }
      
        private void SetActualInvoice(int pidInvoice) {

            ActualInvoiceSelected = ActualClient.LstInvoice.Where(x => x.ID == pidInvoice).FirstOrDefault();
        }
        private void SeePersonDetail(string pID)
        {

            ActualClient = initialLstPersons.Where(x => x.IDPerson == pID).FirstOrDefault();
            //Dummy data For list of Invoices   
            //ActualClient.LstInvoice = new List<Invoice>() { new Invoice() { ID = 1, Description = "Two Headsets", Amount = 100.00 },
                                                            //new Invoice() { ID = 2, Description = "Three Monitors", Amount = 500.00} };

           
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PersonDetailView());

        }
        
        private void AddInvoice(string Title)
        {
            AddEditModeTitle = Title;
            int LatestID = 0;
            
            if (ActualClient.LstInvoice != null)
                if (ActualClient.LstInvoice.Count > 0)
                     LatestID = ActualClient.LstInvoice.LastOrDefault().ID;
                   

            IDNewInvoice = LatestID + 1;
            DescriptionNewInvoice = "";
            AmountNewInvoice = 0;

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new NewInvoicePage());

        }
        private void EditInvoice(string Title)
        {
            AddEditModeTitle = Title;
            IDNewInvoice = ActualInvoiceSelected.ID;
            DescriptionNewInvoice = ActualInvoiceSelected.Description;
            AmountNewInvoice = ActualInvoiceSelected.Amount;
            TypeNewInvoice = ActualInvoiceSelected.Type;

            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new NewInvoicePage(true));

        }
        private void RemoveInvoice()
        {
            ActualClient.LstInvoice.Remove(ActualInvoiceSelected);
            

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
