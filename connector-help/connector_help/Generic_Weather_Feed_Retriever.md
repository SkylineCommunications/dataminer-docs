---
uid: Connector_help_Generic_Weather_Feed_Retriever
---

# Generic Weather Feed Retriever

The **Generic Weather Feed Retriever** shows an overview of the weather forecast based on latitude and longitude.

## About

This connector retrieves the weather forecast for all entries in the **Weather Track Table**, based on serial communication (range 2.0.0.x and 3.0.0.x) or HTTP communication (range 4.0.0.x).

### Version Info

| **Range** | **Description**                                                                                                                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 2.0.0.x          | Changes in order to work with serial command/response (instead of web client). Only supports free API key, which allows 500 commands to be sent per hour, with max. 3 commands per second.                                 | No                  | Yes                     |
| 3.0.0.x          | Added support for premium account. The free version is deprecated.                                                                                                                                                                | No                  | Yes                     |
| 3.0.1.x          | Display columns changed to use naming.                                                                                                                                                                                            | No                  | Yes                     |
| 4.0.0.x          | Complete overhaul to increase scalability (you can now choose the forecast date from today to 14 days in the future and the forecast interval, e.g, hourly). Connection has been changed from serial to HTTP. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 3.0.1.x          | v1                          |
| 4.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>2.0.0.x and 3.0.0.x</td>
<td>Serial main connection
<p>The connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device with value <em>api.worldweatheronline.com</em>.</li>
<li><strong>IP port</strong>: The IP port of the device with value <em>80</em>.</li>
</ul></td>
</tr>
<tr class="odd">
<td>4.0.0.x</td>
<td>HTTP main connection
<p>The connector uses an HTTP connection and requires the following input during element creation:</p>
<p>HTTP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device with value <em>api.worldweatheronline.com</em>.</li>
<li><strong>IP port</strong>: The IP port of the device with value <em>80</em>.</li>
</ul></td>
</tr>
</tbody>
</table>

### Configuration (range 2.0.0.x and 3.0.0.x)

This connector requires an **API Key** from worldweatheronline.com in order to receive weather forecasts. A **Retrieving Method** (*Manual*/*Push*/*Poll*) must be selected in order to reach the data.

#### Manual

The user creates a new row and fills in the coordinates.

#### Push

The **Generic Weather Feed Retriever** gets the coordinates from other elements that push the coordinates to it. These elements must therefore also be adapted to support pushing coordinates to the **Generic Weather Feed Retriever**.

First a command of format *\<DataMiner ID\>/\<Element ID\>* must be sent remotely to parameter ID 6999, and then the **Latitude** (parameter ID 7002) and **Longitude** (parameter ID 7003) must be set remotely.

#### Poll

The **Generic Weather Feed Retriever** gets the coordinates by polling another **DataMiner element**.

Some additional information must be filled in:

- **DMA ID**: The DataMiner ID of the remote element.
- **Element ID**: The element ID of the remote element.
- **Param Table ID**: The parameter ID of the table that contains the coordinates.
- **Column Number Latitude**: The column idx of the **Latitude** column.
- **Column Number Longitude**: The column idx of the **Longitude** column.
- **Column Weather Instance**: The column idx of the **Weather Instance** column.

## Usage (range 2.0.0.x and 3.0.0.x)

### General

This page shows an overview of the weather forecast for the current day. It is possible to add and/or delete new locations to/from the **Weather Track Table** when the **Retrieving Method** is *Manual*.

### Day pages

These pages show an overview of the weather forecast for the coming 4 days.

### Configuration

This page contains the configuration settings in order to reach the data.

## Usage (range 4.0.0.x)

### General

This connector requires an **API Key** from worldweatheronline.com in order to receive weather forecasts.

You may want to configure the **Forecast Date** (e.g. today) and the **Forecast Interval** (e.g. 1 hourly).

You also need to provide the **Location Name** (custom name), **Latitude** and **Longitude**. To do so, right-click the Location table and select to add a row.

### Current Condition

This page displays the **current weather condition** for the locations specified in the **Location** table on the General page, such as the **temperature**, **wind speed**, **precipitation**, **humidity**, **pressure**, etc.

### Weather Forecast

This page displays the **weather forecast** for the locations specified in the **Location** table on the General page, such as the **temperature**, **wind speed**, **precipitation**, **humidity**, **pressure**, etc.

### Tree Control

This page contains a tree view combining information from all tables. The root of the tree view is the name of the location, from which you can access the current and predicted weather conditions for that location.
