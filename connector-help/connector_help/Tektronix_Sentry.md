---
uid: Connector_help_Tektronix_Sentry
---

# Tektronix Sentry

The **Tektronix Sentry** connector will display information related to the **Sentry** device.

## About

The **Tektronix Sentry** connector will display information related to the selected **Sentry** device. This information and details, such as Ports, Transport and Services, are available on different pages, described in the "Usage" section of this document. Alarm monitoring and trending are possible for some of the parameters in the connector, e.g. the **bitrate**.

**Note: This connector requires the .Net Framework 4.0.**

### Version Info

| **Range** | **Description**                                                                                                                                         | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                         | No                  | Yes                     |
| 1.1.0.x          | New firmware based on 1.0.0.x (see below)                                                                                                               | No                  | Yes                     |
| 1.2.0.x          | New firmware based on 1.2.0.x (see below)                                                                                                               | No                  | Yes                     |
| 1.2.1.x          | Change to display key in Program Trap Table.                                                                                                            | No                  | Yes                     |
| 1.3.0.x          | Supports firmware version 10.3 Improved communication with Tektronix Config Manager Works with the latest version of Tektronix Config Manager (1.1.0.x) | No                  | Yes                     |
| 1.4.0.x          | New range for firmware 10.6.6 Add ABR parameters for program statistics                                                                                 | No                  | Yes                     |
| 1.5.0.x          | New range for firmware 10.7.3                                                                                                                           | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                        |
|------------------|--------------------------------------------------------------------|
| 1.0.0.x          | Older versions                                                     |
| 1.1.0.x          | 9.3                                                                |
| 1.2.0.x          | 9.4                                                                |
| 1.3.0.x          | 10.3+ (10.4 also works with this connector range; tested with 10.4.3) |
| 1.4.0.x          | 10.6.6                                                             |
| 1.5.0.x          | 10.7.3                                                             |

## Installation and configuration

### Creation

SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration (Before 1.3.0.x)

The first time you start a **Tektronix Sentry** element, enter a username and a password in the **Configuration** dialog box.

1. Go to the **General** page.
1. Click the **Configuration** page button.
1. Enter the **Username** and **Password**.
1. Select to **Enable**/**Disable** KPI2.
1. If necessary, change the **Timespan Value**. This setting defines which time slot is used to visualize the data. Range: *1 minute* to *60 minutes*.
1. Log on.

Note that the connector uses the JSON API, so the username that the element uses to connect to the device must be granted API access rights. To grant these rights:

1. Open the web interface.
1. Select **Configure** \> **Users**
1. Select the username.
1. Set **API Access** to *Yes*.

The API password must be the same as the password used to log in on the web interface.

### Configuration (Since 1.3.0.x)

The first time you start a **Tektronix Sentry** element, enter a username and a password in the **Configuration** dialog box.

1. Go to the **General** page.
1. Click the **Configuration** page button.
1. Enter the **Username** and **Password**.
1. Log on.

Note that the connector uses the JSON API, so the username that the element uses to connect to the device must be granted API access rights. To grant these rights:

1. Open the web interface.
1. Select **Configure** \> **Users**
1. Select the username.
1. Set **API Access** to *Yes*.

The API password must be the same as the password used to log in on the web interface.

## Usage (Before 1.3.0.x)

### General

This page contains general information regarding the device, such as the **System ID**, **Average Bitrate**, **Licensed Bitrate Device**, etc. (only available from firmware version 9.3 onwards).

There is also a page button that provides access to the **Configuration** page (see "Configuration" section above).

### Port Tree Overview

This page contains a tree overview of the device's information and details.

### Program Group Tree Overview

This page contains a tree overview of all the **program groups** and the services that belong to these program groups.

### Port Overview

This page contains two tables, which display information about the **ports** and **transport** of the device.

### Program Overview

This page provides an overview of all programs with configuration and statistical information.

The page contains page buttons that provide access to the following subpages:

- **Program Groups**: This page contains the **Program Groups** table. In this table, you can delete a program group. To add services or create a new program group, go to the **Service Overview** page.
- **Program Mappings**: This page contains the **Program Mappings** table. You can use the delete button in the table to remove a program mapping. Use the **Add** page button at the bottom of the page to define a new program mapping.

### MPEG Input Settings

This page contains one table, the **MPEG Input Ports** table. Right-clicking the table allows you to edit a specific MPEG port. The information in the table is filled in through the JSON interface.

### Service Overview

This page contains information about the available services of the device.

For every service, you can specify a custom description in the **Service Filter** column. This custom description will then be added to the **Parameter Description** in the Alarm Console.

With the **Remove from Program Group** parameter, you can remove a service from a program group.

To add services to a program group in DataMiner Cube, select one or multiple services, right-click and select **Add to Program Group**. In the dialog box, you can then select the name of an existing program group, or type a new name so that a new program group with this name will be created.

### PID Overview

This page displays information and details on the different programs of the device.

### RF Status Overview

This page contains information related to the **RF** **Status** of the device. This feature is only available on a **Sentry Edge II** device.

### ETR-290 Dashboard

This page contains information related to the **ETR-290 Summary** and **Errors table**.

### Program Traps Overview

This page displays the **Program Trap** table, which displays the program-related traps, and the **Program Traps Number** parameter, which displays the last trap number.

### PID Traps Overview

This page displays the **PID Trap Overview** table, which displays the PID-related traps, and the **PID Traps Number** parameter, which displays the last trap number.

### Table Traps Overview

This page displays the **Table Trap Overview** table, which displays the table-related traps, and the **Table Traps Number** parameter, which displays the last trap number.

### PMT Traps Overview

This page displays the **PMT Trap Overview** table, which displays the PMT-related traps, and the **PMT Traps Number** parameter, which displays the last trap number.

### Trap Configuration

The incoming traps can be aggregated into an aggregated service state. How the aggregated service state is influenced by the traps can be configured on this page.

The configuration parameters allow you to specify one or more trap types (separated by "\|", wildcards allowed). When there is an active trap matching a specified trap type, the aggregated service state will be raised to that severity. The highest severity will be used.

With the **Generate Trap Information Events** parameter, you can enable/disable the generation of an information event for each incoming trap. By default, this parameter is enabled.

### Program Template (available from 1.2.0.9 onwards)

This page contains an overview of the **Program Templates**. The content of this page is updated every 10 minutes. You can also update it immediately by pressing the button **Refresh Templates**.

The **Program Template Table**, which displays the **Template Name and Status in Probe**, allows you to **create, edit, delete, upload and export** (JSON) program templates.

The tree overview displays all the **details** of a program template: the **Description**, the **Trigger** and the details of the various **Alert Types** (Detect, Bitrate, Video, Audio, etc.).

The **Load From File** page button opens a subpage where you can **upload or load** an **exported program template.**

- To **create** a program template:

   1. Right-click in the **Program Template Table** to access the context menu.

   1. Select **Create** and provide a name for the new program template.

   1. A new entry will be created in the Trigger table and in all Alert Type tables, so that the new program template can be configured. When it has been configured, select **Upload to Probe** in the right-click menu.

- To **edit** a program template:

   1. Click the **Edit** button in the **Program Template Table** to edit an existing configuration.

   1. When ready, click the **Update Probe** button to send the new configuration to the probe.

       Alternatively, you can cancel the editing by clicking the **Cancel Edit** button.

- To **import** a program template:

   1. On the **Load From File** page, select the program template file name from the files located in the Documents folder.

   1. Apply one of the following two options:

       - **Upload to Probe**

         Note that if the program template from the file **already exists** in the **Program Template Table**, the **Status in Probe** will be evaluated.

         - If *Not Present*, the content of the file will be uploaded to the probe and the table content will be overwritten.
         - Otherwise, the existing program template will be updated.

       - **Load to Table**

         With this option, you can view and edit the configuration in the file. If everything is as expected, you can then right-click the Program Template Table and select **Upload to Probe** to upload the loaded program template.

         Note that if the program template from the file **already exists** in the **Program Template Table**, it will **not be loaded**.

- To **export** a program template:

  1. Right-click in the **Program Template Table** to access the context menu.

  1. Select **Export** and provide a name for the new program template file. The file will be saved in the Documents folder.

     Note that if the file name already exists, it will be overwritten.

### Alerts (available from 1.2.0.9 onwards)

This page contains an overview of the **Program Template Alerts**. The content of this page is updated every 10 minutes. You can also update it immediately by clicking the buttons **Refresh Alerts** or **Refresh Templates**.

The **Program Template Alert Table**, which displays the **Alert details**, allows you to **create, edit, delete, upload and export** (JSON) program template alerts.

The **Load From File** page button opens a subpage where you can **upload or load** an **exported program template alert**.

From version 1.2.0.9 of the connector onwards, the **Use Program Group** option in the **Program Template Alert Table** will be set to *True*.

- To **create** a program template alert:

  1. Right-click in the **Program Template Alert Table** to access the context menu.
  1. Select **Create** and select a program template from the drop-down list.
  1. A new entry will be created in the table, which you can then configure. When it has been configured, select **Upload to Probe** in the right-click menu.

- To **edit** a program template alert:

  1. Edit the relevant field directly in the **Program Template Alert Table**. The **Status in Probe** will change to *Editing*.
  1. When you are ready, select **Upload to Probe** in the right-click menu.

- To **import** a program template alert:

  1. On the **Load From File** page, select the program template alert file name from the files located in the Documents folder.
  1. Apply one of the following two options:

     - **Upload to Probe**
     - **Load to Table**: With this option, you can view and edit the configuration in the file. If everything is as expected, you can then right-click the Program Template Alert Table and select **Upload to Probe** to upload the loaded alert.

     > [!NOTE]
     > For both options, the program template from the file must exist in the Program Template Table. In addition, if the Program Group Name from the file already exists in the Program Template Alert Table, the content from the file will overwrite the existing content.

- To **export** a program template alert:

  1. Right-click in the Program Template Alert Table to access the context menu.
  1. Select **Export**. The file will be saved in the Documents folder.

     Note that if the file name already exists, it will be overwritten.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

The **RF Status Overview** information and details are only available on a Sentry Edge II device.

## Usage (Since 1.3.0.x)

### General

This page contains general information regarding the device, such as the **System ID**, **Average Bitrate**, **Licensed Bitrate Device**, etc.

There is also a page button that provides access to the **Configuration** page (see "Configuration" section above).

### Port Tree Overview

This page contains a tree overview of the device's information and details.

### Program Group Tree Overview

This page contains a tree overview of all the **program groups** and the services that belong to these program groups.

### Port Overview

This page contains two tables, which display information about the **ports** and **transport** of the device.

The **Port Overview** table provides detailed statistics for each configured port, including the **Discontinuities**, **Bitrate**, **TR101 Errors**, etc.

### Program Overview

This page provides an overview of all programs in the **Program Overview** table with a lot of statistical information about **Video**, **Audio**, **Closed Caption**, etc.

The page contains page buttons that provide access to the following subpages:

- **Program Groups**: This page contains the **Program Groups** table. In this table, you can delete a program group. You can only delete static program groups. To add services or create a new program group, go to the **Service Overview** page.
- **Program Mappings**: This page contains the **Program Mappings** table. You can use the delete button in the table to remove a program mapping. Use the **Add** page button at the bottom of the page to define a new program mapping.
- **Program Overview Config**: This page contains the **Program Overview Display Key Format** parameter. This determines what the display key in the Service Overview Table will look like.
- **ABR Statistics:** This page contains the **ABR Statistics** table, where you can view the program fragment statistics.

### MPEG Input Settings

This page contains one table, the **MPEG Input Ports** table. Right-clicking the table allows you to edit a specific MPEG port. The information in the table is filled in through the JSON interface. You have the option to specify a main and also a backup if necessary.

The **Port Status** column is used by the **Tektronix Configuration Manager**. This connector can configure this table.

### Service Overview

This page contains information about the available services of the device.

For every service, you can specify a custom description in the **Service Filter** column. This custom description will then be added to the **Parameter Description** in the Alarm Console.

With the **Remove from Program Group** column, you can remove a service from a program group.

To add services to a program group in DataMiner Cube, select one or multiple services, right-click and select **Add to Program Group**. In the dialog box, you can then select the name of an existing program group, or type a new name so that a new program group with this name will be created.

### PID Overview

This page displays information and details on the different programs of the device. It includes the **Audio Table**, the **Video Table** and the **PID Overview Table**, which displays the **quality** for audio and video.

### RF Status Overview

This page contains information related to the **RF** **Status** on the device. However, note that the displayed information may not be correct in the current version of this connector.

### ETR-290 Dashboard

This page displays the **ETR-290 Summary Table** and **ETR-290 Status Table**. At the top of the page, the **Timespan** can be specified for the data in the **ETR-290 Summary Table**. The **ETR-290 Status Table** will show the errors from the last minute. Because of the limitations of the device, this will be updated every 3 minutes.

### Program Traps Overview

This page displays the **Program Trap** table, which displays the program-related traps, and the **Program Traps Number** parameter, which displays the last trap number.

### PID Traps Overview

This page displays the **PID Trap Overview** table, which displays the PID-related traps, and the **PID Traps Number** parameter, which displays the last trap number.

### Table Traps Overview

This page displays the **Table Trap Overview** table, which displays the table-related traps, and the **Table Traps Number** parameter, which displays the last trap number.

### PMT Traps Overview

This page displays the **PMT Trap Overview** table, which displays the PMT-related traps, and the **PMT Traps Number** parameter, which displays the last trap number.

### Trap Configuration

The incoming traps can be aggregated into an aggregated service state. How the aggregated service state is influenced by the traps can be configured on this page.

The configuration parameters allow you to specify one or more trap types (separated by "\|", wildcards allowed). When there is an active trap matching a specified trap type, the aggregated service state will be raised to that severity. The highest severity will be used.

With the **Generate Trap Information Events** parameter, you can enable/disable the generation of an information event for each incoming trap. By default, this parameter is disabled.

### Program Template

This page contains an overview of the **Program Templates**. The content of this page is updated every 10 minutes. You can also update it immediately by pressing the button **Refresh Templates**.

The **Program Template Table**, which displays the **Template Name and Status in Probe**, allows you to **create**, **edit**, **delete**, **upload and export** (JSON) program templates.

The tree overview displays all the **details** of a program template: the **Description**, the **Trigger** and the details of the various **Alert Types** (Detect, Bitrate, Video, Audio, etc.).

The **Load From File** page button opens a subpage where you can **upload or load** an **exported program template.**

- To **create** a program template:

  1. Right-click in the **Program Template Table** to access the context menu.
  1. Select **Create** and provide a name for the new program template.
  1. A new entry will be created in the Trigger table and in all Alert Type tables, so that the new program template can be configured. When it has been configured, select **Upload to Probe** in the right-click menu.

- To **edit** a program template:

  1. Click the **Edit** button in the **Program Template Table** to edit an existing configuration.
  1. When ready, click the **Update Probe** button to send the new configuration to the probe.

     Alternatively, you can cancel the editing by clicking the **Cancel Edit** button.

- To **import** a program template:

  1. On the **Load From File** page, select the program template file name from the files located in the **Documents\Tektronix Sentry\Program Template\\** folder.
  1. Apply one of the following two options:

     - **Upload to Probe**

       Note that if the program template from the file **already** **exists** in the **Program Template Table**, the **Status in Probe** will be evaluated.

       - If *Not Present*, the content of the file will be uploaded to the probe and the table content will be overwritten.
       - Otherwise, the existing program template will be updated.

     - **Load to Table**

       With this option, you can view and edit the configuration in the file. If everything is as expected, you can then right-click the Program Template Table and select **Upload to Probe** to upload the loaded program template.

       Note that if the program template from the file **already exists** in the **Program Template Table**, it will **not be loaded**.

- To **export** a program template:

  1. Right-click in the **Program Template Table** to access the context menu.
  1. Select **Export** and provide a name for the new program template file. The file will be saved in the **Documents\Tektronix Sentry\Program Template\\** folder.

     Note that if the file name already exists, it will be overwritten.

### Alerts

This page contains an overview of the Program Template Alerts. The content of this page is updated every 10 minutes. You can also update it immediately by clicking the buttons **Refresh Alerts** or **Refresh Templates** (on the Program Template page).

The **Program Template Alert Table**, which displays the **Alert details**, allows you to **create, edit, delete, upload and export** (JSON) program template alerts.

The **Load From File** page button opens a subpage where you can **upload or load** an **exported program template alert**.

- To **create** a program template alert:

  1. Right-click in the **Program Template Alert Table** to access the context menu.
  1. Select **Create** and select a program template from the drop-down list.
  1. A new entry will be created in the table, which you can then configure. When it has been configured, select **Upload to Probe** in the right-click menu.

- To **edit** a program template alert:

  1. Edit the relevant field directly in the **Program Template Alert Table**. The **Status in Probe** will change to *Editing*.
  1. When you are ready, select **Upload to Probe** in the right-click menu.

- To **import** a program template alert:

  1. On the **Load From File** page, select the program template alert file name from the files located in the **Documents\Tektronix Sentry\Program Template\\Alert\\** folder.
  1. Apply one of the following two options:

     - **Upload to Probe**
     - **Load to Table:** With this option, you can view and edit the configuration in the file. If everything is as expected, you can then right-click the Program Template Alert Table and select **Upload to Probe** to upload the loaded alert.

     > [!NOTE]
     > For both options, the program template from the file must exist in the Program Template Table. In addition, if the Program Group Name from the file already exists in the Program Template Alert Table, the content from the file will overwrite the existing content.

- To **export** a program template alert:

  1. Right-click in the Program Template Alert Table to access the context menu.
  1. Select **Export**. The file will be saved in the **Documents\Tektronix Sentry\Program Template\\Alert\\** folder.

     Note that if the file name already exists, it will be overwritten.

### Program Alerts

This page contains an overview of the program alerts. The contents of this page are updated every 10 minutes. All the separate program alerts are displayed in the **Program Alerts Table**. Currently only the **closed caption alerts** and **discontinuity alerts** are implemented in detail.

Via the **Closed Caption** page button, you can view the CC errors with more info. This subpage also allows you to create a closed caption alert.

Via the **Discontinuity** page button, you can view the discontinuity errors with more info. On this subpage too, an alert can be created.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

### Debug

This page contains debug information in case something goes wrong.

The **Debug Logging** option can be used to enable additional element logging. However, do not leave this option set to *Enabled* any longer than necessary, as it can cause a large amount of extra logging to be generated.

If any of the API calls return an error message, this will be displayed in the **Error Message Table**. Alarm monitoring can be enabled on the **Number of Error Messages** parameter, so that users are warned when a large number of errors occur at the same time. Every hour, this parameter will be reset and the table will be cleared.

Below this, the **Communication Buffer Table** and the **State of Communication Buffer** parameter are displayed, which show all the calls that are in the queue to be sent to the device. Alarm monitoring can be enabled on the state parameter, so that users are warned when a call takes too long (i.e. remains "Busy" for a long time).

## Notes

The information and details on the **RF Status Overview** page may not be correct in this version of the connector, as this is currently still under development. It is likely that this page will later be removed, as the *Tektronix Sentry Edge* connector can be used instead.
