---
uid: General_Main_Release_10.0.0_new_features_1
---

# General Main Release 10.0.0 - New features (part 1)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> From DataMiner 10.0.0/10.0.2 onwards, DataMiner Service & Resource Management also requires DataMiner Indexing.

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

There is also a button available that can be used to migrate booking data to the Indexing database. For more information, see [DataMiner Cube: New 'Migrate booking data to Indexing Engine' wizard \[ID_21935\]\[ID_23674\] \[ID_24410\]\[ID_24424\]](xref:General_Main_Release_10.0.0_new_features_5#dataminer-cube-new-migrate-booking-data-to-indexing-engine-wizard-id_21935id_23674-id_24410id_24424).

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
