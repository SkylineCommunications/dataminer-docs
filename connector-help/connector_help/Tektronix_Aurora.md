---
uid: Connector_help_Tektronix_Aurora
---

# Tektronix Aurora

Since Tektronix aquired the Digimetrics Aurora device a new connector named Tektronix Aurora was created.

The Tektronix Aurora is a high volume automated, no reference, file-based QC with easy-to-use web client and efficient fault reporting.

## About

This connector makes it possible to interact with the Aurora web service. Users monitor the status of jobs.

The connector also retrieves information from the templates, machines, processors and the VUCoreMode.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.3.2.102                   |

## Installation and configuration

### Creation

#### HTTP Main Connection

- This connector uses an HTTP connection and requires the following input during element creation:

  SERIAL CONNECTION:

- IP address/host: The polling IP or URL of the destination, e.g. 10.11.12.13.
  - IP port: The port of the destination, by default 1001.
  - Bus address: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

## Configuration for Aurora web service

On the General page, you must fill in the User Name and Password for the Aurora web service.

It is important that this is done before sending jobs to the web service, otherwise the jobs will not be added.

## Configuration for Server Information

On the Windows Login pop-up page, you must fill in the User Name and Password to make sure the information of the server can be retrieved.

## Usage

### General

On the General page, the User Name and Password for the Aurora web service can be filled in, as described in the Configuration for Aurora web service section above. The **Job Time to Live** and **Maximum Job Entries Allowed** refer to the **Job Contract Completed Table** so that the user can limit the presence of jobs inside the Job Contract Completed Table.

On the right-hand side, buttons are available that allow the user to manually refresh the **Default Container Path**, **Job Contracts,** Machines, Templates and Processors.

### Server Information

The Server Information page displays general information of the server.

When you click the Windows Login. page button, a pop-up page, the Configuration Settings page, appears. Fill in the User Name and Password on this page, as described in the Configuration for Server Information section above. Once this is done, general information about the server will be displayed, as well as a table with the different Network Adapters and a table with Disk Information.

### Job Contracts

On the Job Contracts page, a table is displayed containing 2 tables, the **Job Contract In Process Table** and the **Job Contracts Completed Table**.

The connector looks for new entries for the **Job Contract In Process Table** every 2 seconds and refreshes its content every 30 seconds.

The **Job Contract Completed Table** gets updated whenever a Job Contract present in the In Process table reaches 100% Percentage Complete.

A **remove all Jobs** button is also present to make it possible to delete all job entries from both tables at connector level. Job entries will still be available in the device WEB Interface.

### Machines

The Machines page displays a table with all the machines of the Aurora web service.

This table will be refreshed every 60 minutes.

### Processors

The Processor page displays a table with all the processors of the Aurora web service.

This table will be refreshed every 60 minutes.

### Templates

The Template page displays a table with all available templates of the Aurora web service. These templates can later be used in the request to add a job.

This table will be refreshed every 60 minutes.

### Webpage

This page will lead to the webpage of the web service.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
