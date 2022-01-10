# DataMiner user permissions

In the System Center module, the user permissions have been divided into three main groups: *General*, *Modules*, and *Other*. Below is an overview of the different permissions.

> [!NOTE]
> -  To quickly find a particular user permission in System Center, use the filter box in the top-right corner of the list of permissions.
> -  Some of the listed user permissions are only available if the DMA has the correct licenses and configuration, so that the user permissions are relevant.
> -  For many permissions, it makes no sense to grant them unless you grant the corresponding *UI Available* permission as well.

- [General](#general)

    - [Surveyor available](#surveyor-available)

    - [Data overview available](#data-overview-available)

    - [Data overview view available](#data-overview-view-available)

    - [DataMiner Cube mobile access / DataMiner web apps](#dataminer-cube-mobile-access--dataminer-web-apps)

    - [Element list available](#element-list-available)

    - [Elements](#elements)

    - [Elements \> Data Display](#elements--data-display)

    - [Services](#services)

    - [Views](#views)

    - [Redundancy groups](#redundancy-groups)

    - [Alarms](#alarms)

    - [Workspaces](#workspaces)

    - [Annotations](#annotations)

    - [Visual Overview](#visual-overview)

    - [Collaboration](#collaboration)

    - [Software updates](#software-updates)

    - [Email](#email)

    - [Live sharing](#live-sharing)

- [Modules](#modules)

    - [Asset Manager](#asset-manager)

    - [Automation](#automation)

    - [Bookings](#bookings)

    - [Correlation](#correlation)

    - [Documents](#documents)

    - [Element Connections](#element-connections)

    - [Jobs](#jobs)

    - [Planned Maintenance](#planned-maintenance)

    - [Process Automation](#process-automation)

    - [Profile Manager](#profile-manager)

    - [Profiles](#profiles)

    - [Protocols & Templates \> Protocols](#protocols--templates--protocols)

    - [Protocols & Templates \> Alarm templates](#protocols--templates--alarm-templates)

    - [Protocols & Templates \> Trend templates](#protocols--templates--trend-templates)

    - [Reports & Dashboards \> Reports](#reports--dashboards--reports)

    - [Reports & Dashboards \> Dashboards](#reports--dashboards--dashboards)

    - [Reservations](#reservations)

    - [Resources](#resources)

    - [Resource Manager](#resource-manager)

    - [Router Control](#router-control)

    - [Scheduler](#scheduler)

    - [Service Manager](#service-manager)

    - [Service templates](#service-templates)

    - [Services](#services)

    - [System configuration \> Agents](#system-configuration--agents)

    - [System configuration \> Security](#system-configuration--security)

    - [System configuration \> Security \> Notifications / alerts](#system-configuration--security--notifications--alerts)

    - [System configuration \> Backup](#system-configuration--backup)

    - [System configuration \> Cloud sharing/gateway](#system-configuration--cloud-sharinggateway)

    - [System configuration \> Database](#system-configuration--database)

    - [System configuration \> Indexing engine](#system-configuration--indexing-engine)

    - [System configuration \> Logging](#system-configuration--logging)

    - [System configuration \> Mobile Gateway](#system-configuration--mobile-gateway)

    - [System configuration \> Object Manager](#system-configuration--object-manager)

    - [System configuration \> SNMP Managers](#system-configuration--snmp-managers)

    - [System configuration \> System settings](#system-configuration--system-settings)

    - [System configuration \> System settings \> Credentials library](#system-configuration--system-settings--credentials-library)

    - [System configuration \> Tools](#system-configuration--tools)

    - [Ticketing Gateway](#ticketing-gateway)

    - [Trending](#trending)

- [Other](#other)

- [Legacy](#legacy)

### General

#### Surveyor available

| Cube permission    | Description                        |
|--------------------|------------------------------------|
| Surveyor available | Permission to access the Surveyor. |

#### Data overview available

| Cube permission         | Description                                                                                                                                          |
|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|
| Data overview available | Prior to DataMiner 9.6.6: Permission to access data pages of view cards.<br> From DataMiner 9.6.6 onwards: Permission to access data pages of cards. |

> [!NOTE]
> -  Up to DataMiner 9.5.3, the *Data overview available* permission is called *Element list available (SD Element Overview)* instead.
> -  As soon as this permission or the *View data overview available* permission is granted, the user will have access to data pages of view cards. To hide access to data pages of view cards, neither of these permissions should be granted.

#### Data overview view available

| Cube permission         | Description                                                                            |
|-------------------------|----------------------------------------------------------------------------------------|
| Data overview available | Available from DataMiner 9.6.6 onwards. Permission to access data pages of view cards. |

#### DataMiner Cube mobile access / DataMiner web apps

| Cube permission                                    | Description                                                                                                                                                                                                                                                                                               |
|----------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| DataMiner Cube mobile access / DataMiner web apps. | Available from DataMiner 10.1.0/10.1.2 onwards. Permission to access the DataMiner web apps. From DataMiner 10.0.0 \[CU16\] /10.1.0 \[CU5\]/10.1.8 onwards, the name of this permission changes to *DataMiner web apps*, to better reflect the actual usage of these apps. |

#### Element list available

| Cube permission        | Description                                                                        |
|------------------------|------------------------------------------------------------------------------------|
| Element list available | Permission to access Data pages of cards. Deprecated from DataMiner 9.6.6 onwards. |

> [!NOTE]
> As soon as this permission or the *Data overview available* permission is granted, the user will have access to Data pages of view cards. To hide access to Data pages of view cards, neither of these permissions should be granted.

#### Elements

| Cube permission                   | Description                                                                                                                                                                                                                                                                                                          |
|-----------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Access                            | Permission to access element cards.                                                                                                                                                                                                                                                                                  |
| Add                               | Permission to create elements.                                                                                                                                                                                                                                                                                       |
| Edit                              | Permission to update elements.                                                                                                                                                                                                                                                                                       |
| Delete                            | Permission to delete elements.                                                                                                                                                                                                                                                                                       |
| Import CSV                        | Permission to import elements from CSV files.                                                                                                                                                                                                                                                                        |
| Import DELT                       | Permission to import .dmimport packages.                                                                                                                                                                                                                                                                             |
| Export DELT                       | Permission to export .dmimport packages.                                                                                                                                                                                                                                                                             |
| Properties \> Add                 | Permission to create element properties.                                                                                                                                                                                                                                                                             |
| Properties \> Edit                | Permission to change the value of element properties.                                                                                                                                                                                                                                                                |
| Properties \> Delete              | Permission to delete element properties.                                                                                                                                                                                                                                                                             |
| Lock / unlock                     | Permission to lock and unlock an element.                                                                                                                                                                                                                                                                            |
| Force unlock                      | Permission to unlock an element that has been locked by another user.                                                                                                                                                                                                                                                |
| Start                             | Permission to start elements.                                                                                                                                                                                                                                                                                        |
| Stop                              | Permission to stop elements.                                                                                                                                                                                                                                                                                         |
| Pause                             | Permission to pause elements.                                                                                                                                                                                                                                                                                        |
| Restart                           | Permission to restart elements. Available from DataMiner 9.5.11 onwards.<br> Note that if users have both the *Start* and *Stop* permission, they are able to restart elements, regardless of the *Restart* permission. |
| Mask until clearance / for x time | Permission to mask elements until they are cleared or for a specific time.                                                                                                                                                                                                                                           |
| Mask until unmasking              | Permission to mask elements until they are unmasked.                                                                                                                                                                                                                                                                 |
| Allow unmasking                   | Permission to unmask elements.                                                                                                                                                                                                                                                                                       |
| Simulation available              | Permission to enable or disable element simulations. (Available from DataMiner 9.0.0 CU14 onwards.)                                                                                                                                                                                                                  |

> [!NOTE]
> DELT stands for *DataMiner Element Location Transparency*. It is the feature that allows the exporting and importing of packages as well as migration of elements across DMAs in a cluster.

#### Elements \> Data Display

| Cube permission                             | Description                                                                                                                                                                                                                                                   |
|---------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Access                                      | Permission to access the data pages of an element card.                                                                                                                                                                                                       |
| Device webpage access                       | Available from DataMiner 9.5.7 onwards. Permission to access the webpage of the device in the data pages.                                                                                                                                                     |
| View write parameters                       | Permission to view write parameters on data pages.                                                                                                                                                                                                            |
| Configure matrix options                    | Permission to configure a matrix parameter.                                                                                                                                                                                                                   |
| Spectrum \> Configure measurement points    | Permission to configure measurements points for a Spectrum Analyzer Element.                                                                                                                                                                                  |
| Spectrum \> Configure scripts & monitors    | Permission to manage spectrum scripts and spectrum monitors.                                                                                                                                                                                                  |
| Spectrum \> Edit / delete protected presets | Permission to update and delete protected spectrum analyzer presets.                                                                                                                                                                                          |
| Spectrum \> Take device from other client   | Permission to terminate a spectrum client sessions of another user in order to start a session yourself, in case the maximum number of concurrent client sessions is limited.<br> Note that this feature is no longer available from DataMiner 9.6.0 onwards. |
| Spectrum \> Take priority over monitors     | Permission to temporarily take priority over spectrum monitors.                                                                                                                                                                                               |

#### Services

| Cube permission        | Description                                           |
|------------------------|-------------------------------------------------------|
| Add                    | Permission to create services.                        |
| Edit                   | Permission to edit services.                          |
| Delete                 | Permission to delete services.                        |
| Properties \> Add      | Permission to create service properties.              |
| Properties \> Edit     | Permission to change the value of service properties. |
| Properties \> Delete   | Permission to delete service properties.              |
| Data Display \> Access | Permission to access the data pages of a service.     |

#### Views

| Cube permission                  | Description                                                                                                                                          |
|----------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|
| Manage views                     | Legacy user permission to access the *Admin \> Views* page of System Display. (Only available up to DataMiner 9.5.3.) |
| Add / remove elements            | Permission to add and remove elements and services to and from views.                                                                                |
| Add / remove views               | Permission to add and remove views.                                                                                                                  |
| Assign Visio drawings (SD Views) | Legacy user permission to link Visio files to views in System Display. (Only available up to DataMiner 9.5.3.)                                       |
| Properties \> Add                | Permission to create view properties.                                                                                                                |
| Properties \> Edit               | Permission to change the value of view properties.                                                                                                   |
| Properties \> Delete             | Permission to delete view properties.                                                                                                                |

#### Redundancy groups

| Cube permission                                        | Description                                                                                                                       |
|--------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| Add                                                    | Permission to create redundancy groups.                                                                                           |
| Edit                                                   | Permission to update redundancy groups.                                                                                           |
| Delete                                                 | Permission to delete redundancy groups.                                                                                           |
| Advanced \> Change redundancy mode                     | Permission to change the redundancy mode (automatic, manual, manual switchback) of a redundancy group (software redundancy only). |
| Advanced \> Manual switch                              | Permission to initiate a manual switchover (software redundancy only).                                                            |
| Advanced \> Set element in maintenance                 | Permission to set an element in maintenance.                                                                                      |
| Advanced \> Configure elements in redundancy templates | Permission to configure the elements in a redundancy group that was created as a redundancy group template.                       |
| Advanced \> Configure automatic switching              | Permission to use the automatic switching option when working with redundancy groups.                                             |

#### Alarms

| Cube permission                     | Description                                                                                                     |
|-------------------------------------|-----------------------------------------------------------------------------------------------------------------|
| Alarm Console available             | Permission to access the Alarm Console.                                                                         |
| Allow masking                       | Permission to mask alarms.                                                                                      |
| Allow unmasking                     | Permission to unmask alarms.                                                                                    |
| Allow take & release ownership      | Permission to take ownership of alarms and to release that ownership.                                           |
| Release ownership of another user   | Permission to release ownership of alarms owned by other users.                                                 |
| Allow viewing of system events      | Permission to view system events in the Alarm Console.                                                          |
| Extended context menu Alarm Console | Permission to access the Alarm Console shortcut menu.                                                           |
| Extended view menu Alarm Console    | Permission to access the *Open* submenu of the Cube Alarm Console shortcut menu. |
| Edit / delete protected filters     | Permission to update and/or delete protected filters created by another user.                                   |
| Properties \> Add                   | Permission to add properties to alarms.                                                                         |
| Properties \> Edit                  | Permission to change the value of alarm properties.                                                             |
| Properties \> Delete                | Permission to delete properties from alarms.                                                                    |
| Audible alert \> Add audio files    | Available from DataMiner 9.5.1 onwards. Permission to add audio files that can be used for audible alerts.      |
| Audible alert \> Edit audio files   | Available from DataMiner 9.5.1 onwards. Permission to edit audio files that can be used for audible alerts.     |
| Audible alert \> Delete audio files | Available from DataMiner 9.5.1 onwards. Permission to delete audio files that can be used for audible alerts.   |

#### Workspaces

| Cube permission | Description                      |
|-----------------|----------------------------------|
| Add             | Permission to create workspaces. |
| Delete          | Permission to delete workspaces. |

#### Annotations

| Cube permission | Description                               |
|-----------------|-------------------------------------------|
| View            | Permission to view annotations.           |
| Edit            | Permission to add and update annotations. |
| View Notes      | Permission to view DataMiner Notes.       |

> [!NOTE]
> From DataMiner 10.1.12 onwards, annotations are no longer available by default in new DataMiner installations. To enable them, set the soft-launch option *LegacyAnnotations* to true. See [soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/).

#### Visual Overview

| Cube permission         | Description                                                                                                |
|-------------------------|------------------------------------------------------------------------------------------------------------|
| Access Visual Overviews | Permission to access Visual Overview.                                                                      |
| Advanced navigation     | Permission to navigate from one Visual Overview page to another by clicking shapes that act as hyperlinks. |
| Download Visio drawings | Permission to download a Visio file from the DataMiner System to the client computer.                      |
| Edit Visio drawings     | Permission to change Visio files using the embedded Visio file editor.                                     |

#### Collaboration

| Cube permission        | Description                                                                                                       |
|------------------------|-------------------------------------------------------------------------------------------------------------------|
| UI available           | Permission to start chat sessions.<br> Included in all presets except *No rights*. |
| Disconnect other users | Permission to end chat sessions of other users.                                                                   |

#### Software updates

| Cube permission                    | Description                                                                |
|------------------------------------|----------------------------------------------------------------------------|
| Download software updates from DCP | Permission to download software from the DataMiner Collaboration Platform. |

#### Email

| Cube permission           | Description                                                                                          |
|---------------------------|------------------------------------------------------------------------------------------------------|
| Send via DataMiner System | Available from DataMiner 10.2.0/10.1.10 onwards. Permission to send emails via the DataMiner System. |

#### Live sharing

| Cube permission | Description                                                                                                                                                                                                                                                                                                                                                       |
|-----------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available    | Available from DataMiner 10.2.0/10.1.4 onwards. Permission to view items that have been shared in the cloud. (Available as *Modules* > *System configuration* > *Cloud gateway* > *View shared items* in earlier DataMiner versions.) |
| Share           | Available from DataMiner 10.2.0/10.1.4 onwards. Permission to share items in the cloud. (Available as *Modules* > *System configuration* > *Cloud gateway* > *Share item* in earlier DataMiner versions.)                             |
| Edit            | Available from DataMiner 10.2.0/10.1.4 onwards. Permission to make changes to items shared in the cloud. (Available as *Modules* > *System configuration* > *Cloud gateway* > *Update shared items* in earlier DataMiner versions.)   |
| Unshare         | Available from DataMiner 10.2.0/10.1.4 onwards. Permission to stop sharing items in the cloud. (Available as *Modules* > *System configuration* > *Cloud gateway* > *Unshare item* in earlier DataMiner versions.)                    |

> [!NOTE]
> These permissions require the cloud connected Agents feature, which is currently still in soft launch. See [Connecting your DataMiner System to the cloud](../../part_51/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.md).

### Modules

#### Asset Manager

| Cube permission | Description                                 |
|-----------------|---------------------------------------------|
| Asset Manager   | Permission to use the Asset Manager module. |

#### Automation

| Cube permission | Description                                        |
|-----------------|----------------------------------------------------|
| UI available    | Permission to access the DMS Automation module.    |
| Add             | Permission to create or import Automation scripts. |
| Edit            | Permission to update or export Automation scripts. |
| Delete          | Permission to delete Automation scripts.           |
| Execute         | Permission to execute Automation scripts.          |

#### Bookings

| Cube permission | Description                                                                                                                                                                                                            |
|-----------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available    | Available from DataMiner 9.6.7 onwards. Permission to access the *Bookings* module. Prior to DataMiner 9.6.7, this app is called the *Reservations* app. |
| Add             | Available from DataMiner 9.6.7 onwards. Permission to add bookings.                                                                                                                                                    |
| Edit            | Available from DataMiner 9.6.7 onwards. Permission to edit bookings.                                                                                                                                                   |
| Delete          | Available from DataMiner 9.6.7 onwards. Permission to delete bookings.                                                                                                                                                 |
| Execute         | Available from DataMiner 9.6.7 onwards. Permission to execute Automation scripts or parameter sets linked to bookings, e.g. scripts that are linked to booking events, or custom context menu items for bookings.      |

> [!NOTE]
> To access the *Bookings* module, you also need the appropriate licenses. For more information on acquiring licenses, contact the Skyline Sales department.

#### Correlation

| Cube permission | Description                                      |
|-----------------|--------------------------------------------------|
| UI available    | Permission to access the DMS Correlation module. |
| Add             | Permission to create Correlation rules.          |
| Edit            | Permission to update Correlation rules.          |
| Delete          | Permission to delete Correlation rules.          |

#### Documents

| Cube permission | Description                                                                                           |
|-----------------|-------------------------------------------------------------------------------------------------------|
| UI available    | Permission to access the DataMiner Documents user interface.                                          |
| Add             | Permission to upload documents.                                                                       |
| Edit            | Permission to change the title of an uploaded document as well as the comments that are linked to it. |
| Delete          | Permission to delete uploaded documents.                                                              |

#### Element Connections

| Cube permission     | Description                                               |
|---------------------|-----------------------------------------------------------|
| Element Connections | Permission to use view and configure element connections. |

#### Functions

| Cube permission   | Description                                                                                               |
|-------------------|-----------------------------------------------------------------------------------------------------------|
| Read              | Permission to view the Functions app. Available from DataMiner 10.20./10.1.7 onwards.                     |
| Add               | Permission to add virtual functions. Available from DataMiner 10.20./10.1.7 onwards.                      |
| Edit              | Permission to edit virtual functions. Available from DataMiner 10.20./10.1.7 onwards.                     |
| Delete            | Permission to delete virtual functions. Available from DataMiner 10.20./10.1.7 onwards.                   |
| Configure         | Permission to edit virtual functions. Available from DataMiner 10.20./10.1.7 onwards.                     |
| Generate protocol | Permission to generate a protocol for a virtual function. Available from DataMiner 10.20./10.1.7 onwards. |

> [!NOTE]
> -  At present, these permissions are used for the uploading and deleting of functions in the Protocols & Templates app, and for the use of the Functions app. However, the latter is currently still in soft launch. For more information, see [Soft-launch options](https://community.dataminer.services/documentation/soft-launch-options/).
> -  When you upgrade to DataMiner version 10.1.7, these six permissions are automatically granted to all user groups that have been granted the *Modules* > *Resources* > *Configure functions* permission.
> -  The Functions module requires DataMiner Indexing Engine.

#### Jobs

| Cube permission   | Description                                                                               |
|-------------------|-------------------------------------------------------------------------------------------|
| UI available      | Permission to view the Jobs app in Cube. Available from DataMiner 9.6.4 onwards.          |
| Add/Edit          | Permission to add or edit jobs. Available from DataMiner 9.6.4 onwards.                   |
| Delete            | Permission to delete jobs. Available from DataMiner 9.6.4 onwards.                        |
| Configure domains | Permission to configure a domain in the Jobs app. Available from DataMiner 9.6.4 onwards. |

> [!NOTE]
> This module requires DataMiner Indexing Engine.

#### Planned Maintenance

| Cube permission | Description                                                                                                   |
|-----------------|---------------------------------------------------------------------------------------------------------------|
| UI available    | Permission to view the Planned Maintenance (PLM) app in Cube. Available from DataMiner 10.2.0/10.1.2 onwards. |
| Add/Edit        | Permission to add or edit items in the PLM app. Available from DataMiner 10.2.0/10.1.2 onwards.               |
| Delete          | Permission to delete items in the PLM app. Available from DataMiner 10.2.0/10.1.2 onwards.                    |
| Configure       | Permission to configure the PLM app. Available from DataMiner 10.2.0/10.1.2 onwards.                          |

#### Process Automation

| Cube permission | Description                                                                                                           |
|-----------------|-----------------------------------------------------------------------------------------------------------------------|
| Read            | Permission to read items in the Process Automation framework. Available from DataMiner 10.2.0/10.1.12 onwards.        |
| Add/Edit        | Permission to add or edit items in the Process Automation framework. Available from DataMiner 10.2.0/10.1.12 onwards. |
| Delete          | Permission to delete items in the Process Automation framework. Available from DataMiner 10.2.0/10.1.12 onwards.      |

#### Profile Manager

| Cube permission | Description                                                                                                                                                        |
|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available    | Deprecated from DataMiner 9.6.5 onwards; instead available under *Profiles*. Permission to view the Profile Manager module in Cube. |
| Edit all        | Deprecated from DataMiner 9.6.5 onwards; instead available under *Profiles*. Permission to edit all items in the Profile Manager.   |
| Edit instances  | Deprecated from DataMiner 9.6.5 onwards; instead available under *Profiles*. Permission to edit instances.                          |

#### Profiles

| Cube permission                  | Description                                                                                                                                                              |
|----------------------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available                     | Available from DataMiner 9.6.5 onwards. Permission to view the *Profiles* module in Cube.                                                 |
| Edit all                         | Available from DataMiner 9.6.5 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards. Permission to edit all items in the *Profiles*. |
| Edit instances                   | Available from DataMiner 9.6.5 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards. Permission to edit instances.                                                  |
| All except instances \> Add/Edit | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit profiles, but not profile instances.                                                          |
| All except instances \> Delete   | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete profiles, but not profile instances.                                                               |
| Instances \> Add/Edit            | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit profile instances.                                                                            |
| Instances \> Delete              | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete profile instances.                                                                                 |
| Configure                        | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to configure the Profile Manager (server-side only).                                                         |

#### Protocols & Templates \> Protocols

| Cube permission             | Description                                                                 |
|-----------------------------|-----------------------------------------------------------------------------|
| UI available                | Permission to access the DataMiner protocols user interface.                |
| Add                         | Permission to add DataMiner protocols.                                      |
| Edit                        | Permission to edit DataMiner protocols.                                     |
| Delete                      | Permission to delete DataMiner protocols.                                   |
| Download protocols from DCP | Permission to download protocols from the DataMiner Collaboration Platform. |
| Generate MIB                | Permission to generate SNMP MIB files based on DataMiner protocols.         |

#### Protocols & Templates \> Alarm templates

| Cube permission        | Description                                              |
|------------------------|----------------------------------------------------------|
| UI available           | Permission to access the alarm templates user interface. |
| Add alarm templates    | Permission to create alarm templates.                    |
| Edit alarm templates   | Permission to update alarm templates.                    |
| Delete alarm templates | Permission to delete alarm templates.                    |

#### Protocols & Templates \> Trend templates

| Cube permission           | Description                                              |
|---------------------------|----------------------------------------------------------|
| UI available              | Permission to access the trend templates user interface. |
| Configure trend templates | Permission to edit trend templates.                      |

#### Reports & Dashboards \> Reports

| Cube permission       | Description                                                                                                        |
|-----------------------|--------------------------------------------------------------------------------------------------------------------|
| Reports app           | Legacy user permission to access the DMS Reports module in System Display. (Only available up to DataMiner 9.5.3.) |
| View reports          | Permission to view reports.                                                                                        |
| Manage mail templates | Permission to manage reporter templates.                                                                           |

#### Reports & Dashboards \> Dashboards

| Cube permission | Description                                                                                                           |
|-----------------|-----------------------------------------------------------------------------------------------------------------------|
| Dashboards app  | Legacy user permission to access the DMS Dashboards module in System Display. (Only available up to DataMiner 9.5.3.) |
| View dashboards | Permission to view dashboards.                                                                                        |
| Add             | Permission to create dashboards.                                                                                      |
| Edit            | Permission to update dashboards.                                                                                      |
| Delete          | Permission to delete dashboards.                                                                                      |

#### Reservations

| Cube permission | Description                                                                                                             |
|-----------------|-------------------------------------------------------------------------------------------------------------------------|
| UI available    | Permission to access the *Reservations* module. Deprecated from DataMiner 9.6.7 onwards. |
| Add             | Permission to add bookings. Deprecated from DataMiner 9.6.7 onwards.                                                    |
| Edit            | Permission to edit bookings. Deprecated from DataMiner 9.6.7 onwards.                                                   |
| Delete          | Permission to delete bookings. Deprecated from DataMiner 9.6.7 onwards.                                                 |
| Execute         | Permission to execute bookings. Deprecated from DataMiner 9.6.7 onwards.                                                |

> [!NOTE]
> To access the *Bookings* module, you also need the appropriate licenses. For more information on acquiring licenses, contact the Skyline Sales department.

#### Resources

| Cube permission | Description                                                                                                                                                                                            |
|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available    | Available from DataMiner 9.6.5 onwards. Permission to access the *Resources* module (previously known as the *Resource Manager* module). |
| Add             | Available from DataMiner 9.6.5 onwards. Permission to add pools and resources.                                                                                                                         |
| Edit            | Available from DataMiner 9.6.5 onwards. Permission to edit the status of resources.                                                                                                                    |
| Delete          | Available from DataMiner 9.6.5 onwards. Permission to edit pools and resources.                                                                                                                        |
| Execute         | Available from DataMiner 9.6.5 onwards. Permission to delete pools and resources.                                                                                                                      |

> [!NOTE]
> To access the *Resources* module, you also need the appropriate licenses. For more information on acquiring licenses, contact the Skyline Sales department.

#### Resource Manager

| Cube permission                              | Description                                                                                                                                                                                                                      |
|----------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Pools & Resources \> UI available            | Permission to access the *Resource Manager* module. Deprecated from DataMiner 9.6.7 onwards.                                                                                                      |
| Pools & Resources \> Add                     | Permission to add pools and resources. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                                  |
| Pools & Resources \> Edit \> Resource status | Permission to edit the status of resources. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                             |
| Pools & Resources \> Edit \> Other           | Permission to edit pools and resources. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                                 |
| Pools & Resources \> Delete                  | Permission to delete pools and resources. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                               |
| Pools & Resources \> Configure functions     | Available from DataMiner 9.5.4 onwards. Permission to add functions as resources. Deprecated from DataMiner 9.6.7 onwards.                                                                                                       |
| Reservations \> UI available                 | Permission to access the *Reservations* app. Prior to DataMiner 9.6.5, this permission is called *Timeline UI available*. Deprecated from DataMiner 9.6.7 onwards. |
| Reservations \> Add                          | Permission to add reservations. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                                         |
| Reservations \> Edit                         | Permission to edit reservations. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                                        |
| Reservations \> Delete                       | Permission to delete reservations. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                                      |
| Reservations \> Execute                      | Permission to execute reservations. Deprecated from DataMiner 9.6.7 onwards.                                                                                                                                                     |

> [!NOTE]
> -  In order to access the *Resource Manager* or *Reservations* module, you also need to have the Resource Manager license. For more information on acquiring a Resource Manager license, contact the Skyline Sales department.
> -  In DataMiner 9.6.4, the Resource Manager permissions are available under *Modules* > *Service & Resource Management* > *Resources* and *Reservations*. In later versions, the user permissions within this block are available under *Modules* > *Resources and Modules* > *Reservations/Bookings*.

#### Router Control

| Cube permission | Description                                     |
|-----------------|-------------------------------------------------|
| UI available    | Permission to access the Router Control module. |
| Configuration   | Permission to use the Router Control module.    |

#### Scheduler

| Cube permission | Description                                    |
|-----------------|------------------------------------------------|
| UI available    | Permission to access the DMS Scheduler module. |
| Add             | Permission to create tasks.                    |
| Edit            | Permission to update tasks.                    |
| Delete          | Permission to delete tasks.                    |
| Execute         | Permission to execute tasks.                   |

#### Service & Resource Management \> Profiles

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available under *Modules* > *Profiles*.

| Cube permission | Description                                                                      |
|-----------------|----------------------------------------------------------------------------------|
| UI available    | Permission to view the *Profiles* module in Cube. |
| Edit all        | Permission to edit all items in the *Profiles*.   |
| Edit instances  | Permission to edit instances.                                                    |

#### Service & Resource Management \> Resources

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available under *Modules* > *Profiles*.

| Cube permission         | Description                                                                                                                               |
|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| UI available            | Permission to access the *Resources* tab of the *Scheduler* module in Cube. |
| Add                     | Permission to add pools and resources.                                                                                                    |
| Edit \> Resource status | Permission to edit the status of resources.                                                                                               |
| Edit \> Other           | Permission to edit pools and resources.                                                                                                   |
| Delete                  | Permission to delete pools and resources.                                                                                                 |
| Configure functions     | Permission to add functions as resources.                                                                                                 |

#### Service & Resource Management \> Reservations

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available directly under *Modules* > *Reservations/Bookings*.

| Cube permission       | Description                                                                    |
|-----------------------|--------------------------------------------------------------------------------|
| Timeline UI available | Permission to access the *Reservations* module. |
| Add                   | Permission to add reservations.                                                |
| Edit                  | Permission to edit reservations.                                               |
| Delete                | Permission to delete reservations.                                             |
| Execute               | Permission to execute reservations.                                            |

#### Service & Resource Management \> Services

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available directly under *Modules* > *Services*.

| Cube permission                                | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available                                   | Permission to view the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                                     |
| Definitions \> Add                             | Permission to add definitions in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                       |
| Definitions \> Edit                            | Permission to edit definitions in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                      |
| Definitions \> Delete                          | Permission to delete definitions in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                    |
| Definitions \> Diagram \> Configure UI         | Permission to configure service definitions using the diagram user interface.                                                                                                                                                                                                                                                                                                                                                                                                                |
| Definitions \> Diagram \> Configure data       | Permission to configure the data for items in the *Services* diagram.                                                                                                                                                                                                                                                                                                                                                                                         |
| Definitions \> Diagram \> Configure groups     | Permission to configure groups in the *Services* diagram.                                                                                                                                                                                                                                                                                                                                                                                                     |
| Definitions \> Diagram \> Properties \> Add    | Permission to add properties in the *Services* diagram.                                                                                                                                                                                                                                                                                                                                                                                                       |
| Definitions \> Diagram \> Properties \> Edit   | Permission to edit properties in the *Services* diagram.                                                                                                                                                                                                                                                                                                                                                                                                      |
| Definitions \> Diagram \> Properties \> Delete | Permission to delete properties in the *Services* diagram.                                                                                                                                                                                                                                                                                                                                                                                                    |
| Definitions \> Properties \> Add               | Permission to add properties in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                        |
| Definitions \> Properties \> Edit              | Permission to edit properties in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                       |
| Definitions \> Properties \> Delete            | Permission to delete properties in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                     |
| Definitions \> Actions \> Add                  | Permission to add actions in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                           |
| Definitions \> Actions \> Edit                 | Permission to edit actions in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                          |
| Definitions \> Actions \> Delete               | Permission to delete actions in the *Services* module.                                                                                                                                                                                                                                                                                                                                                                                                        |
| Definitions \> Force updates                   | Available from DataMiner 9.5.14 onwards.<br> Permission to force the execution of the following actions despite warnings:<br> -  Uploading, deleting, activating or deactivating a functions file.<br> -  Updating or deleting a service definition.<br> -  Deleting a protocol with functions. |

#### Service Manager

| Cube permission                                | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
|------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available                                   | Permission to view the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| Definitions \> Add                             | Permission to add definitions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| Definitions \> Edit                            | Permission to edit definitions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                |
| Definitions \> Delete                          | Permission to delete definitions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                              |
| Definitions \> Diagram \> Configure UI         | Permission to configure service definitions using the diagram user interface. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                |
| Definitions \> Diagram \> Configure data       | Permission to configure the data for items in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                   |
| Definitions \> Diagram \> Configure groups     | Permission to configure groups in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                               |
| Definitions \> Diagram \> Properties \> Add    | Permission to add properties in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| Definitions \> Diagram \> Properties \> Edit   | Permission to edit properties in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                |
| Definitions \> Diagram \> Properties \> Delete | Permission to delete properties in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                              |
| Definitions \> Properties \> Add               | Permission to add properties in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| Definitions \> Properties \> Edit              | Permission to edit properties in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| Definitions \> Properties \> Delete            | Permission to delete properties in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                               |
| Definitions \> Actions \> Add                  | Permission to add actions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| Definitions \> Actions \> Edit                 | Permission to edit actions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| Definitions \> Actions \> Delete               | Permission to delete actions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| Definitions \> Force updates                   | Available from DataMiner 9.5.14 onwards. Deprecated from DataMiner 9.6.4 onwards.<br> Permission to force the execution of the following actions despite warnings:<br> -  Uploading, deleting, activating or deactivating a functions file.<br> -  Updating or deleting a service definition.<br> -  Deleting a protocol with functions. |

> [!NOTE]
> From DataMiner 9.6.4 onwards, the Service Manager permissions are available under *Modules* > *Service & Resource Management* > *Services*. In later versions, the user permissions within this block are available under *Modules* > *Services*.

#### Service templates

| Cube permission | Description                                                      |
|-----------------|------------------------------------------------------------------|
| UI available    | Permission to view service templates.                            |
| Add             | Permission to create service templates.                          |
| Duplicate       | Permission to duplicate service templates.                       |
| Edit            | Permission to edit service templates.                            |
| Delete          | Permission to delete service templates.                          |
| Apply           | Permission to apply service templates.                           |
| Reapply         | Permission to reapply a service template to a service.           |
| Detach          | Permission to detach a service from its parent service template. |
| Export          | Permission to export service templates.                          |

#### Services

| Cube permission                                | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
|------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available                                   | Available from DataMiner 9.6.5 onwards. Permission to view the *Services* module.                                                                                                                                                                                                                                                                                                                                                                        |
| Definitions \> Add                             | Available from DataMiner 9.6.5 onwards. Permission to add service definitions.                                                                                                                                                                                                                                                                                                                                                                                                          |
| Definitions \> Edit                            | Available from DataMiner 9.6.5 onwards. Permission to edit service definitions.                                                                                                                                                                                                                                                                                                                                                                                                         |
| Definitions \> Delete                          | Available from DataMiner 9.6.5 onwards. Permission to delete service definitions.                                                                                                                                                                                                                                                                                                                                                                                                       |
| Definitions \> Force updates                   | Available from DataMiner 9.6.5 onwards. Permission to force the execution of the following actions despite warnings:<br> -  Uploading, deleting, activating or deactivating a functions file.<br> -  Updating or deleting a service definition.<br> -  Deleting a protocol with functions. |
| Definitions \> Diagram \> Configure UI         | Available from DataMiner 9.6.5 onwards. Permission to configure service definitions using the diagram user interface.                                                                                                                                                                                                                                                                                                                                                                   |
| Definitions \> Diagram \> Configure data       | Available from DataMiner 9.6.5 onwards. Permission to configure the data for items in a service definition.                                                                                                                                                                                                                                                                                                                                                                             |
| Definitions \> Diagram \> Configure groups     | Available from DataMiner 9.6.5 onwards. Permission to configure groups in a service definition.                                                                                                                                                                                                                                                                                                                                                                                         |
| Definitions \> Diagram \> Properties \> Add    | Available from DataMiner 9.6.5 onwards. Permission to add properties to a node or interface of a service definition.                                                                                                                                                                                                                                                                                                                                                                    |
| Definitions \> Diagram \> Properties \> Edit   | Available from DataMiner 9.6.5 onwards. Permission to edit properties of a node or interface of a service definition.                                                                                                                                                                                                                                                                                                                                                                   |
| Definitions \> Diagram \> Properties \> Delete | Available from DataMiner 9.6.5 onwards. Permission to delete properties of a node or interface of a service definition.                                                                                                                                                                                                                                                                                                                                                                 |
| Definitions \> Properties \> Add               | Available from DataMiner 9.6.5 onwards. Permission to add properties to a service definition.                                                                                                                                                                                                                                                                                                                                                                                           |
| Definitions \> Properties \> Edit              | Available from DataMiner 9.6.5 onwards. Permission to edit properties of a service definition.                                                                                                                                                                                                                                                                                                                                                                                          |
| Definitions \> Properties \> Delete            | Available from DataMiner 9.6.5 onwards. Permission to delete properties of a service definition.                                                                                                                                                                                                                                                                                                                                                                                        |
| Definitions \> Actions \> Add                  | Available from DataMiner 9.6.5 onwards. Permission to add actions in the *Services* app. Obsolete from DataMiner 10.2.0/10.2.1 onwards.                                                                                                                                                                                                                                                                                |
| Definitions \> Actions \> Edit                 | Available from DataMiner 9.6.5 onwards. Permission to edit actions in the *Services* app. Obsolete from DataMiner 10.2.0/10.2.1 onwards.                                                                                                                                                                                                                                                                               |
| Definitions \> Actions \> Delete               | Available from DataMiner 9.6.5 onwards. Permission to delete actions in the *Services* app. Obsolete from DataMiner 10.2.0/10.2.1 onwards.                                                                                                                                                                                                                                                                             |
| Definitions \> Configure actions               | Available from DataMiner 10.2.0/10.2.1 onwards. Combines and replaces the previous *Actions* > *Add*/*Edit*/*Delete* permissions.                                                                                                                                                                                                                           |
| Profiles \> UI available                       | Permissions to access the *profiles* tab in the Services module. Available from DataMiner 10.0.9 onwards.                                                                                                                                                                                                                                                                                                                                                |
| Profiles \> Edit definitions                   | Permission to edit service profile definitions. Available from DataMiner 10.0.9 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards.                                                                                                                                                                                                                                                                                                                                              |
| Profiles \> Edit instances                     | Permission to edit service profile instances. Available from DataMiner 10.0.9 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards.                                                                                                                                                                                                                                                                                                                                                |
| Definitions \> Add/Edit                        | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit service profile definitions.                                                                                                                                                                                                                                                                                                                                                                                 |
| Definitions \> Delete                          | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete service profile definitions.                                                                                                                                                                                                                                                                                                                                                                                      |
| Instances \> Add/Edit                          | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit service profile instances.                                                                                                                                                                                                                                                                                                                                                                                   |
| Instances \> Delete                            | Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete profile instances.                                                                                                                                                                                                                                                                                                                                                                                                |

> [!NOTE]
> To export or import service profiles, you need to have permission to edit both service profile definitions and service profile instances.

#### System configuration \> Agents

| Cube permission         | Description                                                                                                                               |
|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|
| UI available            | Permission to access the Agents page.                                                                                                     |
| Add                     | Permission to add DataMiner Agents to the DMS.                                                                                            |
| Delete                  | Permission to remove DataMiner Agents from the DMS.                                                                                       |
| Switch Failover         | Permission to initiate a manual Failover.                                                                                                 |
| Configure Failover      | Permission to configure a pair of Failover DataMiner Agents.                                                                              |
| Change operator info    | Permission to change the *System info* for a DataMiner Agent.                                              |
| Start                   | Permission to (re)start DataMiner Agents.                                                                                                 |
| Stop                    | Permission to stop the DataMiner Agent software on DataMiner Agents.                                                                      |
| Shutdown                | Permission to shut down DataMiner Agents.                                                                                                 |
| Reboot                  | Permission to reboot DataMiner Agents.                                                                                                    |
| Change IP settings      | Permission to update the virtual IP address settings of a DataMiner Agent.                                                                |
| Change info             | Permission to update the *Name* and *Location* fields of a DataMiner Agent. |
| Add DMA to cluster      | Permission to add DataMiner Agents to DataMiner Systems (also known as “clusters”).                                                       |
| Delete DMA from cluster | Permission to remove DataMiner Agents from DataMiner Systems (also known as “clusters”).                                                  |
| Install App packages    | Permission to install DataMiner App packages (.dmapp).                                                                                    |
| Upgrade / restore       | Permission to upgrade DMAs (.dmupgrade, .zip) and to restore backups (.dmbackup).                                                         |

#### System configuration \> Security

| Cube permission                   | Description                                                                                                                                                                                                                                                                                                         |
|-----------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available                      | Permission to access the *Users / Groups* page in System Center.                                                                                                                                                                                                                     |
| Administrator                     | Permission to edit your own security settings, to import, create, update and delete groups, and to assign users to groups. If you only have this user permission, you will only be able to manage users from groups if you are a member of those groups yourself.                                                   |
| Specific \> Limited administrator | Permission to view all groups, to view/add/remove the users in groups of which you are a member yourself, and to modify your own user details (but not your group membership).                                                                                                                                      |
| Specific \> Edit other users      | Permission to edit the security settings of all users. This permission is intended to be used in combination with the *Administrator* or *Limited administrator* user permissions, so that you can also configure the users you are allowed to view.  |
| View users from other groups      | Permission to view users from other groups. This permission is intended to be used in combination with the *Administrator* and/or *Limited administrator* user permissions, so that you can also view users from groups that you are not a member of. |
| Group Settings \> Edit own groups | Permission to configure the groups you are a member of.                                                                                                                                                                                                                                                             |
| Group Settings \> Edit all groups | Permission to configure groups even if you are not a member of them.                                                                                                                                                                                                                                                |

> [!NOTE]
> -  The permission *Edit other users* can only be granted to users who have also been granted the *Administrator* permission or *Limited administrator*.
> -  The permission *View users from other groups* also determines whether you have access to public and protected alarm filters made by users from other groups.

#### System configuration \> Security \> Notifications / alerts

| Cube permission                    | Description                                                               |
|------------------------------------|---------------------------------------------------------------------------|
| UI available                       | Permission to access the Notifications user interface.                    |
| Configure email                    | Permission to manage your own email notifications.                        |
| Configure SMS                      | Permission to manage your own text message notifications.                 |
| Allow configuration of other users | Permission to manage email and text message notifications of other users. |

#### System configuration \> Backup

| Cube permission | Description                                            |
|-----------------|--------------------------------------------------------|
| UI available    | Permission to access the Backup page in System Center. |
| Configure       | Permission to configure the backup settings.           |

#### System configuration \> Cloud sharing/gateway

| Cube permission           | Description                                                                                                                                                                                                                                                                                        |
|---------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connect to cloud/DCP      | Available from DataMiner 10.1.0/10.0.9 onwards. Permission to connect a DMA to the DataMiner Cloud Platform.                                                                                                                                                                                       |
| Disconnect from cloud/DCP | Available from DataMiner 10.1.0/10.0.9 onwards. Permission to disconnect a DMA from the DataMiner Cloud Platform.                                                                                                                                                                                  |
| Configure gateway service | Available from DataMiner 10.2.0/10.1.4 onwards. Allows you to configure the gateway service even if you do not have the *Tools* > *Admin tools* permission.                                                                          |
| View shared items         | Available from DataMiner 10.1.0/10.0.9 onwards. Permission to view items that have been shared in the cloud. From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*.            |
| Update shared items       | Available from DataMiner 10.1.0/10.0.9 onwards. Permission to make changes to items that have been shared in the cloud. From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*. |
| Share item                | Available from DataMiner 10.1.0/10.0.9 onwards. Permission to share items in the cloud. From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*.                                 |
| Unshare item              | Available from DataMiner 10.1.0/10.0.9 onwards. Permission to stop sharing items in the cloud. From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*.                          |
| Account linking           | Only available in DataMiner 10.1.3. Permission to link a DataMiner account to a cloud account, which is necessary to be able to share items in the cloud or stop sharing items in the cloud.                                                                                                       |

> [!NOTE]
> These permissions support the cloud connected Agents feature, which is currently still in soft launch. See [Connecting your DataMiner System to the cloud](../../part_51/AboutCloudPlatform/Connecting_your_DataMiner_System_to_the_cloud.md).

#### System configuration \> Database

| Cube permission              | Description                                                                                                                       |
|------------------------------|-----------------------------------------------------------------------------------------------------------------------------------|
| UI available                 | Permission to access the Database page in System Center.                                                                          |
| Configure local/general DB   | Permission to change the settings of the general database. Prior to DataMiner 10.1.0/10.1.2, this is called the local database.   |
| Configure central/offload DB | Permission to change the settings of the offload database. Prior to DataMiner 10.1.0/10.1.1, this is called the central database. |

#### System configuration \> Indexing engine

| Cube permission | Description                                                                                                                                                                                                                            |
|-----------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Configure       | Permission to change the Indexing Engine configuration.                                                                                                                                                                                |
| UI available    | Permission to access Indexing-specific features, such as the search tab in the Alarm Console. Only displayed if *?EnableFeature=Indexing* is added to the Cube URL. Obsolete from DataMiner 10.0.7 onwards. |

#### System configuration \> Logging

| Cube permission | Description                                             |
|-----------------|---------------------------------------------------------|
| UI available    | Permission to access the Logging page in System Center. |
| Change settings | Permission to change the log file settings.             |
| Clear log files | Permission to clear the log file.                       |

#### System configuration \> Mobile Gateway

| Cube permission            | Description                                                                                                                                                                                                                                  |
|----------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| UI available               | Permission to access the *Mobile Gateway* page in System Center.                                                                                                                                              |
| Configure general settings | Permission to change the settings of the Mobile Gateway.                                                                                                                                                                                     |
| Configure commands         | Permission to manage the command list.                                                                                                                                                                                                       |
| Configure destinations     | Permission to manage the destination list.                                                                                                                                                                                                   |
| Configure remote users     | Permission to manage the list of remote users.                                                                                                                                                                                               |
| Load log file              | Only used in DataMiner versions prior to 6.5.3.                                                                                                                                                                                              |
| Clear log file             | Only used in DataMiner versions prior to 6.5.3.                                                                                                                                                                                              |
| Remove SMS from stack      | Permission to remove text messages from the SMS stack.                                                                                                                                                                                       |
| Reset GSM                  | Permission to reset the Mobile Gateway.                                                                                                                                                                                                      |
| Send SMS                   | Permission to send ad hoc text messages.                                                                                                                                                                                                     |
| Allow access to Mobile UI  | Permission to access the DataMiner web apps. Obsolete from DataMiner 10.1.0/10.1.2 onwards, where it is replaced by the permission *General* > *DataMiner Cube mobile access*. |

#### System configuration \> Object Manager

| Cube permission | Description                                                                                             |
|-----------------|---------------------------------------------------------------------------------------------------------|
| Module Settings | Available from DataMiner 10.1.5 onwards. Permission to change settings of the DataMiner Object Manager. |

#### System configuration \> SNMP Managers

| Cube permission | Description                                                                                      |
|-----------------|--------------------------------------------------------------------------------------------------|
| UI available    | Permission to access the *SNMP forwarding* page in System Center. |
| Add             | Permission to add SNMP Managers to the list.                                                     |
| Edit            | Permission to make changes to the configuration of the listed SNMP Managers.                     |
| Delete          | Permission to delete SNMP Managers from the list.                                                |
| Resend alarms   | Permission to resend history alarms to a particular SNMP Manager.                                |

#### System configuration \> System settings

| Cube permission           | Description                                                                                                                              |
|---------------------------|------------------------------------------------------------------------------------------------------------------------------------------|
| System settings available | Available from DataMiner 9.6.2 onwards. Permission to access the *System settings* page in System Center. |

#### System configuration \> System settings \> Credentials library

| Cube permission            | Description                                                                                                   |
|----------------------------|---------------------------------------------------------------------------------------------------------------|
| Add library credentials    | Available from DataMiner 9.5.4 onwards. Permissions to add predefined credentials in the credentials library. |
| Edit library credentials   | Available from DataMiner 9.5.4 onwards. Permissions to edit credentials in the credentials library.           |
| Delete library credentials | Available from DataMiner 9.5.4 onwards. Permissions to delete credentials from the credentials library.       |

#### System configuration \> Tools

| Cube permission                             | Description                                                                                                                                                                                                                         |
|---------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Synchronization / clean up unused           | Permission to access the *Tools* page in System Center. From DataMiner 10.1.0/10.1.1 onwards., this user permission is replaced by the *Admin tools* user permission. |
| Admin tools                                 | Available from DataMiner 10.1.0/10.1.1 onwards. Permission to use administrator tools such as synchronization, clean up unused and NATS management.                                                                                 |
| Control background tasks of all users       | Permission to see and control the background tasks of all users.                                                                                                                                                                    |
| Allow access to query executor              | Permission to execute SQL queries against the general or offload database.                                                                                                                                                          |
| Best practices analyzer \> Read             | Permission to read a BPA test. Available from DataMiner 10.0.9 onwards.                                                                                                                                                             |
| Best practices analyzer \> Add/Edit         | Permission to add or edit a BPA test. Available from DataMiner 10.0.9 onwards.                                                                                                                                                      |
| Best practices analyzer \> Delete           | Permission to delete a BPA test. Available from DataMiner 10.0.9 onwards.                                                                                                                                                           |
| Best practices analyzer \> Execute          | Permission to execute a BPA test. Available from DataMiner 10.0.9 onwards.                                                                                                                                                          |
| Best practices analyzer \> Get test results | Permission to retrieve the results of a BPA test. Available from DataMiner 10.0.9 onwards.                                                                                                                                          |

#### Ticketing Gateway

| Cube permission | Description                                                                      |
|-----------------|----------------------------------------------------------------------------------|
| UI available    | Permission to access the *Ticketing Gateway* app. |
| Add             | Permission to add tickets.                                                       |
| Edit            | Permission to edit tickets.                                                      |
| Delete          | Permission to delete tickets.                                                    |
| Configure       | Permission to configure ticket domains.                                          |

#### Trending

| Cube permission | Description                                                           |
|-----------------|-----------------------------------------------------------------------|
| Trending app    | Permission to access the Trending module.                             |
| View Trending   | Permission to view trend graphs of parameters that are being trended. |
| View Histogram  | Permission to view histograms of parameters that are being trended.   |

### Other

| Cube permission      | Description                                                               |
|----------------------|---------------------------------------------------------------------------|
| View Element Manager | Permission to use the EPM module. (Only available up to DataMiner 9.5.3.) |

### Legacy

> [!NOTE]
> -  This category contains all user permissions that are only relevant for the legacy System Display application. To view these user permissions, right-click the list of user permissions and select *Show legacy rights*.
> -  From DataMiner 9.6.0 onwards, this category is no longer available, as the System Display application is no longer available from that DataMiner version onwards.

| Cube permission       | Description                                                                                      |
|-----------------------|--------------------------------------------------------------------------------------------------|
| View Element Manager  | Permission to use the EPM module.                                                                |
| Dashboard Overview    | Permission to access the DMS Dashboards module in System Display.                                |
| Report Overview       | Permission to access the DMS Reports module in System Display.                                   |
| Manage views          | Permission to access the *Admin \> Views* page of System Display. |
| Assign Visio drawings | Permission to access the *Admin \> Views* page of System Display. |
