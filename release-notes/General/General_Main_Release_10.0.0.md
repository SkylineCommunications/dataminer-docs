---
uid: General_Main_Release_10.0.0
---

# General Main Release 10.0.0

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

```txt
var managedFilter = new ManagedFilter<DMAObjectRefTree,IDMAObjectRef>                    (DMAObjectRefTreeExposers.Data,Comparer.Equals,new ViewID(2),null);
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

2. Right-click in the list header (or click the list’s hamburger menu), select *Load column configuration*, and select the configuration you created in step 1.

3. Right-click in the list header, and do the following:

    - add or remove columns,
    - change the text alignment inside columns, and
    - rename columns.

    > [!NOTE]
    > When you click *Add/remove column*, you can also select *More...*
    >
    > This will open a *Choose details* window that will allow you to show/hide columns, move columns up/down, etc. See below for more information.

4. Right-click in the list header (or click the list’s hamburger menu), select *Save current column configuration*.

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

## Changes

### Enhancements

#### HTML5 apps: Enhanced UI component consistency \[ID_18892\]

The UI components used in all DataMiner HTML5 apps have now been made more consistent.

#### DataMiner Cube - Alarm Console: Enhanced service information \[ID_18310\]\[ID_19131\]

When you load a history tab page with a service filter, in some cases, not all service properties are added to the alarms. From now on, when you add a service property column to an alarm tab, a warning icon will be shown in the column header. When you hover over that icon, a tooltip will appear, indicating that some properties are not shown and that you should open the alarm card to view them all.

#### HTML5 app: Embedded spectrum components and spectrum thumbnails \[ID_18479\]\[ID_19297\]

From now on, the HTML5 app fully supports spectrum components and spectrum thumbnails embedded in Visual Overview. Up to now, those components and thumbnails would be rendered as static images.

#### DataMiner Cube: Enhanced visualization of names of table column parameters \[ID_18928\]\[ID_20175\]\[ID_20252\]\[ID_20294\]\[ID_20299\]\[ID_20309\]

From now on, in DataMiner Cube, table column parameters will be referred to by either their long display name or their short display name:

- Long display name (default name, consisting of both the table name and the column name)
- Short display name (shorthand name used e.g. inside tables and in table side panels)

The long display name of a table column parameter can be formatted in two ways:

- \[TableName\]:\[ColumnName\] (default format, e.g. “MyTable: MyTableColumn01”)
- \[ColumnName\] (\[TableName\]) (e.g. “MyTableColumn01 (MyTable)”)

#### Names of existing properties can no longer be changed \[ID_18930\]

From now on, it is no longer possible to change the name of an existing property.

#### Enhanced downgrade and upgrade actions for TTL settings \[ID_18946\]

When a DataMiner System is upgraded from a version that did not use the TTL settings in *DBMaintenance.xml* and *DBMaintenanceDMS.xml* yet to a more recent version, the deprecated settings in *MaintenanceSettings.xml* will be cleared and replaced by a note mentioning that these settings have been moved to the new DBMaintenance files. When a downgrade is executed to such an older version, the old settings will be recalculated and the values of these settings will be restored.

#### OpenSSL library version 1.1.1c now included with DataMiner \[ID_19026\]\[ID_22956\]

From now on, OpenSSL library version 1.1.1c will be included with DataMiner.

#### Web Services - HTML5 app: dependencyId and dependencyValues now supported \[ID_19130\]

The DataMiner web services and HTML5 application now support protocols using the *dependencyId* and *dependencyValues* functionality.

#### Enhanced performance due to reduction of data traffic to and from the LDAP server \[ID_19135\]

Due to a reduction of the data traffic to and from the LDAP server, overall performance has increased.

#### DataMiner Cube - Alarm Console: Enhanced time range options for new history tab \[ID_19285\]

In a new empty tab in the Alarm Console, the time range options to create a history tab have been rephrased and a new "More..." option is now available. Clicking the latter will open a pop-up window where you can select one of several preconfigured quick ranges or specify a custom range.

In addition, in the Settings app, these changes have also been implemented for the configuration of a default history tab for a user or group.

#### Database: Default value of HistorySlider setting set to 1 month \[ID_19299\]

The default value for the *HistorySlider* setting in the file *DB.xml* (which determines how long history alarm information is kept in the Cassandra database so that it can be visualized with the history slider in the Alarm Console) has now been set to 1 month. This change will only affect new installations or upgrades of systems where no default value had been set for this setting yet.

#### HTML5 app: Executing an Automation script by clicking a shape \[ID_19306\]

From now on, similar to DataMiner Cube, the HTML5 app also supports executing an Automation script by clicking a shape.

#### DataMiner Cube - Visual Overview / DCF: Enhanced positioning of connection property shapes in grid layout \[ID_19352\]

Up to now, when element shapes with connectivity were positioned in a grid layout, in some cases, connection property shapes would not be positioned correctly because of rescaling. From now on, those property shapes will no longer be rescaled, not even when the size of the Visio page is changed.

#### DELT import/export packages: Description.txt and Package.xml now also mention the DataMiner version that was used to create the package \[ID_19357\]

Up to now, when you created a DELT package, the *Description.txt* and *Package.xml* files mentioned the user who created the package and the time at which the package was created. From now on, those two files will also contain the DataMiner version that was used to create the package.

#### SLSNMPAgent: Service description changed \[ID_19417\]

The description of the SLSNMPAgent service has been changed from “Skyware SNMP Agent” to “SLSNMPAgent”.

#### Possibility to copy property value of alarm to other alarm field or property \[ID_19421\]

It is now possible to have the value of a property that is available for an alarm copied to a predefined field of the alarm (i.e. the *Owner*, *Comment*, *Element Name* or *Parameter Name* field) or to another property.

To do so, in the *PropertyConfiguration.xml* file, add the *copyToAlarmField* attribute to the *Property* tag of the property that needs to be copied, and set it to the correct keyword:

| Field                          | Keyword                   |
|--------------------------------|---------------------------|
| Comment                        | \[COMMENT\]               |
| Element Name                   | \[ENAME\]                 |
| Owner                          | \[OWNER\]                 |
| Parameter Name                 | \[PNAME\]                 |
| Alarm property called "name"   | \[PROPERTY:ALARM:name\]   |
| Element property called "name" | \[PROPERTY:ELEMENT:name\] |
| Service property called "name" | \[PROPERTY:SERVICE:name\] |
| View property called "name"    | \[PROPERTY:VIEW:name\]    |

For example:

```xml
<Property id="21" type="Element" name="Location" copyToAlarmField="[ENAME]" />
```

#### DataMiner Cube: New label indicating new trend group that is being added \[ID_19526\]

When a new trend group is being added in DataMiner Cube, a "\[new\]" label will be added to the trend group name in the pane that lists the existing trend groups, just as this is done for scripts in the Automation app, for example.

#### DataMiner Cube - Visual Overview: ParametersSummary enhancements \[ID_19568\]

Up to now, if you specified a table parameter in a shape data item of type *ParametersSummary*, only one row was allowed to match the filter. From now on, it is possible to refer to several rows, a column, or a full table.

Examples:

- To refer to all rows that start with “SL”, you can specify “101/201:500:SL\*\|”.
- To refer to a column, specify the column parameter, e.g. “101/201:501”.
- To refer to an entire table, specify the table parameter, e.g. “101/201:500”.

#### Database: Improved handling of large batches for Cassandra database \[ID_19586\]

The way batches are written to the Cassandra database has been improved, so that larger batches can now be written. This can improve performance, especially for systems that are under a heavy load.

#### DataMiner Cube: Files now signed with COMODO certificate \[ID_19675\]

The following DataMiner Cube files are now signed with a COMODO certificate:

- C:\\Skyline DataMiner\\webpages\\DataMinerCubeInstall\\setup.exe
- C:\\Skyline DataMiner\\webpages\\DataMinerCube\\DataMinerCube.xbap
- C:\\Skyline DataMiner\\webpages\\DataMinerCubeStandalone\\DataMinerCube.application
- C:\\Skyline DataMiner\\webpages\\DataMinerCube\\DataMinerCube.exe
- C:\\Skyline DataMiner\\webpages\\DataMinerCubeStandalone\\DataMinerCube.exe
- C:\\Program Files (x86)\\Skyline Communications\\DataMiner Cube x.x.x.x\\DataMinerCube.exe
- C:\\Skyline DataMiner\\webpages\\Tools\\Installs\\DataMiner Cube.msi

Note that a security warning will now always appear when you download a new DataMiner Cube version. To prevent this warning from appearing, you can import the certificate into your Windows Certificate Store as follows:

1. When the security warning appears, click “Skyline Communications NV” under *Publisher*.

2. At the bottom of the *Certificate* window, click *Install Certificate...*

3. In the *Certificate Import Wizard* window, set *Store Location* to “Current User”, click *Next*, and follow the instructions in the wizard to complete the process.

    > [!NOTE]
    > Make sure all certificates are placed in the certificate store called “Trusted Publishers”.

#### Improved logging in case local database connection fails because of Db.xml configuration \[ID_19682\]

If no active local database has been configured in *Db.xml* and the database connection therefore fails, this will now cause a clear message to be logged in *SLDBConnection.txt*, stating that the local database could not be found and *Db.xml* should be verified.

#### DMS Ticketing: Ticket link filtering \[ID_19754\]

DataMiner Ticketing now allows you to filter tickets by ticket link.

#### Improved retrieval of information event history \[ID_19755\]

Historical information events are now retrieved more efficiently, so that these will be displayed in the Alarm Console more quickly.

#### Direct connection no longer limited to specific element \[ID_19790\]

To create a direct connection in a protocol (via a QAction), it is now no longer necessary to specify a DMA ID/Element ID. Instead of connecting to a specific element, you can now create multiple direct connections that are not tied to an element.

#### SLSNMPManager: SNMP++ library upgrade \[ID_19796\]

From now on, the SLSNMPManager process will use SNMP++ library version 3.3.11.

#### Web Services API: WebSocket connections will now be closed when the API is stopped \[ID_19928\]

Up to now, when the Web Services API was stopped by IIS, the existing WebSocket connections would not immediately be closed. IIS would wait a certain amount of time before forcefully terminating the connections. From now on, the Web Services API will listen to IIS for notifications on when to terminate the connections gracefully.

#### Service & Resource Management: Enhanced performance when disabling DVE element after service have ended \[ID_19947\]

Due to a number of enhancements, overall performance has increased when disabling DVE elements after service have ended.

#### Enhanced masking of DataMiner objects \[ID_20033\]\[ID_21654\]

A number of enhancements have been made with regarding to the masking of DataMiner objects (elements, alarms, redundancy group, DVE elements) via user interfaces or Automation.

> [!NOTE]
> All masking information of alarms and elements will now be stored in the *maskstate* table.

#### SLAnalytics now supports asynchronous communication \[ID_20051\]

The SLAnalytics process now allows requests to be sent either synchronously or asynchronously.

#### DataMiner Cube - Ticketing: Cube now ignores tickets without link \[ID_20088\]

Previously, when Cube connected to the DMS, it cached all the tickets from the DMS. To improve efficiency, now only tickets with a link to a DataMiner object will be cached. In addition, if new tickets are created that have no link to a DataMiner object, Cube will ignore these.

#### Service & Resource Management: 'NextAvailableStates' added to SRMServiceState object \[ID_20282\]

A list of NextAvailableStates has been added to the SRMServiceState object. This means that, using the ServiceManagerHelper class in an Automation script, it is possible to save the next available states of an SRM service.

#### Services: Enhanced alarm and element state update mechanism \[ID_20329\]

A number of enhancements have been made to the mechanism that is used to update alarms and element states within a service.

#### Enhanced performance when retrieving view impact data from elements \[ID_20353\]

Due to a number of enhancements, overall performance has increased when retrieving view impact data from elements.

#### Improved logging in case of invalid SNMPv3 trap \[ID_20356\]

The error information in the SNMPManager log file in case an invalid SNMPv3 trap is received has been improved.

#### Support for GetBulk requests \[ID_20362\]

GetBulk requests are now supported by DataMiner (for SNMPv2 and SNMPv3).

#### DataMiner Cube: Users with access to a child view will now automatically have access to the parent view \[ID_20505\]

If users have been granted access to a child view, from now on, they will automatically be granted access to the parent view.

#### Profile Manager: Improved performance when loading profile instances and definitions \[ID_20549\]

In the Profile Manager app, profile instances and definitions will now be loaded more efficiently.

#### DataMiner Cube - Security: Service & Resource Management permissions moved into one category \[ID_20586\]

In the *Users / Groups* app, the different user permissions related to the Service & Resource Management module have been moved into one category. This means that the Profile Manager, Resource Manager and Service Manager user permissions can now be found under *Service & Resource Management* instead of under the separate app names.

#### DataMiner Cube - Visual Overview: ChildrenFilter shape data now supports placeholders \[ID_20664\]

It is now possible to use placeholders such as *\[var:\]* and *\[param:\]* within *ChildrenFilter* shape data. This can for instance be used to filter child shapes using a session variable in the filter value.

#### Automation/Scheduler: Email action now supports CPE reports \[ID_20692\]

It is now possible to send a CPE report via an Automation script or scheduled task. When configuring the email action in the script or task, if you select to attach a CPE report, you will now be able to select a CPE Manager, along with a chain and one or more fields of the selected chain. For each field, a number of KPI parameters can then be selected, optionally with a filter.

#### Backup/restore now includes Service Manager and Protocol Function Manager modules \[ID_20713\]

DataMiner Backup/Restore now also includes the Service Manager and Protocol Function Manager modules.

#### Users with an expired password now only have to change it on one agent in the DataMiner System \[ID_20717\]

Up to now, users of whom the password had expired had to change their password on every agent in the DataMiner System. From now on, they will only have to change it on one of the agents.

#### Enhanced performance when large amounts of data are being stored in Cassandra \[ID_20850\]

Due to a number of enhancements, overall performance has increased when storing large amounts of data in a Cassandra database.

#### Enhanced performance when configuring protocol-level TTL settings \[ID_20908\]

Due to a number of enhancements, overall performance has increased when configuring protocol-level TTL settings.

#### DataMiner Cube: Enhancements for elements in timeout \[ID_20910\]

When an element is in the timeout state, any write parameters of this element will now be disabled. In addition, all parameters of the element will be displayed in such a way that it is clear to the user that there is currently no connection with the device. In addition, at the bottom of the card, a message will be displayed to notify the user that the element is in timeout.

#### New Logging.DaysToKeep tag in DataMiner.xml \[ID_20911\]

In the file *DataMiner.xml*, a new *\<DaysToKeep>* subtag can now be specified within the *\<Logging>* tag, which will determine for how many days log files are kept in the folder *C:\\Skyline DataMiner\\Logging*. If this tag is not specified or if its value is 0, log files will be kept for 100 days.

Example:

```xml
<DataMiner>
  ...
  <Logging>
  ...
  <DaysToKeep>30</DaysToKeep>
  </Logging>
  ...
</DataMiner>
```

#### DataMiner Cube: Contacts panel now also shows users logged into mobile apps \[ID_20934\]

If a user is logged into the Monitoring app (formerly known as the HTML5 app), the new Job Manager app or the Ticketing app, this user will now also be displayed in the *Contacts* panel in DataMiner Cube.

#### Windows feature 'Websockets' automatically enabled as from DataMiner 9.6.5 \[ID_20974\]

As from DataMiner 9.6.5, the Windows feature “Websockets” will automatically be enabled.

> [!NOTE]
> After upgrading to DataMiner 9.6.5, a message may appear, stating that a reboot is required. Note that a reboot is only required when you plan to use the new Dashboards app.

#### Failover: Alarm generated when the two DataMiner Agents in a Failover setup do not have the same DataMiner version \[ID_20951\]\[ID_21032\]

From now on, a “version mismatch on failover pair” alarm of type “error” will be generated when the two DataMiner Agents in a Failover setup do not have the same DataMiner version.

#### Increased performance at DataMiner startup due to enhanced management of TXF files \[ID_21057\]

Due to a number of TXF file management enhancements, overall performance has increased at DataMiner startup.

#### MySQL connector upgraded to v6.9.12 \[ID_21064\]

The MySQL connector has been updated to v6.9.12.

#### Ticketing: Removing ticketing domain no longer possible while a DMA is unavailable \[ID_21100\]

To prevent synchronization issues, it is no longer possible to delete a ticketing domain while one of the Agents in the DMS is unavailable.

#### Enhanced performance by caching TXF files at SLXml startup \[ID_21139\]

From now on, all existing TXF files will be cached when the SLXml process is started. This will enhance overall performance.

#### Service & Resource Management: 'IsIDP' property now indicates if booking instances uses IDP resources \[ID_21168\]

When a booking instance that uses IDP resources is saved, the server will now automatically make sure that it has the property *IsIDP* set to true. This property can only be set on systems with an IDP license.

#### Ticketing/Automation: New type property in TicketFieldDescriptor and TicketFieldOverrideConfig class \[ID_21202\]

A new type property is now available in the *TicketFieldDescriptor* and *TicketFieldOverrideConfig* class, which allows you to define a custom alarm property type when linking an alarm property to a ticket field.

#### DataMiner Cube - Visual Overview: Visio pages displayed in mobile apps are now refreshed via WebSockets \[ID_21291\]\[ID_21941\]\[ID_21971\]

If WebSockets are enabled, from now on, Visio pages displayed in mobile apps will be refreshed using WebSockets. If WebSockets are not enabled, those pages will be refreshed as before, using a polling mechanism.

#### Database: Table creation scripts will now also create a SnapshotData table \[ID_21343\]

The following table creation scripts (found in C:\\Skyline DataMiner\\Tools) will now also create a SnapshotData table:

- CentralTabledef.txt
- CentralTabledefOracle.sql
- CentralTabledefOracleUninstall.sql
- CentralTableDefSQLServer.sql

#### DataMiner Maps: View impact data now taken into account when calculating alarm states of CPE markers \[ID_21384\]

If the source table of CPE markers has a “View Impact” column, the alarm states of the views specified in that column will now taken into account when calculating the alarm states of the CPE markers.

#### DataMiner Cube: No more warning message when changing the protocol of an element \[ID_21407\]

When you changed the protocol of an existing element, up to now, a “This will clear any unsaved changes. Do you wish to proceed?” message would appear.

From now on, this message will no longer appear.

#### Enhanced performance when dynamically including elements in services based on DCF connectivity settings \[ID_21408\]

Due to a number of enhancements, overall performance has increased when dynamically including large amounts of elements in services based on DCF connectivity settings.

#### DataMiner Cube: Redundancy groups can enter the 'Undefined' state if one or more of the switching detection triggers cannot be resolved \[ID_21414\]\[ID_22842\]

From now on, a redundancy group can enter the “Undefined” state if one or more of the switching detection triggers cannot be resolved.

#### SNMP++ library now allows user names to have multiple credentials \[ID_21458\]

The SNMP++ library now allows user names to have multiple different credentials.

Up to now, a user was considered unique based on the user name only. From now on, a user will be considered unique based on the following set of properties:

- user name
- authentication protocol
- authentication password
- privacy protocol
- privacy password

> [!NOTE]
> oidUsmStatsUnknownUserNames (1.3.6.1.6.3.15.1.1.3.0) will no longer trigger a security parameter refresh.

#### DataMiner Indexing now supports Elastic up to version 6.8.0 \[ID_21581\]\[ID_22451\]

DataMiner now supports Elastic up to version 6.8.0.

#### DataMiner Cube - Visual Overview: Bookings component now also available with IDP license \[ID_21591\]\[ID_21686\]

Previously, to have access to a *Bookings* component embedded in Visual Overview, a Resource Manager license had to be available. Now this component will also be available in case an IDP license is available.

#### Cassandra database: Custom data types now also saved to file when database goes down \[ID_21631\]

By default, when the database goes down all data is saved to file, and later, when the database is on-line again, the data in the file is flushed to the database.

From now on, the data that is saved to file will also include the custom data types.

#### Server-side table sorting now uses a natural sorting algorithm \[ID_21705\]\[ID_22243\]

From now on, server-side table sorting will use a natural sorting algorithm.

> [!NOTE]
> MAC addresses will always be sorted by value.

#### Enhanced performance of CPE crawler \[ID_21711\]

Due to a number of enhancements, overall performance of the CPE crawler has increased.

#### A DataMiner Agent can no longer be restarted without restarting SLNet \[ID_21719\]

Up to now, when you restarted a DataMiner Agent, you had the option to either also restart the SLNet process or not. From now on, when you restart a DataMiner Agent, the SLNet process will always be restarted as well.

#### SRM/Automation: IsValueCopy property added to ProfileInstance class \[ID_21797\]

The property *IsValueCopy* has been added to the *ProfileInstance* class. This property makes it possible to distinguish between temporary profile instance copies and profile instance templates.

#### SRM/Automation: Disabled property added to ProfileParameterEntry class \[ID_21808\]

The property *Disabled* has been added to the *ProfileParameterEntry* class. It can be used to disable a parameter that should not be inherited from a parent profile instance.

#### Scheduler/Automation: Possible to include trending for chain field in CPE report email action \[ID_21896\]

When you configure a scheduled task or Automation script action to email a CPE report, you can now select to include trending for a chain field.

#### Service & Resource Management: Contributing DVE associated with a contributing booking now has two additional parameters \[ID_21967\]

The contributing DVE element associated with a contributing booking now has two additional parameters:

| Parameter ID | Parameter name   |
|--------------|------------------|
| 1            | Service ID       |
| 2            | Service severity |

#### Resources: Enhanced concurrency and capacity verification \[ID_21988\]

Due to a number of enhancements, concurrency and capacity verification performed when scheduling a resource instance has been improved.

#### DataMiner Cube - Router Control: Enhanced undo \[ID_21999\]

When, in the Router Control app, you undid the latest connect or disconnect action, up to now, the locking state of the inputs or outputs in question was not taken into account.

From now on, users trying to undo a connect or disconnect action involving locked inputs or outputs will be asked whether they want to first unlock the locked inputs or outputs.

- If they click Yes, then the locked inputs and outputs will be unlocked, and the action will be undone.
- If they click No, locked inputs and outputs will stay locked, and the action will be undone only for the currently unlocked inputs and outputs.

#### Link to Jobs app in app menu Ticketing app \[ID_22012\]

The Ticketing app now has a link to the Jobs app in its app menu.

#### OpenSSL library version 1.1.0j now included with DataMiner \[ID_22070\]

From now on, OpenSSL library version 1.1.0j will be included with DataMiner.

#### SLNet logging: Elements in 'Unsubscribe' log entries now referred to by dmaID/elementID \[ID_22078\]

In the following SLNet log entries, up to now, elements were only referred to by elementID. From now on, they will be referred to by DataMinerID/elementID.

```txt
Successful : Unsubscribing from element dmaID/elementID Unsuccessful : Failed to unsubscribe from element dmaID/elementID
```

#### DataMiner Cube - Alarm Console: Improved 'More...' time range option for new alarm tab \[ID_22092\]

When a new Alarm Console tab is created by dragging a DataMiner object onto the Alarm Console, the *More...* option for the time range of the alarms now functions in a more intuitive manner.

#### Security changes applied more quickly for Web API connections \[ID_22137\]

Previously, if DataMiner security settings were changed using DataMiner Cube, any existing web API connections at that time kept using the security settings from before the changes. The changes were only applied if a new web API connection was made. Now the changes will be applied immediately, although the UI will only be updated when users refresh the page. This means that if users no longer have permission to use particular options, they will still be able to see the options but not to use them, until the page is refreshed.

#### DataMiner Cube - Visual Overview: ClientSideRowFilter now supports both the table name with and without suffix \[ID_22152\]

As, since DataMiner 9.6.4, table column names in DataMiner Cube no longer display the name of the table as a suffix in parentheses, ClientSideRowFilter will now support both the table name with and without this suffix.

For example, a column with parameter description “Value (Table1)”, will match both the filter Value:5 and “Value (Table1)”:5.

#### Service & Resource Management: System function definitions now automatically synchronized among Failover agents and among all agents in a DataMiner System \[ID_22242\]

From now on, system function definitions will automatically be synchronized among Failover agents and among all agents in a DataMiner System.

#### Enhanced performance of CPE filtering \[ID_22262\]

Due to a number of enhancements, overall CPE filtering performance has increased.

#### HTML5 apps: Browser caching disabled by default \[ID_22318\]

All DataMiner HTML5 apps (Ticketing, Jobs, etc.) will now have their browser caching disabled. This will prevent users from having to clear their browser cache after upgrading to a new version.

#### DataMiner Cube - CPE: Enhanced text in tooltip of aggregation page refresh button \[ID_22353\]

The text in the refresh button’s tooltip on CPE aggregation pages has been made more user friendly.

#### Service & Resource Management: Optimization of enhanced service protocol template \[ID_22373\]

The enhanced service protocol template, which is used to create booking services, has been optimized.

#### SLAnalytics: Enhanced calculation of state icons in tables & enhanced logging \[ID_22379\]

In order to optimize overall performance, the number of state icons calculated per table will now be limited.

Also, a number of enhancements have been made with regard to logging.

#### DataMiner Cube - Visual Overview: Enhanced image caching \[ID_22464\]

When you open a Visual Overview, the images in that Visual Overview are kept in an image cache. That cache has now been enhanced. From now on, if you open multiple identical Visual Overviews, each image in those Visual Overviews will only be cached once.

> [!NOTE]
> If a Visual Overview contains shape data fields of type VdxPage or InlineVdx, all references to Visio files in those fields will also be cached.

#### DataMiner Cube - Visual Overview: Placeholders of non-existing properties are now automatically removed from shape text \[ID_22472\]

When shape text contains a placeholder that refers to a non-existing property, from now on, that placeholder will automatically be removed from the shape text.

#### A log entry will now be added to ERRORLOG.txt in the event of an error while processing a notification \[ID_22478\]

In the event that SLDataMiner, SLElement or SLDMS would throw an exception while processing a notification, from now on, a log entry will be added to the ERRORLOG.txt file.

#### Ticketing API: TraceData will now contain all TicketingGateway error data \[ID_22526\]

For each TicketingGateway request that failed, an entry of type TicketingManagerError.Reason.LegacyError will now be added to the TraceData.

The value of the error will be stored in the LegacyErrorMessage property of the TicketingManagerError object.

#### SLNetClientTest: Enhanced analysis of .slnetdump and follow sessions \[ID_22561\]

A number of enhancements have been made to the SLNetClientTest tool in order to improve the analysis of .slnetdump and follow sessions.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Sorting of direct view tables that combine data retrieved from different elements \[ID_22574\]

From now on, it is possible to sort direct view tables that combine data retrieved from different elements.

Note that it is not possible to sort by a column that is not part of the result set.

#### Cassandra: Enhanced performance when writing TimeTrace data \[ID_22609\]

In order to enhance overall performance, TimeTrace data will now be written in batches with the same partition key (maximum batch size = 20).

#### DataMiner Cube - CPE Management: Enhanced performance \[ID_22629\]

Because of a number of enhancements, overall performance of the DataMiner Cube UI has increased when working in a CPE environment.

#### SLSNMPAgent process: Enhanced method to detect duplicate notices \[ID_22652\]

Previously, when SLSNMPAgent generated a notice, that notice would be blocked if an identical notice had been generated less than 5 minutes earlier. In other words, once every 5 minutes, a duplicate of an existing notice could be generated.

From now on, before a new notice is generated, the previous notice with the exact same message will be cleared.

> [!NOTE]
> If a notice older than 7 days has not yet been cleared manually, a duplicate notice might still be generated.

#### Service & Resource Management: Enhanced file cleanup when removing service definitions \[ID_22706\]

When a service definition with a generated contributing service protocol is deleted, then the generated protocol, the function definitions of the generated protocol and the SrmGenerationInfo object for the generated protocol will now also automatically be deleted.

Also, all profile parameters containing references to parameters of the generated protocol will have those references removed.

> [!NOTE]
> Deleting a service definition with a generated contributing service protocol will fail if function definitions of the generated protocol are in use.

#### DataMiner Cube - Trending: Enhanced performance when rendering trend graphs that display frequently changing average trend data \[ID_22732\]

Because of a number of enhancements, overall performance has increased when trend graphs are rendered that display frequently changing average trend data.

#### DataMiner Cube: Enhanced logging when UI thread gets frozen \[ID_22745\]

When the UI thread gets frozen, from now on, its stack trace will be logged.

#### Service & Resource Management: Enhanced performance \[ID_22781\]

Because of a number of enhancements, overall performance has increased when resources are created.

#### Analytics parameter change queue will now be cleared when Analytics is disabled \[ID_22818\]

From now on, the Analytics parameter change queue will be cleared when Analytics is disabled.

Also, Analytics will now automatically be disabled when an error of type ERROR_INVALID\_USER_BUFFER occurs.

#### Monitoring & Control app: Reduced initial load time \[ID_22877\]

The way the Monitoring & Control app is initially loaded has been improved, resulting in a shorter load time.

#### Administrative updates of history set alarms will now inherit the alarm time of the last parameter value change \[ID_22919\]

From now on, administrative updates (i.e. alarms of type “Properties Changed”, “Service impact changed”, “View impact changed” and “Name Changed”) of history set alarms will inherit the alarm time of the alarm where the value of the parameter in question was last changed.

#### DataMiner Cube - Scheduler: CPE reports now based on view tables instead of base tables \[ID_22958\]

When, in Scheduler, you configured a CPE report in an email action, up to now, that report was based on the base tables in the CPE element. From now on, if view tables are present in the CPE element, the report will be based on those view tables instead.

#### HTML5 apps: Enhanced drop-down box behavior \[ID_22968\]

In HTML5 apps like Jobs and Dashboards, drop-down box behavior has been enhanced, especially with respect to how auto-complete suggestions are being displayed.

#### DataMiner Cube - Backup: An information event will now be generated when no network path was specified for a particular Agent \[ID_22991\]

When, on the page *System Center \> Backup \> General*, you selected the options *Store the backups on a network path* and *Use a different network path for each Agent* without selecting all Agents in the list below, up to now, after a backup operation, an alarm was generated, saying that errors had occurred while taking the backup.

From now on, instead of an alarm, an information event will be generated containing the following message: “Path not specified for this agent, no backup was taken”.

#### Masking of virtual functions now possible \[ID_23033\]

It is now possible to mask virtual functions via Automation scripts. Previously it was only possible to mask the main element.

#### NT_UPDATE_PORTS_XML (128) updated to limit information events and allow new option \[ID_23052\]

When labels are updated on a matrix element with the Notify DataMiner call NT_UPDATE_PORTS_XML (128), now at most one information event will be generated with parameter description "Link File" and value "edited by ...".

If this call is used to perform a bulk set, an additional option can now be specified to indicate that a parameter of type "discreet info" should not be triggered, so that this parameter does not trigger a QAction unnecessarily.

For example:

```csharp
elementInfo[labelCount] = new uint[5] { changeType, elementId, uiMatrixPid, dataminerId, Convert.ToUInt32((int)UpdateType.UpdateFileAtOnceNoDiscreetInfoTrigger) };
```

#### SLDataGateway is now capable of performing asynchronous DELT import operations \[ID_23063\]

From now on, the SLDataGateway process will be capable of performing asynchronous DELT import operations.

#### DataMiner Backup: 'Configurations' folder is now included in backup packages \[ID_23114\]

The following DataMiner folder is now also included in backup packages:

- C:\\Skyline DataMiner\\Configurations

#### Web Services API v1: Enhanced performance due to view caching \[ID_23116\]

From now on, SLNet’s ViewInfoEventMessages and ViewStateEventMessages will be cached in a view cache. As all web methods requesting views will use this view cache, overall performance will increase when using those methods.

#### DataMiner Cube: Alarm cards will now highlight changed properties \[ID_23118\]

From now on, when you open an alarm of type “Property Changed”, the changed property (or properties) will be highlighted.

#### SLAnalytics: Enhanced memory management \[ID_23134\]

Due to a number of enhancements, overall memory management in the SLAnalytics process has improved.

#### SLAnalytics: Enhanced caching mechanism \[ID_23184\]

Due to a number of enhancements, the caching mechanism of the SLAnalytics process has improved.

#### Incorrectly named log files have been renamed or removed \[ID_23222\]\[ID_23560\]

The names of the following log files did not follow the DataMiner log file naming conventions. They have either been renamed or removed. Log entries that were written to a file that was removed, will now be written to another file instead.

| Log entries written to...      | will now be written to...        |
|--------------------------------|----------------------------------|
| Mobile Gateway.txt             | SLGSMGateway.txt                 |
| SLProtocolManager.txt          | SLNet.txt                        |
| SNMPAgent.txt                  | SLSNMPAgent.txt                  |
| TicketingMessageRedirector.txt | SLTicketingMessageRedirector.txt |
| UIProvider.txt                 | SLUIProvider.txt                 |

#### Improved connection behavior HTML 5 apps \[ID_23223\]

All the DataMiner HTML5 apps (Monitoring, Dashboards and Jobs), will now fall back to polling when WebSockets are disabled on the Agent. When WebSockets get enabled on the Agent, existing subscriptions that are using polling but can use WebSockets will stop polling and start a WebSocket connection instead.

#### HTML5 apps: Enhanced performance when running interactive Automation scripts \[ID_23312\]

Due to a number of enhancements, overall performance has improved when running interactive Automation scripts from inside HTML5 apps (Dashboards, Jobs, etc.).

#### DataMiner Cube - Alarm Console: Alarm actions will now use the root alarm ID instead of the alarm ID \[ID_23377\]

When, in the Alarm Console, you perform one of the below-mentioned alarm actions, the alarm update request sent to the DataMiner Agent will now contain the root alarm ID instead of the alarm ID.

- Add comment
- Clear alarm
- Force release ownership
- Mask
- Release ownership
- Take ownership
- Unmask

#### Alerter: 'Take ownership' action will now use the root alarm ID instead of the alarm ID \[ID_23379\]

When, in Alerter, you perform the “Take ownership” action, the alarm update request sent to the DataMiner Agent will now contain the root alarm ID instead of the alarm ID.

#### Ticketing: No more information events for third-party ticketing updates \[ID_23380\]

When tickets are updated in a third-party ticketing system, DataMiner will no longer generate an information event mentioning these updates.

#### DataMiner Cube - Visual Overview: Improved performance \[param:\] placeholder \[ID_23428\]

Performance has improved when the \[param:\] placeholder is used in Visio.

#### DataMiner Cube - Visual Overview: Enhanced processing of crosspoint updates in shapes linked to matrices \[ID_23445\]

Due to a number of enhancements, processing of crosspoint updates in shapes linked to matrices has been improved.

#### HTML5 apps: Enhanced performance due to shared communication layer \[ID_23541\]\[ID_23871\]

The HTML5 apps (Dashboards, Jobs, etc.) now use a newly developed, shared communication layer, which will considerably enhance their overall performance.

#### Element ID and QAction ID logged in SLNet log file when QAction sends a message to SLNet \[ID_23564\]

When a QAction sends a message to SLNet, from now on, the element ID and the QAction ID will be logged in the SLNet log file.

#### WatchDog log entries now provide more information in case of run-time errors \[ID_23708\]

Up to now, log entries stored in SLWatchDog2.txt due to a run-time error contained only the name of the process and the name of the thread. From now on, if possible, they will also contain the ID of the process and the ID of the thread.

#### Service & Resource Management: Enhanced performance when opening Services app and Bookings app \[ID_23765\]

Due to a number of data loading enhancements, overall performance has increased when opening the Services app or the Bookings app, especially on systems with a large number of services and bookings.

#### DataMiner Cube - Visual Overview: No more logging if no highlight direction can be found for connections \[ID_23973\]

When highlighting of DCF connections was configured in a Visio drawing but no specific direction could be found for a connection, up to now, log entries were added to the Cube logging. However, as this could cause many unnecessary log entries, this will now no longer be logged.

#### Enhanced performance when passing parameter changes to clients \[ID_23808\]

Due to a number of enhancements, overall performance has increased when passing parameter changes to client applications.

#### Service & Resource Management: Enhanced concurrency verification \[ID_23832\]

Due to a number of enhancements, concurrency verification performed when scheduling a resource instance has been improved.

#### DataMiner Cube - Service & Resource Management: Enhanced profile management \[ID_23861\]

A number of enhancements have been made with regard to the management of profile definitions, profile instances and profile parameters.

#### DataMiner Cube: Selected Visual page now expands in card side panel \[ID_23873\]

When the root Visual page is selected in DataMiner Cube, it will now expand in the card side panel to show its immediate child pages.

#### Enhanced performance when requesting spectrum trend data from SLNet \[ID_23971\]

Due to the introduction of a dedicated cache, overall performance has increased when requesting spectrum trend data from SLNet using GetSpectrumTrendTraceTimestampsMessage and GetSpectrumTrendTraceDataMessage.

#### Services app: Service definition diagram enhancements \[ID_23985\]

In the *Services* app, a number of enhancements have been made to the diagrams that graphically visualize service definitions.

Also, when you embed the Services app in Visual Overview by using a Service Manager component, it is now possible to have that component display node IDs. To do so, add the following option to the *ComponentOptions* shape data field:

| Shape data field | Value              |
|------------------|--------------------|
| ComponentOptions | “ShowNodeIDs=true” |

#### Enhanced performance when reading data from an Elastic database \[ID_23994\]

Due to a number of data serialization enhancements, overall performance has increased when reading data from an Elastic database.

#### IIS URL Rewrite module will now automatically be installed during a DataMiner upgrade \[ID_24022\]

The IIS URL Rewrite module will now automatically be installed during a DataMiner upgrade.

#### Cassandra service: Restart time-out increased from 10 seconds to 5 minutes \[ID_24084\]

When the Cassandra service goes down, DataMiner automatically attempts to restart the service.

The time-out for the Cassandra service to change from “starting” to “started” has now been increased from 10 seconds to 5 minutes. Also, if a restart attempt fails or times out after 5 minutes, DataMiner will now keep trying indefinitely every 60 seconds.

Logging has also been improved. Each time a restart attempt has failed, an error will now be added to the log.

#### Cassandra service: Startup time-out increased from 10 seconds to 5 minutes \[ID_24088\]

When the Cassandra service is down while DataMiner is starting up, DataMiner will automatically attempt to start the service.

The time-out for the Cassandra service to change from “starting” to “started” has now been increased from 10 seconds to 5 minutes.

- If DataMiner is not able to start the Cassandra service in 5 minutes, it will start up in file offload mode with all elements in an error state.

    > [!NOTE]
    > Starting the Cassandra service by hand requires a full DataMiner restart.

- If DataMiner is able to start the Cassandra service, but not to establish a database connection, DataMiner will try to establish a connection for the number of times specified in the following Db.xml setting:

    ```xml
    <DataBase active="true" local="true" type="Cassandra">
      <ConnectionRetries>60</ConnectionRetries>
    </DataBase>
    ```

#### Service & Resource Management: Enhanced performance when opening the Services app or Profiles app \[ID_24112\]

Due to a number of enhancements, overall performance has increased when opening the Services app or the Profiles app on systems with a large number of service definitions and profile definitions.

#### DataMiner Cube: Enhanced performance when drawing card breadcrumbs \[ID_24151\]

Due to a number of enhancements, overall performance has increased when drawing the breadcrumbs at the top of a card.

#### DataMiner Cube - Automation/Correlation: Width of action dialog boxes will now automatically be adapted to the size of the screen \[ID_24190\]

From now on, when you configure actions in Automation scripts or Correlation rules, the action dialog boxes will automatically adapt their width to the size of the screen.

#### Run-time errors will now be generated when SLDataMiner halts while executing start, stop or restart actions for elements \[ID_24228\]

When, for whatever reason, SLDataMiner should halt while executing start, stop or restart actions for a particular element, from now on, a run-time error will be generated.

#### DataMiner Cube - Services app: Service list will no longer be initialized when Visual Overview only shows the service definition editor \[ID_24242\]

From now on, the services list in the Services app will no longer be initialized when Visual Overview only shows the service definition editor.

#### A notice will now be generated when the parameter update stack of SLElement exceeds 5000 items \[ID_24259\]\[ID_24980\]

A notice will now be generated a minute after the parameter update stack of SLElement has exceeded 5000 items.

As soon as the number of items in that stack drops below 1000, the notice will be cleared automatically.

#### DataMiner Cube: Enhanced performance when generating authentication tickets for embedded web browsers \[ID_24261\]

Due to a number of enhancements, overall performance has increased when generating authentication tickets for embedded web browsers in apps like Ticketing, Dashboards, Maps, etc.

#### Service & Resource Management: Enhanced performance when saving and synchronizing resources \[ID_24289\]

Due to a number of enhancements, overall performance has increased when saving resources and synchronizing them among the agents in the DataMiner System.

#### DataMiner Maps: Enhanced performance when opening a pop-up balloon \[ID_24292\]

Due to a number of enhancements, overall performance has increased when opening a pop-up balloon.

#### Improved logging when uploaded protocol requires higher DataMiner version \[ID_24298\]

Logging has improved when a protocol is uploaded that requires a higher DataMiner version than the one currently installed in the system. The following error message will now be logged: "DataMiner version is too low to use this protocol. Please check the protocol's Compliancies tag."

#### DataMiner Cube - Visual Overview: Enhanced performance when using 'FollowPathColor' and 'InternalInterfaceHopping' \[ID_24305\]

Due to a number of enhancements, overall performance has increased when using “FollowPathColor” and “InternalInterfaceHopping”, especially when a large number of shapes are linked to elements containing many interfaces and connections.

#### HTML5 apps: Enhanced icons \[ID_24341\]

All HTML5 apps (Dashboards, Monitoring, Jobs, etc.) now have enhanced icons.

#### Service & Resource Management: Enhanced processing of event messages related to ReservationInstances and ReservationDefinitions \[ID_24350\]

Due to a number of enhancements, the processing of event messages related to ReservationInstances or ReservationDefinitions has improved.

#### Elements updated using an AddElementMessage will no longer be restarted by default \[ID_24370\]

When an element is updated using an AddElementMessage, from now on, that element will only be restarted if one or more of the following properties were changed:

- Bus address
- Element state
- IP
- Poll settings
- Port info
- Protocol name
- Protocol version
- Replication info
- SNMP info

#### DataMiner Cube: Enhanced breadcrumbs on service cards \[ID_24408\]

A number of enhancements have been made to the way in which breadcrumbs are displayed when you open a service cards.

#### HTML5 apps: More consistent layout due to shared UI components \[ID_24414\]

The overall layout of the different HTML5 apps has been made more consistent.

#### DataMiner Cube - Visual Overview: Improved performance when using \[param:\] placeholder \[ID_24493\]

When a \[param:\] placeholder is used in Visio, the way parameters are retrieved has been improved, resulting in improved performance.

#### Web Services API v1: Unused method and arguments removed \[ID_24530\]

The method *GetClusterAsync*, which could not yet be used, has been removed from the Web Services API v1. In addition, a number of fields that also could not yet be used have been removed. The following fields have been removed from the *DMAAutomationScriptSettings* object:

- DebugMode
- AllowUndef
- SupportsBackAndForward
- SkipElementChecks
- SavedFromCube
- SkipSetInfoEvents

The following fields have been removed from the *DMAScatterAxisInfo* object:

- ParameterID
- TableIndex

#### Service & Resource Management: Enhanced performance when updating active function definitions \[ID_24554\]

Due to a number of enhancements, overall performance has increased when updating active function definitions.

#### DataMiner Cube: Activity panel layout enhancements \[ID_24592\]

In the Activity panel, a number of small layout enhancements have been made, especially with regard to spacing between icons and text.

#### DataMiner Cube - Visual Overview: Signal path update enhancements \[ID_24599\]

Due to a number of enhancements, overall performance has increased when updating signal paths.

#### Rollback packages will no longer be created during a DataMiner upgrade \[ID_24614\]

During a DataMiner upgrade, a rollback package will no longer be created.

To downgrade to a specific DataMiner version, from now on, it will suffice to install the full installation package of that earlier DataMiner version.

> [!NOTE]
> In the DataMiner Taskbar Utility, the *Rollback* option has also been removed from the *Maintenance* menu.

#### DataMiner Cube: Enhanced 'Back' buttons in card headers and browser controls \[ID_24693\]

In card headers and browser controls, the *Back* button will now always be visible, either enabled or disabled.

Also, the layout of WFM card headers has been optimized.

#### DataMiner Cube: Enhanced app icons \[ID_24718\]

In DataMiner Cube, the layout of all app icons has now been enhanced.

#### Service & Resource Management: Enhanced performance when deleting service definitions \[ID_24860\]

Due to a number of enhancements, overall performance has increased when deleting service definitions, especially on systems with a large number of booking instances.

#### Outdated version number removed from DataMinerCubeStandAlone web page \[ID_24871\]

Up to now, the following HTML file contained an outdated DataMiner Cube version number. That number has now been removed.

- C:\\Skyline DataMiner\\Webpages\\DataMinerCubeStandalone\\publish.htm

#### DataMiner Cube - Side bar: Enhanced loading of app icons in App list \[ID_24891\]

Due to a number of enhancements, overall performance has increased when loading the app icons in the Apps list.

#### Maximum upload size for upgrade packages increased from 500 MB to 4,000 MB \[ID_24922\]

The maximum upload size for upgrade packages has increased from 500 MB to 4,000 MB.

#### DataMiner backup: Full backup now includes booking data stored in Indexing Engine \[ID_24766\]

When you take a full backup of your DataMiner System, from now on, the booking data stored in Indexing Engine will also be included.

#### Failover: Prevent new elements from receiving the same ID as a deleted element or a disabled function \[ID_25306\]

From now on, when a DataMiner Agent in a Failover setup goes online, SLDataMiner will now retrieve the highest element ID from dataminer.xml. This will prevent new elements from receiving the same ID as an element that was deleted or a function that was disabled.

### Fixes

#### Not possible to assign Visio file to imported view or service \[ID_19280\]\[ID_20207\]

If a service or view had been imported via a .dmimport package, it could occur that it was not possible to assign a Visio file to it.

#### DataMiner Cube - Trending: Enabling or disabling statistics would not update the trend graph \[ID_19358\]

When, in the Statistics window of a trend graph, you enabled or disabled one of the checkboxes (Average, Mean deviation, etc.), in some cases, the trend graph would not be updated unless you forced a redraw by panning or zooming.

#### Service & Resource Management - Service Chain: Problem when restarting an element \[ID_19368\]

When a service chain setup contained a connection property shape, in some cases, an exception could be thrown when you restarted an element in the chain.

#### DataMiner Cube: Function name displayed incorrectly on alarm card \[ID_19583\]

On the alarm card of an alarm with a function impact, it could occur that the name of the function was not displayed correctly if it contained several underscores.

#### Problem with SLAnalytics when opening a trend graph \[ID_19603\]

When you opened a trend graph, in some rare cases, an error could occur in SLAnalytics causing the graph to not show any prediction.

#### Parameters with RTDisplay set to false also processed by Analytics \[ID_19660\]

Up to now, DataMiner Analytics incorrectly also took parameters into account that had RTDisplay set to false, which could cause errors to be displayed in the SLAnalytics logging.

#### Default service card page setting not applied for visual page of SRM service \[ID_19674\]

If the default service card page was set to “Visual page” in the user settings, for an SRM service, it could occur that this setting was not applied.

#### DataMiner Cube: Exception when opening alarm card with service impact from removed SRM service \[ID_19679\]

If there was an alarm on the function DVE of a service booking instance, and the service was deleted at the end of the booking, it could occur that an exception was thrown when you opened the alarm card of one of the alarms affected by this service.

#### Service & Resource Management: Problem with removal of DCF entry point connections \[ID_19728\]

When, in setups with multiple entry points, an entry point connection was removed, in some cases, the connections of all entry points would be removed.

#### DataMiner Cube: Incorrect alarm filter after dragging an item onto the Alarm Console \[ID_19750\]

In some cases, dragging an item onto the Alarm Console would change the alarm filter you applied earlier.

#### Spectrum Analyzer component not loading correctly in HTML5 app \[ID_19812\]

In the HTML5 app, it could occur that the spectrum trace could not be displayed for Spectrum Analyzer components that did not have a reference level or reference scale set.

#### Trending - SLAnalytics: Trend predictions did not take into account the most recent trend data \[ID_19832\]

When you opened a trend graph, in some cases, trend predictions would not take into account the most recent trend data.

#### SLAnalytics: Alarm limits containing exception values could not be parsed correctly \[ID_19911\]

In some cases, alarm limits containing exception values could not be parsed correctly.

#### Problem with SLSNMPAgent process \[ID_20278\]

In some cases, an error could occur in SLSNMPAgent when an element was added, deleted or stopped.

#### Enhanced services did not receive currently active alarms after being restarted \[ID_20328\]

When an enhanced service was restarted (e.g. by editing the protocol), in some cases, it would not receive the currently active alarms when *Monitor Active Alarms* was enabled.

#### DataMiner Connectivity Framework: Problem deleting a connectivity chain throughout a DataMiner System \[ID_20343\]

In some cases, it was not possible to delete a connectivity chain throughout an entire DataMiner System using a DeleteConnectivitySettingsMessage.

#### Service & Resource Management: No enhanced service element created after update protocol ID for existing booking instance \[ID_20430\]

In the Service & Resource Management module, if the protocol ID was updated for an existing booking instance via the *AddOrUpdateReservationInstances* method, it could occur that no corresponding enhanced service element was created.

#### Web Services API v1: GetValuesForCPETopologyField method not returning values \[ID_20483\]

In some cases, it could occur that the *GetValuesForCPETopologyField* method did not return any values, even though values were available.

#### DataMiner Cube: Problem when exporting redundancy group \[ID_20519\]

In some cases, an issue could occur when a redundancy group was exported to a .dmimport package. In particular, when a redundancy group contains a condition involving a virtual primary element from a different redundancy group, that redundancy group will now also be included in the export package.

#### Problem with masking until clearance of parameter or cell \[ID_20553\]

In some cases, when a parameter or cell were set to be masked until an alarm on that parameter or cell was cleared, it could occur that they remained masked even after the alarm was cleared.

#### Not possible to assign alarm template to enhanced service \[ID_20580\]

In some cases, it could occur that it was not possible to assign an alarm template to an enhanced service.

#### DMS Reporter: Incorrect top 10 report if service had elements on different DMAs \[ID_20628\]

If a report was configured to display the top 10 services that spent the largest percentage of time in an alarm state, and the elements in a service were spread over multiple DMAs, it could occur that the report was not generated correctly.

#### Profile Manager: Problem when creating a profile parameter entry \[ID_20670\]

In some cases, an exception could be thrown when a profile parameter entry was created.

#### DataMiner upgrade: Problem when QActions were found without 'encoding' attribute \[ID_20673\]

In some cases, during an DataMiner upgrade, an exception could be thrown when a QAction was found that did not have an “encoding” attribute.

#### Problem when updating a view property with its current value \[ID_20693\]

In some cases, an exception could be thrown when a view property was updated with the value it had before the update.

#### SLAnalytics: Problem when multiple messages were sent simultaneously to SLNet \[ID_20703\]

In some rare cases, an exception could be thrown when multiple messages were sent simultaneously to SLNet in SLAnalytics.

#### Service & Resource Management: Serialization exception when object configuration was specified on service definition node \[ID_20720\]

When an object configuration was specified on a service definition node, this could result in a serialization exception.

#### Failover: Profile Manager data only synchronized at next DataMiner restart \[ID_20825\]

When a Failover switch was performed, in some cases, changes made to Profile Manager data would not be synchronized until the next DataMiner restart.

#### Failover: New service definitions would not be visible in the Service Manager app after a Failover switch \[ID_20832\]

When a Failover switch was performed, in some cases, newly created service definitions would not be visible in the Service Manager app.

#### Element would not go into an error state when the creation of a logger table failed \[ID_20859\]

When the creation of a logger table failed, in some cases, the element in question would not go into an error state.

#### Correlation: No correlated alarm created when using a 'new alarm' correlation action with severity 'Lowest severity of source alarms' \[ID_20917\]

When using a correlation rule with a “new alarm” action and severity set to “lowest severity of source alarms”, in some cases, no correlated alarm would be created when the alarm with the lowest severity was a normal alarm. In this kind of situation, from now on, the second lowest severity will be taken.

#### SLLogCollector process stopped upon DMA restart \[ID_20939\]

Previously, when a DMA was restarted, it could occur that the SLLogCollector process was stopped, causing DMS log information to be lost. This will no longer occur.

#### DataMiner Cube - System Center: Problem with user credentials sharing the same name \[ID_20999\]\[ID_21011\]

When, in System Center, you created a credential in the credential library, up to now, DataMiner Cube would incorrectly only compare the name of the new credential to those of the existing names in the same group. As a result, when another user created a credential with the same name in another group, no error would appear. The DataMiner Agent, on the other hand, would not save the credential.

From now on, when user create a credential of which the name is identical to that of an existing credential, an error will appear.

#### Service & Resource Management: Problem when reserving services and enhanced services \[ID_21007\]

In a DataMiner System, in some cases, IDs of services and enhanced services would be reserved twice due to a synchronization issue.

#### When an alarm filter or a trend filter was changed, the old filter was not added to the recycle bin \[ID_21030\]

When you changed a trend filter or an alarm filter, up to now, the XML file containing the old filter would not be added to the recycle bin.

#### DataMiner Upgrade: Problem with upgrade action that reformats GPIB port settings \[ID_21115\]

In some cases, the upgrade action that reformats GPIB port settings would not process disabled bus addresses incorrectly.

#### Problem with mask state of alarm after deleting and re-adding a row containing a masked cell \[ID_21278\]

When you deleted a table row with a masked cell, added that row again, and then unmasked the masked cell of the new row, the alarm would incorrectly stay masked until an alarm update was generated.

#### Problem when generating an enhanced service protocol \[ID_21283\]

When an enhanced service protocol was generated, in some cases, some of the generated parameters would incorrectly be placed on the same Data Display position.

#### Failover: Problem with incorrect database messages \[ID_21305\]

In a Failover setup without Cassandra or Indexing databases, in some cases, messages related to Cassandra or Indexing databases would incorrectly appear.

#### DataMiner Cube: Problem when choosing to recreate an element after changing its protocol \[ID_21316\]

When, after changing the protocol of an existing element, you chose to make Cube recreate the element by deleting the existing element and then creating a new element with a new element ID, in some cases, the existing element would be deleted, but no new element would be created.

#### Problem with SLElement when a masked element was stopped the moment it was automatically unmasked after a certain period \[ID_21317\]

In some cases, an error could occur in SLElement when an element, which had been masked for a certain period of time, was stopped the moment it was automatically unmasked.

#### Service & Resource Manager: Time zone difference not taken into account when checking for available resources \[ID_21318\]

When a client requested an available resource from the server, the possible time zone difference between client and server was not taken into account, which could lead to incorrect results.

#### DataMiner Cube - Visual Overview: 'ClosePage' option not working on subshape or shape on embedded page \[ID_21481\]

If a subshape within a group or a shape on an embedded page was configured with the *ClosePage* option, it could occur that this option did not work correctly.

#### DataMiner Cube - Trending: Exception values incorrectly taken into account when calculating statistical values \[ID_21593\]

When you opened the statistics window of a trend graph containing exception values, in some cases, those exception values would incorrectly be taken into account when calculating the statistical values (average, minimum, maximum).

#### Mobile Gateway: Problem when setting the cellphone location \[ID_21617\]

In some cases, an exception could be thrown when setting the location of the Mobile Gateway.

#### Sending GetInfoMessage of type 'IndexingConfiguration' incorrectly returned the indexing engine configuration of all DataMiner Agents \[ID_21770\]

When a GetInfoMessage of type “IndexingConfiguration” was sent containing one specific DataMiner ID, the indexing configuration of all DMAs would incorrectly be returned.

From now on, only the indexing configuration of the specified DMA will be returned, except when the DataMiner ID in the GetInfoMessage request was equal to -1.

#### CPE Manager: Empty top filters after item selection in lowest filter \[ID_21821\]

In some cases, it could occur that the top filters of the CPE topology remained empty if an item had been selected in the filter at the lowest level first.

#### DataMiner Cube - Logging: Problem when trying to open a log entry \[ID_21676\]

When you opened the *Logging* window by clicking the *Logging* button in the bottom-right corner of Cube’s login screen, selected a log entry and clicked *Open*, in some cases, the log entry would not be opened.

Also, a number of minor enhancements have been made to the *Logging* window.

#### DataMiner Cube - Logging: Log entry pop-up window not resized when Cube was resized \[ID_21756\]

When, in the *Logging* section of System Center (or the *Logging* window opened on Cube’s login screen), you opened a log entry in a pop-up window, in some cases, that log entry pop-up window would incorrectly keep its same size when you resized DataMiner Cube. From now on, log entry pop-up windows will be resized when you resize DataMiner Cube.

#### DataMiner Cube - Reports: Problem with 'top X' reports \[ID_21778\]

In some cases, in DataMiner Cube, the “top X” reports, which you find e.g. in a view card under *Reports \> More \> Top*, would incorrectly list the “bottom X” items instead of the “top X” items.

#### SNMP polling with V3 HMAC-MD5 or HMAC-SHA authentication algorithms caused memory leak in SLSNMPManager \[ID_21788\]

When SNMP polling was used with V3 HMAC-MD5 or HMAC-SHA authentication algorithms, a memory leak could occur in one of the SLSNMPManager processes.

#### DataMiner Cube - Visual Overview: Clicking a shape configured to perform a parameter set would cause shape text to be copied instead \[ID_21818\]

When a shape displayed some text and was configure to perform a parameter set when clicked, in some cases, clicking that shape would incorrectly cause the text displayed on that shape to be copied rather than cause the parameter set to be executed.

#### Incorrect analytics trend arrows \[ID_21851\]

In some cases, after SLAnalytics was shut down, it could occur that records for the trend arrows were not correctly stored in the database, which could cause Cube to display incorrect trend arrows.

#### DataMiner Cube - Visual Overview: Trend graph would not be properly refreshed when a dynamic placeholder was updated \[ID_21890\]

When, in a data item of type “Parameters” or “ParametersOptions” of a shape displaying a trend graph, a dynamic placeholder was updated, in some cases, the trend graph would not be properly refreshed.

#### No mask comment added to newly created alarms for masked table rows or table row cells \[ID_21927\]

When a new alarm was generated for a masked table row or table row cell, in some cases, no mask comment would be added to that new alarm.

#### Service & Resource Management: Problem with license (number of concurrent bookings) \[ID_21970\]

When the maximum amount of bookings had been scheduled, in some cases, it would not be possible to edit one of those bookings.

#### DataMiner Maps: Dynamic data in \<Detail> tags would be overwritten \[ID_22009\]

In some cases, dynamic data in \<Detail> tags would be overwritten, resulting in incorrect and/or missing placeholder values.

#### Monitoring & Control app: No data in legend for trend graph with gap \[ID_22032\]

In some cases, if a trend graph contained a gap between two trend points, no data was displayed in the legend for that trend graph for a section that was larger than the actual gap.

#### Reporter: Export to Excel/CSV did not contain all rows of a partial table \[ID_22069\]

When, in Reporter, you exported a report to an XLS or CSV file, in some cases, that file would not contain all rows of a partial table. From now on, the exported file will be able to contain up to 1 million rows.

> [!NOTE]
> When you export a report to an HTML or MHT file, that file will display only the first page of a partial table (using the page size configured in the protocol).

#### DataMiner Cube - Service & Resource Management: Caching issue with reservation instances that were more than 21 days in the future \[ID_22091\]

Previously, reservation instances with a start time of more than 21 days in the future were not cached. However, this could result in issues when such an instance was created and then quickly retrieved afterwards. Now the 500 most recently saved instances outside the default cache period of 21 days will be cached too.

#### Problem with alarms not impacting a virtual function \[ID_22127\]

In some cases, alarms would not impact a virtual function without an entry point.

#### DataMiner Cube - CPE: Incorrect table filtering due to deprecated option 'oldFiltering' \[ID_22201\]

In some cases, CPE tables would be filtered incorrectly when using the deprecated option “oldFiltering”.

#### DataMiner Cube - CPE: Opening a CPE object in another chain did not clear all filters of the destination chain before selecting the new item \[ID_22217\]

When you opened a CPE object in another chain using the right-click menu on the CPE diagram item, not all filters would be cleared in the destination chain before the new item was selected.

#### Ticketing: Ticket properties not refreshed after updating a ticket \[ID_22322\]

When you updated a ticket, in some cases, the ticket properties would not get refreshed.

#### DataMiner Agent would not notify the client when objects were unmasked when the masking period elapsed \[ID_22354\]

When, after you had masked a DataMiner object for a period of time, the object and its child items were automatically unmasked when the masking period elapsed, in some cases, the DataMiner Agent would not notify the client application. As a result, the client application would incorrectly continue to show the items as masked.

#### When a DataMiner object was masked for a period of time, not all child object would be unmasked when the masking period elapsed \[ID_22395\]

When you masked a DataMiner object for a period of time, and that object had multiple alarms, in some cases, not all those alarms would be unmasked when the masking period elapsed.

#### Ticketing: Problem when updating a ticket \[ID_22420\]

In some cases, an exception could be thrown when you updated a ticket.

#### DataMiner Cube - Visual Overview: WCF connection timeout caused 'Failed' message to appear after clicking 'Edit in Visio' \[ID_22426\]

When, in Cube, you had clicked *Edit in Visio*, after ten minutes of inactivity, a WCF connection timeout could cause a “Failed” message to appear.

From now on, when you click *Edit in Visio*, a heartbeat mechanism will prevent WCF connections from going into timeout.

#### DataMiner Cube - Cards: 'REPORTS \> More' page missing \[ID_22500\]

When you expanded the *REPORTS* page in a card’s navigation page, in some cases, there was only one subpage named *General*. The other subpage, named *More*, would be missing.

#### Problem with information events not being migrated from MySQL to Cassandra \[ID_22515\]

During a migration from MySQL to Cassandra, in some cases, information events would not get migrated.

#### Problem with topology alarm properties in case of recursive directview/view tables \[ID_22530\]

When a topology cell was defined on a direct view table, in some cases, the alarm properties would not be filled in if view tables defined between the data table and the direct view table.

#### DataMiner Cube: Incorrect sorting of direct view tables and view tables with columns containing data retrieved from other tables \[ID_22537\]

In some cases, direct view tables and view tables with columns containing data retrieved from other tables would be sorted incorrectly.

#### SLAnalytics: Unresolved placeholder in debug log entries \[ID_22612\]

In some cases, debug log entries would incorrectly contain a “%s” placeholder instead of the element ID.

#### Service & Resource Management: Discrete parameters not displayed correctly in contributing services \[ID_22614\]

In a contributing service, it could occur that discrete parameters were not displayed correctly. The way profile parameters are handled in the SRM module has now been enhanced, so that discrete parameters can be included correctly in contributing services. Note that this change could cause some loss of data if you upgrade to this version of DataMiner and then downgrade again.

#### DataMiner Cube: CPE views cards no longer showed child objects after a DELT export had been launched \[ID_22621\]

After a DELT export had been launched, in some cases, the navigation pane of a CPE view card would no longer show any child objects.

#### Service & Resource Management: Duplicate booking instances after midnight sync \[ID_22639\]

A problem could occur when SRM data were synchronized during the daily midnight sync of a DMS, causing duplicate booking instances.

#### Problem when taking a backup containing Elastic data \[ID_22653\]

When taking a backup containing Elastic data, in some cases, a problem could occur when an Elastic index contained a dot (“.”).

#### Child elements were not notified when they exported a parameter impacted by a change to Description.xml or Port.xml \[ID_22654\]

As changes to element files like Description.xml and Port.xml can impact parameters, elements are notified when one of their parameters is impacted by such a file change.

However, up to now, child elements (e.g. DVE elements or virtual functions) would not receive any such file change notification. From now on, child elements will also receive file change notifications when they export parameters that are impacted by a particular file change.

#### Problem after stopping an element that stored data into an Indexing database and restarting the DataMiner Agent \[ID_22656\]

When a DataMiner Agent was restarted after an element that stored data into an Indexing database was stopped, in some cases, an exception could be thrown.

#### Web Services API v1: Problem with DMAParameter.IsTrending \[ID_22684\]

When a parameter had its trending attribute set to “true” in the protocol.xml, in some cases, when that parameter was passed by a web method, its IsTrending property would be “true”, even if it was not being trended in the element in question.

#### Resources app: New properties not available for existing resources \[ID_22693\]

In the Resources app, it could occur that if new properties were created, these were not available for existing resources.

#### DataMiner Cube: Memory leak when opening CPE cards \[ID_22694\]

When you opened a CPE card with a Visio file that showed tables in shapes, but you did not navigate to Visual Overview, in some cases, a memory leak could occur.

#### Service & Resource Management: Problem with Profile Manager when filtered subscriptions were being used \[ID_22698\]

In some cases, the Profile Manager could throw an exception when filtered subscriptions were being used.

#### DataMiner Cube - Alarm Console: Incorrect time range shown when editing a history tab page \[ID_22699\]

When you clicked the pencil icon of a history tab page in order to edit that tab page, in some cases, the time range would be filled in incorrectly.

#### DataMiner Cube - Visual Overview: Problem when closing a Visual Overview \[ID_22711\]

In some cases, an exception could be thrown when you closed a Visual Overview.

#### Service & Resource Management: Problem when trying to open a functions.xml file \[ID_22744\]

Due to a problem with file access rights, in some cases, it would not be possible to manually open a functions.xml file for e.g. debugging purposes.

#### ProfileManagerHelper.GetProfileInstance with empty GUID returned random profile \[ID_22768\]

Previously, if the method *ProfileManagerHelper.GetProfileInstance* passed an empty GUID, a random profile was returned. Now null will be returned in this case.

#### DataMiner Cube - Alarm Console: Problem when grouping or sorting the alarms \[ID_22797\]

When the Alarm Console contained at least two alarm tab pages, and more that 50 alarms per second were received, an error could occur while grouping or sorting the alarms.

#### Inconsistent access to enhanced service elements among the agents in a DataMiner System \[ID_22798\]

In some cases, access to enhanced service elements would be inconsistent among the different agents in a DataMiner System.

#### Problem when updating the Visio file linked to a service hosted on another DMA \[ID_22814\]

In some cases, it could occur that it was not possible to update the Visio file linked to a service hosted on a DMA other than the one you were connected to.

#### Failover: Deleted ticket field resolver would re-appear after a switch-over \[ID_22822\]

When a ticket field resolver was deleted on a Failover system, in some cases, it could re-appear after a switch-over due to a caching problem.

#### Analytics: Mid-term prediction was not shown when polling frequency exceeded 1 minute \[ID_22863\]

In some cases, mid-term prediction would not be shown when the polling frequency exceeded 1 minute.

#### Spectrum Analysis: Problem when sending a SpectrumElementSpecificConfigRequestMessage \[ID_22882\]

When a SpectrumElementSpecificConfigRequestMessage was sent, in some cases, an exception could be thrown when the element.xml file of the spectrum element in question did not contain a \<SpectrumElementSpecificConfig> tag.

#### DataMiner Cube: Cards could get stuck in a 'loading' state when users had not been granted the 'Correlation/UI available' permission \[ID_22908\]

In some cases, cards could get stuck in a “loading” state when users had not been granted the “Correlation/UI available” permission.

#### DataMiner Cube - Security: List of user/group permissions was not sorted alphabetically \[ID_22939\]

When you opened System Center and navigated to the permissions of a particular user or user group, the “Bookings” permission was not displayed at the correct location in the list.

The list of permissions is now again sorted alphabetically.

#### DataMiner Cube - Visual Overview: Columns were not hidden correctly when their width was set to 0 in a 'ColumnWidth' option \[ID_22960\]

When, in a shape data field of type *ParameterControlOptions*, you added a *ColumnWidth* option in which you set the width of a particular column to 0 pixels, in some cases, that column would not be hidden correctly.

#### Reporter: Problem with CPE status report on view tables using advanced naming \[ID_22965\]

When, in Reporter, you generated a CPE status report, in some cases, tables using advanced naming would show primary keys instead of display keys.

Also, in case of custom reports, the DMS_getTableFiltered method would incorrectly return display keys when the tables in question used advanced naming.

#### HTML5 apps: Last column of a list view would incorrectly take up all remaining space \[ID_22993\]

In some cases, the last column of a list view would incorrectly take up all remaining space.

#### DataMiner Cube: Problem during startup when no connection could be made to the internet \[ID_22995\]

When DataMiner Cube was not able to connect to the internet during startup, in some cases, the UI could momentarily become unresponsive.

#### Problem with SLSNMPManager when stopping or deleting a duplicated SMNPv3 element \[ID_23006\]

When one of multiple SNMPv3 elements using identical credentials was stopped or deleted, in some cases, the remaining ones would go into timeout.

#### DataMiner Cube - Visual Overview: Problem when displaying trend graphs \[ID_23041\]

When a trend component on a Visio page was configured to display a trend graph when selecting a table index from a list of table parameter indices, in some cases, no trend graph would be displayed when you selected a table index from the list.

#### Visio: Shapes linked to enhanced service not displayed for some users \[ID_23059\]

In some cases, for an enhanced service that was part of other services, it could occur that linked shapes in Visio were not displayed for users with limited user permissions.

#### Not possible to select different drive for Cassandra installation \[ID_23068\]

In the Cassandra installation/migration wizard, it could occur that it was not possible to change the drive where Cassandra had to be installed.

#### Labels/crosspoints not displayed correctly for exported matrix parameters \[ID_23069\]

In some cases, it could occur that matrix labels and crosspoints were not displayed correctly for exported matrix parameters of virtual functions or DVE child elements. To prevent this, the *Description.xml*, *labels.xml* and *Ports.xml* files of a parent element will now be applied to its child elements.

#### Service & Resource Manager - Profile Manager: Problem during DMS startup \[ID_23070\]

In some cases, Profile Manager could throw an exception while the DataMiner System was starting up.

#### HTML5 apps: App title not always displayed correctly on login screen and/or title bar \[ID_23076\]

In some cases, the app title of an HTML5 app would not be displayed correctly on the login screen and/or the app’s title bar.

#### Problem in SLDataMiner when importing large amount of element data \[ID_23120\]

When a large amount of element data was imported, a problem could occur in the SLDataMiner process.

#### SNMP Manager sending SNMPv3 inform messages stuck in ping mode \[ID_23132\]

If an SNMP Manager in DataMiner was configured to send SNMPv3 inform messages and went into ping mode, it could occur that it remained stuck in this mode.

#### DataMiner Cube: Parameters displayed on dialog boxes had an incorrect parameter description \[ID_23167\]

When a parameter was displayed on a dialog box, in some cases, its parameter description would be incorrect.

#### Various issues with Cube breadcrumbs \[ID_23169\]

A number of issues have been resolved that could occur with the breadcrumbs at the top of cards in DataMiner Cube:

- When an object was renamed, it could occur that the name in the breadcrumbs was not updated.
- When an object had been deleted, it could occur that it was still displayed in the breadcrumbs' drop-down menu.
- For services that only contained excluded devices, it could occur that breadcrumbs were not displayed correctly.
- Breadcrumbs will no longer be displayed in upper case only.

In addition, on a view card, it could occur that the list of elements was not updated if an element was removed from the view while the card was open.

#### End time of masking operation not applied correctly \[ID_23157\]\[ID_23170\]

When a parameter was masked for a limited period of time, it could occur that the end time of the mask operation was not applied correctly.

#### DataMiner Cube - Automation: Window appearing when an Automation script fails had an incorrect caption on a Cube with custom branding \[ID_23171\]

When using a DataMiner Cube with custom branding, up to now, the window that appeared when an Automation script failed would incorrectly have the default “Skyline DataMiner” caption. From now on, on a DataMiner Cube with custom branding, the caption of that window will show the custom product name.

#### DataMiner Cube: Alarm storm prevention incorrectly enabled while being disabled in enforced group settings \[ID_23181\]

When the alarm storm prevention mechanism was enabled in the user settings but disabled in enforced group settings, in some cases, it would incorrectly be enabled.

#### SNMP Managers not respecting resend timer in system with virtual SNMP agent \[ID_23188\]

In a system that had a virtual SNMP agent configured, it could occur that the resend timer of SNMP Managers was not always respected.

#### Visio: PushContextMenu not working correctly with service chain container or a signal path container \[ID_23194\]

If the *PushContextMenu* option was used for shapes like a service chain container or a signal path container, this caused the container to become clickable and then contain all of the context menu items and actions of its children. To avoid this unintended behavior, these container shapes will no longer have any actions of their own.

#### Problem when restoring a backup containing Elastic data \[ID_23197\]

When, after re-installing the Elastic database and starting DataMiner, you took a backup containing Elastic data, in some cases, it would not be possible to restore that backup.

#### Service & Resource Management - Visual Overview: Service chain not displayed correctly \[ID_23205\]

If a Visio drawing displayed a booking service chain with its expected connections, but the booking contained resources that were not linked to an element, it could occur that the chain was not displayed correctly. Now, resources that are not linked to an element will be ignored.

#### DataMiner Cube: Problem with Element migration window \[ID_23237\]

When connected to a DataMiner System with multiple DataMiner Agents, you opened *System Center \> Agents \> Status*, clicked *Migrate*, selected a destination agent and a number of elements, and then clicked either *Migrate* to start migrating the selected elements to the selected agent or *Cancel* to exit the *Element migration* window, in some cases, an exception could be thrown.

#### DataMiner Cube - Backup: No backup made if only Elastic data was selected \[ID_23248\]

Up to now, when you made a custom backup that only contained Elastic data and no Cassandra data, no backup file would be created.

From now on, it is possible to make a backup that only contains Elastic data.

#### DataMiner installation failed when no theme was selected \[ID_23253\]

When DataMiner was installed and no theme had been selected during the setup of the installer, it could occur that the installation failed.

#### DataMiner Cube - Visual Overview: Only one shape used of source/destination shapes with same tag \[ID_23261\]

If shapes in Visio were tagged as a source or destination and multiple shapes had the same tag, only one of them would work as a source or destination. Now all shapes with matching tags will be considered a possible source or destination.

#### DataMiner Cube - Visual Overview: Automatic connection lines generated instead of connectors drawn in Visio \[ID_23295\]

In some rare cases, it could occur that connectors drawn in Visio were replaced by regular connection lines generated by Cube.

#### HTML5 apps: Problem when mouse pointer went outside the Scheduler component \[ID_23302\]

In the HTML5 apps (Dashboards, Jobs, etc.), in some cases, the Scheduler component would not react as expected when moving the mouse pointer away from it.

When you move the mouse pointer away from the Scheduler component and back, from now on, the action will either continue when the mouse button is being pressed or be canceled when the mouse button is no longer being pressed.

#### Incorrect column spans in interactive Automation script in HTML5 applications \[ID_23325\]

If an interactive Automation script was run using a HTML5 DataMiner application, it could occur that the column spans in the script were not correctly applied.

#### Service & Resource Management: First occurrence of a ReservationDefinition was incorrectly saved twice \[ID_23328\]

When, in a DataMiner System, a ReservationDefinition was saved on a non-master DMA, in some cases, the first occurrence of that ReservationDefinition would incorrectly be saved twice.

#### HTML5 apps: Problem with WebSockets \[ID_23336\]

In the HTML5 apps (Dashboards, Jobs, etc.), in some cases, the WebSocket connection could keep disconnecting and reconnecting when a user was logged off.

From now on, when users log off, the WebSocket connection will no longer be disconnected. Instead, it will be unauthenticated.

#### DataMiner Installer: Problem when installing SNMP on Windows 10 version 1809 and above \[ID_23346\]

When installing DataMiner on a system running Windows 10 version 1809 (or above), in some cases, the DataMiner Installer was not able to properly install SNMP. As a result, the installation procedure would fail.

#### Problem when taking a backup containing data stored in a remote Elastic database \[ID_23347\]

In some cases, an error could be thrown when taking a backup containing data stored in a remote Elastic database.

#### Table of virtual function element remains empty \[ID_23356\]

In some cases, it could occur that a table of a virtual function element did not contain any data.

#### SLAnalytics: Trend data older than TTL was incorrectly taken into account when calculating trend predictions \[ID_23358\]

Up to now, trend data older than the trend data TTL setting would incorrectly be taken into account when calculating trend predictions.

#### No error information when adding TicketResolver with existing name \[ID_23369\]

In a system with a Cassandra database, when you tried to add a TicketResolver with a name that was already in use, no error information was returned.

#### Service & Resource Management: Adding, updating or deleting a protocol function would cause all protocols to be fetched from the DataMiner Agent \[ID_23373\]

In some cases, adding, updating or deleting a protocol function would incorrectly cause DataMiner Cube to fetch all protocols from the DataMiner Agent.

#### DataMiner Cube - Profile Manager: Problem when configuring the default value of profile parameters of type 'discrete' \[ID_23376\]

In some cases, it was no longer possible to configure the default value of profile parameters of type “discrete”.

#### DataMiner Cube: Not possible to unmask alarm on CPE object \[ID_23392\]

In some cases, it could occur that it was not possible to unmask an alarm on a CPE object.

#### DataMiner Cube - Visual Overview: Problem with 'VerticalAlignment=Stretch' and 'HorizontalAlignment=Stretch' options \[ID_23397\]

When positioning shapes in a grid layout, in some cases, shapes would not be stretched when using the *VerticalAlignment=Stretch* or *HorizontalAlignment=Stretch* options.

From now on, these options will allow you to stretch single, non-grouped shaped.

#### Problem when exporting Elastic logger tables \[ID_23410\]

Up to now, in some cases, an error would be thrown when you tried to export an Elastic logger table.

From now on, it is possible to export Elastic logger tables, but without any data.

#### Cassandra: Problem when fetching data using a complex filter containing subfilters \[ID_23444\]

In some cases, an error could occur when fetching data from a Cassandra database using a complex filter with a number a subfilters.

#### DataMiner Cube - Indexing: Problem when searching for most suitable hard drive at the start of the Indexing Engine installation procedure \[ID_23483\]

In some cases, an exception could be thrown when searching for the most suitable hard drive at the start of the Indexing Engine installation procedure.

#### Automation: Compiled C# files saved with an incorrect file extension \[ID_23495\]

In some cases, compiled C# files would be saved with the incorrect extension “cs0” instead of “cs”.

#### Service & Resource Management: ReservationInstances with an end time in the past would incorrectly still reserve resources \[ID_23496\]

Up to now, ReservationInstances with an end time in the past would incorrectly still reserve resources. From now on, this will no longer be the case.

Also, when eligible resources are requested for a time range with a start time in the past (by means of a GetEligibleResources call), ReservationInstances with an end time in the past will no longer be taken into account.

#### Service & Resource Management: Problem when a user opened the Bookings app for the first time \[ID_23519\]

In some cases, an exception could be thrown the first time a user opened the Bookings app.

#### Problem when trying to install Elastic on a system that is already running Elastic \[ID_23523\]

When DataMiner tried to install Elastic on a system that was already running Elastic, in some cases, an exception could be thrown.

#### DataMiner Cube - Visual Overview: Connections for active path not highlighted correctly \[ID_23558\]

In some cases, it could occur that the connections for an active path were not highlighted correctly in Visual Overview.

#### Resources incorrectly considered eligible in case of overlapping bookings with same capacity \[ID_23576\]

In some cases, when multiple overlapping bookings used the same capacity, the system would return some resources as eligible for use in a booking even though they were not.

#### Baseline value close to 0 caused constant alarm \[ID_23577\]

If a relative baseline in an alarm template was set very close to 0, it could occur that the parameter was always considered to be in alarm.

#### Problem in SLAnalytics when shutting down \[ID_23593\]

A problem could occur in the SLAnalytics process when it was shutting down.

#### Service & Resource Management: Problem when requesting booking definitions with a time filter \[ID_23631

In some cases, requesting booking definitions with a time filter would incorrectly return outdated definitions.

#### Service & Resource Management: Problem when generating a contributing service \[ID_23666\]

In some cases, an exception could be thrown when a contributing service was generated with an incorrectly configured profile parameter.

#### Problem with protocol buffer serialization when server and client were running different DataMiner versions \[ID_23679\]\[ID_24035\]

When protocol buffer serialization was being used, a number of issues could occur when a DMA and a client were running different DataMiner versions.

#### DataMiner Cube: Problem when opening a spectrum card \[ID_23696\]

In some cases, an exception could be thrown when you opened a spectrum card.

#### Legacy dashboards: No data displayed at the start of a trend graph \[ID_23755\]

On a legacy dashboard, in some cases, no data would be displayed at the start of a trend graph.

#### DataMiner Installer: Problem when setting up a Failover system due to incorrect use of quotes and double quotes in Cassandra.yaml \[ID_23773\]

In some cases, setting up a Failover system using the DataMiner Installer would fail due to the incorrect use of quotes and double quotes in the Cassandra.yaml file.

#### Duplicate log entry when SLAnalytics was started or stopped \[ID_23799\]

When SLAnalytics was started or stopped, in some cases, a duplicate entry would incorrectly be added to the log.

#### DataMiner Cube - Visual Overview: \[Sum:X,Y,Z\] placeholder did not parse decimal values \[ID_23810\]

In some cases, it could occur that the *\[Sum:X,Y,Z\]* placeholder in Visio did not parse decimal values.

#### Problem with SLElement \[ID_23846\]

In some rare cases, an error could occur in the data gateway table thread of SLElement.

#### Duplicated service definition not identical with original \[ID_23870\]

If a service definition was duplicated, it could occur that the interface configuration of the duplicate was not the same as that of the original.

#### Logon to Reports & Dashboards with SAML authentication failed \[ID_23878\]

It could occur that it was not possible to log on to the legacy Reports & Dashboards app using SAML authentication.

#### DataMiner Cube: Memory leak when opening and closing dynamic list \[ID_23910\]

If a dynamic list component was opened and closed in DataMiner Cube, for instance in the Bookings app or the Services app, a memory leak could occur.

#### Problem with alarm properties after importing alarms \[ID_23918\]

When a DELT package containing alarms was imported, in some cases, alarm properties would incorrectly be added to alarms to which they did not belong.

#### DataMiner Cube - Visual Overview: Problem with client-side filtering of dynamically positioned shapes \[ID_23946\]

When dynamically positioning shapes based on table data, in some cases, a row filter specified in a shape data field of type *Filter* would no longer be applied.

#### DataMiner Cube - Visual Overview: Custom DCF connection lines and matrix connections not displayed correctly \[ID_23955\]

In some cases, custom DCF connection lines and matrix connections would be displayed incorrectly.

#### Problem with SLAnalytics when an element was removed \[ID_23965\]

In some rare cases, an error could occur in SLAnalytics when an element was removed.

#### Service & Resource Management: Icons defined in system functions would not be displayed in DataMiner Cube \[ID_23966\]

In some cases, icons defined in system functions would not be displayed in DataMiner Cube.

#### Ticketing: Ticket fields without alarm properties would incorrectly no longer be included in the ticket \[ID_23967\]

In some cases, ticket fields without alarm properties would incorrectly no longer be included in the ticket. From now on, all ticket fields will be included in the ticket, regardless of alarm properties.

#### DataMiner Cube - Visual Overview: Problem when linking a shape to a matrix output \[ID_23980\]

When you linked a shape to a matrix output by using a shape data field of type *Output* or *OutputLabel* set to a number representing the index of the output (e.g. “1”), in some cases, that shape would be linked to an incorrect output.

#### DataMiner Cube - Trending: Problem when adding a parameter to a stopped element \[ID_24045\]

In some rare cases, an error could occur when you tried to add a parameter of a stopped element to a trend graph.

#### DataMiner Cube - Trending: Problem with 'Enable trend logging (debug)' setting \[ID_24065\]

When the “Enable trend logging (debug)” setting was deactivated, in some cases, certain log data would incorrectly still be kept in memory.

#### Ticketing: Ticket fields containing concatenations would have their type set incorrectly \[ID_24092\]

When a ticket field contained a concatenation, in some cases, the type of that field would be set incorrectly.

#### Problem with SLNet when using protocol buffer serialization \[ID_24099\]

In some rare cases, a problem could occur in SLNet when protocol buffer serialization was being used.

#### Cassandra: Paged database query would incorrectly only return the first two pages \[ID_24101\]

In some cases, a paged database query against a Cassandra database would incorrectly only return the first two pages instead of the entire result set.

#### Cassandra migration: Incorrect estimation of the amount of data to be migrated \[ID_24117\]

To be able to indicate the progress of a data migration operation, DataMiner first has to make an estimation of the amount of data to be migrated. Up to now, due to an incorrect calculation of logger table sizes, this estimation was not correct.

#### DataMiner Cube - Visual Overview: DCF connection lines between dynamically positioned shapes would disappear after zooming in and out \[ID_24119\]

In some cases, DCF connection lines between dynamically positioned shapes would disappear after zooming in and out.

#### Stopping an element with virtual functions included in an enhanced service would not correctly clear the alarms in the active alarms table \[ID_24154\]

When an element with virtual functions included in an enhanced service was stopped, although the alarms would disappear from the Alarm Console they would not be correctly cleared in the active alarms table of the enhanced service.

#### Performance issues in case of several subscriptions on single connection \[ID_24156\]

If several subscriptions were made on a single connection, there could be performance issues in Cube. This could for example be the case when service definitions were loaded.

#### Problem when simultaneously stopping an element with a direct view table and the element containing the source data \[ID_24169\]

In some cases, an error could occur when you simultaneously stopped an element with a direct view table and the element containing the source data of that direct view table.

#### DataMiner Cube - Cassandra: Problem when performing alarm queries \[ID_24177\]

On a DataMiner Agent with a Cassandra database but no Elastic database, in some cases, an exception could be thrown when performing an alarm query.

#### Problem when adding or deleting ObjectRefTreeElement objects in a Cassandra database \[ID_24188\]

In some cases, an error could be thrown when adding or deleting an ObjectRefTreeElement object in a Cassandra database.

#### Service & Resource Management: Resource concurrency calculated incorrectly when retrieving the list of eligible resources \[ID_24203\]

When the list of eligible resources was retrieved, it could occur that the resource concurrency was not calculated correctly.

#### Service & Resource Management: When a service definition was updated, the old version would not be removed \[ID_24208\]

When a service definition was updated, in some cases, the old version of that service definition would incorrectly not be removed from the *servicedeftrace* database table.

#### DataMiner Cube - System Center: A backup including the Indexing database could incorrectly be started without specifying a backup path \[ID_24217\]

In the *Backup* section of *System Center*, users would incorrectly be able to start a backup that included the Indexing database even when no *Indexing Engine backup path* had been specified. As a result, the backup operation would fail immediately.

From now on, the *Execute backup* button will be disabled when no *Indexing Engine backup path* is specified.

#### DataMiner Cube - System Center: Agent list would incorrectly be expanded after having chosen not to upgrade a number of specific agents \[ID_24223\]

When, in the *Agents* section of *System Center*, you click *Upgrade*, you can choose whether to upgrade either all agents in the cluster or a number of specific agents. If you choose the latter, and click “Yes” in the confirmation box, the list of available agents will be expanded, allowing you to select the agents to be upgraded.

However, up to now, the list of available agents would also incorrectly be expanded when you clicked “No” in the confirmation box. This will no longer occur.

#### DataMiner Cube: Version conflict error after logging in with an incorrect Administrator password \[ID_24229\]

When you tried to log in to DataMiner Cube with an incorrect Administrator password, in some cases, a version conflict error could be thrown.

#### DataMiner Cube: Locally saved document locked until DMA restart \[ID_24231\]

When a document was saved from the Documents app in Cube to a local drive, it could occur that this file was locked by DataMiner until the DMA was restarted.

#### Service & Resource Management: Alarm icons not displayed in ListView component \[ID_24232\]

In some cases, if the column configuration for a ListView component contained alarm icons, it could occur that the alarm icons were not displayed when the configuration was loaded.

#### Issues when deleting booking instances \[ID_24244\]

When a booking instance in "Ongoing" state was deleted, it could occur that the deletion failed. In addition, if a booking instances tree was deleted by passing the nodes in the tree to the helper call, it could occur that the response contained too many bookings.

#### Element migration failure because of file with same name \[ID_24249\]

When an element was migrated, it could occur that an element data file could not be created because a file with the same name already existed, causing the migration to fail. Now a suffix will be added to the file name to ensure that the file can be created.

#### DataMiner Cube - Alarm Console: Alarm filters using session variables would no longer be updated correctly \[ID_24255\]

In some cases, alarm filters that contained session variables would no longer be updated correctly when one of those variables had changed.

#### Problem with SLSNMPManager when an incorrectly configured SNMPv3 element was started \[ID_24269\]

In some cases, an error could occur in SLSNMPManager when an incorrectly configured SNMPv3 element was started.

#### Problem with SLDataMiner when processing a service alarm while updating a service \[ID_24274\]

In some rare cases, an error could occur in SLDataMiner when it is was simultaneously updating a service and processing a new alarm linked to a service.

#### Problem in SLElement when adding comment while clearing timeout alarm \[ID_24286\]

When a timeout alarm was cleared manually and the user set the comment when clearing the alarm to the IP address of the connection, a problem could occur in SLElement.

#### Failover - MySQL: Alarm cleaning process would not be able to correctly separate active from non-active alarms \[ID_24306\]

When the number of alarms stored in the database reaches a certain threshold, the oldest, non-active alarms are automatically removed from the system. However, on a Failover system with MySQL databases, in some cases, the alarm cleaning process would not be able to correctly separate active from non-active alarms.

#### DataMiner Cube - Data Display: Problem when displaying a tabbed table \[ID_24317\]

In some cases, an exception could be thrown when a tabbed table was displayed on a DATA page.

#### Reports & Dashboards: Empty tables in legacy dashboards \[ID_24320\]

On legacy dashboard, in some cases, tables containing data would incorrectly be displayed as empty.

#### DataMiner Cube: Not possible to connect to another DMA after starting Cube with a 'host=' argument \[ID_24322\]

When DataMiner Cube was started with a “host=” argument, in some cases, the user would not be able to connect to another DataMiner Agent.

#### Exception when starting up DMAs in cluster with empty Elastic database \[ID_24325\]

If several DMAs in a cluster were started at the same time and these DMAs has an empty Elastic database, an exception could be thrown.

#### Reports & Dashboards: Problem with status query in legacy Reporter app \[ID_24332\]

When you used the legacy Reporter app to generate a report containing a status query, in some cases, a “response buffer limit exceeded” error message would appear, especially when the report contained a large amount of data.

#### Alarm Console: Hyperlinks missing in right-click menu after element restart or DataMiner restart \[ID_24335\]

In the Alarm Console, in some cases, the alarm hyperlinks would disappear from the right-click menu after an element restart or a DataMiner restart.

#### Problem when importing DELT packages containing alarms \[ID_24340\]

When a DELT package containing alarms was imported on a system running Cassandra, in some cases, the root time and root creation time of the alarms could be incorrect.

#### Service & Resource Management: Function DVEs not removed after resource swap \[ID_24342\]

If resources of a running booking were swapped with other resources, it could occur that the function DVEs that were no longer in use were not disabled until the maximum number of functions was reached.

#### DataMiner Cube: CPE card headers not showing the correct alarm color \[ID_24345\]

In some cases, the header of a CPE card did not show the correct alarm color. Instead, it was set to gray (Initial).

#### Web Services API v1: Incorrect view alarm severity \[ID_24347\]

The view state returned by the following methods would incorrectly not take into account the user security.

- GetAlarmStateForView
- GetView
- GetViewsForParent

> [!NOTE]
> The above-mentioned methods are also used by the DataMiner web applications (e.g. Monitoring & Control, Dashboards, Ticketing, etc.), and the view states are also used in DataMiner Maps.

#### Element connections saved incorrectly \[ID_24348\]

If an element had multiple serial, smart-serial or HTTP port connections, it could occur that the connection type of the first port was applied to all other serial, smart-serial or HTTP ports as well.

#### Service & Resource Management: Exception when saving multiple profile instances or profile definitions with empty field \[ID_24359\]

When multiple profile instances or profile definitions containing an empty field were saved at the same time, an exception could be thrown.

#### DataMiner Cube: Problem when resizing the Alarm Console \[ID_24362\]

When you made the Alarm Console smaller and then restored it to its original size, in some cases, the entire console would become blank.

#### DataMiner Cube: Problem when displaying dialog box while window/scroll bar thumb is dragged \[ID_24383\]

In the XBAP version of DataMiner Cube, if a dialog box was displayed while a user was dragging a window or a scroll bar thumb, a problem could cause Cube to freeze.

#### Booking definition saved even though no instance could be planned \[ID_24397\]

In some cases, it could occur that a booking definition was saved even though it was not possible to plan a booking instance.

#### Addition/removal booking events of existing booking not implemented correctly \[ID_24398\]

When booking events were added to or removed from an existing booking that still needed to start, it could occur that this change was not executed correctly.

#### Service & Resource Management: Exceptions when using a MySQL local database \[ID_24401\]

On systems with a MySQL local database, if a booking was saved that overrides a property on one of its resources, an exception could be thrown. In addition, an exception could be thrown during the initialization of the Resource Manager.

#### DataMiner Cube - Visual Overview: Column configuration of ListView component not updated \[ID_24422\]

In some rare cases, it could occur that the column configuration of a *ListView* component was not saved or retrieved correctly.

#### DataMiner Cube: Editing an SNMPv3 element created prior to DataMiner 9.6.12 would cause the authentication type to be reset to the default type \[ID_24423\]

When you edited an SNMPv3 element that was created prior to DataMiner 9.6.12, in some cases, the authentication type would incorrectly be reset to the default type (i.e. SHA512).

#### Dashboards: Problem with duplicate trend graphs in line chart component \[ID_24427\]

When, in a line chart component, you selected a second parameter, in some cases, each trend graph would incorrectly be displayed twice.

#### Service & Resource Management: ReservationInstances did incorrectly not have their status set to 'interrupted' \[ID_24434\]

In some rare cases, ReservationInstances that should have had their status set to “interrupted”, had their status set to an incorrect value.

#### Problem with SLElement when updating the source data of a direct view table belonging to an element with debug log level 2 \[ID_24449\]

In some cases, an error could occur in SLElement when updating the source data of a direct view table belonging to an element of which the debug log level was set to 2.

#### Problem with SLDataGateway when retrieving recursive tree items \[ID_24461\]

In some cases, an error could occur in SLDataGateway when retrieving recursive tree items.

#### Problem when SLProtocol retrieved data from a logger table \[ID_24483\]

In some cases, a problem could occur when SLProtocol retrieved data from a logger table using an integer value as primary key.

#### DataMiner Cube - Data Display: Memory leak after sorting and/or filtering tables \[ID_24492\]

In some cases, DataMiner Cube could leak memory after sorting and/or filtering tables displayed on DATA pages.

#### Memory leak in SLXML due to a parsing issue in SLDataMiner \[ID_24503\]

In some cases, SLXML could leak memory due to an XML parsing issue in SLDataMiner.

#### DataMiner Cube: Backup could incorrectly be started while the backup settings of the Indexing engine were being configured \[ID_24510\]

Up to now, users would incorrectly be able to start a backup operation while the Indexing nodes were restarting after, for example, changing the Indexing engine’s backup path.

From now on, it will no longer be possible to start a backup operation while the backup settings of the Indexing engine are being configured.

#### Problem with SLDataMiner \[ID_24511\]

In some rare cases, an error in SLDataMiner would cause other problems to occur (e.g. element timeouts).

#### Service & Resource Management: Editing a service in the services list would incorrectly clear the IDOfSelection session variable \[ID_24519\]

When you select a service in the services list, the ID of that service is stored in the *IDOfSelection* session variable. In some cases, that session variable would incorrectly be cleared when you edited the selected service.

#### Dashboards app: Problem with unintentional move operations in Chrome \[ID_24525\]

When working with the Dashboards app in Chrome, in some cases, a mouse click could unintentionally cause a dashboard component to be moved to another location.

#### HTML5 apps: Selection box values containing backslash characters displayed incorrectly in interactive Automation scripts \[ID_24541\]

When an interactive Automation script was run from within an HTML5 app, in some cases, selection box values containing “\\” characters could be displayed incorrectly.

#### DataMiner Cube: Clicking 'Open Cube Mobile' would not always direct you to the landing page \[ID_24560\]

When, in DataMiner Cube, you clicked *Open Cube Mobile*, in some cases, you were incorrectly directed to the Monitoring & Control app. From now on, clicking *Open Cube Mobile* will always direct you to the landing page.

#### Failover: Problem with Indexing database after a Failover switch \[ID_23945\]\[ID_24562\]

When an Indexing database was installed on a pair of DataMiner Agents in a Failover setup, in some cases, the Indexing database could no longer be reached after a Failover switch.

#### DataMiner Cube: Icons and names not properly aligned in 'Below this view' list \[ID_24572\]

When you opened a view card and selected *Below this view \> All*, in some cases, the icons and the names of the list items would not be properly aligned.

#### Service & Resource Management: Problem during Resource Manager initializing \[ID_24604\]

In some cases, the Resource Manager module could fail to initialize when protocol buffer serialization was enabled.

#### Service & Resource Management: Problem when retrieving a ReservationInstance immediately after a property update \[ID_24622\]

When a ReservationInstance was retrieved immediately after its properties had been updated, in some cases, the properties of the retrieved ReservationInstance would incorrectly still have their old values.

#### DataMiner Cube - Data Display: Alarm icon outside of colored background when hovering over a parameter control \[ID_24631\]

When you hovered over a parameter control, in some cases, the colored background would not include the alarm icon.

#### DataMiner Cube: Problem when using TAB to navigate among controls \[ID_24670\]

When you used the TAB key to navigate from one control to another, navigation would fail when a numeric up/down control had the focus.

#### DataMiner Cube - Data Display: DPI settings not always taken into account when rendering selection boxes and tool tips \[ID_24685\]

In Data Display, in some cases, the screen’s DPI settings would not be taken into account when rendering selection boxes and tool tips.

#### DataMiner Cube: Problem when saving or assigning group settings \[ID_24701\]

In some cases, it would no longer be possible to save group settings or to assign new settings to a group to which none had been assigned before.

#### Problem with SLDMS when synchronizing services to other agents \[ID_24725\]

In some rare cases, an error could occur in SLDMS when synchronizing services to other agents in the DataMiner System.

#### DataMiner Cube - Services app: Service definition not loaded correctly when Services app is opened \[ID_24735\]

When you opened the Services app, it could occur that one of the service definitions was not loaded correctly. When you selected it, it was tagged as “\[modified\]” and its connection lines were lost.

#### DataMiner Cube - Data Display: Description of Write parameters would be missing when there was no corresponding Read parameter \[ID_24767\]

On an element card, in some cases, Write parameters for which there was no corresponding Read parameter would not have their description displayed.

#### Problem when masking rows or cells in view tables or direct views \[ID_24773\]

In some cases, it would no longer be possible to mask cells or rows in view tables or direct views.

#### DataMiner Cube - Automation: Problem when an Automation script tried to send an e-mail containing a report \[ID_24775\]

In some cases, an error could occur when an Automation script tried to send an e-email containing a report.

#### Problem with SLProtocol when calling 'NT_LOAD_TABLE' \[ID_24780\]

In some cases, an error could occur in SLProtocol when calling the NotifyProtocol method “NT\_LOAD_TABLE”.

#### Problem when trying to back up an Elastic database using its public IP address \[ID_24810\]

When you tried to back up an Elastic database (which is used by the DataMiner Indexing engine) using its public IP address, in some cases, a message would incorrectly appear, saying that no Elastic database could be found on the machine in question.

#### SNMP communication error processing issue \[ID_24811\]

In some cases, SNMP communication would interpret SNMP errors incorrectly.

#### Problem when an element was stopped while an alarm time trace was being written \[ID_24872\]

In some rare cases, an error could occur when an element was stopped while a time trace was being written for one of its alarms.

#### Problem when calling GetParameter on the virtual element of a redundancy group \[ID_24892\]

When a GetParameter method was called in an Automation script on the virtual element of a redundancy group, in some cases, a CreateDummyFailedException could be thrown.

#### Memory leak in SLNet when enabling or disabling logging \[ID_24921\]

In some cases, the SLNet process would leak memory when logging was enabled or disabled.

#### Users with an expired password were not able to enter a new password \[ID_24938\]

In some cases, users of whom the password had expired would not be able to enter a new password. Instead, a “Failed to setup ProtoBuf” error would appear.

#### Deleting a monitored table row could cause an incorrect alarm to be generated \[ID_24957\]

When a monitored table row was deleted, in some cases, an incorrect alarm with an invalid root ID and invalid time stamp would be generated.

#### Problem with booking after property update \[ID_25076\]

When a property of a booking was updated using the method *SafelyUpdateReservationInstanceProperties*, a problem could occur with the booking.

#### SLAnalytics: Problem when receiving a trend prediction data request for an unknown parameter \[ID_25171\]

In some cases, an error could occur in SLAnalytics when it received a request to return trend prediction data for a parameter that could not be found in the protocol.

#### Failover: Remote services not synchronized towards offline Agent \[ID_25173\]

In a Failover setup, it could occur that remote services were not synchronized towards the offline Agent.

#### Memory leak in SLLoggerUtil process \[ID_25206\]\[ID_25465\]

In some cases, the SLLoggerUtil process would leak memory. For instance, when the log levels were updated multiple times.

#### Ticketing app: Deleting a ticket would incorrectly cause all tickets to be deleted \[ID_25211\]

In some cases, deleting a ticket would incorrectly cause all tickets to be deleted.

#### Problem with SLElement when the element incorrectly identified as the DMA element was deleted \[ID_25261\]

In some cases, an error could occur in SLElement when the element incorrectly identified as the DataMiner Agent element was deleted.

#### SLProtocol would incorrectly flush timetrace data when only element data had to be flushed \[ID_25273\]

In some cases, when SLProtocol had to flush element data, it would also incorrectly flush timetrace data.

#### Generation of alarm events with root key 0 upon creation of DVE element \[ID_25328\]

When a DVE element was created, in some cases, alarm events with root key 0 would incorrectly be generated for the monitored parameters that were not in an alarm status.

#### Cassandra: When an element was restarted, duplicate timetrace entries would be written to the database \[ID_25385\]

When an element with a large amount of active alarms was restarted, in some cases, duplicate timetrace entries would be written to the Cassandra database

#### Memory leak in SLDataGateway \[ID_25395\]

When DVE elements had average trending configured while the central database was enabled, in some cases, the SLDataGateway process would leak memory.

## Addendum CU1

### CU1 enhancements

#### Logging: Setting log levels per DataMiner log file \[ID_23244\]\[ID_24771\]

In the *Logging* section of *System Center*, it is now possible to set log levels per DataMiner log file, overriding the ones specified on system level.

##### Overriding the system-wide log levels for a specific log file

1. In the tab listing the DataMiner log files (default tab name: “dataminer”), select the log file in the left-hand pane.

1. At the top of the right-hand pane, open the *Log settings* section, select the *Override log levels* option, specify a level for each of the three log levels (info, debug and error), and click *Apply levels*.

> [!NOTE]
>
> - If you want to set the same non-default log levels for multiple log files, then note that you can select more than one file in step 1. To select more than one file, click one, and then click another while holding down the CTRL key, etc. To select a list of consecutive files, click the first one in the list and then click the last one while holding down the SHIFT key.
> - In the left-hand pane, the current log levels for each of the DataMiner log files are displayed next to the name of the file.
>   - If a file inherits the system-wide log levels, the log levels displayed next to the file will appear in gray.
>   - If a file has specific log levels defined (i.e. if the system-wide levels are overridden), the log levels displayed next to the file will appear in black.
> - If you clear the *Override log levels* option for a particular log file, that file will again inherit the system-wide log levels.

##### Setting the system-wide log levels

1. In the tab listing the DataMiner log files (default tab name: “dataminer”), select the first entry in the left-hand pane, marked “\<Default>”.

1. At the top of the right-hand pane, open the *Log settings* section, specify a level for each of the three log levels (info, debug and error), and click *Apply levels*.

#### SLNet setting 'FlushQueuedMessagesInterval' no longer has a minimum value \[ID_24205\]

The “FlushQueuedMessagesInterval” setting controls the interval at which pending messages are flushed to clients through the callback connection. The larger this interval, the less calls will be made, but the longer the delay will be between events being generated and clients receiving them. This setting is a global setting that can be configured per DataMiner Agent, and applies to any client connecting to SLNet.

The default value is 100ms, and up to now the minimum value was 50ms. From now on, this setting no longer has a minimum value. When the interval is set to zero, there will only be a 15ms delay when an iteration did not yield any new callback launches.

#### DataMiner Cube - Alarm Console: Enhanced performance when adding property columns \[ID_24545\]

Due to a number of enhancements, performance has increased when adding property columns in alarm tab pages.

#### DataMiner installer will no longer install Web Services Enhancements \[ID_24547\]

From now on, the DataMiner installer will no longer install Web Services Enhancements for Microsoft .NET.

#### SLSNMPManager: Enhanced error handling \[ID_24579\]

Due to a number of enhancements, overall error handling has been improved in the SLSNMPManager process.

#### Logging related to smart baselines will now be added to a dedicated log file \[ID_24627\]

Up to now, all logging related to smart baselines was added to the *SLNet.txt* log file. From now on, this logging will be added to the *SLSmartBaselineManager.txt* file instead.

#### BPA tests: Minimum version set to '0.0.0.0' by default \[ID_24634\]

When you create a BPA test, from now on, it will have its minimum version set to “0.0.0.0” by default, meaning that it will run on any DataMiner version.

#### Migrating booking data to Indexing Engine: Enhanced message in case of successful migration \[ID_24671\]\[ID_25101\]

When a booking data migration to Indexing Engine completed successfully, up to now, the following message would appear:

```txt
The migration is done with 0 failed merge(s), but without exceptions or errors.
```

From now on, the following message will appear instead:

- In case there are no failed merges:

    ```txt
    The migration has successfully been completed.
    ```

- In case there are failed merges:

    ```txt
    The migration has been completed with X failed merge(s). There were no exceptions or errors.
    ```

#### Migrating booking data to Indexing Engine: 'Show all properties' option will now by default not be selected \[ID_24717\]

When migrating booking data to Indexing Engine, up to now, the “Show all properties” option would be selected even when there were no properties to be changed. From now on, this option will by default not be selected.

#### DataMiner Cube - Spectrum analysis: Preset will now also contain the measurement point for which the trace was measured \[ID_24729\]\[ID_24953\]\[ID_25100\]

From now on, when you save a preset, it will not only include a “measurement points" field containing all measurement points you selected, but also a “saved on measurement point” field containing the ID of the measurement point for which the trace was measured.

This will enable spectrum monitors to determine the correct set of frequencies in case the monitor runs a script that loads a preset based on a selected measurement point.

#### DataMiner Cube - Service & Resource Management: ListView enhancements \[ID_24736\]

A number of enhancements have been made to the ListView component, which is used in the Bookings and Services apps as well as in Visual Overview:

- The *Add/Remove Column \> More…* shortcut menu option was moved up one level and renamed to *Manage column configuration…*
- The title of the column configuration window, which was named *Choose details*, has now been renamed to *Column configuration*.

#### DataMiner Cube - Visual Overview: Advanced editing pane improvements \[ID_24772\]\[ID_24794\]

The *Advanced Editing* pane now provides better support for DataMiner stencils.

From now on, this pane will

- no longer display shape data that is marked “hidden”, and
- no longer show underlying formulas in shape data, but the actual value.

Also, a few general enhancements have been made with regard to scrolling and keyboard focus.

#### Ticketing: Additional logging explaining why it was not possible to delete a ticket field resolver \[ID_24802\]

When it was not possible to delete a ticket field resolver, additional information will now be added to the SLTicketingGateway.txt log file, explaining why the deletion request was denied.

#### DataMiner Cube - Visual Overview: Minor enhancements made to Advanced Editing pane \[ID_24807\]

A number of minor enhancements have been made to the *Advanced Editing* pane:

- The Add shape data list will no longer show a duplicate *ChildrenFilter* entry.
- The message shown when adding a duplicate shape data or when configuring an invalid shape data name will now mention shape data instead of page data.
- Closing the *Advanced Editing* pane will now update the *Advanced Editing* button in the ribbon.
- The current selection will now be taken into account when starting the *Advanced Editing* extension.

#### DataMiner Cube - Correlation: Enhancements with regard to the use of placeholders in 'Send Email' actions of Correlation rules \[ID_24816\]

A number of minor enhancements have been made with regard to the use of placeholders in “Send Email” actions of correlation rules.

#### DataMiner Cube - Visual Overview: Enhanced performance of the Advanced Editing pane \[ID_24825\]

Due to a number of enhancements, overall performance of the *Advanced Editing* pane has increased, especially when editing pages that contain a large amount of shapes.

#### DataMiner Cube - Service & Resource Management: Property columns will now automatically be updated upon property changes \[ID_24826\]

In ListView components embedded in Visio pages, from now on, columns referring to element properties will automatically be updated upon property changes.

#### DataMiner Cube - Alarm Console: Element state changes no longer trigger a refresh of filtered alarm tab pages \[ID_24832\]

Up to now, element state changes would trigger a refresh of filtered alarm tab pages. From now on, this will no longer happen.

#### Web Services API v1: Enhanced retrieval of trend data \[ID_24848\]

From now on, the GetTrendDataForTableParameter and GetTrendDataForTableParameterV2 methods will automatically try to retrieve real-time trend data when no average trend data is available (and vice versa).

#### DataMiner Cube will now be shipped with Segoe MDL2 Assets font \[ID_24853\]

Because client computers running a Microsoft Windows version prior to Windows 10 do not have the Segoe MDL2 Assets font installed by default, from now on, that font will be shipped with DataMiner Cube.

#### SLDMS: SLElement/SLDMS throttle removed \[ID_24862\]

Previously, the amount of simultaneous calls that native SLElement and SLDMS modules could make to the local SLNet process was limited to 1 and 5 respectively. This limit has now been removed. Both now use the same limit as other processes, i.e. 10 simultaneous calls.

If you prefer to keep the call limits as they were, you can specify the following option in the *\<appSettings>* section of the *C:\\Skyline DataMiner\\Files\\SLNetCOM.dll.config* file:

```xml
<add key="UseLegacyThrottle" value="true" />
```

When you set this *UseLegacyThrottle* option to true, the Application/DataMiner event viewer log will show entries for SLElement.exe and SLDMS.exe indicating “Applied throttle: 1” (SLElement) or “Applied throttle: 5” (SLDMS).

#### DataMiner Cube: Option to connect over Web Services will now be hidden when Web Services Enhancements is not installed on the DataMiner Agent \[ID_24918\]

When you try to connect to a DataMiner Agent that does not have Web Services Enhancements for Microsoft .NET installed, from now on, you will no longer be able to set *Connection type* to “Web services” in the logon options window of DataMiner Cube.

#### DataMiner Cube: Undocked cards now have an updated DataMiner logo in the upper-left corner \[ID_24920\]

Undocked cards now have an updated DataMiner logo in the upper-left corner.

#### Indexing Engine: A search string will only be added to the list of suggestions when the search yields results \[ID_24927\]

When, on a system with an Indexing Engine, you perform a search, from now on, the search string you entered will only be added to the list of suggestions when the search yields results.

#### SLDMS: Enhanced file locking mechanism \[ID_24954\]

A number of enhancements have been made to the file locking mechanism in SLDMS.

#### SLNet: Enhanced processing of messages sent asynchronously \[ID_24966\]

Due to a number of enhancements, overall performance of SLNet has increased when processing messages sent asynchronously.

#### DataMiner Cube - Data Display: Redesigned page buttons \[ID_24974\]

All page buttons have now been redesigned in order to match the new DataMiner X style.

#### DataMiner Cube - Visual Overview: Using subscription filters when subscribing to tree control tables \[ID_24995\]

From now on, multiple subscription filters can be configured in the *SubscriptionFilter* shape data field of a tree control. Each of the pipe-separated filters will be applied to the corresponding table specified in the *SetVar* shape data field.

In the following example, the first subscription filter (“value=101 == 1”) will be used when subscribing to the first table (with ID 100) and the second subscription filter (“value=201 == A”) will be used when subscribing to the second table (with ID 200).

| Shape data field   | Value                            |
|--------------------|----------------------------------|
| SetVar             | MyVar:\[this elementID\]:100:200 |
| SetVarOptions      | Control=TreeView                 |
| SubscriptionFilter | value=101 == 1\|value=201 == A   |

#### Automation: SetPropertyValue method will now only return after having checked that the property was set correctly \[ID_25025\]\[ID_25195\]

From now on, the *SetPropertyValue* method will only return after having checked that the property was set correctly.

Up to now, when the value of an element property was updated using the *SetPropertyValue* method on an *Element* object and immediately retrieved using the *GetPropertyValue* method, in some cases, the value returned by that last method would incorrectly be the previous value.

> [!NOTE]
> The *SetPropertyValue* method will only perform the above-mentioned check when the “check sets” option is enabled.
>
> - Before launching a script in Cube, select the “After executing a SET command, check if the read parameter or property has been set to the new value” checkbox in the script execution window.
> - When launching a script using *ExecuteScriptMessage*, make sure to activate the CHECKSETS option (“CHECKSETS:TRUE”).
>
> With this option enabled, the *SetPropertyValue* method will take slightly longer to execute. When a large number of properties need to be updated which do not need to be retrieved immediately, you can disable this option in order to increase performance.

#### Service & Resource Management: Enhanced performance when retrieving available resources \[ID_25061\]

Due to a number of enhancements, overall performance has increased when retrieving available resources (e.g. by means of the GetAvailableResource method).

#### DataMiner Cube - Visual Overview: ListView component will not show a set of default columns when no columns are configured in its shape data \[ID_25098\]

When you add a *ListView* component to a Visio page, from now on, that component will display a set of default columns when its shape data does not contain a column configuration.

#### SLTaskBarUtility: Default Agents to upgrade now set to 'cluster' \[ID_25118\]

Previously, "Agents to upgrade" was by default set to "localhost" in the SLTaskBarUtility upgrade window. In order to ensure that clusters are upgraded completely, now "cluster" is selected by default. However, not that in case the Agent is not running, localhost will still be selected.

#### Enhanced processing of large DELT export operations \[ID_25177\]

A number of enhancements have been made with respect to the DELT export process. This will prevent timeouts in the event the process gets interrupted while exporting large amounts of data.

#### Automation: UnSetFlag method now also added to IEngine interface \[ID_25188\]

Since DataMiner 10.0.0/10.0.1, you can use the engine.UnSetFlag method to clear the AllowUndef, NoInformationEvents and NoKeyCaching run-time flags in an Automation script.

This method has now also been added to the IEngine interface.

#### Additional SLPort error logging \[ID_25200\]

Additional log information is now added to the SLPort logging to make it easier to troubleshoot issues in case DataMiner cannot process an incoming read event from a device because of an issue with the socket.

However, note that this logging will only be enabled for a particular element if the IP address for this element is added in PortLog.txt. For more information on how to add this, refer to the DataMiner Help.

#### Security: LDAP queries will now time out after 5 minutes \[ID_25214\]

From now on, LDAP queries will, by default, time out after 5 minutes.

This setting can be configured in the *DataMiner.xml* file. Enter a value in seconds. If the LDAP.QueryTimeout tag is not present, a default value of 300 seconds (i.e. 5 minutes) will be taken. See the example below.

```xml
<DataMiner>
  <LDAP>
    <QueryTimeout>300</QueryTimeout>
  </LDAP>
</DataMiner>
```

> [!NOTE]
> This timeout applies to every individual LDAP query. As a result, a request to refresh all groups (which consists of multiple requests) could have a total timeout that is much larger than 5 minutes.

#### Legacy Reporter app: Alarm list component now also returns alarms of enhanced service elements \[ID_25232\]

In the legacy Reporter app, the alarm list component will now also return alarms of enhanced service elements.

#### DataMiner Cube - Trending: Behavioral anomaly detection will no longer generate nor clear suggestion events when its flood mode is activated \[ID_25244\]

From now on, behavioral anomaly detection will no longer generate nor clear suggestion events when its flood mode is activated.

#### DataMiner Cube: Enhanced behavior of 'Save all changes' and 'Discard all changes' commands in Profiles and Services apps \[ID_25259\]

In the Profiles and Services apps, a number of enhancements have been made with regard to the “Save all changes” and “Discard all changes” commands.

#### DataMiner Cube: Improved vertical alignment of hint text in password box of login screen \[ID_25303\]

In Cube’s login screen, the vertical alignment of the hint text in the password box has been improved.

#### DataMiner Cube - Alarm Console: Reduced memory consumption \[ID_25340\]

Due to a number of enhancements, the overall memory consumption of the Alarm Console has been reduced.

#### Backup: Backup.log file added to backup package \[ID_25347\]

When a backup package is created, from now on, the log information regarding the creation of that package will now be stored in the Backup.log file, which will be included in the package.

#### DataMiner Cube - Data display: Partial tables with protocol-defined sorting now have a refresh button \[ID_25354\]

Partial tables with protocol-defined sorting now have a refresh button.

#### DataMiner Cube - Header bar search box: Hidden and enhancing elements will no longer be included in the search results \[ID_25403\]

From now on, when you perform a search using the header box search box, the result set will no longer include hidden elements or view-enhancing elements.

#### Enhanced performance when writing data to Indexing Engine \[ID_25411\]

Due to a number of enhancements, overall performance has increased when writing data to the Indexing Engine.

#### Service & Resource Management: When checking whether a boolean ReservationInstance property is true or false, it is now also possible to specify the type as 'Bool' \[ID_25415\]

When checking whether a boolean ReservationInstance property is set to true or false, you can now specify the type as “Bool” as well as “Boolean”. See the following example:

```csharp
"ReservationInstance.Properties.\"Contributing Service\"[Bool]==false"
```

> [!NOTE]
>
> - Do not enclose the values true and false in single quotes. This would cause those values to be interpreted as string values instead of boolean values.
> - Do not enclose the filter in round brackets (...).

#### Service & Resource Management: Checking whether a boolean ReservationInstance property is true or false \[ID_25415\]

It is now possible to check whether a boolean ReservationInstance property is set to true or false. See the following example:

```csharp
"ReservationInstance.Properties.\"Contributing Service\"[Bool]==false"
```

> [!NOTE]
>
> - Do not enclose the values true and false in single quotes. This would cause those values to be interpreted as string values instead of boolean values.
> - Do not enclose the filter in round brackets (...).
> - To indicate the type, you can use either \[Bool\] or \[Boolean\].

#### Dashboards app - Line chart component: Timestamp will now always remain visible in the legend \[ID_25421\]

When hovering over trend graph values in a line chart component, the associated timestamp will now always remain visible in the legend.

When the legend is collapsed, instead of not showing any timestamp, it will now show the timestamp above the trend values. When the legend is expanded, it will show the timestamp as it did before.

#### DataMiner Cube: User name box on login screen can now display user names with a length of up to 64 characters \[ID_25426\]

On the login screen, the user name box can now display user names with a length of up to 64 characters. Longer names will be displayed with a trailing ellipsis character (“...”).

### CU1 fixes

#### DataMiner Cube - System Center: Agent name would not get updated after a Failover switch \[ID_24468\]

In the *Agents* section of *System Center*, after a Failover switch, in some cases, the agent name would not get updated to the name of the online agent.

#### DataMiner Cube - Automation: Problem when turning a SET action into a GET action or vice versa \[ID_24498\]

When you added a SET action to an Automation script and then changed it to a GET action (or vice versa), in some cases, it would no longer be possible to configure the action.

#### DataMiner Cube - Protocols & Templates: Problem when trying to select another protocol version in the 'List based on protocol version' box \[ID_24499\]

If an information template is based on an older protocol version that does not have the same parameters as the latest protocol version, a warning is displayed at the bottom of the information template. Above the warning, a drop-down list allows you to select a different protocol version to load those parameters instead.

In some cases, selecting a different protocol version in this drop-down list would no longer be possible.

#### DataMiner Cube - Services app: Problem when duplicating service definitions \[ID_24500\]

In some cases, when duplicating a service definition, some data would not get copied to the newly created duplicate.

#### Alarm level linking would not be initialized or updated correctly \[ID_24509\]

In some cases, alarm level linking would not be initialized or updated correctly.

#### Failover: 'AlwaysBruteForceOffline' option would not work correctly when releasing virtual IP addresses took more than 10 seconds \[ID_24535\]

When a Failover setup with the *AlwaysBruteForceOffline* option enabled had to go offline, in some cases, the agent would not be restarted when releasing the virtual IP addresses took more than 10 seconds. The agent would incorrectly remain in an undefined state. Also, when the agent eventually went online at a later stage, problems could occur. On systems with a MySQL database, for example, incorrect element alarms would start to appear.

#### DataMiner Cube - Visual Overview: Problem when loading a trend group in a trend component \[ID_24590\]

When you embed a trend component on a Visio page, you can have it load a trend group by setting the *Parameters* shape data field to “TrendGroup=\<username>/sharedusersettings:\<groupName>”. When this entry contained a dynamic part (e.g. \[var:xxx\]), in some cases, updates would not get processed correctly and the trend graph would be cleared.

#### Problem with file synchronization cache \[ID_24620\]

Due to a problem with the file synchronization cache, in some cases, old file versions could incorrectly get synchronized again among the agents in a DataMiner System.

#### Service & Resource Management: Booking state not updated in services list \[ID_24650\]

In the list of services in the Bookings and Services apps, it could occur that the booking state was not up to date. This information will now be refreshed in real time.

#### Problem with SLSNMPAgent when retrieving the views \[ID_24663\]

In some cases, an error could occur in the SLSNMPAgent process when retrieving the views, especially when elements or services were present in the root view and the system contained a view with the same name as the root view.

#### DataMiner Cube - Alarm Console: Not possible to have the 'Focus' column displayed in 'active alarms' tabs listing different types of alarms and events \[ID_24680\]

In an “active alarms” tab showing masked alarms, non-masked alarms, information events and suggestion events, in some cases, it would not be possible to have the Focus column displayed.

#### Problems with recursive tables \[ID_24683\]

When a recursive table was queried directly using dynamic table queries, incorrect results would be returned when a “FK=xxx” filter was used on that same recursive table.

Also, when an element with bubble-up alarms in a recursive table was restarted, some of those alarms would incorrectly be counted twice. This would produce incorrect results when alarm severities dropped.

#### Service & Resource Management: Problem when retrieving profile manager data immediately after that data had been updated \[ID_24688\]

When profile manager data (profile parameters, profile instances or profile definitions) was retrieved immediately after that data had been updated, in some cases, old data would be returned.

#### DataMiner Cube - Trending: Problem when exporting trend data to CSV while trend logging was disabled \[ID_24699\]

When you exported a trend graph to a CSV file after selecting the *Everything* option, in some cases, none or only part of the trend data would get exported when trend logging was disabled. Also, afterwards, data could be missing from the trend graph when selecting e.g. “Previous month”.

#### DataMiner Cube - Bookings app: Problem when zooming to last/next month in the bookings timeline \[ID_24704\]

When, in the bookings timeline, you zoomed to last/next month, in some cases, the timeliine would zoom to an incorrect time range (e.g. one day).

#### DataMiner Cube - Services app: Problem with service definition diagram updates \[ID_24707\]

In the *Services* app, in some cases, the diagram of a service definition would not be updated properly when the service definition was embedded on a Visio page and the *AutoLoadExternalChanges* option was set to true.

#### DataMiner Cube - Visual Overview: Problem with path highlighting after a DCF connection update \[ID_24741\]

After a DCF connection update, in some cases, the highlighting of a manually drawn connector linked to that DCF connection would be incorrect. The highlight path would incorrectly end at the updated connector.

> [!NOTE]
> This problem only occurred when one or both of the interfaces connected to the connector were of type input/output.

#### DataMiner Cube - Data Display: Problem with lite drop-down controls when the listed parameter values were dependent on other parameter values \[ID_24743\]

In some cases, lite drop-down controls would not contain the correct values, especially when the listed parameter values were dependent on other parameter values.

#### DataMiner Cube - Advanced search: Problem when matches could only be found for one of the state filter options \[ID_24758\]

When, in the advanced search, you filter by item type (e.g. “Element”), an additional state filter appears. When you selected that state filter, in some cases, Cube would stop working when matches could only be found for one of the state filter options.

#### Problem when creating virtual function based on entry point tables that were part of the same relation \[ID_24770\]

In some cases, an error could occur when creating virtual functions based on two different entry point tables that were part of the same relation.

#### DataMiner Cube - Router Control: Problem when loading tab page IO buttons in configuration mode \[ID_24779\]

When, in configuration mode, the first tab of a tab control was loaded, in some cases, the IO buttons in that tab would not be loaded.

#### DataMiner Cube: Redesigned Cube X alarm icons incorrectly indicated timeouts and did not fully support alarm severity capping \[ID_24785\]

In DataMiner Cube, in some cases, the redesigned Cube X alarm icons would incorrectly indicate timeouts, especially for items included in a service. Also, up to now, those alarm icons would not fully support alarm severity capping.

#### Ticketing app: Problem when opening the app \[ID_24786\]

When opening the Ticketing app, in some cases, the following error could be thrown:

```txt
“Error trapped: An entry with the same key already exists.”
```

#### DataMiner Cube - Data Display: Problem when searching for a parameter in an element card \[ID_24801\]

In some cases, DataMiner Cube would become unresponsive when, in an element card, you searched for a parameter using the search box in the top-left corner of the card.

#### Problem when masking an entire table \[ID_24805\]

In some cases, it would not be possible to mask an entire table.

Also, the following masking issues have been solved:

- When a row was added to a masked table or a masked column and an alarm was generated for that row, the alarm would immediately be masked. In some cases, however, the number of masked alarms (a counter found in the general parameters) would not get incremented.

- When a row was added to a masked table or a masked column and an alarm was generated for that row, the alarm would immediately be masked. In some cases, however, the comment in the alarm would incorrectly be set to “Masked by” instead of “Parameter masked by”. As a result, after the element was restarted, the number of masked alarms (a counter found in the general parameters) would incorrectly be doubled.

#### DataMiner Cube - Service & Resource Management: ListView component embedded on a Visio page would no longer get updated properly \[ID_24808\]

In some cases, a ListView component embedded on a Visio page would no longer get updated properly.

#### DataMiner Cube - Service & Resource Management: Column headers in ListView components could lose their filter and sort controls \[ID_24814\]

In a ListView component, which is used in the Bookings and Services apps as well as in Visual Overview, in some cases, column headers could lose their filter and sort controls.

#### DataMiner Cube: Sidebar would stay invisible until Cube window was resized \[ID_24819\]

When you log in to a DataMiner Cube of which the sidebar was collapsed, in some cases, the sidebar would stay invisible until the entire Cube window was resized.

#### HTML5 apps: Value changes made by the program were not detected \[ID_24822\]

When, in an HTML5 app, a value had been updated manually, in some cases, the input control would not take into account subsequent updates of that same value made by the program.

#### When an unmonitored element in timeout was masked and then unmasked when it was no longer in timeout, its alarm state would be set to 'normal' instead of 'undefined' \[ID_24838\]

When an unmonitored element in timeout was masked and then unmasked after it had gone out of timeout, its alarm state would incorrectly be set to “normal” instead of “undefined/not monitored”.

#### DataMiner Cube: Problem when initializing the Element Connections module \[ID_24847\]

In some rare cases, an exception could be thrown when the Element Connections module was being initialized.

#### DataMiner Cube - Service & Resource Management: ListView component embedded on a Visio page would incorrectly display booking property updates \[ID_24854\]

In some cases, a ListView component embedded on a Visio page would not correctly display booking property updates.

#### 'Address length of 0' error added to SLErrors.txt when loopback network adapters were found during a DataMiner startup \[ID_24864\]

When DataMiner was started on a system with loopback network adapters, the following error would be added to the SLErrors.txt log file:

```txt
L::GetLocalMAC|ERR|-1|Address length of 0
```

#### DataMiner Cube: Problem when entering special characters in header search box \[ID_24869\]

When, in the header search box, you searched for special characters (e.g. “++”), no results would be returned, even when results were available.

#### DataMiner Maps: Problem retrieving the alarm level for a marker from a column different from the primary key \[ID_24870\]

In some cases, it would no longer be possible to retrieve the alarm level for a marker from a column different from the primary key.

#### DataMiner Cube - Trending: Problem when saving a trend group \[ID_24875\]

When you saved a trend group after editing it, in some cases, an exception would be thrown and no changes would be saved.

#### DataMiner Cube: Collapsing the sidebar would cause it to go into an invalid state \[ID_24877\]

In some cases, collapsing the sidebar would cause it to go into an invalid state.

#### Dashboards app: Problem with CPE feed \[ID_24884\]

In some cases, the Dashboards app would become unresponsive after selecting a chain and a field in a CPE feed.

#### DataMiner Cube - Scheduler: No 'next runtime', 'last runtime' or 'last runtime result' information displayed when a DMA in the DMS was unreachable \[ID_24894\]

On the List tab of the Scheduler app, in some cases, no “next runtime”, “last runtime” or “last runtime result” information would be displayed when one of the DataMiner Agent in the DMS was unreachable or disconnected.

#### Db.xml: 'oldstyle' argument of Offload tags would be removed when database settings were updated via Cube \[ID_24895\]

When a user had manually specified an *oldstyle* argument in an *\<Offload>* tag of the *Db.xml* file, that argument would be removed the first time the central database settings were updated via DataMiner Cube. From now on, Cube will no longer remove manually added *oldstyle* arguments.

#### DataMiner Cube - Visual Overview: Views selection boxes on Edit Shape pane were empty when editing a Visio file in Cube \[ID_24900\]

When editing a Visio file in DataMiner Cube using “edit mode”, in some cases, selection boxes listing all views in the DataMiner System displayed on the Edit Shape pane on the right would incorrectly be empty.

#### 'Unknown Parameter: Rollback' notice when installing Cassandra or Indexing Engine \[ID_24913\]

During a Cassandra or Indexing Engine installation, in some cases, an “Unknown parameter: NoRollback” notice would be generated.

From now on, upgrade packages will ignore the “SetOption NoRollback” command and will add an “info” line to the log saying “Ignoring NoRollback option (legacy)”.

#### Problem with SLSNMPManager when registering SNMPv3 elements with empty passwords \[ID_24944\]

In some cases, an error could occur in the SLSNMPManager process when registering SNMPv3 elements with empty passwords.

#### DIS inject would only store the first injected DLL file \[ID_24948\]

When debugging a QAction, in some cases, when DIS injected a DLL, it would no longer update the reference to that file. In other words, when you updated the QAction and re-injected the DLL, the previous version of that DLL would still be referenced.

#### Matrix crosspoint update would not be applied when connected to a DMA other than the one hosting the element \[ID_24950\]

When a matrix crosspoint was updated via a QAction using one of the following calls, in some cases, the update would not be applied when connected to a DataMiner Agent other than the one hosting the element:

- SendToDisplay(pid, x, y);
- SendToDisplay(pid, int\[\], int\[\]);

#### DataMiner Cube - Visual Overview: Line property configuration not taken into account when determining highlight style priorities \[ID_24955\]

When, in a DCF context, you configure highlight styles that are only applied if the path comes from a certain source and (optionally) goes to a certain destination, it is possible to give one style priority over another style. In some case, however, the line property configuration would not correctly be taken into account when determining those priorities.

#### DataMiner Cube: 'Spectrum settings:' label incorrectly displayed on 'Advanced element settings' pane of element without Spectrum Analyzer settings \[ID_24956\]

When editing an element without any Spectrum Analyzer settings, in some cases, when you opened the *Advanced element settings* pane, a “Spectrum settings:” label would incorrectly be displayed at the bottom of the pane.

#### DataMiner Cube - Services app: Problem when updating a service definition diagram \[ID_24959\]

When you updated a service definition diagram, in some cases, the diagram of another service definition would incorrectly be updated instead.

#### DataMiner Cube - Alarm Console: Cube could become unresponsive when the mechanism was triggered to automatically remove information events \[ID_24965\]

When, in the Alarm Console, the list of information events in the *Information events* tab exceeds 1100 items, the oldest 100 events are automatically removed.

When that automatic removal mechanism was triggered, in some rare cases, DataMiner Cube could become unresponsive.

#### Invalid values in SNMPv3 element configurations would cause DataMiner Agents to get disconnected from each other \[ID_24979\]

When SNMPv3 element configurations contained invalid values, in some cases, DataMiner Agents could get disconnected from each other.

#### Update of the SNMP protocol type or credential library of an advanced port would not get saved in the element.xml file \[ID_24983\]

When you updated an element, in some cases, an update of the SNMP protocol type or the credential library of an advanced port would not get saved in the element.xml file.

#### DataMiner Cube - Service & Resource Management: ListView component did not allow sorting on custom property columns \[ID_24984\]

In a ListView component, in some cases, it would not be possible to sort on custom property columns.

#### Problem with SLDMS when synchronizing a file with a name containing percentage character while the log level was set to 5 or 6 \[ID_24985\]

During a midnight synchronization, in some cases, an error could occur in the SLDMS process when a file with a name containing “%” was being synchronized while the log level was set to 5 or 6.

#### DataMiner Cube - Services app: Selected node, edge or interface would no longer be selected after a service definition was refreshed \[ID_24994\]

When, in the Services app, a service definition was refreshed, in some cases, the node, edge or interface that was selected before the refresh would no longer be selected after the refresh.

#### DataMiner Cube: Newly created service not selected in card breadcrumbs \[ID_25005\]

When you created a new service, in some rare cases, the name of that service would incorrectly not be selected in the breadcrumbs of the service card.

#### Indexing Engine: Problem when storing large string values \[ID_25007\]

When a string value larger than 32,000 bytes was written to an Indexing Engine, in some cases, that value would not be indexed and an exception would be thrown.

#### DataMiner Cube: List view column configuration issues \[ID_25009\]

When a custom property column was renamed in a list view component, either embedded in Visio or in the Services or Bookings app, it could occur that the custom name was not applied correctly.

In addition, if the list view column layout was customized via the context menu, it could occur that the column configuration window did not correctly reflect the customized layout.

#### Problem when retrieving CPE-related data from a Cassandra database \[ID_25019\]

In some cases, an exception could be thrown when retrieve CPE-related element data from a Cassandra database.

#### CPE Management: Problem when resolving recursively linked keys \[ID_25023\]

In some cases, recursively linked keys would be resolved incorrectly. This would especially affect the retrieval of CPE data (e.g. alarm properties).

#### DataMiner Cube: Minor issues with the new DataMiner X UI layout \[ID_25026\]

A number of minor issues with the new DataMiner X UI layout have been fixed.

#### Memory leaks in SLDMS \[ID_25041\]

In some cases, the SLDMS process could leak memory.

#### DataMiner Cube: Problem with unstable DataMiner Agent connections when upgrading an entire DataMiner System \[ID_25043\]

When, in DataMiner Cube, you started an upgrade of the entire DataMiner System, in some cases, the Upgrade window could become unresponsive when one or more of the DataMiner Agents being upgraded had an unstable connection.

From now on, when you start an upgrade of an entire DataMiner System, agents with an unstable connection will no longer be included in the upgrade operation and a warning will be displayed.

#### Dashboards app - CPE feed: Field values for columns other than the primary key would not be applied \[ID_25050\]

When using a CPE feed, in some cases, field values for columns other than the primary key would not be applied.

The URL argument “cpes” now has the following extended format:

```txt
?cpes=dmaID%2FeID%2FFieldPID%2FFieldValue%2FTableIndexPID%2FIndexValue
```

#### Interactive Automation scripts: Problem with checkbox updates \[ID_25054\]

In interactive Automation scripts, in some cases, checkbox components would not be updated correctly.

#### SLDMS run-time errors when connection with remote DMA could not be initialized \[ID_25068\]

When the connection with a remote DMA could not be initialized, run-time errors could occur in the SLDMS process.

#### SLDataMiner: Memory leak when retrieving security group information from the user directory \[ID_25080\]

In some cases, SLDataMiner could leak memory when retrieving security group information from the user directory.

#### Trending displayed incorrectly in case of multiple trend points in the same second \[ID_25097\]

If there were multiple trend points in the same second, it could occur that these were not sorted correctly, which could cause a trend graph to be displayed incorrectly.

#### DataMiner Cube: Problem when clicking several times in rapid succession or when a log folder was created on a clean client computer \[ID_25099\]

In DataMiner Cube, in some cases, an exception could be thrown when clicking several times in rapid succession or when the *C:\\ProgramData\\Skyline\\DataMiner\\DataMinerCube\\CubeLogging* folder was created on a clean client computer.

#### HTML5 apps: Last item in drop-down lists was hidden by the collapse button \[ID_25108\]

In the HTML5 apps (Ticketing, Jobs, etc.), in some cases, the collapse button at the bottom of a drop-down list would hide the last item in the list.

#### DataMiner Cube - EPM/CPE: No Topology button in sidebar \[ID_25120\]

On EPM/CPE systems, in some cases, no Topology button would be displayed in the sidebar.

#### DataMiner Cube - Visual Overview: Embedded Service Manager component would show an empty service definition diagram \[ID_25140\]

In some cases, a Service Manager component embedded on a Visio page would show an empty service definition diagram.

#### Problem with implicitly launched downgrade actions during other than full upgrades \[ID_25158\]

Up to now, other than full upgrades that restarted DataMiner would implicitly have downgrade actions executed as part of the “Start” step. When the upgrade package contained a buildinfo.bin file with an old version number, in some cases, that could leave the system in a corrupted state.

#### Dashboards app: Minor fixes made to trend graph legend \[ID_25159\]

A number of minor fixes have been made to the trend graph legend.

#### Primary key(s) would be parsed incorrectly when reading from a logger table \[ID_25167\]

When reading from a logger table, in some cases, the primary key(s) would be parsed incorrectly.

#### SLNetClientTest tool: Messages/events displayed incorrectly in follow session \[ID_25184\]

In some cases, in a follow session of the SLNetClientTest tool, it could occur that some messages or events were displayed as "*Skyline.DataMiner.Net.Serialization.ProtoBufSerializedMessage*", making it impossible to check their content.

#### DataMiner Cube - EPM: Duplicate parameters in EPM details \[ID_25199\]

In some cases, when DataMiner Cube polled a direct view table for updates, it could occur that EPM (formerly known as CPE) parameters in the corresponding EPM details overview were duplicated.

#### DataMiner Cube - Spectrum analysis: When a user disconnected from a shared session, the other users would stop receiving new traces \[ID_25201\]

When multiple users shared the same spectrum session, in some cases, from the moment one of those users disconnected, all other users would stop receiving new traces.

#### DataMiner Cube - System Center: Not possible to delete unused Visio files \[ID_25209\]

In some cases, it would no longer be possible to delete unused Visio files in the Tools section of System Center.

#### Problem with SLProtocol when starting a DVE element or a virtual function \[ID_25215\]

In some cases, an error could occur in SLProtocol when starting a DVE element or a virtual function.

#### ActiveDirectory.txt log file missing \[ID_25218\]

In some cases, it could occur that the *ActiveDirectory.txt* log file was not generated.

#### Problem with SLNet when performing a diagnostic request in the SLNetClientTest tool while view states were being recalculated \[ID_25219\]

In some cases, an error could occur in SLNet when you performed a diagnostic request (*Diagnostics \> Connections \> OpenConnections*) in the SLNetClientTest tool while view states were being recalculated.

#### Run-time error in protocol thread after dynamic IP change or close action of serial connection \[ID_25223\]

If a protocol with serial connection over UDP or TDC/IP used either an action of type "close" on a serial connection or a parameter with type option "dynamic IP", a run-time error could occur in the protocol thread.

#### Automation: Options text in narrow Automation script execution window not fully displayed \[ID_25226\]

In the window displaying the options for the execution of an Automation script, text wrapping was not implemented, so that it could occur that the text was not fully displayed if the window was too narrow.

#### Problem with EPM filters \[ID_25231\]

When an object in an EPM (formerly known as CPE) environment did not have a link to a parent object, it could occur that filters were loading indefinitely or kept showing the previous filter result.

#### Memory leak in SLNet when multiple documents were being added or deleted in rapid succession \[ID_25234\]

When multiple documents were being added or deleted in rapid succession, in some rare cases, SLNet could start leaking memory.

#### Mobile Gateway: Possible error when updating the cache due to a locking issue \[ID_25238\]

When SLGSMGateway updated its cache after an element had been added, updated or deleted, in some cases, an error could occur due to a locking issue.

#### Problem when the view column of a table containing DVE child elements to be created contained single view IDs \[ID_25255\]

A table containing DVE child elements to be created can have a column that contains the view(s) the child element has to be created in (i.e. a column with option=”view”). In the cells of this column, you can enter a single view ID, a single view name, a list of view IDs separated by semicolons, a list of view names separated by semicolons or a mixed list of view IDs and view names separated by semicolons.

In some cases, a problem could occur when single view IDs had been entered in this column.

#### Service & Resource Management: Capabilities marked 'ByProfileInstanceReference' would never go into quarantine \[ID_25260\]

When a capability usage on a ReservationInstance was updated by updating and applying a ProfileInstance, capability usages that needed to be quarantined would never be quarantined.

#### SLNet: Problem when restarting a DataMiner Agent \[ID_25263\]

In some rare cases, the following exception could be thrown when restarting a DataMiner Agent:

```txt
Exception during startup of SLNet: System.IO.IOException: The process cannot access the file 'c:\skyline dataminer\logging\SLClient.txt' because it is being used by another process.
```

#### DataMiner Maps: Clusters would not get refreshed when panning on a map that only contained layers of which the LimitToBounds attribute was set to False \[ID_25265\]

When panning on a map that only contained layers of which the *limitToBounds* attribute was set to False, in some cases, the clusters would not get refreshed.

#### Dashboards app - Service Definition component: Elements disappeared from service definition nodes when web sockets were disabled \[ID_25275\]

When a Service Definition component was added to a dashboard, in some cases, elements would incorrectly disappear from service definition nodes when web sockets were disabled.

#### Problem with SLNet when retrieving CPU usage or memory usage \[ID_25279\]

In some cases, an error could occur in SLNet when retrieving the CPU usage or the memory usage.

#### Automation: Scripts using a library could no longer be executed after a DataMiner restart \[ID_25282\]

After a DataMiner restart, in some cases, Automation scripts that used a library could no longer be executed because the DataMiner Agent was not able to find the DLL file of that library.

#### DataMiner Cube - Workspaces: A saved workspace could no longer be opened in an undocked window \[ID_25308\]

In some cases, it would no longer be possible to open a saved workspace in an undocked window.

#### DataMiner Cube - Data Display: When a multiple parameter update was canceled, the parameter values would stay marked as modified \[ID_25313\]

When you updated multiple parameter values in one go and then canceled the update, in some cases, the parameter values in question would stay marked as modified.

Also, after updating other values, the multiple update window would incorrectly keep displaying the values for which the update had been canceled.

#### DataMiner Cube - System Center: Colored background remained visible when no filter was applied on the Logging page \[ID_25316\]

When, on the Logging page in System Center, you apply a filter, the background turns blue to indicate that you are viewing a filtered list. In some cases, the background would remain blue after the filter had been removed.

#### DataMiner Cube - Correlation: New analyzer would incorrectly be created when opening the Correlation app via a workspace \[ID_25320\]

When you opened the *Correlation* app by opening a workspace, in some cases, the *Analyzers* tab would be selected and a new analyzer would incorrectly be created.

#### Service & Resource Management: When a resource was updated, usages of other resources would incorrectly also be quarantined \[ID_25322\]

When, for a particular resource, a capacity or capability was deleted or a capability was downgraded, not only would all usages of that resource be quarantined, but also all usages of other resources using the same capacity or capability profile as the one used by the resource that was updated.

#### DataMiner Cube: Problems when renaming/deleting Documents folders \[ID_25323\]

In some cases, it could occur that it was not possible to rename or delete a Documents folder in DataMiner Cube. In addition, when a Documents folder was deleted, it could occur that an incorrect message was displayed, which would remove the folder even if the user clicked "No".

#### Problem with subscriptions on virtual functions \[ID_25326\]

In some cases, subscriptions on virtual functions would not return the correct data.

#### Dashboards app - Service definition component: System function nodes did not show images \[ID_25329\]

In some cases, images would be missing from system function nodes displayed on a service definition component.

#### DataMiner Cube - Visual Overview: Filtered ListView listing services would not get updated when the filter value changed \[ID_25335\]

When, in Visual Overview, a ListView component was listing services and was filtered on a view, in some cases, the services list would not get updated when the filter value changed.

#### Problem with duplicate trend data points when retrieving real-time trend data from a MySQL database \[ID_25337\]

When real-time trend data was retrieved from a MySQL database, in some cases, duplicate trend data points could incorrectly be returned.

#### DataMiner Cube - EPM: Filters would not correctly handle user filter and partial table pages when linked to a diagram \[ID_25339\]

In some cases, EPM filters linked to a diagram would not correctly handle partial table pages and user filters. Only the first page of the result set would be loaded into the selection box, and a custom filter entered by the user would not be applied.

#### When a function resource was deleted, its row in the \[Generic DVE Linker Table\] would incorrectly not be removed \[ID_25356\]

When a function resource is created, a row is added to both the \[Generic DVE Table\] and the \[Generic DVE Linker table\]. When a function resource was deleted, in some cases, only the row in the \[Generic DVE Table\] was deleted. The row in the \[Generic DVE Linker table\] would incorrectly not get deleted.

#### Problem with interface properties of DVE elements \[ID_25360\]

When, in the DataMiner Connectivity Framework page of the General Parameters of an element, the \[Interface Properties\] table was updated, in some cases, some of the information in that table would not get synchronized correctly to the interfaces of the Virtual Function elements when linking them.

#### DataMiner Cube - Trending: Problem when export a trend graph to a CSV file \[ID_25369\]

When you exported a trend graph to a CSV file, in some cases, that CSV file would be formatted incorrectly, especially when the exported graph contained multiple lines.

#### Invalid alarm levels were passed to the parent items when bubble-up severity was identical to that of the table row and one of them got cleared \[ID_25383\]

When the bubble-up severity was identical to that of the table row itself, and one of those was cleared, in some cases, an invalid alarm level would be passed to the parent items.

#### Web Services API v0: GetActiveAlarmsFromView SOAP call would return alarms from parameters not included in the services found in the specified view \[ID_25391\]

When a GetActiveAlarmsFromView SOAP call was performed, all alarms of all elements in the services found in the specified view would be returned, even those associated with parameters that were not included in the services in question.

#### Element connections: Problem with 'Include element state' option \[ID_25418\]

In the *Element Connections* app, in some cases, the states of the source element would incorrectly be passed to the destination element(s) when the *Include element state* option was not selected.

#### DataMiner Cube - Services app: Problem when dragging and dropping in a service definition diagram \[ID_25434\]

In the *Services* app, in some rare cases, an exception could be thrown when performing drag and drop operations in a service definition diagram.

#### Service & Resource Management: No longer possible to save a service definition with an empty diagram \[ID_25439\]

In the Services app, in some cases, it was no longer possible to save a service definition with an empty diagram.

#### Alarm templates: Monitoring conditions would not get re-evaluated after a row or table update \[ID_25453\]

When, in an alarm template, conditional monitoring was configured, in some cases, conditions would not get re-evaluated after a row or table update.

#### Problem with SLDataMiner \[ID_25458\]

In some rare cases, an *OwnershipUpdateThread* error could occur in SLDataMiner.

#### DataMiner Cube - Visual Overview: Problem with FollowPathColor option \[ID_25460\]

In some rare cases, the *FollowPathColor* option would not get applied, especially when the connection lines ran between interfaces with an undefined alarm level state while the parent element had a different state.

#### DataMiner Cube: Inconsistent user initials \[ID_25464\]

Up to now, in some cases, user initials in DataMiner Cube would be inconsistent. Now, user initials will always be the first letters of the full name.

Note that, by design, the user selector at the bottom of the login screen will still display only one letter (i.e. the first letter of the full name).

#### DataMiner Cube - Services app: Items in diagram would still appear to be selected after switching from one tab to another \[ID_25468\]

When, in the Services app, you switched from one tab to another, in some cases, the items selected in the diagram would still appear to be selected although they were not.

#### DataMiner Cube - Data Display: Problem with filtering on discreet or numerical column parameters using wildcards \[ID_25472\]

In some cases, it would no longer be possible to filter on discreet or numerical column parameters using wildcards.

#### DataMiner Cube: Element/service not visible if moved from inaccessible view \[ID_25474\]

If an element or service was created in a view to which a particular user did not have access and then moved to a view to which that user did have access, it could occur that the user could not see the element or service until Cube was reloaded.

#### Problem when MaintenanceSettings.xml contained Trending tag without TimeSpan tag \[ID_25478\]

If the *MaintenanceSettings.xml* file contained a *Trending* tag that did not contain a *TimeSpan* tag, a problem could occur with the file.

#### Monitoring app: Problem when viewing a trend histogram for a column parameter with a primary key containing lowercase characters \[ID_25481\]

In the Monitoring app, in some cases, no data would be returned when viewing a trend histogram for a column parameter with a primary key containing lowercase characters.

#### Dashboards app - Parameter feed: Bottom arrow not displayed when 100 indices had been loaded \[ID_25492\]

When, in the parameter feed component, you had loaded 100 indices, the bottom arrow to load more indices would not be displayed.

#### DataMiner Cube - Element Connections: Problems with table parameters \[ID_25496\]

In the *Element Connections* app, in some cases, issues could occur with regard to table column parameters. Some rows would not disappear after being deleted and some rows would be missing data.

#### Web Services API v0/v1: Methods would return parameters to which users had not been granted access \[ID_25544\]

Some of the web methods would incorrectly return parameters to which users had not been granted access. From now on, a number of parameter-related methods will also require the “SDElementOverview” flag.

Also, the GetTableForParameterV2 method would incorrectly return table columns that had “width=0” defined in the protocol, and, in some cases, it would incorrectly be possible to update a parameter of an element marked as “read only”.

#### Trending data not cleaned up in Failover MySQL database \[ID_25552\]

If a Failover pair used MySQL local databases, it could occur that trending data was not removed from the database when its time to live had elapsed.

#### DataMiner Cube - Alarm Console: Correlation source alarms were sorted incorrectly \[ID_25570\]

When, in the Alarm Console, you opened a correlation alarm to view its source alarms, in some cases, those source alarms would not be sorted correctly.

## Addendum CU2

### CU2 enhancements

#### Cassandra database: Cluster name in cassandra.yaml file now always set to 'DMS' \[ID_24645\]

In a cassandra.yaml file, the cluster name will no longer be configurable. It will now always be set to “DMS”.

> [!NOTE]
> The Cassandra cluster name is not linked to the DMS cluster name. The latter is still configurable.

#### From now on, only DMAObjectRefTreeRequestMessage requests that update information will be processed sequentially \[ID_24967\]

Up to now, all DMAObjectRefTreeRequestMessage request were processed sequentially. From now on, only those that update information will be processed as such.

#### Decreased CPU load when installing DataMiner \[ID_25291\]

Due to a number of enhancements, overall CPU load has decreased when installing DataMiner.

#### Indexing Engine: Configuring a custom IP port in Db.xml \[ID_25407\]

By default, an Indexing Engine listens for client requests on TCP port 9200.

From now on, it is possible to specify another port in the *Db.xml* file. See the following example.

```xml
<DBServer>localhost:9201</DBServer>
```

#### DataMiner Cube - Automation: Script execution messages will now be sent asynchronously  \[ID_25438\]

Up to now, when an Automation script was launched from Cube, a script execution message would be sent to the DataMiner Agent synchronously. In order to avoid timeout issues, from now on, script execution messages will be sent asynchronously.

#### DataMiner Cube - Visual Overview: Using the \[Reservation\] placeholder no longer requires Cube to retrieve all service information \[ID_25463\]

When the \[Reservation\] placeholder was used in a service context, up to now, Cube would retrieve all service information to get the booking ID. From now on, Cube will no longer do this as the booking ID is now available in the LiteServiceInfoEvent message.

#### DataMiner Cube - Service & Resource Management: A notice will now appear when an Indexing Engine is required or when licenses are missing \[ID_25537\]

When you try to open the *Resources* app or the *Service Definitions* tab of the *Services* app, from now on, a notice will appear, saying that those apps can only be used on systems running an Indexing Engine.

Also, when you open a Visio page containing a ListView component, a notice will now appear in the following cases:

- If the ListView is configured to list elements, a notice will appear when you do not have access to the listed elements.

- If the ListView is configured to list bookings, a notice will appear when the DataMiner System has nor the required software licenses (ResourceManager, ServiceManager, SRM Concurrency) nor an Indexing Engine installed.

#### DataMiner Cube - Visual Overview: ListView component will only show 'clear filter' button when FilterMode option is set to true \[ID_25560\]

From now on, the ListView component will only show the “clear filter” button when the FilterMode option has been set to true.

#### DataMiner Cube - Visual Overview: Column names in legacy ListView column configuration will now be case insensitive \[ID_25589\]

Prior to DataMiner 9.6.13, the column configuration of a ListView component had to be specified in JSON format and column names in that configuration were case sensitive. From now on, column names in a legacy ListView column configuration will be case insensitive.

#### DataMiner Cube: Enhanced timeline tool tip in Bookings app \[ID_25704\]

In the Bookings app and the Bookings app Visio component, from now on, the tool tip showing the time in the bookings timeline will now also be visible when you select a particular area.

#### DataMiner Cube - Scheduler: Task list, event list and profile list are now naturally sorted \[ID_25724\]

In the “Time line” tab of the Scheduler app, the task list, event list and profile list are now naturally sorted.

#### Memory usage of service cache has been reduced \[ID_25726\]

Since DataMiner 9.5, a service cache has made it possible to see the impacted services on cell level. Due to a number of enhancements, this cache’s memory usage has now been reduced.

#### Table of virtual function element remained empty \[ID_25732\]

In some cases, it could occur that a table of a virtual function element did not contain any data.

### CU2 fixes

#### DataMiner Installer: Problem when installing a DataMiner Agent with a Cassandra database \[ID_24762\]

In some cases, the DataMiner Installer would fail to install a DataMiner Agent with a Cassandra database.

#### Problem when sending a GetInfoMessage of type 'IndexConfigurationMessage' while an agent is offline \[ID_24898\]

When, in the DataMiner System, a GetInfoMessage of type “IndexConfigurationMessage” was sent to all agents while one of them was offline, in some cases, the method would return an exception instead of the information received from the online agents.

#### Problem when retrieving alarms with rootkey equal to 0 from the database \[ID_25073\]

In some rare cases, an error could occur when retrieving alarms with a rootkey equal to 0 from the database. From now on, if the database contains alarms with a rootkey equal to 0, those alarms will be ignored and will not be retrieved.

Also, each time an alarm with rootkey equal to 0 is encountered, an entry will now be added to the SLDBConnection.txt log file.

#### DataMiner Cube - Correlation: Problem when saving a Correlation rule mail action that sends a PDF report \[ID_25315\]

When you added a mail action to a Correlation rule and configured that action to send a PDF report, in some cases, that configuration would not be saved correctly.

#### DataMiner Cube - Correlation: Mail action in Correlation rule could not be modified more than once \[ID_25317\]

When, in a Correlation rule, you had configured a mail action, in some cases, it would not be possible to update this action more than once.

#### DataMiner Cube - Spectrum analysis: Problem when editing presets \[ID_25330\]

In a spectrum element card, in some cases, problems could occur when editing presets.

Shared presets could get lost when editing them, and, in some cases, when renaming a preset, DataMiner Cube could show other presets with the same name.

#### DataMiner Cube - Users & groups: Selection was incorrectly cleared when filtering the list of users/groups \[ID_25342\]

When you had selected one or more users or groups in the Add existing user or Add existing group window respectively, in some cases, the selected users or groups would incorrectly get unselected when you filtered the list.

#### DataMiner Cube - Scheduler: Memory leak due to an incorrect clean-up of removed timeline items \[ID_25359\]

In some cases, DataMiner Cube could leak memory due to an incorrect internal clean-up of items removed from the Scheduler timeline.

#### DataMiner Cube - Alarm Console: Problem when grouping or sorting the alarms on an alarm tab page with a sliding window \[ID_25390\]

When, in the Alarm Console, an alarm tab page with a sliding window was grouped or sorted by time, in some cases, the grouping or sorting would not get updated when one of the alarms was updated. Also, when you turned history tracking off and then on again, in some cases, the alarms would no longer be grouped or sorted correctly.

#### Service & Resource Management: Problem when updating the end time of a parent and child ReservationInstance while both were in progress \[ID_25405\]

In some cases, an exception could be thrown when the end time of a parent and child ReservationInstance were updated while both were in progress.

#### DataMiner Cube - Bookings app: Blank time line when opening the app \[ID_25410\]

When you opened the Bookings app for the first time in a Cube session, in some cases, the time line would incorrectly be empty.

Also, due to a number of enhancements, overall performance has increased when opening the Bookings app.

#### Problem when sending an SNMP trap from an element that was being restarted \[ID_25435\]

When an SNMP trap was sent from an element that was being restarting, in some cases, an error could occur.

#### Monitoring app: Password boxes would incorrectly display their contents in normal text \[ID_25467\]

In the Monitoring app, password boxes would incorrectly display their contents in normal text. From now on, the contents of password boxes will be displayed as a series of bullets.

#### DataMiner Cube - Settings: User setting hidden in the group settings would incorrectly also be hidden in the group settings editor \[ID_25480\]

When a user setting was hidden in the group settings, it would incorrectly also be hidden in the group settings editor.

#### Automation: Problem when generating a large report via an Automation script \[ID_25482\]

When a large report was generated via an Automation script, in some cases, all other communication with the SLReportsAndDashboardsManager process could get blocked.

#### Jobs app: Problem when entering text in the search box \[ID_25489\]

When, in the Jobs app, you entered a piece of text in the search box, in some cases, no suggestions would be shown and *index_not_found* exceptions would be added to the logging.

#### Protocols: When no column was polled during a polling cycle, previously polled columns could incorrectly get cleared from memory \[ID_25500\]

When, using a particular pollingRate configuration, there was a polling cycle during which no column was polled, in some cases, previously polled columns could incorrectly get cleared from memory in SLProtocol.

#### DataMiner Cube - Correlation: Placeholders in Correlation emails were not filled in correctly \[ID_25504\]

In some cases, placeholders in Correlation emails would not be filled in correctly.

#### DataMiner Cube - Resources app: Expander showed an incorrect icon \[ID_25541\]

In the Resources app, in some cases, the expander would show an incorrect icon.

#### DataMiner Cube - Alarm Console: Hyperlinks would not update in the hyperlink column \[ID_25566\]

When an alarm had a hyperlink configured that was displayed in a hyperlink column, in some cases, that hyperlink would not get updated when the alarm was updated. The placeholders in the hyperlink would keep on displaying values from the previous alarm.

#### DataMiner Cube - Visual Overview: Alarm timeline component did not correctly aggregate different alarm timelines into a single band \[ID_25590\]

In an alarm timeline component, in some cases, an error could occur when different alarm timelines had to be aggregated into a single band.

#### Dashboards app - Visual Overview component: Problem when no page had been selected in the component settings \[ID_25594\]

When, in the Dashboards app, no page had been selected in the settings of a Visual Overview component, in some cases, that component would show a “Could not retrieve the image for the Visual Overview” error message.

#### Legacy Reporter: Report with trend graph block would incorrectly show a 'No parameters were provided for this element' notice \[ID_25595\]

When, in the legacy Reporter, you generated a report with a “trend graph” block, it would incorrectly display a “No parameters were provided for this element” notice when the parameters in question only had real-time trending enabled.

#### Elements not displayed in DataMiner Cube after connection between DMAs was restored \[ID_25602\]

When two DMAs established contact with each other after their connection had been lost, a problem could occur, which could cause elements not to be displayed in DataMiner Cube.

#### Hysteresis-related issues fixed \[ID_25619\]

A number of hysteresis-related issues were fixed:

- When a parameter had both Hysteresis on and Hysteresis off enabled, and the alarm got a non-value update (e.g comment added, property changed, service impact changed, etc.) during the Hysteresis off period, the alarm would not be cleared and would stay stuck until the value of the parameter would again enter an alarm state.

- When, during either the Hysteresis off period or the Hysteresis on period, a parameter got two value updates within the Normal range, the timestamp of the generated alarm would be that of the latest parameter update rather than that of update that triggered the initial drop to Normal.

- When a parameter that had Hysteresis off enabled and Hysteresis on disabled got two value updates within the Normal range during the Hysteresis off period, the alarm would be instantly cleared (or set to “clearable”) instead of at the end of the Hysteresis off period.

#### Parsing error when field names contained colon characters \[ID_25620\]

When converting a string to a filter, in some cases, a parsing error could occur when field names contained colon characters.

#### CPE cards would remain empty or would keep on loading when a direct view table requested data from an element that was starting up \[ID_25623\]

In some cases, CPE cards would remain empty or would keep on loading when a direct view table requested data from an element that was in the process of starting up.

#### Legacy Reporter / Cassandra: History pages would include alarms that did not match the parameter name filter \[ID_25624\]

When, in the legacy Reporter on systems running a Cassandra database, a parameter name filter was applied to a History page, in some cases, the alarm list would incorrectly include alarms that did not match the filter.

#### Problem with SLSNMPManager when testing a connection of an SNMPv3 protocol \[ID_25626\]

In some cases, an error could occur in SLSNMPManager when testing a connection of a protocol of type SNMPv3.

#### Failover: Problem in case of manual switchover with multiple heartbeats \[ID_25633\]

When, on a Failover system with manual switchover, multiple heartbeats had been configured, in some cases, the main agent would not be able to start up when only one of the heartbeats was successful.

From now on, manual switchover will behave in the same way as automatic switchover.

#### Trend graph showing a trend window with a constant parameter value would incorrectly remain empty \[ID_25646\]

When data is requested for a trend window that shows a constant parameter value, the last data point before the requested trend window should also be retrieved to allow the client application to draw the trend graph. In some cases, that data point would not be retrieved, causing the trend graph to remain empty.

#### SNMP tables without polling rate defined would no longer be polled \[ID_25659\]

In some cases, an SNMP table without polling rate defined on any of its columns would no longer be polled.

#### DataMiner Cube: When exporting an element to CSV, only the timeout of the first communication layer would get exported \[ID_25664\]

When you exported an element to a CSV file, and that element had timeouts defined for each of its communication layers, in some cases, only the timeout of the first communication layer would get exported. When you then imported that element from the CSV file, it would immediately go into timeout.

#### DataMiner Cube - Resources app: Problem when deleting a capability or a capacity from a resource \[ID_25680\]

In the Resources app, it is possible to add capabilities and capacities to resources. When you deleted a capability or a capacity in the user interface, in some cases, the deletion would incorrectly not be implemented on the DataMiner Agent.

#### DataMiner Cube - Trending: Problem with invalid 'NaN' points \[ID_25698\]

When, in a trend graph, an invalid “NaN” point had to be drawn immediately after a gap, in some cases, an error could occur.

#### Parameter updates that did not change the parameter value would incorrectly not be applied \[ID_25736\]

In some cases, parameter updates that did not change the parameter value would not be applied. In case of a history set, this could cause a problem.

From now on, history sets will always be considered value changes, regardless of whether the value is updated or not.

#### DataMiner Cube - Service templates: Empty selection box when right-clicking a view and selecting Actions \> Apply service template... \[ID_25741\]

When you right-clicked a view in the Surveyor, and selected Actions \> Apply service template..., in some cases, the selection box containing the list of service templates to choose from would be empty due to a problem with the selection box filter.

#### DataMiner Cube - Visual Overview: Selected service definition in an embedded ServiceManager component would get unselected when another service definition was modified \[ID_25748\]

In some cases, a service definition selected in an embedded ServiceManager component would incorrectly get unselected when another service definition was modified in another Cube session.

#### DataMiner Cube - EPM: Problem when opening an EPM diagram that used the 'DiagramPids' option \[ID_25797\]

In some cases, DataMiner Cube would freeze when you opened an EPM diagram that used the “DiagramPids” option.

#### DataMiner Cube - Spectrum analysis: Hamburger menu of spectrum card still contained a deprecated link to the legacy Data Display UI \[ID_25799\]

The hamburger menu of a spectrum card still contained a deprecated link to the legacy Data Display UI. This link has now been removed.

#### DataMiner Cube: Login algorithm would incorrectly try to use TLS 1.0 when browser was configured to use TLS 1.2 \[ID_25803\]

When the Internet browser was configured to only use TLS 1.2, in some cases, the Cube login algorithm would incorrectly try to use TLS 1.0 instead.

#### Jobs app: Problem when adding a field of type 'Static Text' \[ID_25930\]

In some cases, an exception could be thrown when you added a field of type “Static Text” to a job section.

## Addendum CU3

### CU3 enhancements

#### BPA test framework update \[ID_25840\]\[ID_25891\]

A number of enhancements have been made to the BPA test framework.

Also, special user permissions will now be required to create, update, delete, read, and execute BPA tests and to be able to receive BPA test results.

Best Practice Analysis (BPA) tests can be uploaded and run using the SLNetClientTest tool.

#### Enhanced service elements will now be started along with all other elements \[ID_25843\]

Up to now, enhanced service elements would be started when the services were loaded. Now, they will be started along with all other elements.

#### Service & Resource Management: Deleting resources based only on ID \[ID_25867\]

When a DataMiner Agent was asked to delete a resource, up to now, it would only delete that resource when all resource properties received matched the resource to be deleted. From now on, a DataMiner Agent will delete a resource based solely on the resource ID received in the delete request.

#### SLDMS: Object handling enhancements to prevent memory leaks \[ID_25879\]

In SLDMS, a number of object handling enhancements have been made to prevent memory leaks.

#### EULA page updated \[ID_25937\]

The EULA page has been updated.

This page can be accessed by clicking *Skyline software license terms* in the *About* window of Cube and the HTML5 applications, or by going to `http://<IP address of DMA>/EULA.htm` on the DataMiner Agent.

#### DataMiner Cube - Protocols & Templates: Link to Cube logging added to error window that appears when a server-side error occurred while uploading a functions file \[ID_25953\]

When a server-side error occurs while uploading a functions file in the Protocols & Templates app, from now on, a hyperlink in the error window will allow you to check the cause of the error in the Cube logging.

#### DataMiner Cube - Ticketing: Tickets page will now by default list all tickets associated with the first ticket domain that is found \[ID_25963\]

When, in a card, you selected the TICKETS page, up to now, that page would show a list of all open tickets across all known ticket domains. From now on, the list of open tickets will by default be restricted to the tickets associated with the first ticket domain that is found.

#### Protocols: Compression algorithm(s) can now be specified in an Accept-Encoding header \[ID_25969\]

In a protocol, it is now possible to specify which compression algorithm(s) should be used when performing a HTTP GET request. See the following examples.

##### Example 1: Using compression algorithm 'deflate'

```xml
<Session id="2">
  <Connection id="1">
    <Request verb="PUT" url="/index.php">
      <Headers>
        <Header key="PutHeader">HEADER_DATA</Header>
        <Header key="Accept-Encoding">deflate</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

##### Example 2: Using compression algorithm 'gzip'

```xml
<Session id="4">
  <Connection id="1">
    <Request verb="POST" url="/index.php">
      <Headers>
        <Header key="Accept-Encoding">gzip</Header>
        <Header key="PostHeader">HEADER_DATA</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

##### Example 3: Using compression algorithms 'deflate' and 'gzip'

```xml
<Session id="6">
  <Connection id="1">
    <Request verb="TRACE" url="/index.php">
      <Headers>
        <Header key="TraceHeader">HEADER_DATA</Header>
        <Header key="Accept-Encoding">deflate;q=0.5,gzip;q=1.0</Header>
      </Headers>
      <Data pid="300"></Data>
    </Request>
    <Response statusCode="100">
      <Content pid="200"></Content>
    </Response>
  </Connection>
</Session>
```

> [!NOTE]
> When no \<Header key="Accept-Encoding"> tag was specified, gzip and deflate compression will be used by default.

#### Error message 'Unknown destination DataMiner specified' replaced by 'Unable to find hosting agent. The agent might still be starting up' \[ID_25976\]

Up to now, when the hosting agent of an element or service could not be found, an “Unknown destination DataMiner specified” error would be thrown. This error message has now been replaced by “Unable to find hosting agent. The agent might still be starting up”.

#### DataMiner Cube - Router Control: Highlighting now also supported when working with linked pages \[ID_26001\]

When you select a routed output in the Router Control app, the crosspoints. the IO button and the tab item(s) of the corresponding button will all be highlighted.

Now, this highlighting feature is also supported in a dynamic environment, i.e. when working with linked pages.

#### DataMiner.xml: XML namespace now set during DataMiner installation \[ID_26011\]

In the *DataMiner.xml* file, from now on, the XML namespace will by default be set to   `xmlns=http://www.skyline.be/config/dataminer` during DataMiner installation.

### CU3 fixes

#### Problem when sending table data from SLElement to SLDataGateway \[ID_25048\]

In some cases, an error could occur in SLElement when sending table data to SLDataGateway.

#### Indexing Engine: Active alias would incorrectly be created as index \[ID_25461\]

In some rare cases, the active alias would be created as index.

#### Problem with SLNet connections when a large amount of requests were sent over them \[ID_25613\]

In some cases, an SLNet connection could break when a large amount of requests were sent over it.

Together with this fix, the following changes have also been made:

- Automatic recovery of SLNet connections has now been rendered obsolete and is no longer supported.

- The event cache log options (SLNetClientTest \> Advanced \> Options \> SLNet Options \> EventCacheLogOptions) now support “filter=xxxxx” keywords to limit the output to specific types. “xxxxx” can be “element”, “dma”, “alarm” or any of the types listed in SLNetClientTest \> Diagnostics \> Caches & Subscriptions \> GeneralCacheStats \> Cache for xxxxxxxxx.

#### Miscellaneous small fixes \[ID_25645\]

A number of small fixes have been made, including the following:

- In some cases, a run-time error could occur in “Database Offload Thread \[local\]” when a DataMiner startup took too long.

- SLElement could leak memory when registering a link with an empty filter or when initializing a parameter group.

- The SLElement.txt log file will now indicate that it is loading all active alarms from the database. This will make it easier to analyze DataMiner startup issues.

- The license check will now skip adapters without MAC address.

- In some cases, especially when dealing with SNMPv3 elements, the following error could appear.

    ```txt
    Failed trying to send an initial cached event to EGMCC [...] System.ArgumentNullException: Value cannot be null
    ```

- In some cases, the following error could be added to the SLErrors.txt log file.

    ```txt
    SLDBConnection.txt|SLDBConnection|SLDBConnection|ERR|0|1|Failed to deserialize TableDefinitions Could not find file 'C:\Skyline DataMiner\Database\TableDefinitionCollection.xml'
    ```

- In some cases, the following errors could be added to the SLErrors.txt log file during DataMiner startup for each exported protocol:

    ```txt
    CDataMiner::NotifySLElementProcess|ERR|-1|Notify SLELement process failed (86): 0x8004024c: The element is unknown.
    CExportProtocolsHandler::ExportProtocols|ERR|0|Failed exporting protocol with 0x8004024c The element is unknown.
    ```

- In some cases, the following errors could be added to the SLErrors.txt log file during DataMiner startup:

    ```txt
    Could not load XSD: C:\Skyline DataMiner\Tools\Schemas\MobileGatewaySchema.xsd
    XSD URI was empty for: C:\Skyline DataMiner\Elements\xxxxxxxxx\Description.xml
    ```

#### DataMiner Cube - Visual Overview: Problem with session variables used by the Resource Manager timeline component \[ID_25718\]

In some cases, certain session variables used by the Resource Manager timeline component (e.g. YAxisResources) would not work properly when the page contained a setvar shape but no initvar action.

#### DataMiner Cube: Properties window of service or view would show incorrect Visio file extension \[ID_25760\]

In the Properties window of a service or a view, you can check the name of the Visio file that was assigned to that service or view. In some cases, when the extension of the file was “vdx” or “zip”, it would incorrectly be shown as “vsdx”.

#### Element that generated a large amount of data would be missing data after being restarted \[ID_25761\]

When an element that generates a large amount of data was restarted, in some cases, it would be missing data when it started up again.

#### Upgrade action 'CassandraActiveAlarmsRootOnlyUpgrade' would incorrectly only be run once \[ID_25764\]

Up to now, when a DataMiner Agent with a Cassandra database was upgraded, the upgrade action “CassandraActiveAlarmsRootOnly” would incorrectly only be run once. Now, it will be rerun at every upgrade until no more errors are reported.

Also, an additional upgrade action will now be run at every upgrade. The “CassandraDistinct-PropertiesUpgrade” action will check all alarms in the database and fix any incorrect alarm properties it encounters.

#### DataMiner Cube - Visual Overview: Problem with parameter chart updates \[ID_25777\]

When using a parameter chart, in some rare cases, that chart’s update interval would incorrectly be set to 0 seconds. As a result, it would be updated constantly. From now on, setting the update interval of a parameter chart to 0 seconds will no longer be possible.

#### DataMiner Cube - Profiles app: Modification of profile instance field 'applies to' would incorrectly be disregarded \[ID_25790\]

When configuring a profile instance in the Profiles module, you can indicate to which profile definition the instance applies. In some cases, when you changed this field, the modification would be disregarded.

#### Problem when sending an SNMP trap from an element that was being restarted \[ID_25794\]

When an SNMP trap was sent from an element that was being restarting, in some cases, an error could occur.

#### DataMiner Cube - Alarm Console: Problem when enabling or disabling history tracking \[ID_25813\]

When you enabled or disabled history tracking while viewing an alarm tab page that contained a large number of alarms, in some cases, Cube would become unresponsive.

#### DataMiner Cube - Visual Overview: Problem with \[profile:xxx\] placeholder \[ID_25817\]

In some cases, the \[profile:xxx\] placeholder would no longer be resolved correctly.

#### DataMiner Cube - Router Control: Options field of InfoPanel block would incorrectly be disregarded \[ID_25818\]

When, while configuring an InfoPanel block in the Router Control app, options had been specified in the Options field, those options would incorrectly be disregarded when the matrix configuration was loaded.

#### Memory leak in SLPort \[ID_25846\]

While a SmartIPHeader UDP socket was receiving data from multiple clients, in some cases, the SLPort process could leak memory when another client was detected.

#### Disabling the 'Enable DVE child creation' option in the 'Advanced element settings' would prevent the creation of virtual functions \[ID_25869\]

In some cases, disabling the Enable DVE child creation option in the Advanced element settings would incorrectly prevent the creation of virtual functions.

#### Alarms would have incorrect properties \[ID_25880\]

In some cases, alarms would have incorrect properties.

#### EPM view cards would not always have the same title \[ID_25895\]

If the name of the enhanced view was not identical to the system name, the EPM card of that view would not always have the same title. The title displayed would depend on the way in which the card was opened.

#### Problem caused by missing \<BackupSettings> tag in MaintenanceSettings.xml \[ID_25908\]

Up to now, when the \<BackupSettings> tag was missing from the MaintenanceSettings.xml file, it would not be possible to save backup settings.

From now on, when the MaintenanceSettings.xml file does not contain a \<BackupSettings> tag, it will automatically be added and filled with the correct settings.

#### DataMiner Cube: Element card of a Dynamic Virtual Element incorrectly had a 'Notes' page \[ID_25910\]

Up to now, when you opened the card of a Dynamic Virtual Element, it incorrectly had a Notes page. As DVE elements currently cannot have notes, this page has been removed.

#### DataMiner Cube - Listview: Problem when column icons got a severity update \[ID_25916\]

When a column in a ListView component was configured to show alarm icons, in some cases, an error could occur when one of those icons got a severity update.

#### Duplicate logger table storage types would incorrectly be created when migrating from MySQL to Cassandra \[ID_25935\]

When migrating a database from MySQL to Cassandra, in some cases, duplicate logger table storage types would incorrectly be created.

#### Problem when migrating newly created trend data from MySQL to Cassandra \[ID_25971\]

When you created an element or started trending a parameter and then, afterwards, migrated from MySQL to Cassandra, in some cases, the newly created trend data would not be migrated.

#### Automation: Problem when calling FindElements with a 'WarningOnly' element filter \[ID_25973\]

When the FindElements method was called with a “WarningOnly” element filter, in some cases, it would incorrectly return all elements.

#### Problem when multiple smart-serial elements using the same port restarted \[ID_25982\]

In some rare cases, an error could occur when multiple smart-serial elements using the same port restarted.

#### DataMiner Cube - Visual Overview: Tree view with 'SingleSelectionMode' option would incorrectly allow multiple values to be selected after a filter had been applied \[ID_25986\]

When, on a Visio page, you selected an item in a tree view to which you had added the “SingleSelectionMode” option, applied a filter and then selected another item, in some cases, the item you selected previously would incorrectly remain selected.

## Addendum CU4

### CU4 enhancements

#### DataMiner Cube - Automation: Dummies, parameters and memory files now sorted in the order in which they were added to the script \[ID_25897\]

Up to now, the dummies, parameters and memory files added to an Automation script were sorted naturally. From now on, they will be sorted in the order in which they were added to the script.

#### DataMiner Cube - Visual Overview: Colors linked to the Cube theme will now be changed immediately when you change the Cube theme \[ID_26045\]

When, in a Visio drawing, you linked some colors to the colors used in the DataMiner Cube theme, then those colors will now immediately be changed when you change the DataMiner Cube theme. You will no longer have to close and re-open the Visio drawing to have the changes take effect.

#### DataMiner Cube: Embedded Chromium web browser engine updated from v63 to v81 \[ID_26171\]

The embedded Chromium web browser engine has been updated from v63 to v81.

#### Automation: UnSetFlag method added to Intellisense \[ID_26176\]

In the Automation module, the *UnSetFlag* method has now been added to Intellisense.

#### Text will now be written to the log files using UTF-8 encoding \[ID_26194\]

From now on, text will be written to the log files using UTF-8 encoding.

#### Trending of column parameters with measurement type 'string' is now also supported \[ID_26230\]

From now on, trending of column parameters with measurement type set to “string” is also supported.

#### Enhanced performance when displaying and updating parameter values \[ID_26382\]

Due to a number of enhancements, overall performance has increased when displaying and updating parameter values, both in Data Display and Visual Overview.

### CU4 fixes

#### Problem when taking Agents out of a Failover setup with a Cassandra database \[ID_24787\]

In some cases, it would no longer be possible to correctly take an Agent out of a Failover setup with a Cassandra database.

#### Problem with SLDMS due to memory issues \[ID_25890\]

In some cases, an error could occur in SLDMS due to memory issues.

#### DataMiner Cube: When, in the Generic DVE Linker Table, a link associated with a virtual function was changed while its element card was open, its parameters would not get updated \[ID_25913\]

When, in the Generic DVE Linker Table, a link related to a virtual function was added, updated or removed while its element card was open in DataMiner Cube, the parameters of that function would incorrectly not get updated.

#### Service & Resource Management: State of ReservationInstance would incorrectly be set to Interrupted when it was updated after a DMA restart \[ID_25938\]

When you restarted a DataMiner Agent with an ongoing ReservationInstance and then updated the end time of that ongoing ReservationInstance after the restart, in some rare cases, the state of the ReservationInstance would incorrectly be changed from “Ongoing” to “Interrupted”.

#### Duplicate table change notifications would be sent from SLElement to SLDataGateway when using history sets in combination with table updates \[ID_25987\]

When history sets were used in combination with table updates, in some cases, duplicate table change notifications would incorrect be sent from SLElement to SLDataGateway when the values remained stable.

#### Hotfixes not properly validated during installation \[ID_25991\]

In some cases, it could occur that hotfixes were not properly validated during installation, so that a hotfix could be installed on an incompatible version of DataMiner.

#### When adding or editing an element, some fields would not correctly be saved into the element.xml file \[ID_25994\]

When adding or editing an element, in some cases, the contents of a number of fields (e.g. GetCommunity, SetCommunity, etc.) would not correctly be saved into the element.xml file.

#### DataMiner Cube - Alarm Console: Alarm duration indicator was missing \[ID_26044\]

In the Alarm Console, in some cases, the alarm duration indicator would not be shown in the Time column of a certain alarm, even though the Show alarm duration indicator option was enabled in the hamburger menu of the Alarm Console.

The problem would occur in the following situations:

- When you expanded a correlation alarm, the alarm duration indicator of the source alarms would disappear.
- When, for a particular alarm, an update was received while its history was expanded, the alarm duration indicator of the alarms in the history list would disappear.

#### Automation scripts: Problem when a parameter specified in an email action contained a double quote character \[ID_26046\]

When, in an Automation script, you specified a parameter containing a double quote character in an email action configured to send a report, in some cases, it would not be possible to save the script.

#### DataMiner Cube - Trending: Zoom buttons in top-right corner of a trend graph window would incorrectly not be displayed \[ID_26068\]

When you opened a trend graph, e.g. by clicking the trend graph icon next to a parameter shown on an element card, in some cases, the zoom buttons (Last 24 hours, Week to date and Month to date) in the top-right corner would incorrectly not be displayed.

#### Deadlock between SLNet and SLDataGateway during a DataMiner startup or a Failover switch \[ID_26074\]

Due to a flushing issue in SLNet, in some cases, a deadlock could occur between SLNet and SLDataGateway during a DataMiner startup or a Failover switch.

#### DataMiner Cube - Visual Overview: Problem when initializing a Visio page with service shapes \[ID_26079\]

In some cases, an exception could be thrown while initializing a Visio page containing service shapes.

#### DataMiner Cube - Visual Overview: No tool tip shown when SetVar shape was configured using legacy syntax \[ID_26087\]

In some cases, no tool tip would be shown when you had used legacy syntax to configure a tool tip on a shape (e.g. SetVar set to "varA:X:Y" and SetVarOptions set to "Control=Shape").

#### DataMiner Cube - Element Connections: Problem when swapping connections \[ID_26098\]

When, in the Element Connections app, you swapped two connections, in some cases, the connection configuration would be incorrect or a connection would incorrectly be duplicated.

#### Incorrect message shown after a successful DataMiner upgrade operation \[ID_26114\]

After a DataMiner upgrade operation, in some cases, a “DataMiner is currently upgrading” error would be shown indefinitely, despite the fact that all agents had been upgraded successfully.

#### Database: Large offload files would not get written to the database \[ID_26130\]

In some cases, when a database was again up and running after being down for an extended period of time, the offload files would not get written to the database because their size was too large.

#### Sidebar docking position user setting not working in non-English Cube \[ID_26165\]

If Cube was set to a different language than English, it could occur that it was not possible to change the position of the Cube sidebar via the user settings.

#### DataMiner Cube would become unresponsive when no domain user pictures could be retrieved \[ID_26182\]

In some cases, DataMiner Cube could become unresponsive when no domain user pictures could be retrieved.

#### View synchronization could cause SLDataMiner to leak memory \[ID_26190\]

On large DataMiner systems, in some cases, a view synchronization could cause SLDataMiner to leak memory.

#### Dashboards: Clicking the icon of a parameter component would incorrectly not open the associated trend card in the Monitoring app \[ID_26213\]

When, in the Dashboards app, you click the icon of a parameter component, the trend card of the parameter in question should open in the Monitoring app. However, in some cases, this did not happen due to an incorrect key being passed from the Dashboards app to the Monitoring app.

#### Problem with user permissions caused certain parameters of an enhanced service not to be displayed \[ID_26222\]

In some cases, the user permissions configured for the hidden element of an enhanced service would differ from those configured for the enhanced service itself. This would cause certain parameters of the enhanced service not to be displayed.

#### Problem with protocol buffer serialization when server and client were running different DataMiner versions \[ID_26227\]

When protocol buffer serialization was being used, a “Failed to set up ProtoBuf” error could be thrown when a DMA and a client were running different DataMiner versions.

#### Problem when a table cell value was masked while being retrieved \[ID_26250\]

In some cases, an error could occur when a table cell value was masked while it was being retrieved.

#### Memory leak when adding or deleting rows in the DCF interface table \[ID_26256\]

When, in an element with DCF interfaces, rows were added or deleted in the DCF interface table, in some cases, a memory leak could occur.

#### Automation: Date and time not adapted to local time zone in calendar component \[ID_26258\]

If an interactive Automation script used a calendar component, it could occur that the date and time in the component were not adapted to the local time zone.

#### DataMiner Cube - Data Display: Time control values would incorrectly change when you edited them \[ID_26278\]

Due to a rounding issue, in some cases, values displayed in a time control would change when you edited them.

#### DataMiner Cube - Services: Exclude setting specified when creating a service would incorrectly change to an include setting when editing that service afterwards \[ID_26281\]

When you created a service with exclude conditions in combination with conditional alarm severity influence settings, in some cases, the exclude setting would incorrectly change to an include setting when editing that service afterwards.

#### Problem when multiple FillArray calls simultaneously tried to update the same table \[ID_26287\]

When multiple FillArray calls simultaneously tried to update the same table, in some cases, an error could occur due to a locking issue.

#### DataMiner Cube - Elements: Actions listed in the warning message that appears when changing the protocol version of an element would not be formatted correctly \[ID_26297\]

When you are about to change the protocol version of an element, a popup message will appear. Apart from warning you about the consequences, that message also lists the (manual) actions that are required afterwards. Up to now, in some cases, that list of actions would not be formatted correctly.

#### An SNMP table configured to retrieve data via a bulk operation would not get filled in when one of the responses contained an error \[ID_26333\]

When an SNMP table was configured to retrieve data via a bulk operation (e.g. multiple get), up to now, the table would only get filled in when all requests had received a correct response. One response containing an error would cause the entire table to not get filled in.

From now on, each time a correct response is received, the data in that response will be returned to SLProtocol for processing.

#### DataMiner Cube: Missing icons in standalone Cube installed by Cube Launcher \[ID_26340\]

When DataMiner Cube was used as a standalone application installed using the Cube Launcher introduced in DataMiner v10.0.9, in some cases, icons would be missing, especially when working with Automation and Trending.

#### Ticketing/Cassandra: Problem when retrieving a ticket that had just been added or updated \[ID_26348\]

On systems where the ticketing data is stored in a Cassandra database, in some cases, it would not be possible to retrieve a ticket immediately after it was created. Also, when a ticket was retrieved immediately after it had been updated, in some cases, the ticket data from before the update would incorrectly be retrieved.

#### DataMiner Cube - Alarm Console: Miscellaneous issues \[ID_26396\]

A number of minor issues have been fixes in the Alarm Console:

- When an alarm in the Active Alarms tab page was clicked, in other words, marked as read, in some cases, the alarm would incorrectly be set to unread again when you opened a tab page of type “sliding window” that contained the alarm in question.

- When you opened a tab page of type “sliding window” and kept it open while a number of active alarms were cleared, in some cases, when you opened a new tab page of type “sliding window” with an identical window size, the number of unread alarms in the first tab page would not be equal to the number of unread alarms in the second tab page.

- When the alarms in a particular tab page were grouped by Time, in some cases, the sorting would be reversed each time you changed the Automatically grouped according to arrangement setting.

- In some cases, similar alarms would have different parameter descriptions. One alarm would e.g. show “Temperature” while another alarm would show “Temperature A”.

#### DataMiner Cube: Module names in side bar not translated when UI language was set to a language other than English \[ID_26402\]

When, in DataMiner Cube, the UI language was set to a language other than English, in some cases, the names of the modules in the side bar would not be translated.

## Addendum CU5

### CU5 enhancements

#### DataMiner Installer will now automatically select a checkbox to create an additional DataMiner user when not being executed by a user with administrative privileges \[ID_25414\]

From now on, if DataMiner Installer is not being executed by a user with administrative privileges, it will automatically select a checkbox to add the current user to the DataMiner Administrators group. This will ensure that at least one user account is available to log in to DataMiner when the installation has finished.

#### Enhanced communication between agents using HTTP and agents using HTTPS \[ID_26122\]

A number of enhancements have been made with regard to inter-agent communication within a DataMiner System, especially between agents using HTTP and agents using HTTPS.

#### BPA files will now be synchronized among all agents in a DataMiner System \[ID_26360\]

Files related to Best Practice Analysis (BPA) tests will now be synchronized among all agents in a DataMiner System.

#### Element fields now accept pipe characters and tab characters \[ID_26425\]

When adding or updating an element, it is now allowed to enter pipe characters (“\|”) and tab characters in the fields of that element.

> [!NOTE]
>
> - By default, DataMiner Cube will automatically replace tab characters by spaces.
> - Tab characters in port settings could cause problems when exporting or importing to or from a CSV file.

#### Mobile Gateway: Text messages can now contain special characters like '&' \[ID_26449\]

When DataMiner is configured to use an IP-based cell phone modem (e.g. SMSEagle), it communicates with the device via HTTP GET requests, passing values as ampersand-delimited parameters in the URL.

Up to now, when DataMiner sent a text message containing an ampersand character (“&”), the message would be cut off because the ampersand was incorrectly interpreted as a delimiter. From now on, all text messages will be URL encoded.

#### DataMiner Cube - Failover: When you chose to disable the Failover configuration, it is now also possible to select 'Cancel' \[ID_26509\]

In the Failover configuration window, up to now, when you chose to disable the Failover configuration, you were only able to select *Yes* or *No*. From now on, it is also possible to select *Cancel*.

#### DataMiner Cube - Service & Resource Management: Users will now clearly be notified when trying to configure or manage service profiles when no Indexing Engine is installed \[ID_26534\]

Since DataMiner 10.0.0, service definitions and service profiles can only be used on systems with an Indexing Engine. From now on, when no Indexing Engine is installed, DataMiner Cube will clearly indicate that it is not possible to configure service profiles in the Profiles app nor to manage them in the Services app.

#### Security checks for local connections between an SLxxx module and SLNet \[ID_26544\]

For local connections between an SLxxx module (e.g. SLDMS) and SLNet, security checks have been established. A security token will be generated and verified for each of the messages that are sent.

#### Automation: DataMiner will now check whether a parameter’s set range has not been changed dynamically \[ID_26574\]

When a parameter is set, from now on, DataMiner will check whether the set range of the parameter in question has not been changed dynamically (e.g. by an Automation script).

#### DataMiner Cube - Automation: All parameters will now be aligned vertically \[ID_26665\]

When creating or updating an Automation script in the Automation app, the parameters will now all be aligned vertically.

#### Enhanced performance when notifying SLElement of service updates \[ID_26674\]

Due to a number of enhancements, overall performance has increased when notifying SLElement of service updates.

#### DataMiner Cube - System Center: 'Include SLNet' checkbox removed from restart confirmation window \[ID_26685\]

When, in the *Agents* section of *System Center*, you clicked *(Re)start* to restart a DataMiner Agent, up to now, it was possible to select the *Include SLNet* checkbox in the confirmation window.

This checkbox has now been removed.

#### DataMiner Cube - Visual Overview: New option to show table name in parameter control shape \[ID_26694\]

Up to now, a parameter control displaying a parameter value retrieved from a table would by default also show the name of that table. From now on, this will no longer be the case.

If you want a parameter control to also show the name of the table, then specify the “ShowTableName=true” option in the *ParameterControlOptions* data field of the parameter control shape.

| Shape data field        | Value              |
|-------------------------|--------------------|
| ParameterControlOptions | ShowTableName=true |

#### DataMiner Cube: Property values in Custom tab of Properties window will now be prevented from updating automatically when a user is manually editing property values \[ID_26825\]

The values of the custom properties listed in the *Custom* tab of a *Properties* window are constantly being updated in real time. As this would sometimes cause problems when a user was manually updating one of those properties, from now on, real-time updates of custom properties listed in the *Custom* tab of the *Properties* window will be suspended as long as a user is manually editing property values in that same tab.

#### DataMiner Cube - Alarm Console: Enhanced performance when closing alarm tabs \[ID_26826\]

Due to a number of enhancements, overall performance has increased when closing an alarm tab, especially when all alarms in that tab are selected.

#### DataMiner Cube -Trending: Enhanced retrieval of histogram intervals \[ID_26833\]

A number of enhancements have been made to the way in which histogram intervals are retrieved.

#### DataMiner Cube - System Center: Enhanced saving of backup settings \[ID_26858\]

A number of enhancements have been made to the way in which the backup settings are saved in the *Backup* section of *System Center*.

#### Alarm template information events no longer generated upon element/DMA restart \[ID_26862\]

Previously, when an alarm template was configured to generate information events for specific values, these information events would also be generated each time the element or the DMA restarted. Now such information events will only be generated at runtime.

#### SLLogCollector now targets Microsoft .NET Framework 4.6.2 \[ID_26888\]

SLLogCollector now targets Microsoft .NET Framework 4.6.2.

### CU5 fixes

#### Credential library: Problem with passwords having been encrypted multiple times \[ID_24201\]

In the credential library, in some cases, passwords would incorrectly be encrypted multiple times.

Also, in some cases, an exception could be thrown when you tried to edit an existing library credential.

#### Problem with spectrum session presets reverting to the default settings \[ID_26043\]

After restarting a DMA, in some cases, spectrum session presets could revert to the default settings if a card was open in a Cube connected through another DMA.

#### After a hotfix installation, the version number in VersionHistory.txt would be updated incorrectly \[ID_26067\]

After a hotfix installation, in some cases, the version number in the VersionHistory.txt file would incorrectly be updated with the word “Hotfix” instead of the hotfix version string containing the detailed version information (e.g. “HF_10.0.7.0(CU0)\_20200520-135714”).

#### MySQL: Problem with delete queries trying to delete trend records for elements that were not being trended \[ID_26085\]

On systems with a MySQL database, in some cases, a delete query would incorrectly try to delete trend records for an element that was not being trended.

#### DataMiner Cube - Alarm Console: 'Earlier this month' and 'Last month' were sorted incorrectly \[ID_26209\]

When, in the Alarm Console, you sorted and grouped alarms by Time/descending, the “earlier this month” group would incorrectly be sorted after the “last month” group (and vice versa when sorted and grouped by Time/ascending).

#### Problem when restoring a DataMiner backup package containing a database file that took a long time to restore \[ID_26210\]

When you restored a DataMiner backup package (.dmbackup) containing a database file that took more than 30 minutes to restore, in some cases, the restore of the DataMiner backup package would incorrectly continue before the restore of the database file had finished.

#### Problem when using the IsMatrixCrosspointConnected method in an Automation script \[ID_26276\]

When, in an Automation script, the *IsMatrixCrosspointConnected* method was used before a matrix point had been connected, in some cases, an exception could be thrown.

#### DataMiner Cube - Visual Overview: Shapes with a ParameterControl shape data field would incorrectly not take into account the NoAutoScale option \[ID_26283\]

When a Visio page with the NoAutoScale option contained shapes of which the ParameterControl shape data field was set to a value containing dynamic placeholders, in some cases, those shapes would incorrectly not take into account the NoAutoScale option.

#### Problem with SLPort when polling smart-IP elements \[ID_26304\]

In some cases, a memory issue could occur in SLPort when polling smart-IP elements.

#### Some files would not immediately get synchronized when creating a new DataMiner System \[ID_26359\]

When you created a new DataMiner System, in some cases, certain existing files would not get synchronized immediately. They would incorrectly only get synchronized after restarting one of the DataMiner Agents and awaiting the first midnight synchronization.

#### Problem with SLAutomation when saving a script containing a long line \[ID_26367\]

When you saved an Automation script that contained a long line, in some cases, an error could occur in all SLAutomation processes in the DataMiner System.

#### Source OID of forwarded aggregation alarm would not contain 'Aggregation' \[ID_26369\]

When an aggregation alarm was forwarded, in some cases, OID 1.3.6.1.4.1.8813.1.1.2.2.11 (Source) would incorrectly not contain “Aggregation”.

#### Run-time errors on elements that were partially included in a service \[ID_26376\]

In some cases, processing service additions, service updates and dynamic service inclusions would cause run-time errors on elements that were partially included in a service.

Also, service impact indications could in some cases be displayed incorrectly.

#### Unnecessary DataMiner restart after DataMiner startup with process in 'Suspended' state \[ID_26407\]

When DataMiner started up while a DataMiner process was still in "Suspended" state, this could cause an unnecessary DMA restart later.

#### Alarms associated with an element would be displayed incorrectly after an element restart \[ID_26410\]

When an element was restarted while alarms associated with that element were being processed, in some cases, alarms would incorrectly be duplicated or would be displayed incorrectly after the restart.

#### Problem when using SNMPv3 credentials from the credential library in conjunction with a non-primary SNMP port \[ID_26435\]

In some cases, an element startup error could be thrown when using SNMPv3 credentials from the credential library in conjunction with a non-primary SNMP port.

#### DataMiner Agent not restarting after processes were stopped \[ID_26440\]

To prevent an Agent from automatically restarting when it is stopped, up to now, DataMiner did not automatically restart when more than 2 processes stopped within a 2-minute timespan. However, this could cause problems if more than 2 processes stopped but the Agent did not stop completely. To prevent this, the Agent will now be restarted when at least one of the following processes is still running: SLDataMiner, SLElement, SLDMS and SLNet.

#### Real-time trend data requested by sending a GetTrendDataMessage would incorrectly contain additional data points beyond the specified end time \[ID_26473\]

When real-time trend data was requested by sending a GetTrendDataMessage, in some cases, the response would incorrectly contain additional data points beyond the specified end time.

#### Problem due to duplicate IP addresses in DMS.xml \[ID_26480\]

In some cases, an error could occur because the DMS.xml file on a particular DataMiner Agent had the same IP address listed multiple times. From now on, when a DMS.xml file contains duplicate IP addresses, all but the first occurrence will be ignored.

#### Files in C:\\Skyline DataMiner\\ root folder would not be taken into account when processing FilesToLeave.txt during a DataMiner upgrade \[ID_26489\]

When the FilesToLeave.txt file was processed during a DataMiner upgrade, up to now, the files in the C:\\Skyline DataMiner\\ root folder would incorrectly not be taken into account.

#### Failover: Agent configured to only be switched over manually would incorrectly be switched back to offline automatically in case of failing heartbeats \[ID_26490\]

In some cases, an agent configured to only be switched over manually would incorrectly be switched back to offline automatically in case of failing heartbeats.

#### DataMiner Cube - Alarm Console: Problem when a sliding window alarm tab was present when clearing alarms correlated by the alarm storm prevention mechanism \[ID_26494\]

When too many alarms are generated for the same parameter, an alarm storm prevention mechanism is triggered, which groups all those alarms into one correlated alarm. When those alarms got cleared, in some cases, an error could occur when an alarm tab of type “sliding window” was present in the Alarm Console.

#### Automation: Engine#FindElement(null) call would incorrectly return a random element \[ID_26499\]

When using an Engine#FindElement(null) call in an Automation script, in some cases, a random Element object would incorrectly be returned. From now on, NULL will be returned instead.

#### DataMiner Cube - Documents app: Problem when trying to delete a file after saving it locally \[ID_26500\]

When, in the Documents app, you tried to delete a document after saving it to your client computer, in some cases, the document would not disappear from the list and would remain in a “Deleting” state.

#### Memory leak in SLNet \[ID_26507\]

In some cases, the SLNet process would leak memory due to a thread problem.

#### DataMiner Cube - Alarm Console: Problem when grouping alarms by time on the first day of the month \[ID_26511\]

When, on the first day of the month, you opened an alarm tab page with active alarms grouped by time, in some cases, the alarms generated on the last day of the previous month would incorrectly be marked with the day of the week instead of with the word “Yesterday”.

#### SLProtocol would incorrectly not take the pair with the lowest ID when no ping pair was defined in a serial protocol \[ID_26514\]

When, in a serial protocol, no specific pair is defined as the ping pair (in other words: no pair has its group ID set to -1 or has a ping="true" attribute), by default, SLProtocol should take the pair with the lowest ID. However, up to now, it would instead incorrectly take the first pair defined in the protocol.

#### Monitoring app - Visual Overview: Using a SetVar shape would cause two instances of the same control to be displayed on top of each other \[ID_26516\]

When, in the Monitoring app, a SetVar shape were used in a Visio file, two instances of the same control would incorrectly be displayed on top of each other.

#### SLNet handle leaks \[ID_26517\]

In some cases, the SLNet process would experience handle leaks.

#### DataMiner Cube: Problem when trying to refresh a table by clicking the Refresh button \[ID_26521\]

In some cases, it would no longer be possible to manually refresh a table by clicking the *Refresh* button at the top of the table.

#### DataMiner Cube - Services app: Services list would not display the current states of the listed services \[ID_26537\]

When you opened the Services app, in some rare cases, the services list would not display the current states of the listed services.

#### Automation scripts could fail with a 'No CodeBuilder found for cookie xxx' error \[ID_26546\]

In some cases, Automation scripts could fail with a “No CodeBuilder found for cookie xxx” error.

#### Parts of a table polled via SNMP could be set to 'not initialized' when errors had occurred during polling \[ID_26551\]

When a table with columns that had a specific polling rate configured was polled via SNMP, in some cases, parts of that table could get set to “not initialized” when errors had occurred during polling.

#### Ticketing: TicketFieldResolver instances would no longer be synchronized \[ID_26552\]

In some cases, the TicketFieldResolver instances on the different agents in a DataMiner System would incorrectly no longer be synchronized.

#### HTML5 apps: Problem when logging in \[ID_26559\]

When you tried to log in to an HTML5 app (e.g. Monitoring, Dashboards, etc.), in some cases, the login page could become unresponsive when the login attempt failed.

#### DataMiner Cube: Visual page of a newly opened card would not get loaded when the new card replaced the contents of an existing card \[ID_26561\]

By default, if you left-click an item in the Surveyor using a card layout other than the tab layout, each new card you open will replace the previous open, docked card. Up to now, when the contents of an open card were replaced, in some cases, the visual page of the new card would not get loaded. It would only be loaded when you selected it after opening another page.

#### DataMiner Cube - Visual Overview: Problem with ColumnWidth option \[ID_26570\]

When, in a shape data field of type ParameterControlOptions, a ColumnWidth option had been specified, in some cases, Visual Overview would incorrectly show an empty table.

#### No exception would be thrown when part of an SLDataGateway filter could not be parsed \[ID_26572\]

In some cases, no exception would be thrown when part of an SLDataGateway filter could not be parsed.

#### DataMiner Cube: Alarms would incorrectly be updated with a 'View Impact Changed' event when the Name field in System Info was emptied \[ID_26575\]

When, in DataMiner Cube, you went to *System Center \> Agents \> System \> System info*, and emptied the *Name* field, the alarms would incorrectly be updated with a “View Impact Changed” event.

#### Dashboards app: Line chart components could show incorrect trend data due to a caching problem \[ID_26576\]

Due to a caching problem, in some cases, line chart component would display incorrect trend data.

#### DataMiner Cube - Data Display: Statistical values in table column headers would be displayed incorrectly \[ID_26587\]

In Data Display, in some cases, statistical values in table column headers would be displayed incorrectly.

#### DataMiner Cube - SNMP forwarding: Problems with Notifications tab \[ID_26590\]

When, in the *SNMP forwarding* section of *System Center*, you configured an SNMP manager, in some cases, the following problems could occur:

- When, in the *General* tab, you selected “SNMPv1” and saved the configuration as is, in some cases, the notification OID would not be saved correctly. By default, it should be set to “User device-specific OID”.

- In case of SNMPv2 or SNMPv3, when the *Notification OID* field was not set to “Use custom bindings” and the *Custom bindings* pane was expanded, the *Delete* button would incorrectly always be enabled. That button should only be enabled when the *Notification OID* field is set to “Use custom bindings” and a custom binding is selected in the list.

#### DataMiner Cube - Multiple set: List of table indices would not be populated when there was no associated read parameter \[ID_26593\]

When you performed a multiple set (i.e. an update of multiple parameter values in one go), up to now, the drop-down box listing the table indices would incorrectly not be populated when there was no associated read parameter (e.g. write parameters linked to buttons displayed in table cells).

#### DataMiner Cube - EPM: KPI list would incorrectly display long column names that included the table name \[ID_26599\]

In a CPE Manager element card, the KPI list would incorrectly display long column names that included the table name. From now on, that list will display short column names.

#### DataMiner Cube - Data Display: Incorrect parameter range validation after the range had been modified via a protocol QAction \[ID_26600\]

When a parameter range had been modified via a protocol QAction, in some cases, the new range would not correctly be validated when the parameter was updated via Data Display.

#### EPM: Problem when unmasking a tree element \[ID_26612\]

In some cases, an exception could be thrown when a tree element was unmasked.

#### DataMiner Cube - Data Display: 'CPEOnly' option would not be applied correctly \[ID_26624\]

In some cases, the “CPEOnly” protocol option would not be applied correctly when opening a card.

#### DataMiner Cube - Visual Overview: Breadcrumbs header showing after Visio page is maximized \[ID_26631\]

When you maximized a Visio page and then navigated to e.g. another view inside that page, in some cases, the breadcrumbs header would incorrectly be displayed at the top of the screen.

#### DataMiner Cube: Loading issue when returning to a parent node when navigating through a tree control \[ID_26634\]

When navigating through a tree control showing table data, in some cases, a loading issue could occur when returning to a parent node.

#### DataMiner Cube - Data Display: Exporting a table to CSV could generate wrong column order \[ID_26651\]

When you exported a Data Display table to a CSV file after moving or (un)hiding some of its columns, in some cases, the column order in the CSV file would be incorrect.

> [!NOTE]
> When hidden columns are exported, they are positioned where they would appear when not hidden, i.e. on the right of the closest non-hidden column as defined in the protocol.

#### DataMiner Cube - Visual Overview: Problem when using a placeholder inside another placeholder of the same type in Element shape data fields \[ID_26653\]

When, in an Element shape data field, you used a placeholder inside another placeholder of the same type (e.g. a \[Param:\] placeholder inside another \[Param:\] placeholder), in some cases, those placeholders would not get resolved correctly, causing the shape to not get displayed.

#### DataMiner Taskbar Utility: Problem at the end of a DataMiner upgrade operation \[ID_26660\]

In some rare cases, the DataMiner Taskbar Utility could throw an “out of memory” exception at the end of a DataMiner upgrade operation.

#### Problem with alarm statuses of parent services \[ID_26671\]

When a child service was added to multiple parent services hosted on a different DataMiner Agent, and all those parent services were edited, in some cases, only the alarm status of the parent service that had been edited last would be updated when the child service received an alarm status update.

#### Monitoring app: Clicking an editable table cell caused its value to be replaced by 0 \[ID_26678\]

When in the Monitoring app, you clicked an editable table cell to edit the value, in some cases, the current cell value would incorrectly be replaced b y 0.

#### Elements with an SNMPv3 port and at least one other port not correctly exported to CSV file \[ID_26680\]

In some cases, elements with an SNMPv3 port and at least one other port would not correctly be exported to a CSV file and, in the CSV file, the Credential Library GUID of the additional ports would incorrectly be set to that of the main port.

Also, when elements were exported to the Windows clipboard, in some cases, table columns would be misaligned.

#### Problem when taking a DataMiner backup that included the Cassandra database \[ID_26689\]

When taking a DataMiner backup, in some cases, an error could occur when that backup included the Cassandra database.

#### DataMiner Cube: Incorrect trend data value in Agents statistics in System Center on system with Cassandra database \[ID_26695\]

In DataMiner Cube, in some cases, System Center would show an incorrect trend data value in the Agents statistics when a Cassandra database was being used.

#### Service & Resource Management: ReservationDefinition with an occurrence outside of its time range could not be saved \[ID_26696\]

When a ReservationDefinition was created with an occurrence outside of its time range, in some cases, it would not be possible to save it.

#### Settings of advanced ports incorrectly deleted when element was edited \[ID_26703\]

When an element was edited without changing the existing port settings, in some cases, the settings of the advanced ports would incorrectly be deleted.

#### Element connections: Destination parameter not updated when parameter was linked to cell or column of table using advanced naming \[ID_26712\]

When a parameter was linked to a cell or a column of a table that used advanced naming, in some cases, the destination parameter would not be updated when the source parameter was updated.

#### Problems with the DataMiner Comparison tool \[ID_26713\]

When, in the DataMiner Comparison tool, you requested parameter values, in some cases, the Collapse common lines option would no longer work.

Also, it would no longer be possible to select the text of the option labels and, when the tool was not embedded in Visual Overview, an error could occur when scrolling.

#### DataMiner Cube - Scheduler: No longer possible to modify the actions defined in a task after going to the General or Schedule tabs \[ID_26714\]

When, in the *Scheduler* app, you created a new task and defined a number of actions in the *Actions* tab, in some cases, it would no longer be possible to modify those actions when you returned to the *Actions* tab after going to the *General* or *Schedule* tab.

#### DataMiner Cube - Data Display: Scrolling to the far right of a table would cause the column headers to no longer be aligned with the table content \[ID_26736\]

When you scrolled to the far right of a table, in some cases, the column headers would no longer be aligned with the table content.

#### Service & Resource Management: Problem when the generation of a ReservationDefinition occurrence failed \[ID_26745\]

When the generation of a ReservationDefinition occurrence failed, in some cases, an error could occur in SLNet.

#### DataMiner Cube - Visual Overview: Empty 'Parameter' shape data field could cause DataMiner Cube to become unresponsive \[ID_26750\]

When, on a Visio page, you had defined an element shape with an empty Parameter data field, in some rare cases, this could cause DataMiner Cube to become unresponsive. From now on, empty Parameter data fields will be disregarded.

#### DataMiner Cube - Visual Overview: Child shapes would incorrectly not disappear when the ChildrenFilter no longer applied \[ID_26760\]

When a ChildrenFilter was used in a child shape with ChildType set to “Service”, in some cases, generated child shapes would incorrectly not disappear when the filter no longer applied.

#### Masked rows would no longer be masked after an element restart \[ID_26771\]

When you masked a table row and then restarted the element, in some cases, the row would incorrectly no longer be masked.

#### Monitoring app: Notes on DVE elements \[ID_26787\]

In the Monitoring app, when users had been granted the “View notes” permission, in some cases, a Notes page would incorrectly be shown when they opened the card of a DVE element although it is not possible to create notes linked to DVE elements.

#### DataMiner tasks in Windows Task Scheduler would incorrectly remain in a 'Running' status when DataMiner was not running \[ID_26791\]

When DataMiner was not running, in some cases, the following scheduled tasks would incorrectly remain in a “Running” state:

- Skyline DataMiner Backup (DataMinerBackup.js)
- Skyline DataMiner Database Optimization (OptimizeDB.js)
- Skyline DataMiner LDAP Resync (ReloadLDAP.js)

As a result, the next scheduled execution of those tasks would not take place and a number of files would remain locked.

#### Problem with logging of SLManagedScripting \[ID_26796\]

In some cases, the log file of the SLManagedScripting process would incorrectly keep on growing. From now on, all logging of the SLManagedScripting process will be handled by SLLog.

#### External DCF connections could get deleted at DMA startup \[ID_26807\]

In a DataMiner System, in some rare cases, external DCF connections could get deleted at DMA startup.

#### DataMiner Cube - Trending: Curves submenu would be empty or incomplete when you right-clicked a trend graph \[ID_26809\]

When you right-clicked a trend graph, in some cases, the Curves submenu would be either empty or incomplete.

#### Dashboards app: Problem when a line chart component was configured to display columns from different tables of the same element without grouping \[ID_26810\]

When a line chart component was configured to display columns from different tables of the same element without grouping, in some cases, a “Cannot read property 'indexof' of undefined” error could be thrown.

#### CSV export of table parameter trend graph empty for custom data set other than 'Real-time' \[ID_26818\]

When a trend graph of a table cell for which the display key was different from the primary key was exported to CSV, and a custom data set other than "Real-time" was selected, it could occur that the export was empty.

#### DataMiner Cube - Trending: Exception value displayed incorrectly in trend graph legend \[ID_26824\]

If a trend graph showed an exception value, it could occur that the corresponding trace value in the legend below the graph was displayed incorrectly.

#### Axis name displayed incorrectly after 'Split to new Y-axis' option was used \[ID_26831\]

If a trend graph displayed multiple parameters and the *Split to new Y-axis* option was used for the first parameter that had been added to the graph, it could occur that in the *Y-axis settings* box both axes were displayed with the name of the first parameter.

#### Reporter app: Zip package would incorrectly contain duplicate CSV files when a trend report was generated \[ID_26854\]

When, in the legacy Reporter app, you generated a report template containing a trend block in CSV format, in some cases, the zip package would incorrectly contain duplicate files.

#### DataMiner Cube: Special characters in log files would not be displayed correctly \[ID_26874\]

When viewing log files in DataMiner Cube, in some cases, special characters in those log files would not be displayed correctly. From now on, the browser control displaying the log files will always render the page using UTF-8 character encoding.

#### Monitoring app: Video thumbnails not displayed \[ID_26879\]

In some cases, it could occur that video thumbnails were not displayed in Visual Overview in the Monitoring app.

#### DataMiner Cube - Visual Overview: Not possible to connect matrix input and output \[ID_26886\]

In some cases, it could occur that it was not possible to connect an input and output of a matrix control in a visual overview.

#### No data shown for table parameter in service if multiple filters were used and one contained a closing parenthesis \[ID_26893\]

If a table parameter was included in a service using multiple filters, one of which contained a closing parenthesis, it could occur that no data were shown for this parameter.

#### Incorrect sorting of parameters in multiple parameter set confirmation window \[ID_26908\]

If a parameter value was changed in a table cell and multiple other parameter values were changed as well, it could occur that the table parameter name was not displayed in the correct location in the pop-up window where you could confirm the multiple parameter set.

#### DataMiner Cube - Alarm Console: Delay not applied correctly \[ID_26915\]

In some cases, if a delay was applied to a tab in the Alarm Console, it could occur that this delay was not applied correctly when multiple alarms came in at different moments.

#### Legacy dashboards not synced in new Failover setup \[ID_26916\]

When a new Failover pair was configured, it could occur that the existing dashboards from the legacy Dashboards app were not synced from the online DMA to the offline DMA.

#### DataMiner Cube: Automation script executed from Visual Overview still displayed as 'Executing' when finished \[ID_26925\]

When an Automation script was executed from a shape in Visual Overview, it could occur that it continued to be displayed as being executed even when the script was finished.

#### Precompiled QActions loaded in memory multiple times \[ID_26952\]

In some cases, it could occur that precompiled QActions were loaded in memory multiple times.

#### CPE masking soft-launch feature visible even though soft-launch option was not activated \[ID_26960\]

In some cases, it could occur that the option to mask an EPM object in a diagram was available, even though the *CPEIntegration* soft-launch option was not activated. Attempting to mask the object would result in an error, since this feature is only available in soft launch.

#### DataMiner Cube - Visual Overview: Input 1 missing from right-click menu of matrix control \[ID_26963\]

When a matrix control was displayed in Visual Overview, it could occur that Input 1 was not listed among the available inputs in the right-click menu where you can connect an output with an input.

#### Fixed parameter length from protocol not respected \[ID_26968\]

In some cases, it could occur that the fixed parameter length defined in a protocol was not respected when data was sent.

#### Alarm update with incorrect timestamp after custom element property change \[ID_26971\]

In some cases, when the custom properties for an element were changed, it could occur that the timestamp for corresponding alarm updates was incorrect.

#### Automation: Parameter set failed for string parameter with custom name \[ID_26973\]

If a parameter of type string was configured to be displayed with a custom parameter name, it could occur that parameter sets via the Automation API failed for this parameter.

#### Matrix follow mode issues \[ID_26976\]

The following issues with matrix follow mode have been resolved:

- If a matrix element had been migrated to a different DMA than the one where it was originally created, it could occur that follow mode did not work for this element.

- If follow mode was enabled on an output that was already connected to an input, and this output was set as a slave of another output, it could occur that the output was connected to the wrong input.

#### DataMiner Cube: Visual Overview page not displayed when Visio drawing was not cached on client \[ID_27000\]

In some cases, if a Visio drawing was not cached on the client, it could occur that the displayed Visual Overview page remained empty even after it had been downloaded from the server.

#### DMA startup problem if COM pointer was created for SLGSMGateway while SLNet was initializing \[ID_27023\]

In some rare cases, a DMA startup problem could occur if a COM pointer was created for the SLGSMGateway process while the SLNet process was initializing.

#### Encrypted credential library passwords would incorrectly be re-encrypted \[ID_27034\]\[ID_27089\]

In some cases, encrypted credential library passwords would incorrectly be re-encrypted. This would cause the credential library to grow, which, in turn, would cause a memory issue in SLNet.

> [!NOTE]
> The DataMiner SLNetClientTest tool allows you to repair credential library files that contain incorrectly encrypted passwords.

#### DataMiner Cube: Service child displayed twice in Surveyor after service refresh \[ID_27042\]

In some cases, when a service was refreshed, for example by a manager protocol, it could occur that a service child was displayed twice in the Surveyor until a new Cube session was started.

#### The log size would incorrectly be converted from MB to bytes when the log settings were changed \[ID_27075\]

When the log settings were changed, in some cases, the log size would incorrectly be converted from MB to bytes.

## Addendum CU6

### CU6 enhancements

#### Data forwarded using an AlarmSocket or a PollSocket will now be encoded using UTF-8 \[ID_27059\]

From now on, when DataMiner forwards data using an AlarmSocket or a PollSocket, that data will be encoded using UTF-8 instead of the ANSI code page of the DataMiner Agent.

> [!NOTE]
> From now on, all data sent to a PollSocket must also be encoded using UTF-8.

#### DataMiner Installer: Improved error handling when unable to connect to Cassandra \[ID_27096\]

During a DataMiner installation, in some cases, an error could be thrown when it took more than 2 minutes to connect to the Cassandra database.

Now, the connection timeout has been increased from 2 to 5 minutes. Also, fewer error messages will be logged while trying to connect to the Cassandra database.

#### DataMiner Cube - Data Display: Enhanced services can now include other enhanced services \[ID_27109\]

From now on, it is possible for enhanced services to include other enhanced services.

#### StandAloneBpaExecutor tool now shows the full DLL path and the BPA version \[ID_27134\]

When, in the StandAloneBpaExecutor tool, you select a DLL file, it shows the BPA information for that specific file. From now on, it will show the full path of the selected DLL file as well as the BPA version.

#### Improved performance when subscription is added on element level + possibility to set number of records in protocol cache \[ID_27183\]

Performance has improved when a subscription is added on element level, specifically if the subscription contains elements with different protocols. This will for instance ensure that when multiple cards are opened to Visual Overview pages, parameters will be displayed more quickly.

In addition, it is now possible to change the number of records that can be contained in the protocol cache. You can do so using the SLNetClientTest tool by going to *Options* > *SLNet Options*, selecting *protocolCacheMru* in the drop-down box, changing the value where necessary and clicking *OK*. However, do not change this value without checking with Skyline for advice first, as an incorrect setting can cause serious issues.

> [!WARNING]
> The DataMiner SLNetClientTest tool is an advanced system administration tool that should be used with extreme care (*C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe*).

#### Improved logging for view tables in SLElement log \[ID_27192\]

Logging for view tables in the SLElement log file has been improved. Certain timing information will now only be included once a warning threshold has been exceeded, so that there is less unnecessary log information for view tables.

#### DataMiner Cube - System Center: Only changed fields will be sent to the DMA when changing information in Agents \>System \[ID_27224\]

When, in *System Center*, you click *Save* after changing some of the fields on the *System* tab of the *Agents* section, from now on, only the fields that were changed will be sent to the DataMiner Agent.

#### Client applications will now always connect to a DataMiner Agent via .NET Remoting \[ID_27237\]

Up to now, client applications could use either .NET Remoting or Web Services to connect to a DataMiner Agent. However, as Web Services Enhancements (WSE) for Microsoft .NET is now deprecated, from now on the only way to connect to a DataMiner Agent is by using .NET Remoting.

#### BPA tests: New BpaExecuteContext methods to send messages to SLNet \[ID_27261\]

The BpaExecuteContext object, which BPA tests receive as input, has been extended with methods to send messages to SLNet, allowing the tests to fetch data without manually having to set up a connection:

- DMSMessage\[\] SendSLNetMessage(DMSMessage message)
- DMSMessage\[\] SendSLNetMessages(DMSMessage\[\] message)
- DMSMessage SendSLNetSingleResponseMessage(DMSMessage message)

#### Cube launcher tool: Downgrade support \[ID_27380\]

When you downgraded a DataMiner Agent that came with the Cube launcher tool (i.e. DMS version10.0.9 or newer) to an earlier version without Cube launcher tool (i.e. DMS version 10.0.8 or older), up to now, the Cube launcher tool would incorrectly try to connect to the downgraded agent using the newer Cube version. From now on, after an agent is downgraded, the Cube launcher tool will by default connect to the agent using the matching Cube version.

### CU6 fixes

#### SLDMS notification thread blocked by LDAP refresh \[ID_26547\]

In some cases, if refreshing LDAP took a long time, it could occur that this blocked the SLDMS notification thread.

#### “Authentication took too long” error added to SLNet logging when trying to log on to DataMiner using an incorrect user name and password \[ID_26586\]

When you tried to log on to DataMiner using an incorrect user name or password, in some cases, an “Authentication took too long” error would be added to the SLNet logging after about 30 seconds.

#### Incorrect run-time errors of type 'SLDMS ConnectionThread Problem' would appear when an agent responded slower than expected \[ID_26596\]

When a particular agent in a DataMiner System responded slower than expected, in some cases, incorrect run-time errors of type “SLDMS ConnectionThread Problem” could start to appear on other agents in the same DataMiner System.

#### Failover: Problem when the agents had a different cluster name \[ID_26683\]

Up to now, when the two DataMiner Agents in a Failover setup had a different cluster name, in some cases, the backup agent could end up remaining completely empty. Although, at first, everything would appear correct in the UI, the problem would become apparent after a switch-over.

In such a scenario, from now on, the active agent will show the following “DataMiner Failover Status” notice:

```txt
Failover agent xxx.xxx.xxx.xxx is experiencing sync issues. Check the Failover status.
```

Also, the Failover status window will show a red color and will indicate that the configuration is invalid with reason “Cluster name of agents doesn't match”.

#### DataMiner Cube - Alarm Console: Correlation base alarms not shown in filtered alarm tab when Correlation tracking was disabled \[ID_26817\]

When a filtered alarm tab page contained a correlated alarm, in some cases, the base alarms would not be shown when Correlation tracking was disabled.

#### DataMiner Cube - Settings: Alarm tab page of type 'sliding window' added for a particular group would not be shown to the users in that group \[ID_26902\]

When, in the settings for a particular group, you created a new alarm tab page of type “sliding window” and then changed the size of the sliding window, in some cases, the tab page would not be shown to the users in that group, even when the Enforce Alarm Console pages option was enabled.

#### DataMiner Cube - Alarm templates: Problem when duplicating table column rows in an alarm template \[ID_26985\]

When you duplicated a table column row in an alarm template, in some cases, unsaved changes made to the Info column would not be duplicated correctly.

Also, when you exported a duplicated table column row to a CSV file before saving the changes, in some cases, the Parameter name column in the CSV file would not contain the table name.

#### Problem when installing Indexing Engine on a system with a remote Cassandra database \[ID_27005\]

When you tried to install Indexing Engine on a system with a remote Cassandra database, in some cases, an error could be thrown when the recommendations were being retrieved.

#### Problem when trying to connect to an IPC port after installing Indexing Engine on a remote node \[ID_27014\]

After installing Indexing Engine on a remote node, in some cases, DataMiner would not be able to start up as it would fail to connect to an IPC port.

#### DataMiner Cube - Spectrum Analysis: Trace coloring problem when rapidly switching between spectrum element cards \[ID_27020\]

When you rapidly switched between two spectrum element cards, in some cases, the color of the background, the grid lines, the grid text and the trace of a spectrum trace would incorrectly turn gray or black instead of the color saved in the spectrum preset display settings.

#### DataMiner Cube: Null reference exception when closing alarm tab \[ID_27044\]

In some cases, a null reference exception could be thrown when you closed an alarm tab in the Alarm Console.

#### DataMiner Cube - Alarm Console: Service names visible even to user without access to those services \[ID_27050\]

When a user viewed an alarm that affected a number of services, up to now, the Services column would incorrectly list all impacted services, including those to which the user in question did not have access. From now on, the Services column will only list the services to which the user has access. However, the Service impact column will continue to show the total amount of affected services.

> [!NOTE]
> When you open an alarm in an alarm card, the list of impacted services will now also only contain the services to which you have access.

#### DataMiner Cube - Visual Overview: Alarm color would not be updated in situations where the alarm state changed but the parameter value did not \[ID_27057\]

When text like “\[param:...\]\|Alarm” was specified in a shape data item of type Parameter, in some cases, the alarm color would not be updated correctly while the Visio page was open, especially in situations where the alarm state changed but the parameter value did not.

#### Unexpected behavior if condition for inclusion in service or redundancy switching contained no primary key or display key \[ID_27067\]

Previously, if a condition was defined for the inclusion of an element in a service or for redundancy switching and this condition did not contain a primary key or display key, this could cause unexpected behavior. Now if no primary key or display key is included in a condition, this will be interpreted as a wildcard, and any available row will be considered.

#### DataMiner Cube - Visual Overview: Children of element shapes with an Info placeholder in their shape text would not be displayed \[ID_27095\]

In some cases, child shapes of Element shapes with an Info placeholder (e.g. \[NAME\]) in their shape text would incorrectly not be displayed.

#### DataMiner Cube - Alarm Console: Audible alert would incorrectly be played again after you restarted an element \[ID_27098\]

If, in the Alarm Console, you had configured that an audible alert has to be played as long as not all the alarms in a certain alarm tab page have been read, in some cases, even when all alarms in the alarm tab page in question had been read, the alert would incorrectly be played again when an element was restarted.

#### DataMiner Cube: Not possible to zoom or pan with keyboard in Visual Overview \[ID_27101\]

In some cases, it could occur that it was not possible to zoom and pan using the keyboard in Visual Overview.

#### Problem when reloading Cube browser app \[ID_27103\]

If the Cube browser application was reloaded, it could occur that it did not fully load but instead kept displaying "Connected”.

#### DataMiner Cube - Data Display: Table query would incorrectly not be updated when an initially hidden column of a filtered partial table was unhidden \[ID_27104\]

When an initially hidden column of a filtered partial table was unhidden, in some cases, the table query fetching the data from the server would incorrectly not be updated to include the unhidden column.

#### DataMiner Cube - Spectrum Analysis: Not possible to view average, minimum or maximum trace unless current trace is displayed \[ID_27127\]

When viewing a spectrum analyzer graph, it could occur that it was not possible to display the average, minimum or maximum trace if the current trace was not displayed.

#### Service & Resource Management: Missing LinkerTableEntries in resources after DMA restart \[ID_27139\]

After a DMA was restarted, it could occur that LinkerTableEntries were missing in SRM resources.

#### DataMiner Cube: No longer possible to click below or above a scrollbar thumb \[ID_27149\]

In some cases, it would no longer be possible to click inside a scrollbar track (i.e. below or above the scrollbar thumb).

#### DataMiner Cube - Visual Overview: Memory leak in SLHelper \[ID_27162\]

The SLHelper process keeps a set of actions in memory to be able to track what action should be taken when a Visio shape is clicked. In some cases, that set of actions would never get cleared and new actions would be added each time a Visio file was updated.

#### DataMiner Cube: No context menu would appear when right-clicking a suggestion in the header search box after right-clicking the “Advanced search” button \[ID_27166\]

When, in the Cube header bar, you first right-clicked the *Advanced search for...* option at the bottom of the suggestions list, and then right-clicked any of the listed suggestions, no context menu would appear.

#### DataMiner Cube - Visual Overview: Masked alarm color not shown for cells displayed in Children shape \[ID_27172\]

If cells of a table row were displayed in a Children shape in Visual Overview, it could occur that masked cells did not display the masked alarm color.

#### DataMiner Cube: Custom icon visualization not working for list view components \[ID_27173\]

In list view components, for example in the Bookings app, in the Services app or in ListView shapes in Visual Overview, it was no longer possible to visualize the content of a column as a custom icon. This is now again possible for booking, service and element columns as well as for booking, service and element property columns. Note that this functionality relies on Automation scripts to provide the icon library and column value/icon mapping.

#### DataMiner Cube - Scheduler app: Problem with drag-and-drop in timeline tab \[ID_27174\]

In the *Timeline \> Events* tab, in some cases, it would no longer be possible to drag a profile onto the timeline.

#### Problem with SLAutomation when a ThreadAbortException was thrown in a script while the thread was not actually aborted \[ID_27187\]

When a ThreadAbortException was thrown in an Automation script while the thread running the script was not actually aborted, in some cases, an error could occur in SLAutomation.

#### Data in DVE child element not updated correctly \[ID_27189\]

When a data table was not fully exported to a DVE child element, but only a few columns were exported as standalone parameters of the DVE child element, including the foreign key column of the DVE table, it could occur that data were not updated correctly.

#### DataMiner Cube: No arrow icons would be displayed in partial tables when behavioral anomaly detection was enabled \[ID_27201\]

When behavioral anomaly detection was enabled, in some cases, only standard trend icons but no arrow icons would be displayed in partial tables.

#### Failover configuration deleted when it should only have been disabled \[ID_27252\]

When Failover was disabled, it could occur that the Failover configuration was deleted from the offline Agent even if you had selected to only disable the configuration. Now this will only happen if you select to delete the configuration.

#### DataMiner Cube - Visual Overview: Incorrect alarm coloring DataDisplayPage shape \[ID_27270\]

When a shape in Visual Overview was linked to a Data Display page, it could occur that it showed the alarm color of the element instead of that of the Data Display page.

#### Problem in SLNet when calculating view alarm states \[ID_27271\]

In some rare cases, a problem could occur in the SLNet process when the alarm states of views were calculated.

#### DataMiner Cube - EPM: Problem when selecting a node in another chain \[ID_27278\]

When you opened an EPM node in another chain via the context menu of that node, in some cases, the filters in the destination chain would be empty when the filter table did not exactly match the corresponding filter table in the source chain.

Also, a number of other (minor) enhancements and fixes have been done:

- The positioning of the selected node in the diagram has been improved, the minimum width of the diagram nodes has been increased, and selection filters without links have been better aligned.

- When opening a node in a chain that had not yet been opened, up to now, some of the filters could be empty.

#### Problem with SLLog \[ID_27317\]

In some cases, the SLLog process could cause a problem or memory leak.

#### Problem with blinking status of service children \[ID_27319\]

Up to now, a service child would always blink when its parent element blinked. As elements can be partially included in a service, in some cases, this was not correct.

From now on, whether a service child blinks will depend on the included parameters.

#### Failover: Incorrect alarm event of type 'properties changed' would be generated for alarms with multiple identical view properties \[ID_27374\]

When, in a Failover setup, an alarm had multiple identical view properties defined, in some cases, an incorrect alarm event of type “properties changed” would be generated each time a switchover occurred.

#### Service & Resource Management: Problem when removing a ServiceResourceUsageDefinition from the ResourcesInReservationInstance list \[ID_27385\]

When you used the Remove() method to remove a ServiceResourceUsageDefinition from the ResourcesInReservationInstance list, in some cases, the incorrect ServiceResourceUsageDefinition would be removed.

## Addendum CU7

### CU7 enhancements

#### Monitoring app: Card header, sidebar and menu available on mobile devices \[ID_25156\]

When you open a card on a mobile device, you will now see a card header instead of the app header, and you will be able to open a card sidebar just like on a desktop device.

Also, the card menu is now accessible through a hamburger button in the top-right corner.

#### Logging: More information stored in errorlog.txt file when an error occurs in SLProtocol \[ID_26630\]

When an error occurs in SLProtocol, from now on, more information about that error will be stored in the errorlog.txt log file.

#### BPA Framework: BPA tests can now take corrective actions \[ID_27222\]

BPA tests can now be configured to take corrective actions when issues are detected.

When creating a BPA test capable of taking corrective actions, developers have to do the following:

1. Implement a class that inherits the BpaCorrectiveTest class.

1. Create an implementation of the Verify() method that will return

   - True when no issues were detected, and
   - False when issues were detected.

1. Create an implementation of the CorrectiveAction() method that will return

   - True when the corrective action was performed successfully, and
   - False when issues prevented the action from being performed.

A BPA test that was set to take corrected actions will run the Verify() method, which will run the CorrectiveAction() method in case of failure, and will then run the Verify() method again.

> [!NOTE]
>
> - The result returned by a test will tell whether corrective actions were taken and whether they were successful.
> - By default, no corrective actions will be taken in any of the tests that are run, unless requested in the beginning of the test run.

#### DataMiner Cube - Router Control: Enhanced configuration of input/output filters of custom matrices \[ID_27253\]

A number of enhancements have been made with regard to the configuration of input and output filters of custom matrices.

#### Scope of BPA test should now always be specified \[ID_27276\]

Before running a BPA test, the scope of the test should now always be specified using the *bpaRunmode* setting:

| If you specify...      | then...                                           |
|------------------------|---------------------------------------------------|
| BpaRunMode.ClusterOnly | the test(s) will be run on all agents in the DMS. |
| BpaRunMode.LocalOnly   | the test(s) will be run on the local agent only.  |

#### Service & Resource Management - Profile parameters: Default value of 'IsOptional' field has changed from 'Undefined' to 'Yes' \[ID_27286\]

Up to now, the *IsOptional* field of a profile parameter was by default set to “Undefined”. From now on, this field will by default be set to “Yes”.

#### Only the most recent synchronization file will now be kept in the 'C:\\Skyline DataMiner\\system cache\\sync' folder \[ID_27323\]

To prevent too many synchronization files from getting stored in the “C:\\Skyline DataMiner\\system cache” folder, from now on, only the most recent file will be kept in the “C:\\Skyline DataMiner\\system cache\\sync” subfolder.

Whenever a file is added to this folder, all files older than a day will automatically be deleted.

#### StandAloneBpaExecutor now has to be run with administrative privileges \[ID_27379\]

From now on, the StandAloneBpaExecutor executable has to be run with administrative privileges. When the executable is run, a UAC box will now appear, asking for administrative access.

#### DataMiner Cube - Visual Overview: EPM card Visual pages now only displayed when page-level properties 'Chain' and 'Field' both match \[ID_27392\]

In an EPM environment, you can assign Visual Overview pages to chains and fields by setting the page-level *Chain* and *Field* properties.

Up to now, all Visual pages of an EPM card with a matching *Field* property were displayed, regardless of their *Chain* property. From now on, a Visual page will only be displayed if its *Chain* property is set to either a valid chain or “\*”.

> [!NOTE]
> Setting the *Chain* property of a Visio page to “\*” will display that page on all chains of the CPE Manager.

#### More detailed information in exception message when a BPA test fails to load due to dependencies not being able to load \[ID_27403\]

When a BPA test fails to load due to one or more dependencies not being able to load, from now on, more detailed information will be provided in the exception message.

#### BPA tests can now be run from a Windows command line \[ID_27420\]

BPA tests can now be run from a Windows command line.

Syntax:

```txt
BpaExec.exe -options -- tests
```

Example:

```txt
BpaExec.exe -option1 value -option2 value --<PathToTest1> <PathToTest2>
```

Supported options:

| Use... | or...               | in order to...                                             |
|--------|---------------------|------------------------------------------------------------|
| -u     | -username           | specify the user name of the SLNet user.                   |
| -p     | -password           | specify the password of the SLNet user.                    |
| -c     | -corrective-actions | allow the test(s) to take corrective actions if necessary. |
| -h     | -help               | display information on how to use this command.            |

#### Enhanced performance when applying, updating or removing alarm templates \[ID_27450\]

Due to a number of enhancements, overall performance has increased when applying, updating or removing alarm templates.

#### StandAloneBpaExecutor can now be used to view previously saved BPA test results \[ID_27451\]

When you saved the results of a BPA test to a JSON file, you can now load that file back into the StandAloneBpaExecutor to review the test result. To do so, go to the *Load results* tab, select the file, and click *Load*.

#### DataMiner Cube - System Center: BPA folder will now also be included when taking a full backup or a configuration backup \[ID_27456\]

From now on, the C:\\Skyline DataMiner\\BPA folder will also be included when you take one of the following predefined backups:

- Full backup
- Full backup without database
- Configuration backup
- Configuration backup without database

#### BPA test results now contain an 'Outcome' property \[ID_27476\]

The IBpaTestResult interface now contains an additional property named “Outcome”. This property can have the following values:

- BpaOutcome.NoIssues
- BpaOutcome.IssuesDetected
- BpaOutcome.Warning

#### Enhanced performance when saving alarm templates with conditional monitoring \[ID_27493\]

Due to a number of enhancements, overall performance has increased when updating alarm templates with conditional monitoring.

#### Support for running BPA tests across a cluster \[ID_27577\]

When interfacing with a DataMiner Agent and its installed BPA tests using the *BpaManagerHelper* object, you can now request the execution of one or more BPA tests across the cluster.

#### Client application licensing removed \[ID_27595\]

The client application licensing feature has now been removed. This means that if accepted credentials are provided, you can now connect to DataMiner with any client application, even if it is not approved by Skyline.

#### DataMiner Cube - Element properties: Dependency between options \[ID_27597\]\[ID_27725\]

When you add a custom property to an element, you can select a number of options.

From now on, it will only be possible to select *Update alarms on value changed* after selecting *Make this property available for alarm filtering*.

> [!NOTE]
> When an element property, service property or view property is created, the *Update alarm on value* changed option will by default be cleared. However, when an alarm property is created, this option will by default be selected.

#### DataMiner Cube - Data Display: Enhanced scrollbar behavior in tables \[ID_27653\]

In Data Display, a number of enhancements have been made with regard to scrollbar behavior in tables.

#### Standard BPA tests will now be included in DataMiner upgrade packages \[ID_27716\]

DataMiner upgrade packages will now by default place a collection of standard BPA tests in the C:\\Skyline DataMiner\\BPA folder.

### CU7 fixes

#### DataMiner Cube - Visual Overview: Problem with highlighting of grouped shapes when zooming in or out \[ID_22365\]

When the ShapeGrouping feature was used, in some cases, grouped shapes were highlighted incorrectly when you zoomed in or out.

#### Ticketing app: Problem when filtering on ticket fields of type GenericEnumEntry \[ID_24689\]

In some cases, it would no longer be possible to filter on ticket fields of type GenericEnumEntry.

#### DMS Alerter: Settings window too small to fit all settings \[ID_27017\]

When, in DMS Alerter, you opened the settings window, in some cases, the window could be too small to fit all settings.

#### Problem with the precision of decimal values \[ID_27136\]

Up to now, when SLElement received a value from SLProtocol, in some cases, the raw value would get rounded to the number of decimals specified in the protocol’s *Display.Decimal* element. In cases where the *Display.Decimal* element defined less decimals than the *Interprete.Decimals* element, the level of precision would drop and would lead to rounding errors.

From now on, values will always be saved to the database with the precision specified in the *Interprete.Decimals* element. Also, that same precision will be taken by raw values sent to client applications.

#### DataMiner Cube: Missing focus icon for correlated alarm \[ID_27168\]

If you expanded a correlated alarm in the Alarm Console in order to see the base alarms and then toggled the *Correlation tracking* option, it could occur that the focus icon was missing for the correlated alarm.

#### Problem when renaming a parent DVE element \[ID_27312\]

When a parent DVE element was renamed multiple times in rapid succession, in some cases, the child DVE elements would not inherit the new element name.

#### DataMiner restart not triggered after process generated crashdump \[ID_27321\]

In some cases, after a DataMiner process had generated a crashdump, it could occur that no DataMiner restart was triggered even though this should have been the case.

#### DataMiner Cube - Visual Overview: DCF interfaces linked to a table entry would lose that link when updated \[ID_27353\]

DCF interfaces that are linked to a table entry can retrieve data from that table via their Parameters property. However, up to now, when an interface was updated, in some cases, it would lose that link. As a result, this could lead to problems in Visual Overview when, for example, the ID of the linked table entry was stored in session variables.

#### BPA tests would fail when being run with administrative privileges \[ID_27382\]

When being run with administrative privileges, BPA tests that accessed SLNet would throw a “To log in as Administrator, please log on explicitly” error unless you manually specified the user name and password on the Settings page.

From now on, when a BPA test is launched, a popup window will appear, asking you to enter the Administrator password.

#### Multiple RTEs in same process not logged correctly \[ID_27387\]

When multiple RTEs occurred in the same process, it could occur that this was not correctly reported in the logging. Reporting of RTEs has now been improved to prevent this. Error alarms will now also get updates when a new thread encounters an RTE or has an RTE resolved.

#### DataMiner upgrade: SNMP service would incorrectly always be stopped \[ID_27400\]

When you launched a DataMiner upgrade, up to now, the SNMP service would incorrectly always be stopped, even when you had cleared the Stop SNMP option.

#### Problem with SLDataMiner due to locking issue in the alarm level linking module \[ID_27418\]

In some cases, an error could occur in SLDataMiner due to a locking issue in the alarm level linking module.

#### Protocol-level TTL settings would incorrectly not be taken into account when parsing real-time trend data \[ID_27421\]

In some cases, protocol-level TTL settings would incorrectly not be taken into account when parsing real-time trend data.

#### DataMiner Cube: Duplicated excluded column parameter entry in alarm template could not be edited \[ID_27423\]

If a column parameter entry that was set to *Excluded* was duplicated in an alarm template, it could occur that it was not possible to edit the duplicated entry.

#### DataMiner Cube would no longer receive data updates from the DataMiner Agent it was connected to \[ID_27434\]

In some cases, DataMiner Cube would no longer receive data updates from the DataMiner Agent it was connected to.

#### DataMiner Cube - Visual Overview: Problem when closing Microsoft Visio while a shape was selected in Cube \[ID_27442\]

When, after opening a Visio file in Microsoft Visio, you closed Microsoft Visio while, in DataMiner Cube, a shape of that same file was selected, in some cases, an error could occur in DataMiner Cube.

#### Web Services API v1 - GetAlarms: Problem when filtering on RootAlarmID \[ID_27445\]

When alarms were retrieved using the GetAlarms method with a filter on RootAlarmID, in some cases, the following SOAP error would be returned:

```txt
System.InvalidOperationException: The specified type was not recognized: name='DMAAlarmFilterRootID'.
```

#### Problems with enhanced services \[ID_27465\]

A number of problems with regard to enhanced services have been fixed:

- When an enhanced service was renamed, in some cases, all open alarms associated with that service would incorrectly disappear.

- After an enhanced service had been reloaded, in some cases, element state changes would no longer be forwarded to that enhanced service.

#### Service & Resource Management: A daylight saving time change would incorrectly cause booking durations to get changed \[ID_27468\]

When a daylight saving time change occurred while a booking was active, in some cases, the duration of that booking would incorrectly get changed.

#### Service & Resource Management: Error that appeared when trying to deactivate or delete a function file in use would contain an incorrect file name \[ID_27470\]

Up to now, when you tried to deactivate or delete a function file used by ReservationInstances, ReservationDefinitions, ServiceDefinitions or ServiceProfileDefinitions, the returned error would contain an incorrect file name.

From now on, the error will contain the correct file name, i.e. the name of the file that cannot be deactivated or deleted because it is in use.

#### DataMiner Cube - Bookings app: Bookings list would not get updated when a booking was deleted \[ID_27482\]

In the Bookings app, the bookings are shown both in the list at the top and the timeline at the bottom. Up to now, when a booking was deleted, in some cases, it would disappear from the timeline but incorrectly remain visible in the list.

#### DataMiner Cube - Alarm Console: Problem when opening an alarm card or switching between alarm cards on a system with a large number of alarm properties \[ID_27483\]

On a system with a large amount of alarm properties, in some cases, an error could occur when you either opened a new alarm card or switched between two open alarm cards.

#### Problem with SLDataGateway \[ID_27498\]

In some cases, the SLDataGateway process would start using an excessive amount of CPU resources, especially in Service & Resource Management environments.

#### DataMiner Cube - Protocols & Templates app: Incorrect warning message when deactivating or deleting a functions file \[ID_27518\]

If you deactivated or deleted a functions file in the Protocols & Templates app, in some cases, an incorrect warning message would be displayed.

#### Mobile apps: Date picker controls would show an incorrect month when the day was greater than or equal to 30 (or 29 in case of a leap year) \[ID_27522\]

In mobile apps (e.g. Jobs), in some cases, date picker controls would show an incorrect month when the day was 30 or 31 (or 29, 30 or 31 in case of a leap year).

#### DataMiner Cube - Alarm templates: Problem when editing alarm levels of a matrix parameter from the Alarm Console \[ID_27535\]

In some cases, it was no longer possible to edit the alarm levels of a matrix parameter from the Alarm Console.

#### Problem when a direct view table of an element retrieved data from that same element \[ID_27548\]

In some cases, an error could occur when a direct view table belonging to a particular element was retrieving data from that same element.

#### DataMiner Cube: About window would incorrectly show launcher tool version instead of Cube client version when Cube was opened using the launcher tool \[ID_27552\]

When you opened DataMiner Cube using the launcher tool, in some cases, the *About* window would no longer display Cube’s client version. It would show the launcher tool version instead.

From now on, the *About* window will show both the Cube client version and the launcher tool version.

#### Alarms for numeric or discrete parameters not read out correctly from MySQL local database \[ID_27585\]

In systems with a MySQL local database, it could occur that alarms for numeric or discrete parameters were not read out correctly from the database when an element restart occurred or an alarm history query was launched.

#### Services containing remote elements would no longer get recalculated when the agent hosting the remote elements was disconnected \[ID_27589\]

In some cases, locally hosted services containing elements hosted on another DataMiner Agent (i.e. remote elements) would no longer get recalculated when the connection with the that other agent was lost.

#### Not possible to delete ticketing resolver \[ID_27603\]

In some cases, it could occur that a ticketing resolver could not be deleted.

#### DataMiner Cube: Columns in EPM data pages would be ordered incorrectly when using custom parameter positioning \[ID_27622\]

By default, an EPM card displaying row data as single parameters will automatically position those parameters unless custom positioning is applied on at least one of the columns (using the “CPEIntegration\_” prefix).

In some cases, when parameters were positioned automatically, the columns would not be ordered correctly. They would incorrectly be ordered according to the column definition order instead of the order defined in the options.

#### Minor issues in BPA framework \[ID_27625\]

The following minor issues could occur in the BPA framework:

- In some cases, it could occur that BPA tests were not updated correctly if BpaManager.BPAs.Update was used. The BPA info was not stored.

- BpaManager did not always include trace data on exceptions, causing BpaManagerHelper not to throw ManagerStoreExceptions.

#### DataMiner Cube - Alarm Console: Problem with alarm hyperlinks when the first character of the parameter name is hash character \[ID_27641\]

When you right-clicked an alarm associated with a parameter of which the name started with a “#” character and then clicked an alarm hyperlink that ran an Automation script that used that parameter name as input, in some cases, an error could occur.

#### DataMiner Cube: Clicking a pinned or recently opened custom element app would incorrectly cause another app to open \[ID_27642\]

When the *Activities* tab of the navigation pane listed multiple custom element apps of the same type (either pinned or not), in some cases, clicking one of those apps would incorrectly cause another app to open.

#### SLLogCollector: Generated packages would have incorrect file names \[ID_27677\]

In some cases, SLLogCollector would fail to include the ID and name of the DataMiner Agent in the file name of the packages it generated.

#### DataMiner Cube - Protocols & Templates: Monitoring conditions would not get reapplied after switching alarm templates \[ID_27696\]

When you switched from an alarm template with conditions that were not used to an alarm template with identical conditions that were used, in some rare cases, conditional monitoring would incorrectly not get reapplied for the parameters using those conditions.

#### On DMAs with a MySQL database, alarms based on parameters of type 'analog' or 'progress' would have an incorrect display value after an element restart \[ID_27715\]

On DataMiner Agents using a MySQL database, in some cases, alarms based on parameters with measurement type “analog” or “progress” would have an incorrect display value after an element restart.

#### DataMiner Cube - Settings: Default workspace settings would incorrectly be displayed as text boxes instead of selection boxes \[ID_27718\]

In the User \> Cube sides section of the Settings window, when no custom workspaces had been created, the “default workspace” settings would incorrectly be displayed as text boxes instead of selection boxes.

#### Problem with SLLogCollector tool \[ID_27769\]

If a user had never used SLLogCollector before, it could occur that this tool failed to include memory dumps in packages generated for this user.

In addition, in some cases, SLLogCollector failed to include the contents of the *System Cache\\Info* folder in a memory dump.

#### DataMiner - Visual Overview: Embedded alarm timeline would not show its summary timeline \[ID_27889\]

In some cases, an embedded alarm timeline component would not show its summary timeline.

## Addendum CU8

### CU8 enhancements

#### DataMiner Cube will now always connect to a DataMiner Agent via .NET Remoting \[ID_27354\] \[ID_27904\]

Up to now, DataMiner Cube could use either .NET Remoting or Web Services to connect to a DataMiner Agent. However, as Web Services Enhancements (WSE) for Microsoft .NET is now deprecated, from now on the only way for DataMiner Cube to connect to a DataMiner Agent is by using .NET Remoting.

As a result, in the *Settings* window, it is no longer possible to set the *Computer \> Connection \> Connection type* setting to “Web services”.

#### StandAloneBpaExecutor now supports asynchronous execution of BPA tests across a DMS \[ID_27652\]

The StandAloneBpaExecutor tool now supports asynchronous execution of one or more BPA tests across a DataMiner System.

#### BPA test metadata now indicates whether a test contains corrective actions \[ID_27704\]

The metadata of a BPA test now includes a HasCorrectiveActions property.

If a BPA test contains corrective actions, this property will be set to true.

#### Enhanced performance when processing alarm template actions \[ID_27706\]

Due to a number of enhancements, overall performance has increased when processing alarm template actions.

#### BPA test framework: New flag to indicate whether a test can be run against an offline agent in a Failover setup \[ID_27762\]

When you create a BPA test, you can now use the BpaFlags.CanRunOnOfflineAgents flag to indicate whether the test can be run against an offline agent in a Failover setup.

Default: False

#### Long running actions will now be canceled when a DataMiner upgrade finishes \[ID_27765\]

When a DataMiner upgrade finishes (successful or not), from now on, all remaining long running actions will be canceled.

#### DataMiner Cube: Enhanced performance when logging in and logging out \[ID_27851\]

Due to a number of enhancements, overall performance has increased when logging in and logging out, especially on large systems.

#### DataMiner Cube - Data Display: Background color of tree control table tabs has been adapted in order to enhance readability \[ID_27881\]

In the Skyline Black theme, the background color of tree control table tabs has been adapted in order to enhance readability.

#### Service & Resource Management: Deleting resources only allowed when all DMAs in the DMS are reachable \[ID_27921\]

From now on, you will only be allowed to delete resources when all agents in the DMS are reachable. This will prevent deleted resources from re-appearing when a DMA is started up again.

When you try to delete a resource, an error will now be returned in the following circumstances:

- When at least one agent is disconnected from the agent that hosts the resource you are trying to delete.
- When at least one agent is not in a running state.
- When there is at least one agent on which the ResourceManager module is not initialized.

#### BPA test framework: Abstraction layer added to allow backward compatibility of BPA tests \[ID_27988\]

An abstraction layer has now been added to the BPA test framework. This will prevent older tests from being rendered incompatible when changes are made to the framework.

#### SLNet.exe.config: TcpWebServicePort key will now be ignored \[ID_27990\]

As Web Services Enhancements (WSE) for Microsoft .NET has been deprecated, in the appSettings section of the SLNet.exe.config file, the TcpWebServicePort key will now be ignored.

#### BPA tests can now be assigned a maximum DataMiner version \[ID_27997\]

When creating a BPA test, it is now possible to indicate the most recent DataMiner version on which the test will work.

When a DataMiner Agent is upgraded to a version equal to or above the one specified in the MaxVersion setting of a test, that test will no longer be executed. Also, you will not be able to upload a BPA test to a DataMiner Agent with a version equal to or above the one specified in the MaxVersion setting.

### CU8 fixes

#### DataMiner Cube - Visual Overview: Unnecessary subscription on property when highlight condition was configured based on name \[ID_27409\]

When a highlight condition was configured on a Visual Overview shape based on the name of an element, service or view, an unnecessary property subscription was also made. This will no longer occur.

#### Failover: Problem with SLSNMPManager \[ID_27599\]

During a Failover switch, in some cases, an error could occur in SLSNMPManager.

#### DataMiner Cube: When one client forcefully disconnected another client, the latter would incorrectly reconnect \[ID_27638\]\[ID_27671\]

When two different Cube clients were connected to the same DataMiner Agent, and one forcefully disconnected the other, up to now, that forceful disconnection would incorrectly be considered as abnormal, causing the disconnected client to immediately reconnect.

From now on, when one client forcefully disconnects another client, the disconnection will be treated as a forceful logout instead.

#### Problem with excessive memory usage of SLDataGateway and SLNet during DataMiner startup \[ID_27658\]

When a DataMiner Agent with a Cassandra database had experienced two days of high alarm activity, in some cases, SLDataGateway and SLNet would start to use excessive amounts of memory after DataMiner startup.

A number of enhancements have now been made to the way in which the alarm history is retrieved during a DataMiner startup.

#### DataMiner Cube - Visual Overview: Problem when clicking a connection line drawn based on table data \[ID_27692\]

In some cases, an exception could be thrown when you clicked a connection line that was drawn based on table data.

#### When users logged in with domain administrator credentials, they would incorrectly log in with the local administrator account instead \[ID_27713\]

In some cases, when users logged in with domain administrator credentials, they would incorrectly log in with the local, built-in administrator account instead.

#### Problem with SLDataMiner when importing a CSV file created with a previous DataMiner version \[ID_27722\]

When you imported a CSV file that was created with a previous DataMiner version, in some cases, an error could occur in SLDataMiner.

#### DataMiner Cube - Data Display: Trend icons would not be displayed until after a few minutes \[ID_27740\]

When you opened an element card, in some cases, trend icons in tables would not be displayed until after a few minutes.

#### DataMiner Cube - Protocols & Templates: An alarm template group would incorrectly not take into account the scheduling configured in the alarm templates in that group \[ID_27749\]

When an alarm template using scheduling was added to an alarm template group, in some cases, the alarm template group would not take into account the scheduling configured in that alarm template.

#### DataMiner - Router Control app: Newly selected input would be highlighted but not selected when the selected output was updated \[ID_27752\]

When, in the Router Control app, you had enabled the *Output first workflow* option, in some cases, when the selected output was updated by an external change, the newly selected input would be highlighted but incorrectly not selected.

Also, it will now be indicated more clearly that a highlighted IO button is selected.

#### Service & Resource Management: When a ReservationInstance was updated, the timeout scripts would incorrectly be executed instead of the expected event script \[ID_27757\]

When you updated an ongoing ReservationInstance, in some cases, all ongoing and future events (i.e. scripts) of that instance would incorrectly be canceled and the timeout scripts would be run on all DataMiner Agents instead.

#### DataMiner Cube: Element and parameter heat lines would incorrectly stay gray \[ID_27767\]

In the Alarm Console and in Reports pages of card, in some cases, element and parameter heat lines would incorrectly stay gray.

#### Problem when updating a DVE table while data exported via a virtual function was being retrieved \[ID_27768\]

In some cases, an error could occur when a DVE table was updated while data exported via a virtual function was being retrieved.

#### Alarms with a virtual function impact would not be regenerated when a virtual function was linked or unlinked via the generic linked table \[ID_27775\]

When a virtual function was linked or unlinked via the generic linker table, in some cases, alarms with a virtual function impact would not be regenerated.

#### Memory leak when using the Chromium browser engine in a browser version of DataMiner Cube \[ID_27789\]

When running a browser version of DataMiner Cube in Microsoft Internet Explorer, in some cases, a memory leak could occur when using the Chromium browser engine to e.g. visualize web pages in Visual Overview.

#### Alarm missing from service alarm table after enhanced service was renamed \[ID_27800\]

When an enhanced service was renamed while there was an alarm on multiple services, it could occur that this alarm was cleared from the alarm table of the enhanced service element.

#### DataMiner Cube - Service & Resource Management: Certain text boxes would not allow you to enter a zero character \[ID_27809\]

In certain text boxes, in some cases, it would not be possible to enter a zero character.

#### DataMiner Cube - Alarm Console: Problem when performing actions in rapid succession \[ID_27814\]

In the Alarm Console, in some cases, an exception could be thrown when certain actions were performed in rapid succession.

#### Problem with Protocol.Groups.Group.Content.Session@Next attribute \[ID_27820\]

In a Protocol.Groups.Group.Content.Session@Next attribute, you can specify the number of milliseconds DataMiner has to wait to execute the next session after receiving the response of the last executed session. In some cases, this setting would incorrectly be disregarded.

#### Alarm masked for a limited period of time would not be unmasked if the alarm template was updated while the alarm was masked \[ID_27838\]

When an alarm associated with a column parameter was masked for a limited period of time, in some cases, it would not be unmasked when that period of time elapsed if an alarm template update affecting the column parameter had occurred while it was masked.

#### Problem with automatic URI detection \[ID_27884\]

In some cases, an exception could be thrown during automatic URI detection.

#### DataMiner Cube: Problem when viewing a discrete profile parameter in the Profiles app \[ID_27888\]

In DataMiner Cube, in some cases, an error could occur when you viewed a discrete profile parameter in the Profiles app.

#### Problem when editing a protocol while a cluster synchronization was in progress \[ID_27890\]

In some rare cases, an error could occur when a protocol was edited while a cluster synchronization was in progress.

#### DataMiner Cube - Trending: Problem with trend groups containing invalid data \[ID_27892\]

In some cases, an exception could be thrown when a trend group contained invalid data.

#### DataMiner Cube - Bookings app: Memory leak when opening the Signal Path tab \[ID_27952\]

In some cases, DataMiner Cube could leak memory each time you opened the Signal Path tab when configuring a booking in the Bookings app.

#### DataMiner Cube - Visual Overview: Problem with SurveyorSearchText variable \[ID_27996\]

In some cases, making a shape display or set the Surveyor search text using the Surveyor-SearchText session variable would no longer work.

#### Service & Resource Management: Capacities property and Capabilities property of a Resource could incorrectly be set to null \[ID_28005\]

In some rare cases, the Capabilities property and the Capacities property of a Resource could incorrectly be set to null.

#### DataMiner Cube - Profiles app: Incorrect error message when Name text box is empty \[ID_28007\]

When the name of a profile definition or a profile instance was empty, in some cases, an incorrect error message would appear.

#### DataMiner Cube: Problem when the single, dynamically included element in a service was briefly excluded \[ID_28013\]

When a service contained a single, dynamically included element, in some cases, an exception could be thrown when the element was briefly excluded from the service.

#### Display values of rate alarms would have an unnecessary level of precision after an element restart on systems with a MySQL database \[ID_28028\]

On a system with a MySQL database, in some cases, display values of rate alarms would have an unnecessary level of precision after an element restart.

#### Value rate alarm not displayed correctly \[ID_28039\]

In some cases, it could occur that the value of a rate alarm was not displayed correctly. this could for instance occur after an element restart, after an element was masked, etc.

#### DataMiner Cube - Alarm Console: Error alarms could get stuck when a process had multiple threads with run-time errors \[ID_28113\]

In some cases, error alarms could get stuck in the Alarm Console when a process had multiple threads with run-time errors.

#### Problem in SLLog after stopping and reopening log file \[ID_28122\]

If a log file was stopped and then reopened shortly afterwards, a problem could occur in the SLLog process.

## Addendum CU9

### CU9 enhancements

#### Cassandra: User will now be notified when restoring a database backup has failed \[ID_27441\]

When restoring a Cassandra database backup has failed, from now on, the user will be notified and the restore operation will not be marked as complete.

#### DataMiner Cube - Visual Overview: More filter options when configuring an alarm timeline \[ID_27632\]

When, in Visual Overview, you right-click an alarm timeline with an alarm filter and select Show alarms in a new tab page, the alarms matching the filter will be loaded.

Up to now, it was only possible to filter on alarm properties. Now, you can also filter on severity (e.g. Severity:Critical), element (e.g. Element:49/1), etc.

#### DataMiner Cube: Enhanced performance when opening the Reports page of a view card \[ID_27937\]

Due to a number of enhancements, overall performance has increased when opening the Reports page of a view card, especially when that page shows a large amount of elements with heatlines (e.g. the root view).

#### Web Service API v1: New GetDataMinerClusterName method \[ID_27951\]

The GetDataMinerClusterName method can now be used to retrieve the name of the DataMiner System a DMA is part of.

#### BPA test framework only allows to upload and execute BPA tests that have been digitally signed by Skyline \[ID_27979\]

From now on, the BPA test framework will only allow to upload and execute BPA tests that have been digitally signed by Skyline.

#### SLUpgrade: New option to forcefully kill processes \[ID_27983\]

Up to now, in some cases, attempting to disable a service during a DataMiner upgrade could fail.

Now, when a service has the ACTION_KILL flag added to its service info, it will forcefully be terminated when a clean stop and/or disabling fails.

#### DataMiner Cube - System Center: Refresh button in Logging section \[ID_27986\]

In the Logging section of System Center, you can now click Refresh to reload the log entries.

#### BPA test results now include error impact and list of corrective actions \[ID_28018\]

A BPA test result now contains the following additional fields:

| Field            | Description                                        |
|------------------|----------------------------------------------------|
| Impact           | The impact of the error.                           |
| CorrectiveAction | The actions users could take to correct the error. |

#### BPA tests: Maximum DataMiner version now specifies the last compatible version instead of the first incompatible version \[ID_28108\]

When creating a BPA test, it is possible to indicate the most recent DataMiner version on which the test will work.

From now on, when a DataMiner Agent is upgraded to a version above the one specified in the MaxVersion setting of a test, that test will no longer be executed. Also, you will not be able to upload a BPA test to a DataMiner Agent with a version above the one specified in the MaxVersion setting.

#### BPA tests can now be set to automatically run at specific intervals \[ID_28126\]

BPA tests can now be set to automatically run at specific intervals.

#### Table updates: Threshold columns will now be processed before non-prioritized columns \[ID_28139\]

When a table row is updated, the cells are handled according to the column's perceived priority unless overwritten. The processing order of columns has now been extended so that columns that are part of a threshold option (*Protocol.Params.Param.Alarm@Options*) within the same table definition get processed before columns that are part of a property definition and any other columns. This results in the following column processing order:

1. Primary key (index)
2. Display column
3. Foreign key columns
4. Columns part of the naming or namingformat definition
5. Columns part of a conditional monitoring definition
6. Columns part of a threshold definition (NEW)
7. Columns part of a property definition

Any other columns are processed in the order defined in the table parameter

#### DataMiner Cube - Protocols & Templates: More information will now be returned to the user when a protocol upload fails \[ID_28183\]

When you are uploading a protocol in the *Protocols & Templates* app, a message box will appear when the upload operation has failed. This message box will now contain more detailed information about why the operation failed.

#### SLAutomation will now automatically compile new libraries at startup \[ID_28218\]

When, on startup, SLAutomation detects any new Automation scripts that contain libraries that need to be compiled, from now on, it will automatically compile them.

#### SRM: Additional logging added to SLDBConnection.txt when retrieving service definitions from the servicedeftrace table \[ID_28245\]

Additional information will now be logged in the SLDBConnection.txt log file when service definitions are being retrieved from the servicedeftrace table with a time-based filter.

This information will include the filter that was used as well as the number of valid, outdated and deleted service definitions that were found.

As soon as the read request is made, outdated and deleted service definitions will be deleted in the background. When this delete operation finishes and each time a deletion fails, an entry will be added to the log.

### CU9 fixes

#### SLDataGateway would append inaccurate query timestamps to Cassandra statements \[ID_27534\]

In some cases, SLDataGateway would append inaccurate query timestamps to Cassandra statements.

#### Failover: An agent taken out of a Failover setup would incorrectly keep on trying to connect to the database of the other agent \[ID_27803\]

When a DataMiner Agent was taken out of a Failover setup, in some cases, it would incorrectly keep on trying to connect to the database of the other agent.

#### DataMiner Cube: System Center could incorrectly display negative trend values \[ID_27825\]

In some cases, System Center could incorrectly display negative trend values.

#### Problem when using smart IP header on UDP \[ID_27957\]

When the smartIpHeader communication option was used in a smart serial protocol and multiple clients were sending UDP datagram packets to the smart serial server socket, it could occur that the first package of the second sender would not be processed until a second package arrived.

#### DataMiner Cube: Redundancy groups using software redundancy would not trigger when the switching logic contained elements that were neither primary nor backup element \[ID_28041\]

Redundancy groups making use of software redundancy would incorrectly not trigger when the switching logic contained elements that were neither primary nor backup element.

#### Service & Resource Management: Problem when setting function resource states \[ID_28050\]

In some cases, an error could occur when setting function resource states. As a result, ReservationInstances would no longer be created.

#### DataMiner Cube - Visual Overview: Zoom buttons would disappear when switching to full-screen mode and back in an embedded trend graph \[ID_28065\]

When, in an embedded trend graph, you switched to full-screen mode and back, in some cases, the “Zoom to last X” buttons would disappear.

#### Problem when retrieving composite instances using the 'partialSNMP' option \[ID_28087\]

When retrieving composite instances using the SNMP polling option “partialSNMP”, in some cases, only the first set of the table would be polled correctly. Other rows would either be empty or not polled at all.

#### Visual Overview: SetVar shape with tooltip would not work on a mobile device \[ID_28129\]

When a SetVar shape had its SetVarOptions data field set to “Control=Shape” and contained a legacy tooltip configuration (e.g. ‘\<MyVar>:\<MyValue>:\<MyToolTip>’), in some cases, the variable would not be updated when you clicked the control on a mobile device.

#### DataMiner Cube - Element connections app: Problem with 'Include element state' checkbox \[ID_28188\]

In the *Element connections* app, in some cases, the value of the *Include element state* checkbox would be saved incorrectly.

#### DataMiner Cube - System Center/Backup: 'Use one network path for all Agents' setting would be saved correctly but displayed incorrectly \[ID_28192\]

In the Backup section of System Center, it is possible to specify that a backup has to be stored on a network path. In some cases, when you specified one shared network path for all DataMiner Agents, this would be saved correctly, but displayed incorrectly in the user interface.

#### DataMiner Cube: Impossible to remove a trend template or an alarm template via the right-click menu of an element when the UI language was not set to English \[ID_28198\]

When DataMiner Cube was set to a language other than English, in some cases, it would not be possible to remove an alarm template or a trend template via the right-click menu of an element.

#### SLUpgrade would incorrectly disregard changes made to the SLNet.exe.config file \[ID_28228\]

In some cases, the SLUpgrade process would disregard changes that were made to the SLNet.exe.config file.

#### Failover: Incorrect error message would appear after configuring a Failover setup \[ID_28241\]

In some cases, a cluster name mismatch error would incorrectly appear immediately after configuring a Failover setup.

#### Vendor name would incorrectly disappear from protocol signatures \[ID_28246\]

When a DVE protocol was signed, or when a signed protocol was promoted to production protocol, in some cases, the vendor name would disappear from the signature.

#### Client applications would incorrectly receive table updates multiple times \[ID_28250\]

When data was updated in a table, in some cases, client applications would incorrectly receive those updates multiple times.

#### DataMiner Cube: No pop-up messages when users logged in again after logging out \[ID_28306\]

When users logged in again after having logged out, in some cases, popup messages would no longer appear.

#### SLWatchDog2.txt: Total number of processes of which at least one thread has a run-time error was incorrectly replaced by total number of threads with a run-time error \[ID_28360\]

Each time a run-time error occurs, an entry is added to the SLWatchDog2.txt log file, showing the total number of processes of which at least one thread has a run-time error.

However, in some cases, that log entry would incorrectly show the total number of threads with a run-time error instead.

#### HTML5 apps: Problem when entering numeric values \[ID_28374\]

When a numeric value was updated in the UI, in some cases, the old value would incorrectly re-appear after the new value had been validated.

#### Problem with SLDataMiner when loading protocols \[ID_28447\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.

## Addendum CU10

### CU10 enhancements

#### DataMiner Cube - Alarm templates: Hysteresis values can now be lower than the polling interval \[ID_28207\]

In the Alarm template editor, it is possible to configure hysteresis values for a monitored parameter. From now on, you will be able to enter hysteresis values that are lower than the polling interval of the parameter or the protocol. This will allow hysteresis to also work correctly for protocols in which SNMP traps are defined.

> [!NOTE]
>
> - In general, it remains recommended to specify hysteresis values that are greater than the polling interval of the parameter. Only for parameters updated via SNMP traps or smart-serial parameters should you consider specifying hysteresis intervals that are lower than the polling interval.
> - Up to now, when you entered a hysteresis value that was lower than the polling interval, an error message would be displayed. From now on, a warning message will be displayed instead.

#### DataMiner Cube - Data Display: Enhanced performance when loading the default page after opening a card \[ID_28255\]

Due to a number of enhancements, overall performance has increased when loading the default page after opening a card.

#### DataMiner Maps: Style attribute of TableSourceInfo tags will now by default be set 'markers' \[ID_28313\]

In a map configuration file, the style attribute of a TableSourceInfo tag can be set to either “markers” or “lines”.

From now on, if this attribute is not specified, it will by default be set to “markers”.

#### DataMiner Cube - Protocols & Templates: Signed enhanced service protocols \[ID_28338\]

In the Protocol & Templates app, it is now also possible to have signed enhanced service protocols.

#### DataMiner Cube - Services app & Visual Overview: Enhanced performance when refreshing service definition diagrams \[ID_28340\]

Due to a number of enhancements, overall performance has increased when refreshing service definition diagrams, both in the Services app and in Service Manager components embedded in visual overviews.

#### Log level of '!! No link found for ...' errors has been lowered from 0 to 5 \[ID_28353\]

Up to now, when SLElement tried to resolve a relation path in an element, it would throw a “!! No link found for ...” error with log level 0 and log type “Error”. As this error occurs very frequently in case of virtual functions, its log level has now been lowered from 0 to 5.

#### Enhanced performance when updating parameters \[ID_28515\]

Due to a number of enhancements, overall performance has increased when updating parameters.

#### Restricting the size of the C:\\Skyline DataMiner\\Logging\\WatchDog\\Notifications folder \[ID_28548\]

When a run-time error occurs, SLWatchdog stores a number of files in the C:\\Skyline DataMiner\\Logging\\WatchDog\\Notifications folder of the DataMiner Agent.

From now on, additional measures will be taken to prevent this folder from taking too much disk space. For example, files compressed into an errors.zip file will now be removed after the zip file has been created. Also, the oldest files will now be deleted each time the total size of the folder exceeds 1 GB.

#### Enhancements made to BPA test infrastructure and the StandaloneBpaExecutor tool \[ID_28556\]

A number of enhancements have been made to the BPA test infrastructure and the StandaloneBpaExecutor tool.

### CU10 fixes

#### Problem with SLASPConnection when a timeout occurred while retrieving an alarm history \[ID_28163\]

When a timeout occurred while retrieving an alarm history, in some cases, an error could occur in the SLASPConnection process.

#### Secondary element ports would handle headers and trailers incorrectly \[ID_28271\]

When more than one connection were defined, in some cases, the secondary connections would not be able to handle headers and trailers correctly. This was due to the fact that the port cookie of the main port was incorrectly being used for all header and trailer information.

#### Problem when trying to activate data offload to a database \[ID_28276\]

When, in the *Database* section of *System Center*, you clicked the *Offload* tab, selected the *Activate this database* option, and then clicked *Save*, in some cases, this change would not be saved.

#### Problem when offloading data to SLDataGateway \[ID_28318\]

When offloading data to SLDataGateway, in some cases, a CPU leak could occur.

#### SLWatchDog was not able to detect problems occurring in SLSNMPAgent \[ID_28330\]

In some cases, the SLWatchdog process would not be able to detect problems occurring in the SLSNMPAgent process. From now on, SLSNMPAgent will register with SLWatchdog as soon as it is set to running.

#### DataMiner Maps: Problem when the autofit attribute of an OpenStreetMap layer was set to true \[ID_28336\]

When the autofit attribute of an OpenStreetMap layer was set to true, in some cases, automatic marker fitting could fail when the markers were loaded before the map view was fully visible.

#### DataMiner Cube: Clicking the alarm banner did not have any effect \[ID_28339\]

When, in DataMiner Cube, you logged out and then in again, clicking the alarm banner in the header would not have any effect.

The banner shows the number of new alarms, the color of the most severe among them, and service impact information. When you click the banner, the Alarm Console tab should open and the new alarm(s) should be selected.

#### DataMiner Cube: Problem when logging on to an SRM system \[ID_28342\]

When you logged on to a system running Service & Resource Management (SRM), in some cases, an error could occur in DataMiner Cube.

#### Offload database configuration: Problem with OldStyle=true option \[ID_28366\]

In the Db.xml file, you can add the OldStyle=true option to the offload database configuration to revert to the behavior of older DataMiner versions, so that average trend information is offloaded regardless of whether parameter values have changed.

However, in some cases, when this option was specified, unchanged values of type string or discreet would incorrectly not be written to the offload database.

#### DataMiner Cube: Problem with shared folder permissions \[ID_28373\]

The first time a user opens a newly installed DataMiner Cube, a folder structure is created in C:\\ProgramData\\Skyline. Up to now, when another user subsequently opened DataMiner Cube on the same machine, in some cases, that user would not be granted access to certain cache folders, which would cause delays when requests were made to the DataMiner Agent.

#### Child shapes automatically generated for elements in a service would be sorted incorrectly \[ID_28386\]

When child shapes automatically generated for elements in a service were sorted by name using a ChildrenSort data field, in some cases, the shapes would be sorted incorrectly.

From now on, child shapes sorted by name will be sorted by alias or, if no alias is found, by element name.

#### SNMP Managers: Polling IP address can now be added as a custom trap binding \[ID_28391\]

When configuring an SNMP manager, you can now add the polling IP address as a custom trap binding.

#### SLWatchDog would not log error messages when it failed to generate or clear alarm events \[ID_28435\]

When SLWatchDog was creating or clearing alarm events (e.g. alarm events reporting run-time errors), no error messages would be logged when a request to create or clear an alarm event failed. From now on, those errors will be logged in SLWatchDog2.txt.

#### DataMiner Cube - Resources app: Problem when adding, updating or deleting a resource \[ID_28438\]

In some cases, an error could occur when you added, updated or deleted a resource in the Resources app.

#### DataMµiner Cube - Service templates: Templated service incorrectly placed in the root view instead of the view containing the original view \[ID_28491\]

When you duplicated a service as a templated service, in some cases, the newly created templated service would incorrectly be placed in the root view instead of the view containing the original service.

#### DataMiner Cube - Query Executor: Problem when a Cassandra database returned a collection object \[ID_28499\]

When, in DataMiner Cube’s Query Executor, you launched a query that retrieved data from a Cassandra database, in some cases, an incorrect result would be displayed when the query returned a collection object.

#### Problem when updating DVE protocols \[ID_28561\]

When an existing DVE protocol was updated, in some cases, the update would fail.

#### DataMiner Cube - Profiles app: Production versions not listed in protocol list when adding a profile parameter \[ID_28687\]

When, in the Profiles app, you added a profile parameter, in some cases, the list of available protocols would incorrectly not list production versions.

## Addendum CU11

### CU11 enhancements

#### Elasticsearch: Dynamic templating now enabled by default on customdata \[ID_28047\]

From now on, in an Elasticsearch database, dynamic templating will be enabled by default on customdata. As a result, when new fields are added to a customdata object, those fields will now always be searchable.

#### System Center - Agents: BPA test management \[ID_28516\]

In the *Agents* section of *System Center*, the new *BPA* tab now allows you to view and run the Best Practices Analyzer (BPA) tests available on your DataMiner System.

This growing list of tests will allow you to check hardware and software requirements in order to guarantee an optimal and smooth DataMiner operation.

#### DataMiner Cube - Alarm Console: Enhanced performance when loading alarms into a sliding window \[ID_28537\]

Due to a number of enhancements, overall performance has increased when loading alarms into a sliding window, especially on systems with large alarm trees.

#### BPA tests can now indicate execute conditions \[ID_28576\]

The BPA interface has been extended with an ExecutionConditions property.

This way, BPA test writers can expose one or more conditions that need to be fulfilled before the BPA can be run. If the conditions are not met, the BPA will return “NoIssues” with the reason “This BPA does not apply for this DataMiner Agent”.

#### BPA tests will now be executed by helper processes \[ID_28613\]

Up to now, BPA tests were executed from within the SLNet process. They will now be executed by helper processes instead.

#### BPA tests will now also be forwarded to offline agents \[ID_28658\]

Up to now, when a BPA test could not be run on an offline agent, it would not be forwarded to that agent. Now, BPA tests will be forwarded to all agents, and clients will be notified when an offline agent is not capable of running a test.

#### When the same BPA test is uploaded again, it will be updated \[ID_28668\]

Up to now, when a BPA test was uploaded, no check would be performed to determine whether it was already present on the system.

From now on, when a BPA test is uploaded, a check will be performed:

- If a BPA test is found with the same name under the same DLL, the test will be updated, but the GUID and the schedule will be left unchanged.
- If a BPA test is found with the same name under a different DLL, an error will be thrown.

#### Enhanced performance when a large number of Cube clients are connected to the same DMA \[ID_28695\]

Due to a number of enhancements, overall performance has increased when a large number of Cube clients are connected to the same DataMiner Agent.

#### DataMiner Cube - SNMP forwarding: Setting the code page to be used \[ID_28745\]

When configuring an SNMP manager in DataMiner Cube, it is now possible to set the code page to be used.

Default code page: UTF-8

#### Last test results can now be retrieved for any type of BPA test \[ID_28759\]

Previously, it was only possible to retrieve the last results of scheduled BPA tests that had run in the background. From now on, it is possible to retrieve the last results of any type of BPA test, scheduled or non-scheduled.

#### 'Register DataMiner as Service32.bat' removed from the C:\\Skyline DataMiner\\Tools folder \[ID_28808\]

The “Register DataMiner as Service32.bat” file has been deprecated. It has been removed from the C:\\Skyline DataMiner\\Tools folder.

### CU11 fixes

#### Problem when performing a DataMiner upgrade \[ID_28350\]

In some cases, an error could occur during a DataMiner upgrade.

#### DataMiner Cube - Automation: Not possible to save a script after modifying an if/then block \[ID_28532\]

When, in an Automation scripts, you had changed the actions in an if/then block, in some cases, the *Save script* button would incorrectly not get activated. As a result, you were not able to save the modified script.

#### DataMiner Cube - Scheduler app: Problem when editing a script event in the timeline \[ID_28542\]

When editing a script event in the timeline of the Scheduler app, in some cases, an incorrect parameter would be passed to the DataMiner Agent, causing the Stop parameter on the scheduled action to get the value START instead of STOP.

#### Dashboards app: Problems when moving dashboards \[ID_28543\]

When, in the Dashboards app, you moved a dashboard to the currently active folder, in some cases, an error could occur when you tried to open the dashboard that was moved.

Also, when you manually entered the location to which a dashboard had to be moved, in some cases, that location would incorrectly not be saved when you pressed the ENTER key once. Only when you pressed the ENTER key a second time would the location be saved.

#### DMS Alerter: Settings window too small to fit all settings \[ID_28550\]

When, in DMS Alerter, you opened the settings window, in some cases, the window could be too small to fit all settings.

#### DataMiner Cube: Problem when opening the Protocols & Templates app \[ID_28551\]

In some cases, an exception could be thrown when you opened the Protocols & Templates app.

#### Dashboards app - Bar chart component: Problem when selecting a time span without alarms \[ID_28569\]

When, while configuring a bar chart component that showed data from a view, you specified a time span during which no alarms had occurred, in some cases, an error could be thrown.

Now, an empty chart will be shown instead.

#### Service & Resource Management: ReservationInstance was incorrectly marked as interrupted when created with a start time before the Resource Manager was initialized \[ID_28571\]

When a ReservationInstance was created with a start time in the past, before the Resource Manager was initialized, that ReservationInstance would incorrectly be marked as interrupted.

#### DataMiner Cube: Heatlines displayed in the Alarm Console or in Reports pages of cards would incorrectly be gray \[ID_28579\]

In some cases, element and parameter heatlines displayed either in the Alarm Console or in Reports pages of cards would incorrectly be gray.

#### Service & Resource Management: DecimalQuantity property of CapacityUsageParameterValue incorrectly saved without decimals \[ID_28582\]

When the DecimalQuantity property of the CapacityUsageParameterValue of a Profile-Instance was specified, in some cases, the decimals would be lost was the ProfileInstance was saved in the Elasticsearch database.

#### Problem when adding data to an Elastic logger table \[ID_28587\]

Up to now, when data was added to an Elasticsearch logger table, in some cases, an attempt would incorrectly also be made to add the same data to a non-existing Cassandra logger table.

#### Failover: Offline agent would not be informed of changes made to BPA test configurations \[ID_28624\]

In a Failover setup, up to now, the offline agent would not be aware of any changes made to the configuration of a BPA test. From now on, the BPAManager will correctly inform that agent of all changes made to BPA test configurations.

#### Problem when compiling QActions when 'System.xxxx' and 'Microsoft.xxx' DLL files could not be found in the Windows System Assemblies folders \[ID_28653\]

When a QAction was defined with dllImport=”System.xxxxx.dll” or dllImport=”Microsoft.xxxx.dll”, in some cases, the QAction would fail to compile when the referenced DLL file could not be found in the Windows System Assemblies folders.

Also, the compilation error would not be added to the log file.

#### DataMiner Cube - Alarm Console: Memory usage would increase when a correlated alarm was cleared \[ID_28667\]

When a correlated alarm was cleared, overall memory usage would temporarily increase, which, in some rare cases, could lead to an “out of memory” exception.

#### Problem with SLSpectrum when a client disconnected \[ID_28669\]

In some cases, an error could occur in the SLSpectrum process when a client disconnected.

#### Correlation: Correlation rules would incorrectly be triggered by empty alarms \[ID_28680\]

In some cases, correlation rules would incorrectly be triggered by empty alarms, causing emails to be sent with unresolved placeholders.

#### Problem in SLDataMiner if Protocol.xml.lnk file linked to unavailable path \[ID_28715\]

A problem could occur in the SLDataMiner process if a protocol production version Protocol.xml.lnk file linked to a path that could not be reached.

#### DataMiner Cube: Incorrect parameter information would be displayed in a card after it had been changed via an NT_UPDATE_DESCRIPTION_XML notify call in the protocol \[ID_28716\]

When, in DataMiner Cube, you opened a card, in some cases, parameter information like range, step size and description could be incorrect when that information had been changed via an NT_UPDATE_DESCRIPTION_XML notify call in the protocol.

#### DataMiner Cube: Problem when opening an alarm card \[ID_28738\]

When, in DataMiner Cube, you opened an alarm card, in some cases, an exception could be thrown when the alarm duration was being calculated.

#### DM Cube Scheduler: Problem when updating scheduler events \[ID_28748\]

When, in the Scheduler app, you made changes to an event, in some cases, although those changes would be saved correctly, they would immediately seem to get reverted in the UI. Only after closing the app and re-opening it again would you see the updated event in the UI.

#### DataMiner Cube: Problem when logging in due to invalid user image data received from the domain controller \[ID_28749\]

When logging in to Cube, in some cases, an error could occur when invalid user image data was received from the domain controller.

#### DataMiner Cube - Alarm templates: Numeric baseline values would get parsed incorrectly \[ID_28750\]

When, in DataMiner Cube, you changed the baseline value of a numeric parameter, in some cases, that baseline value would get parsed incorrectly.

#### Domain groups and the users in those groups would be removed when the Active Directory server was unreachable \[ID_28758\]

When the domain server was not available, DataMiner would incorrectly remove all of the imported domain groups as well as the users in those groups.

#### Remote connections would incorrectly get removed from the local cache of a DMA when it lost its connection to another DMA \[ID_28760\]

When a DMA temporarily lost its connection to another DMA, in some cases, remote connections of other DMAs would incorrectly also get removed from its local cache.

#### DataMiner Cube - Visual Overview: An authentication popup would incorrectly appear when a browser shape with the UseChrome option set linked to a web page on the DMA \[ID_28782\]

When, in a visual overview, an embedded browser shape with the UseChrome option set linked to a web page on the DataMiner Agent, in some cases, an authentication popup would incorrectly appear.

#### Problems caused by DMS.xml containing multiple addresses referring to the same DataMiner Agent \[ID_28793\]

When a DMS.xml file contained multiple addresses referring to the same DataMiner Agent, up to now, this could lead to various problems, one of them being disconnects/reconnects of type “XXXX state has changed from XXX to XXXXX” in DataMiner Cube.

#### Invalid 'Failed to read out schedules: XML response was not in the correct format.' errors added to SLErrors.txt log file \[ID_28795\]

In some cases, a “Failed to read out schedules: XML response was not in the correct format.” error message would be added to the SLErrors.txt log file for every alarm template on the system that did not have a schedule defined.

#### Problem when a client using special SLNet connections tried to forward a request to another DataMiner Agent \[ID_28801\]

When clients using special SLNet connections tried to forward a request to another DataMiner Agent in the DataMiner System, in some cases, a “Not a DataMiner user: DOMAINNAME\\SYSTEM” exception would be thrown.

#### Start time and end time in metadata of BPA test result would be incorrect \[ID_28805\]

In the metadata of a BPA test result, you can find the start time and end time of the test. In some cases, both would incorrectly have the same timestamp and the end time would be returned in local time instead of UTC.

#### SyncInfo agent IP address file would incorrectly be updated with the current timestamp on DMA startup \[ID_28809\]

At DataMiner startup, the IP address entries in the C:\\Skyline DataMiner\\Files\\SyncInfo\\{DO_NOT_REMOVE_DC5A2A6C-4583-493C-A9CD-7AEBBF905D1E}.xml file would incorrectly be updated with the current timestamp. In some cases, this could cause IP addresses to re-appear in DMS.xml files across the DMS after starting up a stopped DataMiner Agent that still had those IP addresses listed as active.

#### Problem with SLDataMiner when loading protocols \[ID_28833\]

In some cases, an error could occur in the SLDataMiner process when loading protocols.

#### DataMiner Cube: Properties window would resize when switching to a tab that contained a custom property with a long name \[ID_28873\]

When you switched tabs in the Properties window, in some cases, the window would resize when the selected tab contained a custom property with a long name.

## Addendum CU12

### CU12 enhancements

#### SLDMS: Enhanced processing of DMS_SECURITY_NO_FORWARD messages \[ID_28796\]

Due to a number of enhancements, the way in which SLDMS processes DMS_SECURITY_NO_FORWARD messages has been optimized.

#### DataMiner Cube - Visual Overview: Unselecting a table row with the SingleSelection option enabled will now also clear the session variable \[ID_28848\]

In situations involving a table with columns that have a SelectionSetVar option configured and an embedded table control in Visual Overview with a SingleSelection option specified in its ParameterControlOptions data field, up to now, the session variable would not be updated when the selection was cleared.

From now on, the session variable will be cleared when you click the selected table row while holding down the CTRL key.

#### DataMiner Cube: SurveyorSearchText session variable will now be cleared when the advanced search tab is closed \[ID_28851\]

With the SurveyorSearchText session variable, you can configure a shape to display the most recently used search entry in the Surveyor, or to trigger a search in the Surveyor with a particular search entry.

From now on, this session variable will be cleared when the advanced search tab is closed.

#### Size of C:\\Skyline DataMiner\\Logging\\MiniDump folder limited to 1 GB or 100 files \[ID_28879\]

The size of the C:\\Skyline DataMiner\\Logging\\MiniDump folder is now limited to 1 GB or 100 files (whichever is larger).

When a new ZIP file is created when the folder size is at its limit, the oldest ZIP file(s) in the folder will automatically be deleted.

#### SLNet connections for BPA tests will no longer be logged in SLClient.txt \[ID_28890\]

From now on, by default, SLNet connections set up for BPA tests will no longer be logged in SLClient.txt.

#### Cassandra: Logging will now include health status transitions and failed queries \[ID_28913\]

Cassandra health status transitions and failed queries will now also be logged in the SLDBConnection.txt log file.

#### Sidebar: New help button to open DataMiner Dojo menu \[ID_28990\]

At the bottom of the sidebar, you can now click a help button that will open a menu containing links to the following pages on DataMiner Dojo:

| Menu command    | Page on DataMiner Dojo                                      |
|-----------------|-------------------------------------------------------------|
| Blog            | <https://community.dataminer.services/blog/>                |
| Questions       | <https://community.dataminer.services/questions/>           |
| Learning        | <https://community.dataminer.services/learning/>            |
| Resources       | <https://community.dataminer.services/documentation/>       |
| Suggest feature | <https://community.dataminer.services/feature-suggestions>  |

#### DataMiner Cube - Alarm Console: Enhanced performance when updating the source values of a Correlation base alarm \[ID_29020\]

Due to a number of enhancements, overall performance has increased when updating the source values of a Correlation base alarm.

#### Failover: Enhanced version check during synchronization \[ID_29077\]

When two agents in a Failover setup synchronize, their DataMiner versions are compared to make sure those versions are compatible. A number of enhancements have now been made to this version check.

### CU12 fixes

#### Problem when multiple network interfaces shared the same MAC address \[ID_27971\]

When multiple network interfaces shared the same MAC address, in some cases, DataMiner would not be able to correctly detect those interfaces.

#### Service & Resource Management: Exported protocol would show incorrect parameters after a new function file had been activated \[ID_28290\]

When a new function file was activated, which updated parameters for a particular function, in some cases, the exported protocol would incorrectly show the old parameters.

#### DataMiner Cube: Problem when navigating using breadcrumbs \[ID_28468\]

In some cases, the overall element state of a partially included element would incorrectly be visible in the breadcrumbs. Also, users would incorrectly be able to open the full element via the breadcrumbs, even when they did not have full access to that element.

And when they used the breadcrumbs to navigate to the element via the service child, the element would incorrectly be opened instead of the service.

#### Alarm templates: Problem when calculating the transition from one week to the next \[ID_28477\]

In some cases, an error could occur when, in the alarm template schedule, the transition from one week to the next was calculated.

#### Timetrace data would become incorrect when an element had been dynamically included in or excluded from a service \[ID_28777\]

When an element had dynamically been included in or excluded from a service while active alarms were present, in some cases, the alarm count for the service in timetrace would start to show an incorrect value.

Also, when an element was excluded from a service while it had active alarms, in some cases, SLDataGateway would incorrectly consider the alarm reference to have an impact on the service. When the alarm was cleared while the element was excluded, it would never be removed from the service alarm impact list. As a result, that list could keep growing, which would eventually lead to an overall decrease of the alarm handling performance.

#### DataMiner Cube: Element name and icon would be incorrectly be visible in the alarm card and the alarm details when you did not have explicit access to the element \[ID_28778\]

In some cases, alarms for an element that is partially included in a service would be visible in the Alarm Console even when you did not have explicit access to that element. Also, when you opened the alarm card or the alarm details of one of those alarms, the element icon, alarm state and name would be displayed.

From now on, this will no longer the case when you do not have access to the element itself. Also, you will no longer be able to an element card of an element to which you do not have explicit access.

#### DataMiner Cube - Trend templates: Problem with 'Allow offload database configuration' setting \[ID_28794\]

When, in a trend template, you changed the Allow offload database configuration setting, in some cases, the setting would not be applied correctly.

#### Problem when launching Automation scripts when switching elements in a redundancy group that contained DELT elements \[ID_28832\]

When Automation scripts were launched when switching elements in a redundancy group of which either the primary or backup elements were DELT elements, in some cases, it would not be possible to pass \<Any Primary> or \<Any backup> as dummies.

#### Element log file would not be properly restarted on element restart \[ID_28841\]

In some cases, the element log file would not be properly restarted on element restart.

#### SLNet cache would throw exceptions when receiving NULL data \[ID_28859\]

In some cases, the SLNet cache would thrown exceptions when receiving NULL data. In DataMiner, those exceptions would then appear as alarms of type error.

From now on, the SLNet cache will ignore any NULL data it receives.

#### Problem with SLAutomation when an interactive Automation script was communicating with a client app \[ID_28862\]

When an interactive Automation script was communicating with the client app, in some cases, an error could occur in SLAutomation.

#### DataMiner Cube - Interactive Automation scripts: Multiple 'Continue' messages would be sent to the DataMiner Agent \[ID_28872\]

When an interactive Automation script was running, DataMiner Cube would incorrectly send multiple identical “Continue” messages to the DataMiner Agent. In some cases, this would cause an error in SLAutomation.

#### DataMiner Cube - Visual Overview: Problem when pressing CTRL+TAB while an item inside a Visio page had the focus \[ID_28876\]

When you pressed CTRL+TAB while an item inside a Visio page had the focus, in some cases, an exception could be thrown.

#### Legacy Reporter: Service definition image in the 'Booking Details' report would exceed the width of the report \[ID_28886\]

In the legacy Reporter, the service definition image in the “Booking Details” report would exceed the width of the report. That image has now been assigned a maximum width.

#### Problem in SLElement when recalculating alarm statuses while retrieving view data \[ID_28892\]

In some cases, an error could occur in SLElement when recalculating the alarm status for virtual function impact changes while retrieving view data.

#### Failover: Problem with failing heartbeats when agents were unreachable \[ID_28900\]

When checking Failover agent connectivity through heartbeats, failures could be registered even when the heartbeats succeeded. In some cases, this could lead to “Failing Heartbeat Path” notices being toggled indefinitely.

#### Problem when a cell in a table included in a virtual function was invalidated while the state of the service that included the virtual function was being changed \[ID_28911\]

In some cases, an error could occur when a cell in a table that was included in a virtual function was invalidated while the state of the service that included the virtual function was being changed.

#### DataMiner Cube: Scheduler permissions would not include the timeline \[ID_28944\]

Up to now, the user permissions that control access to the Scheduler app would incorrectly not control access to the timeline view.

The following table lists the timeline actions users will now be allowed to perform when they have been granted a particular Scheduler user permission.

| User permission                 | Action a user is allowed to perform              |
|---------------------------------|--------------------------------------------------|
| Modules \> Scheduler \> Add     | Drop events on the timeline.                     |
| Modules \> Scheduler \> Delete  | Delete events on the timeline.                   |
| Modules \> Scheduler \> Edit    | Edit or move events on the timeline.             |
| Modules \> Scheduler \> Execute | Manually start or stop an event on the timeline. |

#### Service & Resource Management: Problem with GetEligibleResources calls \[ID_28960\]

In some cases, a GetEligibleResources call could incorrectly return resources that were not available due to a concurrency overflow.

Also, in some cases, a GetEligibleResources call would not return resources that were available because the system would incorrectly think no more capacity was available.

#### DataMiner Cube: A 'debug.log' file would incorrectly be created when initializing the CefSharp library \[ID_28963\]

In some cases, a “debug.log” file would incorrectly be created in the %LocalAppData%\\Skyline\\DataMiner\\DataMinerCube folder when the CefSharp library was initialized.

#### Problem with overall performance of SLNet connections \[ID_28976\]

In some cases, the overall performance of connections between SLNet and DataMiner clients would decrease.

#### DataMiner Cube - Alarm Console: Problem when using the history slider on systems with a Cassandra database \[ID_28982\]

When, on a system using a Cassandra database, you moved the history slider, in some cases, the HistoryAlarmRequest that was sent would contain an incorrectly converted timestamp.

#### DataMiner Cube - Alarm Console: Problem when some entries in an alarm tree matched an alarm filter while other entries did not \[ID_29011\]

When, in the same alarm tree, some entries matched an alarm filter while other entries did not, in some cases, that alarm would incorrectly not be shown.

#### Updating an element via a CSV export/import would not work properly when that element had an empty port type value \[ID_29052\]

When an element had an empty port type value, in some cases, trying to edit that element by exporting its data to a CSV file and then importing the updated CSV file would not work as expected.

#### Problem when assigning an alarm template group to a DVE element \[ID_29063\]

When you assigned an alarm template group to a DVE element, no alarms would be generated.

#### ProtocolThread run-time error could occur when an element with a serial connection was paused \[ID_29083\]

In some cases, a ProtocolThread run-time error could occur when an element with a serial connection was paused.

#### Memory leak in SLXml when registered objects were removed \[ID_29091\]

In some cases, the SLXml process could leak memory when registered objects were removed.

#### DataMiner Cube - Alarm Console: Incorrect alarm count when loading a history tab with an element filter while some alarms in the time range were still active \[ID_29106\]

When you loaded a history tab with an element filter while some of the alarms in the selected time range were still active, in some cases, the tab header would show an incorrect alarm count.

#### Failover: LDAP notification setting would incorrectly be ignored when synchronizing DataMiner.xml \[ID_29117\]

In a Failover setup, in some cases, the notification attribute of the LDAP element would incorrectly be ignored when synchronizing the DataMiner.xml file between the two Failover agents.

#### SLAutomation: Problem when clearing the internal parameter cache \[ID_29165\]

In some cases, an error could occur in SLAutomation when its internal parameter cache was being cleared.

## Addendum CU13

### CU13 enhancements

#### Schedule configuration of BPA tests \[ID_29000\]

On the *Agents* > *BPA* page in System Center, you can now schedule when a BPA test should run. In the drop-down box in the *Schedule* column, you can select to run a test at different intervals, e.g. daily or every 12 hours.

#### Enhanced performance when assigning alarm templates with conditions used in multiple rules \[ID_29109\]

Due to a number of enhancements, overall performance has increased when assigning an alarm template to an element, especially when that alarm template contains conditions that are used in multiple rules.

#### SLLogCollector tool can now be accessed via the DataMiner Taskbar Utility \[ID_29154\]

You can now open the SLLogCollector tool by selecting *Launch \> Tools \> SLLog Collector* in the DataMiner TaskBar Utility.

#### DataMiner Cube: Warning message will now appear when you duplicate an SNMPv3 element from another DMA \[ID_29192\]

When you duplicate an SNMPv3 element from a DMA other than the one to which you are connected, from now on, a message box will appear, saying that you have to re-enter the SNMPv3 credentials for the newly created element.

> [!NOTE]
> No such message will be displayed when using either a credential library or the NoAuthNoPriv security level.

#### Enhanced loading and initializing of alarm templates \[ID_29236\]

A number of enhancements have been made with regard to the loading and initializing of alarm templates.

#### '!! No link found for xxx\[xx\] -> xxxx' errors will now be logged in SLErrorsInProtocol.txt instead of SLErrors.txt \[ID_29264\]

Up to now, when a “!! No link found for xxx\[xx\] -> xxxx” error was generated by SLElement, that error would be logged in SLErrors.txt. From now on, this type of errors will be logged in SLErrorsInProtocol.txt instead.

#### SLElement: Enhanced error handling \[ID_29270\]

A number of enhancements have been made to the error handling in SLElement.

#### DataMiner Cube: Filter box in Documents app & Documents card pages \[ID_29298\]

In the *Documents* app and the *Documents* card pages, a filter box now allows you to filter the list of documents.

#### Enhancements to prevent 'Messages have gone lost, making the connection invalid' errors from being thrown \[ID_29304\]

A number of enhancements have been made to prevent “Messages have gone lost, making the connection invalid” errors from being thrown.

#### DataMiner Cube: Enhancement made to 'Skyline Black' theme \[ID_29370\]

A number of enhancements have been made to the “Skyline Black” theme, especially with regard to readability in the *Database* section of *System Center*.

#### 'Saving report...' entry will no longer be added to SLWatchdog.txt when a Watchdog report has successfully been saved \[ID_29379\]

From now on, when a Watchdog report has successfully been saved, no “Saving report...” entry will be added to the SLWatchdog.txt log file anymore.

#### Enhanced performance of file synchronization operations \[ID_29401\]

When the internal file change repository of the SLDMS process reached a considerable size, up to now, overall performance of the file synchronization operations would decline.

Due to a number of enhancements, overall performance of the file synchronization operations has now been optimized.

### CU13 fixes

#### DataMiner Cube: 'Migrate booking data to Indexing Engine' button would still be displayed after the booking data had already been migrated \[ID_28813\]

In DataMiner Cube, clicking the *Migrate booking data to Indexing Engine* button starts a wizard that allows you to migrate booking data from the Cassandra database to the Indexing database. In some cases, this button would incorrectly still be displayed after the booking data had already been migrated.

#### DataMiner Cube - Visual Overview: Element shapes would incorrectly not inherit the service context of their parent element shape \[ID_28867\]

Up to now, an element shape that was a child of another element shape would not inherit the service context of its parent.

From now on, an element shape that is a child of another element shape will inherit the service context of its parent when it does not have a service context of its own.

#### DataMiner Cube: Linked alarm tab would not show all alarms after all cards had been closed & no context menu when right-clicking an app in the Cube header search box \[ID_28893\]

When you closed all cards while a linked alarm tab was open in the Alarm Console, that linked alarm tab would not show all alarms. Instead, it would incorrectly keep the last card you closed as a filter.

Also, when you searched for an app using the search box in the Cube header, right-clicking the app in the search results would not open its context menu.

#### Dashboards app: Multiple parameter feeds in PDF reports would incorrectly also show all selected parameter indices \[ID_28978\]

When you generated a PDF report with the options “No grouping” and “Include feeds” enabled, in some cases, multiple parameter feeds would not only show the selected parameters, but incorrectly also all selected parameter indices.

#### DataMiner Cube - Automation: Discarding a newly created script would not delete it \[ID_29032\]

When you discarded a newly created Automation script, in some cases, it would incorrectly not be deleted although it had disappeared from the UI. As a result, trying to create a new script with the same name would fail.

#### No trigger keys listed when debugging a QAction due to a compatibility issue between DataMiner and DataMiner Integration Studio \[ID_29049\]

Due to a compatibility issue between DataMiner and DataMiner Integration Studio, in some cases, when debugging a QAction, the *Trigger key* box in the *DIS Inject* window would incorrectly not list any trigger keys.

#### SNMPAgent: Engine ID and engine boots counter of local agent would incorrectly be cleared when the users were cleared \[ID_29081\]

Up now on, when an SNMP agent cleared the users during the re-initialization of the SNMP forwarding, the engine ID and the engine boots counter of the local agent would incorrectly be cleared as well. From now on, when an SNMP agents clears the users, it will ignore the engine ID and engine boots counter of the local agent.

#### SLNet.txt log file would contain irrelevant log entries \[ID_29120\]

From now on, the following irrelevant entries will no longer be added to the SLNet.txt log file:

```txt
DmaConnections|Unexpected filter type: SubscriptionFilter\`2
```

```txt
Unexpected filter type: Skyline.DataMiner.Net.SubscriptionFilters.SubscriptionFilter\`2[XXXX,XXXXXX]
```

#### UDP smart-serial server would receive an empty package each time a new client started sending data to it \[ID_29166\]

When multiple clients were sending data to a smart-serial UDP server, that server would incorrectly receive an empty package each time a new client started sending data.

#### DataMiner Cube - EPM: No longer possible to unmask items in a topology diagram or alarms in the Alarm Console \[ID_29173\]

In an EPM environment, in some cases, it would no longer be possible to manually unmask items in a topology diagram or alarms in the Alarm Console.

#### DataMiner Cube: Table columns with a width set to 0 in the protocol would incorrectly be visible \[ID_29196\]

In DataMiner Cube, in some cases, table columns of which the width was set to 0 in the protocol would incorrectly be visible.

#### Problem in SLNet could cause DataMiner to restart \[ID_29229\]

In some rare cases, an error occurring in SLNet could cause DataMiner to restart.

#### DataMiner Cube: Problem when exporting tables to function DVE protocols \[ID_29266\]

When a table is exported to a function DVE protocol, some of the columns can optionally be left out. In some cases, especially when the omitted columns appeared before the primary key or display key columns, DataMiner Cube would interpret the data incorrectly.

#### DataMiner Cube - System Center: Incorrect counter values on Agents \> BPA page \[ID_29271\]

In *System Center*, on the *Agents \> BPA* page, in some cases, the displayed counters would show incorrect values.

#### Problem at DataMiner startup due to an invalid loop in the view hierarchy \[ID_29307\]

On DataMiner startup, in some cases, an error could occur when an invalid loop was found in the view hierarchy. From now on, when an invalid view loop is found, an error mentioning the incorrectly configured views will be logged.

#### Problem with SLDataMiner when an element was stopped \[ID_29327\]

In some cases, an error could occur in SLDataMiner when an element was stopped.

#### DataMiner Cube - Alarm Console: Correlation sources would no longer be updated \[ID_29330\]

When one of the sources of a correlation alarm (group) was updated, in some cases, the update would not be reflected in the Alarm Console. When you opened the correlation alarm (group), the previous alarm source would incorrectly still be shown.

#### Dashboards app: Web components would not load HTTPS-only websites when the Dashboards app was being used with HTTP \[ID_29352\]

When the Dashboards app is being used with HTTP instead of HTTPS (which is not recommended), then it also loads all web component URLs using HTTP, even when they are configured to use HTTPS. As a result, up to now, websites only accessible using HTTPS could not be loaded.

From now on, it will also be possible to load websites only accessible using HTTPS when the Dashboards app is being used with HTTP.

#### Legacy Reporter app: Status query report with table parameters exported to a CSV file would contain tables within table cells \[ID_29355\]

When, in the legacy Reporter app, you generated a report containing a status query with a number of table parameters and exported it to a CSV file, full tables would end up in status query cells.

From now on, when you export a status query report containing table parameters to a CSV file, the data in the table parameters will be exported to separate CSV files as before, but it will no longer appear inside status query cells.

#### Using an NT_EDIT_PROPERTY (62) call to update an alarm property of a DVE element would fail when no element ID was specified \[ID_29358\]

When an alarm property of a DVE element was updated using a SetDataMinerInfoMessage of type 62 (NotifyType.EditProperty) without specifying the element ID, the request would fail with an “element is unknown” error.

#### Dashboards app - CPE feed: Selection box contained too much data \[ID_29377\]

Due to incorrect filtering, in some cases, the selection box in the CPE feed would contain too much data.

#### DataMiner Cube: Problem when selecting a value from a drop-down parameter in a custom context menu of a table \[ID_29383\]

If a parameter of type “drop-down” in a custom context menu of a table retrieved its values from a dependency parameter, in some cases, the first time a value was selected, the selection would not be applied.

#### Legacy Reporter: Status query would no longer show alarm colors \[ID_29516\]

In the legacy Reporter app, in some cases, the status query would no longer show alarm colors.

## Addendum CU14

### CU14 enhancements

#### Client machines running Cube now require Microsoft .NET Framework v4.6.2 \[ID_25309\]

Client machines running DataMiner Cube now require Microsoft .NET Framework 4.6.2.

#### DataMiner Cube - Visual Overview: Viewport and Navigate variables of a Resource Manager timeline will now be read and applied upon opening \[ID_29299\]

When, in Visual Overview, you create a shape that should display the Resource Manager timeline by adding a shape data field of type Component set to “Reservations” or “Bookings”, the Navigate and Viewport session variables allow you to control navigation and zooming within the timeline.

- The Navigate variable can be used to automatically navigate to a specified time range.
- The Viewport variable can be used to zoom to a specified time range and to visualize the time range to which you zoomed manually.

From now on, both variables can be processed immediately upon opening a visual overview with a Resource Manager timeline.

- Setting the Navigate variable using a page-level InitVar will make the timeline navigate immediately to the chosen time slot and clear the Navigate variable.
- The Viewport variable will always be read upon opening the Resource Manager timeline. In other words, if a session variable already exists in the scope in question (e.g. when the time line was opened while using the global variable scope), the timeline will automatically zoom to the last-known view port.

> [!NOTE]
> The Navigate variable will be processed after the Viewport variable.

#### Mobile apps - Visual Overview: Linking shapes to webpages \[ID_29444\]

When you link a shape to a webpage using a shape data field of type *Link*, that page will be opened each time a user clicks that shape. This feature will now also work on visual overviews in mobile apps (e.g. Dashboards, Monitoring, etc.).

#### Enhancements made to the method that decides which subscriptions to forward to other agents in the DMS \[ID_29490\]

A number of enhancements have been made to the method that decides which subscriptions to forward to other agents in the DMS. These enhancements will considerably reduce SLNet CPE usage, especially on systems with a large number of active subscriptions.

#### Visual Overview: New option to keep real-time charts from showing exception values in labels \[ID_29504\]

In the *ParametersOptions* shape data field for a parameter chart showing real-time values, you can now use the *VisualizeExceptions=false* option to keep the display value for exception values from being shown in a label.

| Shape data field  | Value                                                                     |
|-------------------|---------------------------------------------------------------------------|
| ParametersOptions | VisualizeExceptions=true (default behavior)<br> VisualizeExceptions=false |

#### Notice will now appear in the Alarm Console when the initial synchronization of a DMA fails \[ID_29532\]

When, after adding a DMA to the DataMiner System, the initial synchronization of that agent fails, a notice will now appear in the Alarm Console.

Also, a number of protective measures have been added to prevent an agent that has not yet completed its full synchronization from being synchronized at midnight.

#### DVE elements notifications no longer added to SLNetCOM Notification Stack \[ID_29601\]

On DataMiner startup and hourly at report generation, a batch of notifications gets forwarded between DataMiner modules, ending up on the SLNetCOM Notification Stack. Up to now, two such notifications were also forwarded for every DVE element. These will now no longer be sent.

#### SLNetCom notification thread will now only start ignoring messages after a grace period has passed \[ID_29631\]

When the SLNetCom notification thread reaches a certain threshold (defined by MaxStackSLNetCOMNotifications), the DMA assumes something is wrong and stops processing messages, requiring a restart. However, in some cases, this threshold can be reached even when nothing is wrong.

In order to prevent this, a grace period has now been introduced. When the number of SLNetCom notification messages reaches a peak, the DMA will only start ignoring messages when the number of messages on the stack is equal or greater than the threshold during the entire grace period.

Using the SLNetClientTest tool, you can specify this grace period by configuring the SLNetCOMNotificationsStackExceedsThresholdGracePeriodInMin setting (default value: 1 minute).

#### DataMiner Cube - Element Connections app: Mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized \[ID_29653\]

Due to a number of enhancements made to the Element Connections app, the mechanism used to delete connections between a destination parameter and a non-virtual source parameter has been optimized.

### CU14 fixes

#### Problem with SLManagedScripting due to a locking issue \[ID_26139\]

In some rare cases, threads could get stuck in SLScripting due to a locking issue.

#### Alarm filter combining element and table column filter not working for history alarms tab \[ID_26797\]

If a history alarms tab was filtered using an element filter combined with a table column filter, it could occur that no alarms were displayed.

#### Problem when retrieving protocol-level TTL settings from the database \[ID_28023\]

When writing trend data to the database, in some cases, protocol-level TTL settings could not be retrieved. From now on, when TTL settings cannot be retrieved from the database, additional information will be added to the logs.

#### DataMiner Cube - Visual Overview: DCF connections of hidden shapes would incorrectly still be visible \[ID_28930\]

Up to now, DCF connections of shapes that were hidden because of a condition would incorrectly still be visible. From now on, any connection that is linked to a shape that is hidden will no longer be displayed.

Also, hidden shapes will no longer be taken into account when grouping shapes.

#### DataMiner Cube - Visual Overview: IDOfSelection session variable would not get updated when selected rows were removed or the selection was cleared in a ListView component \[ID_29057\]

When you select one or more rows in a ListView component, the IDs or GUIDs of the selected items are stored in the IdOfSelection session variable.

Up to now, when a selected row was removed or when the selection was cleared in any way, in some cases, the contents of the IdOfSelection session variable would not get updated.

#### DataMiner Cube - Resources app: Capacity parameter values would incorrectly be stored without decimals \[ID_29082\]

Up to now, in the Resources app, capacity parameter values would incorrectly be stored without decimals.

#### DataMiner Cube - Trending: Extra data point would incorrectly be exported to CSV \[ID_29212\]

When you exported average trend data to a CSV file, in some cases, extra data points would incorrectly be added to the exported trend data.

#### Protocols: Problem with SLProtocol when the save attribute of a table parameter was incorrectly set to “true” \[ID_29214\]

When, in a protocol.xml file, the save attribute of a table parameter was incorrectly set to “true”, in some rare cases, an error could occur in SLProtocol.

#### At DMA startup, NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT would incorrectly be called before all elements were fully loaded \[ID_29257\]

When a DataMiner Agent was started in a DataMiner System, in some cases, errors would be logged due to NT_CLEAN_SUBSCRIPTION_FOR_STOPPED_ELEMENT being called before all element were fully loaded.

#### Data would not get written to the backup agent after configuring a Failover setup on a system with MySQL databases \[ID_29267\]

When a Failover setup is configured on two DataMiner Agents with a MySQL database, after synchronizing the two databases, all new data should be written to both these databases. However, in some cases, new data would incorrectly not be written to the backup agent until after the primary agent had been restarted.

#### Automation: UIBuilder properties MaxWidth and MaxHeight would incorrectly not get applied to interactive Automation script pop-up windows \[ID_29361\]

In some cases, the UIBuilder properties “MaxWidth” and “MaxHeight” would incorrectly not get applied to interactive Automation script pop-up windows.

#### Dashboards app: Input boxes would extend beyond the borders of the screen \[ID_29406\]

When configuring certain components, a number of input boxes would not resize correctly. Instead, they would extend beyond the borders of the screen.

#### SLAnalytics: Problem when retrieving data from DVE elements \[ID_29464\]

Due to a problem when retrieving data from DVE elements, in some cases, trend prediction and pattern matching would not work for this type of elements.

#### DataMiner Cube - EPM: Children of the siblings of the selected object would incorrectly also be displayed \[ID_29465\]

Up to now, when the *ShowSiblings* option was combined with the *ShowChildren* option, the children of the siblings of the selected object would incorrectly also be displayed. From now on, only the children of the selected object will be displayed.

#### DataMiner Cube - Alarm Console: Problem when clicking the 'Alarm storm' button \[ID_29472\]

If alarm storm protection by delaying is activated, during an alarm storm you can click the red *Alarm storm* button in the alarm bar to open a new card with a list of the delayed alarms.

In some cases, when you clicked that button, an exception would be thrown and no alarms would be displayed.

#### Legacy Dashboards app - Trend component: Custom range values would be ignored when the time range of the chart was updated \[ID_29480\]

In the legacy Dashboards app, the “Custom low range” and “Custom high range” options of the Trend component would incorrectly be ignored whenever the time range of the chart was updated.

#### SLLogCollector would incorrectly not take a dump when the temp folder did not exist \[ID_29500\]

In some cases, SLLogCollector would incorrectly not take a dump when the temp folder did not exist.

#### DMA that was incorrectly cleaned after having been removed from a DMS would skip its initial synchronization when added to another DMS later on \[ID_29523\]

When a DataMiner Agent had been removed from the DataMiner System and was cleaned up incorrectly afterwards (e.g. by manually updating the DMS.xml file), in some cases, it would skip its initial synchronization when it was added to another DataMiner System later on.

#### Problem with SLASPConnection when processing the results of a GetAlarmHistory call \[ID_29525\]

In some cases, an error could occur in SLASPConnection when processing the results of a GetAlarmHistory call.

#### DataMiner Cube - Alarm Console: Blue footer bar had an incorrect dark blue color \[ID_29529\]

In some cases, the blue footer bar of the Alarm Console would have an incorrect dark blue color.

#### Baseline of standalone parameter would incorrectly be cleared when its condition had first been evaluated as true and then as false \[ID_29531\]

When relative or absolute monitoring was enabled on a standalone parameter of which the condition had first been evaluated as true and then as false, in some cases, the baseline of the parameter would incorrectly be cleared.

#### Problem with SLElement at DataMiner startup \[ID_29539\]

At DataMiner startup, in some rare cases, an error could occur in SLElement.

#### Service & Resource Management: Problem loading functions.xml files \[ID_29551\]

When the first attempt to load a functions.xml file would fail, in some cases, no further attempts would incorrectly be made.

#### DataMiner Cube - Embedded Chromium web browser engine: Problems with scaling \[ID_29596\]

In some cases, the following problems could occur with regard to Chromium web browser controls:

- When opened in a window on a high-DPI monitor, they would be scaled twice and the image would not match the mouse cursor.
- When displayed in a window that was moved from one monitor to another, they would not adapt to the new DPI scale.
- When displayed on a high-DPI monitor, they were rendered at 100% DPI and then upscaled, resulting in an imperfect image.

#### SLNetComNotificationThread: Delay between notifications \[ID_29599\]

In SLNet, up to now, the SLNetComNotificationThread had a delay of 15 ms between notifica-tions. In cases where a large number of notifications had to be processed, the total delay could be significant.

#### Incorrect in-memory state in SLDMS when removing an agent from a DMS \[ID_29612\]

When a DMA was removed from a DataMiner System, in some cases, the memory of the SLDMS process would be left in an incorrect state.

This could prevent actions like initial synchronization from working when setting up a new DMS or a new Failover environment that included the agent in question.

#### Elasticsearch: Problem when trying to create a customdata object \[ID_29617\]

When a customdata object had to be created in an Elasticsearch database, in some rare cases, multiple DMAs in the DMS would try to create the same table. This would cause an exception to be thrown on some of those DMAs.

#### DataMiner Cube - Data Display: Problem with dynamic parameter ranges \[ID_29625\]

When a protocol updated parameter ranges using an NT_UPDATE_DESCRIPTION_XML call, in some cases, the ranges could be reverted to an old value, especially when the PageUnloadOnNavigatingAway option was enabled or when the ranges belonged to parameters located on pages that had not yet been visited.

#### Problem with SLSNMPAgent \[ID_29629\]

In some cases, an error could occur in SLSNMPAgent when dealing with issues caused by not being able to fetch XML cookies from SLDataMiner.

#### Problem in SLDataMiner when reloading virtual functions \[ID_29641\]

In some cases, an error could occur in SLDataMiner when a functions.xml file was reloaded.

#### DataMiner Cube - Element Connections: Duplicated non-virtual parameters would be added twice when they referred to a destination parameter \[ID_29645\]

In the Element Connections app, in some cases, duplicated non-virtual parameters would be added twice when they referred to a destination parameter.

#### Dashboards app - Line chart component: Zero values would incorrectly be exported to CSV as null values \[ID_29660\]

When trend data was exported to a CSV file, in some cases, zero values would incorrectly be exported as null values.

#### DataMiner Cube - Spectrum Analysis: Start, stop and center frequencies incorrectly displayed without decimals \[ID_29661\]

When you opened a Spectrum element card, in some rare cases, the start, stop and center frequencies would incorrectly be displayed without decimals.

#### DataMiner Cube: No views visible in the Surveyor after clicking the 'Start' button on the message box saying that the agent was not running \[ID_29665\]

When you opened DataMiner Cube and clicked Start on the message box saying that the agent was not running, the agent would start up but, in some cases, no views would be visible in the Surveyor.

#### Problem when restarting a DMA without stopping SLNet \[ID_29667\]

When you restarted a DataMiner Agent without stopping SLNet, in some rare cases, an exception could be thrown.

#### DMS Alerter would start to consume an excessive amount a memory when configured to play a sound when the alarm in the pop-up matched a filter \[ID_29672\]

When you had configured Alerter to play a sound when the alarm displayed in the pop-up balloon matched a filter, in some cases, Alerter would start to consume an excessive amount a memory.

## Addendum CU15

### CU15 enhancements

#### Standalone Elastic Backup tool will now have to be used to restore a backup of an Elasticsearch database \[ID_29677\]

When you take a backup of a DataMiner Agent, you can opt to also take a backup of its Elasticsearch database. However, as the latter will in most cases be a cluster, automatically restoring an Elasticsearch backup when restoring a DataMiner Agent is not advisable.

From now on, even when a DataMiner backup includes an Elasticsearch backup, the latter will not be automatically restored when the DataMiner backup is restored. Restoring an Elasticsearch backup will now have to be done using the Standalone Elastic Backup tool.

For more information on the Standalone Elastic Backup tool, see [Standalone Elastic Backup Tool](https://community.dataminer.services/documentation/standalone-elastic-backup-tool/) on DataMiner Dojo.

#### SLWatchdog: Notification enhancements \[ID_29697\]

A number of enhancements have been made with regard to notifications generated by the SLWatchDog process.

#### DataMiner Cube: 'Not applicable' replaced by 'N/A' when displaying alarm statistics while the alarm storm protection mode is active \[ID_29771\]

When, in Visual Overview or the Surveyor, alarm statistics were displayed while the alarm storm protection mode was active, up to now, the number of alarms would be replaced by “Not applicable”. From now on, the number of alarms will be replaced by “N/A” instead of “Not applicable”.

#### Inter-DMA communication: Enhanced automatic HTTP port detection \[ID_29834\]

Up to now, when port 80 (HTTP) was unavailable between DataMiner Agents, connections between the DataMiner Agent modules on the different servers would only work after the ConnectTimeout setting had been increased. From now on, when auto-detecting the target port (via port 80 or 443) fails, the connection attempt will continue on default port 8004.

Also, a number of additional options were added to the connection string configuration (SLNetClientTest \> Advanced \> Edit Connection Strings):

- The “To” field can now contain wildcards (\* or ?). If there is no exact match, the settings of the record in question will then apply to all matching destinations. If more than one wildcard entry matches a destination, the behavior is undefined.

- The connection string can now be set to “auto://nodetect” in order to skip the auto-detection of the target SLNet port and automatically default to 8004. When port 80 is blocked between agents, the 15-second autodetection timeout will then be skipped.

#### DataMiner Cube - Bookings app: Enhanced performance of the bookings timeline \[ID_29876\]

Due to a number of enhancements, overall performance of the bookings timeline has been increased.

#### LogCollector: Enhanced handling of long file paths \[ID_29910\]

When, during the creation of a dump file, SLLogCollector encountered a file of which the path was longer than 256 characters, up to now, an error would be thrown and the entire dump operation would fail. From now on, when SLLogCollector encounters a file of which the path was longer than 256 characters, it will exclude that file, and continue creating the dump file.

Also, when in the registry of a Windows 10 version 1607 or above the LongPathsEnabled option is set to 1 in Computer\\HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Control\\FileSystem, SLLogCollector will now accept file paths that are longer than 256 characters.

#### SLManagedAutomation: Locking mechanism will now prevent exceptions from being thrown when reading or writing items in the dummies collection \[ID_29930\]

In an Automation script, every Engine object contains a collection of “dummies”. Each of these dummies represents an element and can be used to interact with that element. When an Automation script wants to interact with an element that is not yet available in the dummies collection, a new dummy is created.

Up to now, exceptions could be thrown when multiple threads were trying to read or write items in the dummies collection. Now, a locking mechanism has been added to prevent multiple threads from interfering with each other while accessing the dummies collection.

#### SLSNMPManager: Enhanced logging \[ID_29935\]

In order to determine the root causes of certain SNMP-related issues, the SLSNMPManager error logging has been enhanced.

This enhanced logging will especially be helpful when investigating the “Unable to set the destination IP” error.

#### SLElement: Enhanced memory usage when processing service impact data \[ID_29948\]

Due to a number of enhancements, overall memory usage of SLElement has increased, especially when processing service impact data.

Also, a small memory leak was fixed in elements contained within services.

#### New BPA tests added to default test set \[ID_30010\]

The following new BPA tests have been added to the default test set:

- Minimum Requirements Check
- Report Active RTE
- View Recursion

### CU15 fixes

#### Service & Resource Management: Problem when trying to retrieve a resource with status 'Maintenance' or 'Unavailable' \[ID_29511\]

Due to a serialization issue involving the AvailableTo and AvailableFrom properties of the GetResourceMessage, in some cases, it would not be possible to retrieve a resource with status “Maintenance” or “Unavailable”.

#### DataMiner Cube - Surveyor: Newly created elements located in multiple views would incorrectly only appear in one of those views \[ID_29544\]

When you created a new element located in multiple views, in some rare cases, it would incorrectly only appear in one of those views. Only when you reconnected Cube would the element be displayed in all views in which it was located.

#### DataMiner Cube - Trending: Color icons missing from trend graph legend \[ID_29718\]

When you opened a trend group with several graphs, in some rare cases, color icons would be missing from the trend graph legend.

#### Manually clearing a clearable alarm on a single-value parameter would incorrectly set the alarm state of the parameter to 'undefined' instead of 'normal' \[ID_29745\]

When you manually cleared a clearable alarm on a single-value parameter, the alarm state of the parameter would incorrectly be set to “undefined” instead of “normal”.

#### DataMiner.xml: \<NetworkAdapters> tag not correctly applied when a network adapter did not have a current IP address assigned \[ID_29759\]

In the DataMiner.xml file, you can use the \<NetworkAdapters> tag to override the order of the network adapters on a DataMiner Agent.

Up to now, when one of the adapters had an IP address defined in the Windows Registry but had no current IP address assigned, in some cases, an incorrect order could get applied in DataMiner.

#### SLSpectrum would no longer properly clean up client connections \[ID_29769\]

In some cases, the SLSpectrum process would no longer properly clean up client connections. As a result, its overall performance would decrease each time a client had made a connection.

#### DataMiner Cube - Alarm templates: Problem with overlapping time frames when the end time of a schedule entry was set to midnight \[ID_29772\]

When configuring schedules in alarm templates, in some cases, entries could have overlapping time frames, especially when the end time of one of those entries was set to midnight.

#### DataMiner Cube - Visual Overview: Field and FieldID placeholders could not be used by a Visio file assigned to a view enhanced with EPM data \[ID_29790\]

When a view was enhanced with EPM data and had a Visio file assigned to it, in some cases, the Visio file assigned to that view would not be able to use the Field and FieldID placeholders.

#### DataMiner Cube: Problem when pressing the Back button during logon \[ID_29808\]

When you pressed the Back button while logging on, in some cases, an error could occur in the logon screen, forcing you to restart Cube.

#### Monitoring app: Service child popup pages without parent page could not be opened \[ID_29816\]

When, for an element included in a service, only parameters from one of its popup pages were included and none of that popup page’s parent page, then that parent page would not be included in the service and there would be no way to access the popup page. From now on, in cases like this one, popup pages of service children will be added to the Monitoring app’s side panel after all other pages.

#### Legacy Reporter app: Problem when trying to display a trend graph for a table column parameter \[ID_29818\]

When the legacy Reporter app had to display a trend graph for a table column parameter, in some cases, a “no trend graph is available” message would incorrectly appear instead, especially when that table column parameter had both average and real-time trending enabled on certain rows.

#### DataMiner Cube: Problem with SLSpectrum when closing a spectrum element card \[ID_29824\]

In some cases, an error could occur in SLSpectrum when you closed a spectrum element card.

#### Not all references to child elements were removed from the original DMA after a DELT migration of main DVE elements \[ID_29831\]

After a DELT migration of main DVE elements from one DMA to another, in some cases, not all references to the child elements would be removed from the original DMA.

#### DataMiner Cube - Visual Overview: Problem when opening a visual overview that contained a filtered table \[ID_29846\]

In some cases, DataMiner could become unresponsive when you opened a visual overview that contained a filtered table.

#### Masking monitored column parameters that were not in an alarm state would not cause them to get marked as being masked \[ID_29871\]

When you masked a monitored column parameter that was not in an alarm state, it would incorrectly not get marked as being masked.

#### SLAnalytics: Memory spikes when requesting trend predictions \[ID_29925\]\[ID_29983\]

In some cases, large memory spikes would occur in the SLAnalytics process when requesting trend predictions for parameters with a small polling interval that did not receive regular (non-exception) parameter value updates in the real-time trend data history.

#### Failover: Problem with SLNet during DataMiner startup \[ID_29950\]

On a Failover system, in some rare cases, an error could occur in SLNet during DataMiner startup, causing the following run-time error in SLDMS:

```txt
THREAD PROBLEM : SLDMS.exe - ConnectionThread [pid 99999 - thread 99999]
```

#### DataMiner Cube - Bookings app: Memory leak in bookings list \[ID_30048\]

When an item was removed from the bookings list, it could occur that the item was not removed from memory.

#### Problem when masking DVE elements containing table parameters \[ID_30084\]

When an element is masked, DataMiner will mask all parameters of that element. Table parameters will be masked as a whole, meaning that column parameters will not be masked individually. However, in case of DVE elements, a column parameter can be exported as a separate, standalone DVE parameter. So, here, a column parameter can be masked individually as the rest of the table is not part of the DVE element.

Up to now, when an entire table had been exported to a DVE element, and that DVE element was masked, then DataMiner would incorrectly mask the table as a whole as well as each column individually, leading to double masking.

From now on, when an entire table was exported to a DVE element, the column parameters will no longer be masked individually. The default table masking procedure will be applied.

## Addendum CU16

### CU16 enhancements

#### Security enhancements \[ID_29980\] \[ID_30012\] \[ID_30195\]

A number of security enhancements have been made.

#### Enhanced handling of stack overflow exceptions \[ID_29796\]

A number of enhancements have been made to better handle stack overflow exceptions.

#### Smart-serial client connections: Logging incoming data \[ID_29874\]

When a smart-serial client connection receives incoming data, it will forward that data to SLProtocol and display it in Stream Viewer. However, when the incoming data does not match the configured response, the connection will forward TIMEOUT to SLProtocol, making it hard to find out what data was received by SLPort.

From now on, if you enable a specific connection in PortLog.txt (see DataMiner Help) and set SLPort debug logging to level 4 or higher, log entries like the one below will be added to SLPort.txt. These entries contain the IP address and port of the server, the size of the incoming data and the data itself.

```txt
2021/05/14 15:30:57.452|SLPort.exe 8.5.1519.6|39680|39544|CSmartIP::ProcessIncomming|DBG|4|Incoming data from 127.0.0.2:4598 (total length: 5 bytes) -    000000  576F72642E                                   Word.
```

#### SLUpgrade can now run BPA tests before starting the upgrade process \[ID_29903\]

When a DataMiner upgrade package contains a set of BPA tests in its Prerequisites folder, SLUpgrade will now run those tests before starting the upgrade process. Upon failure of one or more of these tests, the upgrade process will be aborted and a message will be displayed.

The BPA tests run before the start of an upgrade process will generally be tests designed to check whether the system meets the requirements necessary to upgrade to the new DataMiner version.

BPA tests added to the Prerequisites folder of a DataMiner upgrade package must comply to the following rules:

- They must have their CanRunOnOfflineAgents flag enabled. This will make sure that, in a Failover setup, the offline agent will also be checked.
- They must have their RequireSLNet flag disabled.

#### Enhanced performance when exporting function protocols \[ID_29929\]

When you uploaded a new version of a protocol that had an active functions file, up to now, all active function elements would be re-evaluated after the function protocols were exported. From now on, the function elements will only be re-evaluated when the function file is set to active.

#### Enhanced logging of parameter update stack notices \[ID_29996\]

Up to now, when the number of items on the parameter update stack was divisible by 1000 after an item had been added to it, a log entry would be added to the log file of the element for which that last item had been added. As a result, parameter update stack notices would be scattered among different log files.

From now on, when the parameter update stack exceeds 5000 items, log entries will be added to the log files of all elements for which there are items on the stack. Also, similar log entries will be added to the same log files each time the number of items on the stack is divisible by 1000 until the number of items on the stack drops below 1000.

#### DataMiner backup packages will now also include the SoftLaunchOptions.xml file \[ID_30076\]

From now on, DataMiner backup packages will also include the SoftLaunchOptions.xml file.

#### Enhanced performance when updating user information \[ID_30102\]

Due to a number of enhancements, overall performance has increased when updating user information, especially on systems with a large number of users.

#### DataMiner Cube: 'DataMiner Cube mobile' changed to 'DataMiner web apps' \[ID_30201\]

Throughout the Cube UI, the term “DataMiner Cube mobile” has been replaced by the term “DataMiner web apps”.

#### Service & Resource Management: ReservationInstance will again be marked as interrupted when created with a start time before the Resource Manager was initialized \[ID_30211\]

Since DataMiner version 10.0.0 CU11/10.1.3, when a ReservationInstance was created with a start time in the past, before the Resource Manager was initialized, that ReservationInstance would no longer be marked as interrupted. From now on, when a ReservationInstance is created with a start time in the past, before the Resource Manager was initialized, that ReservationInstance will again be marked as interrupted.

#### DataMiner Cube - Data Display: Service cards now also support conditional page visibility \[ID_30217\]

In a protocol.xml file, it is possible to specify that a Data Display page should either be shown or hidden based on a parameter value. Service cards now also support this feature.

#### BPA test 'Report Active RTE' will now run more frequently \[ID_30250\]

The BPA test “Report Active RTE” will now run once every 8 minutes instead of once every hour.

#### Updated BPA tests: 'Minimum Requirements Check' & 'View Recursion' \[ID_30259\]

The following default BPA tests were updated:

- Minimum Requirement Checker: Name changed to “Minimum Requirements Check”
- View Recursion: Description updated

### CU16 fixes

#### DMS Alerter: Problem when closing Alerter while balloons are popping up \[ID_29725\]

In some cases, an exception could be thrown when you closed Alerter while balloons were popping up.

#### SLDataMiner: High-level log entries would incorrectly not get added to the log after increasing the log level \[ID_29781\]

When you increased the log level of SLDataMiner, high-level log entries would incorrectly not get added to the log.

#### DataMiner Cube - Visual Overview: Problem with SelectionSetVar option \[ID_29797\]

When, in Visual Overview, a table control had the SelectionSetVar option specified, in some cases, it would not be possible to select a row.

#### Cassandra: 'tried to execute null statement' errors incorrectly added to SLDBConnection.txt log file \[ID_29947\]

On systems with a Cassandra database, errors similar to the one below would incorrectly be added to the SLDBConnection.txt log file:

```txt
[timestamp]|SLDBConnection.txt|SLDBConnection|SLDBConnection|ERR|0|335|Cassandra: tried to execute null statement.
```

#### DataMiner Cube - Visual Overview: Problem when using the FollowPathColor option \[ID_29959\]

In some cases, using the FollowPathColor option would cause Cube to become unresponsive.

#### Dashboards app - Group component: Visualizations would incorrectly be removed when opening the Layout tab \[ID_29962\]

When you opened the Layout tab of a Group component, in some cases, the visualizations will incorrectly be removed.

#### Problem when changing a protocol that had a production version \[ID_29966\]

When you changed a protocol that had a production version, in some rare cases, elements could receive an incorrect XML cookie, causing the following error to appear in the Alarm Console. Also, the elements in question would be prevented from starting up properly.

```txt
Initializing the protocol for X failed. The XML module is not initialized. (hr = 0x80040216)
```

#### Data offloading would incorrectly be disabled when saving the settings of the offload database \[ID_29985\]

When, in DataMiner Cube, you saved the settings of the offload database, the settings for offloading the real-time trend data would not be applied correctly. As a result, offloading would be disabled until the DataMiner Agent was restarted.

#### Part of SLNet initialization could be skipped when a client disconnected while the DMA was starting up \[ID_29986\]

When a client disconnected while the DMA was starting up, in some rare cases, part of the initialization of the SLNet process could get skipped, which would lead to issues later on. Up to now, the error would only be added to the logs. From now on, in cases like this, the following will happen:

- When a client cannot be re-registered during the SLNet initialization, an entry will be added to the logs, but the initialization will no longer fail.

- Any exception thrown during the SLNet initialization will now also show up in the Alarm Console as “Unexpected Exception \[Initialize DMA\]: xxxxxx”

#### Stopping an SLA would cause a 'window change' event that would lead to outages being closed when history set alarms were received \[ID_29998\]

When an SLA is stopped while it has an open outage, the open outage will be closed with a timestamp containing the time at which the SLA was stopped. This ensures that all outages are closed in case the SLA starts again when no impacting alarms are present to open and later close the outage.

However, this event would be logged as a “window change”, causing the SLA to close and reevaluate the current alarms at the time the SLA was stopped whenever a history set alarm was received with a timestamp earlier than the time at which the SLA was stopped. This would then cause extra non-intended outages.

#### Synchronization of a cleared DMS.xml file would incorrectly cause all agents to remove themselves from the DataMiner System \[ID_30023\] \[ID_30163\]

When a DataMiner Agent is starting up, it checks whether the DMS.xml file was changed while it was down. If changes are found, these are then synchronized among the other agents in the DataMiner System. However, up to now, when the DMS.xml file had been cleared and only contained either the IP address of the DataMiner Agent that was starting up or the name of the DataMiner System, this would incorrectly cause a cascade of delete operations throughout the DataMiner System, resulting in all the agents slowly removing themselves from the DataMiner System.

Also, when an outdated cluster configuration was left on a standalone DataMiner Agent after manually removing the DMS.xml file or after restoring a DataMiner backup, other agents in the DataMiner System could be triggered to leave the DataMiner System once the standalone agent was re-added to the cluster.

#### Failover: Network interface would not properly release the virtual IP address when being re-attached after being disconnected during a Failover switch \[ID_30033\]

When a network interface was disconnected or disabled during a Failover switch, in some cases, it would not properly release the virtual IP address when it was re-attached.

#### InstanceAlarmLevel would not fall back to CellActualAlarmLevel when there was bubble-up information but no instance information \[ID_30044\]

In case of a view table with bubble-up information and view columns with alarm information, up to now, the InstanceAlarmLevel property on the primary key cell would incorrectly be set to “Undefined” instead of the highest severity of those columns.

#### DataMiner Cube - Alarm Console: Problem when reconnecting after adding the 'Severity Duration' column \[ID_30099\]

When, in the Alarm Console, you added the Severity Duration column and then reconnected, on a large DataMiner System, Cube could become unresponsive.

#### Problem with SLNet during upgrade \[ID_30103\]

During a DataMiner upgrade, in some rare cases, a problem could occur in the cleanup connection thread of SLNet.

#### BPA tests could fail with a 'BPA has an invalid signature' error \[ID_30118\]

On DataMiner Agents on which the latest Windows updates had not been installed, in some cases, BPA tests would fail with the following error:

```txt
BPA has an invalid signature
```

Also, the following entry would be added to the SLBpaManager.txt log file at DataMiner startup:

```txt
Ignoring certificate SkylineCodeSigning.cer: Certificate is not trusted by the machine
```

From now on, BPA tests that are signed with the Skyline code signing certificate will be forcefully loaded, and the following entry will be added to the SLBpaManager.txt log file:

```txt
Force loaded certificate: SkylineCodeSigning.cer (Skyline Certificate). WARNING! Machine might not have latest Windows Updates.
```

#### SNMPv1/SNMPv2 element could remain in a timeout state after its IP address had been first set to a non-existing address and then to its original address \[ID_30123\]

When you change the IP address of an SNMPv1 or SNMPv2 element that is polled using a “dynamic IP” parameter to a non-existing address, the element will go into timeout as it tries to poll that non-existing IP address. However, up to now, when you then changed the IP address back to the one the element had before, it would incorrectly remain in timeout until it was restarted.

Also, from now on, when an SNMP-related failure occurs, the log entry will include the error code. Where previously a log entry like “Unable to set destination port” would be added, DataMiner will now add a log entry like “Unable to set destination port (error code: 3)”.

#### DataMiner Cube - Backup: Users without 'Backup \> Configure' permission would incorrectly be allowed to update the 'Indexing Engine location' backup path \[ID_30131\]

In the *Backup* section of *System Center*, users without *Modules \> System configuration \> Backup \> Configure* permission would incorrectly be allowed to update the *Indexing Engine location* backup path.

#### DataMiner Cube - Scheduler: Users with permission to add tasks but not to edit them would not be able to save a newly created task \[ID_30132\]

When, in the Scheduler app, users created a new scheduled task, they were not able to save that task when they had permission to add tasks but not to edit them.

#### DataMiner Cube - Users/Groups: Duplicate activity log entries \[ID_30162\]

When, in the *Users/groups* section of *System Center*, you opened a user card and selected the *Activity* tab, in some cases, the list would contain duplicate activity log entries.

#### DataMiner Cube - Visual Overview: Button to navigate to another card would no longer work after clicking the Back button \[ID_30167\]

When, on a visual overview, you clicked a button to navigate to another card and then clicked the Back button, in some cases, clicking the button to navigate to another card a second time would no longer open that other card.

#### SLLogCollector: Problem when process list update took longer than 1 second \[ID_30203\]

When SLLogCollector updated its list of processes, it would incorrectly try to update it again when the update took longer than 1 second.

## Addendum CU17

### CU17 enhancements

#### Security enhancements \[ID_30200\] \[ID_30323\] \[ID_30362\] \[ID_30363\] \[ID_30417\] \[ID_30422\] \[ID_30561\]

A number of security enhancements have been made.

#### DataMiner Cube - Trending: Enhanced input and validation of trend graph Y axis settings \[ID_30176\]

When you right-click on a trend graph and select “Y axis settings”, you can change the minimum and maximum Y-axis value for each numeric axis. A number of enhancements have now been made with regard to how these values are entered and validated.

#### Service & Resource Management: No longer possible to create a resource with invalid capacities and/or capabilities \[ID_30207\]

From now on, it will no longer be possible to add a resource with invalid capacities and/or capabilities.

- When you try to add a resource with “NULL” instead of a Capacity or with a Capacity of which the value is set to “NULL”, an error with reason ResourceCapacityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

  - ResourceId: The ID of the resource.
  - ResourceCapacity: The capacity object that did not reference a correct capacity profile.

- When you try to add a resource with “NULL” instead of a Capability or with a Capability of which the value is set to “NULL” and IsTimeDynamic set to FALSE, an error with reason ResourceCapabalityInvalid will be added to the TraceData. The error’s ResourceManagerErrorData will contain the following properties:

  - ResourceId: The ID of the resource.
  - ResourceCapability: The capability object that did not reference a correct capability profile.

#### Enhanced performance when creating function resources \[ID_30248\]

Due to a number of enhancements, overall performance has increased when creating function resources.

#### SLElement: Enhanced performance when processing table request filters \[ID_30262\]

Due to a number of enhancements, overall performance of SLElement has increased when processing table request filters.

#### SLElement: Enhanced performance when managing virtual elements \[ID_30274\]

Due to a number of enhancements with regard to the caching of key links, overall performance of the SLElement process has increased when managing virtual elements.

#### Enhanced performance when including/excluding elements in services based on parameter values \[ID_30284\]

Due to a number of enhancements, overall performance has increased when including/excluding elements in/from services based on parameter values, especially when the same parameter is used in a large number of element inclusion conditions.

#### http://[dma]/root/tools/ page now allows you to install SECTIGO certificate \[ID_30297\]

DataMiner Cube files are now signed with a SECTIGO certificate.

You can install that certificate by clicking a hyperlink in the *DataMiner tools* section of the `http://[dma]/root/tools/` page.

#### SLElement: Enhanced performance when starting up elements \[ID_30315\] \[ID_30316\]

Due to a number of enhancements, overall performance of SLElement has increased when starting up elements, especially DVE elements and elements with a large number of foreign keys, virtual functions, etc.

#### Enhanced performance due to improved locking mechanism \[ID_30328\]

Due to a number of enhancements to the internal locking mechanism, overall performance of all DataMiner processes has increased.

#### SLElement: Enhanced performance when resolving foreign keys \[ID_30348\] \[ID_30426\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving foreign keys, especially when dealing with replicated elements.

#### SLNet will now notify SLWatchdog when it has updated VersionHistory.txt \[ID_30366\]

When the SLWatchdog process is started, it checks the VersionHistory.txt file to find out the DataMiner version running on the DataMiner Agent in question. The VersionHistory.txt file, located in the C:\\Skyline DataMiner\\Upgrades\\ folder of a DataMiner Agent, lists all the major upgrades that have been performed on that DataMiner Agent, each with the date at which the DataMiner Agent was first started after that particular upgrade.

Up to now, when SLNet updated the DataMiner version in VersionHistory.txt while SLWatchdog was running, the latter would not be aware of that change until it was restarted. From now on, SLNet will notify SLWatchdog when it has updated VersionHistory.txt.

#### DataMiner Cube: Links to deprecated DCP platform replaced by links to the new https://dataminer.services platform \[ID_30430\]

Throughout the Cube UI, all links to the deprecated DataMiner Collaboration Platform have been replaced by links to the new <https://dataminer.services> platform.

#### DataMiner Cube - Data Display: Memory consumption of tables showing service impact has been reduced \[ID_30433\]

Due to a number of enhancements, overall memory consumption of tables showing service impact has been reduced.

#### SLElement: Enhanced performance when processing updates in tables with foreign key columns \[ID_30434\]

Due to a number of enhancements, overall performance of SLElement has increased when processing updates in tables with foreign key columns.

#### DataMiner upgrade packages will now include StandAloneBpaExecutor \[ID_30438\]

The StandAloneBpaExecutor tool will now by default be included in DataMiner upgrade packages.

#### DVE elements and virtual functions will start faster when their main element is restarted \[ID_30457\]

Due to a number of enhancements, DVE elements and virtual functions will start faster when their main element is restarted.

#### Enhanced performance when stopping elements that are in a timeout state \[ID_30462\]

Due to a number of enhancements, overall performance has increased when stopping elements that are in a timeout state.

#### No longer possible to save TicketFieldDescriptor with characters that are not supported in Elasticsearch \[ID_30625\]

It is now no longer possible to save a TicketFieldDescriptor with a name that contains characters that are not supported in Elasticsearch (i.e. “\_” in initial position, as well as ".", "#", "\*", "," and double or single quotation marks).

When you do try to do so in a script, an exception will be returned. When you try to save a ticket field name in the Ticketing UI containing one of these characters, an error message will be displayed with more information about the characters that are not supported.

### CU17 fixes

#### Problems when initializing scheduled alarm templates \[ID_29783\] \[ID_30365\]

In some cases, an alarm template group that was either unassigned or assigned to a stopped element would not get updated when the schedule of one of the alarm templates in that group was enabled or disabled.

Also, when an alarm template schedule was started, in some cases, either the active state of that schedule or the entire schedule itself would be set incorrectly.

- When an alarm template with a schedule was edited while, according to its schedule, it was inactive, the following would happen:

  - The template would temporarily be activated, causing alarms to be created which would immediately be cleared.
  - When no active window was scheduled that day, the first window of the upcoming days would be used for that day.

- When an alarm template with a schedule was assigned to an element while, according to its schedule, it was inactive, it would be activated until the first window had passed.

- When an alarm template schedule contained an overlapping window because DataMiner Cube did not detect the incorrect configuration, the overlap would not get corrected and the schedule would get activated at random times.

- When an alarm template with a schedule was updated on a DMA that was part of a DataMiner System, elements running on other DMAs in that DataMiner System would not apply the new schedule until the DMA on which the template was updated was restarted or until another alarm template update occurred on that DMA.

NT_ADD_FILE (99) has now been adapted in order to better handle alarm template changes. When NT_ADD_FILE is called and the templateDetails variable (object 2) specifies the type as “1” (alarm template), then the protocolDetails variable (object 1) will optionally receive a fourth string value: “364” (NT_INITIALIZE_SCHEDULE) or “378” (NT_CLEAR_SCHEDULE). This will specifies how the template's schedule should be reloaded in the memory of SLDataMiner.

> [!NOTE]
> When no fourth string value is passed along, it will by default be set to NT_INITIALIZE_SCHEDULE as it is capable of handling a template without a schedule.

#### DataMiner Cube - Alarm templates: Hysteresis could incorrectly be applied to 'low' severity levels for parameters of type string \[ID_30117\]

When applying hysteresis to specific alarm severity level for parameters of type string, up to now, it would incorrectly be possible to do so for “low” severity levels. From now on, for parameters of type string, it will only be possible to apply hysteresis to “high” severity levels.

> [!NOTE]
> If, for a string parameter, Hysteresis is set to “On” or “Off”, then the High and Low levels must be consistent. Both should either be enabled or disabled.

#### DataMiner Cube - Scheduler: Tasks with a type other than 'Once' would incorrectly allow you to enter a date and a time in the start date box \[ID_30140\]

When you configure a scheduled task with a type other than “Once”, you can specify a start date and an end date. Up to now, the start date box would allow you to enter a date and a time. As this is not relevant, from now on, the start date box will only allow you to enter a date.

#### DataMiner Cube - Cassandra: Information events would not have the correct properties \[ID_30178\]

When you opened an information event on a DataMiner Cube connected to a system with a Cassandra database, in some cases, that information event would not have the correct properties. The problem was due to the properties being stored incorrectly into the database.

#### Problem with SLElement when the hysteresis timer was activated when an element was restarted \[ID_30212\]

In some rare cases, an error could occur in SLElement when the hysteresis timer was activated at the moment when an element was restarted.

#### CPU usage of SLASPConnection would surge after a service update \[ID_30242\]

On systems with a large number of services, in some cases, the CPU usage of the SLASPConnection process would temporarily surge after a service had been updated.

#### DataMiner Cube - Surveyor: Newly created element would be displayed twice after being updated \[ID_30258\]

When a newly created element was in multiple views, and at least two of these views had been opened in the Surveyor, in some cases, the element would incorrectly be displayed twice in the same view after being updated.

#### DataMiner Cube - Visual Overview: Problem when the parent shape of a shape with an embedded Chromium web browser control had a show/hide condition configured \[ID_30270\]

In some rare cases, an exception could occur when, in a visual overview, the parent shape of a shape with an embedded Chromium web browser control had a show/hide condition configured.

#### Problem with SLElement when changing an alarm template of a DVE element that contained references to general parameters in conditional monitoring rules \[ID_30277\]

When a DVE element had its alarm template updated, was assigned a new alarm template or went to “not monitored”, in some cases, an access violation error could occur in SLElement when the alarm template contained references to general parameters in conditional monitoring rules.

#### DataMiner Cube - Services app: Same connection could incorrectly be drawn twice in diagram \[ID_30291\]

When drawing connections between nodes in a service definition diagram, in some cases, it would incorrectly be possible to draw the same connection twice.

#### Cassandra cluster: Problems with cluster health monitoring & data offloads \[ID_30310\]

In some cases, an incorrect consistency level and replication factor would be used when assessing the health of the Cassandra cluster.

Also, a problem could occur when offloading data to a file.

#### DataMiner Cube - Alarm Console: Sources of correlated alarms would incorrectly not be removed from the Alarm Console \[ID_30311\]

In some rare cases, the sources of a correlated alarm would incorrectly not be removed from the Alarm Console.

#### BPA tests: Version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version \[ID_30312\]

A BPA test can only be executed if it has been digitally signed by Skyline, and if your DataMiner version is within the limitations of the minimum and/or maximum DataMiner version configured in the test (if any). However, up to now, the version compatibility test would fail when a BPA test was run on a Feature Release version instead of a Main Release version.

The version compatibility test has now been adapted:

- When no minimum and/or maximum DataMiner version is specified, the BPA test will run regardless of the version.
- When a minimum and/or maximum DataMiner version is specified, the BPA test will run when the DataMiner Agent has

  - a Main Release version greater than the minimum Main Release version and smaller than or equal to the maximum Main Release version, or
  - a Feature Release version greater than the minimum Feature Release version and smaller than or equal to the maximum Feature Release version, or
  - a Release version of which the Main Release on which it is based is greater than the minimum Feature Release version and smaller or equal to the maximum Feature Release version.

#### SLNet would fail to initialize when external authentication via SAML was configured incorrectly \[ID_30318\]

When external authentication via SAML was configured incorrectly, up to now, SLNet would fail to initialize. From now on, a “Failed to build External Authentication for SAML” notice will be generated instead and SLNet will continue its initialization routine.

#### SLAnalytics: 'Division by zero' error when encountering an invalid polling time in legacy parameterInfo records \[ID_30321\]

In some cases, a “division by zero” error could occur in SLAnalytics when encountering an invalid polling time in legacy parameterInfo records.

#### DataMiner Cube - Alarm Console: Submenu of Copy command not shown in right-click menu \[ID_30334\]

When, in the Alarm Console, you selected all alarms with element name “DMA” and then right-clicked to open the shortcut menu, the submenu of the “Copy” command would incorrectly not be shown.

#### DVE elements / Virtual functions: Alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed \[ID_30336\]

In some cases, alarms in tables would not get re-evaluated when foreign keys linking those tables to other tables had changed.

#### Problem with SLDataMiner \[ID_30359\]

In some cases, the SLDataMiner process could become unresponsive due to a problem with its element locking mechanism.

#### EPM: All clients would incorrectly receive view updates when one view was enhanced \[ID_30412\]

When, in an EPM environment, you enhanced a view on a particular DataMiner Agent in the DMS, all clients connected to any of the other DataMiner Agents in the DMS would incorrectly receive updates for all of the enhanced views in the system.

#### Legacy Reports & Dashboards - Alarm List: History alarms with missing ‘Hosting DataMiner ID’ & GetAlarmTreeDetailsMessage not working for imported elements \[ID_30415\]

When, in the legacy Reports & Dashboards app, the Alarm List component requested the alarm tree details, all history alarms would incorrectly have a hosting DataMiner ID equal to -1 and using the GetAlarmTreeDetailsMessage with Hosting DataMiner ID and Root Alarm ID did not work for elements imported by means of a DELT package.

#### Failover: SLASPConnection would be unaware of the local DMA ID \[ID_30416\]

On a Failover setup, part of the SLASPConnection process would be unaware of the local DataMiner ID. In some cases, this could lead to “Handle Notifications Thread” errors.

#### Security: Problems when adding domain users and domain groups \[ID_30428\]

In some cases, a problem could occur when adding a domain user or a domain group to DataMiner.

#### DataMiner Cube: Problem when opening a service \[ID_30471\]

In DataMiner Cube, in some cases, a stack overflow exception could be thrown when you opened a service.

#### Incorrect exceptions thrown when installing a DataMiner upgrade package \[ID_30516\]

When you install a DataMiner upgrade package, a number of checks are performed before the upgrade is started. In some cases, one of those checks would throw incorrect ZipExceptions.

#### DataMiner Cube - Tab layout: Clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question \[ID_30541\]

When in tab layout, clicking e.g. an element multiple times would incorrectly each time open a new instance of the card in question.

> [!NOTE]
> When, on a visual overview, you click a button to navigate to another card and then click the *Back* button, in some cases, clicking the button to navigate to another card a second time may no longer open that other card.

#### Legacy Reporter app - Bookings component: Not possible to select properties \[ID_30547\]

When, in the legacy Reporter app, you had created a report template with a booking component of which the type was set to “list”, in some cases, it would not be possible to select properties to be included in the report.

#### DataMiner Cube - Data Display: Table cells would not contain their current value when in edit mode \[ID_30553\]

In some cases, when you had changed a value in a table cell, and then clicked inside that same cell to change the value again, the cell would not contain the current value. Instead, it would contain the value it contained before the first change.

#### DataMiner Cube - Service & Resource Management: Missing icons in service definitions \[ID_30619\]

In some cases, icons could be missing in service definitions because SVG content could not be loaded.

## Addendum CU18

### CU18 enhancements

#### Improved performance when including/excluding elements in services based on alarm or element alarm state \[ID_30303\]

Performance has improved when elements are dynamically included or excluded in a service based on alarm state or element alarm state.

#### Security enhancements \[ID_30479\] \[ID_30570\] \[ID_30597\] \[ID_30600\] \[ID_30604\] \[ID_30786\]

A number of security enhancements have been made.

#### Service & Resource Management: Interface state calculation for virtual function interfaces disabled \[ID_30537\]

As the interfaces of virtual functions are generated from a table that cannot be monitored, the interface state calculation for these interfaces is now disabled. This may result in improved performance.

#### Service & Resource Management: Improved performance when processing virtual functions \[ID_30585\]

A number of enhancements have been implemented to improve performance when processing virtual functions.

#### SLElement: Enhanced performance when looking up linked rows after a foreign key has changed \[ID_30747\]

Due to a number of enhancements, overall performance of SLElement has increased when looking up linked rows after a foreign key has changed.

### CU18 fixes

#### Slow initial synchronization of services in DMS \[ID_30074\]

In some cases, it could occur that the initial synchronization of services in a DMS was slow because of unnecessary errors generated in the SLDMS process. Usually, an error similar to the following was logged:

```txt
2021/06/03 01:00:00.302|SLDMS.txt|SLDMS.exe 10.1.2118.668|13524|26072|CSystem::ResolveServicePaths|ERR|-1|Failed resolving hosting DMA info for 10.10.80.20 and service RT_ServiceCreationDelete_66_2021_06_03_00_58
```

#### Problem with conditional monitoring after alarm template update \[ID_30531\]

When an alarm template was refreshed in the SLElement process, e.g. because the alarm template was modified or the baseline changed, it could occur that conditional monitoring was ignored for standalone parameters. Because of this, if a parameter was not monitored because the condition for this was met, it was shown as monitored regardless.

#### Automation: CheckboxList and RadiobuttonList not decoding backslash correctly \[ID_30605\]

In an interactive Automation script, it could occur that the *CheckboxList* and *RadiobuttonList* components did not correctly decode a backslash ("\\") character.

#### Information about running elements missing in SLProtocol logging \[ID_30612\]

Since DataMiner 9.6.0/9.6.1, information about running elements could be missing in the SLProtocol logging.

#### DataMiner Cube - Spectrum Analysis: Problem when retrieved client session data contained duplicate keys \[ID_30644\]

When you open a spectrum analyzer element in Cube, it will retrieve all client sessions of that spectrum element. Up to now, when the retrieved client session data contained duplicate keys, an exception could be thrown. From now on, a log entry will be generated instead.

#### GetAlarmFilterResponse and GetTrendFilterResponse messages caused protocol buffer serialization errors \[ID_30650\]

In some cases, it could occur that the *GetAlarmFilterResponse* and *GetTrendFilterResponse* messages failed to be serialized even though these were marked as eligible for protocol buffer serialization. An error similar to the following could be displayed in the Cube logging:

```txt
Message : Index was outside the bounds of the array.
Exception : (Code: 0x80131508) Skyline.DataMiner.Net.Exceptions.DataMinerException: Index was outside the bounds of the array. ---> System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.Collections.Generic.List\`1.Add(T item)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.Log(String method, String text)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.ProtoBufPackMessage(DMSMessage rawMessage)
```

The scenarios where these messages cannot be serialized will now be handled better, so that they can no longer cause errors. In addition, to make it easier to troubleshoot errors with protocol buffer serialization, a new *SLProtobufSerialization.txt* log file is now available.

#### CRC parameter with LengthType 'fixed' and RawType 'other', 'text' or 'numeric text' would incorrectly always be set to 0x20 or 0x30 \[ID_30730\]

When a CRC parameter with LengthType “fixed” and RawType “other”, “text” or “numeric text” was used in a command, it would incorrectly always be set to 0x20 characters for parameter of type “string” or 0x30 characters for parameters of type “double”.

#### Problem with SLDataMiner when using alarm templates with a monitoring schedule \[ID_30732\]

In some cases, an error could occur in SLDataMiner when alarm templates with a monitoring schedule were being used.

#### Problem with SLDataMiner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded \[ID_30743\]

In some cases, an error could occur in SLDataMIner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded.

#### SLAnalytics: Problem when retrieving data at startup \[ID_30744\]

In some cases, an error could occur when SLAnalytics retrieved data from the database at startup.

#### DataMiner Cube - Visual Overview: Cube could become unresponsive while retrieving service states \[ID_30762\]

When a visual overview with at least one service shape was open when you opened a Cube, and the initial service states had not yet been received, in some cases, Cube could become unresponsive while retrieving the service states.

#### DataMiner Cube: Problem when hovering the mouse pointer over an alarm storm warning \[ID_30799\]

When, during an alarm storm, you hovered the mouse pointer over the alarm storm warning, in some cases, an exception could be thrown.

#### DataMiner Cube - Alarm Console: Comments containing a new line would be displayed incorrectly \[ID_30801\]

When an alarm contains one or more comments, you can right-click it and select “View comments” to see all comments in the alarm tree in question. In that list, up to now, comments containing a new line would not be displayed correctly.

## Addendum CU19

### CU19 enhancements

#### SLLogCollector: Command line support \[ID_26293\]

The SLLogCollector tool now supports the following command line options:

| Option             | Function                                                                                         |
|--------------------|--------------------------------------------------------------------------------------------------|
| -c, --console      | Use the SLLogCollector console.                                                                  |
| -h, -?, --help     | List syntax and available options.                                                               |
| -f, --folder=VALUE | Specify the folder in which the zipped log files will be stored. Default: C:\\Skyline_Data\\ |
| -d, --dumps=VALUE  | Specify the comma-separated list of processes from which dumps should be taken (IDs or names).   |
| -m, --memory=VALUE | Take an extra dump as soon as the process uses the specified amount of memory (in MB).           |

#### StandAloneBPAExecutor: New command line option to save test result to file \[ID_27776\]

The StandAloneBpaExecutor tool, which can be found in the C:\\Skyline DataMiner\\Tools folder of a DMA, can be used to execute BPA (Best Practice Analysis) tests.

When using this tool to run a test from a command line, it is now possible to have the test result stored in a JSON file.

| Option                                                      | Function                                                   |
|-------------------------------------------------------------|------------------------------------------------------------|
| -f “PATH/TO/FILE.json”<br> or<br> -file “PATH/TO/FILE.json” | Specify the file in which the test results will be stored. |

#### Security enhancements \[ID_30494\]

A number of security enhancements have been made.

#### No longer possible to launch a system-wide upgrade procedure when one agent fails to upload the upgrade package \[ID_30511\]

Up to now, when an agent in a DataMiner System failed to upload a DataMiner upgrade package, it would still be possible to launch the system-wide upgrade procedure. From now on, as soon as one of the agents in a DataMiner System fails to upload an upgrade package, it will not be possible to launch a system-wide upgrade procedure.

#### SLElement: Enhanced service impact calculation \[ID_30648\]

A number of enhancements have been made to the way in which SLElement calculates the service impact of an alarm.

#### Enhanced performance when enabling virtual functions with monitored parent elements \[ID_30673\]

Due to a number of enhancements, overall performance has increased when enabling virtual functions with monitored parent elements.

#### Enhanced performance when determining the virtual impact of an alarm \[ID_30766\]

Overall performance has increased when determining the virtual function impact of an alarm.

Also, a number of issues have been fixed with regard to displaying statuses of virtual function alarms, exporting alarms to DVE child elements, masking of external alarms and updating virtual function states when alarms are cleared.

#### DataMiner Cube - Alarm Console: Availability of 'Count alarms' button now depends on the alarm filter that was specified \[ID_30810\]

When, in the Alarm Console, you add a new history or sliding window tab page, you can add a filter by clicking *Apply filter*. After configuring that filter, you can click *Count alarms* to see how many alarms will be retrieved when that filter is applied. However, up to now, when the filter contained one of the following items, it would not be possible to count the number of alarms that matched the filter:

- ElementType
- InterfaceImpact
- ParameterDescription
- Protocol
- ServiceImpact
- ViewID
- ViewImpact
- ViewName
- VirtualFunctionID
- VirtualFunctionImpact
- VirtualFunctionName

From now on, when the alarm filter contains one of the above-mentioned items, the *Count alarms* button will not be available.

#### Web Services API v1: SetParameter and SetParameterRow methods can now also be used to update parameters of enhanced services \[ID_30823\]

The SetParameter and SetParameterRow methods of the DataMiner Web Services API v1 can now also be used to update parameters of enhanced services.

#### DataMiner Cube - Aggregation: Enhanced performance \[ID_30917\]

Due to a number of enhancements, overall performance of the Aggregation module has increased.

#### SLDataGateway: Enhanced startup routine \[ID_30934\]

A number of enhancements will now allow the SLDataGateway process to handle Cassandra exceptions and file offload initialization errors more efficiently, which may prevent startup issues.

#### DataMiner Cube - System Center: Enhanced 'Limited administrator' tooltip \[ID_31042\]

When, in the *Users/Groups* section of *System Center*, you hover over the *Modules \> System configuration \> Security \> Specific \> Limited administrator* permission, a tooltip gives you more information about that permission. That tooltip now contains the following updated text:

```txt
* Read-only access on all groups * Read-only access to users in your groups * Create new DataMiner users * Editing your own user properties
```

### CU19 fixes

#### Dashboards app - Node edge graphs: Parameter values in node tooltips would incorrectly show 'not initialized' \[ID_30694\]

When you hovered over a node, parameter values shown in the node tooltip would incorrectly be set to “not initialized”.

#### Elasticsearch installations would fail on systems on which Cassandra was installed remotely \[ID_30731\]

On systems on which Cassandra was installed remotely, in some cases, Elasticsearch installations would fail.

#### Service & Resource Management: Protocols generated for contributing services could cause errors to occur in SLScripting \[ID_30772\]

In some cases, protocols generated for contributing services could cause errors to occur in SLScripting.

#### DataMiner Cube - Settings: User group settings not taken into account when applying regional settings \[ID_30813\]

When starting up, up to now, Cube would load the regional settings before loading the user group settings. As a result, it would only take into account the user settings when applying the regional settings. From now on, Cube will also take into account the user group settings when applying the regional settings.

#### SLSNMPManager: Problem when using MultipleGetBulk to poll a table containing only a single row \[ID_30815\]

When MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm would get stuck into an infinite loop.

#### DataMiner Cube - Visual Overview: Child shapes representing alarms would incorrectly appear on a white background \[ID_30820\]

When generating child shapes that represent alarms, up to now, those child shapes would always appear on a white background, even when the Cube theme was set to e.g. Skyline Black.

From now on, generated child shapes that represent alarms will appear on a transparent background instead.

#### Confusing 'Already authenticated error' would be thrown when an error occurred during an authentication process \[ID_30827\]

When an error occurred during an authentication process, in some cases, a confusing “Already authenticated” exception would be thrown instead of the actual error message. From now on, the actual error message will be thrown.

#### DataMiner Cube: Alarm counter in alarm storm warning did incorrectly not decrease when alarms were cleared \[ID_30836\]

When, during an alarm storm, you hover the mouse pointer over the alarm storm warning, a tooltip appears, showing you which alarms are causing the storm and the number of alarms per parameter. Up to now, when one of those alarms got cleared, the number of alarms shown in the tooltip would incorrectly not decrease.

#### Compiled QAction DLL files would incorrectly not be deleted from the ProtocolScripts folder when a protocol was deleted \[ID_30841\]

When a protocol was deleted, up to now, the compiled QAction DLL files would incorrectly not get deleted from the C:\\Skyline DataMiner\\ProtocolScripts folder.

#### SLElement: ParameterThread error \[ID_30855\]

In some cases, a ParameterThread error could occur in SLElement.

#### DataMiner Cube - Visual Overview: No longer possible to display aggregated parameter values in shapes \[ID_30864\]

In Visual Overview, it was no longer possible to display aggregated parameter values in shapes by specifying either the DMA and element ID of an aggregation element or an \[AggregationRule:...\] placeholder in a shape data field of type Aggregation.

#### Interactive Automation scripts: Value returned by the client would incorrectly be considered as an invalid file path selected in a file selector block \[ID_30879\]

When, in an interactive Automation script, a file selector block was defined after another type of input block (e.g. a checkbox), in some cases, the input block value returned by the client would incorrectly be considered as an invalid file path selected in the file selector. As a result, an “Invalid Data” error would be thrown.

#### DataMiner Cube - Alarm Console: Incorrect notices like '!! Unknown \<Type> R!AD for parameter xxx' \[ID_30884\]

In some rare cases, notices like “!! Unknown \<Type> RE!D for parameter 123” would incorrectly appear in the Alarm Console.

#### Protocols: QActions and their compiled versions could get linked incorrectly \[ID_30896\]

In some rare cases, errors occurring in SLScripting or SLProtocol could cause QActions and their compiled versions to be linked incorrectly.

#### Problem when disabling a virtual function and then enabling it again \[ID_30918\]

When you disabled a virtual function and then enabled it again, in some rare cases, it would incorrectly disappear from the system.

#### Problem with SLDataMiner when deleting a service or a redundancy group \[ID_30925\]

In some cases, an error could occur in SLDataMiner when a service or a redundancy group was deleted.

#### Automation: Problem with ScriptEntry.GetHashCode method \[ID_30939\]

In some cases, calling the ScriptEntry.GetHashCode method could cause a NullReference-Exception to be thrown.

#### Problem with SLAutomation when a Timespan.MaxValue timeout had been defined \[ID_30946\]

In some cases, SLAutomation would throw an ArgumentOutOfRangeException when a Timespan.MaxValue timeout had been defined.

#### Legacy Reporter: Problem with SLASPConnection when requesting trend statistics \[ID_30966\]

In some cases, an error could occur in SLASPConnection when requesting trend statistics (Minimum/Maximum/Average).

#### Alarms in tables that were part of multiple relation paths for different DVEs would not get re-evaluated when a DVE was created \[ID_30979\]

In some cases, an alarm in a table that was part of multiple relation paths would not get re-evaluated when a DVE in one of those paths exported that alarm. As a result, the alarm would not get exported to the DVE child element, causing the element state to become incorrect.

#### DVE element information would no longer be written to the database \[ID_31004\]

In some cases, DVE element information would no longer be written to the database due to a NullReferenceException in SLDBConnection.

#### DataMiner Cube: Asset Manager app failed to initialize \[ID_31072\]

In some cases, the Asset Manager app would fail to initialize.

#### Run-time errors in ParameterThread when defining a column parameter in the functions.xml \[ID_31074\]

In some cases, run-time errors could occur in the ParameterThread when defining a column parameter in the functions.xml.

#### Web Services API v1: Port details missing from result of GetElementConfiguration method \[ID_31075\]

In some cases, the result of a GetElementConfiguration method would be missing port details.

#### Table row exports for DVEs and virtual functions would trigger updates to be sent when no client applications were connected \[ID_31156\]

In some cases, table row exports for DVEs and virtual functions would trigger updates to be sent, even when no client applications were connected.

## Addendum CU20

### CU20 enhancements

#### Security enhancements \[ID_31122\]

A number of security enhancements have been made.

#### Restoring a DataMiner backup package will no longer be possible when the package was created on a system with a different DataMiner version \[ID_30921\]

From now on, it will no longer be possible to restore a DataMiner backup package on a system with a DataMiner version that is different from the one on which the backup was taken.

#### DataMiner upgrade: All agents in the DataMiner System must now meet the requirements before an upgrade of the entire DataMiner System can proceed \[ID_31002\]

When you start an upgrade of an entire DataMiner System, from now on, all agents in that DataMiner System will be checked to determine if they meet the requirements specified in the upgrade package. If one of the agents does not meet the requirements, the entire upgrade will be aborted.

> [!NOTE]
> This check is performed when you upload an upgrade package. When, in DataMiner Cube, you select *Upload only*, the uploaded upgrade package will be marked “Failed” when the requirements are not met.

#### SLLogCollector: Option 'Upload to Skyline' removed \[ID_31032\]

Up to now, when an internet connection was available on the DMA, the SLLogCollector tool provided an option to upload the collected information to Skyline via email. This “Upload to Skyline” option has now been removed.

#### DataMiner Cube - Data Display: Enhanced performance when opening an element with a tree control parameter \[ID_31099\]

Due to a number of enhancements, overall performance of DataMiner Cube has increased when opening an element with a tree control parameter.

#### Minor enhancements to several DataMiner processes \[ID_31155\]

A number of minor enhancements have been made to a number of DataMiner processes (e.g. SLXml, SLWatchdog, SLDMS, SLASPConnection and SLNet).

#### DataMiner Cube - Update Center: Enhanced error handling \[ID_31191\]

A number of enhancements have been made with regard to error handling and the rendering of error messages in Update Center.

#### DataMiner Cube - Visual Overview: Chromium web browser engine now supports find and zoom functionality \[ID_31232\]

The Chromium web browser engine now support find and zoom functionalities.

Available shortcuts:

| Shortcut     | Alternative shortcut | Command       |
|--------------|----------------------|---------------|
| Ctrl-F       |                      | Find          |
| Ctrl-G       | F3                   | Find next     |
| Shift-Ctrl-G | Shift-F3             | Find previous |
| Escape       |                      | Cancel find   |
| Ctrl-Plus    | Ctrl-MouseScrollUp   | Zoom in       |
| Ctrl-Minus   | Ctrl-MouseScrollDown | Zoom out      |
| Ctrl-0       |                      | Reset zoom    |

#### BPA framework: Cluster BPAs can now execute code across the entire cluster \[ID_31266\]

Cluster BPAs can now call an InvokeCluster method to execute code across the entire cluster.

#### Standalone BPA Executor: UI enhancements \[ID_31303\]

In the *Run from DMA* tab, the *Delete* and *Save* commands have been removed from the right-click menu and replaced by the following buttons:

| Button             | Function                                |
|--------------------|-----------------------------------------|
| Delete             | Delete all selected tests.              |
| Save Tests Results | Save the results of all selected tests. |

> [!NOTE]
> The *Get Last Results* button will now only fetch the most recent results for any selected tests that are run on a schedule.

#### DataMiner Cube - Services app: Enhanced performance when saving all changes made to service definitions \[ID_31355\]

Due to a number of enhancements, overall performance has increased when clicking *Save all changes* to save all changes made to service definitions in the Services app.

### CU20 fixes

#### Cassandra: Problem when creating user-defined types \[ID_31001\]

On systems with a Cassandra database, in some rare cases, creating user-defined types could fail and return an exception.

When creating the user-defined types failed during a migration from MySQL to Cassandra, the following exception could be thrown:

```txt
The migration has failed.DBGatewayException(SLCassandraClassLibrary.DBGateway.Cassandra.StorageManagers.SingleNode.CassandraConnection,,UNKNOW SLDataGateway.Types.DBGatewayException: CassandraConnection CreateCustomType - no host available All hosts tried for query failed.
```

#### Problem with SLAutomation when trying to run Automation scripts on elements for which no protocol information could be retrieved \[ID_31030\]

In some cases, an error could occur in SLAutomation when trying to run Automation scripts on elements for which no protocol information could be retrieved.

#### Problem during DataMiner startup when retrieving alarms for multiple elements from an Elasticsearch database \[ID_31039\]

In some cases, the DataMiner startup process could become unresponsive and the CPU usage could rise to 100% when alarms for multiple elements were being retrieved simultaneously from an Elasticsearch database.

#### SLAnalytics: Problem during initialization \[ID_31044\]

When the SLAnalytics process was starting up, in some cases, an error could occur when one of its dependencies was not available. From now on, if an error were to occur during the initialization of the SLAnalytics process, the process will shut down gracefully.

#### DataMiner Cube - Correlation: Problem when discarding or moving a duplicated correlation rule or correlation analyzer \[ID_31058\]

When you duplicated a correlation rule or a correlation analyzer and then immediately discarded the duplicate or moved it to another folder, in some cases, the original rule or analyzer would incorrectly be deleted or moved.

#### Failover: Resources.xml would incorrectly not be synchronized on offline agent \[ID_31117\]

When a new Failover configuration was created, in some cases, the Resources.xml file would incorrectly not be synchronized on the offline agent.

#### DataMiner Cube - Trending: Alarm colors on the Y axis of a trend graph would be shown incorrectly when exceptions and numeric values were combined in the same severity \[ID_31124\]

In case of a numeric parameter with exceptions, an alarm template allows you to combine an exception value and a numeric threshold in one severity. Up to now, when an exception value and a numeric threshold were combined in one severity, in some cases, the alarm colors shown on the Y axis of a trend graph would not be correct.

#### SLProtocol would evaluate certain conditions incorrectly \[ID_31129\]

When a condition defined in a protocol contained an operator like +, -, \*, /, etc. at the right-hand side but no parentheses, the operation would be applied to the left-hand side, causing SLProtocol to evaluate the condition incorrectly.

In the following example, 20 would incorrectly be added to parameter 2002 instead of parameter 2001.

```xml
<Condition><![CDATA[id:2002 < id:2001 + 20]]></Condition>
```

#### Smart-serial & smart-IP protocols: Data could get lost when receiving large data packets \[ID_31132\]

Up to now, when a smart-serial or smart-IP protocol received large data packets, in some cases, it was possible for data to get lost.

#### Scheduler: Problem when a scheduled task was deleted from Windows Scheduler \[ID_31138\]

When a scheduled task had been deleted from Windows scheduler but was still present on the DataMiner Agent, in some cases, an error could be thrown. From now on, when that type of error is thrown after a manually executed task was deleted, the task in question will be recreated.

#### Problem with SLNet after replicating a DELT element \[ID_31154\]

When an element had been migrated within a DataMiner System and then configured to get replicated from its new host agent, in some cases, an incorrect subscription could be created when the replication connection was created and subsequently destroyed during DataMiner startup, prior to the agent being aware of the correct location of the DELT element. As a result, on both the former host agent and the current host agent, the CPU usage of the SLNet process would rise significantly.

#### Service & Resource Management: DateTime values were formatted incorrectly \[ID_31160\]

Due to a deserializing/serializing issue, in some cases, datetime values could be formatted incorrectly.

#### DataMiner Cube - Automation: DateTime control incorrectly updated with the DateTimeKind property \[ID_31190\]

When, in an interactive Automation script, you had configured the DateTimeKind property of a DateTime control, in some cases, the control would incorrectly be updated with the DateTimeKind property instead of the actual datetime value.

#### DataMiner Cube - Router Control: 'park source' feature would incorrectly not work on matrices with IO table structures \[ID_31239\]

Up to now, the “park source” feature would incorrectly not work on matrices with IO table structures.

#### Memory leak in SLElement when stopping or deleting an element with a protocol of type 'virtual' \[ID_31252\]

In some cases, SLElement could leak memory when stopping or deleting elements with a protocol of type “virtual”.

#### Automation: Problem when calling Engine.CreateExtraDummy or Engine.FindElement from multiple threads or tasks within the same script \[ID_31253\]

In some cases, errors could occur in SLAutomation when Engine.CreateExtraDummy or Engine.FindElement were called from multiple threads or tasks within the same script.

#### DataMiner Cube - Visual Overview: Property values would not get updated correctly \[ID_31293\]

In Visual Overview, in some cases, property values would not get updated correctly.

#### Failover: Full synchronization incorrectly not run at setup \[ID_31296\]

When a Failover system was set up, in some cases, a full synchronization would incorrectly not be run.

#### DataMiner Cube - Spectrum analysis: 'Auto RBW Factor' and 'Auto VBW Factor' values stored incorrectly in spectrum preset \[ID_31299\]

In some cases, the “Auto RBW Factor” and “Auto VBW Factor” values would be stored in spectrum presets in an incorrect way. This would then lead to an incorrect auto RBW/VBW calculation.

#### DataMiner Cube - Visual Overview: Table connections would disappear at certain zoom levels \[ID_32336\]

When using dynamic positioning in combination with dynamic zooming, shape grouping and table connections, in some cases, the connection lines could disappear at certain zoom levels.

#### DataMiner Cube - Services app: Contents of 'Configure groups' window would be arranged incorrectly \[ID_31344\]

When you right-clicked a Service Definition diagram and selected *Configure groups*, the contents of the *Configure groups* window would be arranged incorrectly. For example, the *Add group* button would be positioned at an incorrect location.

#### Web apps: Setvar controls in visual overviews would no longer be rendered correctly \[ID_31351\]

In web apps (e.g. Monitoring), in some cases, SetVar controls in visual overviews would no longer be rendered correctly.

#### STARTTLS/SSL options for SMTP would not get applied when sending generic emails \[ID_31592\]

When generic emails were sent via the SLASPConnection process, some of the SMTP options related to the connection type (STARTTLS/SSL) would not get applied, potentially causing failures when trying to send emails.

> [!NOTE]
> Since DataMiner version 10.1.10, sending emails via the SLAutomation process would also fail when using STARTTLS or non-default SSL port configurations.

## Addendum CU21

### CU21 enhancements

#### Enhanced polling of SNMP tables using MultipleGetBulk and MultipleGetNext \[ID_31715\]

In DataMiner versions prior to 10.1.11, when MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm could get stuck into an infinite loop. That problem was fixed in DataMiner version 10.1.11, but now, the MultipleGetBulk/MultipleGetNext polling mechanism has received a more thorough overhaul.

### CU21 fixes

#### DataMiner Connectivity Framework: Virtual functions would incorrectly inherit interfaces from the main element \[ID_30715\]

By default, the interfaces of a virtual function are the interfaces defined in the functions.xml file. Up to now, in some cases, virtual functions would also incorrectly inherited the interfaces of the main element.

#### Protocols: Export rules would fail to parse values containing escaped XML characters \[ID_31362\]

When, in a protocol, values contained escaped XML characters (e.g. \<Description>Measurements \> 5\</Description>), the export rules would fail to parse those values and the generated DVE or Virtual Function protocol would only have some or none of the export rules applied.

#### Alarm limit updates for column parameters would contain invalid data \[ID_31415\]

When alarm monitoring of type “rate” was used to monitor a column parameter, alarm limit change events would contain invalid data.

From now on, alarm limit change events will only be sent for standalone parameters and column parameters that are exported as standalone parameters in a virtual function or DVE child element.

#### DataMiner Cube - Correlation: Incorrect background color when creating or opening an analyzer or a correlation rule \[ID_31482\]

When, in the Correlation app, you created or opened an analyzer in the Analyzers tab or you created or opened a legacy correlation rule in the Correlation rules tab, the tab would incorrectly have a gray background.

#### SLPort would leak a socket when executing an action of type 'open' via a socket that had already been opened \[ID_31512\]

When an action of type “open” was executed on a smart-serial interface via a socket that had already been opened, SLPort would leak a socket as well as a port in the ephemeral port range. This would eventually lead to a situation in which no more ports were available and no more sockets could be created. From now on, SLPort will close the socket when it receives an action of type “open” on a socket that is already open.

#### SLAnalytics: Problem during initialization \[ID_31521\]

In some cases, an exception could be thrown during the initialization of the SLAnalytics process.

#### DataMiner Cube - Alarm Console: Problem when clearing an alarm while alarms were grouped by service \[ID_31549\]

When, in one of the tab pages in the Alarm Console, alarms were grouped by service, in some cases, an exception could be thrown when an alarm listed in more than one group was cleared.

#### DataMiner Cube - Settings: Changes made in 'Alarm Console \> Card-specific' section would incorrectly not get applied \[ID_31566\]

In the *Alarm Console \> Card-specific* section of the *Settings* app, you can configure which alarm tabs should be shown on element, service and view cards. Up to now, when you made changes to the settings on that page, those changes would incorrectly not get applied.

#### Problem with SLDataMiner when deleting an alarm template or a trend template \[ID_31583\]

In some rare cases, an error could occur in SLDataMiner when an alarm template or a trend template was deleted.

#### DataMiner Cube - Alarm cards: Services were not sorted naturally \[ID_31607\]

When you opened an alarm card, in some cases, the services affected by the alarm would incorrectly not be sorted naturally.

#### Problem when SLWatchDog was copying log files to the Minidump folder \[ID_31652\]

When an error of type “thread problem” occurs, the contents of the C:\\Skyline DataMiner\\Logging folder is compressed into a zip file, which is then placed in the C:\\Skyline DataMiner\\Logging\\Minidump folder. During this action, in some cases, a lock inside the SLWatchdog process would accidentally delay the start-up of elements.

#### DataMiner Cube - Settings: Turning an alarm tab of type 'sliding window' into a normal alarm tab would cause this change to be reverted as soon as another change was made to it \[ID_31664\]

When, in the group settings, you added an alarm tab of type “sliding window” and enforced it, as soon as a user had turned this tab into a normal alarm tab, the slightest change made to the tab afterwards would cause the tab to be changed back into a tab of type “sliding window”.

#### DataMiner Cube - Alarm Console: Problem when alarm tabs were grouped by property \[ID_31673\]

When an alarm tab was grouped by property, in some cases, DataMiner Cube could become unresponsive, especially on systems with high alarm traffic.

#### DataMiner Cube - Scheduler: Creating a task could fail on client machines with culture set to “Finnish” \[ID_31712\]

In DataMiner Cube, creating a task in the Scheduler app could fail when the culture of the client machine was set to “Finnish”.

#### Dashboards app: Problem when listing the parameters of a selected element \[ID_31737\]

When, in a dashboard, you selected an element, in some cases, an “Index was outside the bounds of the array” error could be thrown when a linked parameter component tried to list all parameters of the element you selected.
