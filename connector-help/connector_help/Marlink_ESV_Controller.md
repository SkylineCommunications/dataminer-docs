---
uid: Connector_help_Marlink_ESV_Controller
---

# Marlink ESV Controller

The **Marlink ESV Controller** keeps track of the position of all vessels, their connection to the satellites, and their communication speed.

## About

The **Marlink ESV Controller** connector makes it possible to monitor the position of vessels and the speed of their connection with the satellite network.

The data comes in through HTTP requests and is parsed by DataMiner. All data in the ESV controller is used in the **Marlink 7 Seas Manager**.

Coordinates of the vessels are also forwarded to the **Weather Retriever** element. In this element the weather conditions will be matched to that specific location of the vessel.

## Installation and configuration

### Creation

**HTTP connection:**

- **IP address/host**: The polling IP of the device, e.g. *27.96.104.57*.
- **IP Port**: The polling IP port of the device, e.g. *443.*
- **Bus Address**: If there are problems with the proxy server on the DMA, specify "*byPassProxy*".

## Usage

### General Page

The **General** page displays the **ESV ID** and **Installation ID**. In addition, there are some general parameters such as **Avg Eb/No**, **Min Eb/No**, **Avg Tx Power Level Increase**, **Max Tx Power Level Increase**, **Latitude**, **Longitude**, **Tx**, **Bandwidth**. These parameters allow monitoring and trending.

You can also select which kind of **Installation Type** it is. Options are: "*Single Installation*", "*Subsystem Starboard*" or "*Subsystem Portside*". Depending on this setting, a different HTTP request will be sent.

### Modem page

This page contains a table with all the modem data. Important columns in this table are: **Time (Modem)**, **Avg Eb/No**, **Min Eb/No**, **Avg Tx Power Level Increase** and **Max Tx Power Level Increase**.

### ACU page

This page contains a table with all the ACU data. Important columns in this table are: **Time (ACU)**, **Latitudes**, **Longitudes**, **Bandwidths** and **State**.

### Satellite Link Details page

This page displays information from the operational database of Arve.

Three tables are available:

- Satellite Link Active
- Satellite Link Planned
- Sattelite Link History

Use the configuration button to specify the database credentials. Afterwards, click the "Retrieve Info" button to load the information from the database.

## Notes

All data in the ESV Controller is used in the **Marlink 7 Seas Manager**. For this reason, in this connector alarm monitoring and trending are only available for the general parameters.
