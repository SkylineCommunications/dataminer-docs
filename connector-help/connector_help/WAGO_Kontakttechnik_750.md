---
uid: Connector_help_WAGO_Kontakttechnik_750
---

# WAGO Kontakttechnik 750

The **WAGO Kontakttechnik 750** can be used to monitor the WAGO 750-x **PLC** and its connected modules.

The communication towards the PLC is done using **modbus**. As such, there are some restrictions on what can be requested from the PLC.
More details can be found in the notes below.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                | **Based on** | **System Impact**                               |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                                                | \-           | \-                                              |
| 2.0.0.x \[SLC Main\] | Modules are automatically detected (in case of 750-880 or 750-881). Reviewed protocol to make sure everything can be supported. | \-           | Element data and trend/alarm info will be lost. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.4.x                  |
| 2.0.0.x   | 2.4.x                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  -**IP address/host**: The polling IP of the device.
  - **IP port**: The IP port used for modbus communication, by default 502.

### Initialization

#### 1.0.0.x

In the initial range of the WAGO Kontakttechnik 750, you need to configure the connected modules by importing a **.csv file**. This file should contain a line starting with the IP of the controller, followed by a semicolon-separated list of the connected modules in the correct order.
For example: *10.1.2.3;513;513;402;402;402;461.*

The type and exact order of the modules is required in order to obtain a proper indexing of the digital/analog inputs and outputs.

Typically, the .csv file is first created and added to the DataMiner Documents folder (so it will be part of a backup). The file can then be imported on the **Configuration** page. To do so, enter the **File Location** and the **File Name** separately, and then click the **Import File** button. The **Import Status** will indicate if the file was imported successfully. After the file has been imported, the **Module Configuration Table** will be populated accordingly and should reflect the correct module configuration of the chassis.

Note that there is only a single .csv file specifying the module configuration of all the WAGO chassis elements, so typically you will first create all the WAGO elements and then, using multiple sets, fill in the File Location and Name and perform the import. Each WAGO element will then pick its own configuration from the file based on its IP address.

#### 2.0.0.x

This range no longer requires a configuration file. The modules are now **retrieved** from the controller itself. However, the controller reports analog and digital modules differently:

- For **analog** modules, only the type of the module is returned, so the connector contains a mapping of the different types and how many inputs/outputs this module has.
- For **digital** modules, the type is not returned. Instead the number of inputs/outputs for this module is returned. For these modules, the type can be linked to the module entry manually (but this is not required to correctly poll the data).

The connector contains a table with all the known modules, how many inputs/outputs they have and which unit should be used for their values. This is all configurable and in case a module is not yet known by the connector, no connector update is initially required, as new entries can be added to this **mapping** table manually.

### Web Interface

The **web interface** is only accessible when the client machine has network access to the product.

## How to Use

This connector uses **modbus** and needs to request all data from the modules through the controller. To do this correctly, the element first needs to know which modules are connected to the **controller** and it is important that the number of modules and the number of interfaces (inputs/outputs) per module is correct.
The element will read out all interfaces from the controller and when all modules are correctly configured in the element, it will be able to display the values and map them to the correct module. If this is not the case, input and output values could get **shifted** and displayed for the wrong module.

Not all information is available through modbus, but it can be made available using a **custom program on the PLC**. More information about this is available in the Notes section below.

Also, in some cases, you can modify **the format of the display keys** (used in the alarms to identify a table row) by clicking the **Config DisplayKey** button at the top of the relevant table.

## Notes

The WAGO Kontakttechnik 750-x controller **does not allow all values to be read or set via** **modbus**. Certain values can only be read out and manipulated by running a custom program on the PLC itself. To read out and set these values, **custom** **markers** can be used by the program running in the PLC. These markers can then be read out by the element in DataMiner. To read and set these, you can add an entry in the **Markers** table (in range **2.0.0.x**). Each entry in that table will be read out every 5 seconds.

This connector is **not able to automatically retrieve the number of inputs/outputs of 750-8100 (PFC100) modules** because this type does not support the same API as the other module types. In this case, you can manually add the registers you want to poll to the **Markers** table. These values will be retrieved every five seconds.
