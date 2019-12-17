using System;
using System.Collections.Generic;
using System.IO;

namespace ExamQuestion4
{
    class Program
    {
        static void Main(string[] args)

            //A) Tee luokka Tuotantotapahtuma, jossa on jäsenmuuttujat (propertyt KoneId, KoneenNimi, TuoteId, KoneAika. 
            //Lisää luokkaan konstruktori ja ToString() metodi
            //B)Tee ohjelma, joka lukee tiedoston koneajaat.txt ja lisää tuotantotapahtuma-oliot listaan. Tulosta lista näytölle.
            //C)Laske kuinka kauan koneita on käytetty kunkin tuotteen (101, 102, 103) valmistamiseen. Käytä apuna Dictionarya.
            //Dictionaryssa avaimeksi tulee tuotteen tunnus. Arvoksi tulee tuotteen valmistukseen tarvittujen koneiden toiminta-aika yhteensä
        {
            //Tehdään lista
            List<Tuotantotapahtuma> tuotantotapahtumat = new List<Tuotantotapahtuma>();

            //Tehdään dictionary
            Dictionary<int, int> valmistusAjat = new Dictionary<int, int>();

            //Tiedostosta lukeminen
            string polku = (@"C:\Users\Herman\source\repos\ExamQuestion5\ExamQuestion5\koneajat.txt");

            if (File.Exists(polku))
            {
                StreamReader streamReader = File.OpenText(polku);

                string row;
                while ((row = streamReader.ReadLine()) != null)
                {
                    string[] taulukko;
                    taulukko = row.Split(';');
                    int koneid = int.Parse(taulukko[0]);
                    string koneennimi = taulukko[1];
                    int tuoteid = int.Parse(taulukko[2]);
                    int koneaika = int.Parse(taulukko[3]);
                    //Luodaan uusi olio joka lisätään listaan
                    tuotantotapahtumat.Add(new Tuotantotapahtuma(koneid, koneennimi, tuoteid, koneaika));

                    //Jos avainta ei ole olemassa -> Tehdään uusi itemi dictionaryyn
                    //Avaimena käytetään tuoteid:ta
                    if (valmistusAjat.ContainsKey(tuoteid) == false)
                    {
                        valmistusAjat.Add(tuoteid, koneaika);
                    }
                    //Jos avain on olemassa, kasvatetaan valueta
                    else if(valmistusAjat.ContainsKey(tuoteid))
                    {
                        valmistusAjat[tuoteid] = valmistusAjat[tuoteid] + koneaika;
                    }

                }
            }
            //Tulostetaan listan itemit/oliot
            foreach (var item in tuotantotapahtumat)
            {
                Console.WriteLine(item);
            }

            //Tulostetaan dictionary
            foreach (var item in valmistusAjat)
            {
                Console.WriteLine($"avain {item.Key} koneaika yhteensä {item.Value} sekuntia.");
            }
            Console.ReadLine();
        }
    }
}
