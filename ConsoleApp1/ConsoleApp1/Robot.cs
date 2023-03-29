using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Robot
    {
        Piece[] piece;
        List<Batiment> info;
        public int transport { get; set; }
        public int destruction { get; set; }
        public int construction { get; set; }
        public int vit { get; set; }
        public bool Actif { get; set; }
        public int Distance { get; set; }
        public int ID { get; set; }

        public Robot() { }
        public Robot(Piece piece1, Piece piece2, Piece piece3)
        {
            piece = new Piece[3];
            piece[0] = piece1;
            piece[1] = piece2;
            piece[2] = piece3;
            Actif = false;
            SetStats();
        }
        public Robot(Piece piece1, Piece piece2, Piece piece3, List<Batiment> list)
        {
            piece = new Piece[3];
            piece[0] = piece1;
            piece[1] = piece2;
            piece[2] = piece3;
            info = list;
            Actif = false;
            SetStats();
        }
        public void SetStats()
        {
            foreach(Piece p in piece)
            {
                if (p is Construction)
                    construction += 1;
                if (p is Destruction)
                    destruction += 1;
                if (p is Transport)
                    transport += 1;
                if (p is Vitesse)
                    vit += 1;
            }
        }
        public void EvaluerVille(Ville ville)
        {
            foreach(Batiment b in ville.batiments)
            {
                EvaluerBatiment(b);
            }
        }

        public void EvaluerBatiment(Batiment batiment)
        {
            info.Add(batiment);
        }
        public int DonneLongeurListe()
        {
            return info.Count;
        }
        public Batiment[] remettreInfo()
        {
            info.Sort((x, y) => y.Priorite.CompareTo(x.Priorite));
            int c = info.Count;

            Batiment[] tableB = new Batiment[c];
            int i = 0;
            foreach (Batiment b in info)
            {
                tableB[i] = b;
                i++;
            }
            info.Clear();
            return tableB;
        }

        public Batiment DemolirBatiment(Batiment b)
        {
            b.Priorite -= 1;
            b.statut -= 1;
            return b;
        }

        public Batiment EnvoyerRessource(Batiment b)
        {
            b.Resource -= 50;
            return b;
        }

        public Batiment ReparerBatiment(Batiment b)
        {
            b.Priorite = 1;
            b.statut -= 1;
            return b;
        }
    }
}
