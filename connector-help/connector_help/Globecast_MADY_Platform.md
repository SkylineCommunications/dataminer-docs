---
uid: Connector_help_Globecast_MADY_Platform
---

# Globecast MADY Platform

GLOBECAST Content Marketplace is a media management and content-sharing platform across multiple events. Via a specially designed website, content is transcoded to multiple formats and then clipped. File data can then be associated with the video, for example, scripts, cue sheets or a press kit. Access and rights management is also handled, via a simple user interface, with download and viewing statistics available.

This connector uses HTTPS to communicate with GLOBECAST Content Marketplace.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.33.0                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTPS connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

### Initialization

In order to perform a request, you have to be authenticated via a token. A token is a version 4 UUID. The token is used by the server to know which user made the incoming request.

You have to specify the **Authentication Token** in the following format**:** "***Token 711e390d-9622-4d3f-bcb4-263eedac13ab***"

You also need to specify the **Scoped Request UID**, which is a project-specific UUID. Without this, the connector will not make API calls.

## How to use

On the **General** page, you can configure the **Authentication Token and the general platform information.**

On the **Alarms** page, you can find the Alarms table of the device.

On the **Jobs** page, you can set the **Unarchived Failed Jobs Maximum**. This is the maximum number of unarchived failed jobs that can be in the table before the parameter **Unarchived Failed Job Maximum Alarm** changes to *Reached***.**
For example, if the parameter Unarchived Failed Jobs counter is at 289 jobs, and Unarchived Failed Jobs Maximum is set to 300 jobs, the Unarchived Failed Job Maximum Alarm parameter will show *Unreached*. But if the Unarchived Failed Jobs counter changes to 301, the Unarchived Failed Job Maximum Alarm parameter will show *Reached*.

Also on the **Jobs** page, you can set the **Unarchived Failed Job Maximum Time** to 1 to 10 minutes. If the difference between the current time and the **start date** of a job in the **Unarchived Failed Jobs** **Table** exceeds the number of minutes defined as the **Unarchived Failed Job Maximum Time**, the **Time Maximum Alarm** column will show *Reached* for that specific job.
