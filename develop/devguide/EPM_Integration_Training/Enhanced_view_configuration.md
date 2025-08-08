---
uid: Enhanced_view_configuration
---

# Enhanced view configuration

It is possible to enhance a view so that it displays all the data pages of a specific element. In cases where an EPM object represented by a view also has an element representation, you can use this feature to enhance the view so that all the data pages of that element are added to it, merging the EPM and element data pages into one view.

Each view can only be combined with one element, which does not have to be included within that view.

To configure this, you can either use SLNetClientTest tool, or make a direct change to the Views.xml file. However, as the latter requires a DataMiner restart, using SLNetClientTest tool is the preferred option.

## Enhanced view setup using SLNetClientTest tool

1. Open SLNetClientTest tool from the DataMiner Taskbar Utility by selecting *Launch* > *Tools* > *Client Test*.

1. Connect to the DataMiner Agent by selecting *Connection* > *Connect*.

1. In the Build Message tab, select the message *EnhanceViewWithElementRequestMessage*.

1. Specify the view ID and element ID you want to combine, and click *Send Message*.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Enhanced view setup in Views.xml

1. Stop the DataMiner software.

1. Open the file `C:\Skyline DataMiner\Views.xml`.

1. In the *View* tag of the view you want to enhance, add the *enhancedElement* attribute and set it to the ID of the element.

1. Save the file and restart DataMiner.

## Alarms configuration

To link all alarms of the enhancing element to the system object, fill in the general parameters *Alarm System Type* and *Alarm System Name* of this element with the correct system type and name.

These values will then be set in the *System Type* and *System Name* properties of all alarms of this element.
