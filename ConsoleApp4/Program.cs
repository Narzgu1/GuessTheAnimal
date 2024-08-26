using System;
using System.Collections.Generic;

struct Animal
{
    public string name;
    public string question;
}

class Program
{
    static Animal CreateAnimal(string name, string question)
    {
        Animal animal;
        animal.name = name;
        animal.question = question;
        return animal;
    }

    static void ShuffleQuestions(List<Animal> animals)
    {
        Random rand = new Random();
        int n = animals.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            Animal value = animals[k];
            animals[k] = animals[n];
            animals[n] = value;
        }
    }

    static void PrintQuestion(string question)
    {
        Console.Write(question + " (відповідь 'т' або 'н'): ");
    }

    static void ClassifyAnimal(List<Animal> animals)
    {
        Console.WriteLine("Введіть характеристики тварини:");

        List<string> characteristics = new List<string>();
        foreach (Animal animal in animals)
        {
            string characteristic;
            PrintQuestion(animal.question);
            characteristic = Console.ReadLine().ToLower();
            characteristics.Add(characteristic);
        }

        foreach (Animal animal in animals)
        {
            bool match = true;
            for (int i = 0; i < characteristics.Count; ++i)
            {
                if (char.ToLower(animal.question[i]) == 'т' && characteristics[i] != "т")
                {
                    match = false;
                    break;
                }
                if (char.ToLower(animal.question[i]) == 'н' && characteristics[i] != "н")
                {
                    match = false;
                    break;
                }
            }
            if (match)
            {
                Console.WriteLine("Тварина: " + animal.name);
                return;
            }
        }

        Console.WriteLine("Не вдалося вгадати тварину.");
    }

    static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(CreateAnimal("кіт", "Це тварина має вуса?"));
        animals.Add(CreateAnimal("собака", "Ця тварина лається?"));
        animals.Add(CreateAnimal("миша", "Ця тварина маленька?"));

        ShuffleQuestions(animals);

        Console.WriteLine("Виберіть режим роботи:");
        Console.WriteLine("1. Вгадати тварину");
        Console.WriteLine("2. Класифікувати тварину");
        Console.Write("Ваш вибір: ");
        int mode = int.Parse(Console.ReadLine());

        if (mode == 1)
        {
            // Запуск експертної системи для вгадування тварини
            GuessAnimal(animals);
        }
        else if (mode == 2)
        {
            // Виконання класифікації тварини на основі введених характеристик
            ClassifyAnimal(animals);
        }
        else
        {
            Console.WriteLine("Невірний вибір режиму роботи.");
        }
    }

    private static void GuessAnimal(List<Animal> animals)
    {
        throw new NotImplementedException();
    }
}
