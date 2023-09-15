---
uid: Connector_help_Ericsson_IP_Transport_NMS
---

# Ericsson IP Transport NMS

The Ericsson IP Transport NMS/Ericsson ServiceOn Element Management System (SO-EM) is a standard software-based application, designed to support equipment focused on management of optical, microwave, broadband access and packet-based network elements.

## About

The connector polls information from the **Ericsson SO-EM** (EMS) through the **PF-SNMP** northbound interface via SNMP. Control over the device will depend on the access type of the SNMP parameters available in the Management Information Base (MIB). The connector handles parameters such as network element information, alarm event details, and all system reference catalogs.

### Version Info

| **Range** | **Description**                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                    | No                  | Yes                     |
| 1.0.1.x          | Adaptation based on change request | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                       |
|------------------|---------------------------------------------------|
| 1.0.0.x          | Performance Management System (PFM) version 18.3. |
| 1.0.1.x          | Performance Management System (PFM) version 18.3. |

### Exported connectors

| **Exported Connector**              | **Description**                                                         |
|------------------------------------|-------------------------------------------------------------------------|
| Ericsson IP Transport NMS - Device | DVEs will be created only under the name of the Network Element device. |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage (1.0.0.x onwards)

### General

This page displays the main parameters related to the creation and deletion of DVEs (**Dynamic Virtual Elements**) for each of the Network Elements that are currently being managed by the Network Management System (NMS):

- **Device Action** buttons: **Enable All** will execute the creation of all DVEs that are currently in the state "*Disabled*". These elements will be created under the view specified under **View Name** in the Device Table, or in the parent element view if no view name is specified. **Disable All** will execute the deletion of all elements that are currently in the state "*Enabled*" in the Device table.
- **Automatic Removal**: If "*Enabled*", all Network Elements that become unavailable will automatically be removed from the system. When this happens, all information related to the corresponding DVEs will be also deleted. If "*Disabled*", when a Network Element becomes unavailable, the records of this element and associated DVEs will not be deleted, and a manual option for removal will become available in the column "Remove".
- **Delete All Removed Devices**: As mentioned above, when Automatic Removal is "*Disabled*", no elements will be deleted from the Device Table regardless of their presence in the network. When Delete All Removed Devices is executed, elements with content "*Not Available*" will be deleted, together with all data for their DVEs.
- **Device Table**: This table contains information related to the management of DVEs for the different Network Elements. This table includes the parameters **Network Element ID (NE ID)** and **Name**. The table allows the dynamic editing of some DVE features. If you edit **Custom DVE Name**, the corresponding exported DVE will be updated to the new name. If you edit **View Name**, DVE creation will happen in the specified view. If no view is specified, the DVE will be created in the parent element view.

### Network Elements

This page displays information about all Network Elements that are currently being managed by the NMS.

- **Poll Network Element Table**: This button will poll the Network Element Table.
- **Network Element Table**: This table contains information about all Network Elements that are currently being managed by the NMS. It can also contain data about Network Elements that are not currently managed, but that were part of the network at some point and have not been removed from the connector data. The information in this table includes the **Network Element Name**, **Type Description** and **Alarm Level**. This table can also be updated via SNMP traps that are received by DataMiner in real time. These traps allow the information to be updated without the need of continuous polling. In that case, the **Trap Counter**, **Trap Type** and **Last Trap Time** will also be displayed in the table.

### Alarms

This page displays information about all the alarm events that are affecting the system's operation.

- **Poll Alarm Tables**: This button will poll the Alarm Table and Detailed Alarm Table.
- **Alarm Table**: This table contains all numeric and descriptive information about the system's alarms. When a DVE is exported, content in this table that relates to the corresponding Network Element will be the same as the data represented in the DVE, since each row in the Alarm Table corresponds to the alarm events for a specific Network Element. The information in the table includes the **Alarm ID (Index)**, **Raising Time**, **Network Element ID (NE ID)** and **Severity**. This table also receives trap events that update each parameter when there is a change in a Network Element.
- **Detailed Alarm Table**: This table is a smaller version of the Alarm Table, which contains descriptive information about the alarm events. All entries (i.e. alarm events) present in the Alarm Table will have a corresponding entry in the Detailed Alarm Table, so that it can be used as a quick overview of the state of the system. The same set of traps as mentioned above is also received for this table.

### Core

This page displays information about the **Management Information Base (MIB)** and its **Performance Management System (PFM).**

The main feature of this page is the **Core Table**, which displays information about the compiled SNMP MIB module MV36-OID-MIB, monitored by the PFM SNMP agent. The data in this table includes the **PFM Version** and **MV36 Version.** This table can also be updated when relevant SNMP traps are received. Information related to these trap events in the table includes the **Trap Type**, **Event Details**, and **Last Trap Time**.

### Service ID

This page contains information about the service ID, if defined, for a given Network Element.

The **Service ID Table** displays information that is obtained via CSV provisioning (see Provisioning section for details). This includes the **Network Element Unique Name (NE Unique Name)**, **Alarm Source**, **Alarm Field 1** and **Service ID**. The service ID provided here is used in the description shown in the Alarm Table, and therefore also in the DVE that is created for each Network Element.

### Element Properties

This page displays predefined information about the currently managed Network Elements.

Much of the information displayed in the **Element Properties Table** is obtained via CSV provisioning (see Provisioning section for details). This table includes the **Network Element Name**, **Site Name** and **Property 1 to 10 for each element**. In DataMiner, a set of custom properties can be configured and defined by the user for any DataMiner element. These properties can be specified in this table, so that they will be filled in automatically when a DVE is created. Also, if a Site Name (View) has been specified, the DVE will be placed in this view. Otherwise, by default, DVEs are created in the parent element's view.

### Provisioning

This page acts as the provisioning control center for the **Service ID** and **Element Properties** tables.

- **Provisioning Hints**: This is a quick help that explains the expected format of the profile files (.csv files), which is required for the system to be able to properly import/export information. Each profile file has its particulars, and details on this are provided here.

- **Element Properties** page button: Opens a subpage with the control center for provisioning data to/from the Element Properties table.

- **Element Property Provisioning File Format**: The format that each row in the table must have in order to be successfully processed by the connector. If this format is not correct, errors will be thrown.
  - **Element Property Profile File**: The name of the profile file that will be used by the connector to import/export data to/from the Element Properties table. This parameter displays a drop-down list, listing all .csv files in the following directory: **C:\Skyline DataMiner\Documents\Ericsson IP Transport NMS**.
  - **Export File/Import File** buttons: Use these buttons to import/export data to/from the profile file and the Element Properties Table.
  - **Element Property File Status**: This parameter shows the current status of the profile file. If "busy", either import or export operations are being processed.
  - **Refresh Directory** button: When the element is started, all files that are included in the above-mentioned directory are loaded and accessible. However, if any changes are made after startup, it could be that these changes, such as the creation or deletion of files, are not updated in the element. As such, if you do not see an expected profile file in the drop-down list, you should use this button to refresh the directory.
  - **Element Property Import/Export Report**: This section displays information about the last operation performed using the Import/Export settings. Indicators, such as *Operation Type, Time* and *Status,* are provided together with other more specific information.

- **Service ID** page button: Opens a subpage with the control center for provisioning data to/from the Service ID Table. The parameters on this subpage are very similar to the above-mentioned parameters for the Element Properties subpage.

### Catalog NE Type

This page displays reference information on the different Network Element (NE) types that can be encountered.

- **Poll Catalog NE Type Table** button: Performs the polling of the Catalog NE Type Table when clicked.
- **Catalog NE Type Table**: Contains the NE Type Description and the corresponding Type ID.

### Catalog Card

This page contains reference information on the different cards that can be encountered.

- **Poll Catalog Card Table** button: Performs the polling of the Catalog Card Table when clicked.
- **Catalog Card Table**: Contains information about the different cards, including the **Card ID**, **Card Type** and **NE Type**.
  **Note**: Because of the size of this table, it can take several minutes before the connector has polled all data from the NMS. Therefore, SNMP polling can only be triggered manually, using the Poll Catalog Card Table button, and it is entirely your choice when it is most convenient for the information in this table to be updated.

### Catalog Source

This page contains reference information on the different sources within the network. These sources are used, for example, when dealing with system alarm events.

- **Poll Catalog Source Table** button: Performs the polling of the Catalog Source Table when clicked.
- **Catalog Source Table**: Includes among others the **Source Type**, **Source Description** and **NE Basic Type**.

### Catalog Shelf

This page contains reference information on the different shelves that can be encountered. These shelves are usually used to provide details about the alarm events.

- **Poll Catalog Shelf Table** button: Performs the polling of the Catalog Shelf Table when clicked.
- **Catalog Shelf Table**: Includes among others the **Shelf ID**, **Shelf Type** and **Shelf Description**.

### Catalog Alarm

This page contains reference information on the different alarm events that can be triggered by the system.

- **Poll Catalog Alarm Table** button: Performs the polling of the Catalog Shelf Table when clicked.
- **Catalog Alarm Table**: Alarm Type, NE Basic Type, and Alarm Description are some of the parameters that can be found in this table.
  **Note**: As this is a very large table, containing details about every type of alarm that could possibly be triggered within the system, it can take the connector a long time to poll all the information to fully populate this table (up to 30 minutes). As such, SNMP polling is only done when the **Poll Catalog Alarm Table** button is clicked, and it is entirely your choice when it is most convenient for the information in this table to be updated.

### Catalog Signal

This page displays reference information on the signal discriminators that are part of the system.

- **Poll Catalog Signal Discriminator Table** button: Performs the polling of the Catalog Signal Discriminator Table when clicked.
- **Catalog Signal Discriminator Table**: Includes the **Signal Description**, **Scheme ID** and **Signal ID**.

### Catalog Scheme

This page contains reference information on the different schemes that can be encountered. Scheme information is usually used as part of the alarm event details.

- **Poll Catalog Scheme Table** button: Performs the polling of the Catalog Scheme Table when clicked.
- **Catalog Scheme Table**: Includes the **Scheme Description**, **Scheme ID** and **Scheme Field 1**.

### Catalog Event Type

This table contains information on the different types of events that could have associated alarms within the system.

- **Poll Catalog Event Type Table** button: Performs the polling of the Catalog Event Type Table when clicked.
- **Catalog Event Type Table**: Includes the **Event Type Description** and **Event Type ID**.

### Catalog Probable Cause

This page displays information on the different probable causes that could be included in the details of an alarm event.

- **Poll Catalog Probable Cause Table** button: Performs the polling of the Catalog Probable Cause Table when clicked.
- **Catalog Probable Cause Table**: Includes the **Cause Description** and **Cause ID**.

### NE Filter

This page contains information about the different filters that can be applied to the retrieval of information about Network Elements.

- **Poll NE Filter Table** button: Performs the polling of the NE Filter Table when clicked.
- **NE Filter Table**: Includes the **Basic Type** and **Row Status**.**
  Note**: If this table is empty, all Network Elements are listed in the Network Elements Table, and so all Network Element notifications are sent to the NMS. If this table is not empty, the Network Element Table contains only the Network Element basic types listed in this table, and so only Network Element traps related to these NEs are sent to the NMS.

### Alarm Filter

This page contains information about the different alarm filters that could be applied to the system.

- **Poll Alarm Filter Table** button: Performs the polling of the Alarm Filter Table when clicked.
- **Alarm Filter Table**: Includes the **Element Manager ID**, **Network Element ID** and **Network Element Basic Type**.
  **Note**: if this table is empty, the manager is notified of all alarms related to the Network Elements listed in the Network Elements Table, and these are all listed in the alarm tables. If this table is not empty, the manager is only notified of the alarms related to the Network Elements listed in the Network Elements Table that match the conditions of a filter, and only those alarms are listed in the alarm tables.

### System DVE

This page shows information about the currently created DVEs (i.e. those set to *Enabled* in the Device Table).

- **DVE Export Table**: This table contains information on the settings for each created DVE.

- **Custom DVE Name**: The name used to create the DVE.
  - **View**: The Site Name (View) where the DVE was created.
  - **DVE Info**: The DataMiner ID and Element ID separated by a forward slash "/".
  - **Network Element Name**: The name of the Network Element for which the DVE was created.

## Usage (1.0.1.x onwards)

### Alarms

This page displays information about all the alarm events that are affecting the system's operation.

- **Poll Alarm Tables**: This button will poll the Alarm Table and Detailed Alarm Table.
- **Alarm Table**: This table contains all numeric and descriptive information about the system's alarms. When a DVE is exported, content in this table that relates to the corresponding Network Element will be the same as the data represented in the DVE, since each row in the Alarm Table corresponds to the alarm events for a specific Network Element. The information in the table includes the **Alarm ID (Index)**, **Raising Time**, **Network Element ID (NE ID)** and **Severity**. This table also receives trap events that update each parameter when there is a change in a Network Element.
- **New Alarm Table:** This is an exact replication of the Alarm Table, with one difference, which is that the index used for the table is a combination of 8 different bindings of the trap. All 8 bindings were concatenated as **\[mv36AlarmStrNeUniqueName\]/\[mv36AlarmStrCard\].\[mv36AlarmPortId\]/\[mv36AlarmStrScheme\]/\[mv36AlarmStr\]/\[mv36AlarmStrProbCause\]/\[mv36AlarmStrSource\]/\[mv36AlarmField1\]** to form the index of the New Alarm Table.
- **Detailed Alarm Table**: This table is a smaller version of the Alarm Table, which contains descriptive information about the alarm events. All entries (i.e. alarm events) present in the Alarm Table will have a corresponding entry in the Detailed Alarm Table, so that it can be used as a quick overview of the state of the system. The same set of traps as mentioned above is also received for this table.
