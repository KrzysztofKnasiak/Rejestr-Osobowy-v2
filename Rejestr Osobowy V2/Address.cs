using System;
using System.Collections.Generic;
using System.Text;

namespace Rejestr_Osobowy_V2
{
   public class Address : IData
    {
        int postCode;
        string city;
        string street;
        int houseNumber;
        int flatNumber;
 
        public int PostCode { get => postCode; set => postCode = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public int HouseNumber { get => houseNumber; set => houseNumber = value; }
        public int FlatNumber { get => flatNumber; set => flatNumber = value; }

       
        public Address()
        {
        }

        public Address(int postCode, string city, string street, int houseNumber)
        {
            this.postCode = postCode;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
        }

        public Address(int postCode, string city, string street, int houseNumber, int flatNumber)
        {
            this.postCode = postCode;
            this.city = city;
            this.street = street;
            this.houseNumber = houseNumber;
            this.flatNumber = flatNumber;
        }

        public List<Address> addresses = new List<Address>();
        public void AddAdress()
        {
            bool check = false;
            do
            {


                try
                {
                    Console.WriteLine("---- Dodawanie adresu do rejestru ----");
                    Console.WriteLine("Podaj kod pocztowy:\nWprowadź bez -.");
                    postCode = int.Parse(Console.ReadLine());
                    if (postCode.ToString().Length != 5)
                    {
                        throw new Exception("Wprowadzoe dane są niepoprawne, przekroczono liczbę znaków.");
                    }
                    Console.WriteLine("Podaj miasto:");
                    city = Console.ReadLine();
                    if (string.IsNullOrEmpty(city) || city.Length > 30)
                    {
                        throw new Exception("Pole miasto nie może być puste oraz dłuższe niż 30 znaków.");
                    }
                    Console.WriteLine("Podaj ulicę:");
                    street = Console.ReadLine();
                    if (string.IsNullOrEmpty(street) || street.Length > 30)
                    {
                        throw new Exception("Pole ulica nie może być puste oraz dłuższe niż 30 znaków.");
                    }
                    Console.WriteLine("Podaj numer domu:");
                    houseNumber = int.Parse(Console.ReadLine());

                    if (houseNumber > 1000 || houseNumber < 0)
                    {
                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                    }
                    Console.WriteLine("Podaj numer mieszkania:\nWprowadź 0 jeżeli nie występuje.");
                    flatNumber = int.Parse(Console.ReadLine());
                    if (flatNumber > 1000 || flatNumber < 0)
                    {
                        throw new Exception("Wprowadzone dane są niepoprawne, maksymalny numer to 1000.");
                    }
                    if (flatNumber == 0)
                    {
                        addresses.Add(new Address(postCode, city, street, houseNumber));
                        Console.Clear();
                       /* Console.WriteLine("Osoba została dodana do rejestru, naciśnij dowolny przycisk aby kontynuować..");
                        Console.ReadKey();
                        Console.Clear();*/
                    }
                    else
                    {
                        addresses.Add(new Address(postCode, city, street, houseNumber, flatNumber));
                        Console.Clear();
                       /* Console.WriteLine("Adres został dodany do rejestru, naciśnij dowolny przycisk aby kontynuować..");
                        Console.ReadKey();
                        Console.Clear();*/

                    }
                    check = true;
                }


                catch (Exception e)
                {

                    Console.Clear();
                    Console.WriteLine("Coś poszło nie tak: " + e.Message);
                    Console.WriteLine("Naciśnij dowolny klawisz aby kontynuować...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (check == false);
        }

        public void DisplayData()
        {
            
                if (flatNumber == 0)
                {
                    string convertedPostCode = postCode.ToString();
                    Console.Write("   ");

                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write("" + convertedPostCode[i]);

                    }

                    Console.Write("-");

                    for (int i = 2; i < 5; i++)
                    {
                        Console.Write(convertedPostCode[i]);

                    }

                    Console.WriteLine(" {0} \n   ul.{1} {2}", city, street, houseNumber);
                    Console.WriteLine("--------------------------------------");

                }
                else
                {

                    string convertedPostCode = postCode.ToString();
                    Console.Write("   ");

                    for (int i = 0; i < 2; i++)
                    {
                        Console.Write("" + convertedPostCode[i]);

                    }

                    Console.Write("-");

                    for (int i = 2; i < 5; i++)
                    {
                        Console.Write(convertedPostCode[i]);

                    }

                    Console.WriteLine(" {0} \n   ul.{1} {2}/{3}", city, street, houseNumber, flatNumber);
                    Console.WriteLine("--------------------------------------");
                }

            

        }

        
    }
}
