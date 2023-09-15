---
uid: Connector_help_Alpha_XM-2_DSM
---

# Alpha XM-2 DSM

The Alpha XM-2 DSM monitors devices of the series XM-2 DSM. This protocol not only allows you to monitor and interact with the connected devices via SNMP, but also opens a second HTTP interface that facilitates the access to the Alpha Web Services, from which a second IP is retrieved and used to obtain more SNMP parameters.

## About

Through SNMP, this protocol retrieves parameters such as the voltage and current levels. It also runs multiple tests to determine the overall performance and state of the UPS device and its batteries.

In version 2.1.2.29, an extra feature is introduced that allows the use of a POST call to the Alpha Web Services (HTTP) from which IPs are retrieved within the body or the HTTP response. These IPs are used to perform other SNMP calls to fetch additional parameters such as the cable modem (CM) Receive Level and Transmit Level.

### Version Info

| **Range**     | **Description**              | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------|---------------------|-------------------------|
| 1.1.0.x              | Release version              | No                  | No                      |
| 2.1.0.x              | Adjusts Float and Delta Test | No                  | No                      |
| 2.1.2.x \[SLC Main\] | Introduces DDNS and Others   | No                  | Yes                     |

## Installation and Configuration

### Creation

This protocol makes use of SNMP and HTTP connections to transmit and get the necessary values. However, the HTTP connection is not declared as a native session within the protocol. Instead, the POST request that is sent to the web is implemented via a QAction.

#### SNMP First Connection

This connection requires the following input during element creation:

SNMP First Connection:

- **IP address/host**: The polling IP of the device, e.g.10.255.110.14.
- **Device address**: The device location at the specified IP, e.g. *172.16.0.10:x1-6-00-90-EA-A0-A5-94.pl.hms.aorta.net*.

SNMP First Connection Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *mo2cpe12*. Default value: *public.*
- **Set community string**: The community string used when setting values on the device, e.g. *mo2cpe12*. Default value: *private*.

#### HTTP Connection

Note that this is not a declared connection inside the protocol. This connection exists through a QAction and is established via a SOAP call, e.g. soap:Envelope.

HTTP Connection:

- **IP address/host**: The polling IP or URL of the destination, e.g. <http://172.16.24.xxx/AlphaWebservice/alpha.asmx>
- **IP port**: The IP port of the destination, e.g. 80
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

#### SNMP Second Connection

Note that this connection does not require any input during element creation. The IP used to connect to the SNMP device is received in the body of the response coming from the HTTP connection.

If there is a timeout on the first SNMP connection, this second connection will not be polled. If there is a timeout on this second connection, the SOAP request will be sent again to retrieve a new IP, after which polling will continue.

SNMP Second Connection:

- **IP address/host**: The polling IP of the device received in the body of the POST response, e.g. *\<GetAlphaCmIpbyCpeResult\>10.215.46.158\</GetAlphaCmIpbyCpeResult\>.*

### Configuration

As soon as it has been created, the element will start polling. However, at this point the used batteries and automatic tests still need to be configured, on the following pages:

- **Battery Health** page: Select the used battery config.
- **Battery Test** Page: Configure the test interval, duration and execution time.

## Usage

### Main Page

This page displays the most important information regarding the UPS.

### Output Page

This page displays the output parameters: Current, Voltage, Load, etc.

### General Page

This page contains general information about the UPS device, such as its IP Address, Mac Address, Number of Batteries connected, etc.

### DDNS Page

This page contains the DDNS parameters, such as DDNS Polling Intervals, DDNS Timeout Polling Interval, etc.

Note: The file containing the web service address must be named *config.txt* and it must be located on the DMA hosting the element.

### Batteries Page

This page displays information about the batteries, such as the Total Battery Voltage and Battery Temperature, as well as a range of critical indicators such as Batteries Temperature Max Hold.

### Test Page

This page displays a summary of the last test result of the tests performed by this connector or device. The UPS can run a local test and a remote test that causes the batteries to unload. Both the local and remote test are monitored.

To start a new test on the device, click the **Start test** button.

From version 2.1.2.29 onwards, you can also stop a battery test by clicking the **Stop Test** button.

### Test Config

This page displays the status of the local, remote, and self battery tests as *Enabled*, *Disabled* or *Not Initialized*.

Note that if you stop a test with the Stop Test button, these parameters will be set to *Disabled*.

### Battery Details Page

This page displays detailed battery information such as the Maximum Battery Voltage Difference, as well as thresholds for the minimum voltage values for each battery.

### Battery Age Page

This page contains information about how long the batteries have been in use.

### History Page

This page displays the history for the different types of tests. You can delete each entry in the table individually, or delete the entries in bulk with the Remove All button.

### Scheduler Page

This page displays the frequency at which certain tests are run, e.g. the self test intervals.

### Input Failure Page

On this page, the **Input Failure Registration** table keeps track of all input failure occurrences. It displays when a failure starts and ends, for how long it occurred and how big the impact on the network was.

The UPS loses contact with the network when the batteries are fully depleted during an AC failure. The number of minutes that this occurs is displayed in the **Impact on Network** parameter. The **Input Failure Registration Summary** table displays a monthly summary. It contains the total duration for the input failure, the impact on the network, and availability parameters for input failure and impact on network.

### Cable Modem

This page shows parameters related to the HTTP connection, such as the HTTP Status Code, the URL sent in the request, and the IP that was retrieved from the SOAP call.

This page also shows the cable modem (CM) parameters that were retrieved using the second SNMP connection: CM Receive Level, CM Transmit Level, CM Signal Noise, and Cable Modem SW Revision.

### Web Services Page

This page contains web service parameters such as URL Folder location, **Webservice Request URL, Element Creation Address, URL File Location Status, Element Polling Scenario, Webservice HTTP Status Code, Polling IP and Fixed Mac.**

The **URL Folder** location should contain a file called *config.txt*. This file should contain a single line of text with the **Request URL**, which is used to retrieve the **CM IP Address** used to poll the cable modem parameters.

### Edit URL

This page can be used to manually adjust the **Request URL.**
