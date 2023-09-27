---
uid: Configuring_profile_definitions
---

# Configuring profile definitions

Profile definitions combine a number of parameters and scripts that are needed to fully configure a certain device.

To configure a profile definition, first select it in the *Definitions* tab of the list pane.

To create a new profile definition, click the *Add definition* button at the bottom of this pane. The new profile definition will automatically be selected.

In the configuration pane, you can configure a selected profile definition as follows:

- In the *General* section, the name of the definition can be changed, and a description can optionally be added.

- To base a definition on one or more existing definitions:

  1. In the *General* section, next to *Based on*, click *Add*.

  1. In the drop-down list, select the relevant definition, and then click *Add*.

     The parameters of the added definition will be added to the definition you are configuring.

  > [!NOTE]
  > Using this option, you can for example add additional parameters to the base definition, or combine two separate definitions into one.

- To add profile parameters to the definition, in the *Parameters* section of the configuration pane, click *Add*. Then select the parameters in the pop-up window, using the *Ctrl* key if you want to select more than one parameter at a time, and click *OK*. Once a parameter has been added, you can indicate whether it is optional with the *Optional* checkbox, and (from DataMiner 10.2.0/10.1.6 onwards) indicate whether it should be shown in scripts with the *Hide from script* checkbox.

- To add or edit an Automation script in the definition:

  1. In the *Scripts* section, either click *Add* to add a script, or select an existing script and click *Edit*.

  1. Next to *Name*, enter an alias for the script within the *Profiles* module.

  1. Next to *Remarks*, optionally add additional information about the script.

  1. Next to *Script*, select the script from the drop-down list with existing Automation scripts.

  1. Click *OK*.

- To link a new profile instance with the definition, in the *Instances* section of the configuration pane, click *Add*. This will open the *Instances* tab, with a new instance selected in the list pane.

    For more information on linking definitions to instances, see [Configuring profile instances](xref:Configuring_profile_instances).

- To remove parameters, scripts or instances from a definition, select the parameter, script or instance in question, and click the *Remove* or *Delete* button in the relevant section of the configuration pane.

> [!NOTE]
> As long as a profile definition contains unsaved changes, this is indicated in blue in the list of definitions on the left. Make sure you save the changes before you leave the module, as otherwise these changes will be lost.
