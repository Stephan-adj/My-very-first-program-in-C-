//ADJARIAN Stéphan
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeryFirstProgram
{
    class Program
    {
        static int NombreDeJours(int month)
        {
            //Init
            int days = 31;

            //Processing
            if ( ((1 <= month && month <=7) && month % 2 == 0) || ((8 <= month && month <= 12) && month % 2 != 0) )
            {
                days = 30;          
            }
            if (month == 2)
            {
                days = 28;
            }

            //return
            return days;
        }
        static bool Anneebissextile(int year)
        {
            //Init
            bool result = false;

            //Processing
            if (year % 400 == 0 || (year % 100 !=0 && year % 4 ==0))
            {
                result = true;//C'est une année bissextile
            }

            //Return
            return result;
        }
        static int NombreDeJoursAnnee(int year, int month)
        {
            //Init
            int nombreDeJours = 0;

            //Processing
            if (Anneebissextile(year) && month == 2)//Dans une année bissextile le mois de février possède 29 jours.
            {
                nombreDeJours = 29;
            }
            else
            {
                nombreDeJours = NombreDeJours(month);
            }

            //Return
            return nombreDeJours;
        }
        static void Affichage_NombreDeJoursAnnee()
        {
            //Enter
            Console.WriteLine("Saisissez l'année =>");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Saisissez le numéro du mois =>");
            int month = Convert.ToInt32(Console.ReadLine());
            while (month < 1 || month > 12)
            {
                Console.WriteLine("Saisissez un numéro de mois compris entre 1 et 12 !");
                month = Convert.ToInt32(Console.ReadLine());
            }

            //Disp
            Console.WriteLine("Le " + month + " ier/ième mois de l'année " + year + " il y a " + NombreDeJoursAnnee(year, month) + " jours.\n");
        }

        static void MéthodeGaussienneGrégorien(int year)
        {
            //Init
            string dateDePâques = "#ERROR 404# : not found :) ";

            //Process
            if (year >= 1583)   //en calendrier grégorien
            {
                int a = year % 19;
                int b = year % 4;
                int c = year % 7;
                int k = year / 100;
                int p = (13 + 8 * k) / 25;
                int q = k / 4;
                int M = (15 - p + k - q) % 30;
                int N = (4 + k - q) % 7;
                int d = (19 * a + M) % 30;
                int e = (2 * b + 4 * c + 6 * d + N) % 7;
                int H = 22 + d + e;
                int Q = H - 31;

                if (H <= 31)
                {
                    dateDePâques = "le " + H + " mars.";
                }
                else
                {
                    dateDePâques = "le " + Q + " avril.";
                }
                if (d == 29 && e == 6)
                {
                    dateDePâques = "le 19 avril.";
                }
                else
                {
                    if (d == 28 && e == 6 && ((11 * M + 11) % 30 < 19))
                    {
                        dateDePâques = "le 18 avril.";
                    }
                }                
            }
            else
            {
                Console.WriteLine("\nCe choix de méthode et de calendrier ne permet pas le calcul de la date de \nPâques de l'année " + year);
            }
            Console.WriteLine("\nLa date de Pâques de l'année " + year + " est " + dateDePâques);
        }
        static void MéthodeGaussienneJulien(int year)
        {
            //Init
            string dateDePâques = "#ERROR 404# : not found :) ";

            //Process
            if (year < 1583 && year >= 325) //en calendrier julien
            {
                int a = year % 19;
                int b = year % 4;
                int c = year % 7;
                int M = 15;
                int N = 6;
                int d = (19 * a + M) % 30;
                int e = (2 * b + 4 * c + 6 * d + N) % 7;
                int H = 22 + d + e;
                int Q = H - 31;

                Console.WriteLine("TEST :" + H);
                if (H <= 31)
                {
                    dateDePâques = "le " + H + " mars.";
                }
                else
                {
                    dateDePâques = "le " + Q + " avril.";       
                }
            }
            else
            {
                Console.WriteLine("\nCe choix de méthode et de calendrier ne permet pas le calcul de la date de \nPâques de l'année " + year);
            }
            Console.WriteLine("\nLa date de Pâques de l'année " + year + " est " + dateDePâques);
        }
        static void MéthodeMeeusienneGrégorien(int year)
        {
            //Init
            string dateDePâques = "#ERROR 404# : not found :) ";

            //Process
            if (year >= 1583)   //en calendrier grégorien
            {
                int n = year % 19;
                int u = year % 100;
                int c = year / 100;
                int t = c % 4;
                int s = c / 4;
                int p = (c + 8) / 25;
                int q = (c - p + 1) / 3;
                int e = (19 * n + c - s - q + 15) % 30;
                int d = u % 4;
                int b = u / 4;
                int L = (2 * t + 2 * b - e - d + 32) % 7;
                int h = (n + 11 * e + 22 * L) / 451;
                int m = (e + L - 7 * h + 114) / 31;
                int j = (e + L - 7 * h + 114) % 31;
                int date = j + 1;

                if (m == 3)
                {
                    dateDePâques = "le " + date + " mars.";
                }
                if (m == 4)
                {
                    dateDePâques = "le " + date + " avril.";
                }
            }
            else
            {
                Console.WriteLine("\nCe choix de méthode et de calendrier ne permet pas le calcul de la date de \nPâques de l'année " + year);
            }
            Console.WriteLine("\nLa date de Pâques de l'année " + year + " est " + dateDePâques);
        }
        static void MéthodeMeeusienneJulien(int year)
        {
            //Init
            string dateDePâques = "#ERROR 404# : not found :) ";

            //Process
            if (year < 1583 && year >= 325) //en calendrier julien
            {
                int A = year % 19;
                int B = year % 7;
                int C = year % 4;
                int D = (19 * A + 15) % 30;
                int E = ((2 * C) + (4 * B) - D + 34) % 7;
                int G = (D + E + 114) % 31;
                int F = (D + E + 114) / 31;
                int date = G + 1;

                if (F == 3)
                {
                    dateDePâques = "le " + date + " mars.";
                }
                if (F == 4)
                {
                    dateDePâques = "le " + date + " avril.";
                }
            }
            else
            {
                Console.WriteLine("\nCe choix de méthode et de calendrier ne permet pas le calcul de la date de \nPâques de l'année " + year);
            }
            Console.WriteLine("\nLa date de Pâques de l'année " + year + " est " + dateDePâques);
        }
        static void MéthodeConwayienneGrégorien(int year)
        {
            //Init
            string dateDePâques = "#ERROR 404# : not found :) ";

            //Process
            if (year >= 1583)   //en calendrier grégorien
            {
                int t = year % 100;
                int s = year / 100;
                int a = t / 4;
                int p = s % 4;
                int jps = (9-2*p) % 7;
                int jp = (jps + t + a) % 7;
                int g = year % 19;
                int G = g + 1;
                int b = s / 4;
                int r = (8*(s+11)) / 25;
                int C = -s + b + r;
                int d = (11 * G + C) % 30;
                d = (d+30) % 30;
                int h = (551-19*d+G) / 544;
                int e = (50-d-h) % 7;
                int f = (e + jp) % 7;
                int R = 57 - d - f - h;
                int date = R - 31;
                
                if (R <= 31)
                {
                    dateDePâques = "le " + R + " mars.";
                }
                else
                {
                    dateDePâques = "le " + date + " avril.";
                }
            }
            else
            {
                Console.WriteLine("\nCe choix de méthode et de calendrier ne permet pas le calcul de la date de \nPâques de l'année " + year);
            }
            Console.WriteLine("\nLa date de Pâques de l'année " + year + " est " + dateDePâques);
        }
        static void MéthodeConwayienneJulien(int year)
        {
            Console.WriteLine("\nLe calcul de l'année " + year + " n'est pas possible car il n'existe pas de méthode Conwayienne pour le calendrier Julien donc pour les années inférieur à 1583");
        }
        static int MéthodeConwayienneV2(int year)
        {
            //Init
            int R = 0;

            //Process
            if (year >= 1583)   //en calendrier grégorien
            {
                int t = year % 100;
                int s = year / 100;
                int a = t / 4;
                int p = s % 4;
                int jps = (9 - 2 * p) % 7;
                int jp = (jps + t + a) % 7;
                int g = year % 19;
                int G = g + 1;
                int b = s / 4;
                int r = (8 * (s + 11)) / 25;
                int C = -s + b + r;
                int d = (11 * G + C) % 30;
                d = (d + 30) % 30;
                int h = (551 - 19 * d + G) / 544;
                int e = (50 - d - h) % 7;
                int f = (e + jp) % 7;
                R = 57 - d - f - h;
            }
            else
            {
                Console.WriteLine("\nOn ne peut effectuer le calcul pour cette année là.");
            }
            return R;
        }

        static void DateDePâquesAnnéeDonnée()
        {
            //Year's choice
            Console.Write("Saisissez l'année pour laquelle vous souhaitez avoir la date de Pâques \n(pour une année >= 325) => ");
            int year = Convert.ToInt32(Console.ReadLine());

            //Processing
            if(year >= 1583)
            {
                Console.WriteLine("\nAvec le calendrier Grégorien :");
                MéthodeGaussienneGrégorien(year);
            }
            else
            {
                if(year < 1583 && year >= 325)
                {
                    Console.WriteLine("\nAvec le calendrier Julien :");
                    MéthodeGaussienneJulien(year);
                }
                else
                {
                    Console.WriteLine("\nLe calcul de la date de Pâques n'est pas possible pour l'année choisi.");
                }
            }
        }
        static void Décennie()
        {
            //Year's choice
            Console.Write("Saisissez l'année pour laquelle vous souhaitez avoir la décennie de Pâques\n=> ");
            int year = Convert.ToInt32(Console.ReadLine());

            //Truncate to obtain decade
            double yearbis = Math.Truncate((year / 10.0));
            year = (int)yearbis * 10;

            //Processing
            for (int annee = year; annee <= year + 9; annee++)
            {
                if (annee < 1583 && annee >= 325)
                {
                    //Disp
                    MéthodeConwayienneJulien(annee);
                }
                if (annee >= 1583)
                {
                    //Disp
                    MéthodeConwayienneGrégorien(annee);
                }     
                if (annee < 325)
                {
                    Console.WriteLine("Le calcul de la dâte de Pâques de l'année " + annee + " n'est pas possible.");
                }
            }
        }       
        static void AutreFêteCalcul(int year, int décalage)
        {
            //Init
            //decalage correspond au nombre de jours par rapport à la date de Pâques
            int month = 0;
            int référentiel = MéthodeConwayienneV2(year); //Pâques  
            int distanceSéparantFinDuMois = 0;
            //Le tableau suivant n'est utilisé qu'à des fins d'affichage
            string[] mois = new string[12] { "janvier", "février", "mars", "avril", "mai", "juin", "juillet", "août", "septembre", "octobre", "novembre", "décembre" };          

            //On execute ce programme seulement lorsque le calcul de Pâques est possible.
            if (référentiel != 0)
            {
                //Je re-set la bonne date et le bon mois de Pâques tiré de la méthode de Conway
                if (référentiel <= 31)
                {
                    month = 3; //mars
                }
                else
                {
                    month = 4; //avril
                    référentiel = référentiel - 31;
                }

                //Processing
                //Pour trouver la date de la fête il faut se décaler de mois en mois si nécessaire, en faisant attention au nombre de jours du mois 
                while (décalage != 0)   
                {
                    //Before Pâques
                    if (décalage < 0)   
                    {
                        if (Math.Abs(décalage) >= référentiel)
                        {
                            décalage = décalage + référentiel;
                            month--;
                            référentiel = NombreDeJoursAnnee(year, month);
                        }
                        else
                        {
                            référentiel = référentiel + décalage;
                            décalage = 0;
                        }
                    }
                    //After Pâques
                    else
                    {
                        distanceSéparantFinDuMois = NombreDeJoursAnnee(year, month) - référentiel;
                        if (décalage > distanceSéparantFinDuMois)
                        {
                            décalage = décalage - distanceSéparantFinDuMois - 1;
                            month++;
                            référentiel = 1;
                        }
                        else
                        {
                            référentiel = référentiel + décalage;
                            décalage = 0;
                        }
                    }
                }

                //Disp
                Console.WriteLine("La date de cette fête est le " + référentiel + " " + mois[month - 1] + " pour l'année " + year + ".");
            }               
        }
        static void AffichageAutreFete()
        {
            //Disp
            Console.WriteLine("\n\t\t\t     Liste des fêtes :\n");
            Console.WriteLine("1 : Mardi Gras");
            Console.WriteLine("2 : Ascension");
            Console.WriteLine("3 : Lundi de Pentecôte");
            Console.WriteLine("4 : Toussaint");
            Console.WriteLine("5 : Fête de la Sainte Trinité");

            //Select which feast
            Console.Write("Saisissez le numéro associé à la fête => ");
            string choix = Convert.ToString(Console.ReadLine());

            //Year's choice
            Console.Write("\nSaisissez l'année pour laquelle vous souhaitez avoir la date de la fête => ");
            int year = Convert.ToInt32(Console.ReadLine());

            //Selector
            switch (choix)
            {
                case "1":
                    Console.WriteLine("\nMardi Gras :");
                    AutreFêteCalcul(year, -47);
                    break;
                case "2":
                    Console.WriteLine("\nAscension :");
                    AutreFêteCalcul(year, 39);
                    break;
                case "3":
                    Console.WriteLine("\nLundi de Pentecôte :");
                    AutreFêteCalcul(year, 50);
                    break;
                case "4":
                    Console.WriteLine("\nToussaint :");
                    AutreFêteCalcul(year, 56);
                    break;
                case "5":
                    Console.WriteLine("\nFête de la Sainte Trinité :");
                    AutreFêteCalcul(year, 56);
                    break;

                //Input error
                default:
                    Console.WriteLine("Erreur de saisi, veuillez recommencer la procédure.");
                    break;
            }
        }
        static void DatesDePâquesMultiples()
        {
            //Year's choice
            Console.Write("Saisissez l'année pour laquelle vous souhaitez avoir la date de Pâques => ");
            int year = Convert.ToInt32(Console.ReadLine());

            //Select how many times
            string choix = "";
            Console.Write("Saisissez le nombre de méthode que vous voulez tester (majoré à 6 fois) => ");    
            int xfois = Convert.ToInt32(Console.ReadLine());
            while(xfois > 6 || xfois < 1)
            {
                Console.WriteLine("Je vous avais pourtant dit que c'était majoré à 6 fois...\n Try again => ");
                xfois = Convert.ToInt32(Console.ReadLine());
            }

            //Storing choice(s)
            //Utilisé encore une fois à des fins d'affichage
            string[] chaineChoix = new string[xfois];
            for (int i = 0; i < xfois; i++)
            {
                //Disp methods
                Console.WriteLine("\nChoisissez avec quel méthode :\n");
                Console.WriteLine("Méthode Gaussienne : 1");
                Console.WriteLine("Méthode Meeusienne : 2");
                Console.WriteLine("Méthode Conwayienne : 3");
                Console.Write("Saisissez le numéro associé à la méthode de votre choix => ");

                //Select method
                choix = Convert.ToString(Console.ReadLine());

                //Disp calendars
                Console.WriteLine("\nChoisissez avec quel calendrier :");
                Console.WriteLine("Calendrier Grégorien : g");
                Console.WriteLine("Calendrier Julien : j");
                Console.Write("Saisissez le lettre de votre choix => ");

                //Select calendar
                choix = choix + Convert.ToString(Console.ReadLine());

                //Storing Choice(s)
                chaineChoix[i] = choix;
                choix = "";
            }
            Console.WriteLine("Très bien, traitement en cours...\n");

            //Disp
            for (int i = 0; i < xfois; i++)
            {
                choix = chaineChoix[i];
                switch (choix)
                {
                    case "1g":
                        Console.Write("Méthode de Gauss, calendrier Grégorien : ");
                        MéthodeGaussienneGrégorien(year);
                        break;
                    case "1j":
                        Console.Write("Méthode de Gauss, calendrier Julien : ");
                        MéthodeGaussienneJulien(year);
                        break;
                    case "2g":
                        Console.Write("Méthode de Meeus, calendrier Grégorien : ");
                        MéthodeMeeusienneGrégorien(year);
                        break;
                    case "2j":
                        Console.Write("Méthode de Meeus, calendrier Julien : ");
                        MéthodeMeeusienneJulien(year);
                        break;
                    case "3g":
                        Console.Write("Méthode de Conway, calendrier Grégorien : ");
                        MéthodeConwayienneGrégorien(year);
                        break;
                    case "3j":
                        Console.Write("Méthode de Conway, calendrier Julien : ");
                        MéthodeConwayienneJulien(year);
                        break;

                    //Input error
                    default:
                        Console.WriteLine("Erreur de saisi, veuillez recommencer la procédure.");
                        break;
                }
            }           
        }      

        static void Main(string[] args)
        {
            //Set
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            //Clear temporisation
            Console.Write("\t\t    A la fin de chaque exécution d'un programme,\n\t  un compte à rebours s'affichera pour revenir au menu principal.\n  Saisissez la durée de ce compte à rebours en secondes (conseillé : 8) =>  ");
            int tempo = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            while (true)
            {
                //Disp
                Console.SetCursorPosition(30, 1);
                Console.WriteLine("Liste des programme :\n");
                Console.WriteLine("1 : Nombre de jours dans un mois en fonction de l'année");
                Console.WriteLine("2 : Date de Pâques pour une année donnée");
                Console.WriteLine("3 : Date de Pâques par le/les méthode(s)");                
                Console.WriteLine("4 : Date de Pâques pour la décennie");
                Console.WriteLine("5 : Autre fête mobile");
                Console.SetCursorPosition(65, 22);
                Console.WriteLine("Exit : enter");
                Console.Write("Entrez le numéro de votre choix => ");

                //Choice
                string choix = Convert.ToString(Console.ReadLine());
                Console.Clear();

                //Exit
                if (choix == "")
                {
                    break;
                }

                //Selector
                switch (choix)
                {
                    case "1":
                        Affichage_NombreDeJoursAnnee();
                        break;
                    case "2":
                        DateDePâquesAnnéeDonnée();
                        break;
                    case "3":
                        DatesDePâquesMultiples();
                        break;
                    case "4":
                        Décennie();
                        break;
                    case "5":
                        AffichageAutreFete();
                        break;

                    //Input error
                    default:
                        Console.WriteLine("\nErreur de saisi, veuillez recommencer la procédure.\n");
                        break;
                }

                //Warning clear
                Console.Write("\nNettoyage dans :");
                for (int i = tempo; i >= 0; i--)
                {
                    Console.Write(i + "...");
                    System.Threading.Thread.Sleep(1000);                   
                }
                //Clear
                Console.Clear();
            }           
        }//End static Main
    }//End class prog
}//End namespace
