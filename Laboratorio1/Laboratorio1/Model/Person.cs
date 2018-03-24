using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratorio1.Model
{
    public class Person
    {
        public Person() {


        }
        public string IDPerson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }
        public List<Invoice> LstInvoice{get; set;}

        public string FullName => Name + " " + LastName;
        public double Age => (DateTime.Today - BirthDate).TotalDays/365.2425;
        public List<Invoice> GetList() {

            LstInvoice = new List<Invoice> {
                new Invoice(),
                new Invoice(),
                new Invoice()
            };

            return LstInvoice;

        }
        public static async Task<ObservableCollection<Person>> GetPersons()
        {
            ObservableCollection<Person> LstPersons;
            LstPersons = new ObservableCollection<Person>() {
                new Person(){IDPerson="123", Name="Diego", LastName="Gutierrez", SecondLastName="Castro", Email="diegolotr99@gmail.com", PhoneNumber="8888888", Picture="http://image.ibb.co/iHDecn/if_matureman2_628283_Cream.png" },
                new Person(){IDPerson="456", Name="Juan", LastName="Mora", SecondLastName="Fernandez", PhoneNumber="8888888", Picture="http://image.ibb.co/hACBq7/if_male3_403019.png"},
                new Person(){IDPerson="789", Name="Pedro", LastName="Picapiedra", SecondLastName="Marin", PhoneNumber="8888888", Picture="http://image.ibb.co/mf5mOS/if_matureman1_628284.png" },
                new Person(){IDPerson="101", Name="Pablo", LastName="Marmol", SecondLastName="Garita", PhoneNumber="8888888", Picture="http://image.ibb.co/jN9rq7/if_malecostume_403022.png" },
                new Person(){IDPerson="102", Name="Francisco", LastName="Marin", SecondLastName="Hernandez", PhoneNumber="5845888", Picture="http://image.ibb.co/ekM1OS/if_supportmale_403020.png" },
                new Person(){IDPerson="103", Name="Mario", LastName="Rivera", SecondLastName="Moya", PhoneNumber="275985885", Picture="http://image.ibb.co/fLYUcn/if_female1_403023.png" },
                new Person(){IDPerson="104", Name="Raul", LastName="Trejos", SecondLastName="Espinoza", PhoneNumber="5655245254", Picture="http://image.ibb.co/jTurq7/if_maturewoman_628297_Cream.png" }};
            Thread.Sleep(4000);
            return LstPersons;

        }

    }
}
