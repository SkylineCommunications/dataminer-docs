---
uid: Connector_help_Alpha_XM-3_UPS
---

# Alpha XM-3 UPS

The **Alpha XM-3 UPS** connector is a generic connector that can be used to monitor Alpha devices in the XM-3 family.

## About

This connector uses **SNMP** to retrieve data from the device. An **HTTP** connection is used to retrieve the IP address of a second network interface. Tests are automatically executed to determine the health of the UPS and its batteries.

### Version Info

| **Range** | **Description**        | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version        | No                  | No                      |
| 2.0.0.x          | Added support for DDNS | No                  | No                      |

## Installation and Configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Device address**: A unique address used by the XM to communicate with the system controller. The format of the bus address is "*\<DNS server\>:\<hostname\>*".

Note:

- In case of an existing IP of the device, fill in the IP and leave the device address empty. Otherwise, set the IP address to 0.0.0.0 and fill in a device address in the format specified above.
- Starting from version 2.0.0.1, DDNS functionality has been implemented. When the IP address is 0.0.0.0, it will be resolved by the DNS server using the hostname. For this to be possible, the bus address must have the following syntax: *dnsServerIp:hostname*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *AlphaGet*.
- **Set community string**: The community string in order to set to the device. The default value is *AlphaSet.*

### Configuration

As soon as it has been created, the element will start polling. However, at this point the used batteries and automatic tests still need to be configured, on the following pages:

- **Battery Health** page: Select the used battery config.
- **Battery Test** page: Configure the test interval, duration and execution time.

## Usage

### Main View page

This page displays the most important information regarding the UPS.

### General page

This page contains general information about the UPS. Most of the items on this page are static.

There are several subpages:

- **SNMP**: Allows you to configure the **Trap Addresses** and the **Access Addresses**.
- **TFPT**: Allows you to configure and monitor the TFTP.
- **Miscellaneous**: Displays general information about the UPS and allows you to configure a number of settings.
- **DDNS**: Allows you to configure the polling interval, timeout polling interval, timeout polling time and fail polling interval.
- **Edit URL**: Allows you to configure the URL of the web service used to retrieve the IP address of a second network interface.

### Webservices Page

This page contains web service parameters such as URL Folder location, **Webservice Request URL, Element Creation Address, URL File Location Status, Element Polling Scenario, Webservice HTTP Status Code, Polling IP and Fixed Mac.**

Note: The file containing the web service address must be named *config.txt* and it must be located on the DMA hosting this element.

### XM-3 page

This page contains general information about the XM-3 power supply. It contains page buttons to the following subpages:

- **Charger:** Allows you to configure settings related to the charger.
- **Protective Interface Module**: Allows you to configure settings related to the **PIS**.

### Apps page

This page displays general information about the installed App card.

There are several subpages:

- **Outages:** Displays information about the duration and frequency of outage events.
- **Sag:** Displays information about the duration and frequency of sag events.
- **Surge:** Displays information about the duration and frequency of surge events.
- **Frequency:** Displays information about the duration and frequency of frequency events.

### BSS page

This page displays all the battery voltages.

### Output page

This page allows you to monitor the current and voltage of the outputs.

- **Current peaks:** Allows you to configure settings related to current peaks.
- **RMS limits** Allows you to configure the RMS limits.

### Alarms page

This page contains the alarms that are available on the SNMP agent.

### Battery Test page

This page displays a summary of the latest test result of the tests performed by this connector or device. The UPS can run a local test and a remote test that causes the batteries to unload. Both the local and remote test are monitored.

To start a new test on the device, click the **Start test** button.

The following page buttons are available:

- **Battery Details:** Allows you to configure maximum and minimum values for the battery.
- **Battery Age:** Displays the age of each of the batteries.
- **Battery Config:** Allows you to do basic tests of the battery.
- **History:** Displays the Battery History table, with basic parameters related to the battery.
- **Scheduler** Allows you to schedule a remote test at a specific time.

### Battery Health page

On this page, you can monitor the health of the UPS and its batteries.

### Input Failure page

On this page, the **Input Failure Registration** table keeps track of all input failure occurrences. It displays when a failure starts and ends, for how long it occurred and how big the impact on the network was.

The UPS loses contact with the network when the batteries are fully depleted during an AC failure. The number of minutes that this occurs is displayed in the **Impact on Network** parameter. The **Input Failure Registration Summary** table displays a monthly summary. It contains the total duration for the input failure, the impact on the network, and availability parameters for input failure and impact on network.

The page contains one subpage, **System Downtime**, which allows you to configure the maximum and minimum timeout time.

### Web Interface page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The connector executes some tests on the retrieved data, and displays the results in the element.

### Float State test

The float state parameter is an indication of the health of the batteries and is tested when the charger is in float mode. The individual battery voltages cannot be lower than a certain threshold, which depends on the temperature while the charger is in float mode.

Possible values: *Investigate Battery*, *Replace Battery*, *Ok*.

Formula:

- IBthreshold = 13.2 + ( 25 - temperature ) \* 0.0168
- RBthreshold = 12.8 + ( 25 - temperature ) \* 0.0168

### Battery Delta Test

The individual battery voltages may not exceed 0.5 Vdc when the inverter is active due to a local or remote test. The individual battery voltages will only be checked when a remote or local test is running. Either the value *Not Tested* will be displayed if no test has been performed yet, or the most recent value will be kept.

Possible values: *Ok*, *Fail*, *Not Tested*.

### Battery Cable test

This parameter indicates the status of the cable connected to the batteries. If a problem occurs with this cable, this results in invalid data being retrieved from the device. This has an impact on the individual battery voltage: 0 Vdc will be retrieved while there is no problem with the batteries, and the parameter that retrieves the number of batteries will show 0, which is invalid. The total battery voltage will still be retrieved correctly. As such, there is a battery cable alarm when the number of batteries is 0, while the total battery voltage is larger than 0 Vdc.

Possible values: *Ok*, *Fail*.

### Inverter Standby time

This parameter displays a theoretical value indicating how long the batteries will last before depletion when they are put to use. This depends on the **Total Output Current**, and is only calculated when the inverter is off.

### Battery Temperature Holding/Variation

The temperature of the batteries is monitored and the maximum and minimum value are stored respectively in the parameters **Batteries Temperature Max Hold** and **Batteries Temperature Min Hold**. These parameters in turn are also monitored to calculate the **Battery Temperature Variation**, which is the difference between the Batteries Temperature Max Hold and Batteries Temperature Min Hold.
