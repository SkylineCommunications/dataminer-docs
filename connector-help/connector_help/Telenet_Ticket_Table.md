---
uid: Connector_help_Telenet_Ticket_Table
---

# Telenet Ticket Table

The **Telenet Ticket Table** connector is part of the **SAM** system. It is the link between alarms on **DataMiner** and other connectors that will generate tickets. This connector will retrieve an update of the current alarms and group them into tickets. It will trigger the Automation scripts to create, update or close a ticket.

## About

The **Telenet Ticket Table** will retrieve a list of the **current active alarms** that need a ticket. The alarms will be linked to a specific **ticket topology**. Each of these groups will trigger a flow that will **create**, **update** or **close** a ticket. The timing of these triggers can be configured. However, there is a built-in priority to creation of a ticket.

### Version Info

| **Range**            | **Key Features**                                                                                                                                  | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                                                                                                  | \-           | \-                |
| 2.0.0.x              | New topology binding.                                                                                                                             | 1.0.0.x      | \-                |
| 2.0.1.x \[SLC Main\] | QActions triggered on row change of a specific table cell will be replaced by triggers on standalone parameters where the update needs to be set. | 2.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 2.0.1.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

### Process Tickets

Delays need to be configured on **Create**, **Update** and **Close**. These delays indicate how long an alarm or ticket needs to exist before the command is sent. For "Close", the delay takes place after all linked alarms are gone.

A retry can be configured for when a **script** fails to start the flow to **create**, **update** or **close** a ticket.

In case of a specific **Not Owner** error on **creation** or **update** of a ticket, it is possible to determine a delay before a retry is done.

To run a flow, a **script** is started. This flow could take some time. To keep a limit on the currently running scripts, you can configure this in **Max Running Scripts**.

To keep track of the life cycle of the connector, you can add the **DMA/Element ID** of the **heartbeat element**.

There is a limit on the number of tickets that can be created or scheduled, i.e. the **Max Trouble Ticket Count.** This needs to be configured via the **Event Storm** page button.

### Redundancy

There is no redundancy defined.

## How to use

When the connector has been configured as detailed above, it will run automatically based on the input of the alarms. The current situation can be monitored.

## Notes

The connector will only work in a **SAM** system containing extra connectors and **Automation scripts**
