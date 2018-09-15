

# Discuss
* What happens if the developer forgets to derive command or the base command?
* What happens if the developer forgets to override Invoke() in a subcommand (or the most derived implementation calls base.Invoke(), which the editor provides IntelliSense for)?
* Do we need to handle a subcomand (ie --install) that occurs for multiple subcommands.
