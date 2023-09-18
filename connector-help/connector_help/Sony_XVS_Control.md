---
uid: Connector_help_Sony_XVS_Control
---

# Sony XVS Control

This connector uses the Serial Tally communication protocol to control either a Sony XVS-G1 live production switcher or one of the former Sony XVS systems.

### Version Info

| **Range**            | **Key Features**                                                                                                                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | 2-1. M/E Xpt (Write/Read) 4. Key (Write/Read) 8. Snapshot (Write) 9. Key Snapshot (Write) 10. Macro Control (Write) 12-4. Source Name Setup (Read) | \-           | \-                |

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

#### TCP Connection - Tally Protocol

This connector uses a serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *2021*).
  - **Bus address**: The bus address of the device.

### Initialization

No additional configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### M/E Xpoints

You can set crosspoints in a matrix control. The information about the destinations and sources is also displayed in separate tables. With the destinations table, you can change the connected input by setting a different source number.

### Bus Key States

Each individual state is displayed.

### Snapshots and Macro Control

This information is displayed in tables where you can manage presets of different kinds, which function in similar ways.

You can **add a preset** using the page button at the top of each table. Before saving the preset in the table, you can check if the preset works by clicking **Test Exec**. Feedback of the operation is provided in the UI.

You can **edit an existing preset** by right-clicking it in the table and selecting **Copy to Editor**. A pop-up message with further instructions will be displayed. After you have clicked Copy to Editor, use the above-mentioned preset page button to edit the preset instead of adding it. Note that changing the preset name is not supported through this workflow. If you change the name, a new preset will be added instead. You can only edit a preset name by changing it directly in the table. Duplicate names are not allowed.
