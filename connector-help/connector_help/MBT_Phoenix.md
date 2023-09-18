---
uid: Connector_help_MBT_Phoenix
---

# MBT Phoenix

The **MBT Phoenix** connector is a smart-serial and **http** connector. The connector has 2 **smart-serial** connections to communicate with 2 different **MBT clients**. The connector also uses a **http** connection to check if a file has been created on the **ftp** server.

## About

The connector will be used to **schedule** the **extracting** or **blanking** according to which command was received from the **MBT client(s)**. When a **"Recording"** command is received from the **MBT client**, the connector will control the **extraction** of the specified files from the **Origin Server** to a **Network Storage**. If a **"Blanking"** command is received, the connector will control the **blanking** for the specified **stream**.

It will also be possible to **manually** specify **extraction** or **blanking**. This will be done by using the **Visio** file that is used with this connector. This connector creates **schedule tasks** for the **extraction** and **blanking**. This way, it is very easy to check when the **recording** or **blanking** will start and when it will be finished.

## Installation and configuration

### Connections

#### Smart-Serial connections

This connector uses 2 smart-serial connections and requires the following input during element creation:

SERIAL CONNECTION (Connected for MBT A):

- IP address/host: The polling IP of the device.
- IP port: The IP port of the device.

MBTB (Connected for MBT B):

- IP address/host: The polling IP of the device.
- IP port: The IP port of the device.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION (Connection for FTP server):

- IP address/host: The polling IP or URL of the destination.
- IP port: The IP port of the destination, default *80*.
- Bus address: If the proxy server has to be bypassed, default *bypassproxy*.

### Extra configurations

There is some extra configuration that needs to be done before the connector can work correctly. This needs to be done on the **Configuration** page. The settings that need to be done, are explained in more detail on the **Usage \> Configuration** section of this document.

## Usage

### General

The **general** page only displays 3 parameters. The **Operation Mode** can either be *Nominal* or *Degraded*. This can be changed by the user. By default, the **Operation Mode** will be set to *Nominal*. If the **Operation Mode** is set to *nominal*, both **MBT clients** will use the **IPPU(s)** from **Ippu Table 1**. If the **Operation Mode** is set to *Degraded*, the first **MBT client** will use the **IPPU(s)** from **Ippu Table 1** and the second **MBT client** will use **IPPU(s)** from **Ippu Table 2**.

The other 2 parameters on the **general** page are **Channel 1** and **Channel 2**. **Channel 1** displays the channel that is specified in the command received from **MBT client 1**. **Channel 2** will display the channel specified in the command received from **MBT client 2**.

### Configuration

The **configuration** page displays the **configurations** that can be changed by the user. The **DCM Element Name** parameter needs to be set with the name of the *Cisco DCM Element* that is used for the **blanking**. The other element names that need to be set are displayed in the **MBT Table**. Currently, this connector supports 2 **MBT clients**, the names of the *Avenia elements* (**Avenia Element Name**) need to be set in the **MBT Table**.

The **Logging Duration Time** displays the number of days that the recording or blanking information will be stored in the corresponding tables. The **Recording Timeout Time** displays the number of hours it will take before a recording is timed out.

Another important configuration is the **Blanking Delay** and the **Recording Delay**. These delays are added to the **TC** value received in either the **blanking** or **recording** commands. The delays are implemented to compensate for the **video latency** in the delivery chain. If these delays are not configured, the **TC** value from the command will be used.

The other configuration parameters that are displayed on this page are the **Right Service ID** for MBT client 1 and 2 and the **Incident Service ID** for MBT client 1 and 2.

The **MBC Credentials** page can be accessed from the **MBC Credentials** page button on this page. These credentials are used by the soap call sent to MBC when the recording is available.

The **Life Message Threshold** configuration is check the **MBT A Life Status** and **MBT B Life Status**, which are available on the **Status** page. The status will be update to **"Failed"** when no life message was received for the MBT for a duration longer than the **Life Message Threshold**.

### Status

The Status page displays status information about the connected MBTs. The left side of the page displays if the MBT A and MBT B client are connected. If they are connected, then their IP address will be displayed in the MBT A Connected IP and MBT B Connected IP parameter respectively.

The status parameters on the right side indicate if the life messages are still being received from the MBT clients.

### IPPU

The **IPPU** page displays the **IPPU table 1** and **2**. The IPPUs also need to be added **manually** by the user before the commands received from one of the **MBT clients** will be processed. The IPPUs can be added by using the **Add IPPU** button. Clicking this button will open a separate page where 3 parameters need to be set: the **IPPU Name**, the **Service Number for Origin Server** and the **Service Number for Blanking DCM**. When the **Add IPPU Table 1** or **Add IPPU Table 2** button is clicked, the row in the corresponding table will be added.

### Recording

The **recording** page displays the **Record Table**. This table has an entry for each **record** that has or will be **extracted**. This table contains information about the **time**, **channel**, **status**, **MBT client**.

### Blanking

The **blanking** page is similar to the **recording** page, but the **blanking** page displays the **Blanking Table**.

### Log

The **Log** page displays the **Log Table**. This table can be used to **configure the information messages** that are displayed when a **recording** or **blanking** command is received and processed.

### Advanced

The **advanced** page contains information that can be used to debug certain parts of the connector. Some of these parameters will also be used by the Visio to display extra information.
