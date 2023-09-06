---
uid: Connector_help_Imagine_Communications_Motion
---

# Imagine Communications Motion

**MotionT HTTP REST API** is a Windows service providing a defined list of Imagine Communications Motion server operations for HTTP client applications.

This driver can be used to monitor Imagine Communications Motion server operations based on the REST API.

## About

### Version Info

<table>
<colgroup>
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
<col style="width: 25%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Key Features</strong></td>
<td><strong>Based on</strong></td>
<td><strong>System Impact</strong></td>
</tr>
<tr class="even">
<td>1.0.0.x</td>
<td>Initial version.</td>
<td>-</td>
<td>-</td>
</tr>
<tr class="odd">
<td>1.0.1.x [SLC Main]</td>
<td><ul>
<li>Changed the structure/format of the primary key of the Activities table.</li>
<li>Changed the display key of the Activities table.</li>
</ul></td>
<td>Version 1.0.0.4</td>
<td>-</td>
</tr>
</tbody>
</table>

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.9                  |
| 1.0.1.x   | 1.2.9                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *9005*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the following data pages:

- **General**: Displays general information about the service, such as the name, API version, URLs, ports, etc.
- **Jobs**: Displays the number and list of jobs. The **Total Number of Jobs** refers to the total number of jobs available in the API, but the number of items displayed in the table is limited by the Query parameters.
  This page contains the following page buttons:
  - **Job Query Parameters**: Displays the list of parameters used to query jobs. As the list of jobs available in the API could grow too large, it is advisable to limit the maximum number of jobs to an acceptable amount (by default 500) that should be polled from the API; otherwise the element will go into timeout.
  - **Activities**: Displays the list of available activities under each job.
- **Workflows**: Displays the list of workflows.
  This page contains the following page buttons:
  - **Input Parameters**: Displays the list of input parameters.
  - **Output Parameters**: Displays the list of output parameters.
- **Tasks**: Displays the number and list of tasks.
- **Storages**: Displays the list of storages and endpoints.
  This page contains the following page buttons:
  - **Configuration**: Contains the list of parameters used to query directories and files for a specific endpoint.
  - **Directories**: Contains the directory list for a given endpoint.
  - **Files**: Contains the files list for a given endpoint.
  - **Audio**: Contains the audio list for a given endpoint.
