---
uid: Connector_help_The_Weather_Company_Weather_Underground
---

# The Weather Company Weather Underground

This connector retrieves information about weather conditions at locations selected by the user, using information provided by "The Weather Company".

## About

The Weather Underground connector implements the "Weather API" (from The Weather Company), which enables the connector to retrieve information about weather conditions from different locations.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | API version 0.1             |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The URL of the forecast service: *https://api.wunderground.com*
- **IP port**: The IP port of the API, by default port *443*.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General

This page displays the protocol overview and includes parameters such as the **API Connection Status** and the **Number of API Calls** performed during the last 24 hours and the last minute.

### Current Weather Conditions

This page contains the **Forecast Information** table, which contains information related to the weather conditions for the locations configured in the **Locations** table.

The **Locations** subpage, containing the corresponding table, can be accessed via a page button. The **Locations** **table** contains the list of locations for which the connector will obtain the current weather conditions. To make the connector retrieve the weather conditions for a specific location, add a new row to this table.

To add a location, this connector currently supports two methods:

- **Add Location**: The following fields are required:

- **ISO Country Code**: Weather Underground uses custom ISO country codes (e.g. BE). You can find the custom codes on the following page: <https://www.wunderground.com/weather/api/d/docs?d=resources/country-to-iso-matching>.
  - **Weather Station Location Code**: The location name (e.g. Gent).

> It could be that when you select this option, multiple responses (for different locations) are possible, e.g. when the same location name is available for more than one country. If this is the case, the results will be stored in the **Multiple Results** table. In this table, you can select the correct location in order to add it to the Locations table.

- **Location ZMW**: The following fields are required:

- **Weather Station ZMW Code**: In some cases, when you provide the location (ISO Code and ISO Country Code), multiple responses are possible. In order to uniquely identify a location, Weather Underground uses the ZMW code. If you provide this code, the forecast service will return forecast information for only one specific location. More information about this request can be found on the following page: <https://www.wunderground.com/weather/api/d/docs?d=autocomplete-api&MR=1>.

### Quick Features

This page displays the **Quick Features Console**, which can be used to quickly check weather conditions based on available features, and also to provide on-demand weather information to other elements within the DMS.

The Quick Features responses are displayed in the **Quick Forecast Information** table, available on the **Quick Weather Conditions** subpage. This subpage is accessible via a page button.

### Configuration

This page contains parameters related to the configuration of this connector:

- In order to retrieve information from the API, the parameter **API Key** needs to be set.
- With **Max Requests**, you can set the maximum number of queries to be requested at once (in the same timer cycle every 30 minutes), to avoid exceeding the limit of the API plan.
- With **Calls Per Day**, you can set the maximum number of queries to be requested in one day, to avoid exceeding the limit of the API plan.
- With **Calls Per Minute**, you can set the maximum number of queries to be requested in one minute, to avoid exceeding the limit of the API plan.

The **Quick Configuration** subpage can be accessed using a page button and contains the **Quick Console** configuration parameters.

- **Console Status**:

- *Enabled*: Actions can be performed via the Quick Features Console.
  - *Disabled*: No actions can be performed via the Quick Features Console. If an attempt is made to send an API call through the console, a message will be displayed to notify the user that the console is disabled.

- **Inter Element Service**:

- *Enabled*: The protocol will respond to inter-element calls for Weather Conditions Information.
  - *Disabled*: The protocol will not respond to inter-element calls for Weather Conditions Information.

- **Auto Delete**:

- *Enabled*: Weather information retrieved via the Quick Features Console is automatically deleted according to the specified timer.
  - *Disabled*: Weather information retrieved via the Quick Features Console is not automatically deleted according to the specified timer.

If **Auto Delete** is enabled, the **Auto Delete Delay** specifies the time to wait before deleting a record retrieved via the **Quick Features Console**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
