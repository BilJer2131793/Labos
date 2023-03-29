using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalNamespace;
using ChatNamespace;
using ChienNamespace;


namespace AmitieNamespace
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Chien doggy = new Chien("doggy");
            Chien dog = new Chien("dog");
            Chat cat = new Chat("cat");


            dog.MeilleurAmi = "Cat";
            cat.MeilleurAmi = "Dog";
            doggy.Humeur = false;
            dog.MeilleurAmi = "Doggy";
            doggy.MeilleurAmi = "Dog";
            dog.Humeur = true;

            Console.WriteLine(dog);
            Console.WriteLine(doggy);
            Console.WriteLine(cat);

        }
    }
}
