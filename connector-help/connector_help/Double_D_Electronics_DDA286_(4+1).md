---
uid: Connector_help_Double_D_Electronics_DDA286_(4+1)
---

# Double D Electronics DDA286 (4+1)

The connector monitors the activity of the **Double D Electronics DDA286 (4+1)** controller.

## About

The connector has a serial communication to the **Double D Electronics DDA286 (4+1)** and allows the end user to control and monitor the switch configuration.

In addition to the previous, the connector uses two timers: one polling every 10 seconds that retrieves general information from the device and its switches and one that polls every hour for slowly varying information.

### Version Info

| Range            | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Initial version. | -           | -                |

### Product Info

| Range | Supported Firmware |
|-----------|------------------------|
| 1.0.0.x   | DDA286 V1.15           |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | -                    | -                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

## General Page

On the general page, the user can observe some general information from the device on the left such as the **Software Version**, the **Device Name**; the **Maximum Number of Supported Switches** and the **Maximum Number of Supported Chains**.

In addition to the previous, the user can define the device's mode (**Global Device Mode**) and its respective **Control Mode**.

At the right of the page the user can observe if there's any existing alarms regarding: **Active Alarms; Unacknowledged Alarms; PSU 1** and **PSU 2 Alarm.**

### Switches

On this page, the **Status of Switch 1** can be viewed. The user can also configure the **Switches 1 - 4** to Primary or Backup Mode and the **Chains 1 - 4** to Antenna or Load.

### Chain 1 - 2

On this page, the **Status of Chain 1** and **2** can be viewed, such as the **HPA status**, the fault of the **HPA Comms**, **HPA Low Power**, **Up Converter Comms**, the alarms of the **HPA Input**, **Chain Summary**, **Auxiliary**, **Equaliser** and **Up Converter**. The user can also monitor if the chain is **muted** or in **maintenance**.

### Chain 3 - 4

On this page, the **Status of Chain 3** and **4** can be viewed, such as the **HPA status**, the fault of the **HPA Comms**, **HPA Low Power**, **Up Converter Comms**, the alarms of the **HPA Input**, **Chain Summary**, **Auxiliary**, **Equaliser** and **Up Converter**. The user can also monitor if the chain is **muted** or in **maintenance**.

### Chain Standby

On this page, the **Status of the Standby Chain** can be viewed, such as the **HPA status**, the fault of the **HPA Comms**, **HPA Low Power**, **Up Converter Comms**, the alarms of the **HPA Input**, **Chain Summary**, **Auxiliary**, **Equaliser** and **Up Converter**. The user can also monitor if the chain is **muted** or in **maintenance**.
