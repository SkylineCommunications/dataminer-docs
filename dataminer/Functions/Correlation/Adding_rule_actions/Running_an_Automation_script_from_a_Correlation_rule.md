---
uid: Running_an_Automation_script_from_a_Correlation_rule
---

# Running an Automation script from a correlation rule

To run an automation script from a correlation rule:

1. In the *Actions* section of the details pane, click *Add Action* and select *Run Automation script*.

1. Click the first underlined field and select the script.

1. Specify any additional information needed by the script, e.g. dummy elements.

   > [!NOTE]
   > To dynamically pass the element that triggers the correlation rule to the automation script, in the dropdown list for the relevant dummy element, select *\<Dynamic>*.

1. Optionally, specify the options for running the script. For more information, see [Script execution options](xref:Script_execution_options).

1. Click the second underlined field and specify the DMA where the script should be run. If you do not specify a DMA, the DMA is automatically selected by the Correlation engine.

1. If necessary, select one or more of the following options:

   - **Execute on clear**: Select this option to also run the script at the moment when the conditions triggering the rule are no longer fulfilled.

   - **Execute on base alarm updates**: Select this option to also run the script when the base alarms change.

   - **Evaluate script parameter values**: Select this option to allow placeholders in script parameter values. For more information, see [Correlation rule syntax](xref:Correlation_rule_syntax).

> [!NOTE]
>
> - To pass information about the alarm that triggered the correlation rule to the script, you can use the special parameters with ID 65005 and 65006. For more detailed information, see [Special parameters available in DataMiner Automation scripts](xref:Special_parameters_available_in_DMS_Automation_scripts).
> - Prior to DataMiner 10.5.2/10.6.0<!--RN 41653-->, an information event will automatically be generated when an Automation script is triggered by the Correlation engine. If you also want this to happen in versions from DataMiner 10.5.2/10.6.0 onwards, you will need to set the *SkipInformationEvents* option to "false" in *MaintenanceSettings.xml*. See [Enabling information events when scripts are started by Correlation rules or scheduled tasks](xref:Configuration_of_DataMiner_processes#enabling-information-events-when-scripts-are-started-by-correlation-rules-or-scheduled-tasks).
