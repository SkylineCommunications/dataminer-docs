---
uid: Connector_help_Conviva_Experience_Insights
---

# Conviva Experience Insights

**Conviva** is a real-time and historical measurement and intelligence platform for streaming TV that provides solutions for the capture and analysis of QoE metrics oriented to user engagement validation. The data are displayed on the web platform Pulse.

The purpose of this connector is to collect the processed metrics available on Pulse. To retrieve the data, the connector uses an HTTPS connection.

## About

### Version Info

| **Range**            | **Key Features**                                 | **Based on** | **System Impact**                 |
|----------------------|--------------------------------------------------|--------------|-----------------------------------|
| 1.0.0.x              | Initial version (HTTP connection)                | \-           | \-                                |
| 1.0.1.x              | Webhook alarms                                   | 1.0.0.1      | Element IP has to be reconfigured |
| 1.0.2.x              | Deleted incorrect duplicates in MetricLens table | 1.0.1.5      | Removed rows                      |
| 1.0.3.x              | New connection to retrieve filter data           | 1.0.2.4      | New element IP                    |
| 1.0.4.x \[SLC Main\] | Added partial option to a couple of tables       | 1.0.3.7      | Impact to visuals, apps, etc.     |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |
| 1.0.4.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Connection - Main

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Configuration of security settings

To start using this connector, you need to specify the **User** name and the **Password** on the **Security Settings** page.

Once you have logged in, the connector will retrieve the list of accounts available for Conviva's credentials. You must select one from the **Account** dropdown list on the **Security Settings** page.

### Conviva configuration for alarms (Webhook)

In order to receive alarms in DataMiner, a Webhook has to be configured in the Conviva UI.

To do so, log in on <https://pulse.conviva.com/> and go to **Settings** \> **Notification Channels** \> **Webhooks.** There you can add a webhook, for which you have to configure the IP and port DataMiner is going to listen to. Also, it is possible to configure which alarms DataMiner should receive: **AI Alerts** and/or **Manual Alerts**.

Note that the connector does not support the option "**URL has authentication**", if you enable this in the Conviva UI, you may not get any alarms in DataMiner.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### Configuration

In order to view information with this connector, you need to configure which **Metrics** and/or **MetricLens** information should be displayed. This can be done on this page. The results of the configuration are displayed on the **Metrics Results** page and **MetricLens Results** page.

The page contains two tables:

- **Metrics:**

- **Metric Name**: The type of metric to display, e.g. attempts, plays, etc.
  - **Filter Name**: Allows you to specify a filter to see only specific data.
  - **Status**: The status of the HTTP call: *Error*, *Warmup* or *OK*.
  - **Disable**: Allows you to enable or disable the polling.
  - **Poll Now**: Allows you to instantly poll the data.
  - **Remove**: Allows you to remove the metric.

- **MetricLens:**

- **Dimension Name**: The dimension used to collect the data. **Dimensions** can include CDNs, Cities, ISPs. For each dimension, you can choose which metrics to display.
  - **Filter Name**: Allows you to specify a filter to see only specific data.
  - **Metric Name**: The type of metric to display.
  - **Status**: The status of the HTTP call.
  - **Disable**: Allows you to enable or disable the polling.
  - **Poll Now**: Allows you to instantly poll the data.
  - **Remove**: Allows you to remove the metric.

### Metrics Results

Depending on the metric name, the data will be displayed in one of the three tables on this page:

- **Time Series Metrics**

- **Metric name**: The type of metric.
  - **Filter**: The filter that is applied in the table.
  - **Units**: The unit corresponding to the value. This parameter is set by the user.
  - **Avg. value**
  - **Max value**
  - **Min value**

- **Simple Series Metrics**

- **Metric name**: The type of metric.
  - **Filter**: The filter that is applied in the table.
  - **Value**
  - **Units**

- **Label Series Metrics**

- **Metric name**: The type of metric.
  - **Filter**: The filter that is applied in the table.
  - **Label**: The value description.
  - **Value**
  - **Units**: The unit corresponding to the value. This parameter is set by the user.

### MetricLens Results

The MetricLens data are displayed in the **MetricLens Quality** table. This table contains the following information:

- **Dimension**: The dimension used to collect the data.
- **Filter**: The filter that is applied in the table.
- **Metric Name**: The type of metric.
- **Label**
- **Attempts**: The number of attempts to play a video initiated when a viewer clicks play or through video auto-play.
- **VSF - Video Start Failures**: The number of attempts when a video was terminated during startup before the first video frame was played, and a fatal error was reported.
- **EBVS - Exits Before Video Starts**: The number of attempts when a video was terminated before it started, without a reported error.
- **Plays**: The number of plays, which are counted when the first video frame is displayed.
- **VST** - **Video Startup Time**: The number of seconds between when the user clicks play or a video auto-starts and when the first I-frame of the video is rendered, excluding any pre-roll ads.
- **Rebuffering Ratio**: Rebuffering occurs when the video stalls during playback and the viewer must wait for the video to resume playing. The Rebuffering Ratio measures the percentage of total video viewing time during which viewers experienced rebuffering.
- **Average Bitrate**: The bits played by the player.
- **VPF - Video Playback Failures**: The number of times when video play terminates because of a playback error.
- **Ended Plays**: The number of times a play ended during the selected interval.
- **CIRR - Connection Induced Rebuffering Ratio**: The percentage of total video viewing time during which viewers experienced non-seek rebuffering.
- **VRT - Video Restart Time**: The number of seconds after a user initiated seeking until the video began playing.

### Alerts

This page contains an overview of the alerts that are reported via the Webhook connection. There are two types of alerts, each with a dedicated table on this page: **AI** and **Manual** alerts.

For both types, an auto-delete mechanism is available via the **Delete Configuration** button, where you can choose either to delete based on age or based on the number of records.

### Security Settings

For more information on this page, refer to the section "Configuration of security settings" above.
