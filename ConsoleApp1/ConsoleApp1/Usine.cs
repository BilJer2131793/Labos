using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ConsoleApp1
{
    internal class Usine
    {
        Batiment[] tabB;
        List<Robot> listR;


        public Usine()
        {
            listR = new List<Robot>();
        }
        public void EnvoyerPremierRobot(Ville ville)
        {
            listR[0].EvaluerVille(ville);
            int n = listR[0].DonneLongeurListe();
            tabB = new Batiment[n];
            tabB = listR[0].remettreInfo();
        }


        public Robot CreeRobot(Transport piece)
        {
            Console.WriteLine("Creation d'un robot de Transport");
            return new Robot(piece, new Vitesse(), new Vitesse());
        }
        public Robot CreeRobot(Construction piece)
        {
            Console.WriteLine("Creation d'un robot de Construction");
            return new Robot(piece, new Vitesse(), new Vitesse());
        }
        public Robot CreeRobot(Destruction piece)
        {
            Console.WriteLine("Creation d'un robot de Destruction");
            return new Robot(piece, new Vitesse(), new Vitesse());
        }
        public Robot CreeRobot()
        {
            return new Robot(new Vitesse(), new Vitesse(), new Vitesse(), new List<Batiment>());
        }
        //robot lent
        //public Robot CreeRobot(Transport piece)
        //{
        //    Console.WriteLine("Creation d'un robot de Transport");
        //    return new Robot(piece, piece, new Vitesse());
        //}
        //public Robot CreeRobot(Construction piece)
        //{
        //    Console.WriteLine("Creation d'un robot de Construction");
        //    return new Robot(piece, piece, new Vitesse());
        //}
        //public Robot CreeRobot(Destruction piece)
        //{
        //    Console.WriteLine("Creation d'un robot de Destruction");
        //    return new Robot(piece, piece, new Vitesse());
        //}

    }
}
