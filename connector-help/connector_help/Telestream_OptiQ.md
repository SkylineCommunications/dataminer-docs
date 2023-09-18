---
uid: Connector_help_Telestream_OptiQ
---

# Telestream OptiQ

This connector uses the Optiq Monitor API to monitor live streams.

## About

This connector uses **HTTP** to communicate with the API.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **API version** |
|------------------|-----------------|
| 1.0.0.x          | v1.0            |

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

#### HTTP Connection

- **IP address/host**: The IP address e.g `https://api.cloud.telestream.net`.
- **IP port**: The port of the destination e.g. *443*.

### Configuration

Whenever a new element is created, it is necessary to indicate an API Key (General page =\> Configuration).

After that, it is necessary to select a project (General page =\> Select Project).

## Usage

### General

On this page, it is possible to configure an API key and select the desired project.

After that, all the available Assets will be displayed and it will be possible to start a monitoring session.

### Monitoring Sessions

This page shows all sessions that are currently active, by **Name, Asset Name and Start Time**.

### Streams

This page shows the information about the streams, such as **CDN Name, Resolution, Bitrate, etc**.

### Monitoring Points

On this page it is possible to see the list of monitoring points by asset. It is possible to check for example its **Location,** **Number of Alarms and Number of Streams**.
It is also possible to add or remove locations to a desired asset (if it is not being monitored).

### Monitoring Streams

On this page it is possible to see the list of monitoring streams. It is possible to check for example its **Location** and **Status**.

### Connection

On this page it is possible to see more information about the connection, such as the **Minimum Connection Time, Average Manifest Size, Maximum Connection DNS time**, etc.

### QoS

This page shows the metrics parameters related to Quality of Service, such as **Average Media Bitrate, Average Download Time, Media TCP Retransmission Packets**, etc.

### QoE

This page shows the metrics parameters related to Quality of Experience, such as **Media Audio Loudness, Average Audio MOS, Average GOP MOS**, etc.

### Monitoring

This page shows the metrics parameters related to Monitoring, such as **Minimum DVST, Error Time, HTTP Status 2xx, etc.**

### Alarms

This page shows a list of all active alarms. It is possible to see for example the **Name, Description and Severity**.

### Locations

This page shows the entire list of available locations. It is possible to see the **Name** of the location, **Provider, Region, Longitude and Latitude**.

### Overview

On this page it is possible to have a comprehensive view of everything, using a tree control for this.
