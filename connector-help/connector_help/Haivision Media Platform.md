---
uid: Connector_help_Haivision_Media_Platform
---

# Haivision Media Platform

This connector can be used to integrate the Haivision Media Platform. It supports multiple system functionalities such as adding users, editing video information, creating events, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination. Make sure to exclude the protocol/prefix of the host. For example, *https//hmp.demo.haivision.com* should be filled in as *hmp.demo.haivision.com*.
- **IP port**: The IP port of the destination (default: *443*).

### Initialization

On the **General** page, in the **Authentication Settings** section, provide the credentials to access the device.

## How to use

### General

On this page, you can find system information such as the software and build versions. You can also provide the credentials to access the device.

### Users

This page displays the list of users registered in the system.

### Sources

On this page, you can view the different sources.

You can also create, edit, or delete a source. To do so, start by right-clicking the table.

- To add a source, click a row and select **Duplicate source** if you want to use existing source data or **Create source** otherwise.
- To edit or delete a source, right-click the corresponding row and select the appropriate option. Then fill in the necessary fields in the pop-up window.

### Sessions

On this page, you can view the different sessions. It is possible to create, edit, or delete a session. To do so, start by right-clicking the table.

- To add a session, click a row and select **Duplicate session** if you want to use existing session data or **Create session** otherwise.
- To edit or delete a session, right-click the corresponding row and select the appropriate option. Then fill in the necessary fields in the pop-up window.

### Recording

An active recording is a recording that is currently being created by recording a session's sources. When it is paused, it becomes a paused recording. When it is stopped, it becomes a finished recording and is removed from the table. Finished recordings are referred to as videos.

On this page, you can view the list of active recordings and corresponding recorders. You can also pause/resume/stop a recording by right-clicking the row representing the recording and selecting the appropriate option.

### Videos

On this page, the list of videos and categories can be found. You can edit or delete a video, or change its title and description. To do so, right-click the video and select the appropriate option.

### Events

This page contains the list of registered events. To create a new event, right-click the Events table and select **Create Event**.

In the case the event is of type "recurring", to select which days of the week the event should be active, use the **Add Week Day** parameter. With the parameter, you can select the days by writing the 3 initial letters of the desired days separated by semicolons (";"). For example, if you want an event to occur on Wednesday and Friday, write *WED;FRI*.

### Devices

This page provides a list of all of the devices in the system.

### Streams

This page provides a list of all of the streams of the system. You can also pause/resume/stop a stream by right-clicking the row representing the stream and selecting the appropriate option.
