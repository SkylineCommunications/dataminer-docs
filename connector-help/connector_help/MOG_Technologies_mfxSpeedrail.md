---
uid: Connector_help_MOG_Technologies_mfxSpeedrail
---

# MOG Technologies mfxSpeedrail

The **MOG Technologies mxfSpeedrail** connector is used to monitor the MOG Technologies centralized ingest solution. This solution was designed to control file-based production workflows for broadcast environments.

## About

This connector was designed to interact with a SOAP interface. An **HTTP** connection is used to successfully retrieve the API's information.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.1.7600.0                  |

## Installation and configuration

### Creation

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify "*bypassproxy".*

## Usage

The connector contains 10 pages.

### General Page

This page displays general information about the system, such as the **Hostname**, the **Fully Qualified Domain Name**, the **Operating System**, the **IP Address** and the **Server Port**. This page also contains the **Servers Table** and the **MAM Servers Table**, which display information about all connected servers and all persistent MAM servers, respectively.

### Devices Page

This page contains the **Devices Table** with the information regarding all devices that are attached to the system.

### Locations Page

This page displays the **Locations Table** with information regarding all persistent locations**.**

### Flows Page

On this page, you can get information about all current flows, displayed in the **Flows Table**. These flows represent one or several asset(s) processing jobs.

### Rules Page

This page contains the **Rules Table** with brief information about all configurable rules in the system. These rules allow you to monitor specific locations, and automatically create new flows as soon as new assets are detected (within certain limitations).

The **Configuration** page button opens the **Rules Configuration** page, which displays more detailed information about these rules.

### Notifications Page

This page displays the **Notifications Table**, which shows detailed information about the current notifications. These notifications are warnings and information that the system generates when certain events occur.

### System Settings Page

This page provides information about the current values for the system settings. In order to add a system setting to the **System Settings Table**, you must add it using the write parameter located at the top of the page.
