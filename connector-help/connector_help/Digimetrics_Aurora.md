---
uid: Connector_help_Digimetrics_Aurora
---

# Digimetrics Aurora

The Digimetrics Aurora is a high volume automated, no reference, file-based QC with easy-to-use web client and efficient fault reporting.

## About

This connector makes it possible to interact with the Aurora web service. Users can add jobs to the web service, get the status of these jobs, place a job on hold, or move the priority of a job in the queue. The connector also retrieves information from the templates, machines, processors and the VUCoreMode.

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, by default *1001*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

### Configuration for Server Information

On the **Configuration** **Settings** pop-up page, you must fill in the **User** **Name** and **Password** to make sure the information of the server can be retrieved.

### Configuration for Aurora web service

On the **General** page, you must fill in the **User** **Name** and **Password** for the Aurora web service.

It is important that this is done before sending jobs to the web service, otherwise the jobs will not be added.

## Usage

### Server Information page

The **Server** **Information** page displays general information of the server.

When you click the **Configuration.** page button, a pop-up page, the Configuration Settings page, appears. Fill in the **User** **Name** and **Password** on this page, as described in the *Configuration for Server Information* section above. Once this is done, general information about the server will be displayed, as well as a table with the different **Network** **Adapters** and a table with **Disk** **Information**.

### General page

On the **General** page, the **User** **Name** and **Password** for the Aurora web service can be filled in, as described in the *Configuration for Aurora web service* section above.

On the right-hand side, buttons are available that allow the user to manually refresh the **VUCoreMode**, **Templates**, **Machines** and **Processors**.

### Job Contracts page

On the **Job** **Contracts** page, a table is displayed containing the different job contracts. When a job is added to the web service, its job contract will be added to this table.

Every 15 minutes, the status of these jobs will be requested and the updated data will be placed in the table. Once a job is complete, its status will no longer be requested.

### Machines page

The **Machines** page displays a table with all the machines of the Aurora web service.

This table will be refreshed every 60 minutes.

### Processor page

The **Processor** page displays a table with all the processors of the Aurora web service.

This table will be refreshed every 60 minutes.

### Template page

The **Template** page displays a table with all available templates of the Aurora web service. These templates can later be used in the request to add a job.

This table will be refreshed every 60 minutes.

### Webpage

This page will lead to the webpage of the web service.
