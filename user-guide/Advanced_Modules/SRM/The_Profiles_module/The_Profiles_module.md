---
uid: The_Profiles_module
---

# About the Profiles module

The Profiles module is usually used as part of the [Service & Resource Management Framework](xref:About_SRM).

You can find this module in DataMiner Cube by selecting *Apps* > *Modules* > *Profiles* in the sidebar.

This module does not require a separate license. It is intended to manage profiles, which consist of a combination of the parameters needed to fully configure a certain device for usage (e.g. an IRD needs an antenna, frequency, polarization and symbol rate). The profiles can then be used in instances, i.e. filled-in profiles intended for use at one point in time.

The Profiles module consists of a list pane on the left with three tabs, *Definitions*, *Instances*, and *Parameters*, and a configuration pane on the right, which displays detailed information and settings for items selected in the pane on the left.

To create useful instances, you first need to create profile parameters and definitions. The instances can then be linked to a session variable in Visual Overview, or applied to elements with an Automation script.
