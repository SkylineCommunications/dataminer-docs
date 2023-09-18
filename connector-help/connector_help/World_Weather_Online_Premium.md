---
uid: Connector_help_World_Weather_Online_Premium
---

# World Weather Online Premium

The **World Weather Online Premium** connector shows an overview of the current and forecast weather based on latitude and longitude.

## About

The **World Weather Online Premium** connector retrieves the current and forecast weather information for all entries in the weather tables based on HTTP communication. The connector only supports a **premium API Key**.

### Version Info

| **Range**     | **Description**                                                 | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial range.                                                  | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Tables associated with the tree control now are partial tables. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The Worldweatheronline API IP/URL, by default *api.worldweatheronline.com*.
- **IP port**: The IP port of the device, by default *80*.
- **Bus address**: By default *bypassproxy*.

### Configuration

The **World Weather Online Premium** connector needs a **premium API Key** from worldweatheronline.com in order to receive weather forecasts.

## Usage

### Local Weather Overview

This is the default page of the connector. It contains a tree view that provides an overview of the current and forecast weather information for the configured locations.

### Current Local Weather Condition

This page displays the latest weather information retrieved for the configured locations.

Locations can be added or deleted using the fields and buttons at the bottom of the page or using the right-click menu of the table.

### Weather Forecast

This page contains a table with the monthly forecast and a table with the hourly forecast.

### Tides Forecast

This page displays the tides forecast for the configured maritime locations.

### Configuration

This page contains the configuration settings to receive weather data.

The **Import Provisioning File** section of the page can be used to import location settings from pre-configured files.
