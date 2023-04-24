using System;

namespace RecipeBuilder
{
    class Recipe
    {
        private string recname;
        private int numIngredients;
        private string[] ingredients;
        private int[] quantities;
        private int[] originalQuantities;
        private string[] units;
        private int numSteps;
        private string[] steps;

        public Recipe()
        {
            // Default constructor
        }
        public void EnterRecipe()
        {
            Console.WriteLine("Enter recipe name:");
            recname = Console.ReadLine();
            Console.WriteLine("Enter number of ingredients:");
            numIngredients = Convert.ToInt32(Console.ReadLine());

            ingredients = new string[numIngredients];
            quantities = new int[numIngredients];
            originalQuantities = new int[numIngredients];
            units = new string[numIngredients];

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("\nIngredient " + (i + 1) );
                Console.Write("\nEnter name of ingredient" + (i + 1) + " - ");
                ingredients[i] = Console.ReadLine();
                Console.Write("Enter quantity of ingredient" + (i + 1) + " - ");
                quantities[i] = Convert.ToInt32(Console.ReadLine());
                originalQuantities[i] = quantities[i];
                Console.Write("Enter unit of measurement for ingredient" + (i + 1) + " - ");
                units[i] = Console.ReadLine();
            }

            Console.WriteLine("\nEnter number of steps - ");
            numSteps = int.Parse(Console.ReadLine());
            steps = new string[numSteps];

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Enter description of step number " + (i + 1) );
                steps[i] = Console.ReadLine();
            }
            DisplayRecipe();
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nYour Recipe ");
            Console.Write("\nRecipe Name : " + recname + "\n");
            Console.WriteLine("\nIngredients required for the recipe:");
            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("\n" + quantities[i] + " " + units[i] + " of " + ingredients[i]);
            }
            Console.WriteLine("\nteps for the recipe");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("\nstep number " + (i + 1) + " - " + steps[i]);
            }
            Console.WriteLine("\n");
        }

        public void ScaleRecipe(int factor)
        {
            switch(factor)
            {
                case 1:

                for (int i = 0; i < numIngredients; i++)
            {
                quantities[i] = (quantities[i] / 2);
            }
            DisplayRecipe();
                break;

                case 2:
                 for (int i = 0; i < numIngredients; i++)
            {
                quantities[i] = (quantities[i] * 2);
            }
            DisplayRecipe();
                break;

                case 3:
                 for (int i = 0; i < numIngredients; i++)
            {
                quantities[i] = (quantities[i] * 3);
            }
            DisplayRecipe();
                break;
            }
        }

        public void ResetQuantities()
        {
            // Reset quantities to their original values
            for (int i = 0; i < numIngredients; i++)
            {
                quantities[i] = originalQuantities[i];
            }

            Console.WriteLine("Your recipe Quantities have been reset \n");
            DisplayRecipe();
        }
        public void ClearRecipe()
        {
            // Clear all recipe data
            numIngredients = 0;
            Array.Clear(ingredients);
            Array.Clear(units);
            numSteps = 0;
            Array.Clear(steps);
            Array.Clear(quantities);

            Console.WriteLine("All inputs of the recipe are clear");
        }

    class Program
    {
        public static int choice;
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            while ( choice < 6)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter recipe details");
                Console.WriteLine("2. Display recipe");
                Console.WriteLine("3. Scale recipe");
                Console.WriteLine("4. Reset quantities");
                Console.WriteLine("5. Clear recipe");
                Console.WriteLine("6. Exit");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        recipe.EnterRecipe();
                        break;
                    case 2:
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        Console.WriteLine("Enter scaling - 0ption 1 -- 0.5",
                        "\noption 2 -- 2",
                        "\noption 3 -- 3");
                        int factor;
                        factor = Convert.ToInt32(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                        break;
                    case 4:
                        recipe.ResetQuantities();
                        break;
                    case 5:
                        recipe.ClearRecipe();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the app");
                        Console.ReadKey();
                        break;
                        default:
                        Console.WriteLine("Exiting the app");
                        Console.ReadKey();
                        break;

                }
            }
        }
    }
}
}