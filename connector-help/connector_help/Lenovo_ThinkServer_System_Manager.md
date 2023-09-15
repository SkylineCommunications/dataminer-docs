---
uid: Connector_help_Lenovo_ThinkServer_System_Manager
---

# Lenovo ThinkServer System Manager

The ThinkSystem System Manager is the management controller for Lenovo ThinkSystem SR635 and SR655 servers. It provides the Intelligent Platform Management Interface (IPMI), H/W monitor, iKVM, VM, and Web-server functionality into a single chip on the server system board.

## About

This connector is used to retrieve the required data from the Lenovo ThinkServer System Manager device.

It uses the Redfish REST API to get all the associated parameters for this type of device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |



### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 8.82                        |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The device API IP Port *(default 443)*

## Usage

General

This page displays the device generic information, which contains the following parameters: **Product Name**, **Manufacturer**, **Server Name**, **UUID**, **Server Serial Number**, **Product ID** and **System ROM.**

### Active Sessions

This page displays a table where the info related to Active Sessions are being shown up. The table contains the following columns: **Index**, **Name**, **Username,** and **Session Type**.

### Connection Setup

The Connection Setup page displays the **User Name** and **Password** text boxes where the credentials information are filled for the HTTP API polling.

### System Information

This page displays contains 9 subpages pages which can be accessed by clicking the following buttons:

- **Processors:** Displays the **Processors Table** which contains the following columns: **Index**, **Name**, **State**, **Health**, **Speed**, **Max** **Speed**, **Total** **Cores**, **Total** **Threads**, **Manufacturer**, **Model**, **Instruction Set**, **Internal L1 Cache**, **Internal L2 Cache** and **Internal L3 Cache**.
- **Memory:** It has one standalone parameter: **Total System Memory.** It also has one table. The **Memory Summary Table,** which has the following parameters: **Index**, **Slot**, **Health**, **State**, **DIMM** **Type**, **Module** **Type**, **Type**, **Size** **GiB**, **Maximum** **Frequency**, **Manufacturer** and **Part Number**.
- **Power:** This Page contains the **Power Supplies** **Table** which has the following parameters: **Index**, **Name**, **Capacity**, **Health**, **State**, **Firmware**, **Hot** **Plug**, **Model**, **Serial** **Number**, **Part** **Number** and **Manufacturer**.
- **Fans:** Displays the **Fans Table** which has the following parameters: **Index**, **Name**, **State**, **Health**, **Location**, **Speed** and **Max Speed**.
- **PCIe Devices:** Displays the **PCIe Devices Table** which contains the following columns: **Index**, **Name**, **Device Type**, **Manufacturer**, **Location**, **Health** and **State**.
- **Firmware:** Displays the **Firmware Inventory Table** which contains the following columns: **Index**, **Firmware Version**, **Release** **Date**, **State**, **Firmware** **Device** and **Description**.
- **Chassis:** Displays the **Chassis Information Table** which contains the following columns: **Index**, **Name**, **Serial** **Number**, **Part** **Number**, **Power** **State**, **State**, **Health**, **Chassis** **Type**, **Location**, **Height**, **LED** **Indicator**, **Manufacturer**, **Model**, **UUID**, **Min** **Power** and **Max** **Power**.
- **Temperatures:** Displays the **Temperature Table** which has the following parameters: **Index**, **Name**, **State**, **Health,** **Location** and **Temperature**.
- **Storage:** Displays the **Storage Table** which has the following parameters: **Index**, **Type**, **Capacity**, **State**, **Encryption** **Status**, **Health**, **Remaining** **Life**, **Rotation** **Speed**, **Temperature**, **Serial** **Number**, **Part** **Number**, **Manufacturer**, **Product** **Name**, **Firmware** **Version** and **SKU**. This page also displays the **Volumes Table** which has the following parameters: **Index**, **Physical** **Drives**, **RAID** **Level** and **Capacity**.

### Event Log

This page displays the **Event Log Table** which contains the following columns: **Index**, **Severity**, **Source**, **Common** **ID**, **Message** and **Date**.

This table provides some configuration options to manage the table:

- **Polling Configuration** - To configure the polling rate of this table for each hour or 5 min.
- **Maximum Number of Entries** - To Limit in size the amount of available rows in the table

### Web Interface

This page displays the Web Interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.


