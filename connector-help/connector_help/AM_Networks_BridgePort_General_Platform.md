---
uid: Connector_help_AM_Networks_BridgePort_General_Platform
---

# AM Networks BridgePort General Platform

With this connector, you can gather and view information from the device **AM Networks BridgePort** and from the amplifiers connected to the device. It also allows you to configure the device.

## About

This connector is used to gather information from the **AM Networks BridgePort** device and the attached amplifiers.

The connector has several pages with general information, HMTS info, the HMTS device table, etc.

### Version Info

| **Range** | **Description**                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                   | No                  | Yes                     |
| 1.0.1.x          | Added display column to a table.   | No                  | Yes                     |
| 1.0.2.x          | Changed display column for naming. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.0.1.x          | N/A                         |
| 1.0.2.x          | N/A                         |

### Exported connectors

| **Exported Connector**                              | **Description**    |
|----------------------------------------------------|--------------------|
| AM Networks BridgePort General Platform - VGP-9240 | VGP-9240 amplifier |
| AM Networks BridgePort General Platform - VGP-9022 | VGP-9022 amplifier |
| AM Networks BridgePort General Platform - GGA8 R   | GGA8 R amplifier   |
| AM Networks BridgePort General Platform - GGA8 N   | GGA8 N amplifier   |
| AM Networks BridgePort General Platform - GGA8 O   | GGA8 O amplifier   |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *172.16.21.50*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the system description, system name, uptime, location, etc.

### HMTS Info Page

This page contains the configuration parameters of the device and allows you to configure the **HMTS Properties**, **Poll Delay Settings**, **Registration Settings** and **SNMP Properties**.

### HMTS Forward Port Table Page

This page contains a table with the HMTS forward port information, allowing you to both view the forward ports configuration and configure it.

### HMTS Revers Port Table Page

This page contains a table with the HMTS reverse port information, allowing you to both view the reverse ports configuration and configure it.

### HMTS Device Table Page

This page contains information regarding the amplifiers connected to the device. This information is shown in the **HMTS Device Table**.

On this page, you can also import a .csv file with the name, type and view of the amplifiers, so that this information does not need to be set manually for every amplifier in the table. The import file should have the following format:

> Community String (IDX);Element Name;Node Type;View
>
> 00D05507F75D;1S006;VGP-9240;TestView
>
> 00D05507F743;1S007;VGP-9240

Note: The view is not mandatory. If it is left out, the DVE will automatically be assigned to the same view as the main element. The same will happen if the file specifies a view that does not exist.

The node type can have the following values: GGA8 R, GGA8 N, GGA8 O, VGP-9240, VGP-9222 and VGP-9022.

Each amplifier will create a new virtual element with the name present in the HMTS Device Table. The protocol used by this element will depend on the element type.

## Notes

Since this connector creates a large number of DVEs, you must keep the following in mind when using it:

- When a new .csv file is imported, if there are changes in the field Element Type, the corresponding existing DVE will need to be deleted and a new DVE will be created. This can take a while, depending on the number of DVEs to delete and create. You should not make another set on the device before the polling cycle parameters are back to the normal state, as otherwise the set will not take effect, but it will increase the load on the DMA even more.

- The .csv file should be carefully checked. The presence of duplicate entries, wrong names, etc. can lead to a configuration failure.

- The button **Delete All DVEs** will delete all DVEs, so when using this button you should take the same precautions as when importing a new .csv file.

- After a restart of the main element, you have to wait some time before applying any configuration, such as importing a .csv file. This is necessary because the polling of the HTMS Device Table can take a while, depending on the number of rows present in that table. If, for some reason, e.g. because of network failure, the HMTS Device Table failed to poll, you can refresh it using the refresh button. The polling of the amplifiers will only start after this table has been polled.

- Assigning an alarm or trend template to the DVEs can take some time, depending on the number of DVEs. During this operation, you must avoid doing any other configuration, such as deleting DVEs, restarting the main element, importing a new .csv file, etc.
