---
uid: Connector_help_Davis_Vantage_Pro_2
---

# Davis Vantage Pro 2

The Davis Vantage Pro 2 is a customizable station with a wide range of options and sensors to help measure, monitor and manage weather data. It includes a console/receiver and integrated sensor suite with transmitter and solar panel.

The device presents current data or highs and lows for up to 24 different days, months or years and displays a local forecast. It allows you to view over 80 graphs, including additional analysis of temperature, rain, rain rate, wind and barometric pressure. The solar-powered integrated sensor suite combines a rain collector, temperature sensor, humidity sensor and anemometer.

The Davis Vantage Pro 2 provides the following information:

- Barometric pressure
- Inside and outside humidity
- Wind chill
- Inside and outside temperature
- Wind speed and direction
- Dew point
- Rain
- Time of sunrise and sunset at your location
- Rain rate
- Local forecast

## About

### Version Info

| **Range** | **Key Features**                                                                                                                                                                                                                                                                                                                                 | **Based on** | **System Impact** |
|-----------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.1   | Initial version                                                                                                                                                                                                                                                                                                                                  | \-           | \-                |
| 1.0.0.2   | QA - Initial version                                                                                                                                                                                                                                                                                                                             | 1.0.0.1      | \-                |
| 1.0.0.3   | Implemented setting for date and time. Implemented calculations on the received values in case the unit is not the same as used in the protocol. Implemented configuration for metric or imperial units, rain collector, station latitude and longitude, wind cup size, wind direction calibration, rain season, elevation and barometer offset. | 1.0.0.2      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.3   | 3.15                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. This is required, default value: 22222.

## How to Use

Serial commands are used to retrieve the device information. The information is displayed on two data pages:

- **General**: Displays the weather data retrieved from the device.
- **Alarms**: Displays the status for each of the alarms available on the device.
