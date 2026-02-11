---
uid: General_script_configuration
---

# General script configuration

In the *General* section of the details pane, general information and options can be configured for a script. To view the options, click the downwards arrow next to *Show details*.

To configure a script:

1. In the text box next to *Name*, enter a new name for the script.

1. In the text box next to *Description*, optionally enter extra information about the script.

1. Expand the details section and select or deselect the following options as required:

   - **Support back/forward buttons in interactive mode**: Adds back and forward buttons when the script shows a dialog asking for a user response.

     > [!NOTE]
     > If you use this option in an automation script that depends on C# code blocks, do not forget to also use the methods [WasBack](xref:Skyline.DataMiner.Automation.UIResults.WasBack) and [WasForward](xref:Skyline.DataMiner.Automation.UIResults.WasForward).

   - **Do not fail when elements are not active or in timeout**: Keeps the script from failing when it encounters an element that is not active or in timeout.

   - **Write comments to log file**: Ensures that any comments in the script are included in the Automation log file.

     > [!NOTE]
     > This option will only work if Automation logging is enabled. See [DataMiner logging](xref:DataMiner_logging).

   - **C#: Return NULL instead of an exception upon a GetParameter of a non-initialized parameter**: Ensures that no exception is thrown when an undefined or empty parameter is encountered in C# code. Null will be returned instead.

   - **Web compliant**: This option is only displayed if the *UseWebIAS* [soft-launch option](xref:SoftLaunchOptions) is enabled. It allows you to execute the script in a web environment, which can be useful for interactive automation scripts that use web-only features.<!-- RN 29623 -->
