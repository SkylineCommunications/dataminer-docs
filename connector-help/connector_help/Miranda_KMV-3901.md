---
uid: Connector_help_Miranda_KMV-3901
---

# Miranda KMV-3901

The **Miranda KMV-3901** connector is a serial connector used to display information about the **Miranda KMV-3901** card. This protocol uses the Kaleido Remote Control Protocol (RCP) to get the information and change certain values on the device. This connector also needs an SNMP connection to get information about certain status parameters of the frame where the KMV-3901 card is installed.

## About

The KMV-3901 device can be configured with the XEdit software that is delivered with the device. You can also change certain settings using the RCP protocol. However, for this connector, the XEdit software will still need to be used, because certain settings cannot be done using the RCP protocol.

## Configuration and Installation

### Creation

Because this connectors uses SNMP and TCP (serial) communication, 2 connections need to be configured when you create an element for the connector. The settings for these connections are listed below:

**SERIAL CONNECTION**

- **Type of port**: TCP/IP (already configured).
- **IP address**: The IP address of the Miranda KMV-3901 device.

**SNMP CONNECTION**

- **IP address**: The IP address of the frame.

After creating the element, it's important that you set the input parameters that are displayed on the **General** page. See section *Usage \> General Page* for more details.

## Usage

### General Page

This page displays the **System Name** and **Software Version**. These 2 parameters are the only serial parameters that are displayed on this page.

The other parameters on this page are the status parameters that are polled from the frame via SNMP. These parameters are polled more frequently. Trending and alarming are also available for these parameters.

The **Input Names.** page button is also displayed on this page. The **Input Names** page contains a table with the channel names that are used in XEdit. Note that when you change the input name on the XEdit software, it is important that you also change the name in the **Input Names table**, because these names are used for the settings in the **Monitor table** (discreets).

### Monitor Page

The **Monitor** page displays the **Room** and **Current Layout**. These parameters are also displayed on the **UMD** page. Both parameters can be changed using the values in the drop-down menu. When the room is changed, the drop-down list for the layouts will be updated to contain all layouts for the selected room.

Every time the current layout changes, the **Monitor** table will be updated. Because there is no command to get all the monitors for a certain layout, these monitors need to be added by the user. When a monitor has been added to a layout in XEdit, the monitor can be added to the monitor table for the layout in question. To do so, right-click the table and select **Add New Monitor**. A textbox will appear where you can enter the monitor name.

When a new monitor entry is added to the table, the monitor will be added to an .xml file that is saved in the following folder:

*C:\Skyline DataMiner\Documents\DMA_COMMON_DOCUMENTS\Miranda KMV-3901\\*

After the new monitor has been added to the .xml file, the connector will execute an RCP command to get the currently connected channel. This channel can be changed in DataMiner using the drop-down menu that contains the input names (configured in the **Input Names table**).

When a monitor is deleted from the layout, it's also possible to delete this monitor from the table. This is done by selecting the monitor entries you want to delete and right-clicking. When one or multiple rows are selected, you will be able to select the **Delete Selected Monitors.** action. This action will delete the selected monitors from the .xml file.

### UMD Page

The **UMD** page is very similar to the **Monitor** page. It contains the same **Room** and **Current Layout** parameter. This means that when you change one of these parameters on one of the pages, the value will also be changed on the other page. Every time these parameters are changed, the **UMD** and **Monitor table** will be updated with the correct UMDs or monitors.

Adding a UMD to the table is done the same way as adding a monitor in the **Monitor table**. Before you add the UMD to the table, it has to be added in XEdit. After the UMD is added to the table, a command will be executed to get the dynamic text for this UMD. Dynamic text can only be set using the RCP setKDynamicText command. It's possible to set this text in the connector.

### Timer Page

The **Timer** page can be used to alter settings for certain timers. To add a timer to the .xml file, you only need to fill in the timer name and click the **Add Timer** button. When the timer is added to the .xml file, it will be available in the drop-down menu. Before you can change the settings for a timer, you have to create it in XEdit as well.

To set a timer (change settings), all the values on the left side of the card (**Timer**, **Start Time**, **Preset** **Time**, **Timer** **Mode**, **End** **Mode**) need to be filled in. After these parameters have been set correctly, you can click the **Set Timer** button. The **Timer** **Status** will then display if the set was correct or not. It's important that the format for the **Start** and **End Time** is correct (HH:MM:SS:FF).

It's also possible to **Start**, **Stop** and **Reset** a timer, using the buttons at the bottom. When you want to perform one of these actions, only the timer needs to be selected from the drop-down list. When one of these buttons is clicked, the timer status will also be updated.

### Actions Page

The **Actions** page contains a table with all the actions that are configured in XEdit. This table is filled in after the element is started. When an action is added to XEdit, the user can click the **Refresh List** button to update the **Actions table** with the correct actions.

Every action can be executed with the **Execute** button in the second column of the table. After an action is executed, the **Action status** will be updated.

### WebInterface Page

This page links to the **Interface** page of the **Miranda KMV-3901** card. The IP address that is used is the one that was specified when the element was created.

## Notes

### Adding or deleting a table entry

It's important to note that right-clicking in the **Monitor** or **UMD** **table** to add a monitor or UMD will only work in DataMiner Cube. This uses a feature called **ContextMenu** which is not available in DataMiner SystemDisplay.
