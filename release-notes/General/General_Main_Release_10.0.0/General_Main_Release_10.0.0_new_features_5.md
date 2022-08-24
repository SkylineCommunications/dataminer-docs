---
uid: General_Main_Release_10.0.0_new_features_5
---

# General Main Release 10.0.0 - New features (part 5)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!IMPORTANT]
> From DataMiner 10.0.0/10.0.2 onwards, DataMiner Service & Resource Management also requires DataMiner Indexing.

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
