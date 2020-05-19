using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class main
{

    // Main Method 
    static public void Main(String[] args)
    {
        string name;
        Console.WriteLine("Your name?");
        name = Console.ReadLine();

        Hero player = new Hero(name, 10, 1);
        Room r = new Room();

        bool live = true;

        int level = 1;
        while (level != 11 && player.getHp() > 0) {
            Console.WriteLine("#####################Current level: " + level);

            if (player.getHp() <= 0) {
                Console.WriteLine("YOU LOST");
                break;
            }
            Random rnd = new Random();
            int count = rnd.Next(1, 5);
            live = r.figthingSystem(count, player);
            if (live == false) {
                Console.WriteLine("YOU LOST");
                break;
            }

            level++;
        }
        if (live == true)
        {
            Console.WriteLine("YOU WON GG " + name);
        }

        string stop;
        stop = Console.ReadLine();
    }
}

