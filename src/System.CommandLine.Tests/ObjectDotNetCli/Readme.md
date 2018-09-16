# ToDo
* If Invoke is not implemented explicitly (not via inheritance) on the subcommand, report an error.

# Discuss
* Where do we put the dynamic suggestions delegate?
  * Options
    * Suggestion types - I like this because there will be a finite set that is used most of the time
      * Need to figure out how to combine other switches - like pre-release
* How do we handle arity where the switch is optional but the value for the argument is not optional (See Type property on ListCommand)
  * We need to look for another example. This is a problem prior to C# 8 only for string NO not just string cause we can convert to types
  * Attribute parameter like "ValueRequired" will be clear for reference types.
  * Nullability represents this for value types
  * Determmine whether ValueRequired is illegal or optional on value types
* What happens if the developer forgets to derive command or the base command?
  * A little unsure of issue. Abstract base class forces leafs
* Do we need to handle a subcomand (ie install) that occurs for multiple subcommands.
  * This is at least a naming problem. If it's more than that, need separate item
    * Anticipate that names will concatenate parents except for root
    * Also need a get out of jail card here
 * Composition or inheritance to define relationships
   * inheritance prohibits the use of abstract to indicate not-invokable 
   * **inhertance allows final command to be a natural conflating of data regardless of structure
* Attributes -  separate attribtes per concern or combine to intent (Option/Argument)
  * Combining attributes offers better IntelliSense guidance

