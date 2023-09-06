---
uid: Connector_help_TAG_Video_Systems_Media_Control_System_(MCS)
---

# TAG Video Systems Media Control System (MCS)

This is an HTTP-based connector that can be used to monitor and configure the **TAG Media Control System Platform**.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API Version: 5.0       |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

Specify the following input configuration on the **Communication** page of the element:

- **Username**: Name of the user used in the HTTP login operation.
- **Password**: Password of the user used in the HTTP login operation.

## How to Use

REST API calls are used to establish communication with the device.

The following data pages are available in the element:

- **Users**: Allows you to assign the user and their role.
- **Devices**: Displays the device information and statistics.
- **Channels Configuration**: Contains the configuration of the sources.
- **Channel Scans Configuration**: Contains the configuration of the sources scan.
- **Outputs Configuration**: Contains the configuration of the output encoder.
- **Layouts**: Displays the layouts available to set the channel's location.
- **Networks Configuration**: Displays the available networks.
- **DNS Configuration**: Displays the DNS servers that are being used.
- **NTP Configuration**: Displays the NTP servers that are being used.
- **PTP Configuration**: Displays the PTP servers that are being used.
- **Scheduler Configuration**: Displays the scheduler settings to change the profile on the channel configuration.
- **KMS Configuration**: Displays the KMS settings for the MCS platform.
- **Timezones Configuration**: Displays the available time zones for the MCS platform.
- **Threshold Configuration**: Displays the available threshold settings for the MCS platform.
- **Notification Configuration**: Displays the available notifications settings for the MCS platform.
- **Backup & Restore**: Contains settings for backing up, restoring, and downloading.
- **Tasks**: Displays the tasks that are currently being performed on the MCS platform.
