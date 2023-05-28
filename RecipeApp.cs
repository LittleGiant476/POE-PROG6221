using System;

namespace RecipeBuilder
{
    class Recipe
    {
        private string recname; // Recipe Name 
        private int numIngre; // Number of Ingredients 
        private string[] ingredients; // Array for Ingredients 
        private int[] quant; // Array For quantity of Ingredients 
        private int[] originalquant; // Array for orriginal Quantity to reset
        private string[] units; // Array for Units of Ingredients 
        private int numSteps; // Number of Steps
        private string[] steps; // Array to store Steps

        public Recipe()
        {
            // Default constructor
        }
        public void EnterRecipe()
        {
            Console.WriteLine("Enter recipe name:");
            recname = Console.ReadLine();
            Console.WriteLine("Enter number of ingredients:");
            numIngre = Convert.ToInt32(Console.ReadLine());

            ingredients = new string[numIngre];
            quant = new int[numIngre];
            originalquant = new int[numIngre];
            units = new string[numIngre];

            for (int i = 0; i < numIngre; i++)
            {
                Console.WriteLine("\nIngredient " + (i + 1) );
                Console.Write("\nEnter name of ingredient" + (i + 1) + " - ");
                ingredients[i] = Console.ReadLine();
                Console.Write("Enter quantity of ingredient" + (i + 1) + " - ");
                quant[i] = Convert.ToInt32(Console.ReadLine());
                originalquant[i] = quant[i];
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
            DisplayRec();
        }

        public void DisplayRec()
        {
            Console.WriteLine("\nYour Recipe ");
            Console.Write("\nRecipe Name : " + recname + "\n");
            Console.WriteLine("\nIngredients required for the recipe:");
            for (int i = 0; i < numIngre; i++)
            {
                Console.WriteLine("\n" + quant[i] + " " + units[i] + " of " + ingredients[i]);
            }
            Console.WriteLine("\nteps for the recipe");
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("\nstep number " + (i + 1) + " - " + steps[i]);
            }
            Console.WriteLine("\n");
        }

        public void ScaleRecipe(int scaler)
        {
            switch(scaler)
            {
                case 1:

                for (int i = 0; i < numIngre; i++)
            {
                quant[i] = (quant[i] / 2);
            }
            DisplayRec();
                break;

                case 2:
                 for (int i = 0; i < numIngre; i++)
            {
                quant[i] = (quant[i] * 2);
            }
            DisplayRec();
                break;

                case 3:
                 for (int i = 0; i < numIngre; i++)
            {
                quant[i] = (quant[i] * 3);
            }
            DisplayRec();
                break;
            }
        }

        public void ResetQuant()
        {
            // Reset quantities to their original values
            for (int i = 0; i < numIngre; i++)
            {
                quant[i] = originalquant[i];
            }

            Console.WriteLine("Your recipe Quantities have been reset \n");
            DisplayRec();
        }
        public void ClearRecipe()
        {
            // Clear all recipe data
            numIngre = 0;
            Array.Clear(ingredients);
            Array.Clear(units);
            numSteps = 0;
            Array.Clear(steps);
            Array.Clear(quant);

            Console.WriteLine("All inputs of the recipe are clear");
            Console.WriteLine("You will now be directed to enter a new recipe \n");

            EnterRecipe();
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
                        Console.ReadKey();
                        break;
                    case 2:
                        recipe.DisplayRec();
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Enter scaling - 0ption 1 -- factor by 0.5 or half your recipe",
                        "\noption 2 -- factor by 2 or double your recipe",
                        "\noption 3 -- factor by 3 or triple your recipe");
                        int scaler;
                        scaler = Convert.ToInt32(Console.ReadLine());
                        recipe.ScaleRecipe(scaler);
                        Console.ReadKey();
                        break;
                    case 4:
                        recipe.ResetQuant();
                        Console.ReadKey();
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