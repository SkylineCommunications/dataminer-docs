---
uid: Connector_help_Evertz_7780TSM
---

# Evertz 7780TSM

This connector is used to monitor and control the Evertz 7780TSM.

## About

All the monitoring and control information is retrieved via SNMP and displayed in tables.

### Range of the connector

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          |                             |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*

## Usage

### General

General Page contains general information about the device connected like the **Card Type, CPLD Version, IP Address, Netmask, Trap Destination, ...** It's also possible to reboot the card by pushing the button '**Reboot Card**'.

### Input

This page contains three tables:

- The **Input Control Table** displays general information about each input: the **IP Mode, the IP Address, the Port Number,** different **Bit Rates, ...**
- **Input Monitor Table** shows data for parameters such as the **Input state, Number of Programs, Number of know PIDs, TS ID, Network ID, ...**
- The **MDI Monitor Table** displays data regarding the MDI. The table has nine columns and displays the **Delay Factor, Media Loss Rate,** their limits, maximums and ideals.

### Output

The **Output Control Table** on this page provides the following information: **Destination IP Address, Destination Port Number** and **Input Select.**

### PID

This page has one table, the **PID Monitor Table.** This table shows, amongst others, the **PID Number, Type and Info,** the **Program Number** and **Name,** the **Bit Rate** and this **Minimum, Maximum, Thresholds** and **Limit.**

### Switch Control

There are two tables on this page.

- The **Switch Mode** and **Method,** different **Delays (Switch Minimum, Switch Low, Switch Current) and PCR Tolerance** are some columns from the **Clean Switches Table.**
- The **Auto Reset Criteria Table** consists of the **Auto Rest PMT Version, Auto Reste TS ID** and the **Auto Reset Bit Rate.**

### Alarm

The four tables on this page, the **MGMT Faults Table**, **Trigger Faults Table**, **DPI Faults Table** and **Switch Faults Table**, all provide the following information, related to their respective faults:

- **Fault Name**
- **Send Trap** (used to decide if a trap must be sent)
- **Fault Present**

The first three tables each have a toggle button to enable or disable the polling of the table.
A pop-up page with the **Priority Error Monitor Table** will be displayed after the user presses the '**Alarm Configuration..**' button.

### Error Monitoring

The **Error Monitor Table** shows the **Input Status, IP Layer Status, Syntrax Error Status** and the **User Defined Error Status.** This table also had a parameter to disable the table polling.

### CCA and DPI Monitoring Control

On this page two **Monitoring Control Tables** can be found: one for the **CCA** and one for the **DPI.** The columns of these tables are all in function of the monitoring. Examples are the **Start** and **Stop Monitoring, Traps Notify** and different **DPI Message Buffers.**

Two page buttons can be found on this page: '**Packet Loss...'** and **'Misc Control'.**

### SNMP and Trap Configuration

This page contains two tables:

- The **Trap Dest Table** displays the **Trap Dest Index** , **Remove Trap Dest** and **Trap Dest Address**.
- For the card faults, the **Card Faults Table** displays the **Frame Status Index, Send Trap** (to turn trap sending off/on) and the **Fault Present**.

The last table again has a toggle button to enable or disable the polling of the table.

### Port Configuration

This page also contains two tables:

- The **VLAN Config Table** allow the user to configure the **VLAN IP Address, VLAN Net Mask, VLAN ID** and **VLAN Name**.
- The **Network Stats Table** displays the following data about the network: the **Port ID** and **Status**, **Port BW in Use** and information regarding **Input Packets**.

### Web Interface

On this page, you can view the web interface of the device. However, the client machine has to be able to access the device. Otherwise, it will not be possible to open the web interface.

## Notes

Tables 60, 70, 100, 180, 190, 230, 320, 330, 340 and 430 needed to be polled with bulk:1.MultipleGetNext gave error 'Too Big' and GetNext + MultipleGet gave 'TimeOut' error for table 60 and 70.
