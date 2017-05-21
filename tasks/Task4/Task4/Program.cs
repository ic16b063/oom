/*
 Neuanfang um vorherige Codeduplikation auszumerzen und um die Methoden besser zu verinnerlichen.
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface IKonto
    {
        decimal Saldo { get; set; }
        uint GetKontonummer { get; }
        uint GetBankleitzahl { get; }
        string Vorname { get; set; }
        string Nachname { get; set; }

        void Kontodaten();
    }

    class Wertpapierdepot : IKonto
    {
        private uint WP_Kontonummer;
        private uint WP_Bankleitzahl;
        private decimal WP_Saldo;
        private string Konto_Inhaber_Vorname;
        private string Konto_Inhaber_Nachname;
        private int WP_Risikoklasse_Konto;
        public string WP_Anmerkung;
    
        //Vollkonstruktor
        public Wertpapierdepot(uint NeueKontonummer, string NeuerVorname, string NeuerNachname, int Risikoklasse)
        {
            if (NeueKontonummer < 1000000 || NeueKontonummer > 9999999)
                throw new ArgumentOutOfRangeException("Unpassende Kontonummer!\nDie Kontonummer für WP-Depots muss 7-stellig sein!\n");
            if (NeuerVorname == "" || NeuerNachname == "")
                throw new ArgumentException("Fehler beim Namen!\nDa Wertpapierdepots nur natürlichen Personen gehören können muss ein vollständiger Name erfasst werden!\n");
            if (Risikoklasse < -5 || Risikoklasse > 5)
                throw new ArgumentOutOfRangeException("Die Risikoklasse muss zwischen -5 und +5 liegen!");

            WP_Kontonummer = NeueKontonummer;
            WP_Bankleitzahl = 20111;
            WP_Saldo = 0;
            Konto_Inhaber_Vorname = NeuerVorname;
            Konto_Inhaber_Nachname = NeuerNachname;
            WP_Risikoklasse_Konto = Risikoklasse;
            WP_Anmerkung = "";
        }

        public uint GetKontonummer => WP_Kontonummer;
        public uint GetBankleitzahl => WP_Bankleitzahl;
        public decimal Saldo
        {
            get => WP_Saldo;
            set
            {
                WP_Saldo += value;
            }
        }
        public string Vorname
        {
            get =>Konto_Inhaber_Vorname;
            set
            {
                if (value.Length != 0) Konto_Inhaber_Vorname = value;
                else
                {
                    Console.WriteLine("Der Vorname darf nicht leer sein!");
                }
            }
        }
        public string Nachname
        {
            get=>Konto_Inhaber_Nachname;
            set
            {
                if (value.Length != 0) Konto_Inhaber_Nachname = value;
                else
                {
                    Console.WriteLine("Der Nachname darf nicht leer sein!");
                }
            }
        }
        public int Risikoklasse
        {
            get => WP_Risikoklasse_Konto;
            set
            {
                WP_Risikoklasse_Konto = value;
            }
        }

        public void Kontodaten()
        {
            Console.WriteLine("Wertpapierdepot - Kontodaten:\n" +
                "Kontonummer: {0} \n" +
                "Bankleitzahl: {1} \n" +
                "Kontostand: {2} \n" +
                "Inhaber-Vorname: {3} \n" +
                "Inhaber-Nachname: {4}\n" +
                "Risikoklasse: {5}\n" +
                "Anmerkung: {6}\n",
                WP_Kontonummer, WP_Bankleitzahl, WP_Saldo, Konto_Inhaber_Vorname, Konto_Inhaber_Nachname, WP_Risikoklasse_Konto, WP_Anmerkung);
        }
    }

    class Girokonto : IKonto
    {
        private uint GI_Kontonummer;
        private uint GI_Bankleitzahl;
        private decimal GI_Saldo;
        private string Konto_Inhaber_Vorname;
        private string Konto_Inhaber_Nachname;
        public string GI_Anmerkung;
        public string GI_AliasName;

        //Vollkonstruktor
        public Girokonto(uint NeueKontonummer, string NeuerVorname, string NeuerNachname)
        {
            if (NeueKontonummer < 10000000 || NeueKontonummer > 99999999)
                throw new ArgumentOutOfRangeException("Unpassende Kontonummer!\nDie Kontonummer für Girokonten muss 8-stellig sein!\n");

            GI_Kontonummer = NeueKontonummer;
            GI_Bankleitzahl = 20111;
            GI_Saldo = 0;
            Konto_Inhaber_Vorname = NeuerVorname;
            Konto_Inhaber_Nachname = NeuerNachname;
            GI_Anmerkung = "";
            GI_AliasName = "";
        }

        //Konstruktor für Institutskonto
        public Girokonto(uint NeueKontonummer) : this(NeueKontonummer, "Institutskonto!", "Institutskonto!")
        {

        }   

        public decimal Saldo
        {
            get => GI_Saldo;
            set
            {
                GI_Saldo += value;
            }
        }
        public uint GetKontonummer => GI_Kontonummer;
        public uint GetBankleitzahl => GI_Bankleitzahl;
        public string Vorname
        {
            get => Konto_Inhaber_Vorname;
            set
            {
                Konto_Inhaber_Vorname = value;
            }
        }
        public string Nachname
        {
            get => Konto_Inhaber_Nachname;
            set
            {
                Konto_Inhaber_Nachname = value;
            }
        }

        public void Kontodaten()
        {
            Console.WriteLine("Girokonto - Kontodaten:\n" +
                "Kontonummer: {0} \n" +
                "Bankleitzahl: {1} \n" +
                "Kontostand: {2} \n" +
                "Inhaber-Vorname: {3} \n" +
                "Inhaber-Nachname: {4}\n" +
                "Konto-AliasName: {5}\n" +
                "Anmerkung: {6}\n", 
                GI_Kontonummer, GI_Bankleitzahl, GI_Saldo, Konto_Inhaber_Vorname, Konto_Inhaber_Nachname, GI_AliasName, GI_Anmerkung);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IKonto[] Bestand = new IKonto[4];

            Girokonto Kunde1 = new Girokonto(12345678, "Christian", "Posch");
            Girokonto Kunde2 = new Girokonto(23456789, "Karl Heinz", "Steinmetz");
            Girokonto ErsteBank = new Girokonto(11111111);
            Wertpapierdepot Kunde3 = new Wertpapierdepot(1234567, "Dominic", "Francan", -5);

            Bestand[0] = Kunde1;
            Bestand[1] = Kunde2;
            Bestand[2] = ErsteBank;
            Bestand[3] = Kunde3;

            for (int j = 0; j < Bestand.Length; j++)
            {
                if (j == 0) Bestand[j].Saldo = 1235;
                else Bestand[j].Saldo = (Bestand[j - 1].Saldo + 37) * 2;
            }

            foreach (var i in Bestand)
            {
                Console.WriteLine("Kontostand = " + i.Saldo);
            }
            Console.WriteLine("\n\n-----------------------------");
            foreach (var k in Bestand)
            {
                k.Kontodaten();
                Console.WriteLine("\n");
            }
            Console.WriteLine("-----------Ende der normalen Ausgabe----------\n" +
                "Start der JSON Bearbeitung und deren Ausgabe\n\n");

            string s = "";
            string filepathGI = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GI.txt";
            string filepathWP = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\WP.txt";
            if (System.IO.File.Exists(filepathGI)) System.IO.File.Delete(filepathGI);
            if (System.IO.File.Exists(filepathWP)) System.IO.File.Delete(filepathWP);
            Console.ReadLine();
            int count = 0;
            
            for (count = 0; count < Bestand.Length; count++)
            {
                if (Bestand[count].GetKontonummer < 100000000 && Bestand[count].GetKontonummer > 9999999)
                {
                    System.IO.File.AppendAllText(filepathGI, JsonConvert.SerializeObject(Bestand[count]));
                } else
                    if(Bestand[count].GetKontonummer < 10000000 && Bestand[count].GetKontonummer > 999999)
                {
                    System.IO.File.AppendAllText(filepathWP, s = JsonConvert.SerializeObject(Bestand[count]));
                }
            }
            string gi = "GI:\n" + System.IO.File.ReadAllText(filepathGI);
            string wp = "WP:\n" + System.IO.File.ReadAllText(filepathWP);
            Console.WriteLine(gi);
            Console.WriteLine(wp);
        }
    }
}
