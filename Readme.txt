The MasterMind Project structure.

1. Board:

This is the Parent of all. Everithing derives from here.
This implements the Random generator abstract class.
This has the constant variables. These you can get and set. ( except raws, columns those are only get properties).
Other classes wont have public variables, so we can configure everithing from here. ==> in the later part of the development a 
configuration file for the constatnts should be considered.


1.2 Pin class:
All the Pin types derives from this.
This is a derived class from the Board.
The pin has a few properties: color, shape.

IMPORTANT!!! All the pins will be Pin tpyed and instatiated to GuessPin and HintPin ==> THIS IS EXPLICIT CASTING.
This is done so because this way you can cast back to Parent if you want to delete the Color you have imputed. The parent will only have the empty color.
So ==> you have to overwrite the Color conversion method in the child classes. So if you casst back to parent the original Converter method will be called.


2.GuessingPin:


It implements the Guess Color Enum. ==> Or the Color converter interface 
A pin cannot be created without the shape getting a color ==> Constructor statement.

3. Guess Color Enum:

This contains the possibel colors in the game.
All the color variables are Pin type varibles. Thus automatically these will have the same properties.



4. Color Converter abstract class ==> not interface because of the overload:

This converts the Color Enum Pin vars. based on the color name. Sets the shape color of an individual pin.
You will probably have to overload the color converters method based on the input ==> It will convert the input string and the Enum Property as well.


6. HintPin:

Different type from the guess pin. But converted with the Color COnverter too.
Implements the hint color enum.

5. Hint Color Enum:

Contains only black and white.




7. The Business Logic classes:

    7.1 Solution class:
        Implements the Random generator abstract class / INterface
        It has one function that grabs the random generated Enum value calls the Converter class, converts it into a Pin type and stores it in a List.
        Make it a static class so the created List would be constatnt and only for the solution classes.
        THe method returns a List of Pins so somehow you have to add Pins in there. ==> Instatiate with a for cycle as much Pins as Columns there are.
        In the instatiation because the Pin constructor requires Color call the Random generator abstract's instance.

    7.1.2 Random Generator:
        Takes the PInColor Enum-s and generates a List of solutions. The Pin count is dependent on column amount.

    7.2 Guess class.
        Derives from the Board.
        Implements:
            -   the Input cleaner interface;
            -   the Color converter abstract class; 

        Has A List<Pin> property and a List<String> property. In the set method you clean up the input. ==> the input is the starting character of the colors.
        On every input this is called. The app goes through the List of strings, calls the input cleaner interface on the List elements and the returned
        - cleaned up string will be passed to the Color converter.
        The Converter returns a Pin instance of the associated color, that instance will load into the List<Pin> and passed to the Display class.

    7.3 Checker class:
        Compares the Solution and the Guess List<Pin> and returns a List<Pin> of hints based on the result.
        That List<Pin> will get passed to the Display class.
        On default the checker class will compare the solution and the guess List but at the autosolver implementation it may change so write it as generic
        as possible.
        Generic: compares two List of Pins and returns a result List of Hints. The autosolver can work from there.


8. Display class: 

Handles the drwaing of the Lists and it's components. 
Generally it will want to Lists to draw out in on line with a bunch of pritty ASCII characters in between each element.
It will do NO LOGIC ==> in the future it will be replaced with the UI
It listens to input too ==> if the input is maybe an 'H'/'h' than it will draw out the rules again.
Also handles the Errors and Exception drawings.


9. Input cleaner interface.

Cleans the input of any weird character, makes the valueable ones UPPERCASE and throws back the string.







    














