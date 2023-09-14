---
uid: Connector_help_Belgacom_RTCP_Collector
---

# Belgacom RTCP Collector

The **Belgacom RTCP Collector** is part of a CPE setup, where it works together with the **Belgacom CPE Manager** and **Belgacom DB Push Extended**. This particular connector is responsible for collecting the data from the STBs.

## About

This connector will have 2 connections: one RTCP connection and one SSH connection. The RTCP connection will listen to RTCP messages that are sent from the STB. An STB will send its messages to different collector elements, which need to forward the data to the correct element responsible for storing the data of this STB. The SSH connection is used to poll data multithreaded from the STB.

Every day, the collector element will offload its data, which the **Belgacom DB Push Extended** element will then push into a database.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                       |
|------------------|-------------------------------------------------------------------|
| 1.0.0.x          | All firmware versions should be supported with this connector range. |

## Installation and configuration

### Creation

#### Serial RTCP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION

- **IP address/host**: The IP of the DataMiner interface where the RTCP messages are sent.
- **IP port**: The IP port of the DataMiner interface where the RTCP messages are sent.

#### Serial SSH Connection

This connector uses a serial SSH connection and requires the following input during element creation:

SERIAL CONNECTION

- **IP address/host**: A local IP address, which will be changed at runtime. Fill in *127.0.0.1.*
- **IP port**: The SSH port, by default *22.*

### Configuration parameters

The data display pages are not intended to be opened. Instead, the configuration should be performed through a Visio file. Such a file is already available and embedded in the CPE UI. You can access the parameters by clicking on **configuration**. In these sections, the different pages are described.

### Configuration of the SSH parameters

This page contains the **SSH Timeout** parameter, which can be used to configure the timeout time for receiving an SSH response.

### Configuration of the Channel parameters

On this page, you can map a channel IP to a readable channel name.

To add a new channel to the **Channel** **Table**, fill in an *IP:Port* in **New Channel IP:Port** and click the **Add Row** button. A row will be added to the **Channel** **Table**, where you can fill in the **Channel Name** in the matching column. To remove a row, use the **Delete** column.

With the **Synchronize** button, the **Channel Table** can be copied to all other collector elements.

### Configuration of the POP parameters

On this page, you can configure which STBs will be polled with this collector name. A POP will be defined by IP subnets. These IP subnets can be added in the **Subnet Table**.

To add a new IP subnet to the **Subnet Table**, fill in an *IP/Subnet* in **New Subnet IP/Num** and click the **Add Row** button. A row will be added to the **Subnet Table**.

As one collector element cannot contain all the STBs of one POP, the STBs are spread over a number of RTCP collector elements. This is done based on a modulo division of the second last byte of the STB MAC address. With the **POP** parameter, a label can be assigned so that all other elements responsible for the same POP can easily be recognized. **Total POP Elements** indicates with what amount the modulo division calculation should be done. **Sequence Number** indicates the value that the result of the modulo division should match before the STB is added to this collector element.

With the **Synchronize** button, the **Subnet Table** can be copied to all other collector elements that are in the same **POP**.

### Configuration of the Ruleset parameters

On this page, you can configure settings for the different firmware versions.

In the **STB Hardware Table**, the **STB Total Processors** and **STB Total Memory** can be specified per **STB Hardware Version**. To add a new STB to this table, fill in **New STB Hardware**, and then click the **Add Row Hardware** button. To copy the **STB Hardware Table** to all the other collector elements, click the **Sync Hardware** button.

In the **Ruleset Table**, the SSH connection settings can be configured per **HW Version** and **SW Version** combination. To reduce the number of configurations, *DEFAULT* can also be specified as **SW Version**, in which case the connector will use these settings whenever no exact **SW Version** match is found. To add a new row to the **Ruleset Table**, click the **Add Row Ruleset** button. To copy the **Ruleset Table** to all other collector elements, click the **Sync Ruleset** button.

### Configuration of the Oracle parameters

On this page, you can configure the credentials to connect to the Oracle database, used for provisioning. Provisioning can be executed by clicking the **Provisioning** button.

### Configuration of the Offload parameters

On this page, the offload time can be configured with the parameter **Offload UTC Hour of Day**. The offload file locations can be configured in **Extended Offload Location**, for the database offload, and in **Aggregate Offload Location**, for the **Belgacom CPE Manager**.

## Usage

As described above, the data pages are not intended to be used.

If you open the card in Cube, the CPE interface will be displayed, with the STB Entry chain providing a topology view of the account to which an STB is linked.

If you fill in one of the filters, either **STB Exact** with the MAC address, or **Account Number** (on the left side), the topology diagram view is displayed. If you click a KPI item in this diagram view, a pop-up window with parameters opens. In most cases, KPI items of the currently selected item are also displayed below the topology diagram view.

## Notes

As the data pages are not accessible, to provide an easier way to configure the settings, a custom Visio file is available and can be used.
