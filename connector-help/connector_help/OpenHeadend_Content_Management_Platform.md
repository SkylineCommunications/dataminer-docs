---
uid: Connector_help_OpenHeadend_Content_Management_Platform
---

# OpenHeadend Content Management Platform

The **OpenHeadend Content Management Platform** connector monitors and controls the unit through **SNMP**.

## About

The connector polls relevant information from the device every 2 seconds, 30 seconds or 1 hour. It also receives traps from the device and updates the values accordingly.

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The *polling IP* of the device

SNMP Settings:

- **Port number**: *161*
- **Get community** **string**: *OpenHeadend*
- **Set community string**: **OpenHeadend**

## Usage

This connector has several data display pages.

### System Page

This page displays the server **System ID, Version, Vendor, Time** and **Name**, the **Total Memory, Memory Cache, Free Memory** and **Memory Buffers.**

There are also two tables, which show a **List of CPUs** and **Disks.**

### Links Page

This page displays two user-configurable tables containing the **Network** and **Storage Links.**

### Nodes Page

This page displays information regarding the **Configured Nodes**.

### Functions and Operations Page

This page displays information regarding both the **Configured** **Functions** and **Configured Operations** that are created in the device.

### Schedules and Jobs Page

This page displays information regarding both the **Configured Schedules** and **Configured Jobs** that are created in the device.

### Workflow Page

This page displays information regarding the relationships between the **Configured** **Functions** and **Configured Nodes**, to produce the Function/Node workflow.

### Function Tree Page

This page displays a tree structure for every **Configured Function** showing each **operation** that is related to that particular function.

### Schedule Tree Page

This page displays a tree structure for every **Configured** **Schedule** showing each **job** that is related to that particular schedule.

### Web Interface Page

This page displays the **web interface** of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
