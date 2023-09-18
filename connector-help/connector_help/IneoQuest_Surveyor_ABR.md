---
uid: Connector_help_IneoQuest_Surveyor_ABR
---

# IneoQuest Surveyor ABR

The **IneoQuest Surveyor ABR** is a probe device that can detect streaming media data flows on networks and measure a variety of key parameters.

## About

An HTTPS connection is used to retrieve information from and send information to the device. Data is received and sent in the JSON format.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**    |
|------------------|--------------------------------|
| 1.0.0.x          | SurveyorABR-3.00.00.083-102417 |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device, by default *443*. In case you are using a different port than this default, make sure to prefix the IP address/host with " **https://**".
- **Device address**: By default *byPassProxy*.

### Configuration

On the **Security** page, you need to enter the **User Name** and **Password**. With the **Connect** button, you can force the connection.

## Usage

### Streams

This page displays an overview table listing all the streams. Via the right-click menu of the table, actions can be performed:

- **Add Stream**: Displays a dialog box where the necessary information can be specified to add the stream.
- **Start/Stop Selected Streams**: Activates or stops the selected streams.

### Events

This page displays an overview table listing the currently scheduled events. Via the right-click menu of the table, actions can be performed:

- **Add Event**: Displays a dialog box where the necessary information can be specified to add the event.
- **Remove Selected Events by Name**: Removes all the events you selected based on the event name. Note that if multiple instances are scheduled of the same event, all instances will be removed.
- **Remove All Events**: Removes all the currently scheduled events.

### Security

Refer to the above section **Installation and configuration** \> **Configuration**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
