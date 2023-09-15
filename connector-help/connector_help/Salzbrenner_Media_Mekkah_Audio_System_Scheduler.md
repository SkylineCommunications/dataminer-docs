---
uid: Connector_help_Salzbrenner_Media_Mekkah_Audio_System_Scheduler
---

# Salzbrenner Media Mekkah Audio System Scheduler

The main function of this connector is to serve as an intermediary between the Salzbrenner Media Mekkah Audio System Scheduler API and elements with the **Stagetec Nexus Star** connector.

The connector collects the schedules and data from the API and sets the data accordingly on the Nexus. In addition to an overview of the schedulers available via the API, the connector also shows an error log table with information about any issues that occurred during scheduler processing.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                       | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Automation script: Audio System Scheduler (see Notes below) | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address**: The IP address of the device.
- **Port number**: The IP port of the destination, *5000*.
- **Bus address**: If the proxy server has to be bypassed, enter the keyword *ByPassProxy*.

## How to use

When the element is activated, the connector retrieves all basic information about the schedulers available in the API. This information is then available on the **General** page in the **Scheduler table**. It is updated every time a scheduler changes.

All schedulers are processed and analyzed to see if they are valid. If they are, two tasks are created in the **Scheduler app**, one for the start of the event and the other for the end.

When the scheduled start time is reached, the task starts and triggers an Automation script that will make the connector send the data to the nexus elements. It will perform the sets on the **Stagetec Nexus Star** tables and check if they were done correctly. If this fails, the connector tries again up to 3 times. If this keeps failing, the state of the current scheduler is set to *Error*. However, if everything is executed properly, the state will be *All Sets Succeeded,* and the connector will wait for the scheduled end time. When that time arrives, the end task will start the Automation script that will trigger the Scheduler connector that starts the **Unroute** process, where the crosspoint values are replaced with zeros in the Nexus elements.

## Notes

To use this connector, you also need the Automation script **Audio System Scheduler**. The script must have the same version as the connector.
