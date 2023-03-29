using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class Ville
    {
        public Batiment[] batiments { get; set; }
        Random rnd = new Random();

        public Ville(int numBatiment)
        {
            batiments = new Batiment[numBatiment];
            GenererListB(numBatiment);
        }

        public void TestGenererBatiments()
        {
            batiments[0] = new Batiment(Statut.demoli, 5,3,7);
            batiments[1] = new Batiment(Statut.reparation, 3,4,4);
            batiments[2] = new Batiment(Statut.demoli, 5,2,1);
            batiments[3] = new Batiment(Statut.reparation, 3,3,4);
            batiments[4] = new Batiment(Statut.parfait, 1,12,7);
        }

        public void GenererListB(int nombre)
        {
            for(int i = 0; i < nombre; i++)
            {
                batiments[i] = GenererB();


            }
        }
        public Batiment GenererB()
        {
            Statut statut = new Statut();
            int ressource;
            int prio;
            int x;
            int y;

            int i = randChiffre(1, 3);
            if (i == 1)
                statut = Statut.reparation;
            else
                statut = Statut.demoli;

            if(statut == Statut.reparation)
            {
                i = randChiffre(1, 3);
                if (i == 1)
                {
                    ressource = 0;
                    prio = randChiffre(2, 4);
                }
                else
                {
                    ressource = 50;
                    prio = randChiffre(3, 5);
                }

            }
            else
            {
                ressource = 50;
                prio = randChiffre(4, 6);
            }
            x = randChiffre(2, 21);
            y = randChiffre(2, 21);

            return new Batiment(statut, prio, x, y, ressource);

        }
        public int randChiffre(int min, int max)
        {
            int num = rnd.Next(min, max);
            return num;
        }

    }
}
