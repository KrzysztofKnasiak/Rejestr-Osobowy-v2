using System;
using System.Collections.Generic;
using System.Text;

namespace Rejestr_Osobowy_V2
{
    public class Memory : IData
    {
        

        public List<Person> people = new List<Person>();
        public Person p = new Person();
        public Address a = new Address();
        

        public void AddData()
        {
            p.AddPerson(people);
            
           
        }

        public void DisplayData()
        {
            int i = 1;
            foreach (Person p in people)
            {
                Console.Write(i + ". ");
                i++;
                p.DisplayData();
            }
        }



        public void Menu()
        {
            
            bool check = true;
            do
                {
                
                    Console.Clear();
                    Console.WriteLine("--- Rejestr osobowy ---");
                    Console.WriteLine("1.Wyświetl listę osób\n2.Dodaj osobę\n3.Przeszukaj rejestr\n4.Edytuj dane\n5.Usuń osobę\n6.Zapisz i zakończ");
                    char option = Console.ReadKey().KeyChar;
                    Console.Clear();
                    switch (option)
                    {
                        case '1':
                            {
                                DisplayData();
                                Console.WriteLine("Naciśnij dowolny przycisk aby wrócić do menu...");
                                Console.ReadKey();

                                break;
                            }
                        case '2':
                            {
                                AddData();
                                break;
                            }
                        case '3':
                            {
                                Search();
                                break;
                            }
                        case '4':
                            {
                                Edit();
                                break;
                            }
                        case '5':
                            {
                                Delete();
                                break;
                            }
                        case '6':
                            {
                            check = false;
                            break;
                            }

                       /* default:
                            break; */
                    }
                }
                while (check == true);
        }
        public void Search()
        {
            try
            {


                Console.WriteLine("Wprowadź frazę którą chcesz wyszukać w rejestrze:");
                int counter = 1;
                string sentence = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Wyniki wyszukiwania frazy: {0}", sentence);
                Console.WriteLine("--------------------------------------");
                foreach (Person P in people.FindAll(x => x.Name.Contains(sentence) || x.Surname.Contains(sentence) || x.Age.ToString().Contains(sentence)
                || x.Gender.Contains(sentence) || x.Adr.PostCode.ToString().Contains(sentence) || x.Adr.City.Contains(sentence)
                || x.Adr.Street.Contains(sentence) || x.Adr.HouseNumber.ToString().Contains(sentence) || x.Adr.FlatNumber.ToString().Contains(sentence)))
                {
                    counter++;
                    P.DisplayData();

                }

                    if (counter == 1)
                    {
                        Console.WriteLine("Nie znaleziono wyszukiwanej frazy w rejestrze.");
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Naciśnij dowolny przycisk aby kontynuować...");
                        Console.ReadKey();
                    }
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);
            }
        }

        public void Delete()
        {
            int chose;
            DisplayData();
            Console.WriteLine("{0}.Powrót \n", people.Count + 1);

            try
            {
                Console.WriteLine("Którą osobę usunąć z rejestru ?\nWybierz numer przypisany do osoby, którą chcesz usunąć.");
                chose = int.Parse(Console.ReadLine());
                if (chose == people.Count + 1)
                {

                }
                else
                {
                    Console.Clear();
                    people.RemoveAt(chose - 1);
                    Console.WriteLine("Osoba została usunięta, naciśnij dowolny przycisk aby kontynuować..");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Coś poszło nie tak: " + e.Message);
                Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public void Edit()
        {
            //Pierwsza część menu 
            int chose;
            do
            {
                try
                {
                    DisplayData();
                    Console.WriteLine("{0}.Powrót", people.Count + 1);
                    Console.WriteLine("Której osoby dane chcesz edytować ?");
                    chose = int.Parse(Console.ReadLine());

                    if (chose == people.Count + 1)
                    {
                        break;
                    }

                    else if (chose > people.Count + 1)
                    {
                        throw new Exception("Wybrałeś niepoprawną wartość, pod tym indeksem nie widnieje żadna osoba.");

                    }
                    else
                    {
                        break;
                    }

                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine("Coś poszło nie tak: " + e.Message);
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (true);


            if (chose != people.Count + 1)
            {
                bool wait = true;
                do
                {

                    try
                    {


                        Console.Clear();
                        Console.WriteLine("Wybierz co chcesz edytować");
                        Console.WriteLine("1.Imię\n2.Nazwisko\n3.Wiek\n4.Płeć\n5.Kod pocztowy\n6.Miasto\n7.Ulia\n8.Numer domu\n9.Numer mieszkania\n0.Powrót");
                        char option = Console.ReadKey().KeyChar;
                        Console.Clear();

                        switch (option)
                        {
                            case '1':
                                {
                                    Console.WriteLine("Podaj nowe imię:");
                                    string newName = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newName) || newName.Length > 30)
                                    {
                                        throw new Exception("Pole imię nie może być puste oraz dłuższe niż 30 znaków, spróbuj ponownie...");
                                    }
                                    people[chose - 1].Name = newName;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            case '2':
                                {

                                    Console.WriteLine("Podaj nowe nazwisko:");
                                    string newSurname = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newSurname) || newSurname.Length > 30)
                                    {
                                        throw new Exception("Pole imię nie może być puste oraz dłuższe niż 30 znaków, spróbuj ponownie...");
                                    }
                                    people[chose - 1].Surname = newSurname;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '3':
                                {

                                    Console.WriteLine("Podaj nowy wiek:");
                                    int newAge = int.Parse(Console.ReadLine());
                                    if (newAge > 150 || newAge < 1)
                                    {

                                        throw new Exception("Minimalny wiek to 1, maksymalny 150, spróbuj ponownie...");
                                    }
                                    people[chose - 1].Age = newAge;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '4':
                                {

                                    Console.WriteLine("Podaj nową płeć:");
                                    string newGender = Console.ReadLine();
                                    if (newGender == "Kobieta" || newGender == "Mężczyzna" || newGender == "mężczyzna" || newGender == "kobieta")
                                    {

                                    }
                                    else
                                    {

                                        throw new Exception("Wprowadzone dane są niepoprawne, spróbuj ponownie...");
                                    }
                                    people[chose - 1].Gender = newGender;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '5':
                                {

                                    Console.WriteLine("Podaj nowy kod pocztowy:\nWprowadź bez -.");
                                    int newPostCode = int.Parse(Console.ReadLine());
                                    if (newPostCode.ToString().Length != 5)
                                    {
                                        throw new Exception("Wprowadzoe dane są niepoprawne, przekroczono liczbę znaków.");
                                    }
                                    people[chose - 1].Adr.PostCode = newPostCode;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '6':
                                {

                                    Console.WriteLine("Podaj nowe miasto");
                                    string newCity = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newCity) || newCity.Length > 30)
                                    {
                                        throw new Exception("Pole miasto nie może być puste oraz dłuższe niż 30 znaków.");
                                    }
                                    people[chose - 1].Adr.City = newCity;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '7':
                                {

                                    Console.WriteLine("Podaj nową ulicę");
                                    string newStreet = Console.ReadLine();
                                    if (string.IsNullOrEmpty(newStreet) || newStreet.Length > 30)
                                    {
                                        throw new Exception("Pole ulica nie może być puste oraz dłuższe niż 30 znaków.");
                                    }
                                    people[chose - 1].Adr.Street = newStreet;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }
                            case '8':
                                {

                                    Console.WriteLine("Podaj nowy numer domu");
                                    int newHouseNumber = int.Parse(Console.ReadLine());
                                    if (newHouseNumber > 1000 || newHouseNumber < 0)
                                    {
                                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                                    }
                                    people[chose - 1].Adr.HouseNumber = newHouseNumber;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;

                                }
                            case '9':
                                {

                                    Console.WriteLine("Podaj nowy numer mieszkania\nWprowadź 0 jeżeli chcesz usunąć.");
                                    int newFlatNumber = int.Parse(Console.ReadLine());
                                    if (newFlatNumber > 1000 || newFlatNumber < 0)
                                    {
                                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                                    }
                                    people[chose - 1].Adr.FlatNumber = newFlatNumber;
                                    Console.WriteLine("Dane zostały zmienione, naciśnij dowolny przycisk aby kontynuować..");
                                    Console.ReadKey();
                                    Console.Clear();

                                    break;
                                }

                            case '0':
                                {
                                    wait = false;
                                    break;
                                }



                                // default:
                                //break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Coś poszło nie tak: " + e.Message);
                        Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                        Console.ReadKey();
                        Console.Clear();
                    }

                } while (wait == true);
            }
            else
            {
            }


        }

    }
}


