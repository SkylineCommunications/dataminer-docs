---
uid: Script_execution_options
---

# Script execution options

The following script execution options are available:

| Option | Default | Description |
|--|--|--|
| Wait for the script to finish before continuing | On | If you select this option, you will have to wait for the script to finish before you can continue. |
| After executing a SET command, ... | On | By default, every time a script performs an update of a parameter or property value, it will wait for a return value indicating whether the update was successful. Clear this option if you do not want this to happen. |
| Lock elements | Off | By default, an automation script will never lock elements. If you want a script to do so, select this option. |
| Force lock elements | Off | If you have selected *Lock elements*, you can also select this option to make the script lock elements even when they are locked by another process (e.g., another automation script). |
| Wait when locked or busy | On | By default, when an automation script has to access an element that is locked by another process (e.g., another automation script), it will wait until that element gets unlocked. To make sure a script will not do so, clear this option. |
| Mark dummy elements 'In Use' ... | Off | For automation scripts used in Scheduler, select this option to mark the dummy elements as 'In Use' for active scheduled tasks. Based on this property, the elements can then be hidden or shown in Visual Overview. For more information on how to use this option in Visual Overview, see [Overview of page and shape options](xref:Overview_of_page_and_shape_options). |
| Generate an information event ... | On | By default, a *Script started* information event is generated when a script is launched. From DataMiner 10.5.9/10.6.0 <!-- RN 43245 --> onwards, you can clear this option to avoid generating this information event. |

> [!NOTE]
> If *Force lock elements* is selected for an automation script, each instance of the script will have its own lock. This means that, if an element is locked by a script and that same script is executed again at the same time, the second instance of the script will wait until the first instance has released the element lock.
