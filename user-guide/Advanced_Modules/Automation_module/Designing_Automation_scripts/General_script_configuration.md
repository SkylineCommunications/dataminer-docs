---
uid: General_script_configuration
---

# General script configuration

In the *General* section of the details pane, general information and options can be configured for a script. To view the options, click the downwards arrow next to *Show details*.

To configure a script:

1. In the text box next to *Name*, enter a new name for the script.

1. In the text box next to *Description*, optionally enter extra information about the script.

1. Expand the details section and select or deselect the following options as required:

   - Select *Support back/forward buttons in interactive mode* to add back and forward buttons in a dialog box asking for a user response.

     > [!NOTE]
     > If you use this option in an Automation script that depends on C# code blocks, do not forget to also use the methods *WasBack* and *WasForward*. See [WasBack](xref:Skyline.DataMiner.Automation.UIResults#Skyline_DataMiner_Automation_UIResults_WasBack) and [WasForward](xref:Skyline.DataMiner.Automation.UIResults#Skyline_DataMiner_Automation_UIResults_WasForward).

   - Select *Do not fail when elements are not active or in timeout* to keep a script from failing when it encounters an element that is not active or in timeout.

   - Select *Write comments to log file* to write any comments in the script in the Automation log file.

     > [!NOTE]
     > This option will only work if Automation logging is enabled. See [DataMiner logging](xref:DataMiner_logging).

   - Select *C#: Return NULL instead of an exception upon a GetParameter of a non-initialized parameter* to ensure no exception is thrown when an undefined or empty parameter is encountered in C# code. Null will be returned instead.
