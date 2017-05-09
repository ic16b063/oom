using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Konto
    {
        private int K_Kontonummer;
        private int K_Bankleitzahl;
        private decimal K_Kontostand;
        private string K_Vorname;
        private string K_Nachname;
        public string AliasName;
        public string Anmerkung;

        //Konstruktoren
        //Voll-Konstruktor
        public Konto(int NeueKontonummer, string NeuerVorname, String NeuerNachname)
        {
            if (NeueKontonummer < 10000000)
                throw new ArgumentOutOfRangeException("Die Kontonummer ist zu lang!\nDie Kontonummer muss 8-stellig sein!\n");
            if (NeueKontonummer > 99999999)
                throw new ArgumentOutOfRangeException("Die Kontonummer ist zu kurz!\nDie Kontnummer muss 8-stellig sein!\n");

            K_Kontonummer = NeueKontonummer;
            K_Bankleitzahl = 20111;
            K_Kontostand = 0;
            Vorname = NeuerVorname;
            Nachname = NeuerNachname;
            AliasName = "";
            Anmerkung = "";
        }

        //Konstruktor für Anlage ohne Namen
        public Konto(int NeueKontonummer)
            :this(NeueKontonummer, "Institutskonto", "Institutskonto")
        {

        }

        //Methode der Klasse Konto zur Ausgabe der Daten

        //Methoden der Klasse Konto zum Ändern
        public string Nachname
        {
            get
            {
                return K_Nachname;
            }
            set
            {
                if (value.Length == 0)
                    throw new ArgumentException("Kein gültiger Nachname!");
                    K_Nachname = value;
            }
        }

        public decimal Kontostand
        {
            get
            {
                return K_Kontostand;
            }
            set
            {
                K_Kontostand += value;
            }
        }

        public string Vorname
        {
            get
            {
                return K_Vorname;
            }
            set
            {
                K_Vorname = value;
            }
        }

        public void Kontodaten()
        {
            Console.WriteLine("Kontodaten:\nKontonummer: {0} \n" +
                "Bankleitzahl: {1} \n" +
                "Kontostand: {2} \n" +
                "Inhaber-Vorname: {3} \n" +
                "Inhaber-Nachname: {4}\n" +
                "Konto-AliasName: {5}\n" +
                "Anmerkung: {6}\n", K_Kontonummer, K_Bankleitzahl, K_Kontostand, K_Vorname, K_Nachname, AliasName, Anmerkung);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Konto Kunde1 = new Konto(12345678, "Christian", "Posch");
            Konto Kunde2 = new Konto(23456789, "Karl Heinz", "Steinmetz");
            Konto ErsteBank = new Konto(11111111);

            //Kunde1 Test
            Console.WriteLine("Konto1 Test\n");
            Kunde1.Kontostand = -200;
            //Console.WriteLine("Kontostand neu: " + Kunde1.Kontostand);
            Kunde1.Kontostand = +1200;
            //Console.WriteLine("Kontostand neu: " + Kunde1.Kontostand);
            Kunde1.Kontodaten();

            //Kunde2 Test
            Console.WriteLine("\n\nKonto2 Test\n");
            Kunde2.AliasName = "El Präsidente";
            Kunde2.Anmerkung = "Nicht wirklich der Präsident";
            Kunde2.Kontostand = +10000000;
            Kunde2.Kontostand = (decimal) -1.99;
            Kunde2.Kontodaten();

            //Institutskonto Test
            Console.WriteLine("\n\nKontoErsteBank Test\n");
            ErsteBank.Kontodaten();
            ErsteBank.Nachname = "Wien";
            ErsteBank.Kontodaten();
        }
    }
}
