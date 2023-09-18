---
uid: Connector_help_Telenet_Mail_Processor
---

# Telenet Mail Processor

The **Telenet Mail Processor** is part of the **SAM** project and will collect emails and create/update/close tickets accordingly.

This connector will fetch and process specific emails. According to the email, a flow is started to create/update/close a ticket via the **SAM** drivers and scripts (e.g. **Telenet Ticket Gateway**). The results of these processed emails are available.

## About

### Version Info

| **Range**            | **Key Features**                              | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Integrates mail processing into SAM's system. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **General page**, there are several **page buttons** that need extra configuration.

Via the **Configuration** page button, you can set the email settings. This includes the **server**, **port**, **user**, etc. but also the linked **Elements** in the **SAM** project:

- **Ticket Gateway**
- **Heartbeat**
- **Topology**

Via the **Masterdata** page button, you can define keywords that will be used in the ticket.

### Redundancy

There is no redundancy defined.

## How to use

The **General page** will provide an overview of all the emails and their process state. It also shows the time and number of emails that where last processed.
As this connector is part of a system of different connectors, the heartbeat check on the **Ticket Gateway** is also displayed.
