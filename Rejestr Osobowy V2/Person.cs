using System;
using System.Collections.Generic;
using System.Text;


namespace Rejestr_Osobowy_V2
{
    
    public  class Person : IData
    {

        string name;
        string surname;
        int age;
        string gender;
        Address adr = new Address();
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public int Age { get => age; set => age = value; }
        public string Gender { get => gender; set => gender = value; }
        public Address Adr { get => adr; set => adr = value; }

        public Person()
        {
        }

        public Person(string name, string surname, int age, string gender, Address adr)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.gender = gender;
            this.adr = adr;

        }

        public void AddPerson(List<Person> people)
        {
            bool check = false;
            do
            {


                try
                {
                    Console.WriteLine("---- Dodawanie osoby do rejestru ----");
                    Console.WriteLine("Podaj imię:");
                    name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name) || name.Length > 30)
                    {
                        throw new Exception("Pole imię nie może być puste oraz dłuższe niż 30 znaków.");
                    }
                    Console.WriteLine("Podaj nazwisko:");
                    surname = Console.ReadLine();
                    if (string.IsNullOrEmpty(surname) || surname.Length > 30)
                    {
                        throw new Exception("Pole nazwisko nie może być puste oraz dłuższe niż 30 znaków.");
                    }

                    if (people.Exists(x => x.name == name & x.surname == surname))
                    {
                        throw new Exception("Istnieje już osoba o takich danych w rejestrze, skontaktuj się z Administratorem w celu wyjaśnienia.");
                    }

                    Console.WriteLine("Podaj wiek:");
                    age = int.Parse(Console.ReadLine());
                    if (age > 150 || age < 1)
                    {

                        throw new Exception("Minimalny wiek to 1, maksymalny 150.");
                    }

                    Console.WriteLine("Podaj płeć:\nWprowadź: Kobieta | Mężczyzna");
                    gender = Console.ReadLine();
                    if (gender == "Kobieta" || gender == "Mężczyzna" || gender == "mężczyzna" || gender == "kobieta")
                    {

                    }
                    else
                    {

                        throw new Exception("Wprowadzone dane są niepoprawne.");
                    }
                    adr = new Address();
                    adr.AddAdress();
                    
                        people.Add(new Person(name, surname, age, gender,adr));
                        Console.Clear();
                        Console.WriteLine("Osoba została dodana do rejestru, naciśnij dowolny przycisk aby kontynuować..");
                        Console.ReadKey();
                        Console.Clear();
                  
                    check = true;
                }


                catch (Exception e)
                {

                    Console.Clear();
                    Console.WriteLine("Coś poszło nie tak: " + e.Message);
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
                    check = true;
                    Console.Clear();
                }
            } while (check == false);
        }

        public void DisplayData()
        {
            Console.WriteLine("{0} {1} \n   Wiek: {2}, {3}",name,surname,age,gender);
            adr.DisplayData();

        }

    }
}
