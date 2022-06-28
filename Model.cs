using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropetyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string buforIO = "0";
        public string buforOperatora = "";
        public string buforPoprzedniegoOperatora = "";
        public string buforLiczbyPierwszej = "";
        public string buforLiczbyDrugiej = "";
        public string buforDziałania = "";
        public string buforWyniku = "";
        public string równaSię = "";
        public bool flagaOperatora = false;
        public bool flagaBufora = false;
        public bool flagaWyniku = false;
        public bool flagaCyfry = false;
        public bool flagaPrzecinka = false;
        public bool flagaZnaku = false;
        public bool flagaDziałania = false;

        public string Przypominajka
        {
            get
            {
               return $"{BuforLiczbyPierwszej} {BuforOperatora} {BuforLiczbyDrugiej} {równaSię}";
            }
        }

        public string BuforIO
        {
            get { return buforIO; }
            set
            {
                buforIO = value;
                OnPropetyChanged();
            }
        }

        public string BuforOperatora
        {
            get { return buforOperatora; }
            set
            {
                buforOperatora = value;
                OnPropetyChanged();
            }
        }
        public string BuforPoprzedniegoOperatora
        {
            get { return buforPoprzedniegoOperatora; }
            set
            {
                buforPoprzedniegoOperatora = value;
                OnPropetyChanged();
            }
        }

        public string BuforLiczbyPierwszej
        {
            get { return buforLiczbyPierwszej; }
            set
            {
                buforLiczbyPierwszej = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public string BuforLiczbyDrugiej
        {
            get { return buforLiczbyDrugiej; }
            set
            {
                buforLiczbyDrugiej = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public string BuforDziałania
        {
            get { return buforDziałania; }
            set
            {
                buforDziałania = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public string BuforWyniku
        {
            get { return buforWyniku; }
            set
            {
                buforWyniku = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        public string RównaSię
        {
            get { return równaSię; }
            set
            {
                równaSię = value;
                OnPropetyChanged();
                OnPropetyChanged("Przypominajka");
            }
        }

        internal void PobierzCyfrę(string cyfra)
        {
            if(flagaWyniku == false)
            {
                if (flagaCyfry == false)
                {
                    if (BuforIO == "0")
                        BuforIO = "";
                    BuforIO += cyfra;

                }
                else
                {
                    BuforIO = "";
                    BuforIO += cyfra;
                    flagaCyfry = false;
                }
            }
            else
            {
                Czyść();
                if (BuforIO == "0")
                    BuforIO = "";
                BuforIO += cyfra;
            }
            
            
        }

        internal void PobierzOperator(string pobierzOerator)
        {
            BuforOperatora = pobierzOerator;
            flagaCyfry = true;
            flagaPrzecinka = false;
            if (flagaOperatora == false)
            {
                BuforLiczbyPierwszej = BuforIO;
                flagaOperatora = true;
            }
            else
            {   
                if(flagaWyniku == false)
                {
                    double wynik;
                    if (BuforPoprzedniegoOperatora == "+")
                    {
                        BuforLiczbyDrugiej = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczbyPierwszej) + Convert.ToDouble(BuforLiczbyDrugiej);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczbyPierwszej = BuforIO;
                        BuforLiczbyDrugiej = "";
                    }
                    if (BuforPoprzedniegoOperatora == "-")
                    {
                        BuforLiczbyDrugiej = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczbyPierwszej) - Convert.ToDouble(BuforLiczbyDrugiej);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczbyPierwszej = BuforIO;
                        BuforLiczbyDrugiej = "";
                    }
                    if (BuforPoprzedniegoOperatora == "×")
                    {
                        BuforLiczbyDrugiej = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczbyPierwszej) * Convert.ToDouble(BuforLiczbyDrugiej);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczbyPierwszej = BuforIO;
                        BuforLiczbyDrugiej = "";
                    }
                    if (BuforPoprzedniegoOperatora == "÷")
                    {
                        BuforLiczbyDrugiej = BuforIO;
                        wynik = Convert.ToDouble(BuforLiczbyPierwszej) / Convert.ToDouble(BuforLiczbyDrugiej);
                        BuforIO = Convert.ToString(wynik);
                        BuforLiczbyPierwszej = BuforIO;
                        BuforLiczbyDrugiej = "";
                    }
                }
                else
                {
                    flagaWyniku = false;
                    BuforLiczbyPierwszej = BuforIO;
                    BuforLiczbyDrugiej = "";
                    RównaSię = "";                   
                }
                
            }
            BuforPoprzedniegoOperatora = BuforOperatora;            
        }

        internal void PobierzPrzecinek(string przecinek)
        {
            if (flagaWyniku == false)
            {
                if (flagaPrzecinka == false)
                {                    
                    BuforIO += przecinek;
                    flagaPrzecinka = true;
                }

            }
            else
            {
                Czyść();
                BuforIO += przecinek;
                flagaPrzecinka = true;
            }
        }

        internal void ObliczeniaDwuargumentowe()
        {
            double wynik;
            if(BuforOperatora == "+")
            {
                BuforLiczbyDrugiej = BuforIO;
                wynik = Convert.ToDouble(BuforLiczbyPierwszej) + Convert.ToDouble(BuforLiczbyDrugiej);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
                //flagaOperatora = false;
                RównaSię = "=";
            }
            if (BuforOperatora == "-")
            {
                BuforLiczbyDrugiej = BuforIO;
                wynik = Convert.ToDouble(BuforLiczbyPierwszej) - Convert.ToDouble(BuforLiczbyDrugiej);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
                RównaSię = "=";
            }
            if (BuforOperatora == "×")
            {
                BuforLiczbyDrugiej = BuforIO;
                wynik = Convert.ToDouble(BuforLiczbyPierwszej) * Convert.ToDouble(BuforLiczbyDrugiej);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
                RównaSię = "=";
            }
            if (BuforOperatora == "÷")
            {
                BuforLiczbyDrugiej = BuforIO;
                wynik = Convert.ToDouble(BuforLiczbyPierwszej) / Convert.ToDouble(BuforLiczbyDrugiej);
                BuforIO = Convert.ToString(wynik);
                flagaWyniku = true;
                RównaSię = "=";
            }
        }

        internal void PrzełączZnak()
        {
            if (BuforIO != "0")
                if (flagaZnaku == false)
                {
                    BuforIO = "-" + BuforIO;
                    flagaZnaku = true;
                }
                else
                {
                    BuforIO = BuforIO.Substring(1);
                    flagaZnaku = false;
                }
        }

        internal void DziałanieProcentowe()
        {
            if(BuforLiczbyPierwszej == "" || BuforLiczbyPierwszej == "0")
            {
                BuforLiczbyPierwszej = "0";
            }
            else
            {
                BuforLiczbyDrugiej = BuforIO;
                double wynik;
                double liczbaDruga;
                liczbaDruga = (Convert.ToDouble(BuforLiczbyDrugiej) * Convert.ToDouble(BuforLiczbyPierwszej)) / 100;
                if(buforPoprzedniegoOperatora == "+")
                {
                    wynik = Convert.ToDouble(BuforLiczbyPierwszej) + liczbaDruga;
                    BuforLiczbyDrugiej = Convert.ToString(liczbaDruga);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }
                if (buforPoprzedniegoOperatora == "-")
                {
                    wynik = Convert.ToDouble(BuforLiczbyPierwszej) + liczbaDruga;
                    BuforLiczbyDrugiej = Convert.ToString(liczbaDruga);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }
                if (buforPoprzedniegoOperatora == "×")
                {
                    wynik = Convert.ToDouble(BuforLiczbyPierwszej) + liczbaDruga;
                    BuforLiczbyDrugiej = Convert.ToString(liczbaDruga);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }
                if (buforPoprzedniegoOperatora == "÷")
                {
                    wynik = Convert.ToDouble(BuforLiczbyPierwszej) + liczbaDruga;
                    BuforLiczbyDrugiej = Convert.ToString(liczbaDruga);
                    BuforIO = Convert.ToString(wynik);
                    flagaWyniku = true;
                }

            }
        }

        internal void PrzełączOperator(string operatorPrzełącz)
        {
            if(flagaCyfry == true)
            {
                BuforOperatora = operatorPrzełącz;
                flagaOperatora = false;
            }
            
        }

        internal void CofnijZnak()
        {
            BuforIO = BuforIO.Substring(0, BuforIO.Length - 1);
            if (BuforIO == "")
            {
                BuforIO = "0";
            }
        }

        internal void PobierzDziałanieJednoargumentowe(string pobierzDziałanie)
        {
            BuforLiczbyDrugiej = "";
            BuforPoprzedniegoOperatora = "";
            RównaSię = "";
            BuforOperatora = "";
            BuforDziałania = pobierzDziałanie;
            flagaDziałania = true;
            BuforLiczbyPierwszej = buforIO;
            DziałanieJednoargumentowe();
        }

        internal void DziałanieJednoargumentowe()
        {
            double wynik;
            if(BuforDziałania == "1/x")
            {               
                wynik = 1 / Convert.ToDouble(BuforLiczbyPierwszej);
                BuforIO = Convert.ToString(wynik);
                BuforLiczbyPierwszej = "1/(" + BuforLiczbyPierwszej + ")";
                
            }
            if (BuforDziałania == "x²")
            {
                wynik = Convert.ToDouble(BuforLiczbyPierwszej) * Convert.ToDouble(BuforLiczbyPierwszej);
                BuforIO = Convert.ToString(wynik);
                BuforLiczbyPierwszej = "sqrt(" + BuforLiczbyPierwszej + ")";
            }
            if (BuforDziałania == "√x")
            {
                wynik = Math.Sqrt(Convert.ToDouble(BuforLiczbyPierwszej));
                BuforIO = Convert.ToString(wynik);
                BuforLiczbyPierwszej = "√(" + BuforLiczbyPierwszej + ")";
            }
        }

        internal void Czyść()
        {
            BuforIO = "0";
            BuforOperatora = "";
            buforPoprzedniegoOperatora = "";
            BuforLiczbyPierwszej = "";
            BuforLiczbyDrugiej = "";
            buforDziałania = "";
            BuforWyniku = "";
            RównaSię = "";
            flagaOperatora = false;
            flagaBufora = false;
            flagaWyniku = false;
            flagaCyfry = false;
            flagaPrzecinka = false;
            flagaZnaku = false;
            flagaDziałania = false;
        }
        
    }
}
