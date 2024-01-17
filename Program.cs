using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Task coffeeTask = MakeCoffeeAsync();
        Task eggTask = FryEggsAsync(2);
        Task baconTask = FryBaconAsync(3);
        Task toastTask = ToastBreadAsync(2);

        var breakfastTasks = new List<Task> { coffeeTask, eggTask, baconTask, toastTask };

        while (breakfastTasks.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(breakfastTasks);
            if (finishedTask == coffeeTask)
            {
                Console.WriteLine("Café prêt !");
            }
            else if (finishedTask == eggTask)
            {
                Console.WriteLine("Œufs prêts !");
            }
            else if (finishedTask == baconTask)
            {
                Console.WriteLine("Bacon prêt !");
            }
            else if (finishedTask == toastTask)
            {
                Console.WriteLine("Pain grillé prêt !");
                await ApplyJamAsync(); // Appliquer la confiture une fois le pain grillé prêt
            }

            breakfastTasks.Remove(finishedTask);
        }

        await JuiceAsync(); // Verser le jus à la fin
        Console.WriteLine("Petit déjeuner prêt !");
        static async Task MakeCoffeeAsync()
    {
        Console.WriteLine("Faire le café");
        await Task.Delay(1000); // Simuler le temps de préparation du café
    }

    static async Task FryEggsAsync(int count)
    {
        Console.WriteLine($"Cuire {count} œufs");
        await Task.Delay(2000); // Simuler le temps de cuisson des œufs
    }

    static async Task FryBaconAsync(int slices)
    {
        Console.WriteLine($"Cuire {slices} tranches de bacon");
        await Task.Delay(3000); // Simuler le temps de cuisson du bacon
    }

    static async Task<string> ToastBreadAsync(int slices)
    {
        Console.WriteLine($"Griller {slices} tranches de pain");
        await Task.Delay(1500); // Simuler le temps de grillage
        return $"{slices} tranches de pain grillées";
    }

    static async Task ApplyJamAsync()
    {
        Console.WriteLine("Mettre de la confiture sur le pain");
        await Task.Delay(500); // Simuler le temps d'application de la confiture
    }

    static async Task  JuiceAsync()
    {
        Console.WriteLine("Verser du jus...");
        await Task.Delay(500); // Simuler le temps de verser du jus
    }
}

}