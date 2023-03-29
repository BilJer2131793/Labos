using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalNamespace;

namespace ChatNamespace
{
    class Chat : Animal
    {

        public Chat(string nom, bool humeur = true) : base (nom, humeur)
        {

        }

    }
}
