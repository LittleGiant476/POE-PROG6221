using System;
using System.Collections.Generic;
using System.Linq;

class Program
    
{
    // Class representing a Recipe
    class Recipe
    /*
     * Getters and setters are used to impliment this constructor
    */
    {


        public string recname { get; set; } // get,set to enter name of the recipe
        public int numIngre { get; set; } //get,set for the number of ingredients 
        public List<ingredient> ingredients { get; set; }// List the number of Ingreidents
        public int numSteps { get; set; } // List the steps in integers
        public List<string> steps { get; set; } // Stores the steps captured into a list

        public static List<Recipe> recipes = new List<Recipe>();

        public Recipe(string name) // The generic constructor with parameters for all recipes to consist of
        {
            recname = name;
            ingredients = new List<ingredient>();
            steps = new List<string>();
        }

        public static void EnterRecipe() // Method to be called to build the recipe
                                         // Also given the same name as methods from part 1 
        {

            Console.WriteLine("Enter the name of the recipe:");

            string recipeName = Console.ReadLine();
            Recipe newRecipe = new Recipe(recipeName); // A constructor accepting the given recipe name by the user

            // shows the number of ingreidents
            Console.WriteLine("Enter the number of ingredients you would like to add:");
            if(!int.TryParse(Console.ReadLine(), out int numIngre)) { // IOException handeling 

                Console.WriteLine("Invalid Input, Please insert a number");
                Main(null);
            }
            newRecipe.numIngre = numIngre; //int.Parse(Console.ReadLine());

            for (int i = 0; i < newRecipe.numIngre; i++) // begining of the for loop to input ingredients 
            {
                Console.WriteLine($"Please enter the name of ingredient {i + 1}:");
                string name = Console.ReadLine();

                Console.WriteLine($"Please enter the quantity of ingredient {i + 1}:");
                if (!double.TryParse(Console.ReadLine(), out double numIngre)) // IOException handeling 
                {

                    Console.WriteLine("Invalid Input, Please insert a number");
                    Main(null);
                }
                //double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Please enter the unit of ingredient {i + 1}:");
                string unit = Console.ReadLine();

                //double calories;

                Console.WriteLine($"Please enter the number of calories for ingredient {i + 1}:");
                if (!double.TryParse(Console.ReadLine(), out double calories)) // IOException handeling
                {

                    Console.WriteLine("Invalid Input, Please insert a number");
                    Main(null);
                }
                //double calories = double.Parse(Console.ReadLine());

                Console.WriteLine($"Please select the food group for ingredient {i + 1}:");
                DisplayFoodGroup(); // method called to view before selection 
                int foodGroupIndex = int.Parse(Console.ReadLine()) - 1;
                string foodGroup = AvailableFoodGroups[foodGroupIndex];

                // the big add to the major list of all the minor lists
                newRecipe.ingredients.Add(new ingredient { Name = name, Quantity = quantity, Unit = unit, Calories = calories, FoodGroup = foodGroup });
            } // Ending of the for loop for the ingredients 

            Console.WriteLine("Please enter the number of steps:");
            if (!int.TryParse(Console.ReadLine(), out int numSteps))
            { // IOException handeling 

                Console.WriteLine("Invalid Input, Please insert a number");
                Main(null);
            }
            newRecipe.numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < newRecipe.numSteps; i++) // beginning of the for loop for steps input
            {
                Console.WriteLine($"Please enter step {i + 1}:");
                string step = Console.ReadLine();
                newRecipe.steps.Add(step);
            } // ending of the for loop for the steps

            recipes.Add(newRecipe);


        }

        public static void DisplayRec()
        {

            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes found.");
            }
            else
            {
                recipes = recipes.OrderBy(r => r.recname).ToList();
                //OrderBy method stores the recipes in Alphabetical

                Console.WriteLine("Recipes:");
                for (int i = 0; i < recipes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipes[i].recname}");
                }

                Console.WriteLine("Enter the number of the recipe you want to view:");
                int recIndex = int.Parse(Console.ReadLine()) - 1;
                // if statement to calculate the calroies if its above 300

                if (recIndex >= 0 && recIndex < recipes.Count)
                {
                    Recipe selectedRecipe = recipes[recIndex];
                    selectedRecipe.PrintRecipe();
                    selectedRecipe.CalorieRange();
                }
                else
                {
                    Console.WriteLine("Invalid recipe number.");
                }
            }

        }
        public void PrintRecipe() // Method to print out the recipes added to the list when called upon by other functions
        {
            Console.WriteLine($"Recipe: {recname}");//output to ask the name of the recipe
            Console.WriteLine("Ingredients:");
            for (int i = 0; i <numIngre; i++) // A loop to print all ingridents 
            {
                Console.WriteLine($"{ingredients[i].Quantity} {ingredients[i].Unit} of {ingredients[i].Name} ({ingredients[i].FoodGroup})");
            }
            Console.WriteLine("Steps:");
            for (int i = 0; i < numSteps; i++) // A loop to print all the steps 
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }
        // calculates calrories for the recipe
        public double CalculateTotalCalories() // Method to calculate the calories when used in the recipe building function
        {
            double totalCalories = 0; // Setting the variable to 0 for no null error
            foreach (var ingredient in ingredients) // a foreach loop to run through the inputs and add up for calculation
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public void CalorieRange() // A prompt to display to the user the range of their calories as per their input 
        {
            double totalCalories = CalculateTotalCalories();
            Console.WriteLine($"Total Calories: {totalCalories}"); // Will show that the calories is a low amount 

            if (totalCalories < 100)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("This recipe is low in calories.");
                Console.ResetColor();
            }
            else if (totalCalories >= 100 && totalCalories <= 300) // will show that the calories are moderate amount in calroies
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("This recipe has a moderate amount of calories.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;  // shows a red colour when the user has
                Console.WriteLine("This recipe is high in calories.");
                Console.ResetColor();
            }
        }
    }

    // Ending of the Recipe Class

    //-----------------a Line to separate the Recipe Class from the Ingredient Class------------------------------+

    // Begining of the Ingredient class
    class ingredient
    {
        public string Name { get; set; } // get, set to get the recipe name
        public double Quantity { get; set; } // get, set to get the quanity
        public string Unit { get; set; } // get, set to get unit of measurment
        public double Calories { get; set; } // get, set to get the calories
        public string FoodGroup { get; set; } // get,set to add the food group its in
    }

    // Display available food group options
    private static readonly List<string> AvailableFoodGroups = new List<string> { "Fruits", "Vegetables", "Grains", "Proteins", "Dairy", "Fats and Oils" };


    public static void DisplayFoodGroup() // Displays the foog group through a loop when called in other functions for the user
    {
        Console.WriteLine("Available Food Groups:");
        for (int i = 0; i < AvailableFoodGroups.Count; i++) //The for loop to loop though the options 
                                                            // A possible foreach loop could of beed used here 
        {
            Console.WriteLine($"{i + 1}. {AvailableFoodGroups[i]}");
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------+
    //--------------------A Line to seperate the classes from the Main----------------------------------------------------------+
    //--------------------------------------------------------------------------------------------------------------------------+
    static void Main(string[] args)
    {

        while (true) // Updated while loop
        {
            
            Console.WriteLine("\n");
            Console.WriteLine("Please select a command : ");
            Console.WriteLine("1 --- Add Recipe");
            Console.WriteLine("2 --- View Recipes");
            Console.WriteLine("3 --- Exit" + "\n");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":

                    Program.Recipe.EnterRecipe();

                    break;

                case "2":

                    Program.Recipe.DisplayRec();

                    break;

                case "3":
                    Environment.Exit(0); // A forced Enviroment Exit if the option to exit is selected after an incorrect input
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid choice."); // If the input of the user for the main menu is not 1 - 3
                    break;
            }

            Console.WriteLine(); // In the event an extra line is needed to defferenciate between completed tasks
        }
    }
}

