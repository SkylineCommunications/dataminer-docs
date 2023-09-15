---
uid: Connector_help_Tektronix_Config_Manager
---

# Tektronix Config Manager

The **Tektronix Config Manager** is an application that can configure Tektronix probe elements.

## About

This application can be used to configure probe elements. The following connectors are supported: **Tektronix Sentry, Tektronix Sentry Edge** and **Tektronix Sentry PVQ**.

Configuration input must be specified manually or by importing a file from previous configurations.

### Version Info

| **Range** | **Description**                                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                                                                                  | No                  | No                      |
| 1.0.1.x          | Added support for source-to-probe linking.                                                                                                        | No                  | Yes                     |
| 1.1.0.x          | Only works together with the latest version of the Tektronix Sentry (1.3.0.x), Tektronix Sentry Edge (1.3.0.x) and Tektronix Sentry PVQ (1.4.0.x) | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

### Configuration (prior to 1.1.0.x)

For the configuration input, **.csv files** must be exported from a **Cisco DCM** element and placed in the right folder.

To do so:

1. Open a **Cisco DCM** element in DataMiner Cube.
1. Go to the **Table Data** page, and click the **Output** page buttons for **TS** and **Services**.
1. Create a .csv export for the **Output TS Table** and the **Output Service Table**.
1. Add two extra columns to the export of the **Output TS Table**: the **Source IP Main** and **Source IP Backup** columns**.**
1. Place these exported .csv files in the **Documents** **folder** of the **Tektronix Config Manager**.

## Usage (Range 1.0.0.x)

### Probe Elements

Opening the application will only show the **Probe Elements** page.

This page contains a **Refresh** button to manually refresh all the elements and read out the documents folder. This refresh happens automatically every 5 minutes.

The **Probe Elements** **Table** displays all the elements found in the cluster that have the supported protocols. The table contains the element name, protocol name and the views to which each element belongs. A filter box is available to quickly find elements that match a particular filter.

You can configure the elements via the context menu:

1. Select one or multiple rows, right-click, and select **Load Configuration**.

1. In the dialog box, select the applicable .csv files in the drop-down lists. These are the .csv files found in the **Documents folder** of the **Tektronix Config Manager** directory.

   Alternatively, you can also enter a complete file path or a file path starting from a subfolder in the Documents folder, and select the appropriate **TS Config File** and **Service Config File**. Note that the file path may not start with "\\.

1. Click *OK*.

   The configuration will now be applied to the selected elements.

The current status can be found in the **Probe Last Load State** column parameter. This parameter can have the following values:

- *Unknown*: No config has ever been loaded to the probe element since it became active.
- *Busy Loading MPEG*: The configuration for the MPEG input ports has been sent to the probe element and is currently being set on the device.
- *Waiting to Load Group*: MPEG input ports were correctly set on the device, and currently a 2-minute wait is going on to let the device detect the services on the configured ports.
- *Busy Loading Group*: The configuration has been sent to the probe element to place all the detected services in one OUTAGE program group, and this is currently being set on the device.
- *Ok*: All configuration is done.
- *Too Much TS in File*: More TS were found in the config file than there are MPEG input ports available on the device.
- *File not Found*: The configuration file specified in the dialog box could not be found.
- *Malformed File*: Required fields in the config file could not be found.
- *Could not set Values*: The sets were done on the device, but the values did not change.
- *Timeout Element*: The probe element is in timeout state.
- *Element not Responding*: The probe element did not give any feedback to the manager within 30 seconds.
- *Error*: Unspecified error.
- *Ports set, no Services Found*: MPEG input ports were configured but none of the ports contain a service.

### Source Elements

The **Source Elements** page provides an overview of the source elements that can provide content to be monitored by a probe, along with the associated port and pair definitions.

The **Source Elements Table** displays an overview of the elements found in the cluster that have the supported protocols. Currently, only elements running the protocol Cisco DCM are included. To update the table, click the **Refresh** button. If a source element is no longer available, the status of that element will be updated to *Unavailable*.

To remove an element from the table, select the line mentioning the element, right-click it, and select **Delete selected row** in the context menu. Note that removing an element from the Source Elements Table will also remove all ports, pairs and links that use this source element.

The **Output Ports Table** provides an overview of the port definitions. A port definition consists of a **Port Name**, a **Source Element** and a **Primary** and **Secondary IP Address**. In order to add a port definition, right-click and select **Add Output Port** in the context menu. This will open a new window where you can provide the port definition details.

The following restrictions apply:

- A port name must be unique.
- The primary IP address and secondary IP address must be either an IPv4 address (e.g. "192.168.10.1") or the wildcard character (i.e. "\*").
- The primary and secondary IP address cannot be the same.
- The combination of source element, primary IP address and secondary IP address must be unique.

Once a port has been defined, you can change the IP configuration settings by opening the context menu and selecting **Edit IP Config**. Note that when you edit the IP addresses, the same restrictions apply as mentioned above.

To remove a port definition, select the line mentioning the port, right-click it, and select **Delete selected row(s)** in the context menu. However, note that removing a port will also remove all pairs and links that use this port.

You can populate the Output Ports Table by importing a **CSV file**. To import a CSV file, right-click the table and select **Import** in the context menu. Then select a file from the **Ports File** drop-down box**.** Note that only files matching the table definition in the **Documents** **folder** of the **Tektronix Config Manager** are included.

During an import, a number of checks are performed (the data in the import file is subject to the same restrictions as mentioned above). Also note that in order for a port to be imported, the source element has to be present in the source elements table.

The **Output Pairs Table** provides an overview of the pair definitions. A pair definition consists of a **Pair Name**, a **Main Port Name** and a **Backup Port Name**. In order to add a pair definition, right-click and select **Add Output Pair** in the context menu. This will open a new window where you can provide the pair definition details.

The following restrictions apply:

- A pair name must be unique.
- The backup port can be set to *Disabled*. In this case, only a main port is present.
- The combination of main port name and backup port name must be unique.

To remove a pair definition, select the line mentioning the pair, right-click it, and select **Delete selected row(s)** in the context menu. Note that removing a pair will also remove all links that use this pair.

The Output Pairs Table can be populated by importing a CSV file. To import a CSV file, right-click the table and select **Import** in the context menu. Then select a file from the **Pairs File** drop-down box**.** Note that only files matching the table definition in the **Documents** **folder** of the **Tektronix Config Manager** are included**.**

During an import, a number of checks are performed (the data in the import file is subject to the same restrictions as mentioned above). Also note that in order for a pair to be imported, the ports mentioned as main or backup port have to be present in the Ports table.

### Links

The **Links** page provides an overview of the links that are present between output pairs and probe elements. Each link also indicates whether source splitting needs to be performed or not.

The **Links Table** displays an overview of the link definitions. A link definition consists of a **Link Name**, an **Output Pair Name**, a **Probe Element Name** and a **Source Splitting Configuration**. In order to add a link definition, right-click, and select **Add Link** in the context menu. This will open a new window where you can provide the link definition details.

The following restrictions apply:

- A link name must be unique.
- The combination of output pair name, probe element name and source splitting configuration must be unique.

To remove a link definition, select the line mentioning the link, right-click to open the context menu, and select **Delete selected row(s)**.

The Links Table can be populated by importing a CSV file. To import a CSV file, right-click the table, and select **Import** in the context menu. Then select a file from the **Link File** drop-down box. Note that only files matching the table definition in the **Documents** **folder** of the **Tektronix Config Manager** are included.

During an import, a number of checks are performed (the data in the import file is subject to the same restrictions as mentioned above). Also note that in order for a link to be imported, the output pair and probe element name have to be present in the Output Pairs table and Probe Elements Table, respectively.

When importing, follow the following workflow:

- Verify that all source elements and probe elements have been created and are present in the Source Elements Table and Probe Elements Table, respectively.
- Import the port definitions.
- Import the pair definitions.
- Import the link definitions.

### Generate Config Files

With this page, you can generate all the necessary CSV files to configure the probes, using data from the Cisco DCM and RFGW elements.

## Usage (Range 1.0.1.x)

### Source Elements

This page contains an overview of the source elements (i.e. the DataMiner elements running the protocol "Cisco DCM") in the **Source Elements Table**.

In this table:

- The **State** column indicates whether the device is *Available* (i.e. the element is active and is not in timeout state) or *Unavailable*.
- The toggle button in the **Source Subscription** column allows you to enable or disable SLNet subscriptions for a given source element.
  In order to retrieve messages from a source element, Source Subscription has to be set to *Enabled*.
  *Note:* The **SLNet Subscriptions** parameter on the General page needs to be set to *Enabled* before any source element can be subscribed to.

The **Source Elements Table** is automatically refreshed every 30 minutes. You can also refresh the table manually by pressing the **Refresh** button.

### Probe Elements

This page contains an overview of the probe elements (i.e. elements in the DataMiner System running the "Tektronix Sentry" or "Tektronix Sentry PVQ" protocol) in the **Probe Elements Table**.

In this table:

- The **State** column indicates whether the probe is *Available* (i.e. the element is active and is not in timeout) or *Unavailable*.
- The toggle button in the **Source Subscription** column allows you to enable or disable SLNet subscriptions for a given probe.
  In order to retrieve messages from a probe element, **Source Subscription** has to be set to *Enabled*.
  *Note:* The **SLNet Subscriptions** parameter on the General page needs to be set to *Enabled* before any probe element can be subscribed to.

The **Probe Elements Table** is automatically refreshed every 30 minutes. You can also refresh the table manually by pressing the **Refresh** button.

Each probe has a certain capacity (indicated in the **Capacity** column). The connector allows you to define a maximum limit on the allowed capacity for a probe. You can do so by setting the **Percentage Allowed** parameter. The **Allowed Capacity** is checked when new configurations are added to a probe.

### TS Detection

When a message arrives from a DCM indicating a newly detected TS, the configuration manager will determine which probes could be monitoring it according to the configuration that has been provided on the **Configuration** page:

- If the configuration manager connector can find the stream on one of the probes, this means the stream is already configured and no other action is needed.
- If the configuration manager cannot find the stream on one of the probes, a new row will be added to the **Detected Transport Streams Table** (in case it is not already present and it is not present in the **Masked Transport Streams Table**).

The **Detected Transport Streams Table** will show the possible probe configuration options (if any) from which you can choose.

You can select a configuration via the **Main Probe** column drop-down box, and then apply the configuration by right-clicking and selecting **Apply** in the context menu. When you do so, a message will be sent to the message queue (in case the probe or probes are available). Please note that the TS will only be configured in the probe (main or/and backup) candidate if there is at least one port in the **MPEG Input Ports table** with **Port In Use = No**, which means that at least one port is available to be configured. Once the message is processed and everything has succeeded, the row is removed from the table. If something went wrong, feedback will be displayed in the **Status** column.

A stream can be masked until a certain time or until further notice. In both cases, the row will be moved to the **Masked Transport Streams Table**. If the set time for a masked stream has passed, the row will be added to the **Detected Transport Streams Table** again. To unmask masked streams that are masked until further notice, right-click a selected row, and select **Unmask** in the context menu.

### TS Reconfiguration

When a message arrives from a probe reporting that a transport stream is down (i.e. the Port Status parameter is down for a given transport stream), a new row will be added to the **Transport Stream Reconfiguration Table**.

- In case of manual reconfiguration, the possible configuration options will be displayed in the **Manual Reconfiguration Selection** column. When you select one of these options, a new message will be added to the message queue.
- In case of automatic reconfiguration, if there are reconfiguration options available, the connector will automatically start reconfiguring. The connector will try all possible configurations until a reconfiguration succeeds. Note that between every reconfiguration, the connector will wait for a certain amount of time (configurable via the **Delay** parameter on the **Options** page). When every possible configuration has been tried and has failed, the connector will wait for an additional amount of time (configurable via the **Sliding Window** parameter on the **Options** page).

### Configuration

This page allows you to configure the links between the source elements and the probe elements.

The **Output Ports Table** provides an overview of the output ports that have been defined in the current configuration. Each output port defines a primary IP (**Source Primary IP Address**) and secondary IP address (**Source Secondary IP Address**) for a given output port (i.e. a port (**Port Idx**) on a given board (**Board Idx**) of a source element (**Source Element Name**)).

The **Output Pairs Table** provides an overview of the defined output pairs in the current configuration. Each output pair is a combination of two output ports defined in the **Output Ports Table**. Note that a port can only be part of one output pair.

The **Reconfiguration Mode** toggle button allows you to choose between *Manual* or *Automatic* reconfiguration. In case of automatic reconfiguration, the manager connector automatically selects and applies a reconfiguration. If manual reconfiguration is selected, you will need to select the preferred reconfiguration from a list of possible configurations and then apply it.

The **Links Table** provides an overview of the links defined in the current configuration. A link is defined as a connection between an output pair (defined in the **Output Pairs Table**) and one or two monitoring probes (defined in the **Probe Elements Table**).

In this table:

- The **Source Splitting Configuration** column shows the source splitting configuration for a given link. When no source splitting is applied, the main and backup probe can use the primary and secondary IP address of the main and backup port. If source splitting is applied, the main probe will only consider the primary and secondary IP address of the main port, and the backup probe will only consider the primary and secondary IP address of the backup port.
- To define a link, select **Add Link** in the table's context menu.
- To edit or remove a link, right-click the link and select **Edit** or **Delete Selected Row(s)** in the context menu.
- To import or export an entire table, select **Import** or **Other** \> **Export Table** in the context menu.

Note that the order in which the configuration is set up is important. As an output pair depends on the output ports defined in the Output Ports Table, the output ports need to be defined first. Similarly, a link depends on output pairs and probes, so these tables must contain data before a link can be defined.

In summary, in order to set up a configuration, the necessary source and probe elements must be present in the **Source Elements Table** and **Probe Elements Table**, and then the output ports, output pairs and links can each in turn be defined.

### General

This page contains the **SLNet Subscription** parameter, which allows you to enable/disable SLNet subscriptions.

Click the **Message Queue** page button to get an overview of the messages that are currently in the message queue. Note that the parameter **Message Queue Monitoring** needs to be set to *Enabled* to make it possible to monitor the message queue.

*Note*: Message queue monitoring should be set to disabled for normal operation.

## Usage (Range 1.1.0.x)

### DCM TS Detection

Only applicable for **Tektronix Sentry** and **Tektronix Sentry PVQ** probes.

This page contains the **DCM Detected Transport Streams Table**, which shows all the multicast IPs that are not yet configured on the probe. This table is filled up with the streams located in the DCMs that are configured in the Probe Configuration Table (see "DCM Configuration" page). This table is refreshed every hour, but can also be manually refreshed at any time with the **Refresh** button.

To configure streams in the Tektronix Sentry probes mentioned above, right-click the relevant rows and click **Apply**. This will configure those streams on the probe. In case something goes wrong, the probe will send an error message back, which will be displayed in the **Error Logging Table**.

To apply a detected transport stream:

1. Select one or more rows in the table.
1. Right-click the selected row(s) and select **Apply** in the context menu to push the change to the probe(s).

### DCM Configuration

This page contains the **DCM Configuration Table**, where you can configure the Cisco DCMs that will be used. Each DCM can have four boards, for each board there are four ports, and for each port you can assign a source IP. This will be used to set the probe.

Below this, you can find the **Probe Configuration Table**, which allows you to link a probe with a DCM that will act as "Main" and, if necessary, a DCM that will act as "Backup". When you do so, define which DCMs to use and which board and port.

It is also possible to enable **Source Splitting** for linked probes with the same DCM settings. The streams from that DCM will then be split over the two probes linked to it.

Both of these tables can be exported and imported.

To add a DCM configuration:

1. Right-click the DCM Configuration table, and select **Add** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **Element Name**: Select a Cisco DCM in the list.
   - **Board**: Specify the board inside the DCM.
   - **IP Port 1**: Specify the IP address for this specific port. Can optionally be NA.
   - **IP Port 2**: Specify the IP address for this specific port. Can optionally be NA.
   - **IP Port 3**: Specify the IP address for this specific port. Can optionally be NA.
   - **IP Port 4**: Specify the IP address for this specific port. Can optionally be NA.

1. Click **OK** to add the DCM configuration to the table.

To edit a DCM configuration:

1. Right-click on a row in the DCM Configuration table and select **Edit** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **IP Port 1**: Specify the IP address for this specific port. Can optionally be NA.
   - **IP Port 2**: Specify the IP address for this specific port. Can optionally be NA.
   - **IP Port 3**: Specify the IP address for this specific port. Can optionally be NA.
   - **IP Port 4**: Specify the IP address for this specific port. Can optionally be NA.

1. Click **OK** to update the row.

To remove one or more DCM configurations:

1. Select one or more rows in the DCM Configuration table.

1. Right-click the selected row(s) and select **Remove** in the context menu.

   All the selected rows will be removed from the table.

To export the DCM Configuration table:

1. Right-click the DCM Configuration table and select **Export** in the context menu.

1. In the pop-up window, specify the **File Name** of the export file.

1. Click **OK** to export the table to a CSV file in the folder *Documents\Tektronix Config Manager\DCM Configuration\DCM Configuration Table\\*.

To import a DCM Configuration table:

1. Right-click the DCM Configuration table and select **Import** in the context menu.

1. In the pop-up window, specify the **Import File Name**, i.e. the name of one of the files in the folder *Documents\Tektronix Config Manager\DCM Configuration\DCM Configuration Table\\*.

1. Clicking **OK** to import the table from the CSV file.

To add a probe configuration:

1. Right-click the Probe Configuration table and select **Add** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **Linked Probe**: Select a probe from the list.
   - **Main DCM**: Select a Cisco DCM from the list (based on the DCM Configuration table).
   - **Main Board**: Specify the board inside the DCM.
   - **Main Port**: Specify the port inside the DCM.
   - **Backup** **DCM**: Select a Cisco DCM from the list (based on the DCM Configuration table). Can optionally be NA.
   - **Backup Board**: Specify the board inside the backup DCM. Can optionally be NA.
   - **Backup Port**: Specify the port inside the backup DCM. Can optionally be NA.
   - **Source Splitting**: Allows you to enable source splitting.

1. Click **OK** to add the probe configuration to the table.

To duplicate a probe configuration:

1. Right-click a row in the Probe Configuration table and select **Duplicate** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **Linked Probe**: Select a probe from the list.
   - **Main DCM**: Select a Cisco DCM from the list (based on the DCM Configuration table).
   - **Main Board**: Specify the board inside the DCM.
   - **Main Port**: Specify the port inside the DCM.
   - **Backup DCM**: Select a Cisco DCM from the list (based on the DCM Configuration table). Can optionally be NA.
   - **Backup Board**: Specify the board inside the backup DCM. Can optionally be NA.
   - **Backup Port**: Specify the port inside the backup DCM. Can optionally be NA.
   - **Source Splitting**: Allows you to enable source splitting.

1. Click **OK** to add the probe configuration to the table.

To edit a probe configuration:

1. Right-click a row in the Probe Configuration table and select **Edit** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **Linked Probe**: Select a probe from the list.
   - **Main DCM**: Select a Cisco DCM from the list (based on the DCM Configuration table).
   - **Main Board**: Specify the board inside the DCM.
   - **Main Port**: Specify the port inside the DCM.
   - **Backup DCM**: Select a Cisco DCM from the list (based on the DCM Configuration table). Can optionally be NA.
   - **Backup Board**: Specify the board inside the DCM. Can optionally be NA.
   - **Backup Port**: Specify the port inside the DCM. Can optionally be NA.
   - **Source Splitting**: Allows you to enable source splitting.

1. Click **OK** to update the row.

To remove a probe configuration:

1. Select one or more rows in the Probe Configuration table.

1. Right-click the row(s) and select **Remove** in the context menu.

To export the Probe Configuration table:

1. Right-click the Probe Configuration table and select **Export** in the context menu.

1. In the pop-up window, specify the **File Name** of the export file.

1. Click **OK** to export the table to a CSV file in the folder *Documents\Tektronix Config Manager\DCM Configuration\Probe Configuration Table\\*.

To import a Probe Configuration table:

1. Right-click the Probe Configuration table and select **Import** in the context menu.

1. In the pop-up window, specify the **Import File Name**, i.e. the name of one of the files in the folder *Documents\Tektronix Config Manager\DCM Configuration\Probe Configuration Table\\*.

1. Click **OK** to import the table from the CSV file.

### RF Ports Detection

This page is similar to the DCM TS Detection page, but is only applicable for **Tektronix Sentry Edge** probes.

It displays the **Detected Ports Table**, with data read out from the defined Cisco RFGWs (i.e. RF gateways) (see "RF Configuration" page). As this table does not change often, it is only refreshed daily. However, you can also trigger a manual refresh at any time with the **Refresh** button.

To apply one or more detected RF ports:

1. Select one or more rows in the table.

1. Right-click the row(s) and select **Apply Selected Row(s)** in the context menu to push the change to the RF probe(s).

### RF Configuration

This page contains the **RF Pairs Table**, where you can configure each edge probe and link it with up to four RFGWs. When the Detected Ports Table is refreshed, the new or edited rows can be automatically configured if this is specified in the RF Pairs Table. For this, you need to put the **Reconfiguration Mode** column to *Automatic*.

This table can be exported and imported.

To add an RF pair:

1. Right-click the table and select **Add Pair** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **Probe Name**: Select one of the Tektronix Sentry Edge probes from the list.
   - **RF Gateway 1**: Select one of the Cisco RFGW elements from the list.
   - **RF Gatew**ay** 2**: Select one of the Cisco RFGW elements from the list.
   - **RF Gateway 3**: Select one of the Cisco RFGW elements from the list. Optionally, you can also select NA if no more RFGWs are available.
   - **RF Gateway 4**: Select one of the Cisco RFGW elements from the list. Optionally, you can also select NA if no more RFGWs are available.
   - **Reconfiguration Mode**: Determines whether changes will be pushed to the probe when a refresh occurs.

1. Click **OK** to add it to the table.

To edit an RF pair:

1. Right-click the table and select **Edit Pair** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **RF Gateway 1**: Select one of the Cisco RFGW elements from the list.
   - **RF Gateway 2**: Select one of the Cisco RFGW elements from the list.
   - **RF Gateway 3**: Select one of the Cisco RFGW elements from the list. Optionally, you can also select NA if no more RFGWs are available.
   - **RF Gateway 4**: Select one of the Cisco RFGW elements from the list. Optionally, you can also select NA if no more RFGWs are available.
   - **Reconfiguration Mode**: Determines whether changes will be pushed to the probe when a refresh occurs.

1. Click **OK** to update the row.

To remove one or more RF pairs:

1. Select one or more rows in the table.

1. Right-click the selected row(s) and select **Remove Pair(s)** in the context menu to remove all the selected rows from the table.

To export the RF Pairs Table:

1. Right-click the table and select **Export** in the context menu.

1. In the pop-up window, specify the **File Name** of the export file.

1. Click **OK** to export the table to a CSV file in the folder *Documents\Tektronix Config Manager\RF Configuration\RF Pairs Table\\*.

To import an RF Pairs Table:

1. Right-click the table and select **Import** in the context menu.

1. In the pop-up window, specify the **Import File Name**, i.e. the name of one of the files in the folder *Documents\Tektronix Config Manager\RF Configuration\RF Pairs Table\\*.

1. Click **OK** to import the table from the CSV file.

### Service Detection

This page applies to all three probes. It shows the **Service Configuration Table**, which contains all the services that are configured on each probe in the entire system. The table is refreshed every hour, but can also be refreshed manually at any time with the **Refresh** button. The table can be exported and imported.

For each service, you can specify an **Alert Template Name** in the corresponding column in this table. These need to be configured in the Alert Template Configuration Table (see "Service Configuration" page). When an alert name has been configured, click the **Apply** button or select Apply in the context menu to configure a service with the corresponding alert for each probe that has that service. If something goes wrong, the error message will be displayed in the **Error Logging Table** below.

When a service is no longer used in the entire system, you can remove it from the table via the **Remove** button column. If many services are no longer used, you can remove them all at once with the **Remove Empty** button.

To configure a service:

1. Via a button in the row:

   1. Click the **Apply** button for the specific service you want to configure.

   1. In the confirmation box, click **OK** to push the alert template configuration to all the probes that contain that service.

1. Via the context menu:

   1. Select one or more rows in the table and right-click them.

   1. In the context menu, select **Configure** to push the alert template configurations to the probes that contain these services.

To remove empty services (i.e. services that are no longer in any probe):

1. Via a button in the row:

   1. Click the **Remove** button for the specific service you want to remove. This button is disabled as long as the service is somewhere on a probe (which is shown in the **Associated Probes** column).

   1. In the confirmation box, click **OK** to remove the service from the table.

1. Via the context menu:

   1. Select one or more rows in the table and right-click them.
   1. In the context menu, select **Remove Row(s)** to remove the selected empty service(s) from the table.

1. With the **Remove Empty** button:

   - Click the **Remove Empty** button to remove all the empty services from the table.

To export the table:

1. Right-click the table and select Export in the context menu.

1. In the pop-up window, specify the **File Name** of the export file.

1. Click **OK** to export the table to a CSV file in the folder *Documents\Tektronix Config Manager\Service Configuration\Service Configuration Table*.

To import a table:

1. Right-click the table and select **Import** in the context menu.

1. In the pop-up window, specify the **Import File Name**, i.e. the name of one of the files in the folder *Documents\Tektronix Config Manager\Service Configuration\Service Configuration Table.*

1. Click **OK** to import the table from the CSV file.

### Service Configuration

This page contains the **Alert Template Configuration Table**, where you can specify the **Alert Template Names** that you want to use and the JSON files. Those JSON files contain the structure to create the templates on the probe. Such an import file for an alert template should be exported from a Tektronix Sentry, Tektronix Sentry Edge or Tektronix Sentry PVQ. This functionality is described in the help files of these protocols in the subsection "Usage (Since 1.3.0.x)", page "Program Template".

Add these files to **DOCUMENTS \> Tektronix Config Manager \> Alert Template Configurations** (via the element card in DataMiner Cube). For each probe, you can specify which template to use, as some options are not always available for all three.

After you have added the files, click the **Refresh Files** button, so when you add a new Alert Template Name, you can select the templates that are located in the folder. If you wish to apply a template instead of a service on its own, you can click the **Apply** button to configure all the services that are linked to that template name.

This page also displays the **Service Name Separator**. This will split the service names and sort them based on the first entry, for example:

- Service ABC and Service ABC_DEF are the same service, but one of the names has a suffix. If you specify "\_" as the separator, these will be displayed as "ABC" in the Service Configuration Table (see "Service Detection" page).

To add an alert template:

1. Make sure that there are **alert template configurations** in the folder *Documents\Tektronix Config Manager\Alert Template Configurations\\*.

1. Right-click the Alert Template Configuration Table and click **Add**.

1. Configure the following parameters in the pop-up window:

   - **Alert Template Name**: Specify a name for the alert template.
   - **Configuration File Sentry**: Specify which JSON file is used with the alert template for the Tektronix Sentry probes.
   - **Configuration File Sentry Edge**: Specify which JSON file is used with the alert template for the Tektronix Sentry Edge probes.
   - **Configuration File Sentry PVQ**: Specify which JSON file is used with the alert template for the Tektronix Sentry PVQ probes.

1. Click **OK** to add it to the table.

To edit an alert template:

1. Right-click a row in the table and select **Edit** in the context menu.

1. Configure the following parameters in the pop-up window:

   - **Configuration File Sentry**: Specify which JSON file is used with the alert template for the Tektronix Sentry probes.
   - **Configuration File Sentry Edge**: Specify which JSON file is used with the alert template for the Tektronix Sentry Edge probes.
   - **Configuration File Sentry PVQ**: Specify which JSON file is used with the alert template for the Tektronix Sentry PVQ probes.

1. Click **OK** to update the row.

To remove one or more alert templates:

- Select one or more rows in the table and select **Remove** in the context menu.
- In the confirmation box, which is intended to prevent accidental deletion of rows, click **OK** to confirm that the rows can be removed.

To export the Alert Template Configuration Table:

1. Right-click the table and select **Export** in the context menu.
1. In the pop-up window, specify the **File Name** of the export file.
1. Click **OK** to export the table to a CSV file in the folder *Documents\Tektronix Config Manager\Service Configuration\Alert Template Configuration Table\\*.

To import the Alert Template Configuration Table:

1. Right-click the table and select **Import** in the context menu.
1. In the pop-up window, specify the **Import File Name**, i.e. the name of one of the files in the folder *Documents\Tektronix Config Manager\Service Configuration\Alert Template Configuration Table\\*.
1. Click **OK** to import the table from the CSV file.

To configure an alert template to all probes:

- Press the **Configure** button in a particular row to push the alert template configuration to the probes that have services configured with that template name. (See "Service Detection")

### Source Elements

This page contains an overview of the source elements (i.e. the DataMiner elements running the protocol "Cisco DCM") in the **Source Elements Table**.

In this table, the **State** column indicates whether the device is *Active, Stopped*, etc.

The table is automatically refreshed every 30 minutes, but can also be refreshed manually with the **Refresh** button.

### Probe Elements

On this page, the Probe Elements Table displays an overview of the probe elements, i.e. the elements in the DataMiner System running the "Tektronix Sentry", "Tektronix Sentry Edge" or "Tektronix Sentry PVQ" protocol.

In this table, the **State** column indicates whether each probe is *Active, Stopped*, etc.

The table is automatically refreshed every 30 minutes, but can also be refreshed manually with the **Refresh** button.

Each probe has a certain capacity (indicated in the **Capacity** column). The connector allows you to define a maximum limit on the allowed capacity for a probe. You can do so by setting the **Percentage Allowed** parameter. The **Allowed Capacity** is checked when new configurations are added to a probe.

If you want to configure the probe completely at once, you can make use of the **Set MPEG Ports** column, **Initial Config Ports** column and the **Initial Config Services** column.

- **Set MPEG Ports**:

- Only applicable for **Tektronix Sentry and Tektronix Sentry PVQ**.
  - This will set the **Port Status** column on the probe to *Manager*. This way you define that you can configure everything on the probe.

- **Initial Config Ports**:

- Applicable for **all** probes.
  - This will try to configure the probe completely for the MPEG settings. It will read out all the streams in the linked DCMs and set all those streams ordered by multicast IP.

- **Initial Config Services**:

- Applicable for **all** probes.
  - This will try to configure all the services that have an alert configured on that probe.

### Debug

This page is only intended for debugging purposes. It allows you to enable **Detailed** **Logging**. Note that this will cause a lot more logging in the Element Logging, so we advise you not to leave this set to *Enabled* any longer than is strictly necessary.
