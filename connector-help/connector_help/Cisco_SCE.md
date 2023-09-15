---
uid: Connector_help_Cisco_SCE
---

# Cisco SCE

The **Cisco SCE** connector can be used to display and configure information of the Cisco SCE platform.

## About

This protocol can be used to monitor and control the **Cisco SCE** platform. With the protocol, you can connect to the device's database in order to gather information regarding the subscribers' usage.

The protocol also has **alarming** and **trending**.

## Installation and configuration

### Creation

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.107.128.38*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as:

- **Model**
- **System Name**
- **System Uptime**
- Etc.

The page also contains a page button, **Database Connection**, that allows you to fill in the **Database Name, Database IP Address, Database Username** and **Database** **Password**. In order to be able to use the database, you must make sure this information is filled in.

### Module Info

This page displays a table containing information regarding the device **Modules**, such as:

- **Slot Number**
- **Module Type**
- **Module Admin State**

The page also contains a drop-down list, **Select Module**, where you can select the desired module. The information of the selected module will appear under the page button **HW Version**.

### Interface and Link Info

This page allows you to check the **Interfaces** on the device. It contains a table with information about the interfaces and a table with the **Link** information.

### Service Info

This page displays information regarding the available services and the statistics related to these services, for example:

- **Service Upstream Usage**
- **Service Downstream Usage**
- **Service Duration**
- Etc.

### Global Service Info

On this page, you can check the current state of the **Serve Counters**: *Enabled* or *Disabled***.**

### Subscriber Usage

This page has a tree control view that shows, on the first level, the total usage values for each subscriber, and on the second level, the total usage values for each subscriber in each available service. The tree control also displays the package associated with each subscriber

This page also contains a page button, **Annual Statistics**, which displays a table with the monthly usage for each subscriber in the last year.
