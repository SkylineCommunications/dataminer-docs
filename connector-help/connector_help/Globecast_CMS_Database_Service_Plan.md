---
uid: Connector_help_Globecast_CMS_Database_Service_Plan
---

# Globecast CMS Database Service Plan

This connector is designed to manage association between CMS Services and DataMiner Services and their associated elements.

## About

The connector parses XML files in order to apply correct alarm filters and setpoints on the concerned elements divided in 2 categories: QoS probes and QoE probes.

## Installation and Configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

### Configuration of FTP Connection

For the connector to work correctly, you must fill in the following information on the "Configuration" page: the **FTP Server** **IP address** (e.g. *127.0.0.1*), the **FTP Server Login**, the **FTP Server Password**, the **Client File Name** (e.g. *Client.xml*), the **Service File Name** (e.g. *Service.xml*) and the **Service Line-Up File Name** (e.g. *ServiceLine-up.xml*).

## Usage

### Client

On this page, you can find the following parameters: **Tab Clients Last Refresh,** **Tab Clients Last Modified, Tab Clients Count, Tab Clients Missing, Tab Clients New** and the **Clients Table. Tab Clients Missing** and **Tab Clients New** are updated between each change of the associated XML file. The **Clients Table** provides information about the clients such as the **Client Name,** the **Client Status,** the **GOM Link,** etc.

### Service

This page is similar to the Client page, but provides information regarding the Services.

The **Services Table** displays the **Service Monitoring ID**, the **Service Monitoring Admin Status**, the **Service Type**, the **Service Program Id**, etc. It is this table that is responsible for the association between the CMS Services and the DataMiner Services. The **Service Monitoring Admin Status** allows the user to change the monitoring status for each of the services.

### Service Line-up

An important parameter on this page is the **Normalization**, which allows you to disable/enable the **normalization process** (application of the setpoints on the concerned elements).

The **Services Line-Up Table** contains important data, such as the **DVB Service Id,** **DVB Service Rate Min,** **DVB Service Rate Max**, **Pid Video**, **Pid Audio1/2/3/4, Video Rate Min/Max, Audio 1/2/3/4.** Those parameters are used to apply the correct setpoints on the concerned elements.

### QoS and QoE

On this page, you can define the filters values: **Filter QoS Monitoring, Filter Encryption Monitoring, Filter QoE Monitoring, Filter Audio 1/2/3/4.** Those values are user-definable and are used to compose the appropriate **Filter QoS Filter** and **Filter QoE Filter** values.

### Unidentified Client Service

This page displays the DataMiner Services of which **DMA Service Type** property has the value *Client Service Monitoring* (so they should be associated with a CMS Service), but that have no **SIM ServiceId** property, or for which the value of the latter is empty or does not correspond to any of the services listed in the **Services Table**.

### Configuration

This page displays the configuration parameters described in the "Configuration of FTP Connection" section above.

The page also contains the **QoS Probes Table** and the **QoE Probes Table**.

The **QoS Probes Table** is filled in by the user with the following information: the **QoS Protocol Name, Read QoS Filter Id, Read Normalize Service Rate Id, Read Normalize Pid Rate Id, Service Rate Coeff Factor** and **Pid Rate Coeff Factor**. This way, the connector knows which particular protocol it has to search for in the included elements in the DataMiner Services associated to the CMS Services, and which are the PIDs of the parameters to set the **QoS Filter, Normalize Service Rate** and the **Normalize Pid Rate.** The **Service Rate Coeff Factor** and **Pid Rate Coeff Factor** are used to apply a correction value to the setpoints before the sets.

For the **QoE Probes Table**, the only required information is the **QoE Protocol Name** and the **QoE Filter Id.**

Buttons are present to add new rows to those tables, and the rows can be deleted one by one.
