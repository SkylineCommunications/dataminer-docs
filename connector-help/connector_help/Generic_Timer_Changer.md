---
uid: Connector_help_Generic_Timer_Changer
---

# Generic Timer Changer

This a virtual connector that will load **protocol.xml files** and change them according to the user selection.

## About

The **Generic Timer Changer** connector can change any non-fixed timer and add a button to restart timers in any given connector.

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

This connector has two data display pages.

### Single Protocol Page

This page has a logical working order. You start by filling in information about the load and configuration parameters on the top-left side, continuing to the bottom left side. The information regarding the save process should then specified on the right.

A. Load Protocol:

   1. **Load Folder**: By default *C:\Skyline DataMiner\Protocols\\* You can update this to any other folder on your local machine.

   1. **Selected Protocol Name**: After selecting **Load Folder**, you can select the desired protocol name from all the valid "protocol.xml" files found in the previously selected folder.

   1. **Selected Protocol Version**: After selecting **Selected Protocol Name**, you can select the desired protocol version from all the valid "protocol.xml" files found in the previously selected folder.

   1. **Load Status**: This parameter indicates whether the connector is ready to load the timers of the protocol (*100* = ready).

   1. **Load Protocol**: After you have gone through the previous steps, click **Load Protocol**. This will fill in the **Timers table**.

B. Change Protocol:

   - **Timers table**: Every row shows one timer of the protocol. You can change the **Time** and **Data Display Time** to the desired values.

C. Save Protocol:

   1. **Save Folder**: By default *C:\Skyline DataMiner\Protocols\\* You can update this to any other folder on your local machine. The folder does not need to exist, just the logical drive (e.g. C:\\ etc.).

   1. **Protocol Name Suffix**: By default *Not Initialized*. You can update this value to any given name. This will append the chosen **Protocol Name** with the corresponding **Protocol Name Suffix**. Can be left blank.

   1. **Protocol Version Suffix**: By default *\_Review*. You can update this value to any given name. This will append the chosen **Protocol Version** with the corresponding **Protocol Version Suffix**. Can be left blank.

   1. **Save New Version**: When you have gone through all the previous steps, the connector is ready to change and save the **selected protocol** with the selected changes. Note that the **Protocol Name Suffix** and **Protocol Version Suffix** cannot be left blank at the same time (since this would generate a new version of the connector different from the existing one, creating different connectors with the same name and version).

The **Log** will show every action performed by this connector.

### Multiple Protocol Page

This page follows a similar logic as the previous page. You start by filling in information about the load and configuration parameters on the top-left side, continuing to the bottom left side. The information regarding the save process thould then specified on the right.

A. Load Multiple Protocols:

1. **Load Folder**: By default *C:\Skyline DataMiner\Protocols\\*.** You can update this to any other folder on your local machine.

   - **Add Highest Versions**: Will clear the **Selected Protocols** table and then add all the highest protocol versions in the **Load Folder** to the **Selected Protocols** table.

   - **Add All**: Will clear the **Selected Protocols** table and then add all the protocol versions in the **Load Folder** to the **Selected Protocols** table.

1. **Selected Protocol Name**: After selecting **Load Folder**, you can select the desired protocol name from all the valid "protocol.xml" files found in the previously selected folder.

   - **Add Highest Versions**: Will add all the highest protocol versions for the **Selected Protocol Name** to the **Selected Protocols** table.

   - **Add All**: Will add all the protocol versions for the **Selected Protocol Name** to the **Selected Protocols** table.

1. **Selected Protocol Version**: After selecting **Selected Protocol** **Name**, you can select the desired protocol version from all the valid "protocol.xml" files found in the previously selected folder.

   - **Add** **Version**: Will add a single protocol version to the **Selected Protocols** table.

The **Selected Protocols** table will display all the selected protocols that will be subjected to the changes from the **Timer Ranges** table and the **Add Restart Timer Button** toggle button.

B. Change Multiple Protocols:

   1. **Timers Ranges** table: This table can be filled in by the user. Every row shows one range (min and max timer value) and a **New Timer** value. The preferred order for changing the timers is top-down. This means that if you add overlapping ranges, the first range from the top that matches the timer in the protocol will be used. E.g. in the range example below, any timer with a value of *1m 00s* will be changed to 5*m 00s*. If there are overlapping ranges, the range with the lowest Range \[IDX\] will be chosen.
    Example:

      - Range 1: **Existing Timer Range Min** *1s* \| **Existing Timer Range Max** *1m 00s* \| **New Timer** *2m 00s*

      - Range 2: **Existing Timer Range Min** *1m 00s* \| **Existing Timer Range Max** *2m 00s* \| **New Timer** *5m 00s*

   1. **Add Restart Timer Button**: When this toggle button is set to *Yes*, a new page with a **Restart Timers** button will be created in each of the **Selected Protocols**.

C. Save Multiple Protocols:

   1. **Save Folder**: By default *C:\Skyline DataMiner\Protocols\\* You can update this to any other folder on your local machine. The folder does not need to exist, just the logical drive (e.g. C:\\ etc.).

   1. **Protocol Name Suffix**: By default *Not Initialized*, You can update this value to any given name. This will append the chosen **Protocol Name** with the corresponding **Protocol Name Suffix**. It can be left blank.

   1. **Protocol Version Suffix**: By default *\_Review.* You can update this value to any given name. This will append the chosen **Protocol Version** with the corresponding **Protocol Version Suffix**. It can be left blank.

   1. **Save All Protocols**: When you have gone through all the previous steps, the connector is ready to change and save the **Selected Protocols** with the selected changes from **Timers Ranges** and **Add Restart Timer Button**. Note that the **Protocol Name Suffix** and **Protocol Version Suffix** cannot be left blank at the same time (since this would generate a new version of the connector different from the existing one, creating different connectors with the same name and version).

   1. **Save all Protocols Status**: Shows the progress of the changing and saving of all protocols. Starts at *0* and finishes at *100*.

The **Log** will show every action performed by this connector.
