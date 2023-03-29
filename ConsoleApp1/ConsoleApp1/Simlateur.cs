using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ConsoleApp1
{
    internal class Simlateur
    {

        Batiment[] tabB;
        List<Robot> listR;
        Ville ville;
        Usine usine;
        int tour;
        int NumPriorite;

        public void StartSimulation()
        {
            tour = 1;
            listR = new List<Robot>();
            bool fini = false;
            usine = new Usine();
            ville = new Ville(100);
            NumPriorite = 5;

            EnvoyerPremierRobot();
            //CreationDesRobots();
            while (!fini)
            {
                Console.WriteLine("Tour" + tour);
                ChoixAction();
                AvancementTour();
                if (NumPriorite == 1 && !CheckFini())
                {
                    Console.WriteLine("fini");
                    fini = true;
                }
                tour++;
            }
            Console.WriteLine($"Il y avais {tabB.Length} batiment dans la ville.");
            Console.WriteLine("Robot".ToQuantity(listR.Count())+" on ete construit");
            Console.WriteLine("La ville a ete reconstruite en "+tour+ " tours");
            Console.ReadLine();
        }
        public void AvancementTour()
        {
            for (int i = 0; i < listR.Count; i++)
            {
                if (listR[i].Actif)
                {
                    listR[i].Distance -= listR[i].vit;
                    if (listR[i].Distance <= 0)
                    {
                        FiniTache(i);
                    }
                }
            }

        }
        public void FiniTache(int i)
        {
            int ID = listR[i].ID;
            listR[i].Actif = false;
            int x = TrouverBatiment(ID);
            tabB[x].Priorite -= 1;
            tabB[x].Actif = false;
            if(tabB[x].statut == Statut.demoli)
            {
                tabB[x].statut = Statut.reparation;
                Console.WriteLine("Un batiment a ete demoli");
            }
            else if (tabB[x].statut == Statut.reparation && tabB[x].Resource > 0)
            {
                Console.WriteLine("Des ressources ont ete envoyer a un batiment");
                tabB[x].Resource = 0;
            }
            else
            {
                Console.WriteLine("Un batiment est maintenant en parfaite etat");
                tabB[x].statut = Statut.parfait;
            }

        }
        public int TrouverBatiment(int ID)
        {
            int id = 0;
            bool trouve = false;
            for(int i = 0; !trouve; i++)
            {
                if(tabB[i].ID == ID)
                {
                    id = i;
                    trouve = true;
                }
            }
            return id;
        }
        public bool CheckFini()
        {
            for(int i = 0; i < tabB.Length; i++)
            {
                if (tabB[i].Actif)
                    return true;
            }
            return false;
        }
        public bool CheckFiniPrio()
        {
            for (int i = 0; i < tabB.Length; i++)
            {
                if (tabB[i].Priorite == NumPriorite)
                    return false;
            }
            return true;
        }
        public void EnvoyerPremierRobot()
        {
            listR.Add(usine.CreeRobot());
            listR[0].EvaluerVille(ville);
            int n = listR[0].DonneLongeurListe();
            tabB = new Batiment[n];
            tabB = listR[0].remettreInfo();
        }
        public void CreationDesRobots()//reverifier
        {
            int cmptR = 0;
            int cmptD = 0;
            int cmptM = 0;
            foreach (Batiment b in tabB)
            {
                if (b.statut.Humanize() == Statut.reparation.Humanize())
                {
                    cmptR += 1;
                    cmptM += b.Resource;
                }
                if (b.statut == Statut.demoli)
                {
                    cmptD += 1;
                    cmptM += b.Resource;
                }
            }
            if (cmptR / 2 > 1)
                cmptR /= 2;
            if (cmptD / 2 > 1)
                cmptD /= 2;

            for (int i = 0; i < cmptR; i++)
            {
                usine.CreeRobot(new Construction());
            }
            for (int i = 0; i < cmptD; i++)
            {
                usine.CreeRobot(new Destruction());
            }
            for (int i = 0; i < cmptM / 50; i++)
            {
                usine.CreeRobot(new Transport());
            }

        }
        public void ChoixAction()
        {
            bool fini = false;
            for (int i = 0; i < tabB.Length && !fini; i++)
            {
                if (tabB[i].Priorite == NumPriorite && !tabB[i].Actif)
                {
                    ActionBatiment(i);
                    fini = true;
                }
            }
            if (CheckFiniPrio())
                NumPriorite -= 1;
        }

        public void ActionBatiment(int i)
        {
            int r = 0;
            if (tabB[i].statut == Statut.demoli)
            {
                r = TrouverRobot(new Destruction());
                EnvoyerRobot(r, i);
            }
            else if (tabB[i].Resource > 0)
            {
                r = TrouverRobot(new Transport());
                EnvoyerRobot(r,i);
            }
            else if (tabB[i].statut == Statut.reparation)
            {
                r = TrouverRobot(new Transport());
                EnvoyerRobot(r, i);
                tabB[i].Resource = 0;
            }
            else if (tabB[i].statut == Statut.parfait)
            {
                tabB[i].Priorite = 1;
                CheckFiniPrio();
            }
            else
            {
                Console.WriteLine("Aucune action disponible");
                CheckFiniPrio();
            }

        }
        public void EnvoyerRobot(int r, int b)
        {
            tabB[b].Actif = true;
            listR[r].Actif = true;
            listR[r].Distance = (int)Math.Sqrt(Math.Pow(tabB[b].x, 2) + Math.Pow(tabB[b].y, 2));
            listR[r].ID = tabB[b].ID;
        }
        public int TrouverRobot(Construction p)
        {
            Console.WriteLine("Un Robot de Construction a ete envoyer");
            for (int i = 0; i < listR.Count; i++)
            {
                if (listR[i].construction > 0 && !listR[i].Actif)
                {
                    return i;
                }
            }
            listR.Add(usine.CreeRobot(new Construction()));
            return listR.Count() - 1;  
        }
        public int TrouverRobot(Destruction p)
        {
            Console.WriteLine("Un Robot de Destruction a ete envoyer");
            for (int i = 0; i < listR.Count; i++)
            {
                if (listR[i].destruction > 0 && !listR[i].Actif)
                {
                    return i;
                }
            }
            listR.Add(usine.CreeRobot(new Destruction()));
            return listR.Count() - 1;
        }
        public int TrouverRobot(Transport p)
        {
            Console.WriteLine("Un Robot de Transport a ete envoyer");
            for (int i = 0; i < listR.Count; i++)
            {
                if (listR[i].transport > 0 && !listR[i].Actif)
                {
                    return i;
                }
            }
            listR.Add(usine.CreeRobot(new Transport()));
            return listR.Count() - 1;
        }
    }
}
