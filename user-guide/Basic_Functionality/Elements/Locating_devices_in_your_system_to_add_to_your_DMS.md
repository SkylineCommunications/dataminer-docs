---
uid: Locating_devices_in_your_system_to_add_to_your_DMS
---

# Locating devices in your system to add to your DMS

DataMiner Cube provides a wizard that can be used to automatically detect devices in your infrastructure: the Device Discovery wizard. With the wizard, you can discover devices within a certain IP range, and then immediately create the corresponding elements in your DMS.

> [!NOTE]
>
> - The Device Discovery wizard requires a network discovery element using the Production version of the protocol *Skyline IP Network Discovery*.
> - Alternatively, advanced element discovery and provisioning is possible with the IDP app. See [DataMiner IDP app](xref:SolIDP).

To find devices and create elements with the Device Discovery wizard:

1. Open the view card where you want to create the new element(s), and either right-click the colored header bar or click the hamburger button in the top-left corner.

1. Select *Device Discovery* to open the wizard.

1. Under *IP range*, enter the IP address range(s) to include or exclude.

   > [!NOTE]
   > If you enter an invalid IP address, the *Discover* button at the bottom will be unavailable.

1. Under *Devices*, indicate the way the wizard should look for devices by selecting one of the following options in the drop-down list and then specifying it further:

   - *Generic*: Look for any devices using SNMP and/or ping.

   - *Protocol-specific*: Look for devices based on their protocol.

1. Click the *Discover* button at the bottom.

   The wizard will search for devices within the IP range, which may take a while. If there are no devices within the specified range, a message will appear that no devices were found. Otherwise, a list of discovered devices will be displayed. If any devices have an IP address that matches one of your existing elements, these are displayed in gray.

1. In the list of discovered devices, select the devices for which you want to create an element. If necessary, you can use the *Select all* and *Unselect all* buttons at the bottom.

   > [!NOTE]
   > If many devices are found, it can be useful to sort them by clicking on a column header.

1. Click *Prepare for element creation*.

1. In the *element creation* window, enter the basic information required to create the element: name, description, protocol, protocol version and get and set community string.

   > [!NOTE]
   > It is possible to enter the name, description, protocol or protocol version for several elements at once: select multiple elements in the list and click one of the mentioned information fields to open a *multiple edit* box, where you can enter or select the information for all selected elements.

1. Click *Create* to create the elements. The wizard will show a summary of the elements that were created.
