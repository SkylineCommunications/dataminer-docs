---
uid: Connector_help_SES_S.A._Siemens_Logo
---

# SES S.A. Siemens Logo

This driver communicates with the Siemens Logo, which is a **PLC.** It uses **serial** communication via the **Modbus** **TCP** protocol.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.82.01                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

There are 2 ways to configure the device:

1.  By importing an existing configuration. This is done via the **Import/Export** page. This is useful if you have already configured a different device and want to have an identical configuration on this device. It will overwrite existing configuration for all tables and standalone parameters.Fill in the **Import CSV File Path** and the **Import CSV Filename**, and click the **Import CSV button**. The different tables will then be filled in and will be polled in the next polling cycle.

2.  By manually configuring the tables.To do so:

3.  - On the **Relays and Inputs** page, right-click the **Relays Table** or the **Discrete InputsTable** to add or delete rows in the tables.Fill in the requested parameters, including a **Name** and a **Register Address**, which should be unique within the table, and choose the **Signal Mode** (*Equal* or *Inverted*).The latter determines whether the **Raw Value** from the device is the same as the **Logic Value**, or the inverted value.
    - On the **Schneider PM 8000** page, right-click the **Voltages Table** or the **Currents Table**, to add or delete rows in the tables.Fill in a **Name** and a **Register Address**, which should be unique within the table.
    - In order to define the Modbus registers that correspond to the **Power in kW**, **Power in kVA**, **Power in kVAR**, **Frequency** and **Power Factor**, click the **Register Addresses** page button on the **Schneider PM 8000** page.Those parameters are called **Power in kW Modbus Register**, **Power in kVA Modbus Register**, **Power in kVAR Modbus Register**, **Frequency Modbus Register** and **Power Factor Modbus Register**.
    - Once you have completed the configuration, you can export it to a file in order to reuse it on a different device, or to keep a backup of the current configuration. This is done via the **Import/Export** page. Fill in the **Export CSV File Path** and the **Export CSV Filename**, and click the **Export CSV button** to export your current configuration.

### Redundancy

There is no redundancy defined.

## How to use

The driver uses the MODBUS type of commands via a serial interface. The parameters are polled at a fixed interval.

For more information on how to configure the parameters of this driver, refer to the Initialization section above.

## Notes

Below you can find some more information on the format of the import/export CSV file:

- The configuration file is a semicolon-delimited file, in the format illustrated in the example below.
- Lines that start with one of the following characters are considered to be comment lines: / ; \< '
- For table parameters, the first field contains the name of the table (Relay / Discrete Input / Voltage or Current), the second field contains the Modbus register that needs to be polled and the third field contains the custom description of that particular register. For relays and discrete inputs, there is a fourth field, which contains "Equal" or "Inverted". This allows the logic value to be an inversion of the raw value retrieved from the device.
- For standalone parameters, the first field contains the value "Stand-Alone", the second field indicates the parameter ID that will contain the output of the value (which is not the same as the parameter that contains the Modbus address), and the third field indicates the Modbus register that will be polled for this standalone parameter.

Example:

    //
    // Relays Table
    // Relay;Register Address;Name;Equal/Inverted
    Relay; 8192; Sortie relais logo Q1; Equal
    Relay; 8194; Sortie relais logo Q2; Inverted
    Relay; 8195; Sortie relais logo Q3; Equal
    Relay; 8196; Sortie relais logo Q4; Inverted
    //
    // Discrete Inputs Table
    // Discrete Input;Register Address;Name;Equal/Inverted
    Discrete Input; 1; Bouton 5BP1; Equal
    Discrete Input; 2; Bouton 5BP2; Inverted
    Discrete Input; 3; Bouton 5BP3; Equal
    Discrete Input; 4; Bouton 5BP4; Inverted
    Discrete Input; 5; Bouton 5BP5; Equal
    Discrete Input; 6; Bouton 5BP6; Inverted
    Discrete Input; 7; Bouton 5BP7; Equal
    Discrete Input; 8; Bouton 5BP8; Inverted
    //
    // Voltages Table
    // Voltage;Register Address;Name
    Voltage; 528; Tension L1-L2
    Voltage; 529; Tension L2-L3
    Voltage; 530; Tension L1-L3
    Voltage; 531; Tension L1-LN
    Voltage; 532; Tension L2-N
    Voltage; 533; Tension L3-N
    //
    // Currents Table
    // Current;Register Address;Name
    Current; 534; Courant L1
    Current; 535; Courant L2
    Current; 536; Courant L3
    //
    // Stand-Alone Parameters
    // Stand-Alone;Stand-Alone Parameter PID;Register Address
    Stand - Alone; 3100; 537
    Stand - Alone; 3101; 538
    Stand - Alone; 3102; 539
    Stand - Alone; 3103; 540
    Stand - Alone; 3104; 541
