using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatNamespace;
using ChienNamespace;

namespace AnimalNamespace
{
    internal class Animal
    {
        public string Nom { get; set; }
        public string MeilleurAmi { get; set; }
        public bool Humeur { get; set; }

        public Animal(string nom, bool humeur)
        {
            Nom = nom;
            Humeur = humeur;
        }

        public override string ToString()
        {
            return $"{Nom} a {MeilleurAmi} comme meilleur Ami et est {traduitHumeur(Humeur)}";
        }
        public string traduitHumeur(bool Humeur)
        {
            if (Humeur)
                return "heureux";
            else
                return "pas heureux";
        }

    }
}
