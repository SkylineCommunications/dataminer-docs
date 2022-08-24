---
uid: General_Main_Release_10.1.0_new_features_6
---

# General Main Release 10.1.0 - New features (part 6)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> **Internet Explorer Support**
>
> Though DataMiner Cube is available as a desktop application, many users still like to use the DataMiner browser application that requires Internet Explorer. However, Microsoft no longer recommends using Internet Explorer, and support for Internet Explorer is expected to cease in 2025, though currently the program is still maintained as part of the support policy for the versions of Windows it is included in. For more information, see <https://docs.microsoft.com/en-us/lifecycle/faq/internet-explorer-microsoft-edge>.
>
> The preferred way to use DataMiner Cube is as a desktop application, which can be downloaded from each DMA’s landing page in any other browser than Internet Explorer. From DataMiner 10.0.9 onwards, this application also comes with a new start window for increased ease of use.
>
> However, if you do wish to use DataMiner Cube in a browser, this remains possible:
>
> - Microsoft Edge can be configured to open specific URLs in IE compatibility mode. If you configure Edge to open the DataMiner Cube URLs of DMAs in this mode, you will be able to access the DMAs with DataMiner Cube in Edge. However, make sure you only do this for the exact URLs of DataMiner Cube, as other DataMiner apps will not function optimally in IE compatibility mode. For more information see, <https://docs.microsoft.com/en-us/DeployEdge/edge-ie-mode-policies>.
> - You can still continue to use Internet Explorer to access DataMiner Cube as long as Microsoft support continues. However, in this case we highly recommend to use a different browser to access any other websites on the internet.

### DMS Mobile apps

#### Jobs app: Filtering on auto-increment fields \[ID_24047\]\[ID_24857\]\[ID_25057\]

Up to now, a job’s auto-increment field was of type Long and could not be used to filter on. Now, that field will be of type String, containing an ID with a prefix and a suffix. As a result, it will now be possible to filter on it.

> [!NOTE]
> This change requires all existing job data to be converted. This data will automatically be converted the first time you start a DataMiner Agent after upgrading it. However, note that this means that data may be lost if you downgrade to earlier DataMiner versions.

#### Ticketing app: Move to Elasticsearch database and other improvements \[ID_24667\]\[ID_25539\] \[ID_25713\]\[ID_26644\]\[ID_26676\]\[ID_26677\]\[ID_26911\]\[ID_26982\]\[ID_27974\]\[ID_28016\]\[ID_28043\] \[ID_28079\]\[ID_28153\]

Multiple changes and improvements have been implemented to the Ticketing app. The most important change is that the app will now use the Elasticsearch database instead of the Cassandra database.

When you install DataMiner 10.0.13 and you already use an Elasticsearch database, all ticketing data will be migrated automatically. If you do not have an Elasticsearch database and you have installed DataMiner 10.0.13, the ticketing data will be migrated automatically as soon as you add an Elasticsearch database to you DataMiner System. However, until you do so, you will no longer be able to use the Ticketing app. A run-time error in the Alarm Console will indicate that Ticketing Manager could not be initialized because there is no Elasticsearch database.

When you interact with the Ticketing Manager in scripts, keep the following changes in mind:

- A ticket now has a *UID* property of type GUID, which is always unique and which replaces the *TicketID* object. This object was used with the Cassandra database and consisted of a DataMiner ID and ticket ID. However, in Elasticsearch, the DataMiner ID is no longer needed. While tickets will still have a unique ticket ID, new implementations should make use of the *UID* instead.

- A new *TicketingHelper* is available that should be used to read, create, update and delete tickets, ticket field resolvers and ticket history in scripts. The existing *TicketingGatewayHelper* remains backwards compatible, but should not be used for new implementations or to update existing code. Below you can find an example of how to use this helper:

    ```csharp
    public void Run(Engine engine)
    {
        // Create the helper
        var helper = new TicketingHelper(engine.SendSLNetMessages);

        // helper.[OBJECT TYPE].[ACTION]
        // helper.Tickets.Update();
        // helper.TicketFieldResolvers.Delete();
        // helper.TicketHistories.Read();

        // Create a TicketFieldResolver
        var ticketFieldResolver = TicketFieldResolver.Factory.CreateDefaultResolver();
        var createdResolver = helper.TicketFieldResolvers.Create(ticketFieldResolver);

        // Create a Ticket
        var newTicket = new Ticket()
        {
            CustomFieldResolverID =  createdResolver.ID
        };
        var createdTicket = helper.Tickets.Create(newTicket);

        // Read the TicketHistory
        var historyFilter = TicketHistoryExposers.UniqueID.Equal(createdTicket.UID);
        var history = helper.TicketHistories.Read(historyFilter);

        // Read all Tickets linked to a TicketFieldResolver
        var ticketFilter = TicketingExposers.ResolverID.Equal(createdTicket.CustomFieldResolverID);
        var tickets = helper.Tickets.Read(ticketFilter);

        // Delete Tickets
        foreach (var ticket in tickets)
        {
            helper.Tickets.Delete(ticket);
        }

        // Check if the last Ticket request failed
        var traceData = helper.Tickets.GetTraceDataLastCall();
        if (!traceData.HasSucceeded())
        {
            engine.GenerateInformation($"Previous action failed! {traceData}");
        }
    }
    ```

- To check if a request was successful, you can now retrieve the *TraceData* using the *GetTraceDataLastCall()* method on the *CrudComponentHelper* type used for the request. This returns the TraceData object, which can contain TicketingManagerError objects, each containing a reason for the error and extra data on what caused it. These are the possible errors:

  - *TicketFieldResolverInUseByTickets*: The ticket field resolver still has tickets linked to it. (The property *RelatedTickets* contains the IDs of the tickets.)
  - *NotInitialized*: The Ticketing Manager is not initialized.
  - *LegacyError*: A legacy error has occurred. (The property *LegacyErrorMessage* contains the error message.)
  - *TicketLinkedToNonExistingTicketFieldResolver*: The created/updated ticket has a link to a ticket field resolver that does not exist. (The property *TicketFieldResolverId* contains the ID of that ticket field resolver.)
  - *TicketFieldResolverIsUnknownOrNotMasked*: The ticket field resolver is unknown or not masked.
  - *UnexpectedException*: An unexpected exception occurred. (The property *Exception* contains the exception.)
  - *TicketLinkedToMaskedTicketFieldResolver*: The created/updated ticket has a link to a ticket field resolver that is masked. (The property *TicketFieldResolverId* contains the ID of that ticket field resolver.

  Calling *ToString()* on the *TraceData* object will return a formatted string that shows all errors and associated data.

- When paging is started using *TicketingGatewayHelper.NewPagingRequest()*, the out parameter will no longer return the total number of tickets.

- When an invalid page size or page number is used in a request, an empty list will now be returned, while previously the ticketing helper returned all tickets matching the filter.

- Subscribing to *TicketingGatewayEventMessage* will no longer return an initial bulk. Instead tickets and ticket field resolvers should be retrieved via paging with the new *TicketingHelper*.

- Previously, when the Cassandra database was used, all open tickets were stored in the cache as well as the database. It was therefore possible to use the *CacheOnly* boolean in requests to retrieve only open tickets. This cache is no longer used, so using the *CacheOnly* boolean will no longer work when you use *NewPagedTicketsWithFilterMessage*. To resolve this, concatenate the filter with an open tickets filter, which you can retrieve using the new method *GetTicketStateFilter(TicketState ticketState)*. An exception was made for the *GetTickets* method of the existing *TicketingGatewayHelper*, which will still only return the open tickets.

- "Null" values of ticket fields will no longer be saved or returned.

- The open state of a ticket can no longer be linked to the state of an alarm.

- If *GenericEnumEntry\<int>* is used in *VisualData* on a *TicketFieldResolver*, this will now always be returned as a long integer instead of an integer.

- If the ticket field resolver defines a state *TicketFieldDescriptor*, tickets must now always contain a field indicating their state. When tickets are initially migrated to Elasticsearch, a state will automatically be defined for any tickets where this was not yet the case.

The following changes have been implemented in the web services API v1:

- The *DMATicket*, *DMATicketSelection* and *DMATicketUpdate* objects have a new *UID* property which contains the new GUID identifier of a ticket.

- The *PageSessionID* and *TotalTicketsCount* properties of the *DMATicketsPage* object are now obsolete.

- The *DMATicketsPage* object now has a new *HasNextPage* property, which indicates if there is another page after the currently requested page.

- The new methods *GetTicketV2*, *RemoveTicketV2*, *GetActiveTicketsV2* and *GetHistoryTicketsV2* are now available, to be used instead of *GetTicket*, *RemoveTicket*, *GetActiveTickets* and *GetHistoryTickets*.

Finally, the following changes have also been implemented:

- To include tickets in a custom backup, the backup option *Create a backup of the database* > *Include Ticketing in backup* must be selected.

- When you embed the Ticketing app in another page, you can now add *embed=true* to its URL in order to hide the side bar and header bar of the app.

- You can now add a filter in the Ticketing URL to only show tickets affecting a specific element, service, view or redundancy groups. To do so, add a filter in the following format: *affecting=**\[type\]**/**\[DataMiner ID\]**/**\[object ID\]*, where \[type\] can be *element*, *service*, *view* or *redundancy group*. For example: *affecting=element/299/31*

- When you view or edit a ticket in the app, the URL has now changed; while previously, it contained the DMA ID and ticket ID, it now contains the ticket UID. If you use an old URL, the Ticketing app will automatically try to adjust this to the new URL.

- The default page size for the ticket list in the Ticketing app has been increased to 50.

- Instead of AngularJS, the Ticketing app now uses Angular.

- The log file SLTicketingGateway.txt has now been replaced by SLTicketingManager.txt.

  > [!NOTE]
  > The Ticketing Gateway entry in the Cube Logging app now refers to the new file.

#### Jobs app: New methods to manage job attachments \[ID_24791\]\[ID_25961\]

The *JobManagerHelper* has been expanded with new methods that can be used to manage attachments to jobs:

- *AddJobAttachment(JobID **jobID**, string **fileName**,byte\[\] **fileBytes**)*: Adds an attachment to the specified job.

- *GetJobAttachmentFileNames(JobID **jobID**)*: Retrieves the names of the attachments of the specified job.

- *DeleteJobAttachment(JobID **jobID**, string **attachmentName**)*: Deletes the attachment with the specified name from the specified job.

- *GetJobAttachment(JobID **jobID**, string **attachmentName**)*: Retrieves the content of the specified attachment of the specified job as an array of bytes.

Please note the following regarding job attachments:

- The size limit of job attachments depends on the *Documents.MaxSize* setting in the file *MaintenanceSettings.xml*. By default, this is set to 20 MB.

- Deleting a job will remove all attachments of this job from the system. These cannot be recovered afterwards.

- Managing job attachments requires the *Jobs \> UI available* and *Jobs \> Add/Edit* user permissions.

- Job attachments are backed up with the backup option *All documented located on this DMA*.

- Job attachments are synced in a cluster.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### Jobs app: Format of auto-increment fields can now be changed even when those fields are being used in existing jobs \[ID_24917\]\[ID_24973\]

From now on, it is allowed to change the format of auto-increment fields even when those fields are being used in existing jobs. However, you will receive a notice, saying that existing jobs will keep using the old format.

#### Monitoring app: Spectrum Analyzer elements now have a Spectrum Analyzer page \[ID_24925\] \[ID_25028\]\[ID_25059\]

In the Monitoring app, Spectrum Analyzer elements now have a spectrum page that shows the spectrum trace, using a new monitor with the last preset.

The following tabs are available:

| Tab | Content |
|--|--|
| Information | Shows basic information regarding measurement points, markers, thresholds and parameters. |
| Traces | Allows you to display or hide the current trace, the minimum trace, the maximum trace and the average trace. |
| Presets | Lists the available presets. By default, only the private presets are listed (i.e. the presets that are only available to the current user). To also have the shared presets listed, select the *Show shared presets* option. Those will be indicated with a *Shared* tag. When you select a preset, below the list, a *Load preset* button will allow you to load the selected preset. |

#### Monitoring app: Alarm history now also available \[ID_25002\]

In the Monitoring app, alarm history is now also available.

#### Ticketing app: Selection box values can now be assigned a color \[ID_25175\]

The VisualizationHints on the TicketFieldResolver can now store colors for every value listed in a selection box.

These colors can be specified by using the following property:

- TicketFieldResolver#VisualizationHints#VisualFieldEnums (of type List\<VisualFieldEnum>)

For every color linked to a selection box value, a VisualFieldEnum object should be added with the following properties:

| Property  | Description                                                          |
|-----------|----------------------------------------------------------------------|
| FieldName | The name of the selection box (i.e. enum field).                     |
| EnumValue | The selection box value (i.e. the discreet value in the enum field). |
| Color     | The color associated with the selection box value.                   |

#### On mobile devices, the sidebar will now appear at the bottom of the screen \[ID_25225\]

When using a mobile app (Monitoring, Dashboards, Jobs, etc.) on a mobile device, the sidebar, which on a desktop device appears by default on the left-hand side of the screen, will now appear at the bottom of the screen.

#### User picture in top-right corner \[ID_25257\]

The mobile apps (Monitoring, Dashboards, Jobs, etc.) will now show a picture of the user in the top-right corner. If no picture is available, then the user’s initials will be shown instead.

#### Monitoring app: On mobile devices, a redesigned footer will now group all card controls \[ID_25267\]

When using the Monitoring app on a mobile device, all card controls will now be grouped on a redesigned footer.

#### Web applications updated to Microsoft .NET Framework 4.6.2 \[ID_25422\]

Web applications (Web Services API, legacy dashboards, Maps, etc.) have been updated to Microsoft .NET Framework 4.6.2.

#### Jobs app: Job domains \[ID_25889\]\[ID_26428\]\[ID_26813\]\[ID_26814\]\[ID_27025\]\[ID_26844\]

In the Jobs app, it is now possible to have different job domains, each with their own set of job section descriptions.

- If, in the top-left corner of the jobs list, you select a job domain from the list, the jobs list will be filtered and will list only the jobs associated with the selected job domain.

- In configuration mode, you can select the job domain in the top-left corner of the screen, and then configure the job sections within the selected domain. The *New*, *Edit*, *Duplicate* and *Delete* buttons on the right of the job domain selection box allow you to add a new domain, edit the selected domain (change its name and/or hide it), duplicate a domain or delete the selected domain.

##### Duplicating job domains

Clicking the *Duplicate* button will allow you to select one of the following options:

- **Share sections across domains**: Creates a new domain that shares its sections with the original domain.

  > [!NOTE]
  > Changes made to the sections of the new domain will also be applied to the sections of the original domain (except changes made to the *Color*, *Icon* and *Allow multiple instances* properties of a section).

- **Create copies of the sections**: Creates a new domain by duplicating the entire original domain, including its sections.

  > [!NOTE]
  > Changes made to the sections of the new domain will not be applied to the sections of the original domain.

When the duplication operation has finished, you will automatically be redirected to the newly created domain.

As a result of the above-mentioned changes, adding a new section to a domain has also been changed. The *Add section definition* window now has a *New* tab and an *Existing* tab.

- **New**: Use this tab if you want to create a new section from scratch.
- **Existing**: Use this tab if you want to add an existing section to the domain in question. In this case, apart from having to select the section to be added, you will also have to indicate whether you want to:

  - share the section with the other domain(s) containing that section, or
  - make a separate copy of the section (with a new name).

##### New web methods to be used when duplicating job domains

- **DuplicateJobsDomain(string connection, DMAJobDomain domain, string domainID, bool byRef)**

  This method will duplicate a job domain, either by reference or by hard copy, and return the ID of the new job domain if the duplication operation was successful.

  - If the *byRef* parameter is set to false, the method will create an entire new job domain that is in no way linked to the original job domain.
  - If the *byRef* parameter is set to true, the method will create a new job domain that shares its sections with the original job domain.

- **DuplicateJobsSectionDefinition(string connection, string domainID, string sourceDomainID, DMASectionDefinition sectionDefinition, bool byRef)**

  This method will duplicate a job section definition, either by reference or by hard copy.

  - If the *byRef* parameter is set to false, the method will add an entire new job section definition to the job domain specified by *domainID*. This job section definition will no way be linked to the original job section definition in the domain specified by *sourceDomainID*.
  - If the *byRef* parameter is set to true, the method will link the existing job section definition specified by *sectionDefinition* to the job domain specified by *domainID*. This same job section definition will then be shared between the two job domains.

- **GetAffectedJobDomains(string connection, string sectionDefinitionID)**

  This method will return the names of all the job domains that contain the job section definition specified by *sectionDefinitionID*.

> [!NOTE]
>
> - When you upgrade from a DataMiner system without job domains, all existing job section definitions will be stored in a job domain named “DefaultJobDomain”. If necessary, you can rename this default job domain.
> - When you delete a job section definition, a dialog box is displayed allowing you to choose whether to delete it completely, or only sever the link between the section definition and the domain.
> - When a job domain is deleted, all its section definitions are removed as well, unless these are linked to other domains as well.

#### Interactive Automation scripts: UI components now have a TooltipText property \[ID_25609\] \[ID_25978\]

UI components in interactive Automation scripts launched from a mobile app can now have a tool tip configured by means of the UIBlockDefinition class property “TooltipText”.

#### Jobs app: Enhanced job section configuration \[ID_25977\]

In the Jobs app, job section configuration has been enhanced.

When you add a new job section (by clicking a black or purple dot) or edit an existing job section (by clicking the edit button in the section’s header), a pop-up window will now appear, allowing you to enter or modify the properties of that section.

#### Jobs app: Tracking the history of job field values \[ID_26016\]

All changes made to job field values will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-job”).

A HistoryChange record associated with a job field value change will contain SectionChange objects and FieldValueChange objects.

A SectionChange object has the following properties:

| Field             | Description                                                                                    |
|-------------------|------------------------------------------------------------------------------------------------|
| SectionID         | The ID of the section in which fields were created, updated or deleted.                        |
| FieldValueChanges | A list of FieldValueChange objects (one for every field that was created, updated or deleted). |

A FieldValueChange object has the following properties:

| Field             | Description                                                                              |
|-------------------|------------------------------------------------------------------------------------------|
| FieldDescriptorID | The ID of the FieldDescriptor.                                                           |
| CrudType          | The type of change, indicating whether the field was added, updated or deleted.          |
| ValueBefore       | The value before the change. When CrudType is “Created”, this property will be Null. |
| ValueAfter        | The value after the change. When CrudType is “Deleted”, this property will be Null.  |

> [!NOTE]
>
> - If, for some reason, tracking changes to jobs would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a job is deleted, all HistoryChange records associated with this job will also be deleted, and a new HistoryChange record will be added to indicate when the job was deleted and by whom.

#### Enhanced visualization of disabled text boxes \[ID_26193\]

Disabled text boxes in e.g. interactive Automation scripts will now automatically be optimized as to size and will have a scrollbar when needed.

#### Visual Overview: HTML5 table controls can now have a filter box \[ID_26228\]\[ID_26235\]

Similar to Cube, visual overviews in HTML5 apps now also support table controls that include a filter box. In other words, when a parameter control shape with a table and a filter box defined in child shapes is passed to an HTML5 app, that shape will be rendered in the same way as it is rendered in Cube.

The child shapes (filter box and table) will have their coordinates defined relative to the parent shape.

- The filter box will contain an additional ExtraData item named VisualOverviewFilterBoxData with an optional CustomTextBoxInfo property.

- The table will contain an additional ExtraData item named VisualOverviewTableData.

If a table has been defined without a filter box, the parameter control will be passed to the HTML app without child regions.

#### User menu now has a 'Sign out' command \[ID_26254\]

In all mobile apps (Monitoring, Dashboards, Jobs, etc.), the user menu in the top-right corner of the screen now has a “Sign out” command.

#### Monitoring & Dashboards apps: Number groups in numeric parameter values will now be separated by a thin space \[ID_26394\]

In the Monitoring app and the Dashboards app, three-digit number groups in numeric parameter values will now by default be separated by a thin space. This will make large numbers more legible.

#### HTML5 apps: Sidebar settings will now be stored per user account in the browser’s local storage \[ID_26719\]

For each of the HTML5 apps (Monitoring, Jobs, etc.), the size and expand/collapse state of the sidebar will now be stored per user account in the browser’s local storage.

#### Jobs app: History pane \[ID_27113\]

When you are viewing a job, you can now open a *History* pane on the right. That pane will list all changes made to that particular job. At the bottom of the pane, you will also find the time at which the job was created and the time at which it was last edited.

Also, the following web method has been made available to retrieve the change history of a particular job:

- GetJobsHistory(string connection, string jobID)

#### Monitoring & Dashboards apps: Enhancements made with regard to shared spectrum analysis functionality \[ID_27378\]

In both the Monitoring app and the Dashboards apps, a number of performance improvements have been made with regard to shared spectrum analysis functionality.

Also, the following spectrum preset display settings will now be applied:

- Background color

- Grid line color

- Text color (axis labels and timestamp label)

- Show/hide axis labels

- Show/hide grid

#### Monitoring app: Visualizing view properties in the Surveyor \[ID_27411\]

Similar to DataMiner Cube, the Monitoring app now also allows you to visualize view properties in the Surveyor.

#### Loading screen of embedded apps will now show a loading indicator instead of the app icon \[ID_27594\]

The loading screen of all mobile apps (Monitoring, Dashboards, Jobs, etc.) will now show a loading indicator instead of the app icon when opened in embedded mode (i.e. using a URL that contains either the embed=true or embedded=true argument).

#### HTML5 apps: Loading indicator of selection boxes will now be displayed on the right \[ID_27871\]

When values are being loaded into a selection box, from now on, the loading indicator will be displayed on the right instead of on the left.

#### Jobs app & Ticketing app: Column widths can now be saved \[ID_28254\]

When, in the Jobs app or the Ticketing app, you change the widths of the columns in the jobs list or the ticket list, those widths will now be saved per domain in the user settings.

#### Jobs app: Jobs will now be retrieved via web sockets \[ID_28285\]

In the Jobs app, jobs will now be retrieved via web sockets.

As a result, all updates and deletions will now be received automatically.

### DMS Service & Resource Management

#### Service profiles \[ID_24552\]

Up to now, when users wanted to configure a service reservation, they each time had to select profiles for every node and interface of the service definition. From now on, when configuring a service reservation, users will in most cases only have to select a single predefined service profile. That profile will then automatically configure most of the nodes and interfaces necessary for the service reservation in question.

> [!NOTE]
>
> - You can define a single service profile for a series of almost identical service definitions.
> - Service profile logging is stored in SLProfileManager.txt.
> - To make sure service profile data is included in DataMiner backup packages, select *Profile Manager objects and configuration* when configuring backups in System Center.

#### Improvements ResourceManagerHelper class for deletion of resources \[ID_24002\]\[ID_24563\]

If there is an error deleting resources using the *ResourceManagerHelper* class, additional feedback is now returned:

- If one or more resources are deleted using the *ResourceManagerHelper* class, and at least one of the resources fails to be deleted, a single error, *ResourceDeleteFailed*, is returned, which now contains a *UsingIDs* property with all the IDs of the resources that failed. Any possible other resources are still successfully deleted.

- If a resource is deleted that is in use or in maintenance mode, the error *ResourceDeleteInUseOrMaintenanceMode* is returned. If the resource is included in scheduled, ongoing or quarantined bookings, the IDs of these bookings are now returned in the *FutureOrOngoingReservationIds* property.

If a resource that is used in past bookings is deleted, the deletion now fails by default, returning the error *ResourceDeleteInUseOrMaintenanceMode* with the boolean property *HasPastBookings* set to true.

In addition, the following new method is now available in the *ResourceManagerHelper* class: `Resource[] RemoveResources(Resource[] resources, bool ignorePastReservations);`

If *ignorePastReservations* is false, this method works in the same way as existing calls to remove resources. If it is set to true, past bookings will be ignored during the deletion checks. This can be used to delete resources that are only used in past bookings; however, note that these bookings may then contain invalid references to resources.

#### Mediation snippets \[ID_24610\]

Mediation snippets are pieces of code that will convert a parameter value from the format defined in a protocol to the format defined in a profile parameter (and vice versa).

MediationSnippet objects, defined on profile parameter level, consist of an ID and a string containing the actual snippet code (C#). They can be managed by means of the ProfileManagerHelper#MediationSnippets API.

To a particular profile parameter, you can add only one mediation snippet per protocol version. In other words, linking to both parameter 10 and parameter 20 in version 1.0.0.0 of Protocol X in the same profile parameter is not allowed. However, it is possible to specify a single wildcard character at the end of a protocol version (e.g. “1.0.0.\*”). When there are multiple matches, the most specific entry will be chosen (i.e. “1.0.0.\*” will take precedence over “1.\*”).

> [!NOTE]
>
> - Inside a snippet, it is possible to
>   - mediate multiple device parameters to a single profile parameter, and
>   - mediate a single profile parameter to multiple device parameters.
> - When a mediation snippet is updated or deleted, all DataMiner Agents in the DMS will unload that snippet. In case of a snippet update, the next mediation request will trigger a re-load of the updated version.
> - When an attempt is made to delete a mediation snippet used by a profile parameter, a MediationSnippetError will be thrown (with reason ExistingProfileParameters).
> - When a profile parameter is deleted, all the mediation snippets linked to that profile parameter will also be deleted.
> - When a profile parameter is updated, all the mediation snippets that got unlinked due to that update will be deleted.

To use a mediation snippet, you can send one of the following requests:

- MediateDeviceToProfileRequest (with response MediateDeviceToProfileResponse)

- MediateProfileToDeviceRequest (with response MediateProfileToDeviceResponse)

Both requests require the profile parameter ID, the element ID and the parameter value to be passed along, and will return either the mediated value(s) or a MediationError (which will also be logged in SLProfileManager.txt).

> [!NOTE]
>
> - Using mediation snippets requires a ServiceManager license and requires Indexing Engine to be installed.
> - In Indexing Engine, all mediation snippets are stored under the “cmediationsnippet” index. The compiled snippets are stored in C:\\Skyline DataMiner\\MediationSnippets\\Compiled.
>   - All DLL files are deleted from this folder when the DataMiner Agent starts up.
>   - Snippets are compiled per DataMiner Agent. Snippet DLLs are not synchronized among the agents in a DMS.
> - If you want the mediation snippets to be included in DataMiner backups, make sure to select the “Include the ProfileManager in backup” option.

#### Exporting and importing profile parameters \[ID_24641\]

It is now possible to export and import profile parameters to and from a file.

The following methods have been added to the ProfileManagerHelper:

- `export(IEnumerable<Guid> ids)`

  This method returns an object of type “ProfileParameterExportResult”, which contains the bytes of the export file. These bytes can then be saved to a file. To view the contents of that file, first unzip it.

  When you export profile parameters to a file, the following exceptions can be thrown:

  | Exception | Description |
  |--|--|
  | ProfileParameterNotFoundException | The ID of one of the profile parameters that was passed to the method could not be found. |
  | MediationSnippetNotFoundException | One of the profile parameters that was passed to the method has a link to a mediation snippet that could not be found. |

- `import(byte[] file)`

  This method returns an object of type “ProfileParameterImportResult”, which contains the imported profile parameters and mediation snippets.

  When you import profile parameters from a file, the following exceptions can be thrown:

  | Exception                        | Description                                                                    |
  |----------------------------------|--------------------------------------------------------------------------------|
  | InvalidDataException             | The file to be imported does not have the correct format.                      |
  | InvalidProfileParameterException | One of the profile parameters to be imported does not have the correct format. |
  | InvalidMediationSnippetException | One of the mediation snippets to be imported does not have the correct format. |

> [!NOTE]
>
> - If you export a profile parameter, all the mediation snippets linked to that parameter will also be exported.
> - When you import profile parameters and their mediation snippets, all existing profile parameters and mediation snippets with the same ID will be overwritten.

#### Mediated virtual functions \[ID_24657\]\[ID_25046\]\[ID_25193\]\[ID_25271\]\[ID_25401\]\[ID_25651\]\[ID_26078\]

Server-side support has been added for mediated virtual functions.

To configure mediated virtual functions, do the following:

1. For every parameter, every column and/or every cell you want to see in the virtual function element, create a profile parameter.
1. If, in the virtual function element, the value of a profile parameter should be transformed, then add a mediation snippet to that profile parameter.
1. Create a profile definition for the node of the function and a profile definition for every interface of the function.

   - In a profile definition, you can group profile parameters in tables if you want them to be shown as tables in the virtual function element.

1. Create a virtual function definition. In it, you can define the following:

   - The profile definition for the node.
   - The amount and type of interfaces and their profile definition.
   - The protocols supported. For every supported protocol, the following can to be defined:

     | Items             | Description                                                                               |
     |-------------------|-------------------------------------------------------------------------------------------|
     | Entry-point table | The (optional) table that holds the multiple instances of a function in a single element. |
     | Interface filters | The (optional) additional table filters that have to be used for the interface tables.    |

   Next to that, you can also define what the virtual protocol should look like:

   - Define the pages you want to see in the protocol.
   - Define which profile parameters from the profile definitions of the node/interfaces should be on each page.
   - Define which tables from the profile definitions of the node/interfaces should be on each page.

   When you save the virtual function definition, a virtual function protocol is generated (with type “virtual-function”) and the metadata associated with that protocol is stored in an automatically created “virtual function protocol meta” object. That object will contain the following information:

   - The IDs of the read/write parameters that were generated for the different profile parameters and nodes/interfaces.
   - The tables that were generated.
   - Profile parameter information (type, ...)

   This protocol metadata will be used:

   - to resolve IDs of generated parameters when binding a resource
   - to be able to re-use parameter IDs when a new version of the protocol is generated
   - to validate the new versions of the generated protocol

1. Create a virtual function resource with a specific virtual function definition.

   The virtual function element with automatically be created using the generated virtual function protocol.

1. Bind the virtual element to an element by updating the virtual resource:

   - Specify the element ID.
   - Specify the entry point table index (if an entry point table was defined).

   All the parameters and tables of the virtual function element, which were set to “not-initialized/empty”, will now be set to the replicated/mediated values of the bound element.

##### Virtual function definitions

Virtual function definitions can be used on service definition nodes. They can be managed by means of the ProtocolFunctionHelper.VirtualFunctionDefinitions API.

Virtual function definitions are stored in Indexing Engine under the cvirtualfunctiondefinition index. When you create a database backup, they will automatically be included in the package when the *Include SRM in backup* option is enabled.

All logging with regard to virtual function definitions will be added to SLFunctionManager.txt.

##### Virtual function protocol metadata

Virtual function protocol metadata is stored in Indexing Engine under the cvirtualfunctionprotocolmeta index. When you create a database backup, this metadata will automatically be included in the package when the *Include SRM in backup* option is enabled.

##### Virtual function resources

A virtual function resource is an extension of a normal resource. It has the following additional properties:

| Property | Content |
|--|--|
| VirtualFunctionID | The ID of the VirtualFunctionDefinition of which it is an instance. |
| PhysicalDeviceDmaId | The ID of the element that is currently bound to the VirtualFunctionElement. |
| PhysicalDeviceElementId |  |
| ElementName | The name of the VirtualFunctionElement that will be created. If none is specified, then the resource name will be used instead. |

Virtual function resources can be used on ReservationInstances and ServiceReservation-Instances, and can be managed by means of the ResourceManagerHelper API. They are saved in Resources.xml.

All logging with regard to virtual function resources will be added to SLResourceManager.txt.

##### Logging with regard to element binding

Logging with regard to element binding will be added to the following log files:

- SLResourceManager.txt can contain information about errors that occurred during the element orchestration or during binding/unbinding operations.
- SLFunctionManager.txt can contain information about errors that occurred during binding/unbinding operations. If the resource update request was sent from another agent than the one hosting the virtual function element, then the log file of the hosting agent might contain the error. You might also have to check SLDataMiner.txt.
- SLProfileManager.txt can contain information about errors that occurred during the mediation step of the parameter replication.
- The log file of the virtual function element can contain information about errors that occurred during binding, unbinding or replication operations in general.

#### OnStartActionsFailureEvent will now be executed when the start actions of a ReservationInstance fail \[ID_24790\]

From now on, an OnStartActionsFailureEvent will be executed when the start actions of a ReservationInstance fail.

If you want to use this event to trigger an Automation script, then make sure to add a custom entry point method to that script. See the example below.

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnSrmStartActionsFailure)]
public void OnSrmStartActionsFailure(Engine engine, List<StartActionsFailureErrorData> errorData)
{
}
```

A StartActionsFailureErrorData instance contains an *ErrorReason*, which explains what went wrong with the start actions. These are the possible error reasons:

- **ResourceElementNotActive**: The element linked to the resource was not active when the booking was started.

  > [!NOTE]
  > The resource (as well as the element ID) can be retrieved from the *Resource* property. The ReservationInstanceId will also be filled in.

- **ReservationInstanceNotFound**: The ReservationInstance could not be retrieved when the start actions were launched.

- **UnexpectedException**: An exception was thrown while executing the start actions.

  > [!NOTE]
  > This exception can be retrieved from the Exception property. The ReservationInstanceId is available in the ErrorData object.

##### Assigning an Automation script to the OnStartActionsFailureEvent

The following example shows how to assign an Automation script to the OnStartActionsFailureEvent.

```csharp
reservationInstance.OnStartActionsFailureEvent = new ReservationEvent("OnStartActionsFailureEvent", $"Script:StartActionsFailedScript");
```

Although the event name can be chosen randomly, it should be a meaningful name, as it can appear in log entries.

Notes:

- From now on, the elements linked to the resource must be active when the booking is started.

- The start actions will only be started after the ResourceManager has tried to activate the function resources.

- A notice will be generated when the start actions fail and no OnStartActionsFailureEvent was configured. See the following example:

    ```txt
    The start actions for the ReservationInstance 'c3c6df39-bf28-4860-b426-a6dcb2d2306f - RT_SRM_OnStartActionsFailureEvent_08_59_20' have failed, but no OnStartActionsFailure event was configured.
    ```

- A notice will be generated when the start actions fail and no OnStartActionsFailureEvent script has been configured. See the following example:

    ```txt
    The script Script:THIS_SCRIPT_DOES_NOT_EXIST_d03c6ec0-3274-4d01-8b28-e4d12459520d could not be correctly parsed to an existing automation script. The event OnStartActionsFailureEvent of reservation '4ce12a06-55f4-4c7c-a746-7874b23ecd8d - RT_SRM_OnStartActionsFailureEvent_08_59_00' will not be executed.
    ```

#### Tracking the history of ReservationInstances \[ID_25006\]

All changes made to ReservationInstances will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-reservationinstance”).

A HistoryChange records contains the following fields:

| Field | Description |
|--|--|
| ID | ID of the HistoryChange record. |
| SubjectId | ID of the ReservationInstance that was changed. |
| Time | Time at which the change was made. |
| FullUsername | Full user name of the person who made the change. If the change was triggered by the DataMiner System, this will be “DataMiner”. |
| DmaId | ID of the DataMiner Agent on which the change was triggered. |
| Changes | List of changes that were made. In case of a ReservationInstance, this can be a resource usage change or a status change. |

> [!NOTE]
>
> - If, for some reason, tracking changes to ReservationInstances would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a backup is configured to include the Service & Resource Management module, this will also include the chistory-reservationinstance table.
> - When a ReservationInstance is deleted, all HistoryChange records associated with this ReservationInstance will also be deleted, and a new HistoryChange record will be added to indicate when the ReservationInstance was deleted and by whom.
> - When a ReservationInstance is deleted, all HistoryChange records associated with this ReservationInstance will also be deleted.

#### Linking an ID of a contributing resource to a ServiceReservationInstance \[ID_25186\]

It is now possible to link an ID of a contributing resource to a ServiceReservationInstance.

#### Support for capabilities of type string and for time-dynamic capabilities \[ID_25217\]

Service & Resource Management now supports

- capabilities of type string, and

- time-dependent capabilities.

##### Capabilities of type string

It is now possible to define capabilities of type string:

- The CapabilityParameterValue class has a new property named “ProvidedString”. This can be used to define a string capability on a resource.

- The ResourceCapabilityUsage class has a new property named “RequiredString”. This can be used to define a string capability on a ReservationInstance.

- The CapabilityUsageParameterValue class has a new property named “RequiredString”. This can be used to define default capability values of type string for profile parameters and capability values of type string on profile instance parameters.

> [!NOTE]
> From now on, three types of capabilities can be defined: discreet, rangepoint and string. Up to now, when the value provided/required was a number, a rangepoint capability was used, and if it was not a number, a discreet capability was used. String capabilities will now be used when the value provided/required for a rangepoint capability is not a number and the value provided/required for a discreet capability is NULL or an empty string.

##### Time-dynamic capabilities

Time-dynamic capabilities are capabilities of which the value can differ over time, depending on the reservations that are using the capability. Currently, only capabilities of type string can be turned into time-dynamic capabilities (by setting their “IsTimeDynamic” property to true).

As a time-dynamic capability will be treated as a string capability that can have any value, the CapabilityParameterValue property “ProvidedString” will be disregarded.

When a time-dynamic capability is booked by a ReservationInstance that requires a specific value, the Resource capability will keep that value for the entire duration of the ReservationInstance. This means that overlapping ReservationInstances will be able to use the same time-dynamic capability on the same resource, as long as they require the same string capability.

> [!NOTE]
>
> - It is not possible to schedule multiple overlapping ReservationInstances using the same time-dynamic capability on the same resource with a different required string. This would cause quarantine conflicts. When you try to save a ReservationInstance that conflicts with existing ReservationInstances, the software will resolve the conflict by comparing the quarantine priority of all existing ReservationInstances to the one of the ReservationInstance you are trying to save. If the quarantine priority of the ReservationInstance you are trying to save is higher than that of all existing ones, then all existing ones will go into quarantine. Otherwise, the new ReservationInstance will go into quarantine.
> - Whether a capability is time-dynamic is defined on resource level.

##### New ResourceManagerHelper methods

In the context of time-dynamic capabilities, two new methods have been added to the ResourceManagerHelper:

- GetEligibleResourcesWithUsageInfo

- GetEligibleResourcesForServiceNodeWithUsageInfo

These methods correspond with GetEligibleResources and GetEligibleResourcesForService-Node, but the return value of the new methods contains information about the currently booked usage of each eligible Resource, along with all eligible Resources.

This usage info currently only contains information about the already booked capabilities for each resource. For each capability requested in the call, the usage info will contain a “CapabilityUsageDetails” property, which contains a “HasExistingBookings” property indicating whether the capability of that resource is:

- Not time-dynamic (which means the resource has the requested capability regardless of the time range the booking is in).

    In this case, “HasExistingBookings” will be NULL.

- Time-dynamic (without a booking in the requested time range).

    In this case, “HasExistingBookings” will be false.

- Time-dynamic (with a booking in the requested time range).

    In this case, “HasExistingBookings” will be true.

> [!NOTE]
> The GetEligibleResources and GetEligibleResourcesForServiceNode methods will continue to work correctly, but they will only return the eligible Resources without the extra information.

#### Service & Resource Management: New EmptyResourceInReservation property for ReservationInstance/ServiceReservationInstance \[ID_25220\]

In Service & Resource Management scripts, you can now configure nodes on a reservation instance while the resource is not known yet, by using the new *EmptyResourceInReservation* property.

#### Tracking the rebinding history of VirtualFunctionResources \[ID_25307\]

The rebinding history of VirtualFunctionResources will now be logged by means of HistoryChange records, stored in Indexing Engine (index “chistory-resource”).

A HistoryChange records contains the following fields:

| Field | Description |
|--|--|
| ID | ID of the HistoryChange record. |
| SubjectId | ID of the VirtualFunctionResource that was changed. |
| Time | Time at which the change was made. |
| FullUsername | Full user name of the person who made the change. If the change was triggered by the DataMiner System, this will be “DataMiner”. |
| DmaId | ID of the DataMiner Agent on which the change was triggered. |
| Changes | List of changes that were made. In case of a VirtualFunctionResource, this can be a RebindChange containing the following information about the binding:<br> - BindBefore (the element ID before the rebind)<br> - BindAfter (the element ID after the rebind)<br> - the type of change (Create/Update/Delete) |

Using the HistoryHelper#Resources API you can read all the history objects for resources. See the following example:

```csharp
ResourceID myResourceID = …
var query =HistoryChangeExposers.SubjectID.Equal(someResourceID.ToFileFriendlyString()).OrderBy(HistoryChangeExposers.Time);
```

> [!NOTE]
>
> - If, for some reason, tracking changes to VirtualFunctionResources would fail, an error will be logged in SLHistoryManager.txt each time a HistoryChange record could not be saved. To prevent users from receiving too many notices, a notice will only be generated every hour.
> - When a backup is configured to include the Service & Resource Management module, this will also include the chistory-resource table.
> - When a VirtualFunctionResource is deleted, all HistoryChange records associated with this VirtualFunctionResource will also be deleted.

#### Profile data can now also be stored in Indexing Engine \[ID_25515\]\[ID_25758\]\[ID_26081\]

From now on, the following profile data can be stored either in XML format on the DataMiner Agents (default) or in Indexing Engine:

- ProfileDefinitions

- ProfileInstances

- ProfileParameters

#### Missing interfaces on the parent function will now automatically be added when generating a contributing function \[ID_25587\]

When a contributing function had to be generated, up to now, it was assumed the given collection of interfaces to expose would match the interfaces on the parent system function. In fact, any interfaces on the parent system function that do not have a matching interface on the underlying service definition of the contributing function can simply be omitted from the request.

The software will therefore automatically create the interfaces on the contributing function and link them to a parameter group on the contributing protocol. The parameter group in the protocol will not contain any parameters and the name of the interface will be that of the matching interface in the system function definition (or “DefaultInterfaceName” if the interface in the parent system function does not have a name).

#### A profile assignment mode can now be configured on service definition nodes and on the resource usages of a ServiceReservationInstance \[ID_25616\]

Up to now, a profile assignment mode could already be configured on the capacity and capability usages of a ServiceReservationInstance. Now, a profile assignment mode can also be configured on service definition nodes and on the resource usages of a ServiceReservationInstance. For that purpose, a “ByProfileInstanceReference” property has now been added to the ObjectConfiguration class.

#### The full capacity will now always be quarantined when a capacity with a reference string must be quarantined \[ID_25637\]

When a capacity with a reference string has to be quarantined, from now on, the full capacity will always be quarantined.

#### New notice will now appear when a DMA that is not using Indexing Engine has an IDP license but no ServiceManager license \[ID_25762\]

The following notice will now appear when a DataMiner Agent that is not using Indexing Engine has an IDP license but no ServiceManager license:

```txt
DataMiner IDP is licensed, but no Elasticsearch database is active on the system. Therefore, scheduled workflows are not available.
```

This same notice will also be added to the ResourceManager log file.

#### GetEligibleResources: New ResourceFilter and RequiredCapabilitiesOrFiltered arguments \[ID_25786\]

The GetEligibleResources call has been extended with two new arguments:

| Argument | Description |
|--|--|
| ResourceFilter | New (optional) argument to filter the eligible resources. Resources that do not match the specified filter will not be returned as eligible resource. |
| RequiredCapabilitiesOrFiltered | Apart from the RequiredCapabilities argument, which can be used to specify an “AND” list of capabilities, this new (optional) RequiredCapabilitiesOrFiltered argument can be used to specify an “OR” list of capabilities. |

> [!NOTE]
> The following new API call has been added to the ResourceManager-Helper:
>
> - public EligibleResourceResult GetEligibleResources(EligibleResourceContext context)
>
> This new call allows you to combine all existing and new parameters of the GetEligibleResources calls. The legacy GetEligibleResources and GetEligibleResourceForServiceNodeWithUsageInfo calls will now link to this new call.

#### LockLifeCycle property added to ServiceReservationInstance objects \[ID_26635\]

ServiceReservationInstance objects now have a LockLifeCycle property, which can be set to either “Unlocked” (default) or “Locked”.

- When this property is set to “Unlocked”, the ServiceReservationInstance will behave like a normal ServiceReservationInstance.

- When this property is set to “Locked”, an additional check will be performed during the Concurrency License check.

> [!NOTE]
> When checking whether the concurrency limit set in the DataMiner License has been reached, a booking will not be taken into account when
>
> - it is a ServiceReservationInstance,
> - the ContributingResourceID is filled in,
> - the Contributing Resource exists, and
> - the Contributing Resource is used in an overlapping booking.
>
> A booking that is not taken into account when checking the concurrency limit will not be taken into account for the entire duration of the booking, even if the overlapping booking (see above) has already ended.

#### Possibility to add attachments to booking instances \[ID_26784\]

To support adding attachments to booking instances (i.e. ReservationInstance objects), a new ReservationInstanceAttachments property is now available in the ResourceManagerHelper. This property allows you to manage booking attachments using the following methods:

| Method                                                                                | Function                                                                         |
|---------------------------------------------------------------------------------------|----------------------------------------------------------------------------------|
| Add(ReservationInstanceID reservationInstanceID, string fileName, byte\[\] fileBytes) | Add an attachment to a booking                                                   |
| List\<string> GetFileNames(ReservationInstanceID reservationInstanceID)               | Retrieve the names of all the attachments added to the specified booking.        |
| Delete(ReservationInstanceID reservationInstanceID, string attachmentName)            | Deletes the attachment with the specified name from the specified booking.       |
| byte\[\] Get(ReservationInstanceID reservationInstanceID, string attachmentName)      | Retrieves the content of the attachment with the specified name as a byte array. |

> [!NOTE]
>
> - If a booking is deleted, all its attachments will be deleted as well. They will not be recoverable.
> - The maximum size of booking attachments is determined by the Documents.MaxSize setting, located in the MaintenanceSettings.xml file. Default: 20 Mb. Trying to upload a larger file will result in a DataMinerException.
> - Manipulating booking attachments requires security permissions on the ReservationInstance. If a SecurityViewId is specified, the view permission on the view is required to retrieve or download attachments, and the write permission on the view is required to add or delete attachments.
> - All booking attachments are synchronized throughout the DataMiner System. To include them in a backup, select the “All documents located on this DMA” backup option.

#### Element of a virtual function resource will now be updated when the resource changes \[ID_27043\]

Up to now, when a VirtualFunctionResource object was updated, in some cases, the virtual function element would not be updated corrected. When, for example, the VirtualFunctionDefinitionID of a VirtualFunctionResource was changed, in some cases, the element would not be set to use the protocol of the new virtual function definition, even when the resource update was successful.

From now on, the following resource updates will be taken into account:

- When the name of the resource is updated, the name of the element will also be updated.

- When the virtual function definition of the resource is updated, the protocol of the element will also be updated.

> [!NOTE]
> When the virtual function definition of a resource is updated while it is bound, the binding must still be valid after the update. Otherwise, the update will be blocked.
>
> It is possible to change both the binding and the virtual function definition in a single update by simultaneously updating the VirtualFunctionDefinitionID, the PhysicalDeviceDmaID and the PhysicalDeviceElementID.

#### Binding between a VirtualFunctionResource and a physical device element will now automatically be updated when the protocol of the device element changes \[ID_27466\]

When a virtual function resource is bound to a physical device element, that binding will now automatically be updated when the protocol of the physical device element changes.

- When the updated protocol of the physical device element is no longer supported by the VirtualFunctionDefinition of the resource, the resource will automatically become unbound and a notice will be generated for all such resources, stating that the new protocol no longer supports the binding.

- When the updated protocol of the physical device element is still supported by the VirtualFunctionDefinition but now uses an entry point table, the resource will be unbound as the row in the entry point table that needs to be bound to is unknown.

- When the updated protocol of the physical device element is still supported but no longer uses an entry point table, the resource will be unbound as the protocol used to support multiple resources binding and now only supports one resource binding.

- When the protocol of the physical device element is changed to a different protocol, which is also supported by the VirtualFunctionDefinition used by the resource and which uses the same binding method (entry point table or not), the resource binding will automatically be updated.

#### New helper method: GetEligibleResources \[ID_27609\]

The ResourceManagerHelper now contains a new method that allows you to simultaneously execute multiple eligible resource queries.

```csharp
/// <summary>
/// Returns the eligible resources for all given contexts. A result can be matched
/// with its context by matching the <see cref="EligibleResourceResult.ForContextId"/>
/// property on the <see cref="EligibleResourceResult"/> with the
/// <see cref="EligibleResourceContext.ContextId"/> of the
/// <see cref="EligibleResourceContext"/>.
/// </summary>
/// <exception cref="ArgumentNullException"><paramref name="contexts"/> is null
/// </exception>
/// <exception cref="ArgumentException"><paramref name="contexts"/> is empty
/// </exception>
/// <param name="contexts">The contexts to calculate the resources for</param>
/// <returns>
/// The result with additional info for all requested contexts that were valid.
/// If one or more contexts were invalid the results for the valid contexts are still
/// returned
/// </returns>
public List<EligibleResourceResult> GetEligibleResources(List<EligibleResourceContext> contexts)
{
    if (contexts == null)
        throw new ArgumentNullException(nameof(contexts));
    if(contexts.Count == 0)
        throw new ArgumentException("At least one context should be provided", nameof(contexts));
    var reqMsg = new GetEligibleResourcesMessage(contexts);
    return InnerGetEligibleResources(reqMsg)?.MultipleResults;
}
```

Also, a number of minor changes were done to make sure that the EligibleResourceResults can be matched to the requested contexts:

- An EligibleResourceContext now has a ContextId, which will automatically be filled in by any constructor.

- When the GetEligibleResources method returns a ReservationInstanceNotFound error or a ServiceNodeResourceUsageNotFound error, the error data will now have an additional  EligibleResourceContextId property. This will allow you to pinpoint any context will faulty data.
