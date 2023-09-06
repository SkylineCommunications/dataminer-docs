---
uid: Connector_help_Satec_PM130_Plus
---

# Satec PM130 Plus

The PM130 PLUS is a compact, multi-function, three-phase AC power meter, designed to meet the requirements of users ranging from electrical panel builders to substation operators.

## About

### Version Info

| **Range**            | **Key Features**               | **Based on** | **System Impact** |
|----------------------|--------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | General monitoring parameters. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600*.
  - **Databits**: Databits specified in the manual of the device, e.g. *7*.
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1*.
  - **Parity**: Parity specified in the manual of the device, e.g. *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No*.

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element generated with this driver consists of the following data pages:

- **General**: Displays the majority of the power meter parameters, such as parameters related to **tension**, **amperage**, **power**, **energy**, etc.
- **Device Info**: Displays the **COM1** and **COM2** communication information, i.e. the **Protocol**, **Interface**, **Address** and **Baud** **Rate**. The **MAC** **Address**, **IP** **Address** and **Default** **Gateway** are also displayed on this page.
- **Basic Reading**: Displays the basic readings of the three-phase AC power meter: **Neutral Tension**, **Power in Watts**, **Amperage** and **Power Factor** for phases 1 to 3.
- **Energy**: Displays the current **Active** **Tariff** and the **Energy** values for all three tariffs, in **kWh** and in **kVArh**, as well as the **Total** **Energy** value in **kWh**, **kVArh** and in **kVAh**.
- **Phasor**: Displays the **Neutral** **Tension** and **Amperage** for phases 1 to 3, as well as the **Tension 1 - 3 Phase** and **Amperage 1 - 3 Phase**.
- **Phase 1 - 3**: These pages display the **Phase 1 - 3 Tension**, **Neutral** **Tension**, **Amperage**, **Power** in **Watts**, **VA** and **VAr**, **Phase 1 - 3 THD** and **Current 1 - 3 THD.**
