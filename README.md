# RecipeApp
# Part2
-- Description --
An Application to build, store and manipulate recipes by their individual ingredients
An infinite amount of recipes can be made and stored within the list with any amount of ingredients specified by the user while in runtime.
At a later date recipes can be altered after storing as well as be modified and cleared from memory 
If code is launched and a "build" error occurs select the option to compile and run anyway 

-- The Requirements for the application --

A 32 bit machine with a minimum of 8GB of RAM 
An adequate processor to handle at a minimum of 3 threads at any given time as well as a base hurtz of 2.0 -> 3 threads can still withstand the WinForms implimented in part 3 
Anything under these minimum specifications will lead to the program not running due to inefficiency or the crashing of the IDE

It is also required for an appropriate IDE to have a solid enviroment where the code can run while also being able to pick up any runtime errors

-- Differences from the Part 1 to the functioning Part 2 --

Exception handling has been implimented where ever the user is prompted to enter any input that is not of type string or specified entry. Whenever the user is asked to input a number the error message will pop up to show that a number should be input
and in regards to the menu the input can only be "1" "2" or "3" any other input will result in an invalid input
Switching the array and looping variables to a list and adding foreach loops to accommodate. It is required of us to make use of generic collections to store what is essentially an indefinite amount of variables in the lists to store in turn a possible infinite amount of recipes 
Improving the structure of the code by better structure and a substantially larger amount of comments. The added comments partnered with the improved structure of the code leads to cleaner and better to understand code.
The code being easy to understand was an aspect of the POE I skipped out on in the first part and now with better understanding of the task at hand that reflects on my programming

-- Differences from the Part 2 to  Part 3 --

Although the application runs, there are still too many pitfalls from the back end for the application to run nearly at all. I do still beleive that my logic is sound as I maintained good coding etiquet and no syntaxual errors are present. 
I have implimented 2 features from the first part of the POE being the clear function and scaling option. Although it was not necessary it is, in my opinion, features needed for a more developed application. The clear function clears all lists inside of it as intended and the scaling option scales the Quantity list as specified in the code
A more user friendly design is implimented as with the additional help of WinForms a better GUI was constructed to be more visually appealing and functionally sound for both the front and a minority of the back end.
I have kept the Lists for all the values as that has proven to be more useful to me in this part than converting back to arrays and using non-generic collections.
