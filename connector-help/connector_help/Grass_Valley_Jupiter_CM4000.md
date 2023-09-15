---
uid: Connector_help_Grass_Valley_Jupiter_CM4000
---

# Grass Valley Jupiter CM4000

The **Grass Valley Jupiter CM4000** is a matrix device that contains both **ASI** and **SDI** outputs/inputs.

## About

With this connector either an **SDI** or an **ASI** matrix can be created, with a maximum size of 1024x1024. **SDI** or **ASI** is selected using the **Bus Address** of the element in the connector and relies upon the following configuration setting on the device: all ASI names must be preceded by a "#" character, which is used to identify whether the matrix is SDI or ASI. From version 1.0.0.14 onwards, this connector supports both JupiterXPress and AccuSwitch applications.

### Version Info

| **Range**         | **Description**                                                       | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|-----------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial version.                                                      | No                  | No                      |
| 2.0.0.1                  | Label pages are custom-linked to page names.                          | No                  | No                      |
| \>1.0.0.14               | Support for JupiterXPress added.                                      | No                  | No                      |
| 1.0.1.1                  | Communication with device via smart-serial connection instead of DLL. | No                  | Yes                     |
| 1.0.2.1 **\[SLC Main\]** | DCF interfaces added.                                                 | Yes                 | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**  |
|------------------|------------------------------|
| 1.0.0.x          | AccuSwitch Application       |
| 2.0.0.1          | AccuSwitch Application       |
| \>1.0.0.14       | AccuSwitch and JupiterXPress |
| 1.0.1.1          | JupiterXPress                |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. Default: *420*, *UDP.*
- **Bus address**: The bus address of the device: *\<device address\>.\<level\>*
  \<device address\> and \<level\> are *1-based*. A level of *1* indicates **SDI** and a level of *2* indicates **ASI**.

### Installation Procedure

Only applicable for versions prior to 1.0.1.1.

For versions prior to 1.0.1.1, an external DLL is used by the connector to contact the device. For this purpose, when you are using such an older version, add *es-lan-communication.dll* to the folder "C:\Skyline DataMiner\ProtocolScripts". If the folder already contains this file, follow the **Clean Shutdown** procedure described below and overwrite the old *es-lan-communication.dll* with the new file during step 4 of the procedure.

Note: If you are using a redundancy setup, make sure to add or update this DLL on both DMAs.

By default, the connector attempts to use commands for the **AccuSwitch** application. If the Jupiter CM4000 is using **JupiterXPress**, then the **AccuSwitch** toggle button on the **General** page needs to be toggled. Please note that JupiterXPress does not support lock ownership, so that all locks are considered to be owned by DataMiner.

### Clean Shutdown or Update Procedure

Because the connector uses an external DLL, it is very important to cleanly shut down the elements if you wish to update the connector or stop using the element. Adhere to the following procedure:

1. Stop all but one of the elements using this connector.
1. On the last active element, go to the **General** page and click **Clean ShutDown**. Wait until the Clean Shutdown parameter indicates it is ready.
1. Stop the last active element.
1. Set all elements to the newest version.
1. Start all elements.

If you notice the **DLL Object Exception** counter increasing, apply the same procedure again. However, if the issue persists, then a DataMiner restart will be necessary before the element can be used again.

Warning: When you are about to delete the last element that uses this connector, it is vital that you perform the **Clean Shutdown** procedure. If the procedure is not applied, a DataMiner restart is the only way to get this connector active again in the future.

## Usage

### General

This page contains general device parameters such as the **System Name**, **Level Name**, **Number of Inputs** and **Number of Outputs**.

For versions prior to 1.0.1.1, there is also a **DLL Object Exception** counter. This will indicate if there is an issue with the background DLL that is used for communication with the device. If this counter is increasing, you should carry out the **Clean Shutdown** procedure detailed above.

If you use a version of the connector prior to 1.0.1.1, you can also find the **AccuSwitch** toggle button on this page. When this button is set to *true*, the API uses **AccuSwitch** commands. When it is set to *False*, the API uses **JupiterXPress** compliant commands.

### Input-Outputs

This page contains a **matrix** with **outputs on the X-axis** and **inputs on the Y-axis.** **Label Names** and **Categories** are retrieved from the device. It is possible to **set crosspoints** and to apply **locking or unlocking**.

When a **locking or unlocking** command is executed, the **Communication Status** parameter on this page and on the General page will show *Timeout*. However, the lock or unlock command does go through to the device, and despite the timeout status, the connector is still fully functional. To clear the timeout status of this parameter, go to the **Advanced** subpage of the General page and use the **Clear Queue** parameter.

The connector does not currently support locking or unlocking multiple ports at the same time. Attempting to do so will cause the connector to display incorrect information on the matrix. When locking or unlocking, wait until the **Communication Status** parameter displays either *Timeout* or *Idle*.

### Monitor Page

#### Versions other than 1.0.1.1

This page contains the **Monitor Table**. This table contains all current information for each output, such as its current **Lock State** and **Current Connected Input.** All data in this table is read-only and can be used for alarm monitoring or trending. The main usage of this table is the **Revert** button located at the end of the table. The table keeps track of the **Last Connected Input** and allows you to revert back to that state using this button.

The **Monitor Table** also contains the current **Lock State** and current **Lock Owner**. There is a **Force Unlock** button to force unlock any output regardless of the **Lock Owner**. However, this last functionality should be used with care.

Note: The following situations will reset the **Monitor Table**, cleaning all previous inputs:

- After a **Clean Shutdown**, when the element is started again, the Monitor Table is re-created.
- After **Labels/Category** changes on the device, the Monitor Table is re-created.
- Clearing Element Storage resets the Monitor Table.

#### Version 1.0.1.1

This page contains the **Monitor Table**. This table contains all current information for each output, such as its current **Lock State** and **Current Connected Input.** The table has a custom context menu that can be used to execute a lock, protect, unlock, unprotect or revert operation.

The revert operation will set the connection back to the source as indicated in the **Revert Connected Sources** column.

## DataMiner Connectivity Framework

Available in range 1.0.2.x.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic interfaces

- Sources: Reports the available interfaces **in** for the encoder or decoder.
- Destination: Reports the available interfaces **out** for the encoder or decoder.
