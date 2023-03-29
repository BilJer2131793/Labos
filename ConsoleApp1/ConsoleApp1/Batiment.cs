using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace ConsoleApp1
{
    enum Statut
    {
        parfait, 
        reparation, 
        demoli
    }
    internal class Batiment
    {
        static int Count = 1;
        public int ID { get; set; }
        public Statut statut { get; set; }
        public int Resource { get; set; }
        public int Priorite { get; set; }
        public bool Actif { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public Batiment(Statut statut, int priorite, int x, int y, int resource = 50)
        {
            this.statut = statut;
            this.Resource = resource;
            this.Priorite = priorite;
            ID = Count;
            Count++;
            this.y = y;
            this.x = x; 
        }
        public Batiment(int ID)
        {
            this.ID = ID;
        }

        public override string ToString()
        {
            return $"{Priorite} {statut.Humanize()}";
        }

    }
}
