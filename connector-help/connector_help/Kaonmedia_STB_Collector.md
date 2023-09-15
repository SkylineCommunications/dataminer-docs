---
uid: Connector_help_Kaonmedia_STB_Collector
---

# Kaonmedia STB Collector

The **Kaonmedia STB Collector** connector is used to monitor Kaonmedia set-top boxes (STBs).

## About

This connector uses the **HTTP** interface in order to collect data from a web service.

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **Type of port:** TCP/IP
- **IP address/host:** [http://localhost](/)
- **IP port:** Port used for communication. By default *80*, but we advise to change this to *+1024*.
- **Bus address** *bypassproxy*

### Configuration

- **Web service:** Install the web service on the DataMiner server. The Web.config XML file contains credentials to communicate with DataMiner. If necessary, create a new user with these credentials (and with sufficient rights). Here you can also configure the buffer size of the web service. Extra logging can be found in `C:\Webservice`.

- **STB Collector**:

  1. Create a number of elements and configure a unique **STB Collector Number** (1..254) for each element, as well as the **Total Number of Collectors**. Restart all elements afterwards.

  2. Webservice Manager: Select *Yes* for one STB Collector element running on the server hosting the web service. This element will request data from the web service.

## Usage

### CPE Interface

This interface contains two pages that can be used to search for an STB. The **STB ID page** uses the STB ID as a filter, the **MAC page** uses the MAC address.

When you search for an STB, you need to enter the full name. If the STB is found, you will see a visual overview of the STB with the attached cell. Below this visual overview, you can find all **KPIs** of the STB, for example **HW Version**, **SW Version**, **Uptime**, **State** (active or standby), **AV State** (Ok or Blocked), **SNR**, **BER**, **PER**, etc.

The KPIs are not refreshed automatically. To refresh the KPIs, click the STB object in the visual overview again. The **STB Last Update Time** displays the date and time when the KPIs were last refreshed.

The following commands can be sent to the STB:

- **Delete**: Deletes the STB from the CPE Interface. The STB is automatically added if new data is retrieved for it.
- **AV Block**: Sends Block ON or Block OFF to the STB. This state can be checked in the AV State (*Ok* or *Blocked*).
- **Reboot**: Reboots the STB.
- **Interval**: Sets the reset interval time of the STB. This timespan defines the speed at which the STB pushes its control commands. (The default value is 120s.) The STB saves this value in memory. When a Factory Reset is executed or new firmware is installed, this value is reset.

### Adding new STB Collectors

To add or remove STB Collector elements, reconfigure the **Collector Number** and **Total Number of Collectors**, and then click **Redetect STBs**. This will reschedule all existing STBs towards the different elements based on their MAC address. However, note that if an STB is moved to another element, you will lose all existing trend data.

With **Backup STB Files**, you can create a CSV file on a configured file location, listing all existing STBs. This file will contain MAC address, STB ID and Serial ID.

## Manager config

### Firmware

To add new firmware versions, right-click the firmware table and select **Add Firmware**. When you have added a new entry, it will only be displayed after you re-open the element card. You will then need to right-click and select **Sync Table** to forward the entire firmware table towards all collector elements.

The **HW Version/FW Device Type** should contain the hardware version or the device type:

- **Hardware Version**: If you click \`Force Update' for a single CM, the first URL related to its hardware version that can be found in the firmware table will be used in order to start the update.
- **Device Type**: For the stbVer API, if the firmware table has the device type in the first column, and the same device type is found, the connector checks if current_ver is lower than what is configured in the firmware table. If it is, the new URL is sent.

### Notification

To add a new notice, right-click the notice table and select **Add Notice**. When you have added a new entry, it will only be displayed after you re-open the element card. You will then need to right-click and select **Sync Table** to forward the entire firmware table towards all collector elements.

### Channel List/EPG

To import the Channel List and EPG file, you first need to configure the correct path where these files are located.

- Import the Channel List by clicking the **Import Channel List** button. To view the list of imported channels, click the **Channel List** page button.
- Load a new EPG file by right-clicking the EPG Table and selecting **Load EPG**. When you have added a new entry, it will only be displayed after you re-open the element card. You will then need to right-click and select **Sync Table** to forward the entire firmware table towards all collector elements.
