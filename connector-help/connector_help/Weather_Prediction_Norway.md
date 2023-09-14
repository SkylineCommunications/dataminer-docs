---
uid: Connector_help_Weather_Prediction_Norway
---

# Weather Prediction Norway

The **Weather Prediction Norway** connector uses [http://api.met.no](http://api.met.no/) to request weather data.

Though this is a Norwegian weather service, it also provides weather information for outside Norway. The connector can therefore be useful at many sites, although it could occur that it provides more detailed information for locations inside Norway itself.

## About

With this connector, important weather data can be retrieved based on **locations** specified with **longitude**, **latitude** and optionally **height**. (Height is only necessary for locations outside of Norway.) The connector also provides an overview of any **API errors** and **textual forecasts**. All data can be retrieved for up to 10 days in the future.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                           |
|------------------|-------------------------------------------------------|
| 1.0.0.x          | [http://api.met.no](http://api.met.no/) (Version 0.3) |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** [*http://api.met.no*](http://api.met.no/)
- **IP port:** *80*
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration of the Summary Table

In order to retrieve data for specific locations, specify the locations in the **Locations** table. These will then automatically be synced to the **Summary** table, so that specific weather data can be retrieved.

## Usage

### API Errors

This page provides an overview of all **Errors**, indicating the **Subject** and the affected areas in a semicolon-separated list (In the column **API Error Affecting**). The **Time Duration** for each error is also indicated. If **API Error To** is empty, the issue has not yet been resolved.

### Locations

On this page, you can configure the locations based on **Latitude**, **Longitude** and **Height**. Each location can be configured to be present in the Summary table (**Monitored** = *Enabled*) or not (**Monitored** = *Disabled*). Location **Names** can be configured and will be shown in the **Summary table**.

Locations can be added individually with the **Add Location button**. Individual locations can be **Refreshed** or **Deleted**.
However, please note that it is better to enable or disable **Monitoring** instead of deleting a location, as deleting locations can lead to inconsistent trending.

Several locations can be added in one go with the **AS AddLocations** parameter. This is also the parameter that should be used when adding rows with **Automation scripts**. The parameter expects the following format:

- *Location\*Latitude\*Longitude\*Height\*Monitored;Location\*Latitude\*Longitude\*Height\*Monitored; ...*
  If there is no **Height**, leave the value blank (e.g. \*Longitude\*\*Monitored;).
  **Monitored** should be set to 0 for false or to 1 for true.
  Locations must be unique!
  Example: *TestLocation 1\*60.10\*9.58\*\*1;TestLocation 2\*60.10\*9.58\*\*1;TestLocation 3\*60.10\*9.58\*\*1*

### Summary

This page contains all **weather data averaged per day**. The number of days shown can be defined with the **Predicted Days** parameter. Please note that the data for every predicted day will be contained in an **extra row for each** **location** (e.g. *200 locations showing 5 days will result in 1000 rows*).

The display key of each row consists of the following information: **Location - Time**, where Time = *Today, Tomorrow, 1 Day From Now, 2 Days From Now, ...*

The following data is available for each location:

- **Avg. Temperature**
- **Min Temperature**
- **Max Temperature**
- **Avg. Wind Speed (mps and Beaufort)**
- **Avg. Wind Direction (deg and compass)**
- **Avg. Humidity**
- **Avg. Pressure**
- **Avg. Cloudiness**
- **Avg. Fog**
- **Avg. Low Clouds**
- **Avg. High Clouds**
- **Avg. Dew Point Temperature**
- **Avg. Precipitation:** Average rain per hour during the day.
- **Min Precipitation:** Minimum rain per hour during the day.
- **Max Precipitation:** Maximum rain per hour during the day.
- **Prevalent Temperature Probability:** Probability of temperature data being correct.
- **Prevalent Wind Probability:** Probability of wind data being correct.
- **Prevalent Symbol:** General symbol indicating the weather for the day.
- **Prevalent Symbol Probability:** Probability of the provided symbol being correct.
- **Forecast:** Textual forecast for this day.

With the **URL Extension** parameter, you can add an extension to the URL that is used to request the forecast information (e.g. "[http://api.met.no](http://api.met.no/)/**abcd**/weatherapi/errornotifications/1.0/").

With the **X IBM Client ID** parameter, you can add a header to the API weather forecast requests. The header has the following format: "*x-ibm-client-id*". The header value will be the input parameter value. If you set *None*, then the header will not be added.

The page button **Details** opens a page where you can request all the **data for a single location** as it is recovered from the API. It shows very detailed data for every hour.

The page button **Lite Details** opens a page that is very similar to the Details page, but with less detailed information.

### Text Forecasts

This page provides all **textual forecasts** currently issued for every location.

With the **Configuration** page button, a selection of **text forecast types** can be *Enabled* or *Disabled*. Each enabled type adds additional data (if available) to the **Text Forecasts table**.

## Notes

- For correct usage of the connector, **.NET 4.5** is recommended.
- Multi-client behavior is not supported. The configuration implemented by one client will be shared between all clients.
- To add rows via an Automation script, use the **AS AddLocations** parameter.
