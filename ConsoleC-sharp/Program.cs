using System;
using System.Collections.Generic;
using ConsoleC_sharp;

namespace ConsoleC_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=KRAFTREPORT;Initial Catalog=PocketMonster;User ID=sa;Password=sa@123";
            DababaseConnection databaseConnection = new DababaseConnection(connectionString);
            PoketMonsterRepository repository = new PoketMonsterRepository(databaseConnection);

            bool keepRunning = true;

            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine("Pokemon CRUD Operations");
                Console.WriteLine("1. Create Pokemon");
                Console.WriteLine("2. Read Pokemons");
                Console.WriteLine("3. Update Pokemon");
                Console.WriteLine("4. Delete Pokemon");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreatePokemon(repository);
                        break;
                    case "2":
                        ReadPokemons(repository);
                        break;
                    case "3":
                        UpdatePokemon(repository);
                        break;
                    case "4":
                        DeletePokemon(repository);
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (keepRunning)
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void CreatePokemon(PoketMonsterRepository repository)
        {
            Console.Write("Enter Pokemon Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Pokemon Type: ");
            string type = Console.ReadLine();

            PocketMonster pokemon = new PocketMonster
            {
                Name = name,
                Type = type
            };

            repository.CreatePocketMonster(pokemon);
        }

        static void ReadPokemons(PoketMonsterRepository repository)
        {
            List<PocketMonster> pokemons = repository.GetPocketMonsterList();

            Console.WriteLine("Id\tName\tType");
            foreach (var pokemon in pokemons)
            {
                Console.WriteLine($"{pokemon.Id}\t{pokemon.Name}\t{pokemon.Type}");
            }
        }




        static void UpdatePokemon(PoketMonsterRepository repository)
        {
            Console.Write("Enter Pokemon Id to Update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Pokemon Name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter New Pokemon Type: ");
            string newType = Console.ReadLine();

            PocketMonster pokemon = new PocketMonster
            {
                Id = id,
                Name = newName,
                Type = newType
            };

            repository.UpdatePocketMonster(pokemon);
        }



        static void DeletePokemon(PoketMonsterRepository repository)
        {
            Console.Write("Enter Pokemon Id to Delete: ");
            int id = int.Parse(Console.ReadLine());
            repository.DeletePocketMonster(id);
        }
    }
}















