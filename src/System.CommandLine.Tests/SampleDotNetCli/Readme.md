# ToDo
* If Invoke is not implemented explicitly (not via inheritance) on the subcommand, report an error.

# Discuss
* Where do we put the dynamic suggestions delegate?
* How do we handle arity where the switch is optional but the value for the argument is not optional (See Type property on ListCommand)
  * We need to look for another example. This is a problem prior to C# 8 only for string.
  * One option is to tackle this as a short term problem by creating a "stringNotNull" type as a wrapper hack 
* What happens if the developer forgets to derive command or the base command?
* Do we need to handle a subcomand (ie --install) that occurs for multiple subcommands.

