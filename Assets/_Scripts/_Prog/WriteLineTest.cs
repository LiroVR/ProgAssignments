using System;
using System.Collections.Generic;

class WriteLineTest
{
    static void Main()
    {
        string catNoise = "Meow", dogNoise = "Woof";
        int carrotNum = 3, carrotCounter = 1, carrotOut = 0, gradeOutput = 9;
        for (int i = 0; i < 4; i++)
        {
            Console.Write("The cat says {0} and ", catNoise);
            Console.WriteLine("the dog says {0}", dogNoise);
            Console.WriteLine(2*i);
        }

        while (carrotOut <= 30)
        {
            Console.WriteLine("I have {0} carrots", carrotOut);
            carrotCounter += 1;
            carrotOut = (carrotNum * carrotCounter);
        }

        string[] animalNoises = {"Meow", "Woof", "Moo", "Oink", "Baa", "Quack", "Neigh", "Roar", "Bark", "Hiss"};

        foreach (string noise in animalNoises)
        {
            Console.WriteLine(noise);
        }
        //Console.Write("Enter your grade (0-10): ");
        //gradeOutput = Console.Read();
        switch(gradeOutput)
        {
            case 10:
                Console.WriteLine("A+");
                break;
            case 9:
                Console.WriteLine("A");
                break;
            case 8:
                Console.WriteLine("B");
                break;
            case 7:
                Console.WriteLine("B");
                break;
            case 6:
                Console.WriteLine("C");
                break;
            case 5:
                Console.WriteLine("E");
                break;
            default:
                Console.WriteLine("F");
                break;
        }
        
    }
        
}
