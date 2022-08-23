---
uid: General_Main_Release_10.0.0_new_features
---

# General Main Release 10.0.0 - New features

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> From DataMiner 10.0.0/10.0.2 onwards, DataMiner Service & Resource Management also requires DataMiner Indexing.

## New features

### DMS core functionality

#### DataMiner Indexing \[ID_13370\]\[ID_13406\]\[ID_13504\]\[ID_13571\]\[ID_13623\]\[ID_13622\]\[ID_13629\] \[ID_13695\]\[ID_13769\]\[ID_13912\]\[ID_14001\]\[ID_14038\]\[ID_16287\]\[ID_16896\]\[ID_16915\]\[ID_16935\] \[ID_16959\]\[ID_17081\]\[ID_17166\]\[ID_17328\]\[ID_17851\]\[ID_18562\]\[ID_18714\]\[ID_19337\]\[ID_19437\] \[ID_19443\]\[ID_19691\]\[ID_20373\]\[ID_20845\]\[ID_20998\]\[ID_21205\]\[ID_21257\]\[ID_21634\]\[ID_22378\] \[ID_22927\]\[ID_23049\]\[ID_23998\]\[ID_24054\]\[ID_24158\]

On DataMiner Agents running Cassandra, it is possible to install a dedicated indexing database (e.g. Elasticsearch). If this so-called Indexing Engine is installed, new search features will now become available in the Alarm Console. Additional features are also being developed that will make use of the Indexing Engine in the future.

##### **Indexing system requirements**

DataMiner Indexing Engine can only be installed on DataMiner Agents with the following characteristics:

- Operating system: Windows Server 2008 R2 or higher (64-bit).

- Free RAM: At least 10 GB.

    > [!NOTE]
    > This requirement refers to the amount of free RAM in the system, not the total amount of RAM. DataMiner Indexing will always reserve 8 GB of RAM when it is in use, and an additional 2 GB of free RAM must be available to ensure that the system can run correctly.

- Average CPU usage: Lower than 70%.

- Local database type: Cassandra.

- Free hard disk space: Same amount as used by Cassandra.

- Separate hard disk from the one containing the Cassandra database.

    > [!NOTE]
    > At least 20% of the disk must remain free at all times.

- Microsoft .Net version: 4.6 or higher.

- If multiple indexing databases will be used, the latency between those databases must be less than 50 ms.

- The minimum number of nodes required in order to install DataMiner Indexing Engine depends on the number of alarms that occurred in the 24 hours prior to the installation. One node is required for every 30,000 alarms per day in the DMS.

> [!NOTE]
> If not all DMAs in the DataMiner System use Cassandra, the button to start the Indexing Engine installation wizard is unavailable. Other system requirements can be checked in the first step of the wizard.

##### Installing the Indexing Engine

To install the Indexing Engine, go to DataMiner Cube’s System Center, select *Search & Indexing*, click the button *Install Indexing Engine...*, and then follow the wizard.

> [!NOTE]
> The *Search & Indexing* page in System Center is only available for users with the user permission *Modules* > *System configuration* > *Indexing engine* > *Configure*.

Like the wizard for the Cassandra migration, the wizard will first check whether the system requirements are met. If necessary, you can close the wizard again in order to continue later after the necessary changes have been made. In case changes are implemented while the wizard is open, a button is available that allows you to refresh the validation data.

Once the installation process is completed, reconnect to DataMiner to make sure all functionality is available.

Please note the following regarding the indexing database:

- In the wizard, you can select on which DMAs in a DMS you install DataMiner Indexing. You will only be able to start the installation if the required minimum number of Agents in the DMS is selected. This minimum number depends on the total number of DMAs in the system. If there are 3 or less DMAs in the system, all DMAs must be selected, otherwise at least 3 DMAs must be selected.

- When several DMAs in a DataMiner System have an indexing database installed, all indexes in all those indexing databases will be linked. That way, when a user launches a search on one DMA, all indexing databases in the DataMiner System will be queried.

- If an indexing database is installed on a Failover system, a database instance will be installed on each of the DMAs, and both instances will be clustered. Also, when a DMA with an indexing database and a DMA without an indexing database are combined into a Failover system, a new database instance will be created on the latter DMA, and both instances will be clustered. When a DMA is removed from a Failover system, the indexing database instance on that DMA is removed from the cluster.

- During the setup of the DataMiner Indexing installation, a backup path has to be specified. For more information, refer to [Configuring DataMiner Indexing backups](#configuring-dataminer-indexing-backups).

- In a DataMiner System, there must be at least 2 master nodes. By default, the 3 DataMiner Agents with the lowest DataMiner ID will act as master node.

- Alarms in the indexing database are kept in two separate tables, one for active alarms and one for closed alarms.

##### DB.xml Indexing configuration

When the DataMiner Indexing Engine installation is complete, the *Db.xml* file will contain an additional \<DataBase> section with the connection information of the indexing database. The “search” attribute will be set to true.

```xml
<DataBases xmlns="http://www.skyline.be/config/db">
  ...
  <DataBase active="true" search="true" type="Elasticsearch">
    ...
```

> [!NOTE]
>
> - Changes to the settings of an indexing database in DataMiner Cube will take effect immediately and do not require a DataMiner restart. A DataMiner restart is only required when a named database is deleted.
> - When the Indexing Engine has been installed, the file *Indexing.xml* file is also added to the Skyline DataMiner folder, containing the configuration of the engine itself.

##### DBMaintenance.xml and DBMaintenanceDMS.xml Indexing configuration

In *DBMaintenance.xml* and *DBMaintenanceDMS.xml*, each \<TTL> tag can have an \<Indexing> subtag, allowing you to specify an override for the default TTL setting for a table that is part of the indexing database. It is possible to specify "infinite" as the indexing TTL, in which case these data will be kept indefinitely.

##### Configuring DataMiner Indexing backups

Backups of the Indexing database are not included in a DataMiner restore package. Instead, the backups are stored in a fixed location, which must be specified during the installation of DataMiner Indexing. This location is the same for all Indexing servers in the cluster.

A number of restrictions apply for the backup path. For more information on these restrictions, refer to the DataMiner Help.

Once DataMiner Indexing has been installed, it is possible to change the backup path using the *Backup path* parameter on the *Backup* page in System Center.

> [!NOTE]
>
> - After you have changed the path in System Center, it is possible that the UI is temporarily disabled while the Indexing nodes are restarted to implement the change. As such, we recommend to only change the backup path if this is absolutely necessary.
> - Only one Indexing data backup can be made per day.
> - Deleting any files from the backup file location will cause a restore to fail.

##### Indexing features configuration in System Center

Once DataMiner Indexing Engine has been installed, the *Search & Indexing* section in System Center contains an additional *Enable indexing on alarms* option. This option must be enabled in order to use the new Alarm Console features mentioned below.

There is also a button available that can be used to migrate booking data to the Indexing database. For more information, see [DataMiner Cube: New 'Migrate booking data to Indexing Engine' wizard \[ID_21935\]\[ID_23674\] \[ID_24410\]\[ID_24424\]](#dataminer-cube-new-migrate-booking-data-to-indexing-engine-wizard-id_21935id_23674-id_24410id_24424).

##### Enhanced search in alarm tab pages

When you open a new alarm tab page in the Alarm Console while connected to a DataMiner Agent that has indexing enabled on alarms, a search box at the top of that alarm tab page will now allow you to search for particular alarms or information events.

You can also right-click text in the Alarm Console while holding the left CTRL key (or a different key depending on the *Mouse word highlighting in Alarm Console* user setting), and select “Search for \<text> in new tab”. This will open a new tab with the text in question filled in in the search box.

Next to the search box, you can select a timespan (default: last 24 hours). When you start typing in the search box, the most relevant suggestions that are returned by the server will be displayed below. If a suggestion is too large to be displayed completely, you will be able to view it completely by hovering the mouse over it. However, if it consists of multiple lines, only the first line will be displayed.

After you press Enter or select a suggestion, the alarms matching your search phrase will be retrieved in batches of 50. If there are more than 50 alarms that match your search phrase, a *More results* button will be displayed at the bottom of the list. If you click that *More results* button, any alarms that were added or changed will blink briefly.

Once the first 50 alarms have been retrieved, a graphical representation of the alarm distribution will also be displayed.

By default, different instances of the same alarm will be combined in a single alarm tree in the search results. If you want them to be displayed separately, disable the *History tracking* checkbox.

In the search box, you can use the following special keywords, followed by a colon (“:”) and a search phrase:

- Severity
- Description
- Parameter_description
- Owner
- Value
- Time of arrival
- Status
- Elementname
- Viewnames
- Parentviews
- Protocolname
- ElementProperty\_\<propertyName>
- Viewproperty\_\<PropertyName>
- ServiceProperty\_\<PropertyName>

For example, if you want to search for alarms associated with elements of which the name resembles “probe”, you can enter “Elementname:probe”.

##### New user permission

In the Users / Groups module, in the category *Modules* > *System configuration* > *Indexing engine*, the following user permission is now available:

- *Configure*: Determines whether the user can make any changes to the Indexing Engine configuration.

##### **Indexing log information**

Log information about the Indexing Engine can be found in a new “Search” log file in the *Logging* section of *System Center*.

In addition, the system will continuously monitor the connection with the Indexing database. If for some reason a node of the Indexing database goes down, an alarm will be displayed in the Alarm Console.

##### **GetIndexCountRequest method**

A new *GetIndexCountRequest* method has been added in DataMiner, which can be used to retrieve the number of documents in the indexing database.

This method can for instance be used as follows for a logger table:

```csharp
GetIndexCountRequest<LoggerTableData> message = new GetIndexCountRequest<LoggerTableData>(new LoggerTableDataIndex(503,52,1000));
```

#### DataMiner Agents upgraded to Microsoft .NET Framework 4.6 \[ID_19816\]\[ID_20005\]

DataMiner Agents have been upgraded to Microsoft .NET Framework 4.6. As such, this version of the Microsoft .NET Framework is now required in order to be able to upgrade DataMiner.

> [!NOTE]
> When upgrading a .NET Framework installation, it is recommended to always upgrade to the latest version.

#### Enhanced services: Alarm counters per severity per element \[ID_19917\]

Version 1.0.0.7 of the “Skyline Service Definition Basic” protocol is now able to count the alarms in an enhanced service per severity per element.

For this purpose, the following columns have been added to the table with parameter ID 100. If these columns are present and the “Monitor Active Alarms” option is enabled, the alarm counters will be updated automatically.

| PID | Type | Interprete Type | Name                                        |
|-----|------|-----------------|---------------------------------------------|
| 109 | read | string          | Service_Element_Status_Service_Index        |
| 110 | read | double          | Service_Element_Status_Alarm_Count_Critical |
| 111 | read | double          | Service_Element_Status_Alarm_Count_Major    |
| 112 | read | double          | Service_Element_Status_Alarm_Count_Minor    |
| 113 | read | double          | Service_Element_Status_Alarm_Count_Warning  |
| 114 | read | double          | Service_Element_Status_Alarm_Count_Timeout  |
| 115 | read | double          | Service_Element_Type                        |

#### New Job Manager app \[ID_19964\]\[ID_20130\]\[ID_20583\]\[ID_21098\]\[ID_21180\]\[ID_21422\]\[ID_21660\] \[ID_21724\]\[ID_21767\]\[ID_21940\]\[ID_22289\]\[ID_22331\]\[ID_22772\]\[ID_22758\]\[ID_22823\]\[ID_22895\] \[ID_22909\]\[ID_22913\]\[ID_22966\] \[ID_22988\]\[ID_23007\]\[ID_23042\]\[ID_23049\]\[ID_23790\]

A new DataMiner Job Manager app is available, which can be used to create and manage jobs, which are then distributed to the SRM applications, so that the necessary bookings can be generated.

This app requires a separate Job Manager license. In addition, it requires a Cassandra local database, and DataMiner Indexing Engine must be installed in order to run the app.

Log information for the app is stored in the SLJobManager log file.

> [!NOTE]
> The Job Manager app requires DataMiner Indexing. For more information on the Indexing installation, see [Installing the Indexing Engine](#installing-the-indexing-engine).

##### Job Manager UI overview

The Job Manager app can be accessed via the link `https://[MyDataMiner]/Jobs` or `http://[MyDataMiner]/Jobs`, depending on your setup.

> [!NOTE]
> We strongly advise to use HTTPS when using DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet.

The main page of the app consists of a header bar, a side panel and an overview panel.

- The header bar contains various buttons, including a button to create a new job and a button to configure the app.

- The side panel can be used to filter the jobs displayed in the overview panel. Two filter options are available, one to limit the jobs that are displayed depending on the values in the job fields, and one to limit the jobs depending on the time frame in which they are planned.

- The overview panel has two buttons in the top-right corner, allowing you to switch between a list view and a timeline view. In the list view, all jobs matching the specified filters are listed, along with any additional job information that has been configured to be displayed. In the timeline view, jobs are displayed on a timeline control similar to that of the DMS Scheduler app.

    > [!NOTE]
    > When you open the Jobs app on a mobile device, the timeline view will not be available.

##### Job Manager timeline

There are several ways to manipulate the timeline in the Job Manager app:

- Click and drag with the right mouse button to pan the timeline.
- Click and drag with the left mouse button to zoom in on the timeline.
- Press Ctrl and scroll in order to zoom in or out on the timeline.
- In case the timeline displays many jobs, use the scroll wheel to scroll through the timeline vertically.
- Right-click on the timeline to mark a particular time with a red line.
- Double-click with the left mouse button to jump to the present time on the timeline.

In the lower right corner of the timeline, an arrow icon is displayed. Click this icon to display a preview pane, which also allows you to manipulate the timeline. The white area in this pane corresponds with the currently displayed timeline.

- Click and drag with the left mouse button in the preview pane in order to move the white area to a different time.
- The white area displays a lock icon. Click this icon to toggle between locked and unlocked mode. In locked mode, dragging causes the white area to remain in place while the timeline itself is moved. In unlocked mode, it is the white area that is moved across the timeline.

##### Creating, editing, exporting and deleting jobs

Most actions involving jobs can be done with buttons in the header bar of the app:

- To add a job, click the *New* button in the header bar, and fill in the necessary fields. Which fields can or must be filled in partly depends on your Job Manager configuration, but the job name and its start and stop time are always required.

  - Multiple-instance job sections are visualized as tabs. To add an instance, click the “+” icon. To duplicate an existing instance, click the *Duplicate* icon inside the instance header.

- To edit a job, select the job in the list view or the timeline view and click the *Edit* button in the header bar.

  When editing a job, you can save that job as a job template.

  - To create a job template, click the downward arrow in the top-right corner, and click *Save template*.
  - To apply a job template (i.e. to fill the fields of the job you are editing with the field values stored in the template), click the downward arrow in the top-right corner, select a template from the list, and click *Apply template*.

  > [!NOTE]
  > Auto-increment and booking fields are not included in job templates.

- To export a job to PDF, select the job in the list view or the timeline view and click the *Export* button in the header bar.

- To remove one or more jobs, select the job(s) in the list view or the timeline view and click the *Delete* button in the header bar. To select more than one job, keep the Ctrl key pressed while you make the selection.

##### Job Manager configuration

The sections that users can fill in when they create a job can be configured via the *Configuration* button in the header bar of the app.

You can add sections by clicking one of the nodes in the configuration pane. The location where you add the sections determines where they are displayed to the user during job creation.

You can modify an existing job section by clicking the section header. When you have done so, you can also delete the job section using the red recycle bin icon below the section icon.

When you add a section, you can select whether it is a regular job field or a booking section. For a booking section, you must specify the Booking Manager component and booking script.

Each section must have a name and a type configured. If the section type is set to *Booking*, you must specify the Booking Manager component and booking script. Once the configuration is used by a job, the Booking Manager selection can no longer be modified.

If the section type is set to *Fields*, you can configure as many job fields as necessary to be included in the section. For each field, the name and type must be specified. In addition, you can indicate if the field is always required when a job is created, whether the field should be displayed in the list view of the app, and whether it is read-only.

Within each section of type *Fields*, arrow icons allow you to change the position of the fields, and recycle bin icons next to each field allow you to remove the fields.

> [!NOTE]
>
> - If a section definition is in use in jobs, deleting the section definition will not remove it from the system, but cause it to become hidden.
> - The type of a job section can be changed from “Fields” to “Booking” (or vice versa) as long as that section is not being used in any job.
> - Job section fields of type “Integer” only accept values between -9223372036854775808 and 9223372036854775808, while job section fields of type “Double” only accept values between -1.7976931348623157^308 and 1.7976931348623157^308.
> - Values can be added to or deleted from job section fields of type “Dropdown” even when those fields are being used by existing jobs. When a value is deleted from a drop-down field, it is marked as hidden, not deleted physically.

##### Job Manager user permissions

The following new user permissions are available for this app:

- Modules \> Jobs \> UI available
- Modules \> Jobs \> Add/Edit
- Modules \> Jobs \> Delete
- Modules \> Jobs \> Configure Domains

##### New methods added to Web Services API v1

A number of new methods have been added to the Web Services API v1 to support the new app. This includes the following methods:

- AddOrUpdateJobsSectionDefinitionField
- CreateJob
- CreateJobTemplate
- CreateJobsSectionDefinition
- DeleteJob
- DeleteJobTemplate
- DeleteJobsSectionDefinition
- DeleteSectionDefinitionField
- GetBookingsForJobSection
- GetJob
- GetJobFieldOptions
- GetJobSuggestions
- GetJobTemplate
- GetJobTemplates
- GetJobs
- GetJobsSectionDefinition
- GetJobsSectionDefinitions
- RemoveJobs
- SaveJobsSectionDomainConfig
- UnhideJobSectionDefinitionField
- UpdateJob
- UpdateJobTemplate
- UpdateJobsSectionDefinition

#### SLSNMPManager: A notification will now be generated when a received SNMPv3 trap cannot be processed \[ID_20340\]

When an SNMP manager receives an SNMPv3 trap or inform message that cannot be processed (e.g. due to authentication problems), it will now generate a notification.

Note that for this feature to work, the *SNMPv3* tag in the DMA’s *DataMiner.xml* file has to have its *generateNoticeOnIncorrectTrapReceived* attribute set to “true”. See the following example:

```xml
<SNMPv3 trapPort="362" generateNoticeOnIncorrectTrapReceived="true" />
```

#### DataMiner.xml: New WarningThreshold tag to configure when license limit warning messages must be generated \[ID_20714\]

When a DMA is approaching the limit of its element license, by default warning messages are generated. From now on, it is possible to customize when these messages are generated using the WarningThreshold tag.

The following values can be configured in this tag:

| Value                            | Behavior                                                                                                                                                                                                                                                                                                              |
|----------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| A value lower than or equal to 0 | The option will have no effect.                                                                                                                                                                                                                                                                                       |
| A value between 0 and 1          | The value represents the percentage of active elements compared to the total allowed elements. Once this percentage is reached, warnings will be generated. However, license limit warnings are never generated if the DMA is below 80% of its total capacity, even if a value lower than 0.8 is configured here. |
| A value higher than 1            | No warnings will be generated.                                                                                                                                                                                                                                                                                        |

For example, if you specify the following, warnings will only be generated once the DMA is at 99% of its capacity:

```xml
<WarningThreshold>0.99</WarningThreshold>
```

#### New alarm color defaults in SLNetTypes.dll \[ID_20862\]

If the DataMiner.xml file does not contain alarm color overrides, DataMiner will use the default alarm colors that are hard-coded in the SLNetTypes.dll file. Those hard-coded default colors have now been updated. See the following list.

| Alarm state  | RGB values  |
|--------------|-------------|
| normal       | 22,198,12   |
| warning      | 59,120,255  |
| minor        | 97,214,214  |
| major        | 245,210,40  |
| critical     | 240,50,65   |
| notMonitored | 204,204,204 |
| initial      | 242,242,242 |
| timeout      | 255,155,15  |
| masked       | 136,23,152  |
| error        | 204,204,204 |
| notice       | 204,204,204 |
| information  | 204,204,204 |

#### Information event will be generated when a TTL setting is changed \[ID_21265\]

From now on, an information event will be generated when a TTL setting is changed by a user or an Automation script.

> [!NOTE]
> Information events of this type will have a description that starts with “\[TTL\]”.

#### New option to disable SNMP trap distribution in DMS \[ID_21389\]

It is now possible to disable SNMP trap distribution in a DataMiner cluster. To do so, add the tag *SnmpTrapDistribution* in the file *DataMiner.xml* and set it to false.

Example:

```xml
<DataMiner>
  ...
  <SnmpTrapDistribution>false</SnmpTrapDistribution>
  ...
</DataMiner>
```

#### Enhanced service element protocols now referred to as 'service protocols' instead of 'service definitions' \[ID_21854\]

In DataMiner, up to now, two different concepts were referred to as a “service definition”:

- the protocol of an enhanced service element, and
- the diagram and configuration of a service signal flow (in Service & Resource Management).

In order to avoid confusion, from now on, the first of the above-mentioned concepts will be referred to as a “service protocol”.

#### Cassandra: Number of connection retries is now configurable \[ID_22194\]

In the *DB.xml* file, it is now possible to specify how many times you want the SLDataGateway process to try to connect to the Cassandra database at startup.

Example:

```xml
...
<DataBase active="true" local="true" type="Cassandra">
    <ConnectionRetries>60</ConnectionRetries>
</DataBase>
...
```

Default value: 60 times (with 30-second intervals)

> [!NOTE]
> If Cassandra is still unreachable after SLDataGateway has tried to connect for the maximum number of times specified in the \<ConnectionRetries> setting, a restart of the SLDataGateway process will be required.

#### Uploading and running BPA tests \[ID_22222\]\[ID_22357\]\[ID_33793\]

It is now possible to upload and run Best Practice Analysis (BPA) tests using the SLNetClientTest tool.

BPA tests, which are meant to be short checks, can be configured to run either once or periodically (e.g. once a day). A BPA test can be run to verify, for example, whether all agents in a DataMiner System are set to use the same time server.

If a BPA test takes more than 15 minutes, the SLNet process may throw a run-time error.

#### Mobile Gateway: Communicating with an SMSEagle device via HTTPS \[ID_22441\]

It is now possible to communicate with an SMSEagle device via HTTPS.

##### To enable HTTPS

1. Open Skyline DataMiner/Mobile Gateway/Config.xml.

1. Inside the \<HttpGsm> tag, add the following tags:

    | Tag                | Value  |
    |--------------------|--------|
    | \<UseHttps>        | “true” |
    | \<RequireValidSsl> | “true” |

1. Make sure the port attribute of the \<Location> tag is set to the port on which the SMSEagle device is listening. This will most likely be port 443.

Example of a Config.xml file:

```xml
<HttpGsm>
  <Location port="443">10.3.1.41</Location>
  <Schedule>3</Schedule>
  <UseHttps>true</UseHttps>
  <RequireValidSsl>true</RequireValidSsl>
  <SMSEagle user="user" pass="pass"/>
</HttpGsm>
```

> [!NOTE]
> When you set \<RequireValidSsl> to “true” and make the DataMiner Agent trust the server certificate of the SMSEagle device (see below for instructions), then the \<Location> tag must contain “smseagle” instead of the IP address of the device.

##### Making the DataMiner Agent trust the SMSEagle server certificate

When, in the Config.xml file, you set \<RequireValidSsl> to “true”, you have to make the DataMiner Agent trust the default server certificate of the SMSEagle device. To do so, perform the following steps on the server that hosts the DataMiner Agent:

1. In your internet browser, go to `https://<IP address of the SMSEagle device>`.

    If an error appears, telling you that the site is not secure, ignore it.

2. Click the warning triangle to the left of the URL bar, and click *certificate*. A window will open.

3. Go to the *Details* tab, and click *Copy to File...*

4. Click *Next*, specify a random folder and a file name, and click *Save*.

5. Open the Microsoft Management Console. To do so, press WINDOWS+R, type “mmc”, and press ENTER.

6. In the Microsoft Management Console, press CTRL+M.

7. In the *Add or Remove Snap-ins* window, select “Certificate” from the *Available snap-ins* list, and click *Add*.

8. Select the following options:

    - *Computer Account*
    - *Local Computer*

9. Click *OK* to close the *Add or Remove Snap-ins* window.

10. Under the *Console Root*, go to *Certificates (Local Computer) \> Trusted Root Certification Authorities \> Certificates*.

11. Right-click the *Certificates* folder, and select *All tasks \> Import....*

12. Select the file you saved in step 4. This will load the certificate into the certificate store.

##### Updating the Windows hosts file

The Common Name (CN) of the default SMSEagle certificate is set to “smseagle”. As a result, you have to update the Windows hosts file:

1. Open C:\\Windows\\System32\\Drivers\\etc\\hosts.

2. At the bottom, add a line with the following content: \<IP address of the SMSEagle device>, followed by a space and the word “smseagle”

    Example: 10.3.1.41 smseagle

3. Save the hosts file.

##### Checking the certificate

To check if the certificate was correctly installed, open an internet browser, and go to <https://smseagle/login>. If no “invalid certificate” errors appear, then the certificate was correctly installed.

> [!NOTE]
>
> - In production environments, it is recommended to use the domain certificate of the network (e.g. smseagle.skyline.be) and to generate a server certificate for the SMSEagle device that is trusted by the root skyline.be certificate.
> - The SMSEagle firmware supports HTTPS as from version 2.7.
> - When using an SMSEagle device with firmware version 3.32 it is not possible to retrieve the signal strength due to a bug in said firmware.

#### DataMiner now supports NATS Streaming \[ID_22506\]

DataMiner now supports NATS Streaming.

#### SNMP agent function now disabled by default \[ID_22817\]

From now on, the DataMiner SNMP agent functionality is disabled by default, so that polling of active alarms and general DataMiner information is not possible.

If necessary, this function can be enabled in the *DataMiner.xml* file:

```xml
<DataMiner>
  <SNMP enableDataMinerAgentPolling="true"/>
</DataMiner>
```

> [!NOTE]
>
> - This change does not affect virtual SNMP agents that can be enabled for elements.
> - When you upgrade from a DataMiner version where the SNMP agent function was enabled by default, an \<SNMP enableDataMinerAgentPolling="true"/> tag will automatically be added to the *DataMiner.xml* file. This way, no configuration changes will have to be made on systems using this feature.

#### Cassandra: Automatic TTL refresh in case of average trending \[ID_22920\]

When, in a system with a Cassandra database, average trending for a parameter had not changed for the period of time the TTL was configured, up to now, the last trend data record would be deleted from the database. From now on, the TTL will automatically be refreshed 15 minutes before the TTL expires.

#### Editing of properties of closed alarms \[ID_23067\]

It is now possible to edit properties of alarms that have already been closed. This will create a new alarm entry with the updated properties in the alarm tree of the closed alarm.

To update a property of a closed alarm, in Cube, select the root alarm in the alarm tree and then edit the property. Alternatively, in an Automation script, use the *SetDataMinerInfoMessage* with NT_EDIT_PROPERTY (62).

#### DBMaintenanceDMS.xml: TTL settings can now be specified for all custom data types defined in an Elastic database \[ID_24549\]\[ID_24575\]\[ID_24846\]

In the *DBMaintenanceDMS.xml* file, you can now configure “time to live” (TTL) settings for all custom data types defined in an Elastic database.

In the following example, a TTL setting was specified for job objects stored in an Elastic database:

```xml
<MaintenanceConfigs>
  <MaintenanceConfig type="DMS" xmlns="http://www.skyline.be/config/dbmaintenance">
    <TimeToLive>
      <TTL type="cjobsection">
        <Indexing>6M</Indexing>
      </TTL>
      ...
    </TimeToLive>
  </MaintenanceConfig>
</MaintenanceConfigs>
```

### DMS Security

#### DataMiner user accounts are now deleted at startup if no corresponding Windows user account can be found and if the user password is not known \[ID_20347\]

From now on, DataMiner user accounts are deleted at startup if no corresponding Windows user account can be found and if the user password is not known.

#### DataMiner Cube: External user authentication via SAML \[21027\]\[ID_22838\]\[23112\]

DataMiner Cube now supports external user authentication via Security Assertion Markup Language (SAML).

A Cube user trying to log in to a DataMiner Agent using external authentication via SAML will be redirected to a webpage on a third-party server. That server will authenticate the user and return a SAML response to DataMiner Cube, which will forward it to the DataMiner Agent. Depending on the authentication result in that response, the Agent will then either grant or deny the user access.

> [!NOTE]
>
> - At present, the authentication web page will always be opened in Internet Explorer.
> - DataMiner SAML authentication supports multiple assertion consumer service locations, so that authentication is possible across multiple service addresses.

#### HTML5 apps: External user authentication via SAML \[23905\]

The DataMiner HTML5 apps (e.g. Dashboards, Jobs, etc.) now all support external user authentication via Security Assertion Markup Language (SAML).

### DMS Protocols

#### Dynamic parameter replication \[ID_19311\]

It is now possible to configure replication on parameter level.

> [!NOTE]
>
> - As soon as you configure parameter-level replication, the polling engine will stop processing groups and start managing parameter replication.
> - Currently, only single-value parameters can be replicated.
> - It is not possible to replicate the same parameter of the same element multiple times into a different local parameter.

To configure dynamic parameter replication in a protocol, add a \<Replication> tag to the parameter that has to be replicated, with both an \<Element> and a \<Parameter> subtag.

Both these subtags should have a “dynamic” attribute of which the value is a parameter ID.

- The parameter specified in the \<Element> tag has to contain the DmaID/ElementID of the element containing the parameter to be replicated.

- The parameter specified in the \<Parameter> tag has to contain the ID of the parameter to be replicated.

See the \<Replication> tag in the following example:

```xml
<Param id="1">
  <Name>Parameter 1</Name>
  <Description>Parameter 1</Description>
  <Type>read</Type>
  <Interprete>
    <RawType>double</RawType>
    <LengthType>fixed</LengthType>
    <Length>8</Length>
    <Type>double</Type>
  </Interprete>
  <Alarm>
    <Monitored>true</Monitored>
  </Alarm>
  <Display>
    <RTDisplay>true</RTDisplay>
    <Units></Units>
    <Range></Range>
    <Decimals></Decimals>
    <Steps></Steps>
    <Positions>
      <Position>
        <Page>Main View</Page>
        <Row>2</Row>
        <Column>0</Column>
      </Position>
    </Positions>
  </Display>
  <Measurement>
    <Type>number</Type>
  </Measurement>
  <Replication uid="" pwd="">
    <Element dynamic="4"/>
    <Parameter dynamic="5"/>
  </Replication>
</Param>
```

#### Base protocols can now be linked directly to a protocol \[ID_19591\]

From now on, it is possible to create a base protocol that is not linked to a specific element type but directly to a protocol. This means that you will now be able to link protocols with different element types to the same base protocol.

In a Protocol.xml file, when a base protocol contains \<Mediation>\<LinkTo> tags with a *protocol* attribute, the element type in the *basefor* attribute of the \<Protocol> tag will now be disregarded.

#### New ColumnOptions option: viewImpact \[ID_19798\]

By specifying the new “viewImpact” option in a particular table column definition, you can configure a “view impact” column containing IDs\* of views that have to be put in alarm whenever there is an alarm on a cell in another column of that same table.

```xml
<ColumnOptions options=";viewImpact" />
```

*Multiple view ID have to be separated by semicolons.*

#### New ColumnOptions option: QueryTablePID \[ID_19897\]

By specifying the new “QueryTablePID” option in a particular table column definition, you can configure a column containing parameter IDs of tables from which to retrieve additional information. This option will mostly be used in CPE environments.

Default cell value in a column of this type: -1

```xml
<ColumnOptions options=";QueryTablePID" />
```

#### HTTP: Support for gzip and deflate compression \[ID_20462\]

From now on, HTTP requests executed from DataMiner protocols via SLPort will automatically include the following header:

```html
Accept-Encoding: gzip, deflate
```

This way, DataMiner will inform the web server that it supports gzip and deflate decompression. If the web server also supports this, it will return the requested data gzip or deflate compressed. SLPort will then automatically decompress the data and pass it uncompressed to SLProtocol.

Due to this enhancement, overall transfer speed and bandwidth utilization will increase.

> [!NOTE]
> The feature only works on DataMiner Agents running Windows 8.1, Windows Server 2012 R2, or a more recent Windows operating system.

#### 'FillArray' and 'FillArrayWithColumn' functions now support history sets \[ID_21482\]

The *FillArray* and *FillArrayWithColumn* functions now support history sets.

Both functions now accept a datetime that will be applied to all values passed in the parameter set.

> [!NOTE]
> Contrary to setrow, it is not possible to specify multiple datetime values for different parts of the parameter set.

The QActionBaseClasses functions have been expanded with an optional parameter. Existing protocols will continue to function as they will use the current datetime (default behavior).

NotifyProtocol calls:

```csharp
protocol.NotifyProtocol(193 /*NT_FILL_ARRAY*/ , new object[3] { <TablePid>, <bOverrideBehaviour_bool>, <DateTime> } , values});
protocol.NotifyProtocol(220/*NT_FILL_ARRAY_WITH_COLUMN*/ , new object[] { <TablePid>, <ColumnPid>, new object[2] { <bOverrideBehaviour_bool>,<DateTime>} }, Values);
```

Protocol functions:

```csharp
protocol.FillArray(<TablePid>, Values, <DateTime>);
protocol.FillArrayWithColumn(<TablePid>, <ColumnPid>, <keys>, <values>, <DateTime>);
```

QActionTable functions:

```csharp
table.FillArray(rows, <DateTime>);
table.SetColumn(<ColumnPid>, keys, values, <DateTime>);
```

#### Enhanced service protocols: A number of tags will automatically be filled in at protocol creation \[ID_22279\]

When a protocol for an enhanced service is generated, the following tags will now be filled in automatically:

| Tag                | Default content                                                                                                           |
|--------------------|---------------------------------------------------------------------------------------------------------------------------|
| Protocol.DeviceOID | The number of ticks that represent the date and time at which the protocol was generated. Example: 636946329930563687 |
| Protocol.Provider  | Skyline Communications                                                                                                    |
| Protocol.Vendor    | Skyline                                                                                                                   |
| Protocol.VendorOID | 48                                                                                                                        |

#### .NET Compiler Platform now used for QActions \[ID_23095\]

The .NET Compiler Platform ("Roslyn") is now used to compile QActions, so that C# version 6.0 and higher syntax is now supported in QActions.

#### Possibility to refer to DLLs in subfolders of ProtocolScripts folder \[ID_23565\]

Up to now, to use a custom DLL in a protocol's QActions, it always had to be stored in the folder *C:\\Skyline DataMiner\\ProtocolScripts*. Now it is also possible to use a DLL that is stored in a subfolder of this folder. In that case, you must mention the subfolder when you specify the DLL in the protocol.

For example, to use “test.dll” stored in *C:\\Skyline DataMiner\\ProtocolScripts\\SubFolder*, configure the *dllImport* attribute of the QAction tag as follows: *dllImport="SubFolder\\test.dll"*.

It is now also possible to use DLLs with the same name but with different assembly versions within the same driver, though not within the same QAction.

For example, the following QAction definitions are possible within a single protocol:

```xml
<QActions>
   <QAction id=100 dllImport="test.dll"></QAction>
   <QAction id=200 dllImport="MyCustomDlls\v2\test.dll"></QAction>
   <QAction id=300 dllImport="MyCustomDlls\v3\test.dll"></QAction>
</QActions>
```

> [!NOTE]
>
> - A leading slash before the folder name is supported, but not required.
> - A folder separator can be a forward slash or backslash.
> - DLL files stored in *C:\\Skyline DataMiner\\Files\\* will take precedence over DLL files in other folders if they are not strongly named (signed). This is standard Microsoft .NET assembly resolving behavior.
> - In the details of a DLL, ‘File Version’ and ‘Product Version’ reflect the project’s file version at compilation. Other tools might be needed to check the actual assembly version.

#### SLProtocol class refactored to an interface \[ID_23787\]

To allow for easier testing, the SLProtocol class has been refactored to an interface.

#### FillArray calls now allow timestamp per cell \[ID_23815\]

When using a *FillArray* call (*NT_FILL_ARRAY*, *NT_FILL_ARRAY_NO_DELETE* or *NT_FILL_ARRAY_WITH_COLUMN*), you can now specify a timestamp per cell, so that it is now possible to do a history set on cell level. To do so, use an object array containing the value and timestamp.

For example:

```csharp
object[] column1 = new object[] { "Key 10", "Key 20", "Key 30" };
object[] column3 = new object[] { "2.2", "1.1", "3.3" };
object[] column2WithTimeStamps = new object[] { new object[] { "Z", DateTime.Now - TimeSpan.FromDays(1) }, new object[] { "Y", DateTime.Now - TimeSpan.FromDays(2) }, "X" }; // Note, providing a timestamp is optional. If none is provided, DateTime.Now will be used.
object[] columnsWithTimeStamps = new object[] { column1, column2WithTimeStamps, column3 };
protocol.NotifyProtocol(220/*NT_FILL_ARRAY_WITH_COLUMN*/ , new object[] { tableId, columnIdColumn2, columnIdColumn3, new object[2] { true, null } }, columnsWithTimeStamps);
```

#### NT_SNMP_GET (295): Possibility to specify the maximum number of repetitions \[ID_23888\]

When sending an NT_SNMP_GET request from within a QAction, it is now possible to pass along the maximum number of repetitions in the elementInfo array.

See the following example:

```csharp
elementInfo[13] = maxRepetitions;
object[] result = (object[])protocol.NotifyProtocol(295/*NT_SNMP_GET*/, elementInfo, tableOids);
```

elementInfo\[13\] should contain a 32-bit integer value (Int32) of at least 1. If no value is specified, or if the value is 0 or less, then the default number of repetitions (6) will be passed along.

> [!NOTE]
> Apart from the maximum value of an Int32 (2^31-1), there are no constraints as to maximum value you can specify. So, use this option with caution. The higher this value is set, the higher the stress on the network and the device in question will be.

#### DataMiner Mediation Layer: Base protocols and device protocols can now contain value mappings \[ID_24127\]

In base protocols and device protocols linked to base protocols, you can now specify \<ValueMapping> tags inside \<LinkTo> tags.

A \<ValueMapping> tag has two attributes:

- a *remoteValue* attribute that refers to the value in the other protocol, and
- a *value* attribute that refers to the value in the current protocol.

Here is an example of a value mapping defined in a base protocol:

```xml
<Mediation>
  <LinkTo protocol="Skyline Discreet Values" pid="10" ops="/:1000000">
    <ValueMapping remoteValue="-1" value="-2"/>
  </LinkTo>
</Mediation>
```

Here is example of a value mapping defined in a device protocol:

```xml
<Mediation>
  <LinkTo pid="70005">
    <ValueMapping remoteValue="1" value="5"/>
    <ValueMapping remoteValue="2" value="7"/>
  </LinkTo>
</Mediation>
```

> [!NOTE]
>
> - Value mappings can be defined for both single-value and column parameters of type string or double. If you define them for parameters with Interprete type “high nibble”, they will be ignored.
> - In case of read/write parameters, value mappings have to be defined on both. Note, however, that they should not be identical. If a value mapping match is found when reading or writing a parameter, then the *ops* attribute of the *LinkTo* tag will be ignored. However, if no relevant mappings could be found for the value in question, the *ops* attribute will be taken into account. This can prove useful in case of exception values.

### DMS Cube

#### DataMiner Analytics: Behavioral anomaly detection and suggestion events \[ID_15723\]\[ID_15914\] \[ID_15916\]\[ID_15951\]\[ID_15952\]\[ID_15976\]\[ID_16001\]\[ID_16050\]\[ID_16163\]\[ID_17279\]\[ID_17462\] \[ID_19224\]\[ID_24095\]\[ID_24126\]\[ID_24147\]

The DataMiner Analytics software now allows you to configure behavioral anomaly detection and to display suggestion events in the Alarm Console.

The purpose of this new feature is to detect anomalous changes in the behavior of individual parameters in real time.

> [!NOTE]
> Behavioral anomaly detection and suggestion events are only available on DMAs using a Cassandra database. If none of the DMAs in a cluster use Cassandra, the anomaly configuration options are not displayed.

##### Current limitations

- Only possible for trended parameters with numeric values.
- Not possible for partial table parameters.
- Anomaly detection is limited to 100,000 parameters per DataMiner Agent.
- Processing of change points (see below) is limited to 1,000 points per second. If the buffer receives more than 100,000 change points in rapid succession, some of those may be disregarded.

##### Change points

Any change in behavior is called a change point. At present, there are five types of change points:

- **Outlier**: A value that suddenly spikes upwards or downwards, but returns to its previous, normal behavior after a few points.
- **Level shift**: A value that shifts upwards or downwards (similar to an outlier) and then stays at that new level.

  Example: A value fluctuating around 0 which starts fluctuating around 10.

- **Variance change**: A value of which the variance either increases or decreases.

  Example: A series like 0.5, 0.6,-0.5,-0.2, 1,… 5,8,9,-5,-6,-2.1,… indicates a variance increase. At some point, a value that is fluctuating around 0 between 1 and -1, starts fluctuating around 0 between 10 and -10.

- **Trend change**: A value that suddenly starts increasing or decreasing at a rate different from the normal behavior.

  Examples:

  - A value fluctuating around 10 (i.e. a trend slope of 0) which suddenly starts increasing 1 unit per second (i.e. a trend slope of 1).
  - A value fluctuating around a line with slope 1 which suddenly starts fluctuating around a line with slope -1.

- **Unlabeled change**: If a change point cannot be classified as one of the above-mentioned change points, it is considered an unlabeled change.

##### Behavioral anomalies

Some change points are more significant or unexpected than others. The stranger the current change point is compared to past change points, the higher its significance will be.

Of every new change point, its significance is calculated based on its characteristics (change point type, direction, absolute or relative change size, etc.), taking into account the parameter's change point history of the last month. The change points that are considered the most significant, i.e. the most “surprising”, are labeled “anomalous”.

Level shifts which are higher or which have a different direction than previous recent jumps, or which jump to a previously unseen level, will typically be labeled “anomalous”. Similarly, trend or variance changes will be labeled “anomalous” when no earlier trend or variance changes in the same direction appeared during the last weeks.

Currently, no change points of type “outlier” or “unlabeled” will be labeled “anomalous”.

##### Change points visible in trend graphs

On a trend graph, a change point is indicated by a bar below the graph. The length of the bar indicates the approximate time frame in which the change started, the height of the bar indicates the importance of the change, and the color of the bar indicates the severity.

When you hover the mouse pointer over a change point bar, a semi-transparent ribbon will appear over the entire height of the trend graph, showing more information about the change point.

Labels of change points of type “trend change” will indicate the level of increase or decrease in seconds, minutes, hours or days depending on the value. If, for example, the value increases by 0.01 per second (i.e. 0.6 per minute, 36 per hour or 864 per day), the label will show an increase of 36 per hour as it is the smallest amount greater than 1.

##### Trend state icons next to parameters in DATA pages

When you open an element card, each trended parameter on that card gets one of the following trend state icons. When you hover over one of those icons, a popup will open, showing additional information.

| Icon | Description |
|--|--|
| ![trend graph icon](~/release-notes/images/StandardTrendGraphIcon.png) | Standard trend graph icon |
| ![upward arrow icon](~/release-notes/images/ArrowRight60.png) | Upward arrow |
| ![downward arrow icon](~/release-notes/images/ArrowRight120.png) | Downward arrow |
| ![flat arrow icon](~/release-notes/images/ArrowRight.png) | Flat arrow |
| ![upward level shift icon](~/release-notes/images/LevelShiftIncrease.png) ![red upward level shift icon](~/release-notes/images/LevelShiftIncreaseRed.png) | Upward level shift |
| ![downward level shift icon](~/release-notes/images/LevelShiftDecrease.png) ![red downward level shift icon](~/release-notes/images/LevelShiftDecreaseRed.png) | Downward level shift |
| ![upward trend change icon](~/release-notes/images/ArrowTrendChangeUp.png) ![red upward trend change icon](~/release-notes/images/ArrowTrendChangeUpRed.png) | Upward trend change |
| ![downward trend change icon](~/release-notes/images/ArrowTrendChangeDown.png) ![red downward trend change icon](~/release-notes/images/ArrowTrendChangeDownRed.png) | Downward trend change |
| ![variance increase icon](~/release-notes/images/ArrowVarianceChangeUp.png) ![red variance increase icon](~/release-notes/images/ArrowVarianceChangeUpRed.png) | Variance increase |
| ![variance decrease icon](~/release-notes/images/ArrowVarianceChangeDown.png) ![red variance decrease icon](~/release-notes/images/ArrowVarianceChangeDownRed.png) | Variance decrease |
| ![upward outlier icon](~/release-notes/images/ArrowOutlierUp.png) ![red upward outlier icon](~/release-notes/images/ArrowOutlierUpRed.png) | Upward outlier |
| ![downward outlier icon](~/release-notes/images/ArrowOutlierDown.png) ![red downward outlier icon](~/release-notes/images/ArrowOutlierDownRed.png) | Downward outlier |

DataMiner will do the following to select a trend state icon for a particular parameter:

1. From the trend data of the parameter, DataMiner will fetch all change points that occurred during the last X seconds. X being the number of seconds specified in the *arrowWindowLength* parameter, found in *C:\\Skyline DataMiner\\Files\\SLAnalytics.config*. Default value: 3600 seconds.

2. If some of the change points are anomalous, then the following trend state icon is selected:

    - Type = Type of most recent anomalous change point
    - Color = Red

    Example: A red, upwards level shift.

    > [!NOTE]
    > If the most recent anomalous change point is an unlabeled change, then the standard trend graph icon is selected.

3. If none of the change points are anomalous, then the following trend state icon is selected:

    - Type = Type of the most recent change point of which the severity is equal to or greater than 0.5. If there are no change points of which the severity is equal to or greater than 0.5, then see step 4.
    - Color = Black

4. In all other cases, one of the following trend state icons is selected, based on the behavior of the parameter value in the last *arrowWindowLength* seconds: a flat arrow, an upward arrow, a downward arrow, or the standard trend graph icon.

##### Suggestion events

By default, a so-called “suggestion event” is generated whenever an anomalous level shift, trend change or variance change is detected for a particular parameter.

In case of a level shift, for example, the value of the suggestion event will be either “Level increased by X (from Y to Z)” or “Level decreased by X (from Y to Z)”. X will be the size of the jump, Y will be an estimation of the previous level and Z will be an estimation of the new data level.

To view these suggestion events, you can create a new tab in the Alarm Console and select to display suggestion events. This is possible for tabs displaying current alarms, history alarms and alarms in a sliding window.

> [!NOTE]
>
> - Currently, no suggestion events are generated for outliers and unlabeled change points.
> - Suggestion events have severity “Information” and source “Suggestion Engine”.
> - Suggestion events generated to indicate a behavioral anomaly are automatically cleared 2 hours after their creation time or their last update time.

#### SNMP forwarding: Enhanced authentication and encryption algorithm support \[ID_19471\]\[ID_19693\]\[ID_23031\]\[ID_23322\]\[ID_23586\]

When configuring SNMPv3 trap forwarding in System Center, it is now possible to make DataMiner use the following authentication and encryption algorithms:

Authentication algorithms:

- MD5
- SHA128
- SHA224
- SHA256
- SHA384
- SHA512

Encryption algorithms:

- AES128
- AES192
- AES256
- DES

> [!NOTE]
>
> - Default setting (when no default algorithms are specified in the protocol): SHA512 authentication in combination with AES256 encryption.
> - Some of the above-mentioned authentication and encryption algorithms cannot be combined.

#### Improved import/export UI \[ID_19999\]

The import/export UI in Cube has been improved as follows:

- When you select to do an import, you will now first have to select whether you want to import a .dmimport package or a CSV file.
- Similarly, for an export, you will first need to select either an export to a .dmimport package or to a CSV file, to the clipboard or to a printer. This will improve performance of export operations where a .dmimport package is not involved.

#### Visual Overview: Option to embed Chromium browser \[ID_18501\]

If a shape in Visio is linked to a web page, it is now possible to add an option in order to display the page using the Chromium browser. To do so, add the following shape data:

| Shape data field | Value     |
|------------------|-----------|
| Options          | UseChrome |

#### Visual Overview: Highlighting connections based on the source and target of the connection \[ID_19511\]\[ID_21428\]

From now on, it is possible to configure a highlight style that is only applied if the path comes from a certain source and (optionally) goes to a certain destination.

To do so, add the following fields in the **Options** shape data field next to the *HighlightStyle* option, using a pipe character (“\|”) as a separator:

- **HighlightTarget=SourceDestination**: This option must be added to indicate that the type of highlighting to be used is source-to-destination highlighting.

- **Source:\<x>**: This option must be added to indicate where the highlighted path should start.

  \<x> can take the following values:

  - *Element=*\[Element name or DMA ID/Element ID of the source element\]
  - *Protocol=*\[Protocol name of the source element (not including the version)\]
  - *Tag=*\[tag name\]

  To use the “Tag” option, a shape elsewhere in the drawing will need to be configured with the shape data **Tag**, of which the value is set to the tag name.

- **Destination:\<y>**: This is an optional field that can be added to indicate where the highlighted path should end. The highlighted path will then only include shapes and lines that run towards this destination.

  \<y> is configured in the same manner as \<x>, allowing the same three kinds of values.

- **Priority:\<z>**: This optional field allows you to give a highlight style priority over another style.

  \<z> is a number indicating the priority of the style. This way, multiple of these source-to-destination highlight styles can be defined with different priorities. If this field is not defined, the style will get the lowest priority.

- **Direction=Forwards/Backwards/Both**: This optional field allows you to specify the direction in which has to be crawled through the DCF network. Default direction: Forwards.

  - Using *Direction=Backwards* together with *Source:Tag=MySource* will highlight all paths that lead to the *MySource* shape.
  - Using *Direction=Forwards* will highlight all paths starting from the source shape.

Examples:

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Element=231/88|Priority=3
```

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Protocol=MyDCFProtocol|Destination:Tag=Antenna|Priority=2
```

```txt
HighlightStyle|HighlightTarget=SourceDestination|Source:Tag=MySource|Direction=Backwards
```

#### Visual Overview: Device discovery shape \[ID_19646\]

It is now possible to configure a shape in Visio so that it launches the Device Discovery app when it is clicked in Cube. To do so, add the following shape data to a shape linked to a view:

| Shape data field | Value            |
|------------------|------------------|
| Execute          | Device discovery |

Example:

| Shape data field | Value            |
|------------------|------------------|
| View             | MyView           |
| Execute          | Device discovery |

#### Visual Overview: New option to automatically close a VdxPage popup/window after executing the main action \[ID_19689\]

It is now possible to have a VdxPage popup/window close itself automatically after the main action has been executed. To do so, add a data field of type “Options” to a shape displayed inside the VdxPage popup/window and set its value to “ClosePage”.

| Shape data field | Value     |
|------------------|-----------|
| Options          | ClosePage |

The difference between this new “ClosePage” option and the “AutoClosePopup” option is that the former is set on a shape inside the VdxPage popup/window, while the latter is set on the shape opening the popup/window.

#### DataMiner Cube: New user setting to keep track of the history of a correlated alarm \[ID_19718\]

A new setting is available in the Cube user settings app: *Keep track of the full history of a correlated alarm*. If this option is selected, the entire alarm tree will be shown for a correlated alarm in the Alarm Console. Otherwise, only the most recent alarm will be displayed, and its sources will be displayed underneath. By default, the option is selected. If you change this setting, you will need to reconnect Cube to make the change take effect.

#### URL parameters / Alarm hyperlinks: Opening a card on a specific data page \[ID_19898\]

Up to now, it was possible to configure a DataMiner Cube URL or an Alarm Console hyperlink to open an element, service or view card either in Visual Overview mode or in Data Display mode. From now on, it is also possible to specify the exact page that has to be opened.

In the following examples, we open an element in Data Display mode and go directly to subpage “Ping” of page “Performance”:

- Using a DataMiner Cube URL:

  `http://myDma/DataMinerCube/DataMinerCube.xbap?element=48/70:data:performance/ping`

- Using an Alarm Console hyperlink specified in Hyperlinks.xml:

  `<HyperLink type="OpenElement" name="Open Ping page" version="2" id="4">[EID]:Data:Performance/Ping</HyperLink>`

All pages shown in a card’s side panel can be selected. If you want to select a page that is grouped neither under VISUAL nor under DATA, then omit the “visual” (“v”) or “data” (“d”) argument (without omitting any “:” separators). See the following examples:

- `http://myDma/DataMinerCube/DataMinerCube.xbap?element=48/70::help`
- `http://myDma/DataMinerCube/DataMinerCube.xbap?element=48/70::alarms`
- `http://myDma/DataMinerCube/DataMinerCube.xbap?service=48/105::alarms`
- `http://myDma/DataMinerCube/DataMinerCube.xbap?view=SLC::aggregation`

> [!NOTE]
> Names of pages and subpages do not need to be capitalized. All character casing will be ignored.

#### Visual Overview: Embedded Resource Manager timeline component has three new session variables \[ID_19996\]\[ID_23047\]

When you embed a Resource Manager timeline component in a Visio drawing, you can now use the following additional session variables:

- **ResourcesInSelectedReservation**

  When you select a booking block, this session variable will contain a comma-separated list of resource GUIDs.

- **TimerangeOfSelectedReservation**

  When you select a booking block, this session variable will contain the start-stop time range of the booking, inflated by 10%.

  Note that values in this session variable will be serialized. Example: “5248098399646517511;5248392353962787511”

- **Viewport**

  When you pan or zoom in the timeline, this session variable will contain the time range that is visible on the screen.

  When this session variable is set by an external source, the timeline component will be updated to show the new time range. The value can be set in serialized form (e.g. “5248098399646517511;5248392353962787511”) or using a “start;stop” format. In the latter case, start and stop must be timestamps that can be parsed by DateTime (e.g. “2017-09-17T09:42:01.9129607Z;2018-08-23T15:05:53.5399607Z” in ISO 8601 format, or “17/09/2017 9:42:01;23/08/2018 15:05:53” in local format).

> [!NOTE]
>
> - Using the above-mentioned session variables, you can link two timeline components in a master-detail relation.
> - The Viewport session variable can be set on Cube level, card level, page level and workspace level.

#### Visual Overview: 'Edit in Visio' enhancements \[ID_20361\]\[ID_22394\]

When, in DataMiner Cube, you right-click a visual overview and select *Edit in Visio*, the Visio file in question will be opened in Microsoft Visio. In Visio, a new set of add-ins is now available to manage DataMiner-related data.

##### Advanced Editing

The *Advanced Editing* panel is an improved shape data editor. If the panel is not visible, go to the *Add-ins* menu, and click the *Advanced editing* button.

When you click the page background, this panel will list the page data items currently linked to the page. When you click a shape, this panel will list the shape data items currently linked to the shape you clicked.

- To add a data item to either the page or the selected shape, click *Add page data* or *Add shape data* and select a data item from the list. That data item will then be added to the list of data items linked to the page or shape. Now, click inside the value box of the new data item and enter a value.

  When, in a value, you want to add a placeholder (i.e. a dynamic part), then type a square bracket (“\[“), select the placeholder from the list, and press TAB.

  > [!NOTE]
  > Apart from the value of a data item, you can also change the name of a data item. If, however, you change a name to one that is unknown to DataMiner or to one that is already in the list, it will be highlighted.

- To remove a data item from either the page or the selected shape, click the black cross on the right of the item.

#### Forced view table refresh & configurable view table polling interval \[ID_20300\]\[ID_20394\]\[ID_20577\]

##### Forcing a (direct) view table refresh from within a protocol

It is now possible to force a refresh of a (direct) view table displayed in DataMiner Cube from within a protocol.

- To configure this, create a string parameter named “\[TableName\]\_REFRESHVIEWFORKEY”, and set its RTDisplay property to “True”.

When values in a particular row have changed due to a forced poll by the user (i.e. a user clicking a row’s *Update*, *Force poll* or *Refresh* button), then set the “\[TableName\]\_REFRESHVIEWFORKEY” parameter to the following value: the primary key of the row in question, followed by a pipe character (“\|”) and a random value (e.g. the current time).

If, for example, you have a direct view table named “View_Cable Modems”, and the protocol has a parameter named “View_Cable Modems_REFRESHVIEWFORKEY”, then you can force an immediate update of that table in DataMiner Cube by setting that parameter to the following value: “ABCDEF\|124831898” (in which ABCDEF is the primary key of the row and 124831898 is a random value).

> [!NOTE]
>
> - It is advised not to use this refresh mechanism too often, but to limit its use to when the contents of a row have changed due to some user action.
> - This force refresh can also be used to refresh child tables displayed in the CPE Manager KPI list.

##### Setting the view table polling interval

DataMiner Cube does not automatically receive updates for direct view tables and view tables with a *disableViewRefresh* option. Up to now, it polled these tables once a minute, but from now on, it will no longer poll these tables automatically.

If you want DataMiner Cube to automatically poll these tables, then do the following:

- Open the *Users\\ClientSettings.json* file, and set the *commonServer.ui.ViewTableRefresh.PollInterval* setting to a number of seconds.

    A negative or zero value will disable view table polling (which is the default behavior).

If, for example, you set this setting to “900”, all (direct) view tables opened in DataMiner Cube will be refreshed every 15 minutes.

> [!NOTE]
>
> - If, in DataMiner Cube, you hover over the “last updated on” box in the top-right corner of a (direct) view table, the polling interval will be shown in a tooltip.
> - A number of enhancements have been made to the automatic (direct) view table polling mechanism. It will now, for example, also apply to direct view tables and view tables displayed in CPE KPI windows and in Visual Overview.

#### DataMiner Cube - Data display: Table columns can now be shown or hidden using the table header’s right-click menu \[ID_20466\]

In Data Display, table columns can now be shown or hidden by selecting or deselecting them in the table header’s shortcut menu.

> [!NOTE]
>
> - These settings are not saved. When you close a card and then open it again, all column selections you made from a table header’s shortcut menu will be reset.
> - Table columns that have their width set to 0 will be hidden by default. If you want a zero-width column to be shown, then right-click the table header, open the *Columns* submenu, and select it in the list.

#### Visual Overview: Shapes turned into a tab control showing Visio file pages now also support different tab control styles \[ID_20507\]

Shapes turned into a tab control that displays specific pages of a Visio file now also support the new tab control style introduced in DataMiner version 9.5.14.

To use this style, add the “TabControlStyle=2” option to the *Options* shape data item.

Example:

| Shape data field | Value             |
|------------------|-------------------|
| VdxPage          | Page1\|Page2      |
| Options          | TabControlStyle=2 |

#### Visual Overview: Reservation shape \[ID_20517\]\[ID_22075\]

It is now possible to link a shape to a booking, used in the Service & Resource Management suite.

To do so, specify a *Reservation* shape data field and set it to one of the following values:

- The GUID of the booking

- A dynamic placeholder, e.g. \[pagevar:SelectedReservation\]

- A service name, service ID or placeholder referring to a service, e.g. \[this service\]. In that case, the *ReservationID* property of the service will be used.

The following placeholders can be used in the text displayed on the *Reservation* shape:

| Placeholder | Description |
|-------------|-------------|
| \[Name\] | Will be replaced by the name of the booking linked to the shape. |
| \[Status\] | Will be replaced by the value of the *Status* property of the booking linked to the shape. |
| \[Start Time:format=\<format>\] | Will be replaced by the start time of the booking, converted to the DataMiner time. Optionally, a colon (":") can be added within the placeholder, followed by the format in which the start time should be displayed. By default, this is the standard month format, followed by a space and the standard short time format. For other possible formats, refer to the note below. |
| \[End Time:format=\<format>\] | Will be replaced by the end time of the booking, converted to the DataMiner time. This placeholder supports the same optional format configuration as the *\[Start Time\]* placeholder. |
| \[Elapsed Time:format=\<format>,default=\<defaultValue>\] | Will be replaced by the amount of time that has passed since the booking started running. Optionally, a colon (“:”) can be added within the placeholder, followed by the time format and a default value. By default, the format is "\[x days\] hh:mm:ss", where the number of days is only displayed if it is 1 or more, and the local language is used. For other possible formats, refer to the note below. This placeholder is replaced by the default value when the booking is not running. If no default value is specified and the booking is not running, nothing is displayed. |
| \[Time until start:format=\<format>,default=\<defaultValue>\] | Will be replaced by the amount of time that still has to pass until the booking starts. This placeholder supports the same options as the *\[Elapsed Time\]* placeholder. The placeholder is replaced by the default value when the current time is later than the booking start time. If no default value is specified in that case, nothing is displayed. |
| \[Remaining time:format=\<format>,default\<defaultValue>\] | Will be replaced by the amount of time remaining until the booking ends. This placeholder supports the same options as the *\[Elapsed Time\]* placeholder. The placeholder is replaced by the default value if the booking is not currently running. If no default value is specified in that case, nothing is displayed. |
| \[Time since end:format=\<format>,default=\<defaultValue>\] | Will be replaced by the amount of time that has passed since the end of the booking. This placeholder supports the same options as the *\[Elapsed Time\]* placeholder. The placeholder is replaced by the default value if the current time is earlier than the booking end time. If no default value is specified in that case, nothing is displayed. |

> [!NOTE]
>
> - If a parent shape has *Reservation* shape data that resolves to a booking, and a child shape has placeholders that could potentially resolve to the value of a booking property, then you can prevent the child shape from being linked to the parent shape's booking by adding an *Options* shape data field to the child shape and set its value to “AllowInheritance=False”.
> - For more information on possible date and time formats, refer to:
>   - <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings>
>   - <https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings>

#### DataMiner Cube - Visual Overview: New context menu item to copy text to clipboard + new option to customize context menu \[ID_20539\]\[ID_21715\]

If a shape in Visual Overview displays text, a new context menu item is now available for the shape that will allow users to easily copy the text to the clipboard.

In addition, it is now also possible to configure a custom context menu for a specific shape in Visio. To do so, add the *ContextMenu* shape data. For now, the only supported action for this context menu is to copy the shape text, even if the shape is part of a disabled group shape. For this, the following value needs to be specified:

| Shape data field | Value                         |
|------------------|-------------------------------|
| ContextMenu      | MenuItem:Action=CopyShapeText |

Optionally, to make sure that this action is also executed when a user left-clicks on the shape, instead of only when the user right-clicks, you can also add IsDefaultAction=True:

| Shape data field | Value                                              |
|------------------|----------------------------------------------------|
| ContextMenu      | MenuItem:Action=CopyShapeText,IsDefaultAction=True |

#### DataMiner Cube: Enhanced logging & freeze detection \[ID_20600\]\[ID_21259\] \[ID_23363\]\[ID_23719\]

In DataMiner Cube, a number of enhancements have been made to the internal error logging mechanism as well as to the *Logging* section of System Center. Also, an automatic freeze detection has been added.

##### Enhanced Cube tab in Logging section of System Center

On the *Cube* tab of System Center’s *Logging* section:

- Icons now visually indicate the category of each message.

- Of each message, you can now see how many times it was generated (by checking the *Count* column).

- When you click a message in the list, more information about that message will appear in the details pane at the bottom. Clicking the *Open* button in that details pane will make a new card appear, showing all information about that message.

- The *Show debug logging* checkbox now allows you to have the list also display debug log items. By default, this checkbox is not selected.

- At the bottom of the screen, the *Open log folder...* button now allows you to open the folder on the client PC in which the client-side log files are stored.

##### New values for computer setting 'Level of logging'

From now on, the *Level of logging* setting (*Settings \> Computer \> Advanced \> Logging*) will only have two values: “Log everything (5)” and “No logging (0)”.

##### Two types of log entries

In Cube, you can now consult two types of log entries:

| Type        | Location in Cube                                | Location on disk                                                                                   |
|-------------|-------------------------------------------------|----------------------------------------------------------------------------------------------------|
| Client-side | System Center \> Logging \> Cube                | C:\\ProgramData\\Skyline\\DataMiner\\DataMinerCube\\CubeLogging\\SLCubeLog_YYYY_MM_DD_HH_MM_SS.txt |
| Server-side | System Center \> Logging \> DataMiner \> Client | C:\\Skyline DataMiner\\logging\\SLClient.txt                                                       |

> [!NOTE]
> Each time a new Cube session is started, all client-side log files older than 1 week will automatically be deleted.

##### Updated log entry categories

These are the new log entry categories:

- **ClientSystem**: Entries containing information about a Cube client: Microsoft Windows version, Microsoft .Net version, processor type, amount of RAM, etc.

- **Connection**: Entries indicating how long Cube took to set up a connection and load all initial data.

- **Debug**: Entries containing debugging information for developers.

  By default, messages of this category are hidden. To consult them, go to *System Center \> Logging \> Cube*, and select the *Show debug logging* checkbox.

- **Error**: Entries generated due to events that have an impact on overall Cube functionality.

  These entries mostly indicate exceptions that were caught, but which could not be dealt with by the software.

  > [!NOTE]
  > These entries will always be forwarded to the DataMiner Agent to which Cube is connected.

- **Exception**: Entries indicating unhandled exceptions that were thrown in Cube.

  > [!NOTE]
  > These entries will always be forwarded to the DataMiner Agent to which Cube is connected.

- **ForwardDebug**: Entries of category “Debug” that will always be forwarded to the DataMiner Agent to which Cube is connected.

- **ForwardInfo** Entries of category “Info” that will always be forwarded to the DataMiner Agent to which Cube is connected.

- **Freeze**: Entries indicating that Cube became unresponsive at some point.

- **Info**: Entries containing general information.

  Examples: connection time, load time, fetch time, etc.

  > [!NOTE]
  > The log entry category “Default” no longer exists and has been replaced by “Info”.

- **Warning**: Entries generated due to events that had an unexpected outcome, but which did not have an impact on overall Cube functionality.

  Examples: user input that was validated as being incorrect, imported drivers that were validated as being faulty, problems that occurred while reading or writing files or settings, etc.

  > [!NOTE]
  > These entries will always be forwarded to the DataMiner Agent to which Cube is connected.

##### Messages of category Warning, Error and Exception now indicated in Cube header

Up to now, messages of category Warning, Error and Exception were displayed in a pop-up window. Now, instead an icon will be displayed in the Cube header if an error message is logged. Clicking the icon will open the Logging section of System Center. Icons can also be displayed for warning and exception messages, but this does not occur by default. To view these icons in the header, add the following argument to the Cube URL: *?enablefeature=loggingnotifications*

##### Automatic freeze detection

If DataMiner Cube remains unresponsive for a number of seconds, a pop-up window will now appear, asking you whether to keep waiting or to exit Cube.

You can configure this detection mechanism by means of the following system settings in the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file:

| Setting                                            | Description                                                                                             |
|----------------------------------------------------|---------------------------------------------------------------------------------------------------------|
| commonServer.client.ui.logging.FreezeLogTime   | Minimum number of seconds Cube must be unresponsive before a log entry is created. Default: 10 seconds      |
| commonServer.client.ui.logging.FreezePopupTime | Minimum number of seconds Cube must be unresponsive before a pop-up window will appear. Default: 30 seconds |

#### Visual Overview: Using a protocol name in a shape condition \[ID_20646\]

It is now possible to use a protocol name in a shape condition. This allows shapes to be shown or hidden based on the protocol of an element.

If, for example, a shape has the following shape data, it will be shown only when the element named “MyElement” has a protocol named “MyProtocolName”.

| Shape data field | Value                                                |
|------------------|------------------------------------------------------|
| Show             | \<A>-A\|Element:MyElement\|Protocol\|=MyProtocolName |

#### Visual Overview: New 'ListView' component [ID_20649] [ID_21203] [ID_21752] [ID_21686] [ID_21886] [ID_21929] [ID_21931] [ID_22795]

Up to now, when you wanted to turn a shape into a list box control, you had to add two shape data items to that shape: one of type "SetVar" and one of type "SetVarOptions". In the first, you had to specify a list of fixes values or refer to a table parameter containing a number of values, and in the second, you had to specify "Control=ListBox", followed by a number of options if necessary.

In a Visio file linked to either an element or a view, you can now add a list box control by adding a shape with the following shape data items:

| Shape data field |Value |
|------------|------------|
| Component | ListView |
| ComponentOptions | List of options, separated by pipe characters. For an overview of all possible component options, see below. |
| Columns | The list of columns that have to be displayed (in JSON format). If you do not specify this shape data field or leave it empty, all columns will be displayed.<br>Example:<br>*{"Name": "SetVar visioshape columnfilters","Version": 1,"Columns": [{"ColumnKey": "AlarmIcon","Position": 1,"PredefinedWidth": 50, "HorizontalAlignment":"center" },{"ColumnKey": "Name", "Position": 2,"PredefinedWidth": 200, },{"ColumnKey": "ID", "Position": 3,"PredefinedWidth": 80, }]}* |
| Source | The type of items to be shown in the list:<br>- *Elements*<br>- *Services*<br>- *Reservations*/*Bookings* |
| Filter | If you set *Source* to *Elements* or *Services*, then *Filter* can contain a view filter to make the list view only show items from one specific view:<br>- View=\<ViewID\> (with fallback to view name if you specified a number that is used as a name)<br>- ViewName=\<ViewName\> (with fallback to view ID if you specified a number)<br>It is also possible to apply a filter based on the service name. The filter should contain the exposer "Service.Name" and the operator "not Contains" or "contains". The filter can be combined with a view filter, using a pipe ("\|") character as separator. For example: *View=\[var:ViewFilter\]\|Service.Name notContains '1'\|Service.Name notContains 'copy'*<br>If you set *Source* to *Reservations* or *Bookings*, then *Filter* can contain a booking filter based on any field or property.<br>Examples:<br>- *ReservationInstance.Name\[string\]== 'Encoder 2'*<br>- *ReservationInstance.Name\[string\] contains 'Enc'*<br>- *ReservationInstance.Status\[Int32\] == 3*<br>- *ReservationInstance.End\[DateTime\] \>01/22/2019 11:17:32*<br>- *ReservationInstance.Properties.Class\[String\] == 'Silver'*<br>Note:<br>- Both View and ViewName filters will fall back to the root view if the specified view cannot be found.<br>- Instead of specifying a fixed view ID or view name, you can also specify a session variable that contains a view ID or a view name. Example: *View=\[var:mySelectedView\]* |

##### Component options

List of options that can be entered in the *ComponentOptions* data item:

| Component option | Description |
|--------|----------------|
| DisableInUseItems=true/false | When a list view is in edit mode, all list items have a checkbox in front of them. If you set the "Disable-InUseItems" option to "true", the checkboxes that should not be accessible will be shown as disabled. Default: false |
| EditMode=true/false | This option can be used to enable or disable the list view’s edit mode. If set to "true", checkboxes will appear in front of every row. |
| Recursive | This option can be used to link a list view to another list view. If, for example, a ListView component lists the services, and two other ListView components list the source and destination resources available and in use for the services in the first ListView component, then the "recursive" option will allow the source and destination resource ListView components to link to the service ListView component, supporting any type of service hierarchy. |
| SessionVariablePrefix=\[prefix\] | When you specify this option, a unique prefix is assigned to the session variable names. This option allows you to avoid having multiple ListView components using the exact same session variables. |
| StartTime=<br>EndTime= | If the list view is configured to list bookings, then you can use these options to specify a time range.<br>Example: MM/DD/YYYY HH:MM:SS<br>Default settings:<br>- StartTime = NOW - 1 day<br>- EndTime = NOW + 2 days<br>Note: SetVar controls of type DateTime will automatically return a date/time in the correct format.<br> For more information, see: <https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings> |

> [!NOTE]
> Contrary to the above-mentioned options, the “MultipleValueSep” option must be specified in a shape data item of type “SetVarOptions”.

##### Session variables

List of session variables that can be used in conjunction with this *ListView* component:

| Session variable | Contents |
|------------------|----------------------|
| DynamicList_CheckedItems | When a list view is in edit mode, all list items have a checkbox in front of them.<br>This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox is selected. |
| FilterMode | In situations with multiple linked ListView components, set the FilterMode variable to "true" if you want a second, linked ListView to be filtered based on the item selected in the first ListView. Default: false. |
| ListViewCheckingChanged | When a list view is in edit mode, all list items have a checkbox in front of them.<br>This session variable will contain the ID and the values of all editable columns of all list items of which the checkbox state has been changed. |
| ListViewDataChanged | This session variable will indicate whether data has been changed in the list view. |
| ListViewSelectionChanged | This session variable will indicate whether an item has been selected in the list view. |
| IDOfSelection | This session variable contains a list of IDs or GUIDs of the selected items, separated by pipe characters. |
| StateOfSelection | When a booking is selected, this session variable will contain the current state of the booking:<br>- Undefined (0)<br>- Pending (1)<br>- Confirmed (2)<br>- Ongoing (3)<br>- Ended (4)<br>- Disconnected (5)<br>- Interrupted (6)<br>- Canceled (7) |
| ViewPort | This session variable has to contain the time range that will be used when populating a dynamic list with bookings. |

##### Using the component in Cube

In DataMiner Cube, right-clicking the header of the *ListView* component will allow users to change the alignment of a column, change a column name and modify which columns are displayed. It is also possible to save and load a column configuration.

These options are also available in the *Services* tab of the Services app, which uses a similar kind of component. For more information on the different options, see [Services app: New 'Services' tab \[ID_20459\]\[ID_20962\]\[ID_21203\]\[ID_23460\]\[ID_23785\]](#services-app-new-services-tab-id_20459id_20962id_21203id_23460id_23785).

#### Alarm Console: Icons of alarms associated with an element in timeout state will now have an orange X \[ID_20725\]

From now on, icons of alarms associated with an element in timeout state will have an orange X.

#### Protocols & Templates: Viewing protocol version differences when changing the protocol version of an existing element \[ID_20742\]

When you change the protocol version of an existing element, and the protocol XML files of both the old and the new protocol version contain version history information (i.e. inside a \<VersionHistory> element), an icon will now appear next to the *Version* box. When you click that icon, a pop-up window will show an overview of the differences between the two versions.

A protocol version number is made up of four parts:

`Branch.SystemVersion.MajorVersion.MinorVersion (e.g. 2.1.0.1)`

The level of information shown in the pop-up window will depend on the version number part that has changed:

- If *Branch* changed, then only the features in the new branch will be listed.

- If *Branch* did not change, then all changes in *SystemVersion*, *MajorVersion*, *MinorVersion*, and all the versions on which the new version is based will be listed.

- If *Branch* or *MajorVersion* changed, then a warning icon will appear, and you will get the option to have the element recreated (meaning that the existing element will be deleted and a new element will be created with a new element ID) or to continue editing the current element (default setting).

- If *Branch* and *MajorVersion* did not change, then an info icon will appear.

#### Visual Overview: Embedding the Bookings app as a component \[ID_20812\]\[ID_21686\]

It is now possible to embed the *Bookings* app in a Visio shape.

To do so, add a shape data item of type *Source*, and set its value to “*Reservations*”.

| Shape data field | Value        |
|------------------|--------------|
| Source           | Reservations |

- A filter can be applied using the YAxisResources session variable.

    Example: \[{"Type":"custom","Background":"#FFFFFF","ItemHeight":64,"Filter":"(ReservationInstance.Name\[String\]  notContains 'SRMExposeFlow')"}\]

- A time range can be applied using the Viewport session variable.

    Example: 5248460498427387904;5248491602427387904

#### New annotations editor \[ID_20838\]

DataMiner Cube now features an entirely new annotations editor.

#### Ticketing: Ticket fields can now automatically be populated with alarm information \[ID_20961\] \[ID_21136\]

When creating a ticketing domain, it is now possible to link ticket fields to alarm fields.

This will allow ticket fields to automatically inherit alarm field contents when Cube users right-click an alarm in the Alarm Console and select *Ticket \> New ticket*.

##### Linking an alarm field to a ticket field

1. In the Ticketing app, click the cogwheel icon in the header, open a ticket domain, and add a new ticket field (or edit an existing ticket field).
1. In the *Edit field* window, open the *Alarm field* box, select the alarm field that you want to link to the ticket field, and click OK.

When you now right-click an alarm in the Alarm Console and select *Ticket \> New ticket*, you will notice that the ticket field that you linked to an alarm field will have inherited the contents of that alarm field.

#### Visual Overview: Cropped images now supported \[ID_21019\]

Visual Overview now supports images that were cropped in Microsoft Visio.

#### Visual Overview - Trend component: Top/bottom X & wildcard result limitation \[ID_21035\]

The trend component has two new features.

##### Top/bottom X functionality

When configuring a trend component, it is now possible to specify that it should only show the top/bottom X current values of a particular parameter.

In the “Sort” shape data field, you can add the following for every parameter specified in the “Parameters” shape data field: \[SortOrder\],limit:X (where SortOrder is either ASC or DESC, and X is the number of values to be shown).

See the following example:

| Shape data field  | Value                      |
|-------------------|----------------------------|
| Component         | Trending                   |
| Parameters        | 520/3:270:\*\|520/3:203:\* |
| ParametersOptions | ShowLegend:true            |
| Sort              | ASC,limit:2\|DESC,limit:1  |

> [!NOTE]
> The trend component will show an information bar only if the number of values found for a particular parameter exceeds the default limit (i.e. 10). It will not show an information bar if the number of values found for a particular parameter exceeds a limit that was explicitly specified in the “Sort” data field.

##### Limiting wildcard results

When configuring a trend component, it is now possible to limit the number of parameters that match the wildcard expression specified in the “Parameters” shape data field. Previously, the number of returned parameters had a fixed limit of 10.

In the “ParametersOptions” shape data field, you can add the following for every parameter specified in the “Parameters” shape data field: Limit:X (where X is the number of values to be shown).

See the following example:

| Shape data field  | Value        |
|-------------------|--------------|
| Component         | Trending     |
| Parameters        | 520/3:207:\* |
| ParametersOptions | Limit:2      |

> [!NOTE]
> The trend component will show an information bar only if the number of parameter found for at least one of the wildcard expressions exceeds the default limit (i.e. 10). It will not show an information bar if the number of parameters found for at least one of the wildcard expressions exceeds a limit that was explicitly specified in the “ParametersOptions” data field.

#### Service & Resource Management: Profiles app now supports profile parameters of type Capacity and Capability \[ID_21296\]

The Profiles app now supports profile parameters of type Capacity and Capability.

#### Service & Resource Management - Visual Overview: Shape inheritance for Reservation shapes and support for placeholders containing booking properties \[ID_21391\]

It is now possible to use placeholders containing custom booking properties in the text on a Visio shape.

In addition, shape inheritance has been added for *Reservation* shapes. This means that if a parent shape has *Reservation* shape data and a child shape is linked to this same booking, for instance because of shape text placeholders or *Info* shape data, the child shape will be considered a Reservation shape linked to the same booking.

#### DataMiner Cube - Visual Overview: Condition to check the number of quarantined bookings \[ID_21598\]

In Visio, it is now possible to apply conditional shape manipulations depending on the number of bookings that have been quarantined in the system. Quarantined bookings are bookings that they have automatically returned to a pending state by the DMA.

To do so, for shape data fields such as Hide, Show, Highlight, etc., specify a condition like the following example:

```txt
<A>-A|Reservations|NumberOfQuarantinedReservations|>1
```

#### Contacts window: More user-friendly application name displayed when hovering over a user in the list \[ID_21561\]

When, in the Contacts window, you hover over a user, the tooltip will now display a user-friendly description of the application that person is using to connect to the DMS. If such a name is not available, the name as used up to now will be displayed instead.

Format of the text in the tooltip:

```txt
[ClientAppDisplayName or ClientAppName] Online since [ConnectTime]
```

#### Visual Overview: A shape linked to an alarm can now list the impacted services of that alarm \[ID_21657\]

If a shape is linked to an alarm, it is now possible to have the list of impacted services displayed on that shape.

To do so, add a shape data field of type “Info”, and set its value to “Services”. See the example below.

Make sure the text of the shape contains an asterisk ('\*'). At run-time, this asterisk will then be replaced with the names of all impacted services.

Example:

| Shape data field | Value       |
|------------------|-------------|
| Alarm            | 111/273/350 |
| Info             | Services    |

#### Documents: Uploading a document linked to an element and only storing it on the DMA hosting the element \[ID_21690\]\[ID_21993\]\[ID_21997\]

It is now possible to upload a document, link it to a specific element, and have it stored only on the DataMiner Agent hosting the element in question.

When you upload a document and link it to an element:

- The document will only be stored in the *C:/Skyline DataMiner/Elements/ElementName/Documents* folder on the DataMiner Agent hosting that element. It will not be synchronized to the other agents in the DataMiner System.

- A small, single-byte file with the same name as the document will be stored in the *C:/Skyline DataMiner/Documents/Elements/ElementName* folder. Contrary to the document itself, this small file will be synchronized among all agents in the DataMiner System, and will be used to make all agents aware of this element-level document.

##### Uploading a document and linking it to a specific element

1. Open the element card, and go to the *Documents* page.
2. Select the folder with the same name as the element, right-click in the document list, and select *Add document*.
3. Under the *Documents* option, click *Browse*, and browse to the document you want to add.
4. Under *Location*, select *Local*, and select the element to which you want to link the document.
5. Click *OK*.

> [!NOTE]
> From now on, in the *Documents* app, a progress bar will be displayed when you are uploading or downloading a document.

#### All Cube clients will now display 'broadcast popups' sent from QActions, Automation scripts, etc. \[ID_21733\]\[ID_21928\]\[ID_22089\]

When a QAction, an Automation script, etc. sends a BroadCastPopupRequestMessage with the following arguments, a BroadCastPopupEventMessage will now be sent to all recipients specified in the UserNames and GroupNames arguments, causing a so-called “broadcast popup” to appear.

| Argument | Format | Description |
|--|--|--|
| Source | GUID | A GUID indicating the entity that sent the message. |
| Title | String | The title of the message. |
| Message | String | The contents of the message. |
| UserNames | List\<string> | The list of users who will receive the message.<br> User name format:<br> - Domain users: “domainname\\username”<br> - Local users: “username” |
| GroupNames | List\<string> | The list of user groups of which the members will receive the message.<br> Group name format:<br> - Domain groups: “domainname\\groupname”<br> - Local groups: “groupname” |
| Expiration | DateTime | The date/time until which the message will be shown.<br> Note:<br> - If no Expiration argument is specified, the message will never expire.<br> - If you set Expiration to DateTime.MinValue (default setting) or DateTime.MaxValue, the message will never expire.<br> - If you set Expiration to a date more than one year into the future, the expiration date of the message will not be displayed. |

- All messages received in a BroadCastPopupEventMessage will be listed in the same message box.

- When a BroadCastPopupEventMessage is received with a GUID identical to that found in a message received earlier, then that earlier message will be replaced by the new message.

    > [!NOTE]
    > When a BroadCastPopupEventMessage is received with a GUID identical to that found in a message received earlier and an Expiration date/time in the past, then that earlier message will be cleared.

- When both the UserNames and GroupsNames arguments are empty, the message will be sent to all clients.

- When a user acknowledges a message, the message will only disappear in that particular Cube session. It will remain visible on all other Cube clients that received the same message.

- Each message will show the time at which it was received and the time until which it will be shown (if such a time was specified in the BroadCastPopupRequestMessage).

- In the Message argument (i.e. the contents of a message), you can include some of the placeholders that can be included in Visio shape data values. As this kind of broadcast messages do not have any context, placeholders like e.g. \[this element\] or \[cardvar:abc\] will not work. For a list of Visio placeholders, see [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

#### Visual Overview: Dynamic placeholder '\[Param:\]' can now retrieve all values of a column parameter \[ID_21781\]

The dynamic placeholder “\[Param:\]” can now retrieve all values of a column parameter. Up to now, specifying a column parameter in a “\[Param:\]” placeholder would result in a “Not Initialized” error.

To have a “\[Param:\]” placeholder retrieve all values of a column parameter, specify the ID of that column parameter in the placeholder.

In the following example, all values of column parameter 110 are retrieved and displayed as “One\|Two\|Three”.

| Shape data field | Value                                                |
|------------------|------------------------------------------------------|
| Tooltip          | Summary of parameter 110 is: \[Param:MyElement,110\] |

If you want a custom separator instead of the default separator (“\|”), then you can specify that custom separator in a shape data item of type “Options”. See the example below.

| Shape data field | Value              |
|------------------|--------------------|
| Options          | MultipleValueSep=; |

#### New ClientSettings.json setting to determine CPE card behavior \[ID_21822\]

A new setting is available in the file ClientSettings.json, *Surveyor.CPE.LaunchCPECardOnSelect*, which determines what happens when a CPE card is opened based on the Surveyor topology. If this setting is set to true, a CPE card will be opened as soon as an item is selected in the Surveyor topology. If this setting is set to false (which is the default configuration), the CPE card will only be opened if the launch button is clicked in the Surveyor topology.

For example:

```json
{
   "Name":"Surveyor.CPE.LaunchCPECardOnSelect",
   "Value": false,
   "VersionNumber": 0,
   "Mode": 0,
   "InVisible": false
}
```

#### Visual Overview: YaxisResources session variable now allows DMA ID/Element ID configuration \[ID_21832\]

When a *Reservations* or *Bookings* component is embedded in Visio, the resources on the Y-axis of the timeline can be specified using the session variable *YAxisResources*. When this session variable is used to refer to specific resources, this can now also be done by referring to the DMA ID and element ID of resources linked to an element, using the syntax "*YaxisResources:Resource=**DMA ID/Element ID*". For example:

| Shape data field | Value                          |
|------------------|--------------------------------|
| SetVar           | YaxisResources:Resource=34/101 |

#### Visual Overview: Displaying or using the current DataMiner time in a shape \[ID_21866\]

It is now possible to have a shape display the current DataMiner time or to use that time in shape data items.

To do so, add the following dynamic placeholder to either the shape text or a shape data item:

- \[DataMinerTime\]

By default, the current DataMiner time will be displayed in the regional date/time format. If you want that time to be displayed in another format, then specify the format inside the placeholder. See the following example:

- \[DataMinerTime:Format=HH:mm:ss\]

> [!NOTE]
> The time shown by this dynamic placeholder will be refreshed every second.

#### Visual Overview: Calculating datetime and timespan values using dynamic placeholders \[ID_21911\]

The existing \[Sum:...\] placeholder and the new \[Subtract:...\] placeholder can now be used to calculate datetime and timespan values.

Also, the new \[Reservation:...\] placeholder can be used to retrieve the start or the end of an existing booking.

##### \[Subtract:...\]

Use this new dynamic placeholder to calculate datetime and timespan values by subtracting one or more values from a specified value. See the following examples.

- Calculating a timespan by subtracting one datetime value from another:

    \[Subtract:14/02/1989 22:22:22,12/01/1989 11:10:9\]

- Calculating a timespan by subtracting a datetime value and two timespan values from a datetime value:

    \[Subtract:14/02/1989 22:22:22,12/01/1989 11:10:9,00:01:00,00:00:05\]

- Calculating a datetime value by subtracting a timespan from a datetime value:

    \[Subtract:14/02/1989 22:22:22,00:02:00\]

- Calculating a timespan by subtracting one timespan from another:

    \[Subtract:23:33:15,00:03:15\]

By default, datetime and timespan values will be displayed in the regional date/time format. If you want such a value to be displayed in another format, then specify the format inside the placeholder. See the following example: \[Subtract:23:33:15,00:03:15\|Format=HH:mm\]

##### \[Sum:...\]

Similar to the \[Subtract:...\] placeholder above, this existing dynamic placeholder can now also be used to calculate datetime and timespan values by adding one or more values to a specified value.

##### \[Reservation:...,Start/End\]

Use the new \[Reservation:...\] placeholder to retrieve the start or the end of an existing booking.

See the following example: \[Reservation:\<ReservationGuid>,Start\]

As this \[Reservation:...\] placeholder produces a datetime value, it can also be used inside a \[Sum:...\] or \[Subtract:...\] placeholder.

#### Visual Overview: Shape data fields of type 'Parameters' now also accept element names, \[this element\] placeholders and keys containing forward slashes \[ID_21976\]

When configuring a trend component or a parameter chart, up to now, the shape data field of type *Parameters* had to contain a value with the following syntax:

```txt
DmaID:ElementID:ParameterID[:TableRowFilter]|...|...
```

In a value like the one found above, from now on, it is also allowed to use element names, \[this element\] placeholders and keys containing forward slashes (e.g. dmaID/elementID).

#### DataMiner Cube - Visual Overview: Possibility to link page to multiple CPE chains and/or fields \[ID_22107\]

Previously, a Visio page could only be linked to one particular chain and field of a CPE Manager element. Now it is possible to link a page to several chains and/or fields.

To do so, in the *Chain* and *Field* shape data, specify the different chains and fields using pipe characters as separators. For each combination of a chain and field value from the shape data, the page will be displayed.

For example:

| Shape data field | Value                              |
|------------------|------------------------------------|
| Chain            | olt (limited)\|cmts topology\|maps |
| Field            | OLT\|CMC                           |

With the configuration of the example above, the page will be visible for the *OLT* and *CMC* field when the user navigates in the *OLT (limited)*, *CMTS topology* or *maps* chain.

> [!NOTE]
> If the *Field* shape data ends in a pipe character, the page will also be displayed when no field is selected.

#### Visual Overview: New dynamic placeholder \[Resource:...\] \[ID_22157\]

From now on, the \[Resource:...\] placeholder can be used to retrieve a property of a resource, which can be the name of the resource, the ID of the element linked to the resource, or a custom property.

For this purpose, the following syntax must be used:

\[Resource:*\<GUID>*,*\<property>*\]

This syntax consists of the following components:

- The GUID of the resource.

- The property to be retrieved, which can be specified as follows:

    | Property                                            | Value returned                                                                                                                                                               |
    |-------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | FullElementID                                         | The ID of the element linked to the resource in the format DmaID/ElementID. This can for instance be used to link to an actual element in Element shape data.                |
    | Name                                                  | The name of the resource.                                                                                                                                                    |
    | Property=*\<propName>* | The value of a custom property of the resource. The name of that custom property must be specified in *\<propName>*, e.g. Property=State. |

#### Alarm Console - Custom hyperlinks: filterElement attribute supports alarm property names that contain spaces \[ID_22178\]

In a \<Hyperlink> tag, from now on, the filterElement attribute supports alarm property names that contain spaces.

If, in a filterElement attribute, you specify a property name that contains spaces (e.g. “System Type”, “System Name”, etc.), then you must enclose it in XML-encoded double quotes. See the following example.

```txt
filterElement="AlarmEventMessage.PropertiesDict.&quot;System Type&quot;[String] == 'OLT'"
```

#### Visual Overview: Displaying or using the DataMiner time in UTC or local time in a shape \[ID_22252\]

It is now possible to have a shape display the current DataMiner time in either UTC time or local time, and to use those times in shape data items.

To do so, add the following dynamic placeholders to either the shape text or a shape data item:

- \[UTCTime\]
- \[LocalTime\]

By default, those times will be displayed in the regional date/time format. If you want a time to be displayed in another format, then specify the format inside the placeholder. See the following example:

- \[UTCTime:Format=HH:mm:ss\]

> [!NOTE]
> The times shown by these dynamic placeholders will be refreshed every second.

#### Visual Overview: Comprehensive set of Visio stencils now shipped with DataMiner \[ID_22643\]

DataMiner is now shipped with a comprehensive set of Visio stencils, which will automatically be downloaded to the client computer when you open Microsoft Visio from within DataMiner Cube. In Microsoft Visio, these stencils can be found under *More Shapes \> DataMiner*.

Using the new DataMiner stencils will considerably speed up the design of visually attractive Visio drawings. Not in the least because the stencils contain macros that automatically fill in the necessary shape data when you add shapes to a drawing. Only group-level shape data has to be filled in manually.

> [!NOTE]
>
> - In Microsoft Visio, open the *Visio options* window, go to *Advanced \> General*, and make sure the *Enable Automation events* option is selected.
> - Shape data used by the macros to fill in child-level shape data is always preceded by an underscore character.

#### DataMiner Cube - Data Display: Tooltips can now be displayed for icons in table cells containing discrete values \[ID_22884\]\[ID_23003\]

In a protocol, it is now possible to define a tooltip for every discrete parameter value. That tooltip will then be displayed when the mouse pointer hovers over the icon displayed in a table cell containing the discrete parameter value to which it is linked.

In the following example, a tooltip was defined that displays data found in other columns of the same table (see also the note regarding placeholders below).

```xml
<Discreets>
  <Discreet iconRef=”CAT”>
    <Display>Two</Display>
    <Value>2</Value>
    <Tooltip>
      Number ‘{pid:1003}’\n
      dateTime ‘{pid:1004}’
    </Tooltip>
  </Discreet>
  ...
</Discreets>
```

> [!NOTE]
>
> - When you define tooltips for discrete values, note that, within a given \<Discreets> tag, all \<Discreet> tags should have a \<Tooltip> tag. If no value should be defined for a particular \<Discreet> tag, leave the \<Tooltip> tag empty.
> - If you defined a tooltip for a particular discrete value, you cannot set the displayIconAndLabel attribute to “true”.
> - For the list of placeholders that can be used inside the text of a tooltip, refer to the “Protocol.Params.Param.Measurement.Discreets.Discreet” section in the Protocol Development Library.

#### Visual Overview: Parameter cache can now be used by shapes linked to a table column value and by \[param:\] placeholders that retrieve a table column value \[ID_22900\]

In the global user settings in DataMiner Cube (*C:\\Skyline DataMiner\\Users\\ClientSettings.json*), it is possible to configure that certain table parameters have to be cached. This cache can now also be used for:

- a shape that is linked to a table column value, and
- a \[param:\] placeholder that retrieves a table column value.

> [!NOTE]
>
> - For this to work, you only have to configure in the *ClientSettings.json* file that the table in question needs to be cached on the client. No changes have to be made to the Visio file.
> - Table indices containing wildcards are not yet supported.

#### Alarm Console: New 'Keep active alarms' option to prevent active alarms from disappearing from a sliding window alarm tab \[ID_23056\]

Up to now, when you created an alarm tab of type “sliding window”, it would only display active alarms as long as they occurred within the sliding window. From now on, when you create an alarm tab of type “sliding window”, you can enable the *Keep active alarms* option to prevent the active alarms from disappearing from the alarm tab the moment they are no longer within the sliding window.

#### Data Display: Full-screen button on Data pages \[ID_23187\]

Similar to the one on Visual Overview pages, from now on, there is also a full-screen button on Data pages.

> [!NOTE]
> When, on a Data page in full-screen mode, you maximize a table and then exit the full-screen mode, the normal Data page viewing mode will be restored.

#### Alarm Console: 'Merge alarm trees...' option \[ID_23200\]

In the list of Alarm Console settings, which you can access by clicking the hamburger button in the top-left corner of the console, you can now find the new *Merge alarm trees...* option.

If you click this option, you can choose to merge all alarm trees for the same element/parameter combination (active tree and cleared trees) into one. If you choose to do so, you can also indicate that you only want to merge trees of which the time difference is less than X seconds.

> [!NOTE]
> This new option will only be available when *History tracking* is enabled, *Freeze* is disabled and automatic alarm clearing is disabled.

#### More detailed error message will now appear when an interactive Automation script fails \[ID_23251\]\[ID_23561\]

Up to now, when an interactive Automation script failed, a generic popup message was displayed, stating that something went wrong.

From now on, when an interactive Automation script fails, a popup message will appear, containing more detailed information about why the script failed (e.g. the user aborted the script while it was running, the script ran for too long and went into timeout, etc.).

#### Visual Overview: Linking to an element or partial element in a service by passing the service context in the element shape \[ID_23319\]

Up to now, it was possible to link to partial elements in a service context if the parent shape or the Visio file had a service context. In other words, when using child shapes or when the Visio file was linked to a service.

From now on, it will also be possible to set the service context by explicitly specifying a service in the *ServiceContext* shape data field of the element shape. The shape data of the element will then be resolved based on the name, ID or alias of the element, but in the context of the service you specified in the ServiceContext field.

| Shape data field | Value                                                             |
|------------------|-------------------------------------------------------------------|
| ServiceContext   | *Name, ID or alias of the service* |

#### Visual Overview: Navigation to data pages via shapes \[ID_23386\]

You can now configure a shape in Visio so that it can be used to navigate to any page of an element, service or view. Previously, this was only possible for visual overview pages, but now you can also configure a shape to navigate to data pages.

To do so:

1. Link the shape to the DataMiner object with the page you want to navigate to. For example, for an element, add the *Element* shape data field and specify the DMA ID/element ID as its value.

2. Add the following shape data to the shape:

    | Shape data field | Value                                                                                                                                                                                                                                                                                                                                                                                     |
    |--------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Page               | “*data*” or “*d*” for a data page or “*visual*” or “*v*” for a visual page, followed by a colon and the name of the page. To link to a subpage, add a forward slash and the name of the subpage. For example: *data:performance/Task Manager* |

#### Redesigned DataMiner Cube layout \[ID_23427\]\[ID_23486\]\[ID_23540\]\[ID_23628\]\[ID_23646\] \[ID_23813\]\[ID_23822\]\[ID_23904\]\[ID_23982\]\[ID_24036\]\[ID_24044\]\[ID_24079\]\[ID_24086\]\[ID_24129\] \[ID_24143\]\[ID_24160\]\[ID_24165\]\[ID_24189\]\[ID_24218\]\[ID_24518\]

The design of DataMiner Cube has been updated to be more user-friendly and more in line with other DataMiner apps. Aside from numerous small layout changes, there have been a number of large changes, as detailed below.

##### Redesigned header bar

- In the header bar, the date and time and the four squares indicating the four "sides" of Cube are no longer displayed by default. A drop-down arrow in the header bar provides quick access to settings that allow you to display these again if you prefer this. These settings are also available on the *Cube* tab of the Cube settings card.

- In the middle of the header bar, there is now a search box. This search box features improved search possibilities compared to the search box that was previously included in the side panel. As soon as you click the search box, a list of suggestions is shown below. Initially, this list shows recent items, but it is updated with search results as soon as you type anything in the box. You can click a suggestion to immediately open the corresponding card, or click *Advanced search* at the bottom of the list to open a complete list of search results in the side panel. This list will stay visible until another tab is selected.

    > [!NOTE]
    > Hidden elements are no longer included in the search results.

- Cube settings, card layout settings, updates, and other options that were previously available via various menus of the header bar are now available in one single menu, which can be accessed via the user icon in the top-right corner.

- If an alarm storm occurs, this is no longer displayed in the header bar. Instead, a button is now displayed at the bottom of the Alarm Console. A tooltip on the button provides more information.

- The alarm banner has been replaced with a notification in the header bar. A new Cube setting is available, which allows you to choose between a wide or compact alarm banner.

##### Redesigned side panel

- The side panel on the left or right side of the Cube UI is now by default displayed as a blue bar containing the *Surveyor*, *Activity*, *Apps* and *Workspace* icons. Clicking these icons opens the corresponding panel.

- The *Activity* panel replaces the former *Recent* tab of the side panel, but functions in the same way as this tab, allowing you to pin items to the top of the list of recent activity.

- The icons in the Surveyor and apps panel have been updated. These are now the most commonly used icons:

  | Icon                                                                  | Description      |
  |-----------------------------------------------------------------------|------------------|
  | ![element icon](~/release-notes/images/CubeXElement.png)              | Element          |
  | ![service icon](~/release-notes/images/CubeXService.png)              | Service          |
  | ![redundancy group icon](~/release-notes/images/CubeXRedunGroup.png)  | Redundancy group |
  | ![SLA icon](~/release-notes/images/CubeXSLA.png)                      | SLA              |
  | ![view icon](~/release-notes/images/CubeXView.png)                    | View             |

  If an alarm is present on an element, service, redundancy group or SLA, this is indicated by a colored circle in the bottom-right corner of the icon. For a view, the entire icon is colored according to the alarm severity.

  However, note that these new icons do not support latch level, aggregation level and split view level indications. As such, a new user setting is available, *Use modern icons*, which can be cleared to use the previous icons again.

##### Redesigned logon screen

- The logon screen now features a minimalist design, showing only the DataMiner logo, the IP of the DMA, the login info and a configuration button. With a button at the bottom of the window, you can switch between the current Windows user and a different user profile. The configuration button provides access to options, the "about" information and logging.

- A number of buttons are now available, based on the status of the logon and the DMA. While you are logging onto a DMA, you can click *Back* to return to the logon screen. If a DMA is upgrading or migrating when you log on, you can click the *Monitor* button to monitor the progress. If a DMA is stopped, you can click *Start*, and if a DMA is offline, you can click *Set online*.

#### Smart-serial server elements can now have a list of allowed IP addresses configured \[ID_23592\]\[ID_23673\]\[ID_23694\]\[ID_23739\]

When, while editing an element in DataMiner Cube, you configure a smart-serial server port of type TCP, it is now possible to specify a number of allowed IP addresses for that particular port.

Up to now, when multiple elements were using the same smart-serial server port, each of those elements would

- receive all messages from all elements using that port, and
- forward all messages to all elements using that port.

From now on, for each of their smart-serial server ports of type TCP, elements can have a list of IP addresses configured from which they will accept incoming messages and to which they will forward messages.

- When, for a particular smart-serial server port, an element has a list of allowed IP addresses configured, it will from now on

  - accept messages only from those IP addresses, and
  - forward messages only to those IP addresses.

- When, for a particular smart-serial server port, an element does not have a list of allowed IP addresses configured, it will from now on

  - accept messages from all IP addresses that have not been added to an “allowed IP addresses” list linked to that port, and
  - forward messages only to IP addresses that have not been added to an “allowed IP addresses” list linked to that port.

> [!NOTE]
>
> - If none of the elements that use a particular smart-serial server port have allowed IP addresses configured for that port, they will behave as before.
> - By default, this “allowed IP addresses” functionality is disabled. For more information on how to enable it, see below.

##### Enabling the 'allowed IP addresses' functionality in the Protocol.xml file

In the Protocol.xml file of a smart-serial element, you can enable or disable the AllowedIPAddresses functionality by setting AllowedIPAddresses.Disabled to “false” in the user settings of the smart-serial connection. In the following example, it has been enabled.

```xml
<Connections>
  <Connection name="Smart-Serial Server" id="0">
    <SmartSerial>
      <UserSettings>
        <AllowedIPAddresses>
          <Disabled>false</Disabled>
        </AllowedIPAddresses>
      </UserSettings>
    </SmartSerial>
  </Connection>
</Connections>
```

#### Visual Overview: Bookings component and ListView component on same Visio page are now automatically synchronized \[ID_23715\]

On a Visio page containing both a Bookings component showing a timeline and a ListView component listing bookings, selecting a booking in one component will now automatically cause the same booking to be selected in the other component.

#### Visual Overview: New options for VdxPage pop-up windows \[ID_23734\]

When a shape is configured to display a page of the Visio drawing in a normal, undocked window using a VdxPage data shape field set to “\<Pagename>\|Window”, two new options can now be specified in a LinkOptions data shape field.

| Shape data field | Value                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| VdxPage          | *\<PageName>*\|Window                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| LinkOptions      | WindowStyle=*\<Style>*<br> \<Style> can be:<br> - SingleBorderWindow: A window with a single border<br> - ThreeDBorderWindow: A window with a 3-D border<br> - ToolWindow (default): A fixed-size tool window without minimize/maximize buttons<br> KeepOnTop=*\<true/false>*<br> - When set to true, the window will always appear in front of the window from which it was launched (default: false) |

#### Visual Overview: New \[Event:...\] placeholder \[ID_23834\]

By specifying an \[Event:...\] placeholder in a shape data field or a page data field, it is now possible to have an action triggered when a particular event occurs. During the event, the \[Event:...\] placeholder will be replaced by the value of the argument specified in the placeholder.

Syntax of the placeholder: \[Event:*\<EventName>*,*\<ArgumentName>*\]

At present, only one Router Control event can be specified:

- EventName: IOClicked

- Possible arguments:

    | Name               | Description                                                                           |
    |--------------------|---------------------------------------------------------------------------------------|
    | Label              | The label of the input or output that was clicked.                                    |
    | Index              | The index of the input or output that was clicked.                                    |
    | DCF interface ID   | The ID of the DCF interface that is linked to the input or output that was clicked.   |
    | DCF interface name | The name of the DCF interface that is linked to the input or output that was clicked. |

Example: \[Event:IOClicked,Label\]

> [!NOTE]
>
> - If you specify multiple \[Event:...\] placeholders in a shape data field or a page data field, only one action will be triggered when that event occurs.
> - It is advised not to insert \[Event:...\] placeholders into other dynamic parts or placeholders.

#### DataMiner Analytics: Alarm focus \[23911\]\[ID_24083\]\[ID_24102\]\[ID_24128\]

The DataMiner Analytics software will now by default assign an estimated likelihood, called a focus score, to each active alarm after analyzing the short-term history and current behavior of incoming alarms in real time.

Focus scores are numbers ranging from 0 (completely unexpected) to 1 (fully expected). They are stored in AlarmFocusEvents that are generated by SLAnalytics and cached by SLNet. Each AlarmFocusEvent contains an alarm ID and a likelihood field containing the focus score.

The decision whether an alarm is expected is based on likelihood and frequency:

- Likelihood scores are used to spot daily patterns. If an alarm occurs at the same time every day, it will be assigned a high likelihood value at that time.

    > [!NOTE]
    > Likelihood values are based on UTC time. As a result, when daylight saving time goes into or out of effect, patterns following local time might be off for approximately one week.

- Frequency scores are used to detect parameters that frequently go into and out of alarm, or alarms that persist over a long time.

The focus score that is assigned to an alarm is a combination of likelihood, frequency and severity.

> [!NOTE]
>
> - Currently, every DataMiner Agent is responsible for calculating the focus scores of the alarms it is hosting.
> - Currently, no focus score is assigned to the following types of alarms: Correlation alarms, external alarms and information events. By default, those alarms are assigned a focus score equal to null.

##### New column in Alarm Console: Focus

In the *Active alarms* tab page, for each alarm that can be considered “unexpected”, an icon will be displayed in the new *Focus* column, which is located between the *Icon* column and the *Element name* column.

Also, in the blue footer of the *Active alarms* tab page, you will notice a new focus icon. If you click this icon, the current tab page will only display the alarms with a focus icon in the *Focus* column.

> [!NOTE]
> If an alarm template changes, all alarms of the parameters that were assigned that alarm template will have their focus score reset and will get the focus icon. All historical focus data for those alarms will be lost.

##### In the event of an alarm storm

During an alarm storm, focus scores of persistent alarms will not be updated, but as soon as a storm has ceased, all active alarms will have their focus scores updated with the most recent values.

Also, an information event will be generated when alarm focus calculation goes into and out of alarm storm mode.

##### When will alarm focus values be recalculated from scratch?

Alarm focus values will be calculated for the first time after an upgrade to DataMiner version 10.0.2. They will only be recalculated from scratch when SLAnalytics notices that, for whatever reason, the Alarm Focus database table has been cleared.

When calculating alarm focus values for the first time, or when recalculating them from scratch, SLAnalytics will take into account the alarm history of the last week. The time taken by such a recalculation, will depend on the amount of alarms to be updated.

#### New system-wide ClientSettings.json setting to configure whether Data Display pages should be unloaded from memory when you navigate away from them \[ID_23913\]

In the *ClientSettings.json* file, the new system-wide *commonServer.ui.datadisplay.PageUnloadOnNavigatingAway* setting allows you to configure whether Data Display pages should be unloaded from memory when you navigate away from them.

Default value: False

#### Visual Overview: New option to collapse empty rows and columns in the connectivity chain of a service instance \[ID_23941\]

By adding a data field of type ‘ServiceInstance’ to a shape, it is possible to have the connectivity chain of a service instance drawn automatically in Visual Overview.

When configuring such a shape, from now on, you can use the *CollapseEmptyRowsAndColumns* option to automatically collapse all empty rows and columns in the connectivity chain.

Example:

| Shape data field | Value                            |
|------------------|----------------------------------|
| ServiceInstance  | \[this service\]                 |
| Options          | CollapseEmptyRowsAndColumns=True |

#### Settings: ‘Table export column separator’ setting replaced by ‘CSV separator’ setting \[ID_23986\]

The *Table export column separator* setting (on the *User \> Data Display* page of the *Settings* window) has now been replaced by the *CSV separator* setting (on the *User \> Regional* page of the *Settings* window).

The separator you select in this new setting will be used in all CSV files exported from Cube.

> [!NOTE]
>
> - This *CSV separator* setting is a Cube-only setting. When a CSV file export is initiated directly by a DataMiner Agent, this setting will be disregarded.
> - Before you import a CSV file that was exported using a previous version of Cube, make sure to check the separator used in that file.
> - When you copy data to the Windows clipboard, that data will always be delimited by TAB characters, regardless of the delimiter specified in the CSV separator setting.

#### Automation/Correlation/Scheduler - Email action: List of reports to be included now indicates whether a report is a legacy report or a Dashboards app report \[ID_24015\]

When, in Automation, Correlation or Scheduler, you configure an email action, you can specify whether the email message has to include a report. To do so, you select the *Include report or dashboard* checkbox and select a report from the list.

From now on, each report listed in the report selection box will have an icon that indicates whether it is a legacy report or a Dashboards app report.

#### DataMiner Cube will now be built as an AnyCPU application \[ID_24168\]

As from DataMiner X, DataMiner Cube will be built as an AnyCPU application.

ClickOnce StandAlone and MSI versions will run as 64-bit processes on 64-bit systems and as 32-bit processes on 32-bit systems.

> [!NOTE]
>
> - Microsoft Internet Explorer always launches PresentationHost.exe as a 32-bit process. As a result, ClickOnce XBAP versions of Cube will always run as 32-bit processes.

#### New sidebar docking position setting \[ID_24178\]

In the restyled Cube X, the docking position of the sidebar can now be controlled by means of the *User \> Surveyor \> Sidebar docking position* setting.

Default: left

#### System Center: Agent state displayed on Agents page and total number of agents displayed on Agents, Database and Backup pages \[ID_24230\]

In *System Center*,

- the state of every agent in the DataMiner System is now displayed on the *Agents* page, and

- the total number of agents in the DataMiner System is now displayed on the *Agents* page, the *Database* page, and the *Select Agents to back up* window (which appears when you click *Execute backup* on the *Backup* page).

#### Visual Overview: New icons added to DataMiner stencils \[ID_25024\]

The following additional icons are now available in the DataMiner stencils:

- PTP -BC
- PTP-TC
- PTP-Slave
- PTP-GrandMaster

### DMS Reports & Dashboards

#### Reporter: New method that allows sending an email from inside a custom report \[ID_20031\]

Reporter now has a method that allows sending an email from inside a custom report:

```csharp
template.sendEmail(string toAddress, string toFriendly, string fromAddress, string fromFriendly, string subject, string message, bool isHtml);
```

If *fromAddress* is empty, then the email address specified in System Center \> Agents \> System \> System Info will be used.

#### Reporter: Update 'Reservation' to 'Booking' and new booking list template component \[ID_21998\]

In the Reporter app, the term “Reservation” has been replaced by “Booking” to be in line with the rest of the Cube UI. In addition, in the template builder, the “Bookings” component can now be configured to show a list of bookings.

#### New Dashboards app \[ID_19638\]\[ID_20719\]\[ID_20739\]\[ID_21182\]\[ID_21199\]\[ID_21213\]\[ID_21220\] \[ID_21223\]\[ID_21234\]\[ID_21263\]\[ID_21340\]\[ID_21437\]\[ID_21706\]\[ID_21848\]\[ID_21932\]\[ID_21957\] \[ID_22072\]\[ID_22117\]\[ID_22273\]\[ID_22325\]\[ID_22517\]\[ID_22672\]\[ID_22761\]\[ID_22855\]\[ID_22874\] \[ID_23080\] \[ID_23097\]\[ID_23131\]\[ID_23161\]\[ID_23173\]\[ID_23176\]\[ID_23245\]\[ID_23249\]\[ID_23293\] \[ID_23401\]\[ID_23481\]\[ID_23546\]\[ID_23563\]\[ID_23671\] \[ID_23692\]\[ID_23747\]\[ID_23754\]\[ID_23839\] \[ID_24171\]

A completely redesigned Dashboards app is now available. This new app features HTML5 responsive design, with the ability to run across desktops, tablets and mobile platforms. It allows you to create and use interactive dashboards more easily and intuitively.

You can access the app via the link `https://[MyDataMiner]/dashboard` or `http://[MyDataMiner]/dashboard`, depending on your setup. We recommend to use Google Chrome to access the app. Mozilla Firefox and Microsoft Edge are also supported.

The new app consists of the following main areas:

- A header bar with a search box and a user icon. Clicking the user icon opens a menu where you can find user information and app version info, log out, or access the app settings. Via the app settings, you can manage dashboard themes.

- A navigation pane listing all the available dashboards in the system, sorted into folders. The navigation pane has a recent items tab that lists the dashboards you recently used. Via the context menu of the navigation pane, you can copy or move a dashboard, delete or rename a dashboard or dashboard folder, import an example dashboard, add a new dashboard or create a new folder.

- The main area of the app, which displays the currently selected dashboard. If no dashboard is selected, buttons are available that allow you to quickly create a new dashboard, either starting from scratch or from an example, or to open a recently used dashboard. If a dashboard is selected, buttons at the top of the dashboard allow you to refresh the displayed data or go to editing mode.

> [!NOTE]
> If the app is viewed using a mobile device, no options to create or edit dashboards will be available.

##### Creating a new dashboard

To create a new dashboard, you can either start from scratch with a blank dashboard, or modify an example dashboard.

There are several ways to start creating a new blank dashboard:

- On the home page, click *Start with a new blank dashboard*.

- Click the “...” icon in the top-right corner of the navigation pane, and select *New dashboard*.

- Select a folder or dashboard in the list of dashboards on the left and select *New dashboard* in the right-click menu, or click the *New dashboard* button in the header bar.

    Whichever way you choose, a pop-up window will be opened where the name of the dashboard and the folder containing the dashboard can be specified. Once the dashboard has been created, you can start editing it.

To create a dashboard based on an example, you can either first import the example via the context menu of the navigation pane and then edit it, or click *Start with an example dashboard* on the home page of the app.

> [!NOTE]
> The following characters are not allowed in the name of a dashboard or dashboard folder: `/ \ : ; * ? < > | °`

##### Editing a dashboard

If a dashboard is selected in the navigation button, you can enter edit mode by clicking the edit button in the top-right corner. To stop editing, click the button in the same location.

In edit mode, you can adapt the dashboard in the following ways:

- To customize the default dashboard layout, go to the *Layout* tab while no component is selected. In this tab, you can customized the dashboard theme and default component settings, such as the title, borders, etc. You can also a custom theme for later use or load a saved theme.

- To customize the general dashboard settings, go to the *Settings* tab while no component is selected. The settings that can be customized include the dashboard name, WebSocket communication and polling timers.

- To add a new component, see “Adding a component” below.

- To edit a component that has already been added to the dashboard, select the component and configure it in the same way as when you add a new component.

- To duplicate one of the existing components, hover the mouse pointer over the component and click the duplicate icon.

- To remove one of the existing components, hover the mouse pointer over the component, click the recycle bin icon, and click *Yes* to confirm the removal.

- To move a component, hover the mouse pointer over the component, click and hold the move icon, and then drag the component to a different position on the dashboard.

- To resize a component, move the mouse pointer to the edge of the component and drag it until the component has the desired size.

##### Adding a component

There are several ways to add a new component. First you need to indicate where the component should be located. You can do so in the following ways:

- By dragging a visualization from the visualizations pane on the left onto the dashboard.
- By dragging a data feed from the data pane on the right onto the dashboard.

The component then needs to be further configured. As soon as you click on the component or hover the mouse pointer under the component, a quick menu will provide access to quick configuration actions, allowing you to select a visualization or data feed on the fly. This quick menu also allows you to move the component, duplicate the component or delete it.

Once the visualization and data feed(s) have been selected, you can fine-tune the way the component is displayed in the *Layout* and *Settings* panes on the right.

##### Overview of available dashboard components

Currently, the following components can be added to a dashboard.

- General

    | Component     | Description                                                                                                                                                                                       |
    |-----------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Block           | Acts as a divider between other components.                                                                                                                                                       |
    | Clock (analog)  | Shows an analog clock that indicates either the local time or the DataMiner time (i.e. the time of the DataMiner Agent to which you are connected).                                               |
    | Clock (digital) | Shows a digital clock that indicates either the local time or the DataMiner time (i.e. the time of the DataMiner Agent to which you are connected).                                               |
    | Generic map     | Displays a DataMiner map.                                                                                                                                                                         |
    | Group\]         | Displays a group of components. This allows you to display the same set of components for each item in a group feed, for example for each parameter in a group of parameters.                     |
    | Image           | Shows an image. Note: This component not only allows you to select an image that was uploaded earlier, it also allows you to upload new images.                                               |
    | Text            | Shows a block of static text. In the *Layout* tab, you can configure the styling of the text (font, font size, bold, italic, underline, horizontal alignment). |
    | Web             | Displays either a block of static HTML or a web page.                                                                                                                                             |

- States

    | Component | Description                                                                                                                                                                                               |
    |-------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Gauge       | This component displays the value of one or more numeric parameters with a gauge.                                                                                                                         |
    | Ring        | This component displays the name and, if applicable, the value of a DataMiner object within a colored ring matching the state of the object. This can be an element, a view, one or more parameters, etc. |
    | State       | This component displays the state, name and, if applicable, the value of a DataMiner object. This can be an element, a view, one or more parameters, etc.                                                 |

- Tables

    | Component     | Description                                                                                                                                                                                                                      |
    |-----------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Parameter table | Displays a data table of an element, optionally filtered by table indices or using a dynamic table filter.                                                                                                                       |
    | Pivot table     | Displays a status report for a number of parameters of the elements using the selected protocol and protocol version. Via the ... button in the top-right corner of the component, the status report can be exported to CSV. |

- Charts

    | Component            | Description                                                                                                                                                                                                                     |
    |------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Bar chart              | Displays the elements or services in a view that caused the most or the least alarms in a selected time range and were in an alarm state for the longest or the shortest period of time.                                        |
    | Bar chart (horizontal) | Displays the same information as a regular bar chart, but with horizontal bars.                                                                                                                                                 |
    | Line chart             | Displays a trend graph. If graphs are displayed in this component, you can configure grouping by parameter, by element, by table index (if relevant) or by all of the above together. Also, a percentile line can be added. |

- Other

    | Component      | Description                                                                                                                                                                                            |
    |------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Parameter page   | Displays a data page of an element.                                                                                                                                                                    |
    | Trend statistics | Shows the minimum, average and maximum values of one or more trended parameters.                                                                                                                       |
    | Visual overview  | Shows a Visio file linked to an element, a service or a view. Note that if this Visio file contains a shape linked to an Automation script, that script will be executed when you click the shape. |

- Feeds

    | Component | Description                                                                                                                                                                     |
    |-------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | CPE         | Allows the user to make a filter selection for a particular CPE Manager element and CPE chain.                                                                                  |
    | Drop-down   | This feed allows the user to select an item in a drop-down list. The selectable items can be based on any data feed.                                                            |
    | List        | This feed allows the user to select one or more items in a list. The selectable items can be based on any data feed.                                                            |
    | Parameter   | This feed allows the user to select one or more parameters. Default column order: Parameters, Elements, Indices. Note: The element list will load per page of 100 items. |
    | Time range  | This feed allows the user to specify a time range.                                                                                                                              |
    | Tree        | This feed allows the user to select one or more items in a tree view. The selectable items can be based on any data feed.                                                       |

##### Specifying data input in a dashboard URL

If a dashboard has been configured with one or more feed components, it is possible to specify data input for these feeds in a dashboard URL. This way, you can immediately make the dashboard display specific data when it is opened.

Within the dashboard URL, the following objects can be specified:

- Elements (using the argument *elements*): By specifying the DMA ID and element ID.

- Services (using the argument *services*): By specifying the DMA ID and service ID.

- Redundancy groups (using the argument *redundancy groups*): By specifying the DMA ID and redundancy group ID.

- Parameters (using the argument *parameters*):

  - By protocol: By specifying the protocol name, protocol version and protocol ID.

  - By element: By specifying the DMA ID, the element ID, the parameter ID and optionally the parameter index.

- Views (using the argument *views*): By specifying the view ID.

- SLAs (using the argument *slas*): By specifying the DMA ID and element ID.

- DataMiner Agents (using the argument *agents*): By specifying the DMA ID.

- Protocols (using the argument *protocols*): By specifying the protocol name and protocol version.

- Data Display pages:

  - By protocol (using the argument *protocol pages*): By specifying the protocol name, protocol version and page name.

  - By element (using the argument *parameter pages*): By specifying the DMA ID, the element ID and the page name.

- Indices (using the argument *indices*): By specifying the index.

- Timespans (using the argument *time spans*): By specifying the start and end timestamp.

- A CPE filter (using the argument *cpes*): By specifying the DMA ID, the element ID, the field PID, the table PID and the value.

Within one object, use a slash (“/”) as the separator between its components. If different objects of the same type are specified, use “%1D” as the separator between the objects.

For example:

- `http://myDma/Dashboard/#/myDashboard?elements=1/1%1D1/2&views=1&parameters=1/1/1%1D1/1/2/myIndex`

    This URL opens a dashboard in which the elements 1/1 and 1/2, view 1 and parameters 1/1/1 and 1/1/2/myIndex are selected by default.

- `http://myDma/Dashboard/#/myDashboard?time%20spans=1549753200000/1549835265007`

    This URL opens a dashboard with a time range filter from 1549753200000 to 1549835265007.

> [!NOTE]
>
> - If, in the *timespans* argument, you specify “/1531814522191” (i.e. leaving out the first timestamp), this will be interpreted as “from midnight to X”.
> - If, in the *timespans* argument, you specify “1531810522191” (i.e. leaving out the second timestamp), this will be interpreted as “from X to now”.

##### New methods added to Web Services API v1

A number of new methods have been added to the Web Services API v1 to support the new app. This includes the following methods:

- GetActiveAlarmCountForElement
- GetActiveAlarmCountForService
- GetActiveAlarmCountForView
- GetAlarmCountForElement
- GetAlarmCountForService
- GetAlarmStatesForElement
- GetAlarmStatesForParameter
- GetAlarmStatesForService
- GetMonitoredParametersForElement
- GetMonitoredParametersForService
- GetParametersForProtocolFiltered
- GetTrendDataCustomTimespanForParameter
- GetTrendStatisticsForParameter
- GetTrendStatisticsForService
- IsFeatureAvailable

##### Configurable maxJSONLength setting

Up to now, the maxJSONLength setting, which is used when serializing and deserializing WebSocket messages, was always set to 4MiB. This setting is now configurable.

To set maxJSONLength to a specific value, do the following:

1. Open the *Web.config* file located in the *C:\\Skyline DataMiner\\Webpages\\API* folder.

2. Make sure that the *configuration.appSettings* section contains an element similar to the following one:

    ```xml
    <add key="maxJsonLength" value="?10485760?" />
    ```

    Note that the value should be specified in bytes. In the example above, maxJSONLength was set to 10 MiB.

> [!NOTE]
> If no maxJSONLength value is specified in the Web.config file, this setting will be set to 20 MiB by default.

#### Reporter: Accessing parameter values of paused elements \[ID_23829\]

In Reporter, status queries and parameter pages of elements are now able to access the parameter data of elements that are paused.

Example of how to access parameter data of paused elements in a custom report:

```csharp
var iOptions = O_SQ_INC_ELEMENTS_PAUSED;
template.insertStatusQueryBlock(null, null, iOptions);
```

#### Dashboards app: Separator used in CSV exports based on CSV separator setting in Cube \[ID_24161\]

The separator used in CSV exports from the Dashboards app is based on the “CSV separator” setting in Cube. If this setting cannot be retrieved, in Internet Explorer the system will fall back to the Windows regional settings, while other browsers will fall back to the local browser settings.

### DMS Automation

#### .NET Compiler Platform now used for C# Automation scripts \[ID_20746\]

All C# Automation scripts will now be validated and compiled using the .NET Compiler Platform (also known as "Roslyn"), which will enable the use of syntax of C# version 6.0 and higher.

#### New IDPResource and IDPManagerHelper class \[ID_20892\]

A new *IDPResource* and *IDPManagerHelper* class are now available in DMS Automation. The *IDPResource* class defines resources that can be used with an IDP license, and the *IDPManagerHelper* class allows you to manage these resources.

IDP resources can only be created if an IDP license is present. Such a license allows you to add up to 10 IDP resources, as well as to create booking instances and resource pools using IDP resources. The booking instances using IDP resources are not taken into account for the SRM volume license.

#### Radio button lists can now be added to interactive Automation script dialog boxes \[ID_21475\]

It is now possible to add radio button lists to an interactive Automation script dialog box.

First, create the list:

```csharp
UIBlockDefinition blockRadioButtonList = new UIBlockDefinition();
blockRadioButtonList.Type = UIBlockType.RadioButtonList;
```

Then, add buttons to the list:

```csharp
foreach (string sOption in dropDownOptions)
{
    uibDef.AddRadioButtonListOption(sOption);
}
```

> [!NOTE]
> When no initial value is passed to this list, no radio button will be selected by default.

#### Password boxes can now be added to interactive Automation script dialog boxes \[ID_21518\]

It is now possible to add password boxes to an interactive Automation script dialog box.

```csharp
UIBlockDefinition blockPasswordBox = new UIBlockDefinition();
blockPasswordBox.Type = UIBlockType.PasswordBox;
```

Optionally, you can set the HasPeekIcon property to display an icon that, when clicked, will allows you to display the value inside the password box.

```csharp
blockPasswordBox.HasPeekIcon = allowPeek;
```

#### Dialog box of an interactive Automation script can now have a custom title \[ID_21552\]

When defining a dialog box of an interactive Automation script, you can now specify a custom title.

Example:

```csharp
UIBuilder uibDialogBox = new UIBuilder();
uibDialogBox.Title = “My dialog box title”;
```

#### AlarmTemplateHelper \[ID_21878\]

The AlarmTemplateHelper will allow Automation scripts to manipulate alarm templates.

##### Types of methods and calls

The AlarmTemplateHelper contains four types of methods:

- Get (retrieves a row)
- Delete (deletes a row)
- Merge (copies a row to another template)
- Update (updates a row)

Each of the above-mentioned types of methods has three possible calls:

- Retrieve/delete/merge/update a single row on the client (e.g. GetAlarmTemplateRow)
- Retrieve/delete/merge/update multiple rows on the client (e.g. GetAlarmTemplateRows)
- Retrieve/delete/merge/update multiple rows on the DataMiner Agent (e.g. GetAlarmTemplateRowsFromServer)

##### Defining the alarm template and the alarm template rows to be manipulated

Before you send a call, you have to define the alarm template of which you want to retrieve, delete, merge or update rows, and the row(s) to be retrieved, deleted, merged or updated.

- To define the alarm template, you have to create an AlarmTemplateID object with the protocol name, the protocol version and the alarm template name.
- To define the row(s), you have to create one or more AlarmTemplateRowID objects with the parameter ID, the condition name (empty in case of no condition) and the filter (empty in case of no filter).

See the following example:

```csharp
AlarmTemplateHelper helper =new AlarmTemplateHelper(Engine.SLNetRaw.HandleMessages);
var id = new AlarmTemplateID("AlarmTemplate", "Protocol", "1.0.0.0");
var rowId = new AlarmTemplateRowID(1, "condition", "filter");
var rowList = new List<AlarmTemplateRowID> {rowId};
var row = helper.GetAlarmTemplateRowsFromServer(id, rowList);
helper.DeleteAlarmTemplateRowsOnServer(id, row);
```

> [!NOTE]
>
> - A row will be returned as an AlarmTemplateRow object containing the AlarmTemplateRowID, all parameter values (in a GetAlarmTemplateResponseMessage) and the full condition.
> - When a row is deleted, the condition will only be deleted if it is not used by any other parameter.
> - When an existing row is merged, the parameter values will be updated, and the parameter will have the same index in the list.
> - When a new row is merged, it will be added at the bottom of the list.
> - Only parameter rows that are set to “Included” can be extracted and merged.

##### Exceptions

The AlarmTemplateHelper can throw the following exceptions:

| Exception                                   | Cause                                                                                                                                     |
|---------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| ArgumentNullException                       | “null” values were passed to the method.                                                                                                  |
| ConditionDoesNotExistException              | The condition specified in the AlarmTemplateRow could not be found in the alarm template.                                                 |
| ConditionMergeException                     | A condition used in a merge call has the same name as an existing condition with a different content.                                     |
| InvalidAlarmTemplateRowException            | The AlarmTemplateRow contains an ID object that does not match the parameter ID, the parameter filter or the condition in the row object. |
| NoAlarmTemplateRowToUpdateException        | The AlarmTemplateRow to be updated does not exist.                                                                                        |
| ParameterDoesNotExistException              | The parameter specified in the AlarmTemplateRow could not be found.                                                                       |
| RetrievingAlarmTemplateFromServerException | The alarm template could not be retrieved from the server.                                                                                |

> [!IMPORTANT]
> When creating or updating an alarm template row for a table column parameter, also specify the filter (default: “\*”). Setting the filter value to “” or null will prevent alarms from being triggered.

#### Passing information from a subscript to the parent script \[ID_21952\]

In an Automation script, it is now possible to pass information from a subscript to the parent script.

##### Retrieving a dictionary with key/value pairs from a subscript

In the parent script, prepare the subscript using the ScriptOptions object, and start it by running StartScript(). Once the subscript is running, you can then use GetScriptResult() to retrieve information from the subscript and store it in e.g. a dictionary\<string, string>. See the following example.

```csharp
Dictionary<string, string> result = scriptOptions.GetScriptResult();
```

##### Adding key/value pairs to the dictionary before it is passed to the parent script

In a subscript, use the following line to add a key/value pair to the dictionary before it is passed to the parent script.

```csharp
engine.AddScriptOutput("key", "value");
```

#### Service & Resource Management: Adding custom text to a booking block on the timeline \[ID_22068\]

By default, on the booking timeline, booking blocks display the name of the booking. Now, it is also possible to override this default name with custom text using the *Visual.BlockContent* property. See the following example.

```csharp
...
public void Run(Engine engine)
{
    var from = DateTime.UtcNow.Date.AddHours(8);
    var until = DateTime.UtcNow.Date.AddHours(16);
    var reservation =new Skyline.DataMiner.Net.ResourceManager.Objects.ReservationInstance(new TimeRangeUtc(from, until));
    reservation.ID = new Guid("{47CF35C2-C265-447A-A01C-FEF72881C99F}");
    reservation.Status = ReservationStatus.Confirmed;
    reservation.Name = "My First Booking";
    reservation.Properties.Add(new KeyValuePair<string, object>("Visual.BlockContent", "*** custom block text ***\r\nThe time is now " + DateTime.UtcNow));
    var msg = new SetReservationInstanceMessage(reservation);
    engine.SendSLNetSingleResponseMessage(msg);
}
...
```

> [!NOTE]
> The value of the Visual.BlockContent property can be a multiline, but take into account that half of the block height is reserved for displaying subbookings or event markers.

#### Finding an interactive client by user cookie \[ID_22227\]

In Automation scripts and QActions, it is now possible to find an interactive client by user cookie instead of by user name.

General syntax of the FindInteractiveClient method:

```csharp
_engine.FindInteractiveClient(string Message, int timeoutTime, string allowedGroups, AutomationScriptAttachOptions options)
```

Example of how to find a client by user cookie:

```csharp
bool ok =_engine.FindInteractiveClient("Some text", 100, "userCookie:" + connection.ConnectionID, AutomationScriptAttachOptions.None);
```

#### Engine.FindElements can now also be used to find enhanced service elements \[ID_22631\]

It is now possible to use the Engine.FindElements method to find enhanced service elements.

To do so, set the *IncludeServiceElements* option to true and add it to the ElementFilter.

> [!NOTE]
> By default, the *IncludeServiceElements* option is set to false.

#### Element.SetParameter and Element.SetParameterByPrimaryKey methods now allow control of information event generation \[ID_22783\]

Both the *Element.SetParameter* and *Element.SetParameterByPrimaryKey* methods now allow you to add an optional boolean indicating whether an information event should be generated when the parameter is set.

```csharp
void SetParameter(int pid, object value, bool? generateInformation)
void SetParameter(string name, object value, bool? generateInformation)
void SetParameter(int pid, string index, object value, bool? generateInformation)
void SetParameter(string name, string index, object value, bool? generateInformation)
void SetParameterByPrimaryKey(string name, string index, object value, bool? generateInformation)
void SetParameterByPrimaryKey(int pid, string index, object value, bool? generateInformation)
```

> [!NOTE]
> This works as an override for the option *RunTimeFlags.NoInformationEvents* which can be set with the *Engine.SetFlag* method.

#### C# code blocks can now be compiled as separate libraries \[ID_23504\]\[ID_23699\]

When you add an action of type “C# code” to an Automation script, you can now indicate that you want to have this code block compiled as a separate library.

To do so, open the *Advanced* section, and do the following:

1. Select the *Compile as library with name* option, and

1. Enter a valid library name.

   > [!NOTE]
   >
   > - Library names cannot contain periods (“.”).
   > - An Automation script cannot contain multiple libraries with the same name. Library names must be unique within a particular Automation script.

Once you have compiled a C# code block as a library, you can then import that library into other Automation scripts. To do so, in the *Advanced* section of a C# code block of a given Automation script, do the following:

- In the *Script references* box, enter a reference to the library that you want to import.

  > [!NOTE]
  >
  > - A reference to a library has to contain the script name and the library name, separated by a colon: *ScriptName:LibraryName*
  > - In the above-mentioned two-part reference, the ScriptName part can be replaced by the \[AutomationScriptName\] placeholder, which will be resolved to the name of the script in which the library is defined.

> [!NOTE]
>
> - To optimize performance and use of resources, it is advised to create each library in a separate Automation script. This will minimize the amount of recompilations and DLL generations.
> - When you recompile a library, all Automation scripts and libraries that use that library will also be recompiled.
> - The order of the C# blocks in an Automation script will define the order in which the libraries will be compiled.
> - When you delete an Automation script that contains a library, all files belonging to that library will also be deleted. As a result, you will not be able to recompile any of the depending scripts until you add the deleted library again (with the same script name and library name).
> - When you delete a library C# block from an Automation script and then save the script, the DLL of that deleted library will not be deleted. The DLL file and all references to that deleted library should be removed manually.
> - When you compile a library, its DLL file (and, if compiled in debug mode, its PDB and CS files) are stored in *C:\\Skyline DataMiner\\Scripts\\Libraries*. When the first Automation-related action (i.e. creating, editing or deleting an Automation script, or validating a C# code block) is performed after a DataMiner restart, this folder is cleaned up. After cleaning, of each library it will only contain the most recent version.

#### Interactive Automation scripts: Uploading files from a client computer \[ID_23950\]\[ID_24144\]\[ID_24164\]

In an interactive Automation script, it is now possible to upload files from a client computer.

To allow users to do so, you need to add a file selector control to the script in the following manner:

```csharp
UIBlockDefinition uiBlock = new UIBlockDefinition();
uiBlock.Type = UIBlockType.FileSelector;
uiBlock.DestVar = "varUserUploadedFile";
```

When the UI is then shown using *Engine#ShowUI(...)*, *UIResults* will contain the path to the file:

```csharp
UIResults results = engine.ShowUI(uiBuilder);
string uploadedFilePath = results.GetUploadedFilePath("varUserUploadedFile");
```

When you have selected a file, the actual upload will only start after you click a button to make the script continue (e.g. Close, Next, etc.). Once the upload has started, a *Cancel* option will appear, allowing you to abort the upload operation.

All files uploaded by users will by default be placed in the *C:\\Skyline DataMiner\\TempDocuments* folder, which is automatically cleared at every DataMiner startup.

#### New engine.UnSetFlag method to clear run-time flags \[ID_23961\]

In an Automation script, you can now use the engine.UnSetFlag method to clear the following run-time flags:

- RunTimeFlags.AllowUndef
- RunTimeFlags.NoInformationEvents
- RunTimeFlags.NoKeyCaching

This will allow you to, for instance, perform silent parameter sets. See the following example:

```csharp
public void SetParameterSilent(int pid, object value) {
    // Set the NoInformationEvents flag to disable information events
    _engine.SetFlag(RunTimeFlags.NoInformationEvents);
    // Perform a silent parameter set without triggering an information event
    element.SetParameter(pid, value);
    // Re-enable information events by clearing the NoInformationEvents flag
    _engine.UnSetFlag(RunTimeFlags.NoInformationEvents);
}
```

### DMS Correlation

#### Support for 'elementdesc' placeholder in notifications sent as a result of some triggered correlation rule \[ID_22105\]

When defining a notification message template in the *NotifyTemplates.xml* file, you can use a number of placeholders.

From now on, the “elementdesc” placeholder (i.e. element description) can also be used in templates for notification messages sent as a result of some triggered Correlation rule. Up to now, it could only be used in templates for notification messages that are sent independently (not as a result of some triggered correlation rule).

#### New event to trigger Correlation rules at DataMiner startup \[ID_22622\]

At DataMiner startup, a new event will now signal when the Correlation engine is up and running. This event will make it possible to trigger correlation rules at DataMiner startup.

Event properties:

- Element Name: DMANAME
- Parameter Description: Correlation engine (DataMiner Element Control Protocol)
- Value: Started

### DMS Maps

#### Service & Resource Management: Markers for multiple individual elements and elements in services \[ID_21800\]

A map layer that has its sourceType set to “objects”, can display markers for any type of DataMiner object and can retrieve marker data from parameters and/or properties.

Currently, only markers for elements and service elements are supported, but, in the future, markers for services, CPE objects and enhanced views will also be supported.

In the \<ObjectsSourceInfo> tag of an “objects” layer, you can configure a collection of sources:

- \<Element> for individual elements
- \<ServiceChildren> for service child objects (currently only elements and services elements)

##### Attributes for \<Element>

| Attribute | Description |
|--|--|
| id | Element name or element ID (dmaId/elementId) |
| idVar | Name of a variable that can be provided in the Maps URL, which will then be used as a dynamic ID. Example: idVar="MyElement" will resolve the ID with the URL parameter dMyElement. |

##### Attributes for \<ServiceChildren>

| Attribute | Description |
|--|--|
| id | Service name or service ID (dmaId/serviceId) |
| idVar | Name of a variable that can be provided in the Maps URL, which will then be used as a dynamic ID. Example: idVar="MyService" will resolve the ID with the URL parameter dMyService. |
| recursive | If true, elements of child services will be included. Note: Using recursive="true" will also allow you to show markers from contributing services. If the service contains an enhanced service element (or an associated DVE), children of that enhanced service will be included as well. |

##### Subtags of \<Element> and \<ServiceChildren>

| Tag          | Description                                                  |
|--------------|--------------------------------------------------------------|
| \<Latitude>  | Latitude coordinate (required)                               |
| \<Longitude> | Longitude coordinate (required)                              |
| \<Title>     | Marker title (optional, uses the DMA object name by default) |

Any of the above-mentioned subtags can contain raw text, a name of a property or a parameter ID (with optional table index). See the following examples:

- \<Latitude>12.34\</Latitude>
- \<Longitude>\<Property>MyLongitudeProperty\</Property>\</Longitude>
- \<Title>\<Parameter>\<ID>123\</ID>\<Index>MyTableIndex\</Index>\</Parameter>\</Title>

#### Visualizing DCF connections as lines between markers \[ID_21923\]

Map layers can now visualize DCF connections as lines between markers.

To have DCF connections displayed as lines between markers, do the following:

1. Create a new \<Layer>, and set its sourceType attribute to “connectivity”.

1. To this new layer, add a \<LayerSourceInfo> tag in which you specify the name of the layer that contains the objects of which you want the connections to be visualized.

    > [!NOTE]
    >
    > - The sourceType attribute of the layer specified in the \<LayerSourceInfo> tag has to be set to “objects”.
    > - The style of the connections can be configured in a \<LineOptions> tag.
    > - If you want to show a DCF connection property in the \<PopupSkeleton> template, then add a \<Detail> tag inside the \<PopupDetails> tag, and set its *type* attribute to “property” and its *property* attribute to the correct connection property name.

> [!NOTE]
> In order to be displayed consistently, DCF connections and DCF properties need to be defined on both source and destination elements.

#### Enhanced service parameters can now be specified in \<Detail> tags \[ID_22009\]

In a service context, it is now possible to specify parameters of enhanced services in \<Detail> tags inside \<PopupDetails> or \<MarkerDetails> tags.

The detail placeholders can then be used in \<PopupSkeleton> or \<MarkerImage> tags respectively.

Examples:

```xml
<Detail name="MyVariable" type="parameter" pid="12345" idx="MyDisplayKey" />
```

```xml
<Detail name="MyVariable" type="marker/parameter" pid="12345" idx="MyDisplayKey" />
```

```xml
<Detail name="MyVariable" type="service/parameter" service="MyService" pid="12345" idx="MyDisplayKey" />
```

### DMS CPE Management

#### Enhanced views \[ID_19316\]\[ID_21944\]

The new “enhanced view” feature allows an element to become part of a view. This means that the alarm state of an element included in a view will now influence the alarm state of that view.

See also: [New properties added to the ViewStateEventMessage \[ID_21375\]\[ID_21547\]](#new-properties-added-to-the-viewstateeventmessage-id_21375id_21547)

> [!NOTE]
> When a view was enhanced with an element, the alarms associated with that element will have the view specified in their “View impact” column.

#### CPE Manager: Dummy items in CPE diagram and filters can now be hidden \[ID_19658\]

CPE tables often contain dummy items, i.e. virtual items that merely act as a link between two actual items. From now on, it is possible to hide these dummy items in CPE diagrams and CPE filters.

To be able to mark items as dummy items in a particular CPE table, add an extra column of type “double”, and specify the “CPEDummyColumn” option in its column definition. See the following example:

```xml
<ArrayOptions index="0" displayColumn="1">
  ...
  <ColumnOption idx="9" pid="1616" type="retrieved" options=";save;disableHeaderSum;CPEDummyColumn"/>
  ...
</ArrayOptions>
```

When, in DataMiner Cube, you now want to mark an item as a dummy item in that table, then go to the row that represents the item, and add “1” in the column defined as “CPEDummyColumn”.

> [!NOTE]
>
> - Items marked as dummy items will not be displayed in CPE diagrams nor in CPE filters, unless selected from a direct filter.
> - Parents of a dummy item will be linked to its children, and children of a dummy item will be linked to its parents.
> - There can only be one dummy item per topology level. For example, a street cannot have two parents “Dummy1” and “Dummy2”. These two dummy items must be combined into one.

#### CPE Manager: Right-click menu now allows you to copy values from a diagram node and a KPI list \[ID_20541\]

In a CPE environment, right-click menus now allow you to copy certain values:

- When you right-click a diagram node, you can copy the title of the node as well as the values displayed on the node.
- When you right-click a value in a KPI list, you can copy that specific value.

#### CPE Manager: Masking nodes in CPE diagrams \[ID_20653\]\[ID_24010\]

It is now possible to mask nodes in CPE diagrams. To mask a node, right-click it, and select “Mask”.

However, note that it is only possible to mask a node for a limited period of time or until unmasked. The option to mask until the alarm is cleared, which is available for other DataMiner objects, is not available for CPE objects.

#### CPE Manager: New 'skipInDiagram' option to skip level in CPE diagram \[ID_20893\]

It is now possible to configure a chain in a CPE protocol so that a level is skipped in the CPE diagram. To do so, add the option "skipInDiagram" in the relevant "Field" tag in the chain.

The level linked to this field will then not be displayed in the diagram, unless the currently selected object is actually of that level.

Example:

```xml
<Chains>
   ...
   <Chain name="Example Hide Room/Rack">
      <Field name="Location" options="MaxDiagramsOnRow:3;ShowCPEChilds;details:1000-KPI|1500;displayInFilter;tabs:1000-KPI|1500|1600" pid="1002">
         <DiagramTitleFormat>{rowDK} (temp:{pid:1004})</DiagramTitleFormat>
         <DiagramPids>1004,1006</DiagramPids>
     </Field>
     <Field name="Room" options="SkipInDiagram;DiagramSort:1506|DESC:1;ShowCPEChilds;details:1500-KPI|1600;displayInFilter;KPIsInDiagram:{rowDK}\nCode: {pid:1504}, Temperature: {pid:1506}\nRoomAVGDeviceTemp:{pid:1506}" pid="1502">
         <DiagramTitleFormat>{rowDK} ({pid:1506}°C)</DiagramTitleFormat>
         <DiagramPids>1504,1506</DiagramPids>
         <DiagramSorting>1506|DESC</DiagramSorting>
     </Field>
     <Field name="Rack" options="SkipInDiagram;ShowCPEChilds;details:1600-KPI|1700|1900;detailTabs:1700-SeverityColumn-ListKPIHide;displayInFilter;tabs:1600-KPI|1700|1900;ShowBubbleupAndInstanceAlarmLevel" pid="1602"/>
     <Field name="Device-TileList" options="detailTabs:1700-KPI-SeverityColumn-ListKPIHide,1800;ShowCPEChilds;displayInFilter;tabs:1700-KPI|1800|14,14,1800;TabOrder:2,1,0;TileList;ShowBubbleupAndInstanceAlarmLevel;KPIsInDiagram:Online:\t{pid:1710}\nOffline:\t {pid:1714}" pid="1704"/>
   </Chain>
   ...
</Chains>
```

> [!NOTE]
> If you configure the filter of a field to not be displayed (i.e. you leave out the "displayInFilter" option), the "showTree" option is required, as otherwise the diagram would immediately stop at the level corresponding to this field. In that case, depending on whether the "skipInDiagram" option is specified, the diagram will either be shown as if the filter was displayed, or shown without this particular level.

#### New CPECollectorHelper function to retrieve table rows that are linked via topology \[ID_21101\]\[ID_21122\]\[ID_21206\]\[ID_21465\]\[ID_21746\]

The following CPECollectorHelper function allows client apps to retrieve table rows that are linked via topology:

- GetLinkedDMAObjectRefGroupsThroughTopology

Note that this function requires that, in the protocols of the CPE collector elements, the Topology.Cell tags map to names of table cells on the CPE Manager elements that have to be polled, and that each of those Topology.Cell tags also contains an Exposer tag.

In the example below, the “Amplifier” cell has been exposed to the CPE crawler, which will retrieve the data. This means, that table 500 can be searched using the above-mentioned function.

Also note that, inside the Exposer element, you can add linked tables. In the example below, table 1000 is linked to table 500 using column parameter ID 1001.

Example:

```xml
<Topologies>
  <Topology>
    <Cell name="Amplifier" table="500">
      <Exposer enabled="true">
        <LinkedIds>
          <LinkedId columnPid="1001">1000</LinkedId>
        </LinkedIds>
      </Exposer>
    </Cell>
  </Topology>
</Topologies>
```

A typical CPE environment usually contains one front-end manager element and multiple back-end manager elements. All those elements, which contain the same CPE topology and refer to the same data in the background, will by default be polled by the CPE crawler.

To force the CPE crawler to only poll the front-end manager element, indicate which of the manager elements is the front-end manager. You can do this by adding to it a parameter of type “double” named “ElementManagerType”, and set its value to “1”.

> [!NOTE]
>
> - The LinkedId@columnPid attribute is only required when the tables have no foreign key linking to each other.
> - If a protocol contains at least one Protocol.Topologies.Topology.Cell element, two properties will be created on the DataMiner Agent: “System Type” and “System Name”. Alarms generated in tables defined in Cell@table attributes will have their “System Type” property set to the value of the Cell@name attribute and their “System Name” property set to the row's display key.
>   - If an exposer is defined with a LinkedId, it will receive the same property values. The “System Name” property will be set to the display key of the table defined in Cell@table as resolved by the foreign key relations. If no link can be resolved, then the display key of the original row will be used.
>   - If a LinkedId element has a columnPid attribute containing a column parameter ID in the LinkedId table, then the alarm's “System Name” property will be set to the value found in the specified column.
> - If the topology contains view tables instead of physical tables, then the above-mentioned alarm properties will also be filled in. However, note that, if view tables are used, secondary tables are currently not able to retrieve display keys of primary tables.
> - This feature will only work with Protocol.Topologies.Topology elements, not with legacy Protocol.Topology elements.

#### New properties added to the ViewStateEventMessage \[ID_21375\]\[ID_21547\]

The following new alarm level properties have been added to the view state:

| Property                       | Description                                                                                                                                                                                                                                                                                                                                                                       |
|--------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| DirectEnhancedLatchLevel       | Latch level of the enhanced element linked to the view.                                                                                                                                                                                                                                                                                                                           |
| DirectEnhancedRawLevel         | Alarm level of the enhanced element linked to the view.                                                                                                                                                                                                                                                                                                                           |
| DirectEnhancedTimeout          | Timeout state of the enhanced element linked to the view.                                                                                                                                                                                                                                                                                                                         |
| DirectSystemObjectLevel        | Alarm level of the “system object”, without objects below it. The system object contains the view, the enhancing element and all rows linked to the view via viewImpact.                                                                                                                                                                                                      |
| DirectViewImpactsBubbleupLevel | Bubble-up alarm level of the rows linked to the view via viewImpact.                                                                                                                                                                                                                                                                                                              |
| DirectViewImpactsLevel         | Instance alarm level of the rows linked to the view via viewImpact.                                                                                                                                                                                                                                                                                                               |
| EnhancedLatchLevel             | The most severe state of the DirectEnhancedLatchLevel and SubEnhancedLatchLevel.                                                                                                                                                                                                                                                                                                 |
| EnhancedRawLevel               | The most severe state of the DirectEnhancedRawLevel and SubEnhancedRawLevel.                                                                                                                                                                                                                                                                                                     |
| EnhancedTimeout                | The most severe state of the DirectEnhancedTimeout and SubEnhancedTimeout.                                                                                                                                                                                                                                                                                                       |
| SubEnhancedLatchlevel          | Latch level of the enhanced element linked to the subviews.                                                                                                                                                                                                                                                                                                                       |
| SubEnhancedRawLevel            | Alarm level of the enhanced element linked to the subviews.                                                                                                                                                                                                                                                                                                                       |
| SubEnhancedTimeout             | Timeout state of the enhanced element linked to the subviews.                                                                                                                                                                                                                                                                                                                     |
| SubSystemObjectLevel           | Alarm level of the items below the “system object”. The system object contains the view, the enhancing element and all rows linked to the view via viewImpact. The items below the system object are the items in the view and the subviews, the aggregation rules of the subviews, the enhancing elements of the subviews and the bubble-up alarm levels of the linked rows. |
| SystemObjectLevel              | Alarm level of the “system object” and the objects below it.                                                                                                                                                                                                                                                                                                                      |

> [!NOTE]
> The EnhancedExtraLevel property has been removed.

#### CPE tables can now have a ViewImpact column \[ID_21401\]

It is now possible to add a “view impact” column to a CPE table (by specifying the “ViewImpact” option in its column definition). In each of the table rows, the “view impact” column can then contain the IDs of the views that are impacted by that particular row.

- The highest alarm among all rows that impact a particular view will be copied to the DirectViewImpactsLevel property of the ViewStateEventMessage class.
- The bubble-up level will be copied to the DirectViewImpactsBubbleupLevel property of the ViewStateEventMessage class.

#### DataMiner Cube: A chain can now have several list tabs displaying the same data but with a different filter \[ID_21704\]

A chain can now have several list tabs displaying the same data but with a different filter.

#### CPECollector API: New methods \[ID_21755\]

The following methods have been added to the CPECollector API:

`GetMaskedDMAObjectRefTrees(FilterElement<IDMAObjectRef>)`

This method returns all masked object trees that match the specified filter. If no filter is passed, then all masked object trees are returned.

In the following example, a filter is passed to check whether the view with ID 2 is masked.

```csharp
var managedFilter = new ManagedFilter<DMAObjectRefTree,IDMAObjectRef> (DMAObjectRefTreeExposers.Data,Comparer.Equals,new ViewID(2),null);
```

**GetMaskedDMAObjectRefTrees(managedFilter);**

This method returns mask operations stored in the transaction store (i.e. masking of topology data or views).

#### Topology cells configured on a direct view table will now provision 'System Type' and 'System Name' properties on alarms originating from the source table \[ID_22238\]

If a topology cell is configured as in the example below, and the specified table is a direct view showing data from a source table that has monitoring enabled, then the alarms originating from that source table will now have their “System Type” and “System Name” properties provisioned with the cell name (in the example below: “Amplifier”) and the row key of the source table.

```xml
<Topologies>
  <Topology>
    <Cell name="Amplifier" table="4200"/>
  </Topology>
</Topologies>
```

#### New general parameters: \[Alarm System Type\] and \[Alarm System Name\] \[ID_22632\]

Two new general parameters have been added:

- \[Alarm System Type\]
- \[Alarm System Name\]

When no topology cell is defined for a monitored parameter, then the values of the alarm properties “System Type” and “System Name” will be set to the values found in the above-mentioned general parameters.

> [!NOTE]
>
> - When no alarm properties named “System Name” and “System Type” exist within the DataMiner System, they will not be created. Only creating an element with a topology cell definition will cause these alarm properties to be created.
> - Updating these general parameters will not cause the values defined by a topology cell definition to be overwritten.
> - Updating these general parameters will trigger a “Property Changed” update on the active alarms of the element, even on alarms relying on the topology cell definition in the protocol rather than these general parameters.
> - As to these two new general parameters, DVE elements will not inherit the values of the main element. Alarms on values exported to a DVE element will only use the values of the general parameters of that particular DVE element.
> - When using virtual functions, an alarm is linked to the main element instead of to the virtual function (i.e. the virtual element). This means that alarms will inherit the \[Alarm System Type\] and \[Alarm System Name\] parameters of the main element. Currently, the \[Alarm System Type\] and \[Alarm System Name\] parameters of virtual functions are not yet being used.

### DMS Web Services

#### Web Services API v1: New method 'GetDocuments' \[ID_19348\]

The method *GetDocuments* has been added to the Web Services API v1. This method makes it possible to retrieve a list of general and protocol documents from within a particular documents folder.

#### Web Services API v1: New method 'GetTrendDataForTableParameter' \[ID_19532\]

The method *GetTrendDataForTableParameter* has been added to the Web Services API v1. This method makes it possible to retrieve trend data for a parameter by primary key within a custom timespan.

#### Web Services API v1: New method 'GetAlarmPageWithAlarms' \[ID_19540\]

The method *GetAlarmPageWithAlarms* has been added to the Web Services API v1. This method combines the functionality of the *GetAlarmPage* and *GetAlarms* methods, so that the actual alarms only need to be fetched once.

#### Web Services API v1: Response of GetAggregationQueryResultAsync method now also includes the sublevel aggregation \[ID_20330\]

From now on, the response of the *GetAggregationQueryResultAsync* method will also include the sublevel aggregation.

#### Job Manager API: Job template management methods \[ID_21380\]\[ID_23055\]

The Job Manager app now allows you to use job templates. Those templates can be managed using either the app’s HTML5 user interface or the following API methods:

- JobHelper.JobTemplates.Create(JobTemplate)
- JobHelper.JobTemplates.Update(JobTemplate)
- JobHelper.JobTemplates.Delete(JobTemplate)
- JobHelper.JobTemplates.Read(FilterElement\<JobTemplate>)

Errors that can be returned in TraceData:

- ManagerStoreError.Reason.Unknown

    *A general exception occurred. Something went very wrong. Check logging and \<see cref="Message"/>.*

- ManagerStoreError.Reason.ModuleNotInitialized

    *The module to which the request was sent was not yet fully initialized.*

- ManagerStoreError.Reason.ObjectAlreadyExisted

    *During a create request the given object already existed.*

- ManagerStoreError.Reason.ObjectDidNotExist

    *During an update request, the object did not already exist (and thus can't be updated).*

- ManagerStoreError.Reason.NoPermission

    *The current user does not have permission to complete the action.*

#### Job Manager API: Enhancements \[ID_21683\]

A number of enhancements have been made to the Job Manager API.

##### ReservationFieldDescriptor

A new type of job field has been added, which will contain GUIDs of ReservationInstances.

##### ReservationLinkInfo

The ReservationLinkInfo property of a SectionDefinition can now contain additional information about how bookings are linked.

The client will use

- the BookingElementID property to determine the “virtual platform” to which the booking belongs, and
- the CreateBookingScript to convert the jobs to bookings.

##### Update restrictions

The BookingElementID of a SectionDefinition cannot be updated once there are jobs for that SectionDefinition. Trying to do so will cause a SectionDefinitionError.Reason.SectionDefinitionInUseByJobs to be returned in the TraceData.

The CreateBookingScript of a SectionDefinition can be updated at any time.

##### Hidden SectionDefinitions

A CustomSectionDefinitions now has an IsHidden property (default value: false).

The hidden SectionDefinitions will be ignored when applying a job template.

##### ApplyTemplate changes

When a job template is applied, the default section will be ignored. In other words, the name and the start and end values will not be changed when a job template is applied.

When a job template is applied, both the target job and the JobTemplate#TemplateData job should be stitched.

#### Ticketing API: Removing a masked TicketFieldResolver and all linked tickets \[ID_22403\]

It is now possible to remove a masked TicketFieldResolver along with all linked tickets.

To do so, call the TicketingGatewayHelper method RemoveMaskedTicketFieldResolver, in which you pass the ID of the TicketFieldResolver to be removed.

An error will be returned in the following cases:

- If the TicketFieldResolver does not exist.
- If the TicketFieldResolver is not masked.
- If the user has not been granted the “Ticketing Gateway/Configure” permission.
- If something went wrong while deleting the TicketFieldResolver or any of the linked tickets.

#### WebSockets input buffer can now expand automatically \[ID_22931\]

Up to now, the WebSockets input buffer had a fixed size of 1024 bytes. Now, this input buffer will be able to automatically expand when receiving messages larger than 1024 bytes.

When a message is received that does not fit the buffer (which, by default, has a size of 1024 bytes), the buffer will automatically expand by another 1024 bytes.

> [!NOTE]
>
> - The size of the input buffer will not be decreased automatically. Once the input buffer has expanded, it will keep that size.
> - Maximum input buffer size: 1 MB

#### Web Services API v1: 'GetTableForParameterV2' method has new 'as-kpi' table filter option \[ID_23928\]

The GetTableForParameterV2 method now supports filtering based on the following table column KPI options:

- KPIHideWrite
- HideKPI
- HideKPIWhenNotInitialized
- KPIShowDisplayKey
- KPIShowPrimaryKey
- DisableHistogram

To enable KPI option filtering when calling the *GetTableForParameterV2* method, specify the “as-kpi” filter in the *Filters* input field.

### DMS Mobile apps

#### Monitoring & Control app: Contacts list \[ID_21560\]\[ID_22754\]

In the Monitoring & Control app, you can now view the list of users who are currently logged on to the DataMiner System.

To open the contacts list, click the user icon in the top-right corner of the screen and select *Contacts*.

For each user, the list displays the name of the user, the name of the computer, and the amount of active connections. Clicking a user in the list will open a details pane showing more information about that user (e.g. “\[APP\] online since \[Connect time\]”).

> [!NOTE]
>
> - If available, the name of the application shown in the details pane (“\[APP\]”) will be a user-friendly description of the application that person is using to connect to the DMS.
> - Only users who have been granted the “General \> Collaboration \> UI available” permission are able to access the Contacts list.

#### New Monitoring & Control app \[ID_21736\]\[ID_22023\]\[ID_22209\]\[ID_22750\]\[ID_22801\]\[ID_22888\] \[ID_22943\]\[ID_23025\]\[ID_23036\]\[ID_23090\]\[ID_23387\]\[ID_23798\]\[ID_23874\]\[ID_24017\]\[ID_24059\] \[ID_24072\]\[ID_24080\]\[ID_24114\]\[ID_24134\]\[ID_24180\]\[ID_24192\]

The DataMiner HTML5 app has now been replaced by the new Monitoring & Control app, of which the overall look and feels closely resembles that of the newly redesigned Cube X.

- Redesigned header bar:

  - The app title is now a button that redirects the user to the app’s homepage.
  - Like in Cube X, the Search box has now been moved from the side panel to the middle of the header bar.
  - On the right, there is now one single user icon, which, when clicked, opens a menu that allows users to access to the settings window and the About box.

    Currently, the settings window allows you to specify the default pages for element and view cards.

- A new homepage similar to the Cube X homepage, listing recently used items.
- Redesigned (collapsible) side panel, on which alarm states are now indicated by colored circles.
- Redesigned element, service, view and alarm cards, which can be accessed directly using the following URLs:

  - `http://<DMAIP>/monitoring/element/<DMAID>/<EID>/data/<PAGENAME>`
  - `http://<DMAIP>/monitoring/element/<DMAID>/<EID>/visual/<PAGENAME>`
  - `http://<DMAIP>/monitoring/element/<DMAID>/<EID>/chain/<CHAINNAME>`
  - `http://<DMAIP>/monitoring/view/<VIEWID>/<PAGENAME>`
  - `http://<DMAIP>/monitoring/view/<VIEWID>/visual/<PAGENAME>`
  - `http://<DMAIP>/monitoring/alarm/<DMAID>/<ALARMID>`

> [!NOTE]
> To open this new Monitoring & Control app from the address bar of your internet browser, enter the IP address of the DataMiner Agent, followed by “/monitoring”.
>
> Alternatively, you can go to the landing page of the DataMiner Agent (by entering its IP address), and then click the *Monitoring & Control* button.

#### Mobile DataMiner apps can now be added to a device’s home screen and be used as an app \[ID_21754\]

The mobile DataMiner apps can now be added to a mobile device’s home screen and be used as an app. This will allow users to use those apps in full-screen mode.

#### Default time zone can now be specified in ClientSettings.json \[ID_22762\]

Time notations displayed in DataMiner mobile apps will now all be based on the time zone specified in the following setting, located in the *C:\\Skyline DataMiner\\Users\\ClientSettings.json* file:

- commonServer.ui.DefaultTimeZone

#### Ticketing app: Concatenation of alarm fields and static text in ticket fields \[ID_23894\]

It is now possible to combine multiple alarm fields and static text in a ticket field. When you have added an alarm field in the field configuration, you can now click *Add concatenation* to add an additional alarm field or static text. You can do so several times to combine multiple alarm fields and/or static text fields in one field. When a ticket is generated based on an alarm, the concatenated fields will be combined into a single string.

#### Legacy Monitoring & Control app: New settings to specify the default page for element, service and view cards \[ID_24017\]

In the *Settings* window of the legacy Monitoring & Control app, it is now possible to specify the default pages for element, service and view cards.

#### Jobs app: UI adapted to new DataMiner X style \[ID_24157\]

The header and login screen of the Jobs app have now been adapted to the new DataMiner X style.

#### New DataMiner landing page \[ID_24239\]\[ID_25017\]

When you open a browser window and enter the IP address or host name of a DataMiner Agent, you are now directed to a new DataMiner landing page (“/root”).

After signing in, you will be presented with a list of apps (e.g. Monitoring, Dashboards, etc.), and a drop-down menu on the right will allow you to install the DataMiner Cube desktop application using either a click-once web installer or an MSI installer.

Clicking the user menu in the upper-right corner will allow you to open the Tools page, the About page and DataMiner Help.

### DMS Service & Resource Management

#### New methods related to function definitions in ProtocolFunctionHelper class \[ID_19405\] \[ID_19571\]

The following new methods are now available in the *ProtocolFunctionHelper* class:

| Method                                  | Description                                                                                                                                                                                                                                                    |
|-----------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ReplaceActiveSystemFunctionDefinitions | Replaces all the current active function definitions with a specified set of new ones. It returns the function definitions that are active after this replacement is executed. The old function definitions are placed in the recycle bin folder of DataMiner. |
| GetSystemFunctionDefinitions            | Returns the currently active function definitions.                                                                                                                                                                                                             |
| GetFunctionDefinition                   | Retrieves function definition objects by ID.                                                                                                                                                                                                                   |

#### Service & Resource Management: Possibility to generate protocols and function definitions based on service definitions and enhanced services based on reservations \[ID_19330\]\[ID_19359\]\[ID_19385\]\[ID_19386\]\[ID_19415\]\[ID_19431\]\[ID_19450\] \[ID_19491\]\[ID_19498\]\[ID_19556\]\[ID_19632\]\[ID_19789\]\[ID_23201\]

It is now possible to generate an enhanced service protocol based on a service definition. The enhanced service will detect changes in the resource usage of the service booking instance and reconfigure the dynamic replication accordingly.

For this enhanced service protocol, a function definition can be generated, which can be used to create a function resource at runtime. It is possible to specify a parent system function definition with interfaces of its own and the necessary connections, which will then be applied to the generated function definition.

In addition, a specific protocol and protocol version can be defined for a service booking instance, which will cause an enhanced service to be created instead of a normal service when a booking is created. A specific element ID can be preconfigured in the service booking instance, so that the enhanced service will use this ID. It is also possible to apply an alarm template to the enhanced service for alarm monitoring.

A generated protocol can be configured to have parameter groups, and the interfaces of a generated function can be configured to link to these parameter groups.

The new method *GetSrmGeneratedProtocolFunctionsInfo* in the *ProtocolFunctionHelper* class makes it possible to retrieve information on the generated protocols and functions.

Information on the protocols generated via SRM is also synchronized throughout the DMS.

#### Service & Resource Management: New EnhancedServiceElementID property for service booking definitions \[ID_19942\]

Service booking definitions now have an *EnhancedServiceElementID* property. If this property is filled in with a particular element ID, this ID will be copied to every service booking instance for that definition, so that these instances can use that ID to create the corresponding enhanced service. This allows trending of the enhanced services to be available for the same element for each occurrence of the booking definition.

If no ID is filled in for the new property, the server will automatically provide one.

#### DataMiner Cube: New 'Migrate booking data to Indexing Engine' wizard \[ID_21935\]\[ID_23674\] \[ID_24410\]\[ID_24424\]

In DataMiner Cube, a new wizard has been added to the *Search & Indexing* section of *System Center*. This wizard allows you to migrate booking data from the Cassandra database to the Indexing database.

As some booking property names can contain characters that are considered invalid by the Indexing engine, the wizard will ask you to rename certain booking properties before starting the migration. To ensure the correct functionality of the Service & Resource Management module, some properties will be renamed automatically. For example, the *Visual.Background* and *Visual.Foreground* properties will automatically be renamed as *VisualBackground* and *VisualForeground*.

When you have successfully migrated all booking data, the button to start the wizard will disappear from the UI. Also, when the migration has finished, a *Retrieve report* button will allow you to generate a report showing a summary of that migration.

> [!NOTE]
>
> - After migrating the booking data to the Indexing database, make sure to check your Automation scripts and Visio files and adjust the booking property names where necessary.
> - When configuring backup settings in the *Backup* section of *System Center*, a new *Include SRM in backup* option is now available under the *Create a backup of the database* option. Select this option if you want the booking data in the Indexing database to be included in the backup package.
> - An Indexing database takes about twice as much disk space to store booking data compared to a Cassandra database.
> - A number of methods in the *ServiceManagerHelper* and *ResourceManagerHelper* classes have been adapted to allow them to manage booking data stored in an Indexing database.

#### Services app: New 'Services' tab \[ID_20459\]\[ID_20962\]\[ID_21203\]\[ID_23460\]\[ID_23785\]

In the *Services* app, the *Recent* and *All* tabs have now been grouped into a *Definitions* tab, and a new *Services* tab has been added.

When you open the new *Services* tab, it lists all services in a dynamic, filterable list view with a default set of columns. Apart from this default column set, it is also possible to create additional, customized column sets, called column configurations.

##### Loading a column configuration

- Right-click in the list header (or click the list’s hamburger menu), select *Load column configuration*, and select the configuration you want to load.

##### Creating a new column configuration

1. Right-click in the list header (or click the list’s hamburger menu), select *Save column configuration as...*, enter the name of the new configuration, and click *OK*.
1. Right-click in the list header (or click the list’s hamburger menu), select *Load column configuration*, and select the configuration you created in step 1.
1. Right-click in the list header, and do the following:

    - add or remove column,

    - change the text alignment inside columns, and

    - rename columns.

    > [!NOTE]
    > When you click *Add/remove column*, you can also select *More*.  This will open a *Choose details* window that will allow you to show/hide columns, move columns up/down, etc. See below for more information.

1. Right-click in the list header (or click the list’s hamburger menu), select *Save current column configuration*.

##### Configuring columns using the Choose details window

When you right-click the list header, and select *Add/remove column \> More*, the *Choose details* window opens. In that window, you can do the following:

- Show or hide a column by selecting or clearing its checkbox, or by clicking *Show* or *Hide*.
- Move a column up or down by clicking *Move up* or *Move down*.
- Set the column type of a column (which, by default, is set to “Text”):

  - Set the column type of a column containing IDs to “Alarm icon” to display the IDs as alarm icons.

  - Set the column type of a column to “Custom icon” to have its contents replaced by icons.

  - Set the column type of a column to “Color” to have the cells in that column visualized as colored blocks.

  - Set the column type of a column to “Date” to have its contents displayed as date values.

- In the *Filter by type* section, indicate which type of columns you want to choose from (services, properties and/or service profiles). It is also possible to add additional service profile columns.

#### Service & Resource Management: New 'Resources' and 'Bookings' apps \[ID_20525\]\[ID_21686\] \[ID_20715\]

In the *Apps* tab of the DataMiner Cube navigation pane, you can now find the following new applications:

- Resources

- Bookings

> [!NOTE]
> Up to DataMiner 9.6.3, the *Resources* app was available as an additional resources tab page in the *Scheduler* app.

#### Service & Resource Management: Filter API Profile Manager objects updated \[ID_20761\]

In Automation scripts, Profile Manager objects (parameters, profile instances and profile definitions) now allow the same filter style as Resource Manager objects.

#### Service & Resource Management/Automation: Profile parameter capabilities and resource capabilities \[ID_20891\]\[ID_20926\]\[ID_20958\]\[ID_21093\]\[ID_21178\]

In profile parameters and resources, you can now define so-called capabilities. This will allow you to configure the capabilities of the different resources as well as the resource capabilities required when reserving a resource.

##### Changes to profile parameters, profile instances, resources and booking instances

- A profile parameter can now belong to one of three categories: “Configuration”, “Monitoring” and “Capability”. If a profile parameter is of category “Capability”, it can represent one of two types of capabilities: range capability or discreet capability.

  A profile parameter of category “Capability” can also contain a default capability value, stored in the DefaultCapabilityValue property.

- A profile instance that contains a profile parameter of category “Capability” can now also contain a default capability value for that parameter.

- A (function) resource now has a list of resource capabilities, each referring to a profile parameter of category “Capability”.

- Every resource usage definition in a booking instance or service booking instance can now contain a list of resource capability usages, each containing

  - a link to the profile parameter that defines the capability, and

  - a required capability value (a single required discreet value or a single required value in the range)

- When you schedule a booking, the ResourceCapabilityUsage data of the booking will be checked against the capabilities of the resource. If the resource does not have the requested capabilities, you will receive an error.

- When a Resource has a ResourceCapability using a particular ProfileParameter, and that Resource is used in a scheduled ReservationInstance, from now on, it will not be allowed to delete the ProfileParameter in question. Updating a ProfileParameter of category “Capability” is always allowed, except:

  - deleting capabilities that are in use, and

  - deleting the capability category if it is being used by resources linked to scheduled bookings.

  The same rule applies to ProfileParameters of category “Capacity”. Updating such a parameter is always allowed, except:

  - deleting the capacity category if it is being used by resources linked to scheduled bookings.

##### Overview

Depending on the type of capability, the following data is expected in ProfileParameter, CapabilityUsageParameterValue and ResourceCapabilityUsage.

|                                                                           | Range capability                           | Discreet capability                                            |
|---------------------------------------------------------------------------|--------------------------------------------|----------------------------------------------------------------|
| ProfileParameter<br> (parameter definition)                               | The units of the capability range          | The list of discreet values, each representing a capability    |
| CapabilityUsageParameterValue<br> (parameter value)                       | The minimum and maximum value of the range | A subset of the discreet values defined in ProfileParameter |
| ResourceCapabilityUsage<br> (resource capability required by the booking) | A single value within the defined range    | One of the values from the list                                |

#### Service & Resource Management/Automation: Profile parameter capacities and resource capacities \[ID_20218\]\[ID_20996\]\[ID_21085\]\[ID_21194\]

In profile parameters and resources, you can now define capacities. This will allow you to configure the capacities of the different resources as well as the resource capacities required when reserving a resource.

The following changes have been implemented to profile parameters, profile instances, resources and booking instances:

- A profile parameter can now belong to one of four categories: “Configuration”, “Monitoring”, “Capability” and “Capacity”.

  - For a profile parameter of category “Capacity”, a unit should be defined. The profile parameter can have either a CapacityUsageParameterValue or a CapacityParameterValue value: the CapacityUsageParameterValue contains the required capacity for a booking, while the CapacityParameterValue contains the provided capacity of a resource. The default capacity value can be specified in the profile parameter itself.

- A profile instance that contains a profile parameter of category “Capacity” can now also contain a default capacity value for that parameter.

- A (function) resource now has a list of resource capacities, each referring to a profile parameter of category “Capacity”.

- Every resource usage definition in a booking instance or service booking instance can now contain a list of resource capacity usages, each containing

  - a link to the profile parameter that defines the capacity, and

  - a required capacity value (a single required discreet value or a single required value in the range)

- When you schedule a booking, the ResourceCapabilityUsage data of the booking will be checked against the capabilities of the resource. If the resource does not have the requested capabilities, you will receive an error.

  > [!NOTE]
  > The scheduling checks that are performed when you make a booking have all been updated. All these checks are now able to check resources with multiple capacities.

- When a Resource has a ResourceCapability using a particular ProfileParameter, and that Resource is used in a scheduled ReservationInstance, from now on, it will not be allowed to delete the ProfileParameter in question. Updating a ProfileParameter of category “Capability” is always allowed, except:

  - deleting capabilities that are in use, and

  - deleting the capability category if it is being used by resources linked to scheduled bookings.

  The same rule applies to ProfileParameters of category “Capacity”. Updating such a parameter is always allowed, except:

  - deleting the capacity category if it is being used by resources linked to scheduled bookings.

> [!NOTE]
>
> - In DataMiner 9.6.3, an input reference was added to resource usage definitions, so that it was possible to reserve the same capacity multiple times to transport the same source signal to different destinations. As a ResourceUsageDefinition can now contain multiple capacities, the input references have been moved to the capacity level. This means that, for a common input reference to be detected by the booking scheduler, the same Resource GUID, CapacityProfile GUID, Input Reference and Quantity should be configured in a booking. Also, from now on, reference strings will be linked to the MultiResourceCapacityUsage. Those linked to ResourceUsageDefinition are now obsolete.
> - On a system that uses multiple capacities, the following ResourceManagerHelper methods can no longer be used:
>   - GetAvailableResources
>   - GetResourceUsage

#### Services app: Service profiles \[ID_20635\]

In a service definition, it is now possible to organize parameter configurations into groups called service profiles.

To add a profile to the service definition:

1. In the *Definitions* tab, select a service definition.

1. In the *Profiles* tab, select any existing profile from the profile selection box (or select “New Profile Definition” to create a new profile), and click *Add*.

   > [!NOTE]
   >
   > - A warning icon will appear if the profile does not contain any parameters.
   > - An information icon will be shown as long as none of the parameters of the nodes of the service definition are linked to the profile.

1. Link the necessary node parameters to the selected profile.

#### New 'GetEligibleResources' method in ResourceManagerHelper class \[ID_21107\]

The following new method is now available in the *ResourceManagerHelper* class:

| Method               | Description                                                                                  |
|----------------------|----------------------------------------------------------------------------------------------|
| GetEligibleResources | Retrieves resources based on capabilities and capacities available in a specific time range. |

#### Updating a resource can cause ReservationInstances to get quarantined \[ID_21277\]

When, after being updated, a resource is no longer able to support all ReservationInstances, the resource update will not be saved and an error will be returned in tracedata. That error will contain a list of ResourceUsageDefinitions that should be quarantined before the resource update can be saved.

If a resource update has its forceQuarantine flag set to “true”, all ResourceUsageDefinitions to be quarantined will be quarantined automatically and the update will be saved. In this case, instead of an error, a warning will be returned listing the IDs of the ReservationInstances that were quarantined.

> [!NOTE]
> By default, the forceQuarantine flag of a resource update is set to “false”. This means that, when conflicts are found, an error will be returned and the update will be blocked.
>
> This forceQuarantine flag is a parameter of the SetResources method found in the ResourceManagerHelper.

When a ReservationInstance should be quarantined and the forceQuarantine flag is set to “true”, the following will happen:

- The IsQuarantined property of the ReservationInstance is set to “true”.

- The status of the ReservationInstance is set to “Pending”.

- All ResourceUsageDefinitions of the updated resource that caused the ReservationInstance to be quarantined are added to the QuarantinedResources property and are removed from the ResourcesInReservationInstance property.

    The QuarantinedResources property contains QuarantinedResourceUsageDefinition objects, which in turn contain the ResourceUsageDefinition that was quarantined and a list of QuarantineTriggers. The QuarantineTrigger contains more information as to which update triggered the ResourceUsageDefinition to be quarantined.
    When a ResourceUsageDefinition is quarantined, it is possible that not the entire ResourceUsageDefinition is quarantined. In that case, the original ResourceUsageDefinition is split up, and the ResourceUsageDefinition left in ResourcesInReservationInstance and the ResourceUsageDefinition in the QuarantinedResourceUsageDefinition will have the same value for the QuarantineReference property.

The following resource updates can cause a resource to be quarantined:

- Deleting a capacity or a capability.

    All bookings using the deleted capacity/capability will be quarantined.

- Downgrading a capacity.

    ReservationInstances using the downgraded capacity will be quarantined in the order described below until all other ReservationInstances can be run.

- Removing a discreet value from a capability.

    All ReservationInstances using the removed discreet value will be quarantined.

- Downgrading the range of a capability.

    All ReservationInstances using a value outside of the range of the capability will be quarantined.

- Downgrading the maximum concurrency of a resource.

    ReservationInstances will be quarantined in the order described below until all other ReservationInstances can be run.

- Setting a resource in maintenance mode.

    All ReservationInstances using the resource will be quarantined.

Order in which ReservationInstances are quarantined:

1. First try to quarantine ResourceUsageDefinitions of ReservationInstances that are already being quarantined.
2. Then try to quarantine the ReservationInstances that are the last to start.
3. Finally, if necessary, try to quarantine a random selection of ReservationInstances.

Limitations:

- ReservationInstances derived from a ReservationDefinition are never quarantined. When updating a resource used by a ReservationInstance derived from a ReservationDefinition, in the tracedata a ResourceManagerErrorData object is returned with the following properties:

  - SubjectId: ResourceId
  - conflictinformation: all ResourceUsageDefinitions used by ReservationInstances derived from a ReservationDefinition

- When a Cassandra database is being used, ReservationInstances scheduled after the caching period defined in the configuration file are not checked if they are saved on a DMA other than the one on which the Resource was updated.

> [!NOTE]
> The resource property “ResourceMode” has been deprecated.

#### Service & Resource Management: Update Resources & Profiles apps with capacity and capability support \[ID_21457\]

Resources in the Resources app can now be configured with one or more capabilities and one or more capacities. The latter replace the capacity configuration that was previously available for resources.

In the Profiles app, the parameter definition now indicates that the optional default value is intended for the configuration of the parameter. Also, in case a parameter is not in the category "Configuration", it will no longer be possible to configure a default configuration value for the parameter or to configure a link to a protocol.

#### Checks performed when updating a resource on systems using only legacy Reservation objects \[ID_21535\]

On systems using only legacy Reservation objects, the following checks are performed when editing a resource:

- Is the new maxconcurrency of the resource high enough to support the current bookings?
- Are the new capacities of the resource high enough to support the current bookings?
- If the ResourceMode was changed to Maintenance, is the resource not being used by any booking?

If any of these checks fail, an error will be returned in the tracedata.

> [!NOTE]
> If both ReservationInstance objects and legacy Reservation objects and being used, the ResourceManager will use the quarantine mechanism and ignore all legacy Reservation objects. Mixing legacy Reservation objects and ReservationInstance objects on one system is not supported.

#### Updating a ReservationInstance can cause resources to get quarantined \[ID_21557\]

When a ReservationInstance is updated, scheduling conflicts can now be resolved by quarantining ResourceUsageDefinitions.

##### Quarantining ResourceUsageDefinitions automatically

If, in the SetReservationInstances and AddOrUpdateReservationInstances methods of ResourceManagerHelper, the “forceQuarantine” flag is set to “true”, then ResourceUsageDefinitions will be quarantined automatically in order to resolve scheduling conflicts. When a ReservationInstance is saved, then the return value will contain a warning of type “ResourceManagerWarningData”, with warningReason “ReservationsWereMovedToQuarantine”.

If the “forceQuarantine” flag is set to “false”, the ReservationInstance will not be saved if ResourceUsageDefinitions have to be quarantined. Instead, an error of type “ResourceManagerErrorData” with errorReason “ReservationUpdateCausedReservationsToGoToQuarantine” will be returned.

Information about the reservations that will be quarantined can be found in the “MustBeMovedToQuarantine” property, which contains a list of “QuarantinedUsagesOnSingleReservation” objects. One “QuarantinedUsagesOnSingleReservation” object contains the ReservationInstance together with a list of moved ResourceUsageDefinitions (each with their QuarantineTriggers).

##### New reason 'ReservationInstanceUpdated'

A new Reason has also been added to the QuarantineTrigger class with value “ReservationInstanceUpdated”. Any ResourceUsageDefinitions that were quarantined because of a ReservationInstance update will have this reason in the respective QuarantineTrigger. Also, the ReservationUpdateTrigger property will be filled in (unlike the UpdateTrigger property). The ReservationUpdateTrigger object is of type ReservationDifference. A ReservationDifference contains the upgraded capacities and capabilities and the old and new time range. If the update was caused by a ProfileInstance change, the UpdatedProfileInstanceID property of the ReservationDifference will be filled in.

##### Which ReservationInstance updates can cause ResourceUsageDefinitions to be quarantined?

The following ReservationInstance updates can cause a ResourceUsageDefinition to be quarantined:

- Updating a required capacity so more usage is needed.
- Updating a required capability so more usage is needed.
- Using more concurrency of a resource.
- Moving a ReservationInstance to a new time range.
- Adding a new ReservationInstance

If a ReservationInstance in a tree is quarantined, the entire tree will be quarantined, and the QuarantineTrigger will have the reason TreeMovedToQuarantine. Note that, although the ReservationInstance itself was quarantined, it might be that none of its ResourceUsageDefinitions were:

- The IsQuarantined property of the ReservationInstance will be set to “true”.
- The ReservationInstance will have its status set to “Pending”.
- The ReservationInstance will have a QuarantinedResourceUsageDefinition added to its QuarantinedResources list. This QuarantinedResourceUsageDefinition will contain a trigger with the reason TreeMovedToQuarantine, but the QuarantinedResourceUsage will be set to “null”.

##### Profiles can now be updated by reference

From now on, the Profile Manager allows using an UpdateAndApplyProfileInstance call to update a profile by reference. When a profile instance is updated in this way, all ReservationInstances with a required capacity or required capability linked to this profile with a ByReference flag set to “true” will use the new value.

This new call also provides a “forceQuarantine” flag to indicate whether conflicts that arise during the update of ReservationInstances need to be automatically resolved by quarantining.

When this new call is used to update a ReservationInstance that already has a referenced ResourceUsageDefinition in quarantine, the quarantined ResourceUsageDefinition will also be updated.

If the ProfileManager encounters quarantine conflicts when executing an update, it will return

- a ProfileManagerWarningData object in the stacktrace in case of forced quarantining, or
- a ProfileManagerErrorData object in case of no forced quarantining.

Those objects contain a ResourceManagerWarningData and a ResourceManagerErrorData object respectively, containing the objects that were returned by the ResourceManager.

##### Limitations

- The above-mentioned quarantining checks will only be performed when updating ReservationInstances. Legacy Reservation objects do not support quarantining.
- If any ReservationInstances derived from ReservationDefinitions are affected, the update will be blocked and an error of type ResourceUsedByReservationDefinition will be returned.
- If any ReservationInstances using legacy capacity would need to be quarantined to resolve concurrency/capacity overflows, the quarantining will be skipped and the ResourceManager will fall back on the old mechanism of returning errors. If this happens, a warning will be returned with the reason “LegacyCapacitiesUsed”, along with any conflicts found by the ResourceManager in the error data.

#### Service Manager: New definition grouping toggle button \[ID_21632\]

In the Service Manager module, a button is now available in the top-right corner of the tree view pane that allows you to toggle grouping of template definitions and regular definitions in this pane. This template grouping feature is also available via the context menu of the tree view pane.

#### DataMiner Cube - Surveyor: Service & Resource Management apps now in 'Modules' section of 'Apps' tab \[ID_21688\]

In the *Apps* tab of the Cube navigation pane, all Service & Resource Management apps can now be found in the *Modules* section.

> [!NOTE]
>
> - Users will only be able to access those apps
>   - if a Service & Resource Management license is present, and
>   - if they have been granted the necessary user permissions.
> - The user permission *Reservations \> Timeline UI available* has been renamed to *Bookings \> UI available*.

#### Bookings can now have 'pre-events' \[ID_21751\]

It is now possible to add so-called “pre-events” to a booking, i.e. events that will take place before the start of the booking.

> [!NOTE]
>
> - All configured pre-events will be executed before the start actions are run.
> - If a pre-event could not be executed because the DataMiner Agent was down or because the ReservationInstance was configured in such a way that the pre-event was set in the past, then that pre-event will still be executed.

#### Resources app: Updating a capacity/capability can now cause reservations to be quarantined \[ID_21780\]

Updating a capacity or a capability of a resource can now cause certain reservations to be quarantined. When conflicting reservations are detected, those will now be shown in a popup, and users will have to indicate whether they want to save the resource or discard the changes.

#### Visual Overview - Profile Manager component: Extra options & new dynamic placeholder for booking properties \[ID_21843\]

If you want to embed a Profile Manager component on a Visio page, then add a shape with a shape data item of type “Component” set to either “Profile Manager” or “Profiles”.

| Shape data field | Value    |
|------------------|----------|
| Component        | Profiles |

In a shape data item of type “ComponentOptions”, you can now specify whether you want that component to show the Definitions, Instances and/or Parameters tabs.

| Shape data field | Value                                                                 |
|------------------|-----------------------------------------------------------------------|
| Component        | Profiles                                                              |
| ComponentOptions | ShowDefinitions=True\|ShowInstances=True\|ShowParameters=True |

Also, in a shape data item of type “Profile”, you can now specify the GUID of the profile instance that has to be shown in the Instances tab (together with all its parent and child items).

| Shape data field | Value                                                                 |
|------------------|-----------------------------------------------------------------------|
| Component        | Profiles                                                              |
| Profile          | *GUID of profile instance*             |
| ComponentOptions | ShowDefinitions=True\|ShowInstances=True\|ShowParameters=True |

##### New dynamic placeholder \[Reservation:...\]

Using the dynamic placeholder \[Reservation:...\], you can now retrieve a property of a booking (a profile, a resource or another property).

In this placeholder, you need to specify

- the GUID of the booking or the name or ID of the service linked to it (or a \[this service\] placeholder referring to a service),
- the property to be retrieved, and
- the arguments necessary to be able to retrieve the property.

Syntax: \[reservation:\<GUID or service>,\<property>\|\<argA>\|\<argB>\]

The property to be retrieved can be specified as follows:

| Property             | Value returned                                                                                                                         |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------|
| ProfileID            | The GUID of the profile instance linked to the resource retrieved from the booking. Note: The node ID has to be passed in \<argA>. |
| ResourceID           | The GUID of the resource linked to the booking. Note: The node ID has to be passed in \<argA>.                                     |
| Property:\<propName> | The value of a custom property of the booking. Note: The name of the custom property has to be passed in \<propName>.              |

> [!NOTE]
> If you specify arguments inside the placeholder, then use the following syntax: \<ArgumentName>=\<ArgumentValue>
>
> Example: NodeID=15

#### Decimal capacity values \[ID_22022\]

The CapacityParameterValue, CapacityUsageParameterValue, MultiResourceCapacity and MultiResourceCapacityUsage objects can now contain decimal capacity values.

Those decimal values will be used in resource usage calculations when calling GetEligibleResources or when adding or editing ReservationInstances.

If the long capacity value of one of the above-mentioned objects is updated, then its decimal capacity value will also be updated (and vice versa).

- If a decimal value is too large to fit in a field of type “long”, 0 will be returned when the corresponding long value is retrieved.
- When a long capacity value is retrieved, and the corresponding decimal value is set to a non-integer value, then the decimal capacity value will be returned, rounded down to the nearest integer. If, for example, the decimal capacity value is set to 125.8, the long capacity will be 125.

> [!NOTE]
>
> - When you try to add or edit ReservationInstances using long capacity values while some ReservationInstances are using decimal capacity values, then ReservationInstances with long capacity values might be quarantined and will have to have their capacity values (automatically) converted to decimal values.
> - It is not recommended to have a system that uses both decimal and long capacities values as it is not always possible to correctly convert decimal capacity values to long capacity values.

#### Quarantine check when changing a profile instance \[ID_22274\]

DataMiner will now also do a booking quarantine check when you update a profile instance. When conflicts are found after a profile instance update, a dialog box will appear, asking you whether the bookings should be quarantined (i.e. set to a pending state).

#### Checks added when regenerating contributing service protocol \[ID_22605\]

When the protocol for a contributing service is generated again, the following checks will now be executed:

- If any ongoing or confirmed bookings are using the current version of the protocol, the update will be blocked. In the tracedata, the errors *ProtocolInUseByReservations* and/or *ProtocolInUseByReservationDefinitions* will contain the IDs of the reservation instances and/or definitions that use the protocol.

- If any bookings used the protocol in the past, any parameters that were part of the protocol in the past will have the same parameter ID. If the *ShouldKeepInvalidPidsOnUpdate* property of the generate request is set to true (which is the default value), any parameters that were requested in the previous version of the protocol but are not requested in the new version will still be included.

- In case the protocol is not used in any bookings now or in the past, the update is executed without any further checks.

- If a protocol for a service definition is regenerated, and it had already been regenerated in the past on a system where these checks had not yet been implemented, the system will only check for ongoing and confirmed bookings. If other checks are skipped when the protocol is regenerated, the tracedata will contain a warning of type *RegeneratedWithoutPreviousInfo*.

In addition, the *SrmProtocolGenerationInfo* object has been expanded with the complete profile parameter that was used to generate each protocol parameter.

#### Service & Resource Management - Automation: New GetEligibleResourcesForServiceNode method \[ID_23576\]

A new method, *GetEligibleResourcesForServiceNode*, is now available in the *ResourceManagerHelper* class. It can be used to replace a resource for a specific node of a service booking that has already been scheduled. The method requires a ReservationID, a nodeID and a set of capacities and capabilities. It retrieves all eligible resources for the specified node that can provide the specified capacities and capabilities within the time range of the specified booking.

```csharp
public Resource[] GetEligibleResourcesForServiceNode(
    ReservationInstanceID ServiceReservationInstance,
    int NodeID,
    List<MultiResourceCapacityUsage> requiredCapacities,
    List<ResourceCapabilityUsage> requiredCapabilities)
```

#### Service & Resource Management: SRM_QuarantineHandling script triggered when booking is quarantined \[ID_23589\]

When a booking enters into quarantined state because of a change in the system, the script titled *SRM_QuarantineHandling* will now be run. The entry point for this script should be configured as follows:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmQuarantineTrigger)]
public void OnSrmQuarantineTrigger(Engine engine, List<ReservationInstance> reservations)
{
    engine.GenerateInformation("SRM_QuarantineHandling was correctly triggered for " + reservations.Count + " reservations.");
}
```

If there is a quarantine trigger in the system and this script is not present or does not have a correct entry point defined, a notice will be generated. However, if the script was executed but exited with a failure, no notice is generated.

It is currently not possible to replace this script by a script with a different name. The script will also always run when a booking enters the quarantined state, regardless of whether it has been in this state before.

#### Service & Resource Management: Modified context menu options for dynamic booking, service and resource lists \[ID_23607\]

Different context menu options are now available for dynamic booking, service and resource lists, depending on whether these are viewed in Visual Overview (using a *ListView* component) or in the Services/Bookings app:

- Both in the Services/Bookings app and in Visual Overview, the following options are available: *Add/Remove column*, *Alignment*, *Change column name*.

- The following options are only available in Visual Overview: *Load column configuration* and *Save column configuration as*.

- The following options are only available in the Services/Bookings app: *Load default column configuration* and *Save current column configuration*.

The custom column configuration for a *ListView* component can now be saved via the *Columns* shape data field. As such, it is now possible to set this shape data field to the name of a saved column configuration instead of to a JSON configuration.

In the Bookings app and Services app, it is now possible to save the preferred set of columns and to load the default set of columns based on the source type.

#### Service & Resource Management: Bookings list can now display colors configured in Visual.Background property of bookings \[ID_23681\]

If colors are defined using the *Visual.Background* property of bookings, these can now be displayed in the *Color* column of a dynamic list showing bookings, for instance in the Bookings app or in Visual Overview. The same colors and color formats are supported as when this property is used to determine the background color of the blocks on the Resources timeline.

#### DataMiner will now generated an error when it detects a ServiceManager license but no ElasticSearch instance \[ID_24329\]

From now on, a DataMiner Agent will generated the following DataMiner run-time error when it detects a ServiceManager license but no Elasticsearch instance:

*The Service Manager is licensed, but no ElasticSearch database is active on the system. Therefore, Resource Manager and Service Manager will not initialize.*

#### DataMiner upgrade: Additional action to correct default value types of profile parameters \[ID_24937\]

As it is no longer allowed for profile parameters with a type set to a value other than “Undefined” to have a default value of type “Undefined”, when upgrading to DataMiner 10.0.0/10.0.4, an additional action will be performed to correct all incorrect default value types.

Whenever a profile parameter with a type set to a value other than “Undefined” has a default value of type “Undefined”, the upgrade action will do the following:

| If...                                        | then...                                                                                                                                                                                 |
|----------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| the profile parameter is of type “Number”,   | the type of the default value will be set to “Double”.                                                                                                                                  |
| the profile parameter is of type “Text”,     | the type of the default value will be set to “String”.                                                                                                                                  |
| the profile parameter is of type “Discreet”, | If the parameter’s “DiscreetDisplayValues” list is filled in, then the type of the default value will be set to “Discreet”, else the type of the default value will be set to “String”. |

> [!NOTE]
> The upgrade action will create a backup copy of the profiles.xml file named profiles.xml.bak, and will store in the C:\\Skyline DataMiner\\ProfileManager\\changeundefinedtype_backup\\ folder.
>
> This backup copy will not be deleted when the upgrade action has finished.

### DMS Spectrum Analysis

#### Users will now get more information when a spectrum script fails \[ID_21036\]

When a spectrum script fails, a pop-up window will now clearly show

- the name of the script, and
- the error message returned by the script.

#### 'Follow device settings' option \[ID_22615\]\[ID_23009\]

When configuring a spectrum element, you can now select the *Follow device settings* option.

When you open a spectrum element that has this option enabled, regardless of the client, the card will show the actual configuration of the spectrum analyzer device. Any settings specific to a particular user will be disregarded.

> [!NOTE]
> When you select the *Follow device settings* option when configuring a spectrum element, it is advised to also select the *Shared session mode* option to make sure traces are shared between users.

### DMS tools

#### SLNetClientTest: Checking whether protocol buffer serialization is enabled \[ID_20495\]

Using the SLNetClientTest tool, you can now check whether a client connection is using protocol buffer serialization.

1. Go to *Diagnostics \> Connection Details*, and then select a client connection.

2. Using the filter box at the bottom of the window, check whether the text contains the following string: “ProtoBuf: disabled/enabled (version)”

    Example: “ProtoBuf: Enabled (version: 9.6.1846.504)”

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### DataMiner Taskbar Utility: Option to abort an upgrade operation \[ID_20925\]

If an upgrade is started using the DataMiner Taskbar Utility, a button will now be available that allows you to abort the upgrade in progress.

> [!NOTE]
> Be very careful with this functionality, as aborting an upgrade can potentially cause a DataMiner Agent to no longer start up.

#### DataMiner Taskbar Utility: 'Summary' tab in upgrade window & 'Forced stop' option in right-click menu \[ID_20944\]

The following enhancements have been made to the DataMiner Taskbar Utility:

- The window shown while a DataMiner upgrade is in progress, used to have a *General* tab. This tab has now been replaced by a *Summary* tab, listing the latest status updates of every DataMiner Agent being upgraded.

- When you right-click the taskbar icon of the DataMiner Taskbar Utility, you can now click *Forced stop* to have all Skyline processes stopped immediately.

#### SLNetClientTest: History tab added to QueryTable window \[ID_21386\]

In the *QueryTable* window (which you can open via *Advanced \> Dynamic Table Query*), a *History* tab has now been added. This tab will keep track of all queries executed during the current session.

- Apart from exporting and importing the list of queries, you can re-run queries and calculate average timings.

- For a specific query, it is possible to generate C# Automation script code that executes the query and provides access to the results.

#### SLNetClientTest: Viewing the connection timeout states of an element \[ID_23573\]

Using the SLNetClientTest tool, you can now view the connection timeout states of a specific element.

- Go to *Diagnostics \> DMA \> Protocol Connection States*, and specify either the element name or the element ID (format: DmaID/ElementID).
