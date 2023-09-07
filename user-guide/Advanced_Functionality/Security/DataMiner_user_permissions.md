---
uid: DataMiner_user_permissions
---

# DataMiner user permissions

In the System Center module, the user permissions have been divided into two main groups: *General* and *Modules*. Below is an overview of the different permissions.

> [!NOTE]
>
> - To quickly find a particular user permission in System Center, use the filter box in the top-right corner of the list of permissions.
> - Some of these user permissions are only available if the DMA has the correct licenses and configuration, so that the user permissions are relevant.
> - For many permissions, it makes no sense to grant them unless you grant the corresponding *UI Available* permission as well.

## General

### General \> Surveyor available

Permission to access the Surveyor.

### General \> Data overview available

This permission allows users to access data pages of cards.

Prior to DataMiner 9.6.6, it allows users to access data pages of view cards.

> [!NOTE]
> As soon as this permission or the *View data overview available* permission is granted, the user will have access to data pages of view cards. To hide access to data pages of view cards, neither of these permissions should be granted.

### General \> View data overview available

Permission to access data pages of view cards.

### General \> DataMiner web apps / DataMiner Cube mobile access

The *DataMiner web apps* user permission (or *DataMiner Cube mobile access* prior to DataMiner 10.1.0 \[CU5\]/10.1.8) allows users to access the DataMiner web apps.

This user permission is available from DataMiner 10.1.0/10.1.2 onwards.

>[!NOTE]
> To access the Monitoring app, from DataMiner 10.2.0/10.2.2 onwards, the permission [Modules > Monitoring web app](#modules--monitoring-web-app) is needed.

### General \> Element list available

Permission to access Data pages of cards. This user permission is deprecated from DataMiner 9.6.6 onwards.

> [!NOTE]
> As soon as this permission or the *Data overview available* permission is granted, the user will have access to Data pages of view cards. To hide access to Data pages of view cards, neither of these permissions should be granted.

### General \> Elements

#### General \> Elements \> Access

Permission to access element cards.

#### General \> Elements \> Add

Permission to create elements.

#### General \> Elements \> Edit

Permission to update elements.

#### General \> Elements \> Delete

Permission to delete elements.

#### General \> Elements \> Import CSV

Permissions to import elements from CSV files.

#### General \> Elements \> Import DELT

Permission to import \.dmimport packages.

> [!NOTE]
> DELT stands for *DataMiner Element Location Transparency*. It is the feature that allows the exporting and importing of packages as well as migration of elements across DMAs in a cluster.

#### General \> Elements \> Export DELT

Permission to export \.dmimport packages.

> [!NOTE]
> DELT stands for *DataMiner Element Location Transparency*. It is the feature that allows the exporting and importing of packages as well as migration of elements across DMAs in a cluster.

#### General \> Elements \> Properties \> Add

Permission allows users to create element properties.

#### General \> Elements \> Properties \> Edit

Permission allows users to change the value of element properties.

#### General \> Elements \> Properties \> Delete

Permission allows users to delete element properties.

#### General \> Elements \> Lock / unlock

Permission to lock and unlock an element.

#### General \> Elements \> Force unlock

Permission to unlock an element that has been locked by another user.

#### General \> Elements \> Start

Permission to start elements.

#### General \> Elements \> Stop

Permission to stop elements.

#### General \> Elements \> Pause

Permission to pause elements.

#### General \> Elements \> Restart

Permission to restart elements.

>[!NOTE]
> If users have both the *Start* and *Stop* permission, they can restart elements regardless of the *Restart* permission.

#### General \> Elements \> Mask until clearance / for x time

Permission to mask elements until they are cleared or for a specific time.

#### General \> Elements \> Mask until unmasking

Permission to mask elements until they are unmasked.

#### General \> Elements \> Allow unmasking

Permission to unmask elements.

#### General \> Elements \> Simulation available

Permission to enable or disable element simulations.

#### General \> Elements \> Data Display \> Access

Permission to access the data pages of an element card.

#### General \> Elements \> Data Display \> Device webpage access

Available from DataMiner 9.5.7 onwards. Permission to access the webpage of the device in the data pages.

#### General \> Elements \> Data Display \> View write parameters

Permission to view write parameters on data pages.

#### General \> Elements \> Data Display \> Configure matrix options

Permission to configure a matrix parameter.

#### General \> Elements \> Data Display \> Spectrum \> Configure measurement points

Permission to configure measurements points for a Spectrum Analyzer Element.

#### General \> Elements \> Data Display \> Spectrum \> Configure scripts & monitors

Permission to manage spectrum scripts and spectrum monitors.

#### General \> Elements \> Data Display \> Spectrum \> Edit / delete protected presets

Permission to update and delete protected spectrum analyzer presets.

#### General \> Elements \> Data Display \> Spectrum \> Take device from other client

Permission to terminate a spectrum client sessions of another user in order to start a session yourself, in case the maximum number of concurrent client sessions is limited.

>[!NOTE]
> This feature is no longer available from DataMiner 9.6.0 onwards.

#### General \> Elements \> Data Display \> Spectrum \> Take priority over monitors

Permission to temporarily take priority over spectrum monitors.

### General \> Services

#### General \> Services \> Add

Permission to create services.

#### General \> Services \> Edit

Permission to edit services.

#### General \> Services \> Delete

Permission to delete services.

#### General \> Services \> Properties \> Add

Permission to create service properties.

#### General \> Services \> Properties \> Edit

Permission to change the value of service properties.

#### General \> Services \> Properties \> Delete

Permission to delete service properties.

#### General \> Services \> Data Display \> Access

Permission to access the data pages of a service.

### General \> Views

#### General \> Views \> Add / remove elements

Permission to add and remove elements and services to and from views.

#### General \> Views \> Add / remove views

Permission to add and remove views.

#### General \> Views \> Properties \> Add

Permission to create view properties.

#### General \> Views \> Properties \> Edit

Permission to change the value of view properties.

#### General \> Views \> Properties \> Delete

Permission to delete view properties.

### General \> Redundancy groups

#### General \> Redundancy groups \> Add

Permission to create redundancy groups.

#### General \> Redundancy groups \> Edit

Permission to update redundancy groups.

#### General \> Redundancy groups \> Delete

Permission to delete redundancy groups.

#### General \> Redundancy groups \> Advanced \> Change redundancy mode

Permission to change the redundancy mode (automatic, manual, manual switchback) of a redundancy group (software redundancy only).

#### General \> Redundancy groups \> Advanced \> Manual switch

Permission to initiate a manual switchover (software redundancy only).

#### General \> Redundancy groups \> Advanced \> Set element in maintenance

Permission to set an element in maintenance.

#### General \> Redundancy groups \> Advanced \> Configure elements in redundancy templates

Permission to configure the elements in a redundancy group that was created as a redundancy group template.

#### General \> Redundancy groups \> Advanced \> Configure automatic switching

Permission to use the automatic switching option when working with redundancy groups.

### General \> Alarms

#### General \> Alarms \> Alarm Console available

Permission to access the Alarm Console.

#### General \> Alarms \> Allow masking

Permission to mask alarms.

#### General \> Alarms \> Allow unmasking

Permission to unmask alarms.

#### General \> Alarms \> Allow take & release ownership

Permission to take ownership of alarms and to release that ownership.

#### General \> Alarms \> Release ownership of another user

Permission to release ownership of alarms owned by other users.

#### General \> Alarms \> Allow viewing of system events

Permission to view system events in the Alarm Console.

#### General \> Alarms \> Extended context menu Alarm Console

Permission to access the Alarm Console shortcut menu.

#### General \> Alarms \> Extended view menu Alarm Console

Permission to access the *Open* submenu of the Cube Alarm Console shortcut menu.

#### General \> Alarms \> Edit / delete protected filters

Permission to update and/or delete protected filters created by another user.

#### General \> Alarms \> Properties \> Add

Permission to add properties to alarms.

#### General \> Alarms \> Properties \> Edit

Permission to change the value of alarm properties.

#### General \> Alarms \> Properties \> Delete

Permission to delete properties from alarms.

#### General \> Alarms \> Audible alert \> Add audio files

Permission to add audio files that can be used for audible alerts.

#### General \> Alarms \> Audible alert \> Edit audio files

Permission to edit audio files that can be used for audible alerts.

#### General \> Alarms \> Audible alert \> Delete audio files

Permission to delete audio files that can be used for audible alerts.

### General \> Workspaces

#### General \> Workspaces \> Add

Permission to create workspaces.

#### General \> Workspaces \> Delete

Permission to delete workspaces.

### General \> Annotations

> [!NOTE]
> From DataMiner 10.1.12 onwards, annotations can be disabled using the soft-launch option *LegacyAnnotations*. See [Soft-launch options](xref:SoftLaunchOptions).

#### General \> Annotations \> View

Permission to view annotations.

#### General \> Annotations \> Edit

Permission to add and update annotations.

#### General \> Annotations \> View Notes

Permission to view DataMiner Notes.

### General \> Visual Overview

#### General \> Visual Overview \> Access Visual Overviews

Permission to access Visual Overview.

#### General \> Visual Overview \> Advanced navigation

Permission to navigate from one Visual Overview page to another by clicking shapes that act as hyperlinks.

#### General \> Visual Overview \> Download Visio drawings

Permission to download a Visio file from the DataMiner System to the client computer.

#### General \> Visual Overview \> Edit Visio drawings

Permission to change Visio files using the embedded Visio file editor.

### General \> Collaboration

#### General \> Collaboration \> UI available

Permission to start chat sessions.

This permission is included in all presets except *No rights*.

#### General \> Collaboration \> Disconnect other users

Permission to end chat sessions of other users.

### General \> Software updates \> Download software updates from DCP

Permission to download software from dataminer.services.

### General \> Live sharing

#### General \> Live sharing \> UI available

Available from DataMiner 10.2.0/10.1.4 onwards. Permission to view the sharing UI and to view items that have been shared via dataminer.services. (Available as *Modules* > *System configuration* > *Cloud gateway* > *View shared items* in earlier DataMiner versions.)

#### General \> Live sharing \> Share

Available from DataMiner 10.2.0/10.1.4 onwards. Permission to share items via dataminer.services. (Available as *Modules* > *System configuration* > *Cloud gateway* > *Share item* in earlier DataMiner versions.)

#### General \> Live sharing \> Edit

Available from DataMiner 10.2.0/10.1.4 onwards. Permission to make changes to items shared via dataminer.services. (Available as *Modules* > *System configuration* > *Cloud gateway* > *Update shared items* in earlier DataMiner versions.)

#### General \> Live sharing \> Unshare

Available from DataMiner 10.2.0/10.1.4 onwards. Permission to stop sharing items via dataminer.services. (Available as *Modules* > *System configuration* > *Cloud gateway* > *Unshare item* in earlier DataMiner versions.)

### General \> Email \> Send via DataMiner System

Available from DataMiner 10.2.0/10.1.10 onwards. Permission to send emails via the DataMiner System.

## Modules

### Modules \> API

These user permissions are used for the API deployment feature. This is a deprecated [soft launch feature](xref:SoftLaunchOptions).

>[!NOTE]
> This feature has been marked obsolete from DataMiner version 10.3.6 onwards. It has been replaced by the [User-Defined APIs](xref:UD_APIs) feature and will be removed in the future.

#### Modules \> API \> Deploy script API

Permission to deploy an API to a script.

#### Modules \> API \> View deployed APIs

Permission to view the APIs that have been deployed.

#### Modules \> API \> Undeploy script API

Permission to stop an API from being deployed to a script.

#### Modules \> API \> Create and update API access token

Permission to create and update an API access token.

#### Modules \> API \> View API access token

Permission to view an API access.

### Modules \> Asset Manager

Permission to use the Asset Manager module.

### Modules \> Automation

#### Modules \> Automation \> UI available

Permission to access the Automation module.

#### Modules \> Automation \> Add

Permission to create or import Automation scripts.

#### Modules \> Automation \> Edit

Permission to update or export Automation scripts.

#### Modules \> Automation \> Delete

Permission to delete Automation scripts.

#### Modules \> Automation \> Execute

Permission to execute Automation scripts.

### Modules \> Bookings

> [!NOTE]
> To access the *Bookings* module, you also need the appropriate licenses. For more information on acquiring licenses, contact the Skyline Sales department.

#### Modules \> Bookings \> UI available

Available from DataMiner 9.6.7 onwards. Permission to access the *Bookings* module. Prior to DataMiner 9.6.7, this module is called the *Reservations* module.

#### Modules \> Bookings \> Add

Available from DataMiner 9.6.7 onwards. Permission to add bookings.

#### Modules \> Bookings \> Edit

Available from DataMiner 9.6.7 onwards. Permission to edit bookings.

#### Modules \> Bookings \> Delete

Available from DataMiner 9.6.7 onwards. Permission to delete bookings.

#### Modules \> Bookings \> Execute

Available from DataMiner 9.6.7 onwards. Permission to execute Automation scripts or parameter sets linked to bookings, e.g. scripts that are linked to booking events, or custom context menu items for bookings.

### Modules \> Correlation

#### Modules \> Correlation \> UI available

Permission to access the Correlation module.

#### Modules \> Correlation \> Add

Permission to create Correlation rules.

#### Modules \> Correlation \> Edit

Permission to update Correlation rules.

#### Modules \> Correlation \> Delete

Permission to delete Correlation rules. |

### Modules \> Documents

#### Modules \> Documents \> UI available

Permission to access the DataMiner Documents user interface.

#### Modules \> Documents \> Add

Permission to upload documents.

#### Modules \> Documents \> Edit

Permission to change the title of an uploaded document as well as the comments that are linked to it.

#### Modules \> Documents \> Delete

Permission to delete uploaded documents.

### Modules \> Element Connections

Permission to use view and configure element connections.

### Modules \> Functions

> [!NOTE]
>
> - At present, these permissions are used for the uploading and deleting of functions in the Protocols & Templates app, and for the use of the Functions app. However, the latter is currently still in soft launch. For more information, see [Soft-launch options](xref:SoftLaunchOptions).
> - When you upgrade to DataMiner version 10.1.7, these six permissions are automatically granted to all user groups that have been granted the *Modules* > *Resources* > *Configure functions* permission.
> - These user permissions are only displayed if the DMA uses an Elasticsearch database.

#### Modules \> Functions \> Read

 Permission to view the Functions app. Available from DataMiner 10.2.0/10.1.7 onwards.

#### Modules \> Functions \> Add

 Permission to add virtual functions. Available from DataMiner 10.2.0/10.1.7 onwards.

#### Modules \> Functions \> Edit

 Permission to edit virtual functions. Available from DataMiner 10.2.0/10.1.7 onwards.

#### Modules \> Functions \> Delete

Permission to delete virtual functions. Available from DataMiner 10.2.0/10.1.7 onwards.

#### Modules \> Functions \> Configure

Permission to edit virtual functions. Available from DataMiner 10.2.0/10.1.7 onwards.

#### Modules \> Functions \> Generate protocol

 Permission to generate a protocol for a virtual function. Available from DataMiner 10.2.0/10.1.7 onwards.

### Modules \> Jobs

> [!NOTE]
> These user permissions are only displayed if the DMA uses an Elasticsearch database.

#### Modules \> Jobs \> UI available

 Permission to view the Jobs app in Cube. Available from DataMiner 9.6.4 onwards.

#### Modules \> Jobs \> Add/Edit

Permission to add or edit jobs. Available from DataMiner 9.6.4 onwards.

#### Modules \> Jobs \> Delete

Permission to delete jobs. Available from DataMiner 9.6.4 onwards.

#### Modules \> Jobs \> Configure domains

 Permission to configure a domain in the Jobs app. Available from DataMiner 9.6.4 onwards.

### Modules \> Monitoring web app

Permission to use the Monitoring app. Available from DataMiner 10.2.0/10.2.2 onwards.

### Modules \> Planned Maintenance

> [!NOTE]
> These user permissions are only displayed if the DMA uses an Elasticsearch database.

#### Modules \> Planned Maintenance \> UI available

Permission to view the Planned Maintenance (PLM) app in Cube. Available from DataMiner 10.2.0/10.1.2 onwards.

#### Modules \> Planned Maintenance \> Add/Edit

Permission to add or edit items in the PLM app. Available from DataMiner 10.2.0/10.1.2 onwards.

#### Modules \> Planned Maintenance \> Delete

Permission to delete items in the PLM app. Available from DataMiner 10.2.0/10.1.2 onwards.

#### Modules \> Planned Maintenance \> Configure

Permission to configure the PLM app. Available from DataMiner 10.2.0/10.1.2 onwards.

### Modules \> Process Automation

#### Modules \> Process Automation \> Read

Permission to read items in the Process Automation framework. Available from DataMiner 10.2.0/10.1.12 onwards.

#### Modules \> Process Automation \> Add/Edit

Permission to add or edit items in the Process Automation framework. Available from DataMiner 10.2.0/10.1.12 onwards.

#### Modules \> Process Automation \> Delete

Permission to delete items in the Process Automation framework. Available from DataMiner 10.2.0/10.1.12 onwards.

### Modules \> Profile Manager

These user permissions are deprecated from DataMiner 9.6.5 onwards. Use the user permissions under [Profiles](#modules--profiles) instead.

#### Modules \> Profile Manager \> UI available

Permission to view the Profile Manager module in Cube.

#### Modules \> Profile Manager \> Edit all

Permission to edit all items in the Profile Manager.

#### Modules \> Profile Manager \> Edit instances

Permission to edit instances.

### Modules \> Profiles

#### Modules \> Profiles \> UI available

Available from DataMiner 9.6.5 onwards. Permission to view the *Profiles* module in Cube.

#### Modules \> Profiles \> Edit all

Available from DataMiner 9.6.5 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards. Permission to edit all items in the *Profiles*.

#### Modules \> Profiles \> Edit instances

Available from DataMiner 9.6.5 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards. Permission to edit instances.

#### Modules \> Profiles \> All except instances \> Add/Edit

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit profiles, but not profile instances.

#### Modules \> Profiles \> All except instances \> Delete

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete profiles, but not profile instances.

#### Modules \> Profiles \> Instances \> Add/Edit

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit profile instances.

#### Modules \> Profiles \> Instances \> Delete

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete profile instances.

#### Modules \> Profiles \> Configure

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to configure the Profile Manager (server-side only).

### Modules \> Protocols & Templates \> Protocols

#### Modules \> Protocols & Templates \> Protocols \> UI available

Permission to access the DataMiner protocols user interface.

#### Modules \> Protocols & Templates \> Protocols \> Add

Permission to add DataMiner protocols.

#### Modules \> Protocols & Templates \> Protocols \> Edit

Permission to edit DataMiner protocols.

#### Modules \> Protocols & Templates \> Protocols \> Delete

Permission to delete DataMiner protocols.

#### Modules \> Protocols & Templates \> Protocols \> Download protocols from DCP

Permission to download protocols from the DataMiner Collaboration Platform.

#### Modules \> Protocols & Templates \> Protocols \> Generate MIB

Permission to generate SNMP MIB files based on DataMiner protocols.

### Modules \> Protocols & Templates \> Alarm templates

#### Modules \> Protocols & Templates \> Alarm templates \> UI available

Permission to access the alarm templates user interface.

#### Modules \> Protocols & Templates \> Alarm templates \> Add

Permission to create alarm templates. Prior to DataMiner 10.2.0/10.2.3, this user permission is called "Add alarm templates".

#### Modules \> Protocols & Templates \> Alarm templates \> Edit

Permission to update alarm templates. Prior to DataMiner 10.2.0/10.2.3, this user permission is called "Edit alarm templates".

#### Modules \> Protocols & Templates \> Alarm templates \> Delete

Permission to delete alarm templates. Prior to DataMiner 10.2.0/10.2.3, this user permission is called "Delete alarm templates".

### Modules \> Protocols & Templates \> Trend templates

#### Modules \> Protocols & Templates \> Trend templates \> UI available

Permission to access the trend templates user interface.

#### Modules \> Protocols & Templates \> Trend templates \> Configure trend templates

Permission to edit trend templates.

### Modules \> Reports & Dashboards \> Reports

#### Modules \> Reports & Dashboards \> Reports \> View reports

Permission to view reports.

#### Modules \> Reports & Dashboards \> Reports \> Manage mail templates

Permission to manage reporter templates.

### Modules \> Reports & Dashboards \> Dashboards

#### Modules \> Reports & Dashboards \> Dashboards \> View dashboards

Permission to view dashboards.

#### Modules \> Reports & Dashboards \> Dashboards \> Add

Permission to create dashboards.

#### Modules \> Reports & Dashboards \> Dashboards \> Edit

Permission to update dashboards.

#### Modules \> Reports & Dashboards \> Dashboards \> Delete

Permission to delete dashboards.

### Modules \> Reservations

These user permissions are deprecated from DataMiner 9.6.7 onwards.

> [!NOTE]
> To access the *Bookings* module (formerly known as the *Reservations* module), you also need the appropriate licenses. For more information on acquiring licenses, contact the Skyline Sales department.

#### Modules \> Reservations \> UI available

Permission to access the *Reservations* module.

#### Modules \> Reservations \> Add

Permission to add bookings.

#### Modules \> Reservations \> Edit

Permission to edit bookings.

#### Modules \> Reservations \> Delete

Permission to delete bookings.

#### Modules \> Reservations \> Execute

Permission to execute bookings.

### Modules \> Resources

> [!NOTE]
> To access the *Resources* module, you also need the appropriate licenses. For more information on acquiring licenses, contact the Skyline Sales department.

#### Modules \> Resources \> UI available

Available from DataMiner 9.6.5 onwards. Permission to access the *Resources* module (previously known as the *Resource Manager* module).

#### Modules \> Resources \> Add

Available from DataMiner 9.6.5 onwards. Permission to add pools and resources.

#### Modules \> Resources \> Edit \> Resource status

Available from DataMiner 9.6.5 onwards. Permission to edit the status of a resource.

#### Modules \> Resources \> Edit \> Other

Available from DataMiner 9.6.5 onwards. Permission to edit pools and resources.

#### Modules \> Resources \> Delete

Available from DataMiner 9.6.5 onwards. Permission to delete pools and resources.

#### Modules \> Resources \> Configure functions

Available from DataMiner 9.6.5 onwards. Permission to add functions as resources.

### Modules \> Resource Manager

These user permissions are deprecated from DataMiner 9.6.7 onwards.

> [!NOTE]
> - In order to access the *Resource Manager* or *Reservations* module, you also need to have the Resource Manager license. For more information on acquiring a Resource Manager license, contact the Skyline Sales department.
> - In DataMiner 9.6.4, the Resource Manager permissions are available under *Modules* > *Service & Resource Management* > *Resources* and *Reservations*. In later versions, the user permissions within this block are available under *Modules* > *Resources and Modules* > *Reservations/Bookings*.

#### Modules \> Resource Manager \> Pools & Resources \> UI available

Permission to access the *Resource Manager* module.

#### Modules \> Resource Manager \> Pools & Resources \> Add

Permission to add pools and resources.

#### Modules \> Resource Manager \> Pools & Resources \> Edit \> Resource status

Permission to edit the status of resources.

#### Modules \> Resource Manager \> Pools & Resources \> Edit \> Other

Permission to edit pools and resources.

#### Modules \> Resource Manager \> Pools & Resources \> Delete

Permission to delete pools and resources.

#### Modules \> Resource Manager \> Pools & Resources \> Configure functions

Available from DataMiner 9.5.4 onwards. Permission to add functions as resources.

#### Modules \> Resource Manager \> Reservations \> UI available

Permission to access the *Reservations* app. Prior to DataMiner 9.6.5, this permission is called *Timeline UI available*.

#### Modules \> Resource Manager \> Reservations \> Add

Permission to add reservations.

#### Modules \> Resource Manager \> Reservations \> Edit

Permission to edit reservations.

#### Modules \> Resource Manager \> Reservations \> Delete

Permission to delete reservations.

#### Modules \> Resource Manager \> Reservations \> Execute

Permission to execute reservations.

### Modules \> Router Control

#### Modules \> Router Control \> UI available

Permission to access the Router Control module.

#### Modules \> Router Control \> Configuration

Permission to use the Router Control module.

### Modules \> Scheduler

#### Modules \> Scheduler \> UI available

Permission to access the Scheduler module.

#### Modules \> Scheduler \> Add

Permission to create tasks.

#### Modules \> Scheduler \> Edit

Permission to update tasks.

#### Modules \> Scheduler \> Delete

Permission to delete tasks.

#### Modules \> Scheduler \> Execute

Permission to execute tasks.

### Modules \> Service & Resource Management \> Profiles

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available under *Modules* > *Profiles*.

#### Modules \> Service & Resource Management \> Profiles \> UI available

Permission to view the *Profiles* module in Cube.

#### Modules \> Service & Resource Management \> Profiles \> Edit all

Permission to edit all items in the *Profiles*.

#### Modules \> Service & Resource Management \> Profiles \> Edit instances

Permission to edit instances.

### Modules \> Service & Resource Management \> Resources

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available under *Modules* > *Profiles*.

#### Modules \> Service & Resource Management \> Resources \> UI available

Permission to access the *Resources* tab of the *Scheduler* module in Cube.

#### Modules \> Service & Resource Management \> Resources \> Add

Permission to add pools and resources.

#### Modules \> Service & Resource Management \> Resources \> Edit \> Resource status

Permission to edit the status of resources.

#### Modules \> Service & Resource Management \> Resources \> Edit \> Other

Permission to edit pools and resources.

#### Modules \> Service & Resource Management \> Resources \> Delete

Permission to delete pools and resources.

#### Modules \> Service & Resource Management \> Resources \> Configure functions

Permission to add functions as resources.

### Modules \> Service & Resource Management \> Reservations

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available directly under *Modules* > *Reservations/Bookings*.

#### Modules \> Service & Resource Management \> Reservations \> Timeline UI available

Permission to access the *Reservations* module.

#### Modules \> Service & Resource Management \> Reservations \> Add

Permission to add reservations.

#### Modules \> Service & Resource Management \> Reservations \> Edit

Permission to edit reservations.

#### Modules \> Service & Resource Management \> Reservations \> Delete

Permission to delete reservations.

#### Modules \> Service & Resource Management \> Reservations \> Execute

Permission to execute reservations.

### Modules \> Service & Resource Management \> Services

> [!NOTE]
> The Service & Resource Management block of user permissions is only available in DataMiner 9.6.4. In later versions, the user permissions within this block are available directly under *Modules* > *Services*.

#### Modules \> Service & Resource Management \> Services \> UI available

Permission to view the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Add

Permission to add definitions in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Edit

Permission to edit definitions in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Delete

Permission to delete definitions in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Diagram \> Configure UI

Permission to configure service definitions using the diagram user interface.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Diagram \> Configure data

Permission to configure the data for items in the *Services* diagram.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Diagram \> Configure groups

Permission to configure groups in the *Services* diagram.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Diagram \> Properties \> Add

Permission to add properties in the *Services* diagram.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Diagram \> Properties \> Edit

Permission to edit properties in the *Services* diagram.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Diagram \> Properties \> Delete

Permission to delete properties in the *Services* diagram.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Properties \> Add

Permission to add properties in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Properties \> Edit

Permission to edit properties in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Properties \> Delete

Permission to delete properties in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Actions \> Add

Permission to add actions in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Actions \> Edit

Permission to edit actions in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Actions \> Delete

Permission to delete actions in the *Services* module.

#### Modules \> Service & Resource Management \> Services \> Definitions \> Force updates

Available from DataMiner 9.5.14 onwards. Permission to force the execution of the following actions despite warnings:

- Uploading, deleting, activating or deactivating a functions file.

- Updating or deleting a service definition.

- Deleting a protocol with functions.

### Modules \> Service Manager

> [!NOTE]
> In DataMiner 9.6.4, the Service Manager permissions are available under *Modules* > *Service & Resource Management* > *Services*. In later versions, the user permissions within this block are available under *Modules* > *Services*.

#### Modules \> Service Manager \> UI available

Permission to view the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Add

Permission to add definitions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Edit

Permission to edit definitions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Delete

Permission to delete definitions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Diagram \> Configure UI

Permission to configure service definitions using the diagram user interface. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Diagram \> Configure data

Permission to configure the data for items in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Diagram \> Configure groups

Permission to configure groups in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Diagram \> Properties \> Add

Permission to add properties in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Diagram \> Properties \> Edit

Permission to edit properties in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Diagram \> Properties \> Delete

Permission to delete properties in the Service Manager diagram. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Properties \> Add

Permission to add properties in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Properties \> Edit

Permission to edit properties in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Properties \> Delete

Permission to delete properties in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Actions \> Add

Permission to add actions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Actions \> Edit

Permission to edit actions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Actions \> Delete

Permission to delete actions in the Service Manager module. Deprecated from DataMiner 9.6.4 onwards.

#### Modules \> Service Manager \> Definitions \> Force updates

Available from DataMiner 9.5.14 onwards. Deprecated from DataMiner 9.6.4 onwards.

Permission to force the execution of the following actions despite warnings:

- Uploading, deleting, activating or deactivating a functions file.

- Updating or deleting a service definition.

- Deleting a protocol with functions.

### Modules \> Service templates

#### Modules \> Service templates \> UI available

Permission to view service templates.

#### Modules \> Service templates \> Add

Permission to create service templates.

#### Modules \> Service templates \> Duplicate

Permission to duplicate service templates.

#### Modules \> Service templates \> Edit

Permission to edit service templates.

#### Modules \> Service templates \> Delete

Permission to delete service templates.

#### Modules \> Service templates \> Apply

Permission to apply service templates.

#### Modules \> Service templates \> Reapply

Permission to reapply a service template to a service.

#### Modules \> Service templates \> Detach

Permission to detach a service from its parent service template.

#### Modules \> Service templates \> Export

Permission to export service templates.

### Modules \> Services

> [!NOTE]
> To export or import service profiles, you need to have permission to edit both service profile definitions and service profile instances.

#### Modules \> Services \> UI available

Available from DataMiner 9.6.5 onwards. Permission to view the *Services* module.

#### Modules \> Services \> Definitions \> Add

Available from DataMiner 9.6.5 onwards. Permission to add service definitions.

#### Modules \> Services \> Definitions \> Edit

Available from DataMiner 9.6.5 onwards. Permission to edit service definitions.

#### Modules \> Services \> Definitions \> Delete

Available from DataMiner 9.6.5 onwards. Permission to delete service definitions.

#### Modules \> Services \> Definitions \> Force updates

Available from DataMiner 9.6.5 onwards. Permission to force the execution of the following actions despite warnings:

- Uploading, deleting, activating or deactivating a functions file.

- Updating or deleting a service definition.

- Deleting a protocol with functions.

#### Modules \> Services \> Definitions \> Diagram \> Configure UI

Available from DataMiner 9.6.5 onwards. Permission to configure service definitions using the diagram user interface.

#### Modules \> Services \> Definitions \> Diagram \> Configure data

Available from DataMiner 9.6.5 onwards. Permission to configure the data for items in a service definition.

#### Modules \> Services \> Definitions \> Diagram \> Configure groups

Available from DataMiner 9.6.5 onwards. Permission to configure groups in a service definition.

#### Modules \> Services \> Definitions \> Diagram \> Properties \> Add

Available from DataMiner 9.6.5 onwards. Permission to add properties to a node or interface of a service definition.

#### Modules \> Services \> Definitions \> Diagram \> Properties \> Edit

Available from DataMiner 9.6.5 onwards. Permission to edit properties of a node or interface of a service definition.

#### Modules \> Services \> Definitions \> Diagram \> Properties \> Delete

Available from DataMiner 9.6.5 onwards. Permission to delete properties of a node or interface of a service definition.

#### Modules \> Services \> Definitions \> Properties \> Add

Available from DataMiner 9.6.5 onwards. Permission to add properties to a service definition.

#### Modules \> Services \> Definitions \> Properties \> Edit

Available from DataMiner 9.6.5 onwards. Permission to edit properties of a service definition.

#### Modules \> Services \> Definitions \> Properties \> Delete

Available from DataMiner 9.6.5 onwards. Permission to delete properties of a service definition.

#### Modules \> Services \> Definitions \> Actions \> Add

Available from DataMiner 9.6.5 onwards. Permission to add actions in the *Services* app. Obsolete from DataMiner 10.2.0/10.2.1 onwards.

#### Modules \> Services \> Definitions \> Actions \> Edit

Available from DataMiner 9.6.5 onwards. Permission to edit actions in the *Services* app. Obsolete from DataMiner 10.2.0/10.2.1 onwards.

#### Modules \> Services \> Definitions \> Actions \> Delete

Available from DataMiner 9.6.5 onwards. Permission to delete actions in the *Services* app. Obsolete from DataMiner 10.2.0/10.2.1 onwards.

#### Modules \> Services \> Definitions \> Configure actions

Available from DataMiner 10.2.0/10.2.1 onwards. Combines and replaces the previous *Actions* > *Add*/*Edit*/*Delete* permissions.

#### Modules \> Services \> Profiles \> UI available

Permissions to access the *profiles* tab in the Services module. Available from DataMiner 10.0.9 onwards.

#### Modules \> Services \> Profiles \> Edit definitions

Permission to edit service profile definitions. Available from DataMiner 10.0.9 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards.

#### Modules \> Services \> Profiles \> Edit instances

Permission to edit service profile instances. Available from DataMiner 10.0.9 onwards. Deprecated from DataMiner 10.2.0/10.1.12 onwards.

#### Modules \> Services \> Profiles \> Definitions \> Add/Edit

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit service profile definitions.

#### Modules \> Services \> Profiles \> Definitions \> Delete

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete service profile definitions.

#### Modules \> Services \> Instances \> Add/Edit

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to add or edit service profile instances.

#### Modules \> Services \> Instances \> Delete

Available from DataMiner 10.2.0/10.1.12 onwards. Permission to delete profile instances.

### Modules \> System configuration \> Agents

#### Modules \> System configuration \> Agents \> UI available

Permission to access the Agents page.

#### Modules \> System configuration \> Agents \> Add

Permission to add DataMiner Agents to the DMS.

#### Modules \> System configuration \> Agents \> Delete

Permission to remove DataMiner Agents from the DMS.

#### Modules \> System configuration \> Agents \> Switch Failover

Permission to initiate a manual Failover.

#### Modules \> System configuration \> Agents \> Configure Failover

Permission to configure a pair of Failover DataMiner Agents.

#### Modules \> System configuration \> Agents \> Change operator info

Permission to change the *System info* for a DataMiner Agent.

#### Modules \> System configuration \> Agents \> Start

Permission to (re)start DataMiner Agents.

#### Modules \> System configuration \> Agents \> Stop

Permission to stop the DataMiner Agent software on DataMiner Agents.

#### Modules \> System configuration \> Agents \> Shut down

Permission to shut down DataMiner Agents.

#### Modules \> System configuration \> Agents \> Reboot

Permission to reboot DataMiner Agents.

#### Modules \> System configuration \> Agents \> Change IP settings

Permission to update the virtual IP address settings of a DataMiner Agent.

#### Modules \> System configuration \> Agents \> Change info

Permission to update the *Name* and *Location* fields of a DataMiner Agent.

#### Modules \> System configuration \> Agents \> Add DMA to cluster

Permission to add DataMiner Agents to DataMiner Systems (also known as “clusters”).

#### Modules \> System configuration \> Agents \> Delete DMA from cluster

Permission to remove DataMiner Agents from DataMiner Systems (also known as “clusters”).

#### Modules \> System configuration \> Agents \> Install App packages

Permission to install DataMiner App packages (.dmapp).

#### Modules \> System configuration \> Agents \> Upgrade / restore

Permission to upgrade DMAs (.dmupgrade, .zip) and to restore backups (.dmbackup).

### Modules \> System configuration \> Backup

#### Modules \> System configuration \> Backup \> UI available

Permission to access the Backup page in System Center.

#### Modules \> System configuration \> Backup \> Configure

Permission to configure the backup settings.

### Modules \> System configuration \> Cloud sharing/gateway

#### Modules \> System configuration \> Cloud sharing/gateway \> Connect to cloud/DCP

Available from DataMiner 10.1.0/10.0.9 onwards. Permission to connect a DMA to dataminer.services.

#### Modules \> System configuration \> Cloud sharing/gateway \> Disconnect from cloud/DCP

Available from DataMiner 10.1.0/10.0.9 onwards. Permission to disconnect a DMA from dataminer.services.

#### Modules \> System configuration \> Cloud sharing/gateway \> Configure gateway service

Available from DataMiner 10.2.0/10.1.4 onwards. Allows you to configure the gateway service even if you do not have the *Tools* > *Admin tools* permission.

#### Modules \> System configuration \> Cloud sharing/gateway \> View shared items

Available from DataMiner 10.1.0/10.0.9 onwards. Permission to view items that have been shared via dataminer.services.

From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*.

#### Modules \> System configuration \> Cloud sharing/gateway \> Update shared items

Available from DataMiner 10.1.0/10.0.9 onwards. Permission to make changes to items that have been shared via dataminer.services.

From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*. |

#### Modules \> System configuration \> Cloud sharing/gateway \> Share item

Available from DataMiner 10.1.0/10.0.9 onwards. Permission to share items via dataminer.services.

From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*.

#### Modules \> System configuration \> Cloud sharing/gateway \> Unshare item

Available from DataMiner 10.1.0/10.0.9 onwards. Permission to stop sharing items via dataminer.services.

From DataMiner 10.2.0/10.1.4 onwards, this permission is instead available under *General* > *Live sharing*.

#### Modules \> System configuration \> Cloud sharing/gateway \> Account linking

Only available in DataMiner 10.1.3. Permission to link a DataMiner account to a dataminer.services account, which is necessary to be able to share items via dataminer.services or stop sharing items via dataminer.services.

### Modules \> System configuration \> Database

#### Modules \> System configuration \> Database \> UI available

Permission to access the Database page in System Center.

#### Modules \> System configuration \> Database \> Configure local/general DB

Permission to change the settings of the general database. Prior to DataMiner 10.1.0/10.1.2, this is called the local database.

#### Modules \> System configuration \> Database \> Configure central/offload DB

Permission to change the settings of the offload database. Prior to DataMiner 10.1.0/10.1.1, this is called the central database.

### Modules \> System configuration \> Indexing engine

#### Modules \> System configuration \> Indexing engine \> Configure

Permission to change the Indexing Engine configuration.

#### Modules \> System configuration \> Indexing engine \> UI available

Permission to access Indexing-specific features, such as the search tab in the Alarm Console. Only displayed if *?EnableFeature=Indexing* is added to the Cube URL. Obsolete from DataMiner 10.0.7 onwards.

### Modules \> System configuration \> Logging

#### Modules \> System configuration \> Logging \> UI available

Permission to access the Logging page in System Center.

#### Modules \> System configuration \> Logging \> Change settings

Permission to change the log file settings.

#### Modules \> System configuration \> Logging \> Clear log files

Permission to clear the log file.

### Modules \> System configuration \> Mobile Gateway

#### Modules \> System configuration \> Mobile Gateway \> UI available

Permission to access the *Mobile Gateway* page in System Center.

#### Modules \> System configuration \> Mobile Gateway \> Configure general settings

Permission to change the settings of the Mobile Gateway.

#### Modules \> System configuration \> Mobile Gateway \> Configure commands

Permission to manage the command list.

#### Modules \> System configuration \> Mobile Gateway \> Configure destinations

Permission to manage the destination list.

#### Modules \> System configuration \> Mobile Gateway \> Configure remote users

Permission to manage the list of remote users.

#### Modules \> System configuration \> Mobile Gateway \> Load log file

Obsolete. Only used in DataMiner versions prior to 6.5.3.

#### Modules \> System configuration \> Mobile Gateway \> Clear log file

Obsolete. Only used in DataMiner versions prior to 6.5.3.

#### Modules \> System configuration \> Mobile Gateway \> Remove SMS from stack

Permission to remove text messages from the SMS stack.

#### Modules \> System configuration \> Mobile Gateway \> Reset GSM

Permission to reset the Mobile Gateway.

#### Modules \> System configuration \> Mobile Gateway \> Send SMS

Permission to send ad hoc text messages.

#### Modules \> System configuration \> Mobile Gateway \> Allow access to Mobile UI

Permission to access the DataMiner web apps. Obsolete from DataMiner 10.1.0/10.1.2 onwards, where it is replaced by the permission [General > DataMiner web apps / DataMiner Cube mobile access](#general--dataminer-web-apps--dataminer-cube-mobile-access).

### Modules \> System configuration \> Object Manager \> Module Settings

Available from DataMiner 10.1.5 onwards. Permission to change settings of the DataMiner Object Manager. Requires the DOMManager [soft-launch option](xref:SoftLaunchOptions).

### Modules \> System configuration \> Security

#### Modules \> System configuration \> Security \> UI available

Permission to access the *Users / Groups* page in System Center.

#### Modules \> System configuration \> Security \> Administrator

Permission to edit your own security settings, to import, create, update and delete groups, and to assign users to groups. If you only have this user permission, you will only be able to manage users from groups if you are a member of those groups yourself.

#### Modules \> System configuration \> Security \> Specific \> Limited administrator

Permission to view all groups, to view/add/remove the users in groups of which you are a member yourself, and to modify your own user details (but not your group membership).

#### Modules \> System configuration \> Security \> Specific \> Edit other users

Permission to edit the security settings of all users. This permission is intended to be used in combination with the *Administrator* or *Limited administrator* user permissions, so that you can also configure the users you are allowed to view.

> [!NOTE]
> The permission *Edit other users* can only be granted to users who have also been granted the *Administrator* permission or *Limited administrator*.

#### Modules \> System configuration \> Security \> View users from other groups

Permission to view users from other groups. This permission is intended to be used in combination with the *Administrator* and/or *Limited administrator* user permissions, so that you can also view users from groups that you are not a member of.

> [!NOTE]
> The permission *View users from other groups* also determines whether you have access to public and protected alarm filters made by users from other groups.

#### Modules \> System configuration \> Security \> Group Settings \> Edit own groups

Permission to configure the groups you are a member of.

#### Modules \> System configuration \> Security \> Group Settings \> Edit all groups

Permission to configure groups even if you are not a member of them.

### Modules \> System configuration \> Security \> Notifications / alerts

#### Modules \> System configuration \> Security \> Notifications / alerts \> UI available

Permission to access the Notifications user interface.

#### Modules \> System configuration \> Security \> Notifications / alerts \> Configure email

Permission to manage your own email notifications.

#### Modules \> System configuration \> Security \> Notifications / alerts \> Configure SMS

Permission to manage your own text message notifications.

#### Modules \> System configuration \> Security \> Notifications / alerts \> Allow configuration of other users

Permission to manage email and text message notifications of other users.

### Modules \> System configuration \> SNMP Managers

#### Modules \> System configuration \> SNMP Managers \> UI available

Permission to access the *SNMP forwarding* page in System Center.

#### Modules \> System configuration \> SNMP Managers \> Add

Permission to add SNMP Managers to the list.

#### Modules \> System configuration \> SNMP Managers \> Edit

Permission to make changes to the configuration of the listed SNMP Managers.

#### Modules \> System configuration \> SNMP Managers \> Delete

Permission to delete SNMP Managers from the list.

#### Modules \> System configuration \> SNMP Managers \> Resend alarms

Permission to resend history alarms to a particular SNMP Manager.

### Modules \> System configuration \> System settings \> System settings available

Available from DataMiner 9.6.2 onwards. Permission to access the *System settings* page in System Center.

### Modules \> System configuration \> System settings \> Credentials library

#### Modules \> System configuration \> System settings \> Credentials library \> Add library credentials

Available from DataMiner 9.5.4 onwards. Permissions to add predefined credentials in the credentials library.

#### Modules \> System configuration \> System settings \> Credentials library \> Edit library credentials

Available from DataMiner 9.5.4 onwards. Permissions to edit credentials in the credentials library.

#### Modules \> System configuration \> System settings \> Credentials library \> Delete library credentials

Available from DataMiner 9.5.4 onwards. Permissions to delete credentials from the credentials library.

### Modules \> System configuration \> System settings \> Manage client versions

Available from DataMiner 10.2.0 \[CU3]/10.2.6 onwards. Permission to configure the client update mode.

### Modules \> System configuration \> Tools

#### Modules \> System configuration \> Tools \> Synchronization / clean up unused

Permission to access the *Tools* page in System Center. From DataMiner 10.1.0/10.1.1 onwards., this user permission is replaced by the *Admin tools* user permission.

#### Modules \> System configuration \> Tools \> Admin tools

Available from DataMiner 10.1.0/10.1.1 onwards. Permission to use administrator tools such as synchronization, cleaning up unused protocols, alarm filters, or Visio files, NATS management, and (de)initializing Resource Manager.

#### Modules \> System configuration \> Tools \> Control background tasks of all users

Permission to see and control the background tasks of all users.

#### Modules \> System configuration \> Tools \> Allow access to query executor

Permission to execute SQL queries against the general or offload database.

#### Modules \> System configuration \> Tools \> Best practices analyzer \> UI Available

Permission to read a BPA test. Available from DataMiner 10.0.9 onwards. Prior to DataMiner 10.2.0/10.2.3, this user permission is called "Read".

#### Modules \> System configuration \> Tools \> Best practices analyzer \> Add/Edit

Permission to add or edit a BPA test. Available from DataMiner 10.0.9 onwards.

#### Modules \> System configuration \> Tools \> Best practices analyzer \> Delete

Permission to delete a BPA test. Available from DataMiner 10.0.9 onwards.

#### Modules \> System configuration \> Tools \> Best practices analyzer \> Execute

Permission to execute a BPA test. Available from DataMiner 10.0.9 onwards.

#### Modules \> System configuration \> Tools \> Best practices analyzer \> Get test results

Permission to retrieve the results of a BPA test. Available from DataMiner 10.0.9 onwards.

### Modules \> Ticketing Gateway

#### Modules \> Ticketing Gateway \> UI available

Permission to access the *Ticketing Gateway* app.

#### Modules \> Ticketing Gateway \> Add

Permission to add tickets.

#### Modules \> Ticketing Gateway \> Edit

Permission to edit tickets.

#### Modules \> Ticketing Gateway \> Delete

Permission to delete tickets.

#### Modules \> Ticketing Gateway \> Configure

Permission to configure ticket domains.

### Modules \> Trending

#### Modules \> Trending \> Trending app

Permission to access the Trending module.

#### Modules \> Trending \> View Trending

Permission to view trend graphs of parameters that are being trended.

#### Modules \> Trending \> View Histogram

Permission to view histograms of parameters that are being trended.

### Modules \> User-Defined APIs

> [!NOTE]
> This feature is available from DataMiner 10.3.6/10.4.0 onwards. In DataMiner 10.3.5, it is available in preview if the soft-launch option *UserDefinableAPI* is enabled. See [soft-launch options](xref:SoftLaunchOptions).

#### Modules \> User-Defined APIs \> Tokens \> UI available

Permission to view tokens for [user-defined APIs](xref:UD_APIs).

#### Modules \> User-Defined APIs \> Tokens \> Add/Edit

Permission to create and edit tokens for [user-defined APIs](xref:UD_APIs).

#### Modules \> User-Defined APIs \> Tokens \> Delete

Permission to delete tokens for [user-defined APIs](xref:UD_APIs).

#### Modules \> User-Defined APIs \> APIs \> UI available

Permission to view API definitions for [user-defined APIs](xref:UD_APIs).

#### Modules \> User-Defined APIs \> APIs \> Add/Edit

Permission to create and edit API definitions for [user-defined APIs](xref:UD_APIs). In order to create or edit API definitions, you also need the [Automation > execute](#modules--automation--execute) permission.

#### Modules \> User-Defined APIs \> APIs \> Delete

Permission to delete API definitions for [user-defined APIs](xref:UD_APIs).

### Modules \> User-definable apps

#### Modules \> User-definable apps \> View apps

Permission to view custom DataMiner apps created using the [DataMiner Low-Code Apps](xref:Application_framework) and to access the framework itself. You need to have this permission to be able to use any of the other "User-definable apps" permissions.

#### Modules \> User-definable apps \> Add

Permission to add custom DataMiner apps using the [DataMiner Low-Code Apps](xref:Application_framework).

#### Modules \> User-definable apps \> Edit

Permission to edit custom DataMiner apps created using the [DataMiner Low-Code Apps](xref:Application_framework).

#### Modules \> User-definable apps \> Delete

Permission to delete custom DataMiner apps created using the [DataMiner Low-Code Apps](xref:Application_framework).

#### Modules \> User-definable apps \> Publish

Permission to publish custom DataMiner apps created using the [DataMiner Low-Code Apps](xref:Application_framework).
