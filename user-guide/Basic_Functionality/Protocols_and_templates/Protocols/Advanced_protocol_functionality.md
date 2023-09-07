---
uid: Advanced_protocol_functionality
---

# Advanced protocol functionality

## Generating a protocol-specific MIB

If you want to be able to control an element using a particular protocol version via SNMP, you have to create a MIB file based on the parameter information found in that protocol version.

> [!NOTE]
> The protocol MIB generation supports SNMPv1, SNMPv2 and SNMPv3.

To do so, in DataMiner Cube:

1. Go to Apps \> Protocols & Templates.

1. Right-click the protocol version for which you want to generate the MIB, and select *Get MIB file*.

1. In the *Save As* dialog box, select a name and a location for the MIB that is about to be generated, and click *Save*.

## Generating a list of all parameters in a protocol version

In DataMiner Cube, you can export the parameters for a particular protocol, or for an element using this protocol. If you export the parameters for an element, the export will include any element-specific changes towards the general protocol, such as parameter description overrides.

To export the parameters of a protocol version or an element using the protocol:

1. In the Protocols & Templates module, right-click the protocol version or the element using the protocol.

1. In the context menu, select *Export parameters*.

1. In the *Save As* dialog box, select a folder, specify a file name, and click *Save*.

   The exported CSV file will contain write and read parameters combined in a single row, with the following column order:

   ```txt
   Parameter name; Parameter description; Read parameter ID; Write parameter ID; Table parameter ID; Type; Discreet values; Can be monitored; Allow trending; Critical low; Major low; Minor low; Warning low; Normal; Warning high; Minor high; Major high; Critical high; ToolTip text; ToolTip subtext
   ```

   > [!NOTE]
   > The discrete values are displayed as "ActualValue:StringValue" and are separated by pipe characters ("\|").
   >
   > For example: *0:Disconnected\|1:Connecting\|2:Connected\|3:Disconnecting\|4:Hardware Not Present\|5:Hardware Disabled\|6:Hardware Malfunction\|7:Media Disconnected\|8:Authenticating\|9:Authentication Succeeded\|10:Authentication Failed*

## Making changes to a protocol.xml file

DataMiner Cube features a Protocol Editor functionality that can be used to make small changes to a *Protocol.xml* file.

For larger changes, however, it is advisable to use a dedicated code editor.

To make changes to a *Protocol.xml* file within Cube:

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Versions*, right-click the protocol version you want to edit and select *Open*.

1. Make the necessary changes and click *OK*.

> [!WARNING]
> Each time you make changes to a protocol version, all elements using that protocol version will automatically be restarted.

> [!NOTE]
>
> - Encrypted protocols and exported DVE protocols are read-only. They cannot be edited.
> - When you save changes to a protocol in Cube, an automatic XML validity check is done. If the XML is invalid, you cannot save your changes until the problem has been corrected.
> - If you make changes to a protocol version that is currently in use, a warning message will appear when you try to save your changes. If you then confirm the changes, the elements using the protocol version will be restarted.
> - If you add a parameter to a protocol.xml file while an element card for that protocol is opened, prior to DataMiner 10.3.8/10.4.0, you will need to close and reopen the card to see your changes. This is no longer needed from DataMiner 10.3.8/10.4.0 onwards<!-- RN 36286 -->.
