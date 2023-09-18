---
uid: Connector_help_Woodward_EasyGen-3000
---

# Woodward EasyGen-3000

This connector monitors the activity of **Woodward EasyGen-3000** Genset controllers.

The easYgen-3000 series are control units for engine-generator system management applications. The control units can be used in applications such as co-generation, standby, AMF, peak shaving, import/export and distributed generation.

## About

The connector uses **serial** communication with the device. It makes use of the "Modbus" communication protocol.

The information from the device that is displayed depends on the configuration of imported CSV files.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.2004                      |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: *502*
  - **Bus address**: *1*

## Usage

### Config Page

On this page, you can **upload** four **CSV files**:

- **Modbus List**: file with the register address, description, multiplier and units of the parameters. This file must be manually created based on information from the manual.
- Three files that can be exported from the device, containing the address and description of the parameters.

### Modbus Data Table

This page displays information about the Modbus CSV file.

### Data

On this page, you can view information from the device according to the parameters uploaded from the CSV file.

The following selected info is available:

- **Fire Alarm**: Fire alarm status based on the data table using the **Fire Alarm Tag**.

### Visio Table

This page shows the dynamic items in the Visio.

### Set Device

The table on this page makes it possible to add different commands that will set values on the device.

### Fuel Tank

On this page, the **Table Fuel Tank** is used to add new types of fuel tanks connected to the device, to set specifications and to get information about the amount of fuel available in each tank.

The following estimated info is available:

- **Running Time Left**: Engine run time left based on how much fuel is left in the fuel tanks.
  Calculated by retrieving power engine consumption from the data table (based on the **Running Time Left Power Engine Tag** or the **Running Time Left Power Grid Tag** when the generator is not running) and the **Running Time Left Power Engine Factor**.
- **Total Remaining Fuel Left**: The total fuel remaining in all the tanks (in liters).
