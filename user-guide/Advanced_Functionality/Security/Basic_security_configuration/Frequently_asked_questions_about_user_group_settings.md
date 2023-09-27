---
uid: Frequently_asked_questions_about_user_group_settings
---

# Frequently asked questions about user group settings

- [Where can I find the clientsettings.dat files?](#where-can-i-find-the-clientsettingsdat-files)

- [Which user permissions are required to manage user group settings](#which-user-permissions-are-required-to-manage-user-group-settings)

- [What if a user is a member of more than one group?](#what-if-a-user-is-a-member-of-more-than-one-group)

- [When a user logs on to DataMiner Cube, which value will a particular user setting have?](#when-a-user-logs-on-to-dataminer-cube-which-value-will-a-particular-user-setting-have)

- [Which user permissions are included in which security preset?](#which-user-permissions-are-included-in-which-security-preset)

## Where can I find the clientsettings.dat files?

Users as well as user groups can have a *clientsettings.dat* file.

- The *clientsettings.dat* file of a user can be found in the folder `C:\Skyline DataMiner\Users\[UserName]`.

- The *clientsettings.dat* file of a user group can be found in the folder `C:\Skyline DataMiner\Users\SharedUserSettings\Groups\[GroupName]`.

> [!NOTE]
> A *clientsettings.dat* file only contains user settings, no computer settings.

## Which user permissions are required to manage user group settings?

If you want users to be able to assign and configure user group settings, you have to grant them one of the following user permissions:

- [Modules > System configuration > Security > Group settings > Edit all groups](xref:DataMiner_user_permissions#modules--system-configuration--security--group-settings--edit-all-groups)

- [Modules > System configuration > Security > Group settings > Edit own groups](xref:DataMiner_user_permissions#modules--system-configuration--security--group-settings--edit-own-groups)

## What if a user is a member of more than one group?

If a user is a member of more than one user group, default user settings for this user will be supplied from the first user group that has been assigned a set of user settings. In other words, the first user group that has a *clientsettings.dat* file will provide the settings for the user.

## When a user logs on to DataMiner Cube, which value will a particular user setting have?

See the following decision flow.

![User setting flowchart](~/user-guide/images/cube_usergroupsettings.jpg)

> [!NOTE]
> Once a user has overridden the (default) value of a setting as found in the group-level settings file, that setting will no longer be controlled by the group-level settings file. In other words, non-default values will never be overwritten.

## Which user permissions are included in which security preset?

In the following table, an x in a preset column indicates that the user permission in the first column is available in that preset.

> [!NOTE]
> Some user permissions are only available in certain versions of Cube or depending on certain DataMiner licenses.

| Cube permission | No Rights | Operators | Power users | Administrators (read-only access to Security) | Administrators |
|--|--|--|--|--|--|
| Surveyor available |  | x | x | x | x |
| Data overview available |  | x | x | x | x |
| Data overview view available |  | x | x | x | x |
| Element list available |  | x | x | x | x |
| Elements \> Access |  | x | x | x | x |
| Elements \> Add |  |  | x | x | x |
| Elements \> Edit |  |  | x | x | x |
| Elements \> Delete |  |  | x | x | x |
| Elements \> Import CSV |  |  | x | x | x |
| Elements \> Import DELT |  |  | x | x | x |
| Elements \> Import DELT |  |  | x | x | x |
| Elements \> Properties \> ... |  |  | x | x | x |
| Elements \> Lock / unlock |  | x | x | x | x |
| Elements \> Force unlock |  |  | x | x | x |
| Elements \> Start |  |  | x | x | x |
| Elements \> Stop |  |  | x | x | x |
| Elements \> Pause |  |  | x | x | x |
| Elements \> Restart |  |  | x | x | x |
| Elements \> Mask until clearance / for x time |  | x | x | x | x |
| Elements \> Mask until unmasking |  | x | x | x | x |
| Elements \> Allow unmasking |  | x | x | x | x |
| Elements \> Simulation available |  | x | x | x | x |
| Elements \> Data Display \> Access |  | x | x | x | x |
| Elements \> Data Display \> Device webpage access |  | x | x | x | x |
| Elements \> Data Display \> View write parameters |  | x | x | x | x |
| Elements \> Data Display \> Configure matrix options |  | x | x | x | x |
| Elements \> Data Display \> Spectrum \> Configure measurement points |  | x | x | x | x |
| Elements \> Data Display \> Spectrum \> Configure scripts & monitors |  | x | x | x | x |
| Elements \> Data Display \> Spectrum \> Edit / delete protected presets |  |  | x | x | x |
| Elements \> Data Display \> Spectrum \> Take device from other client |  |  | x | x | x |
| Elements \> Data Display \> Spectrum \> Take priority over monitors |  |  | x | x | x |
| Services \> ... |  |  | x | x | x |
| Views \> ... |  |  | x | x | x |
| Redundancy groups \> Add |  |  | x | x | x |
| Redundancy groups \> Edit |  |  | x | x | x |
| Redundancy groups \> Delete |  |  | x | x | x |
| Redundancy groups \> Advanced \> Change redundancy mode |  |  | x | x | x |
| Redundancy groups \> Advanced \> Manual switch |  |  | x | x | x |
| Redundancy groups \> Advanced \> Set element in maintenance |  | x | x | x | x |
| Redundancy groups \> Advanced \> Configure elements in redundancy templates |  |  | x | x | x |
| Redundancy groups \> Advanced \> Configure automatic switching |  |  | x | x | x |
| Alarms \> Alarm Console available |  | x | x | x | x |
| Alarms \> Allow masking |  | x | x | x | x |
| Alarms \> Allow unmasking |  | x | x | x | x |
| Alarms \> Allow take & release ownership |  | x | x | x | x |
| Alarms \> Release ownership of another user |  |  | x | x | x |
| Alarms \> Allow viewing of system events |  | x | x | x | x |
| Alarms \> Extended context menu Alarm Console |  | x | x | x | x |
| Alarms \> Extended view menu Alarm Console |  | x | x | x | x |
| Alarms \> Edit / delete protected filters |  |  | x | x | x |
| Alarms \> Properties \> Add |  |  | x | x | x |
| Alarms \> Properties \> Edit |  | x | x | x | x |
| Alarms \> Properties \> Delete |  |  | x | x | x |
| Alarms \> Audible alert \> ... |  |  | x | x | x |
| Workspaces \> ... |  |  | x | x | x |
| Annotations \> ... |  | x | x | x | x |
| Visual Overview \> Access Visual Overviews |  | x | x | x | x |
| Visual Overview \> Advanced navigation |  | x | x | x | x |
| Visual Overview \> Download Visio drawings |  |  | x | x | x |
| Visual Overview \> Edit Visio drawings |  |  | x | x | x |
| Collaboration \> UI available |  | x | x | x | x |
| Collaboration \> Disconnect other users |  |  | x | x | x |
| Software updates |  |  |  | x | x |
| Live sharing |  | x | x | x | x |
| Email |  | x | x | x | x |
| Modules \> Asset Manager |  |  | x | x | x |
| Modules \> Automation \> UI available |  |  | x | x | x |
| Modules \> Automation \> Add |  |  | x | x | x |
| Modules \> Automation \> Edit |  |  | x | x | x |
| Modules \> Automation \> Delete |  |  | x | x | x |
| Modules \> Automation \> Execute |  | x | x | x | x |
| Modules \> Bookings \> ... |  |  | x | x | x |
| Modules \> Correlation \> ... |  |  | x | x | x |
| Modules \> Documents \> UI available |  | x | x | x | x |
| Modules \> Documents \> Add |  |  | x | x | x |
| Modules \> Documents \> Edit |  |  | x | x | x |
| Modules \> Documents \> Delete |  |  | x | x | x |
| Modules \> Element Connections |  |  | x | x | x |
| Modules \> Functions |  |  | x | x | x |
| Modules \> Jobs \> UI available |  | x | x | x | x |
| Modules \> Jobs \> Add/Edit |  | x | x | x | x |
| Modules \> Jobs \> Delete |  | x | x | x | x |
| Modules \> Jobs \> Configure Domains |  |  | x | x | x |
| Modules \> Planned Maintenance \> UI available |  | x | x | x | x |
| Modules \> Planned Maintenance \> Add/Edit |  | x | x | x | x |
| Modules \> Planned Maintenance \> Delete |  | x | x | x | x |
| Modules \> Planned Maintenance \> Configure |  |  | x | x | x |
| Modules \> Profiles \> ... |  |  | x | x | x |
| Modules \> Profile Manager \> ... |  |  | x | x | x |
| Modules \> Protocols & Templates \> ... |  |  | x | x | x |
| Modules \> Reports & Dashboards \> Reports \> Reports app |  | x | x | x | x |
| Modules \> Reports & Dashboards \> Reports \> View reports |  | x | x | x | x |
| Modules \> Reports & Dashboards \> Reports \> Manage mail templates |  |  | x | x | x |
| Modules \> Reports & Dashboards \> Dashboards \> Dashboards app |  | x | x | x | x |
| Modules \> Reports & Dashboards \> Dashboards \> View dashboards |  | x | x | x | x |
| Modules \> Reports & Dashboards \> Dashboards \> Add |  |  | x | x | x |
| Modules \> Reports & Dashboards \> Dashboards \> Edit |  |  | x | x | x |
| Modules \> Reports & Dashboards \> Dashboards \> Delete |  |  | x | x | x |
| Modules \> Resource Manager > ... |  |  | x | x | x |
| Modules \> Resources > ... |  |  | x | x | x |
| Modules \> Router Control \> ... |  |  | x | x | x |
| Modules \> Scheduler \> ... |  |  | x | x | x |
| Modules \> Service & Resource Management \> ... |  |  | x | x | x |
| Modules \> Service Manager \> ... |  |  | x | x | x |
| Modules \> Service templates \> ... |  |  | x | x | x |
| Modules \> Services \> ... |  |  | x | x | x |
| Modules \> System configuration \> Agents \> UI available |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Add |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Delete |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Switch Failover |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Configure Failover |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Change operator info |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Start |  |  | x | x | x |
| Modules \> System configuration \> Agents \> Stop |  |  | x | x | x |
| Modules \> System configuration \> Agents \> Shutdown |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Reboot |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Change IP settings |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Change info |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Add DMA to cluster |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Delete DMA from cluster |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Install App packages |  |  |  | x | x |
| Modules \> System configuration \> Agents \> Upgrade / restore |  |  |  | x | x |
| Modules \> System configuration \> Backup \> ... |  |  |  | x | x |
| Modules \> System configuration \> Cloud sharing/gateway |  |  |  | x | x |
| Modules \> System configuration \> Database \> ... |  |  |  | x | x |
| Modules \> System configuration \> Object Manager |  |  |  | x | x |
| Modules \> System configuration \> Indexing \> ... |  |  | x | x | x |
| Modules \> System configuration \> Logging \> UI available |  |  | x | x | x |
| Modules \> System configuration \> Logging \> Change settings |  |  |  | x | x |
| Modules \> System configuration \> Logging \> Clear log files |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> UI available |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Configure general settings |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Configure commands |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Configure destinations |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Configure remote users |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Load log file |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Clear log file |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Remove SMS from stack |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Reset GSM |  |  |  | x | x |
| Modules \> System configuration \> Mobile Gateway \> Send SMS |  | x | x | x | x |
| Modules \> System configuration \> Mobile Gateway \> Allow access to Mobile UI |  | x | x | x | x |
| Modules \> System configuration \> Security \> UI available |  |  |  | x | x |
| Modules \> System configuration \> Indexing Engine |  |  | x | x | x |
| Modules \> System configuration \> Security \> Administrator |  |  |  |  | x |
| Modules \> System configuration \> Security \> Specific \> ... |  |  |  |  | x |
| Modules \> System configuration \> Security \> View users from other groups | x | x | x | x | x |
| Modules \> System configuration \> Security \> Group settings \> ... |  |  |  |  | x |
| Modules \> System configuration \> Security \> Notifications / alerts \> UI available |  |  | x | x | x |
| Modules \> System configuration \> Security \> Notifications / alerts \> Configure email |  |  | x | x | x |
| Modules \> System configuration \> Security \> Notifications / alerts \> Configure SMS |  |  | x | x | x |
| Modules \> System configuration \> Security \> Notifications / alerts \> Allow configuration of other users |  |  |  | x | x |
| Modules \> System configuration \> SNMP Managers \> ... |  |  |  | x | x |
| Modules \> System configuration \> System settings \> System settings available |  |  | x | x | x |
| Modules \> System configuration \> System settings \> Credentials library \> ... |  |  |  | x | x |
| Modules \> System configuration \> System settings \> Manage client versions |  |  |  | x | x |
| Modules \> System configuration \> System settings \> Indexing engine \> ... |  | x | x | x | x |
| Modules \> System configuration \> Tools \> Synchronization / clean up unused |  |  |  | x | x |
| Modules \> System configuration \> Tools \> Control background tasks of all users |  |  | x | x | x |
| Modules \> System configuration \> Tools \> Allow access to query executor |  |  |  | x | x |
| Modules \> System configuration \> Tools \> Best practices analyzer \> ... |  |  |  | x | x |
| Modules \> Ticketing Gateway > ... |  | x | x | x | x |
| Modules \> Trending \> ... |  | x | x | x | x |
| Other \> View Element Manager |  |  |  | x | x |
| Legacy \> View Element Manager |  |  |  | x | x |
| Legacy \> Dashboard Overview |  | x | x | x | x |
| Legacy \> Report Overview |  | x | x | x | x |
| Legacy \> Manage views |  | x | x | x | x |
| Legacy \> Assign Visio drawings |  |  | x | x | x |
