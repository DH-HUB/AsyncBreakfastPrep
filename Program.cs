using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Task coffeeTask = MakeCoffeeAsync();
        Task eggTask = FryEggsAsync(2);
        Task baconTask = FryBaconAsync(3);
        Task toastTask = ToastBreadAsync(2);

        // Attendre que le café soit prêt
        await coffeeTask;

        // Attendre que les œufs soient prêts
        await eggTask;

        // Attendre que le bacon soit prêt
        await baconTask;

        // Attendre que le pain soit grillé
        await toastTask;

        // Mettre de la confiture sur le pain grillé
        await ApplyJamAsync();

        // Préparer le jus
        await JuiceAsync();

        Console.WriteLine("Petit déjeuner prêt !");
    }

    static async Task MakeCoffeeAsync()
    {
        Console.WriteLine("Faire le café...");
        await Task.Delay(1000); // Simuler le temps de préparation du café
        Console.WriteLine("Café prêt !");
    }

    static async Task FryEggsAsync(int count)
    {
        Console.WriteLine($"Cuire {count} œufs...");
        await Task.Delay(2000); // Simuler le temps de cuisson des œufs
        Console.WriteLine($"{count} œufs prêts !");
    }

    static async Task FryBaconAsync(int slices)
    {
        Console.WriteLine($"Cuire {slices} tranches de bacon...");
        await Task.Delay(3000); // Simuler le temps de cuisson du bacon
        Console.WriteLine($"{slices} tranches de bacon prêtes !");
    }

    static async Task<string> ToastBreadAsync(int slices)
    {
        Console.WriteLine($"Griller {slices} tranches de pain...");
        await Task.Delay(1500); // Simuler le temps de grillage
        Console.WriteLine($"{slices} tranches de pain grillées !");
        return $"{slices} tranches de pain grillées";
    }

    static async Task ApplyJamAsync()
    {
        Console.WriteLine("Mettre de la confiture sur le pain...");
        await Task.Delay(500); // Simuler le temps d'application de la confiture
        Console.WriteLine("Confiture appliquée !");
    }

    static async Task JuiceAsync()
    {
        Console.WriteLine("Verser du jus...");
        await Task.Delay(500); // Simuler le temps de verser du jus
        Console.WriteLine("Jus versé !");
    }
}
