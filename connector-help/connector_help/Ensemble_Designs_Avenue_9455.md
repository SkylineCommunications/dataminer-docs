---
uid: Connector_help_Ensemble_Designs_Avenue_9455
---

# Ensemble Designs Avenue 9455

Ensemble Designs Avenue 9455 monitors an Ensemble Frame, which contains only cards of the type 9455. The connector displays key information about the frame and each slot contained in the system.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                  |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Ensemble Designs Avenue 9455 - Slot](xref:Connector_help_Ensemble_Designs_Avenue_9455_-_Slot) |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

When you have created a new element with this connector, specify the number of available slots on the **Slot Management** page.

### Redundancy

There is no redundancy defined.

## How to use

### Frame Information

This page displays relevant information about the frame, also known as Slot 0. This includes the CPU Function, Power Supply 1, Power Supply 2, Cooling Status, and Master Reference.

### Slot Management

This page contains the **Installed Cards** table, which displays each available slot along with relevant information about it.

All the columns are purely informative except for the last two. In the **Switch Position** column, you can select a value from the drop-down list, and in the **Remove Slot** column, you can click a button to remove the slot and the corresponding DVE, as well as disable the SNMP polling for that slot.

### Connection Management

On the left side of this page, you can select the number of available slots, and click a button to refresh all SNMP parameters. You can also find the **SNMP Overview** table here, which displays information about the connection to each slot and allows you to manage these connections.

On the right side of the page, you can use the toggle button to enable or disable the automatic creation of DVEs. You can also find the **Slot DVE** table here. This table contains two columns: the **DVE ID** column, which contains the ID of the created DVE, and the **Alias**, which indicates the name of the DVE.
