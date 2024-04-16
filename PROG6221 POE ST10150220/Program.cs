// See https://aka.ms/new-console-template for more information
using System.Numerics;

class Recipe
{
    public String RecipeName { get; set; }
    public Ingredient[] Ingredients { get; set; }
    public String[] Steps { get; set; }

    public Recipe (String recipeName, Ingredient[] ingredients, String[] steps)
    {
        RecipeName = recipeName;
        Ingredients = ingredients;
        Steps = steps;
    }
}

class Ingredient
{
    public String IngredientName { get; set; }
    public double Quantity { get; set; }
    public String Unit { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the recipe called?");
        string recipeName = Console.ReadLine();
        Console.WriteLine("How many Ingredients are there?");
        int numOfIngredients = int.Parse(Console.ReadLine());
        Ingredient[] ingredients = new Ingredient[numOfIngredients];

        for (int i = 0; i < numOfIngredients; i++)
        {
            Console.WriteLine($"Please enter the ingredient info. {i + 1}:");
            Console.WriteLine("Please Enter the Ingredient Name.");
            String ingredientName = Console.ReadLine();
            Console.WriteLine("Please Enter the quantity. (Just the number)");
            double quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Unit of Measurement");
            string unit = Console.ReadLine();
            ingredients[i] = new Ingredient { IngredientName = ingredientName, Quantity = quantity, Unit = unit };
        }

        Console.WriteLine("How many Steps are there?");
        int numOfSteps = int.Parse(Console.ReadLine());

        string[] steps = new string[numOfSteps];

        for (int i = 0; i < numOfSteps; i++)
        {
            Console.WriteLine($"Please enter the Step {i + 1}:");
            steps[i] = Console.ReadLine();
        }

        Recipe originalRecipe = new Recipe(recipeName, ingredients, steps);
        Recipe currentRecipe = new Recipe(recipeName, ingredients, steps);
        while (true)
        {
            Console.WriteLine($"Recipe Name: {currentRecipe.RecipeName}");
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < currentRecipe.Ingredients.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currentRecipe.Ingredients[i].Quantity} {currentRecipe.Ingredients[i].Unit} of {currentRecipe.Ingredients[i].IngredientName}");
            }

            Console.WriteLine("\n\nRecipe Steps");
            for (int i = 0; i < currentRecipe.Steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {currentRecipe.Steps[i]}");
            }
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1) x0.5 Quantity");
            Console.WriteLine("2) x2 Quantity");
            Console.WriteLine("3) x3 Quantity");
            Console.WriteLine("4) Reset Quantity");
            Console.WriteLine("5) Clear Recipe");
            Console.WriteLine("6) Exit");

            Console.Write("Select and Option: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ChangeQuantity(currentRecipe.Ingredients, 0.5);
                    break;
                case 2:
                    ChangeQuantity(currentRecipe.Ingredients, 2);
                    break;
                case 3:
                    ChangeQuantity(currentRecipe.Ingredients, 3);
                    break;
                case 4:
                    currentRecipe = new Recipe(originalRecipe.RecipeName, DeepCopy(originalRecipe.Ingredients), originalRecipe.Steps);
                    break;
                case 5:
                    ClearRecipe(currentRecipe);
                    break;
                case 6:
                    return;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;

            }
        }
    }

    static void ClearRecipe(Recipe currentRecipe)
    {
        currentRecipe.Ingredients = new Ingredient[0];
        currentRecipe.Steps = new string[0];
    }

    static void ChangeQuantity(Ingredient[] ingredients, double factor)
    {
        for (int i = 0; i < ingredients.Length; i++)
        {
            ingredients[i].Quantity *= factor;
        }
    }

    static Ingredient[] DeepCopy(Ingredient[] ingredients)
    {
        Ingredient[] copy = new Ingredient[ingredients.Length];
        for (int i = 0; i < ingredients.Length; i++)
        {
            copy[i] = new Ingredient { IngredientName = ingredients[i].IngredientName, Quantity = ingredients[i].Quantity, Unit = ingredients[i].Unit };
        }
        return copy;
    }

}
