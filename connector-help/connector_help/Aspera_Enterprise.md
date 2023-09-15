---
uid: Connector_help_Aspera_Enterprise
---

# Aspera Enterprise

The **Aspera Enterprise** is a file-monitoring connector that uses **SSH** to retrieve files from a remote platform.

## About

After the connector has retrieved a file through **SSH**, the contents of the file are checked line by line with a number of configured filters. The files that are polled are specific .log files that have a maximum size of 10 MB.

In range1.0.0.x of the connector, once the maximum file size has been reached, the file is renamed by another application by appending a *'.0'.*

In range 2.0.0.x of the connector, once the maximum file size has been reached, the oldest lines are progressively replaced, starting from the begining.

This connector takes this into account and will make sure that every line (new or old file) is parsed once.

### Version Info

| **Range** | **Description**                                                                                                                                                                         |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Initial version.                                                                                                                                                                        |
| 2.0.0.x          | New range version based on 1.0.0.x. Instead of creating multiple log files after reaching 10MB, this new version parses just one file, which is overwritten after the limit is reached. |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The server to connect to with SSH.
- **IP port**: By default *22*. Not adjustable (SSH).
- **Bus address**: Not applicable.

### Configuration of SSH Credentials

Before the connector can start polling, the **SSH Credentials** need to be filled in on the **General Page**.

## Usage

### General

This page contains the **Server IP** that is being polled, the **SSH Username** and the **SSH Password** used for the connection.

### Log File

The **Log File page** contains two important tables:

- **Aspera Log File Alert Filter:** In this table, filters can be configured. More information on the possible **Filter Types** and configuration options can be found in the *Ad Insertion Monitoring System TRSD* document. From range 2.0.0.x onwards, the **Log Last Read Date** is also displayed.
- **Aspera Log File:** In this table, you can view whether certain configured filters are in alarm state. You can also manually **Clear** an alarm from this table.

The files are retrieved and parsed once every 30 seconds (see note below). It is possible to manually request a refresh with the **Refresh** button.

With the **Add Filter** page button, you can add a new row containing all necessary data. After you have clicked **Add**, a second confirmation window will appear that will only allow you to add a new filter if all necessary data has been filled in.

The **Logs Last Read** page button leads to a table with data indicating the last read character for each file. This is used to keep track of which lines to continue parsing on. If necessary, you can change the last read character so that a file will be re-parsed from a certain position. This functionality is mostly used for debugging and testing purposes. However, note that this page button is **no longer included in** connector range **2.0.0.x**.

## Notes

On the **Log File** page, depending on the size and number of the different files that need to be parsed, it can take more than 30 seconds between each poll.

### Logfile Filter Types

The following section describes the filter types available in the detection of an alarm state in an event log.

#### Simple: Detects an alarm state from the occurrence of a single event.

Simple event detection uses the occurrence of a single event to indicate an alarm condition.

The alarm condition can be reset in the following ways:

- **Event Reset**: Detection of another single event, after the alarm event, indicating that the alarm condition has cleared.
- **Manual**: The alarm condition never returns to a normal state automatically. The user determines whether the problem was corrected and then clears the alarm in the Alarm Console.
- **Timer Reset**: A timer reset acts the same as a manual reset, except that if the user does not manually reset the alarm after a specified time, it will reset automatically.

Simple event example:

- **Alarm Filter:** Event 1
- **Normal Filter:** Event 5

| **Time** | **Event** | **State** |
|----------|-----------|-----------|
| 00:00:00 | \-        | Normal    |
| 00:01:00 | Event 1   | Alarm     |
| 00:02:00 | Event 1   | Alarm     |
| 00:03:00 | \-        | Alarm     |
| 00:04:00 | Event 5   | Normal    |
| 00:05:00 | \-        | Normal    |
| 00:06:00 | \-        | Normal    |
| 00:07:00 | Event 1   | Alarm     |

#### Repeating: Detects an alarm state based on one or more occurrence of a particular event in a specified time window

Repeated event detection uses one or more occurrence of a particular event in a time window to indicate an alarm condition. This typically applies to conditions in an application where a single event on its own can be ignored, but multiple occurrences of the event in a particular time window indicate a potential error.

- **Trigger on Count**: Trigger on count consolidation of events requires multiple occurrences of the same event in a specified time window before an alarm condition is set. The time window is a rotating time duration of a specified length.
- **Trigger on Count, Sliding**: Similar to Trigger on Count, except that the time window is reset when a specified reset event occurs.

Repeated events example:

- (consolidation) **Interval:** 2 minutes
- (compare) **Count:** 3
- **Alarm Filter:** Event 1
- **Normal Filter:** Event 2

| **Time** | **Event** | **Trigger On Count State** | **Trigger On Count, Sliding State** |
|----------|-----------|----------------------------|-------------------------------------|
| 00:00:00 | \-        | Normal                     | Normal                              |
| 00:01:00 | Event 1   | Normal                     | Normal                              |
| 00:01:30 | Event 1   | Normal                     | Normal                              |
| 00:02:00 | \-        | Normal                     | Normal                              |
| 00:02:30 | Event 1   | Alarm                      | Alarm                               |
| 00:02:40 | Event 2   | Alarm                      | Normal                              |
| 00:03:00 | \-        | Normal                     | Normal                              |
| 00:04:00 | Event 1   | Normal                     | Normal                              |
| 00:04:10 | Event 1   | Alarm                      | Normal                              |
| 00:04:30 | Event 1   | Normal                     | Alarm                               |

#### Missing: Detects an alarm state when an expected event is not detected in a particular time window

Instead of detecting a particular event to identify an alarm condition, the missing event detection uses the absence of a particular event in a particular time window to determine an alarm condition.

Missing event example:

- **Alarm Filter:** Event 1
- (time window) **Interval:** 2 hours
- **Normal Filter:** Event 3

| **Time** | **Event** | **State** |
|----------|-----------|-----------|
| 00:00:00 | Event 1   | Normal    |
| 01:00:00 | \-        | Normal    |
| 02:00:00 | \-        | Alarm     |
| 03:00:00 | Event 1   | Normal    |
| 05:00:00 | \-        | Alarm     |
| 05:06:00 | Event 3   | Normal    |
| 05:07:00 | Event 1   | Normal    |

#### Correlated Missing Events: Detects an alarm state when an expected event is not detected in a particular time window after the occurrence of another event

Correlated missing event detection identifies an error when a particular event does not occur after another event has occurred. This is similar to the missing event detection, except that instead of searching for the missing event in a time window, it searches for the event in a particular time after another event is first detected.

Correlated missing event example:

- \(A\) **Alarm Filter:** Event 1
- \(B\) **Alarm Filter B:** Event 2
- (correlation) **Interval:** 2 minutes
- **Normal Filter:** Event 3

