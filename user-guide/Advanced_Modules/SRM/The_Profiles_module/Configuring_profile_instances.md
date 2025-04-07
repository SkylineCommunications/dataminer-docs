---
uid: Configuring_profile_instances
---

# Configuring profile instances

In a [profile instance](xref:srm_instantiations#profile-instance), you can assign specific values to each of the parameters in a linked profile definition. Those values can then be used to configure actual devices.

To configure a profile instance, first select it in the *Instances* tab of the list pane.

To create a new profile instance, click the *Add instance* button at the bottom of this pane. The new profile instance will automatically be selected. Alternatively, a new profile instance can also be created from the *Instances* section of the configuration pane for a profile definition.

In the configuration pane, you can configure a selected profile instance as follows:

- In the *General* section, the name of the instance can be changed, and a description can optionally be added.

- To base an instance on one or more existing instances:

  1. In the *General* section, next to *Based on*, click *Add*.

  1. In the drop-down list, select the relevant instance, and then click *Add*.

  > [!NOTE]
  > - With this option, you can for example override one or more values from a base instance.
  > - An instance always has to be linked to the same definition as the instance it is based on. Therefore, if you have already selected a definition, the “Based on” list will be filtered to only show instances with that definition. If you have not yet selected a definition, it will automatically be filled in once you select a “Based on” instance.

- To link the instance to a definition:

  1. Next to *Applies to*, click *Edit*.

  1. Select the definition in the drop-down list and click *Apply*.

  > [!NOTE]
  > An instance must always be linked to a definition. It will not be possible to save the instance unless a definition has been selected.

- Once a definition has been linked with the instance, the parameters of the definition are displayed in the *Parameter values* section. You can then configure the parameter values that correspond with this instance in the *Value* column of this section, and optionally add remarks in the *Value remarks* column. From DataMiner 10.2.0/10.1.6 onwards, you can also select whether the parameter should be shown or hidden in scripts with the *Hide from scripts* checkbox.

> [!NOTE]
> As long as a profile instance contains unsaved changes, this is indicated in blue in the list of instances on the left. Make sure you save the changes before you leave the module, as otherwise these changes will be lost.
