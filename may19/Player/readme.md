## Player model
This program implements a `IPlayerModel` interface, which accepts a Name and a `Regex`-approved Email Address.  It also affords the programmer the option to define custom task functions to be assigned to the `PlayerModel`'s `Task` delegate.

Users can interactively add players, display existing player information, and invoke player tasks.  Users are not able to define or assign custom tasks, because those must be created by the programmer.

`PlayerModel` is now an abstract class, of which there are two implementations:
 - `Player`, which can take an arbitrary email address (pending validation)
   - This type can be edited by the user at any time
   - This type is serializable to JSON and can be loaded by the program.  Loading a Player object from JSON who has the same Id as a Player in memory will overwrite the Name and Email properties of the runtime object.
 - `Robot`, which derives its email address from combining its name with its GUID
   - This type is immutable and cannot be edited by the user
