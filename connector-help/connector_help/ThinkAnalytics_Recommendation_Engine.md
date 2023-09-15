---
uid: Connector_help_ThinkAnalytics_Recommendation_Engine
---

# ThinkAnalytics Recommendation Engine

With this connector, it is possible to monitor logging files.

## About

This connector retrieves logging files, parses them, and gathers the extracted information into several tables for monitoring purposes via an SFTP connection. Recommendation information is also retrieved via an HTTP connection and stored in a table.

The connector can work in 2 modes: *Application* and *Reporting.* The information retrieved in each of these modes and the way to configure these modes are discussed below.

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP CONNECTION:**

- **IP address/host:** The polling IP or URL of the destination, e.g. *10.67.0.34*.
- **IP port:** The IP port of the destination, e.g. *8080*.
- **Bus address:** To be able to retrieve the *TA Application* information, fill in the value *ByPassProxy*. Otherwise, if you connect to a *TA Reporting* device, set the value *reporting*.

## Usage

### General

This page contains all the information concerning the SFTP connection and the HTTP response.

The **SFTP Connection Status** parameter indicates the current status of the SFTP connection.
You can specify the credentials with the parameters **Login** and **Password**, and then click the **Connect** button to establish the connection to the device.

To display the fetching status for the different logging files, click the **Files Status** page button.

The **Recommendations Result Table** (only filled in in the Application Mode) displays the recommendation information such as the **Content Item ID, Content Item Name**, **Content Genre** and **Content Rating**.

Finally, to manually trigger polling of all the data again, click the **Refresh** button.

### Ingest

This page displays the **Ingest Table** and the **Ingest Error Table** (only filled in in the Application Mode). The former keeps a history of all the job statuses*.* The size limit for this table can be adjusted with the **Max Entries Number** parameter. When jobs are in error, they are added in the second table.

The **Ingest Table** indicates the start time (**Time**) of the job, its name (**Job Name**), its duration (**Duration**) and status (**Status**).

The **Ingest Error Table** is similar but displays an error description in the extra column **Error Description**. Alarms can be cleared manually with the **Clear** buttons.

The **Last Update** parameter displays the time when the file was last updated. Similarly, the **Last Modified** parameter displays the time when the file was last modified on the SFTP server.

### RE System Out

On this page, RE System Out errors and warnings are shown in the **RE System Out Error Table** (only filled in in the Application Mode) with the associated **Time, Job Name, Status** and **Error Description.**

### REMON System Out

On this page, REMON System Out errors and warnings are shown in the **REMON System Out Error Table** (only filled in in the Application Mode) with the associated **Time, Job Name, Status** and **Error Description.**

### Server

On this page, server errors and warnings are shown in the **Server Error Table** (only filled in in the Application Mode) with the associated **Time, Job Name, Status** and **Error Description.**

### Central

On this page, central errors are shown in the **Central Error Table** (only filled in in the Application Mode) with the associated **Time, Job Name, Status** and **Error Description.**

### Host

On this page, host errors are shown in the **Host Error Table** (only filled in in the Application Mode) with the associated **Time, Job Name, Status** and **Error Description.**

### REP ETL System Out

On this page, REP ETL System Out errors and successes are shown in the **REP ETL System Out Error Table** (only filled in in the Reporting Mode) with the associated **Time, Job Name, Status** and **Error Description.**

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
