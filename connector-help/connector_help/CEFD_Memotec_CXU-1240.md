---
uid: Connector_help_CEFD_Memotec_CXU-1240
---

# CEFD MEMOTEC CXU-1240

This is an SNMP connector for the configuration and monitoring of the following types of devices:

- CXU-1240
- CXU-1010

## About

The connector is used to configure a CXU-1240/CXU-1010.

## Configuration and Installation

### Creation

This connector uses a Simple Network Management Protocol (**SNMP**) connection and needs following user information:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*

**SNMP Settings**:

- **Port number**: the port of the connected device, default *161*
- **Get community string**: the community string in order to read from the device. The default value is *public*.
- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

Once all configurations are done, this connector will work stand alone.

## General

This page contains some general data concerning the device.

With the button **Clear temperature statistics**, it is possible to clear the temperature parameters

## Admin

This page contains standard administrator parameter such as the location and name of the device.

With the button **Reboot unit**, it is possible to reboot the device.
When pressing the button **Save Configuration**, The System parameters will be saved to the device.

On this page it is also possible to switch to the redundant unit and to set the SNMP Trap Destination address.

## Configuration - Network

Here it is possible to find the current network settings.

It is possible to change these setting by clicking on the **Modify.** page
A new page will pop up where it is possible to fill in the new values for the parameters.
Once this has been done click on the **Apply** button to apply these settings to the device.

Configuration - E1 Ports Page
On this page you will find the configurations of the E1 ports.
Here you can configure everything concerning the E1 Ports.

On the bottom of the page you will also find the possibility to change the jitter buffer Depth.

**Note**: settings done on this page will immediately be applied to the device.

## Configuration - Wan interfaces

On this page you will find the configuration of the Wan Interfaces
Here you can configure the Traffic channels.
It is possible to delete an entry from the table by clicking the **Delete** button of the corresponding row.

For creating a new entry in the Traffic channel Table click on the **Create New Entry.** button located at the bottom of the page. Fill in the Different Parameters.
Press **Apply** to add the new entry to the table.

**Note**: when the maximum number of entries is reached. It is not possible to add a new entry and therefore a row should first be deleted.

## Configuration - Clocking

On this page you will find the Settings of the Clocking Configuration.
For changing these parameters click on the **Modify.** button.
A new window will pop up where you can change the selected settings.
When clicking the **Apply** button, these settings will be applied to the device.

## Configuration - Redundancy

On this page you will find the settings of the clocking configuration. For changing these parameters click on the **Modify.** button. A new page will pop up where you can change these settings.
When clicking the **Apply** button, the new settings will be applied to the device.

## Statistics - Network

On this page you are able to find the statistics of the network interface.

With the **clear** button it is possible to clear the network statistics.

## Statistics - E1 Ports

On this page you are able to find the statistics of theE1 Ports.

With the **clear** button it is possible to clear the corresponding row.


## Performance monitoring E1 Ports

On this page you are able to find the performance statistics of the device.

When clicking the **Intervals.** button a new page will pop up where it is possible to select a port and interval to view the performance statistics of up to a day ago in blocks of 15 min.
Pressing the next will shift the interval by one and get the new data.

Example:
For selecting the interval of 45 minutes ago on E1 Port 2.

- Select under the parameter E1 Port: Port 2
- Set the interval to 3 (3\*15min = 45 min ago.)
- Press the **Get** button.


## Statistics - Wan Interfaces

On this page you are able to find the statistics of the Wan interfaces.

With the **clear** button it is possible to clear the corresponding row.

## Statistics - Optimization

On this page you are able to find the statistics of the optimization of the device.

Pressing the **Clear** button will clear TX and RX Savings.

## E1 Ports Table

With the **Clear** button it is possible to clear the corresponding row.

When clicking on **Select E1 Port** and then clicking on the button **Mapping.** this will open a window with the Timeslots of the selected E1 Port.
It is also possible to select the E1 port by changing the E1 Port Selected parameter located on the top of the page.

You can refresh the Timeslots by clicking on the **Refresh** button located at the bottom of the page.

## Statistics - Clocking

On this page you are able to find the statistics of the clocking of the device.

With the **Reset** button it is possible to reset the statistics.

## Statistics - Redundancy

On this page you are able to find the redundancy statistics

With the **Reset** button it is possible to reset the statistics.

## Traps

on this page you can see the traps that have been received from the device.

It is possible to delete a entry by pressing the **Delete** button on the corresponding row.
For deleting all entries from the table click on the **Clear Table** button located at the bottom of the page.
