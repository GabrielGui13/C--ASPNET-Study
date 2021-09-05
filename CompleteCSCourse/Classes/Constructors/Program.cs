using System;

namespace Constructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Human gabriel = new Human("Gabriel", "Guilherme", "brown", 19);
            gabriel.IntroduceMyself();

            Human guilherme = new Human("Luiz", "Guilherme", "brown");
            guilherme.IntroduceMyself();

            Human john = new Human("John", "Doe");
            john.IntroduceMyself();
        }
    }
}
