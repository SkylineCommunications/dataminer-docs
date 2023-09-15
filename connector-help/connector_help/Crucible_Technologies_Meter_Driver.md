---
uid: Connector_help_Crucible_Technologies_Meter_Driver
---

# Crucible Technologies Meter Driver

This connector collects the logging information of a *Meter Logger 100*, manufactured by *Crucible Technologies*.

The Meter Logger 100 is a simple-to-use interface device which converts the pulse outputs from up to 3 utility meters into both a graphical display on a webpage and formatted downloadable data.

## About

The connector allows the user to view the logged consumption of the utility meter(s) attached to the *Meter Logger 100*. Using alarming and trending abnormal consumption can then be detected. The information is retrieved using the XML download page provided by the device.

This connector will export different connectors based on the retrieved data. A list can be found in the section 'Exported Connectors'.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.6a                        |

### Exported connectors

| **Exported Connector**                      | **Description**                                                            |
|--------------------------------------------|----------------------------------------------------------------------------|
| Crucible Technologies Meter Driver - Meter | Retrieved consumption information for every activated meter of the device. |

## Installation and configuration

#### HTTP main connection

HTTP CONNECTION:

- **IP address/host**: The polling IP
- **IP port**: The IP port of the destination. Standard port: 80.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration of meters

Every meter that will be logged has to be activated using the Settings page. Extra meter information (like name, factor and unit) can be copied from *Meter and Input Settings* page of the web interface of the device.

## Usage

### Metering

For every activated meter a line is added to the *Meters* table. A unique meter name and the unit of the consumption data.

The table contains the following consumption counters:

- **Current Consumption**: Consumption during the day, updated every half hour. The consumption is reset at the start of the day.
- **Daily Consumption**: Consumption of the last day, updated every day with last day's consumption total. This total can be reset using the *Reset Daily* button, to mask abnormal behavior.
- **Weekly Consumption**: Consumption of the last week, updated at the start of each week with last week's consumption total. This total can be reset using the *Reset Weekly* button, to mask abnormal behavior.
- **Monthly Consumption**: Consumption of the last month, updated at the start of a month with last month's consumption total. This total can be reset using the *Reset Monthly* button, to mask abnormal behavior.
- **Daily History**: Consumption history of today as logged by the device. Reset at the start of the day.
- **Weekly History**: Consumption history of this week as logged by the device. Reset at the start of the week.
- **Monthly History**: Consumption history of this month day as logged by the device. Reset at the start of the month.
- **Status**: Whether the meter is active and consumption is logged.
- **Delete**: Button to delete disabled meters.

Using the **Delete Meters** button all disabled meters will be deleted.

### Settings

This page contains the metering settings. The meter information can be copied from *Meter and Input Settings* page of the web interface of the device.

The following information can be set for each meter logger:

- Active: Whether the consumption should be logged by this element.
- Name: Display name of the meter.
- Factor: The scaling factor of the meter, for example if the meter pulses once every 0.1 m3 you can set the scaling factor and the readout of the values will take this into account.
- Unit: The unit of the logged consumption information.

### Web Interface

Consult and administer the device through its web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
