---
uid: General_Feature_Release_10.1.12
---

# General Feature Release 10.1.12

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### Redundancy groups: Additional information in information events and Automation scripts \[ID_31358\]

When switching elements within a redundancy group, from now on, additional information will be added both to the information events and the Automation scripts that are executed.

##### Information events

The following information will be added to the information events.

- When a user changes the mode of a redundancy group, one of the following strings will now be added to the information event with parameter description “Edited”:

  - *RDG By Administrator: Set Mode to Automatic switching*
  - *RDG By Administrator: Set Mode to Manual switchback*
  - *RDG By Administrator: Set Mode to Manual switching*

- When a user sets an element to maintenance mode or takes an element out of maintenance mode, one of the following strings will now be added to the information event with parameter description “Edited”:

  - *RDG By Administrator: Switch to maintenance mode on \<element>*
  - *RDG By Administrator: Switch back from maintenance mode on element \<element>*

- When a switch is performed, an additional information event with parameter description “Redundancy switch” will now be generated to indicate the cause of the switch. In case of a manual switch, the information event will mention the user and in case of an automatic switch, it will mention the trigger ID.

- When DataMiner intervenes in the switching process, an information event with parameter description “Linked to” is generated. From now on, this event will also mention the element from which the switch occurred. It will now contain e.g. “RDG1, Unlinked from RDG3” instead of just “RDG1”.

##### Automation scripts

When an Automation script is triggered as part of an redundancy group action, that script will now have the following additional parameters. These can then be requested from within the Automation script using the GetScriptParam(\<id>) method on the engine object.

| ID | Name | Description |
|--|--|--|
| 65007 | \<Redundancy User> | In case of manual switching, this parameter will contain the name of the user who performed the switch. |
| 65008 | \<Redundancy Trigger> | In case of automatic switching, this parameter will contain the ID of the trigger that caused the switch to be performed. To look up the trigger, send a GetRedundancyGroup-ByID or GetRedundancyGroupByName message and check the Triggers array in the response. |
| 65009 | \<Redundancy Triggering Element> | In case of automatic switching, this parameter will contain the ID of the element that has caused the trigger to be fired. ID format: `<DataMinerID>/<ElementID>` |
| 65010 | \<Redundancy Primary> | This parameter will contain the ID of the primary element involved in the switch. ID format: `<DataMinerID>/<ElementID>` |
| 65011 | \<Redundancy Backup> | This parameter will contain the ID of the backup element involved in the switch. ID format: `<DataMinerID>/<ElementID>` |

### DMS Security

#### DataMiner Cube - System Center: New & updated user permissions \[ID_30989\]\[ID_31208\]

In the *Users/Groups* section of System Center, new user permissions have been added and existing user permissions have been updated.

##### New user permissions

- Modules \> Process Automation \> Add/Edit
- Modules \> Process Automation \> Delete
- Modules \> Process Automation \> Read
- Modules \> Services \> Profiles \> Definitions \> Delete
- Modules \> Services \> Profiles \> Instances \> Delete

##### New and restructured user permissions

- Modules \> Profiles \> UI available
- Modules \> Profiles \> All except instances \> Add/Edit
- Modules \> Profiles \> All except instances \> Delete (NEW)
- Modules \> Profiles \> Instances \> Add/Edit
- Modules \> Profiles \> Instances \> Delete (NEW)
- Modules \> Profiles \> Configure (with tooltip providing more information) (NEW)

##### Updated user permissions

- Users are no longer allowed to add an instance to a newly created service profile definition that has not yet been saved.
- When a user who has been granted the Modules \> Services \> Profiles \> Definitions \> Delete permission deletes a service profile definition, all instances of that definition must also be deleted. A confirmation box will now appear to make the user aware of this. Also, a confirmation box will now appear when you try to delete definition instances.

#### UDP port 162 opened by default \[ID_31035\]

In the default firewall configuration, from now on, UDP port 162 will again be opened by default.

> [!NOTE]
> On systems that do not rely on SNMP traps, it is recommended to close this port.

#### Users authenticated by Azure AD using SAML can now automatically be created and assigned to groups \[ID_31057\] \[ID_31184\]

Users authenticated by Azure AD using SAML can now automatically be created and assigned to groups in DataMiner.

> [!NOTE]
> If you plan to implement this new feature, make sure DataMiner is not configured to import users and/or groups from Azure AD. This might cause users to be created twice.

To configure DataMiner to automatically (a) create users authenticated by Azure AD using SAML and (b) assign them to groups, proceed as follows:

1. Make sure DataMiner is registered as an Enterprise Application in Azure AD.
2. Go to *Users and groups* and add the necessary users and groups to the Enterprise Application.
3. Go to *Single sign-on*, select *SAML*, and edit the following settings in “Basic SAML Configuration”:

    - Set *Entity ID* to `https://[your application name]`.
    - Under *Reply URL*, specify the following URLs:

        ```txt
        https://[your application name]/root/
        https://[your application name]/ticketing
        https://[your application name]/jobs
        https://[your application name]/monitoring
        https://[your application name]/dashboard
        https://[your application name]/root
        https://[your application name]/login
        https://[your application name]
        ```

    - Set *Sign on URL* to `https://[your application name]`.

4. Go to *User Attributes & Claims* and add a group claim.

    > [!NOTE]
    > If you add a group claim, the account name of the group will only be sent via SAML when the groups are synchronized. Otherwise, the ID of the group will be sent instead.

5. In DataMiner Cube, add the necessary groups.

6. In the DataMiner.xml, configure the \<ExternalAuthentication> element as shown in the following example.

    ```xml
    <DataMiner ...>
      ...
     <ExternalAuthentication type="SAML" ipMetadata="[Path/URL of the identity provider’s metadata file]" spMetadata="[Path/URL of the service provider’s metadata file]" timeout="300">
        <AutomaticUserCreation enabled="true">
          <EmailClaim>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress</EmailClaim>
          <Givenname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname</Givenname>
          <Surname>http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname</Surname>
          <Groups claims=“true”>[group claim name]</Groups>
        </AutomaticUserCreation>
      </ExternalAuthentication>
      ...
    </DataMiner>
    ```

    > [!NOTE]
    >
    > - In Azure AD, the ipMetadata URL can be found under *Single sign-on \> SAML Signing Certificate – App Federation Metadata*.
    > - If, in the *Groups* element, you set the *claims* attribute to “false”, no claims will be used to add users to groups. In that case, the name of the group as specified in Cube will be used instead. A user can only be added to a single group this way.
    > - If, in the *Groups* element, you set the *claims* attribute to “false”, the user information that is created will not be updated.

7. Save the DataMiner.xml file.

8. Create an spMetadata file as described in the DataMiner Help section “Creating a DataMiner metadata file”.

    > [!NOTE]
    > In Azure AD, the EntityID can be found under *Single sign-on*. It is not the application ID.

9. Restart the DataMiner Agent.

#### Web apps: Using custom HTTP headers will now be allowed \[ID_31090\]

From now on, the DataMiner web apps will allow the use of custom HTTP headers. Up to now, custom HTTP headers would by default be deleted.

As a result, it will now be possible to configure custom HTTP headers in IIS Manager to allow web applications to be secured with policies like HSTS, XSS, CSP, CORS, etc.

> [!NOTE]
> DataMiner web applications might still overwrite certain HTTP headers.

### DMS Cube

#### Visual Overview: New \[Element:\] placeholder \[ID_31158\]

In Visual Overview, you can now use the new “\[Element:\<input>,\<output>\]” placeholder to convert an element name to an element ID and vice versa.

\<input> can be set to

- an element name, or
- an element ID (dmaID/elementID).

\<output> can be set to

- “Name”, or
- “ID”.

Examples:

- \[Element:MyElement,ID\] will be resolved to the ID of the element with the name “MyElement”.
- \[Element:2/125,Name\] will be resolved to the name of the element with ID 2/125.

#### DataMiner Cube - Visual Overview: Service connectivity chains now support 'lite contributing' resources \[ID_31196\]

In Visual Overview, it is possible to have the connectivity chain of a service instance (from the Service & Resource Management module) drawn automatically in Visual Overview. Now, this feature supports so-called “lite” contributing resources, i.e. resources for which no enhanced elements have to be created.

#### Sidebar: Click '+' to pin sidebar items \[ID_31207\]

Since DataMiner feature release version 10.1.11, it is possible to pin and unpin items in the sidebar.

To pin an item, up to now, you had to click the ellipsis button (“...”), and then click the item you wanted to pin to the sidebar. From now on, you will have to click the Add button (“+”) instead.

#### DataMiner Cube - Visual Overview: Chromium web browser engine now supports find and zoom functionality \[ID_31232\]

The Chromium web browser engine now support find and zoom functionalities.

Available shortcuts:

| Shortcut     | Alternative shortcut | Command       |
|--------------|----------------------|---------------|
| Ctrl-F       |                      | Find          |
| Ctrl-G       | F3                   | Find next     |
| Shift-Ctrl-G | Shift-F3             | Find previous |
| Escape       |                      | Cancel find   |
| Ctrl-Plus    | Ctrl-MouseScrollUp   | Zoom in       |
| Ctrl-Minus   | Ctrl-MouseScrollDown | Zoom out      |
| Ctrl-0       |                      | Reset zoom    |

#### Visual Overview: New icons added to Icons stencils \[ID_31271\]

The following icons have been added to the Icons stencil:

- Action
- Cloudy
- Cloud Formation
- Response
- Request
- Media Connect
- Groups
- Media Live
- Media Package
- Mist
- Moon
- Pairs
- Parameter
- Rain And Snow
- Qactions
- Rain
- Rain Percentage
- Snow
- Semi Cloudy
- Storm
- Snowflake
- Sunset
- Sun
- Umbrella
- Thunder
- Wind Direction
- Weather Forecast
- Wind

#### Legacy Reports, Dashboards and Annotations modules will by default be hidden in new installations \[ID_31329\]

In new installations, from now on, the legacy Reports, Dashboards and Annotations modules will be hidden by default.

If you do not want these modules to be hidden, you can set the LegacyReportsAndDashboards and/or LegacyAnnotations soft-launch options to true.

### DMS Reports & Dashboards

#### Dashboards app: Sharing dashboards with other users via the DataMiner Cloud \[ID_29047\] \[ID_31476\]

It is now possible to share dashboards with other users via the DataMiner Cloud.

##### Prerequisites

- The DataMiner Cloud Pack must be installed on the DataMiner Agent.
- The DataMiner Agent must be connected to the DataMiner Cloud.
- To be able to share items, users must have the following permissions:

  - Modules \> Reports & Dashboards \> Dashboards \> Edit
  - General \> Live sharing \> Share
  - General \> Live sharing \> Edit
  - General \> Live sharing \> Unshare

##### Sharing a dashboard

1. In the Dashboards app, go to the list of dashboards on the left, and select the dashboard you want to share.

1. Click the “...” button in the top-right corner of the dashboard, and select *Start sharing*.

1. If it is the first time you are sharing the dashboard, you may be asked to confirm that you want to link your account to the cloud. Select *I want to link the above users* and click *Link accounts*.

1. In the pop-up window, fill in the email address of the person you want to share the dashboard with.

1. Optionally, in the *Message* field, add a message you want to send to the person you are sharing the dashboard with, in order to provide additional information.

1. If you do not want the dashboard to remain permanently available, select the *Expires* option and specify the expiration date.

1. Click *Share*. An email will be sent to the person you are sharing the dashboard with, to inform them that they now have access to the dashboard.

> [!NOTE]
>
> - If access to a dashboard is limited to some users only, it will not be possible to share this dashboard.
> - You can stop sharing a dashboard by clicking the “...” button again and selecting *Manage share*. This will open a pop-up box where you can delete the share or update the message.
> - At present, sharing dashboards that use the following components is not supported: spectrum components, Maps, SRM components (service definition and resource usage line graph), queries using feeds and visualizations based on query feeds (e.g. node edge graph, table), trend components with subscription filters and pivot table components. If you attempt to share a dashboard with content that is not supported for sharing, a message will be displayed with more information.

##### Accessing the Sharing module that lists the dashboards that others have shared with you

1. Open an internet browser (other than Microsoft Internet Explorer), go to <https://dataminer.services/>, and sign in.

1. On the dataminer.services landing page, click *Sharing*.

   You will now see all data that others have shared with you.

> [!NOTE]
> When somebody has shared a dashboard with you, you will receive an email informing you of this. You can then click the link in the email to immediately access the dashboard, provided that you already have a dataminer.services account.

##### Security layers

- User authentication via Microsoft B2C login.

- For every shared dashboard, a dedicated “Cloud-connected Agent” user (CCA user) is created on the DataMiner Agent. This user only has permission to view the data shown on the dashboard and nothing else.

- The DataMiner Web Services API now has a Web Application Firewall. Each time a CCA user calls a particular web method, this firewall will check whether that CCA user is allowed to do so.

- Detailed logging is stored in C:\\Skyline DataMiner\\logging\\Web and Dashboards Sharing SPI metrics are published.

> [!NOTE]
> In the list of users and groups in System Center, there is a separate section for dataminer.services users and groups. These also have their own icon, so the distinction with regular users and groups is more clear.
>
> As dataminer.services users and groups are entirely managed by DataMiner, they cannot be modified.

### DMS Automation

#### Automation scripts launched from web apps will now take into account the MaxFileSizeInBytes and AllowedFileNameExtensions properties of UIBlockDefinitions of type FileSelector \[ID_31212\]

In Automation scripts launched from web apps, the MaxFileSizeInBytes and AllowedFileName-Extensions properties of UIBlockDefinitions of type FileSelector will now also be taken into account.

An error will now be thrown when you try to add a file that is larger than the allowed file size or does not have an allowed file name extension. Also, the “Choose file” popup window will now only list files with an allowed extension and dragging an item other than a file or a folder onto the script’s drop zone will no longer be possible.

### DMS web apps

#### DataMiner landing page: Browser title changed to 'DataMiner' \[ID_31373\]

The browser title of the DataMiner landing page (e.g. `https://<MyDMA>/root/`) has been changed from “DataMiner Services” to “DataMiner”.

Also, the error message shown when you try to log in to a web application with a user account that has not been granted the “DataMiner Web Apps” user permission has now been changed to “You have no access to the DataMiner Web Apps”.

### DMS Service & Resource Management

#### Profile Manager: Server-side user permissions \[ID_30748\]

The public API of the Profile Manager now has the following server-side user permissions.

| Operation                                                                                   | Required user permission                                                                     |
|---------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------|
| Read calls of ProfileParameters, MediationSnippets, ProfileDefinitions and ProfileInstances | ProfileManagerUI                                                                             |
| Create and Update of ProfileParameters, MediationSnippets ProfileDefinitions                | ProfileManagerEditAll                                                                        |
| Delete calls of ProfileParameters, MediationSnippets ProfileDefinitions                     | ProfileManagerDeleteAll                                                                      |
| Create and Update of ProfileInstances                                                       | ProfileManagerEditInstances                                                                  |
| Delete of ProfileInstances                                                                  | ProfileManagerDeleteInstances                                                                |
| Read calls of ServiceProfileInstances and ServiceProfileDefinitions                         | ServiceProfileManagerUI                                                                      |
| Create and Update ServiceProfileInstances                                                   | ServiceProfileManagerEditInstances                                                           |
| Delete of ServiceProfileInstances                                                           | ServiceProfileManagerDeleteInstances                                                         |
| Create and Update of ServiceProfileDefinitions                                              | ServiceProfileManagerEditDefinitions                                                         |
| Delete of ServiceProfileDefinitions                                                         | ServiceProfileManagerDeleteDefinitions                                                       |
| Mediation calls (MediateDeviceToProfile and MediateProfileToDevice)                         | ProfileManagerEditAll, AccessElement and DataDisplayAccess, as well as access to the element |
| Getting the ProfileManagerConfiguration                                                     | ProfileManagerConfiguration                                                                  |
| Setting the ProfileManagerConfiguration                                                     | ProfileManagerConfiguration                                                                  |
| Exporting and importing ServiceProfiles                                                     | ServiceProfileManagerEditInstances and ServiceProfileManagerEditDefinitions                  |
| Exporting and importing Parameters                                                          | ProfileManagerEditAll                                                                        |

The following new permissions will automatically be assigned to existing user groups:

| User permission...                     | will be assigned to...                                           |
|----------------------------------------|------------------------------------------------------------------|
| ProfileManagerDeleteAll                | groups with the ProfileManagerEditAll permission.                |
| ProfileManagerDeleteInstances          | groups with the ProfileManagerEditInstances permission.          |
| ServiceProfileManagerDeleteInstances   | groups with the ProfileManagerEditInstances permission.          |
| ServiceProfileManagerDeleteDefinitions | groups with the ServiceProfileManagerEditDefinitions permission. |
| ProfileManagerConfiguration            | groups with the ProfileManagerEditAll permission.                |

> [!NOTE]
>
> - The AddOrUpdateBulk, RemoveBulk and Create, Read, Update and Delete calls on single objects in the ProfileHelper will throw CrudFailedExceptions if the ThrowExceptionsOnErrorData property is true on the CrudComponent. If not, the TraceData will contain a ManagerStoreError with reason NoPermission.
>
>   The AddOrUpdateBulk and RemoveBulk calls normally never throw exceptions regardless of the ThrowExceptionsOnErrorData property. However, NoPermission is an exception since this makes the entire call fail.
>
> - The calls in the ProfileManagerHelper will always return TraceData (except for the CrudComponent properties on the helper).
> - Import/export of ProfileParameters and mediation messages will throw a DataMinerException.
> - Import/export of the ServiceProfiles will return TraceData. This helper does not have an option to throw exceptions on error data.

## Changes

### Enhancements

#### Security enhancements \[ID_31122\]

A number of security enhancements have been made.

#### DataMiner Cube - Alarm Console: Enhanced correlation mechanism \[ID_30481\]

Due to a number of enhancements, overall performance of the correlation mechanism has increased, especially when generating correlation alarms with a large number of sources.

#### Communication between SLNet and SLAnalytics will now use NATS \[ID_30761\]

Communication between SLNet and SLHelper will now use NATS instead of .NET remoting.

#### Restoring a DataMiner backup package will no longer be possible when the package was created on a system with a different DataMiner version \[ID_30921\]

From now on, it will no longer be possible to restore a DataMiner backup package on a system with a DataMiner version that is different from the one on which the backup was taken.

#### DataMiner upgrade: All agents in the DataMiner System must now meet the requirements before an upgrade of the entire DataMiner System can proceed \[ID_31002\]

When you start an upgrade of an entire DataMiner System, from now on, all agents in that DataMiner System will be checked to determine if they meet the requirements specified in the upgrade package. If one of the agents does not meet the requirements, the entire upgrade will be aborted.

> [!NOTE]
> This check is performed when you upload an upgrade package. When, in DataMiner Cube, you select *Upload only*, the uploaded upgrade package will be marked “Failed” when the requirements are not met.

#### DataMiner Cube: Enhanced performance when loading large bookings \[ID_31097\]

Due to a number of enhancements, overall performance has increased when loading large bookings.

#### DataMiner Cube - Data Display: Enhanced performance when opening an element with a tree control parameter \[ID_31099\]

Due to a number of enhancements, overall performance of DataMiner Cube has increased when opening an element with a tree control parameter.

#### SLAnalytics - Automatic incident tracking: Enhancements \[ID_31123\]

A number of enhancements have been made to the automatic incident tracking feature, especially with regard to alarm group management.

#### Web Services API v1: Enhanced alarm template management methods \[ID_31149\]

In DataMiner version 10.1.9, the following methods were introduced to create, update, delete and assign alarm templates:

- CreateAlarmTemplate
- UpdateAlarmTemplate
- DeleteAlarmTemplate
- AssignAlarmTemplate

From now on, if no baseline configuration is provided in the request, the alarm information configured in the protocol for the chosen parameter will be passed along, and if no alarm information could be found, then a default baseline will be passed along instead.

The “average type” property will now always be set to “median”.

#### SLAnalytics - Behavioral anomaly detection: Enhancements \[ID_31151\]

A number of enhancements have been made to the behavioral anomaly detection feature, especially with regard to overall performance during startup or when restarting.

#### DataMiner Cube - Visual Overview: Enhanced updating of resource, booking and service booking information \[ID_31153\]

A number of enhancements have been made with regard to updating resource, booking and service booking information in Visual Overview.

#### Minor enhancements to several DataMiner processes \[ID_31155\]

A number of minor enhancements have been made to a number of DataMiner processes (e.g. SLXml, SLWatchdog, SLDMS, SLASPConnection and SLNet).

#### Cassandra cluster: Unnecessary scheduled maintenance tasks will automatically be deleted \[ID_31180\]

When a Cassandra cluster is starting up, the following scheduled tasks will automatically be deleted in Windows Task Scheduler:

- DBGatewayMaintenance/SLDefaultCassandraCompaction
- DBGatewayMaintenance/SLCassandraDefaultRepair

#### DataMiner Cube - Update Center: Enhanced error handling \[ID_31191\]

A number of enhancements have been made with regard to error handling and the rendering of error messages in Update Center.

#### SLAnalytics: Enhanced creation and clearance of notice events \[ID_31199\]

Notice events will now be generated to inform users in case of reduced accuracy of an SLAnalytics feature due to e.g. a high CPU, database or memory load. Those events will then automatically be cleared as soon as the CPU, database or memory load drops to a normal level.

Other changes:

- The pattern matching notice events that inform users when the memory limit has been reached will now be cleared as soon as memory usage drops below the limit.
- A notice event will now also be generated when the number of trended numeric parameters is too high to be monitored by behavioral anomaly detection and proactive cap detection. The maximum number of parameters that can be monitored by those features is 100,000. When this limit is reached, the rest of the parameters will be ignored.

#### BPA framework: Cluster BPAs can now execute code across the entire cluster \[ID_31266\]

Cluster BPAs can now call an InvokeCluster method to execute code across the entire cluster.

#### Standalone BPA Executor: UI enhancements \[ID_31303\]

In the *Run from DMA* tab, the *Delete* and *Save* commands have been removed from the right-click menu and replaced by the following buttons:

| Button             | Function                                |
|--------------------|-----------------------------------------|
| Delete             | Delete all selected tests.              |
| Save Tests Results | Save the results of all selected tests. |

> [!NOTE]
> The *Get Last Results* button will now only fetch the most recent results for any selected tests that are run on a schedule.

#### DataMiner Cube - Services app: Enhanced performance when saving all changes made to service definitions \[ID_31355\]

Due to a number of enhancements, overall performance has increased when clicking *Save all changes* to save all changes made to service definitions in the Services app.

#### Cassandra: Enhanced performance when writing data to the database \[ID_31361\]

Due to a number of enhancements, overall performance has increased when writing data to a Cassandra database.

### Fixes

#### DataMiner Cube - Visual Overview: No longer possible to display aggregated parameter values in shapes \[ID_30864\]

In Visual Overview, it was no longer possible to display aggregated parameter values in shapes by specifying either the DMA and element ID of an aggregation element or an \[AggregationRule:...\] placeholder in a shape data field of type Aggregation.

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

#### 'Not a matrix update' exceptions would appear in the Alarm Console \[ID_31052\]

In some cases, the parameter throttling mechanism would incorrectly try to interpret full table changes as matrix updates, causing “Unexpected Exception \[Not a matrix update.\]: Sending an event to subscribers (see comment)” alarm events to appear in the Alarm Console.

#### DataMiner Cube - Correlation: Problem when discarding or moving a duplicated correlation rule or correlation analyzer \[ID_31058\]

When you duplicated a correlation rule or a correlation analyzer and then immediately discarded the duplicate or moved it to another folder, in some cases, the original rule or analyzer would incorrectly be deleted or moved.

#### Security: Azure AD access tokens would incorrectly not get refreshed \[ID_31067\]

In some cases, Azure AD access tokens would incorrectly not get refreshed.

#### Web apps: Selecting the selected value in a selection box would incorrectly clear that value \[ID_31089\]

When, in a web app, you opened a selection box and selected the value that was selected, in some cases, that value would incorrectly be cleared.

#### DataMiner Cube - Trending: Alarm colors on the Y axis of a trend graph would be shown incorrectly when exceptions and numeric values were combined in the same severity \[ID_31124\]

In case of a numeric parameter with exceptions, an alarm template allows you to combine an exception value and a numeric threshold in one severity. Up to now, when an exception value and a numeric threshold were combined in one severity, in some cases, the alarm colors shown on the Y axis of a trend graph would not be correct.

#### DOM: LastModified property of a ModuleSettings object would incorrectly not get updated \[ID_31125\]

In some cases, the LastModified property of a ModuleSettings object would incorrectly not get updated.

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

#### DataMiner Cube: View updates and element removals would incorrectly not trigger an update of the 'Below this view' list in a view card \[ID_31141\]

In some cases, view updates and element removals would incorrectly not trigger an update of the “Below this view” list in a view card.

> [!NOTE]
> This change will also enhance overall performance when starting Cube on a system with SRM enabled and breadcrumbs disabled.

#### Problem with SLNet after replicating a DELT element \[ID_31154\]

When an element had been migrated within a DataMiner System and then configured to get replicated from its new host agent, in some cases, an incorrect subscription could be created when the replication connection was created and subsequently destroyed during DataMiner startup, prior to the agent being aware of the correct location of the DELT element. As a result, on both the former host agent and the current host agent, the CPU usage of the SLNet process would rise significantly.

#### Service & Resource Management: DateTime values were formatted incorrectly \[ID_31160\]

Due to a deserializing/serializing issue, in some cases, datetime values could be formatted incorrectly.

#### Web Services API v1: GetInformationEvents method would return an empty array \[ID_31162\]

Up to now, in some cases, the following methods would return an empty array, even when a valid timespan had been specified.

- GetInformationEvents
- GetInformationEventsV2
- GetInformationEventsSorted
- GetInformationEventsSortedV2

#### DataMiner Cube - Profiles: Profile parameter mediation snippet would fail to compile \[ID_31197\]

In some cases, the default profile parameter mediation snippet would fail to compile.

#### DataMiner Cube - Automation: DateTime control incorrectly updated with the DateTimeKind property \[ID_31190\]

When, in an interactive Automation script, you had configured the DateTimeKind property of a DateTime control, in some cases, the control would incorrectly be updated with the DateTimeKind property instead of the actual datetime value.

#### Dashboards app: Duplicate options in GQI queries \[ID_31206\]

In some cases, options added to GQI queries would incorrectly be added twice.

#### DataMiner Cube - Router Control: 'park source' feature would incorrectly not work on matrices with IO table structures \[ID_31239\]

Up to now, the “park source” feature would incorrectly not work on matrices with IO table structures.

#### DataMiner Agent could get stuck in offload mode after the database had been unreachable \[ID_31245\]

In some cases, a DataMiner Agent could get stuck in offload mode after the database had been unreachable for a period of time.

#### Memory leak in SLElement when stopping or deleting an element with a protocol of type 'virtual' \[ID_31252\]

In some cases, SLElement could leak memory when stopping or deleting elements with a protocol of type “virtual”.

#### Automation: Problem when calling Engine.CreateExtraDummy or Engine.FindElement from multiple threads or tasks within the same script \[ID_31253\]

In some cases, errors could occur in SLAutomation when Engine.CreateExtraDummy or Engine.FindElement were called from multiple threads or tasks within the same script.

#### Users without access to elements were no longer able to retrieve the list of views in which a service is located \[ID_31258\]

In some cases, it would no longer be possible for users without access to elements to retrieve the list of views in which a service is located using, for example, the Web Services API.

#### DataMiner Cube - Visual Overview: Property values would not get updated correctly \[ID_31293\]

In Visual Overview, in some cases, property values would not get updated correctly.

#### DataMiner Cube - Spectrum analysis: 'Auto RBW Factor' and 'Auto VBW Factor' values stored incorrectly in spectrum preset \[ID_31299\]

In some cases, the “Auto RBW Factor” and “Auto VBW Factor” values would be stored in spectrum presets in an incorrect way. This would then lead to an incorrect auto RBW/VBW calculation.

#### Interactive Automation scripts: Initial state of non-recursive tree view incorrect \[ID_31302\]

The initial checked/unchecked state of a non-recursive tree item would be incorrect when

- the state of the item in question was “checked”,
- there was no recursive checking,
- the item had children, and
- none of those children were checked.

#### Interactive Automation scripts: Dialog items could incorrectly inherit the dimensions of a dialog item shown earlier \[ID_31311\]

When an interactive Automation script was launched from a web app, in some cases, a dialog item could incorrectly inherit the dimensions of a dialog item shown earlier.

#### DataMiner Cube - Visual Overview: Table connections would disappear at certain zoom levels \[ID_32336\]

When using dynamic positioning in combination with dynamic zooming, shape grouping and table connections, in some cases, the connection lines could disappear at certain zoom levels.

#### DataMiner Cube - System Center: Server setting updates would not be saved immediately \[ID_31339\]

When you had updated server settings in System Center (e.g. the default browser plug-in), up to now, it could take up to 10 seconds for the changes to be applied. Also, when Cube was closed in the meantime, those latest changes would be lost. From now on, all changes made to system settings will be applied immediately.

#### DataMiner Cube - Alarm Console: Problem after turning on the alarm focus feature \[ID_31343\]

When the alarm focus feature was used for the first time, in some cases, all alarm events would incorrectly be marked with an icon in the *Focus* column.

#### DataMiner Cube - Services app: Contents of 'Configure groups' window would be arranged incorrectly \[ID_31344\]

When you right-clicked a Service Definition diagram and selected *Configure groups*, the contents of the *Configure groups* window would be arranged incorrectly. For example, the *Add group* button would be positioned at an incorrect location.

#### Jobs app: Date values saved in UTC format would be parsed incorrectly \[ID_31345\]

In the Jobs app, in some cases, date values saved in UTC format would be parsed incorrectly.

#### Dashboards app - GQI: Problem when enabling the 'Use feed' option of a select node \[ID_31349\]

When, in a GQI query, the “Use feed” option of a select node had been enabled, in some cases, an error could occur when selecting the default columns.

#### Web apps: Setvar controls in visual overviews would no longer be rendered correctly \[ID_31351\]

In web apps (e.g. Monitoring), in some cases, SetVar controls in visual overviews would no longer be rendered correctly.

#### ProfileManager module could get stuck during its initialization routine \[ID_31367\]

In some rare cases, the ProfileManager module could get stuck during its initialization routine.

#### Problem when writing to the database after restarting an SLAnalytics feature or changing a setting of an SLAnalytics feature \[ID_31371\]

When an SLAnalytics feature had been restarted or when a setting of such a feature had been changed, in some cases, an exception could be thrown when data was written to the database.

#### DataMiner Cube - Alarm Console: 'Saved filters' option would incorrectly be missing on systems with a MySQL database \[ID_31375\]

When, on a system with a MySQL database, you selected *Apply filter...* in a newly created alarm tab, in some cases, the *Saved filters* options would incorrectly be missing.

#### DataMiner Cube - Visual Overview: Sorting of automatically generated shapes sorted by alarm severity would not get updated when the alarm level of any of the shapes was updated \[ID_31378\]

When automatically generated shapes configured to be sorted by alarm severity had their sorting enabled e.g. by means of a session variable, the sorting would be correct but would not get updated when the alarm level of any of the shapes was updated.

#### Dashboards app: Problem when generating a PDF report of a dashboard that contained empty components \[ID_31388\]

When a PDF report was generated for a dashboard that contained empty components, in some rare cases, the PDF generation process could get stuck.

#### Dashboards app: Problem when trying to import a dashboard \[ID_31389\]

When you tried to import a dashboard, in some cases, the system would incorrectly look for the dashboard to be imported in the “Dashboards” folder instead of the “ImportDashboards” folder.

Also, when you tried to import a dashboard on a DataMiner Agent that did not have an “ImportDashboards” folder, the Dashboards app would incorrectly look for the dashboard to be imported in the “Dashboards” folder instead. From now on, when the “ImportDashboards” folder does not exist, a message will appear, saying that no dashboards are available for import.

#### DataMiner Cube - Visual Overview: Session variable 'IDOfSelection' of ListView would be updated incorrectly \[ID_31395\]

When you embed a list view component in a visual overview and set the Source field to “Bookings”, then the session variable IDOfSelection will contain the ID of the currently selected booking. In some cases, this session variable would be updated incorrectly, especially when you selected a booking in the future after having selected a booking in the past.

#### Dashboards app - GQI: Column identification would be adapted incorrectly for services and view properties \[ID_31545\]

In GQI queries, since DataMiner version 10.1.11, columns are identified by ID instead of display name, and any query using the latter way of column identification is adapted on the fly the first time you open a dashboard containing such a query. However, up to now, column identification would not be adapted correctly for services and view properties.

#### STARTTLS/SSL options for SMTP would not get applied when sending generic emails \[ID_31592\]

When generic emails were sent via the SLASPConnection process, some of the SMTP options related to the connection type (STARTTLS/SSL) would not get applied, potentially causing failures when trying to send emails.

> [!NOTE]
> Since DataMiner version 10.1.10, sending emails via the SLAutomation process would also fail when using STARTTLS or non-default SSL port configurations.

#### Dashboards app - GQI: Problem when migrating 'start from' queries \[ID_31544\]

When you opened a query that was created using an older GQI version, and that query was configured to start from another query, in some cases, it would incorrectly be migrated to the current GQI version.

Also, in some cases, a server query would not be translated correctly to a client query.

#### Failover: Status of newly installed Failover system would incorrectly not be set to 'No problems detected' \[ID_31604\]

In some cases, the status of a newly installed Failover system would incorrectly not be set to “No problems detected” (i.e. green LED).

## Addendum CU1

### CU1 fixes

#### Problem when using Class Library monitors in DataMiner Integration Studio \[ID_31685\]

Critical errors could be thrown when using Class Library monitors in DataMiner Integration Studio in conjunction with DataMiner version 10.1.12. Also, in some cases, Automation scripts could fail at run-time.

## Addendum CU2

### CU2 fixes

#### Elements of which the second port was incorrectly configured would no longer start up \[ID_31882\]

Elements of which the second port was incorrectly configured would no longer start up. In some cases, a port could get configured incorrectly after the production version of a protocol had been changed to a version with an additional port.

Editing the element, setting any missing port values and saving the element configuration will fix this kind of problem. Therefore, whenever the system detects an element with an incorrect port configuration, from now on, a notice alarm with the following text will be generated for that element:

```txt
Initializing the communication of port (x) failed. Please verify the connection settings in the Edit window of the element.
```

> [!NOTE]
> Even if the second port of an element is a hidden port that does not require any configuration, the system will generate a notice alarm like the one above when it detects any anomalies in the port settings.
