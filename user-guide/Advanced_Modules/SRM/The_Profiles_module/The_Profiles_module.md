---
uid: The_Profiles_module
---

# About the Profiles module

The Profiles module, which is sometimes also referred to as "Profile Manager", is usually used as part of the [Service & Resource Management Framework](xref:About_SRM). You can find this module in DataMiner Cube by selecting *Apps* > *Modules* > *Profiles* in the sidebar.

This module does not require a separate license. It is intended to manage profiles, which are used to **configure complex resources repeatedly and reliably**. This is typically done using [Profile-Load Scripts (PLS)](xref:srm_scripting#profile-load-script-pls), which execute the necessary parameter sets on a resource in an ordered and controlled manner via its connector in DataMiner. However, simple profiles may even be used without these scripts.

In practice, each **profile definition** consists of a set of parameters, independent of the underlying technology, and the corresponding **profile instance** determines the values that need to be applied to these parameters. Think for example of a profile to tune a satellite receiver: operators can add parameters required for any branch of satellite receiver, such as the center frequency, roll-off factor, modulation standard, etc.

Aside from configuration parameters, a profile can also include a **customized list of capacities and capabilities**. For example, an HD profile of 4 Mbps needs an HD encoder, and an SD profile of 1.5 Mbps needs an SD-only capable encoder and a limited network capacity only. Corresponding capacities and capabilities should be configured on the resources in this case, so that DataMiner will be able to check if a resource meets the capability requirements asked for in the profile, and it will be able to reduce the capacity of the resource while it is in use.

In DataMiner Cube, the **Profiles module in DataMiner Cube** consists of a list pane on the left with three tabs, *Definitions*, *Instances*, and *Parameters*, and a configuration pane on the right with detailed information and settings for items selected in the pane on the left. To create useful instances, you will first need to create profile parameters and definitions. The instances can then be linked to a session variable in Visual Overview, or applied to elements via a script.

![Profiles module](~/user-guide/images/Profiles_module.png)<br>*Profiles module in DataMiner 10.5.5*
