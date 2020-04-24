using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kundenBank
{
    class Kunde
    {
        public string Name { get; set; }
        public string Adresse { get; set; }
        public int kundenNummer { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList kunden = new ArrayList();
            int counter = 0;
            Kunde kunde = new Kunde();

            Console.WriteLine("Wie viele Kunden willst du Eingeben?: ");
            string input = Console.ReadLine();

            while (counter < int.Parse(input))
            {
                Console.Clear();
                Console.WriteLine("Kunde " + (counter + 1));
                Console.WriteLine("Kunden Name: ");
                kunde.Name = Console.ReadLine();
                kunden.Add(kunde.Name);
                Console.WriteLine("Kunden Adresse: ");
                kunde.Adresse = Console.ReadLine();
                kunden.Add(kunde.Adresse);
                Console.WriteLine("Kunden Nummer: ");
                kunde.kundenNummer = int.Parse(Console.ReadLine());
                kunden.Add(kunde.kundenNummer);
                counter++;
            }

            foreach (Object item in kunden)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }

}
