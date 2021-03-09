using System;
using System.Collections.Generic;
using System.Text;

namespace Rejestr_Osobowy_V2
{
    public class Memory : IData
    {
        

        public List<Person> people = new List<Person>();
       // List<Address> addresses = new List<Address>();
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
                               // p.EditPerson();
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
    }
}


