---
uid: Connector_help_Alpha_XM-2-300HP_DPM
---

# Alpha XM-2-300HP DPM

The **Alpha XM-2-300HP DPM** monitors an Alpha UPS device of type XM-2-300HP DPM.

## About

The **Alpha XM-2-300HP DPM** connector uses SNMP to retrieve data from the device. Tests are automatically executed to determine the health of the UPS and its batteries.

## Installation and Configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Settings**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device.
- **Set community string**: The community string in order to set to the device.

Starting from version 2.0.0.1, a DDNS functionality has been implemented.
When the IP address is 0.0.0.0 then the IP address will be resolved by the DNS server using the hostname. In order to do this, the bus address must have the following syntax: dnsServerIp:hostname

### Configuration

The element will immediately start polling once it is created, but it's nessecary to configure the used batteries and automatic tests.

- Battery Health page: select the used battery config.
- Battery Test Page: configure test interval, duration and execution time.

## Usage

### Main View page

On the main page, the most important information regarding the UPS is displayed

### General page

This page contains general information about the UPS. Most of the items on this page are static, like for instance Number of Subscribers, Address, Region, City, etc.

### Webservices Page

This page contains Webservice parameters such as URL Folder location, Webservice Request URL, Element Creation Address, URL File Location Status, Element Polling Scenario, Webservice HTTP Status Code, Polling IP and Fixed Mac.

Note: The file containing the Webservice address must be named "config.txt" and it must be in the DMA that the element is created in.

### XM-2 page

This page contains all XM-2 power supply related parameters.

### BSS page

On the BSS page, all the battery voltages are available.

### Output page

This page shows the output parameters: voltage, current, power, frequency,...

### Alarms page

The alarms page, contains the alarms that are available on the SNMP agent.

### Battery Test page

This page displays a summary of the last test result of the tests performed by this connector or device. The UPS can run a local test and a remote test which causes the batteries to unload. Both local and remote tests are monitored. By clicking the **Start test** button, you can start a new test on the device.

### Battery Health page

This page allows the operator to determine the health of the UPS and its batteries.

### Input Failure page

The input failure registration table keeps track of all input failure occurrences. It displays when a failure starts, ends, for how long it occurred and how big the impact on the network was. The UPS loses contact with the network when the batteries are fully depleted during an AC Failure. The number of minutes is displayed in the **Impact on Network** parameter. The **Input Failure Registration Summary** table displays a monthly summary. It contains the total duration for the input failure, impact on network and availability parameters for input failure and impact on network.

### Web Interface page

This page displays the web interface of the device.

### Modem Info

This page displays the web interface of the modem.

## Notes

The connector executes some tests on the retrieved data. The results are visible in the element.

### Float State test

The float state parameter is an indication for the health of the batteries and is tested when the charger is in float mode. The individual battery voltages cannot be under a certain threshold, which depends on the temperature while the charger is in float mode.

Possible values: Investigate Battery, Replace Battery, Ok

Formula:

IBthreshold = 13.2 + ( 25 - temperature ) \* 0.0168

RBthreshold = 12.8 + ( 25 - temperature ) \* 0.0168

### Battery Delta Test

The individual battery voltages cannot exceed 0.5Vdc when the inverter is active due to a local or remote test. The individual battery voltages will only be checked when a remote or local test is running. Either the value "Not Tested" will be shown if no test has been performed yet, or the last value will be kept.

Possible values: Ok, Fail, Not Tested

### Battery Cable test

An indication for the status of the cable connected to the batteries. A problem with this cable might occur, resulting in invalid data retrieved from the device. This has an impact on the individual battery voltage: 0 Vdc will be retrieved while there is no problem with the batteries and the parameter that retrieves the number of batteries will show 0, which is invalid. The total battery voltage will still be retrieved correctly. We can conclude that there is a battery cable alarm when the number of batteries is 0, while the total battery voltage is larger than 0 Vdc.

Possible values: Ok, Fail

### Inverter Standby time

The Inverter Standby Time is a theoretical value indicating how long the batteries will last before depletion when they are put to use. This depends on the Total Output Current, and is only calculated when the inverter is off.

### Battery Temperature Holding/Variation

The temperature of the batteries is monitored and the maximum and minimum value are stored respectively in the parameters **Batteries Temperature Max Hold** and **Batteries Temperature Min Hold**. These parameters in turn are also monitored to calculate the Battery Temperature Variation, which is the difference between the Batteries Temperature Max Hold and Batteries Temperature Min Hold.
