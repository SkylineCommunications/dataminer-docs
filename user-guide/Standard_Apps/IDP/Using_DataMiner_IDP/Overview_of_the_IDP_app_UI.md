---
uid: Overview_of_the_IDP_app_UI
---

# Overview of the IDP app UI

The *DataMiner Infrastructure, Discovery and Provisioning* app (or IDP app) is available in the *Applications* section of the apps list in the Surveyor.

By default, the app consists of the following tabs:

- [Overview](#overview)

- [Inventory](#inventory)

- [Connectivity](#connectivity)

- [Configuration](#configuration)

- [Software](#software)

- [Facilities](#facilities)

- [Processes](#processes)

- [Admin](#admin)

- [About](#about)

## Overview

This tab consists of a summary of the actions of the app, KPIs, alarms, statistics per DMA and a general map overview.

## Inventory

This tab consists of the following subtabs:

- **Managed**: Displays an overview of the elements managed by DataMiner IDP.

  At the top of the overview, you can find the following buttons:

  - **Open**: Navigates to the card of the selected managed element.

  - **Remove**: Allows you to remove a selected managed element, if a *CI Removal Script* has been configured on the *Admin* > *Settings* page.

  - **Reapply**: Allows you to apply a CI Type again, for example to revert the element to its original configuration in case changes were made or to make the element reflect an update to the CI Type. Clicking the button will open a wizard where you can select which parts of the CI Type should be reapplied. The *Show details* button in this wizard will show an overview of what all selected replacements look like and what the end result will be.

  - **Reassign**: Allows you to reassign the CI Type of the element, for example in case previously one generic CI Type was used for a family of devices but now more specific CI Types are available. Clicking the button opens a wizard where you can select the new CI Type and then select which parts of the CI Type should be applied. The *Show details* button in this wizard will show an overview of what all selected replacements look like and what the end result will be.

- **Unmanaged**: Displays an overview of the elements available in the system but not yet managed by DataMiner IDP. The information in this tab is particularly useful if IDP is deployed in an existing DMS, or in the rare case that managed elements cannot be discovered or imported, but need to be manually created.

  At the top of the overview, you can find the following buttons:

  - **Refresh**: Refreshes the displayed data.

  - **Manage**: If the detected IP address and CI Type are filled in for an element in the overview, click this button to add the element to the managed elements.

- **Discovered**: Allows you to start a device discovery and manage the discovered elements. Consists of the following sections:

  - **Actions**: Allows you to start a discovery action. You can either select a scan range and click the *Discover* button on the right, or click the *Discover* page button to start a custom discovery. The section also contains the following options:

    - *Identify Unknown devices*: Disable this option if you do not want devices to be displayed if no matching CI Type is found.

    - *Identify All Matching CI Types*: Enable this option if you want the discovery process to try to match all possible CI Types configured in the scan range. Otherwise, the process will stop trying to match a device with other CI Types once a CI Type has been identified for it.

    > [!NOTE]
    > - It is only possible to complete a discovery action for a specific CI Type if the *Discovery* activity setting is enabled on the tab *Processes* > *Activities*.
    > - When a discovery has been initiated, the *Provisioning Status* column in the table will display the status *Provisioning Started*. As long as this status is displayed, you will not be able to start another provisioning activity for the same device.

  - **Most recent discoveries**: Displays information on the 6 most recent discovery operations.

  - **Discovered elements**: Lists all discovered elements with detailed information, including the provisioning status. The buttons above the table allow you to show the responses returned by the selected device during discovery, provision the element or remove the device from the list. The toggle button on the right determines if all discovered elements are displayed, or only managed elements.

    > [!NOTE]
    > Depending on the *Discovery Results to Show* setting, either all discoveries are shown in the *Discovered Elements* table, or only the most recent discoveries. This setting can be found on the *Settings* data page of the IDP app. To access this page, click the hamburger button in the top-left corner, select *Show card side* *panel* and then go to *DATA* > *Settings*.

- **Deleted**: Displays an overview of the elements that have been deleted from the DMS. At the top of the overview, you can find three buttons:

  - *Provision*: Recreates the selected deleted element(s).

  - *Clean*: Removes the selected element(s) from the *Deleted Elements* table.

  - *Clean All*: Removes all entries from the *Deleted Elements* table.

## Connectivity

This tab consists of the following subtabs:

- **Managed**: Displays an overview of existing managed connections. Select a managed element in the list and click *Show details* to view the external connections of the selected element.

- **Discovered**: Displays an overview of discovered connections, and allows easy DCF provisioning. The following buttons are available at the top of the overview:

  - *Show details*: Displays detailed information on the connectivity discovery operation for the selected element in a pane on the right. This includes the status (*OK* or *NOK*), chassis ID and progress. It also includes the following two tables:

    - *Discovered Connections*: Lists the connections that have been discovered on the element and for which the elements on both side of the connection have reported its existence. You can select a discovered connection and click *Provision DCF* to provision the connection. The *Include Managed* toggle button at the top determines whether discovered connections that are already provisioned by IDP are included in the table or not.

    - *Unresolved Connections*: Lists the connections that were only discovered by the selected element, i.e. connections for which the element at the other side of the connection is still unknown. These connections cannot be provisioned in DCF.

  - *Discover*: Starts a connectivity discovery action for the selected element.

  - *Provision DCF*: (Called "Provision All DCF" prior to IDP 1.1.18.) Provisions the discovered connections for the selected element(s) in DCF.

## Configuration

This tab consists of the following subtabs:

- **Summary**: Provides an overview of the elements of which the CI Type has *Take Backup* and/or *Configuration Update* enabled (via *Processes* > *Automation*). The overview includes the CI Type, element name and IP address for each element, as well as the update progress of the last backup that was copied to the configuration archive, and the date and time when the last configuration change was detected.

  Above the overview, the following buttons are available:

  - *Backup*: Creates a configuration backup of the selected elements.

  - *Default*: Applies the default configuration to the selected elements.

  - *Compare*: Starts a configuration comparison with the selected file as one of the files to be compared.

  - *Show Backups*: Displays all available configuration backups from the last 30 days for the selected element in the *Backups* tab.

- **Backups**: Allows you to view a list of configuration backups, either based on a selection in the *Summary* tab as mentioned above, or based on specific search criteria. The list mentions the element name, the timestamp of the backup, the backup type, the backup size and whether a change was detected compared to the previous backup.

  Clicking the *Search* icon opens a wizard where you can specify these search criteria. Searching is possible by CI Type, by element name or by time range (UTC), or a combination of these. When you select a configuration backup in the table, you can also use the following buttons above the table:

  - *Show content*: Displays the content of the selected configuration backup to the right of the list. Above the content, a drop-down box allows you to select whether the *Full Configuration Backup* should be displayed or the *Core Configuration Only*. This last option allows you to focus on the information that is most important for the configuration.

  - *Compare*: Starts a configuration comparison with the selected file as one of the files to be compared.

- **Update**: Allows you to apply a configuration backup file to one or more elements. To do so, select the configuration backup file in the table on the left, and the elements in the table on the right (keep the Ctrl key pressed to select several elements at a time). Then click the *Update* button above the table.

  > [!NOTE]
  > When a configuration backup is applied, the backup file is first copied from the DataMiner Configuration Archive to the working directory on the DMAs hosting the selected elements. This means that a working directory must be configured for each DMA in the DMS. You can do so via *Admin* > *Configuration* > *Network Shares*. See [Configuration](xref:Configuration).

- **Compare**: Allows you to compare two configuration files. To do so:

  - First start a search to get a list of configuration files matching specific search criteria.

  - Then use the buttons above the table to select the configuration files to show on the left side and on the right side of the comparison, and click the *Compare* button to start comparing them.

  - With the drop-down box in the top-right corner, you can select whether you want to compare the *Full Configuration Backup* or the *Core Configuration Only*. This last option allows you to focus on the information that is most relevant for comparison.

  - To clear the current file selection, click *Clear*.

  - If you started a comparison from the *Summary* or *Backups* subtab, the file you selected there will automatically be selected as the left file in the comparison.

  > [!NOTE]
  > Files can only be compared if they have an extension listed under *Admin* > *Configuration* > *Backup*. See [Configuration](xref:Configuration).

## Software

This tab allows you to manage software updates of managed elements. At the top of the tab, a graph displays a summary of the software status of all managed devices.

The table below this lists the managed elements of which the CI Type has *Software Update* and/or *Software Compliancy* enabled (via *Processes* > *Activities*). Several buttons are available above the table:

- *Show Details*: Only available if a single element is selected. Displays the software details for the element, such as the expected software version, detected software version, software image location and deployed software version.

- *Update*: Opens a wizard to perform a software update on the selected elements.

- *Check compliancy*: Checks if the selected elements use the expected software version.

## Facilities

This tab displays an overview of the levels in the infrastructure, with KPIs and a table that allows you to easily navigate to the rack of the managed devices.

> [!NOTE]
> The *Expected* and *Actual Energy Consumption* KPIs are aggregated on all the different levels of the facilities. On this overview tab, the total values are displayed.
> - The *Expected Energy Consumption* is based on the element property *Energy Expected Consumption*. This property can be supplied in the CI Type definition or via the update properties script.
> - To calculate the *Actual Energy Consumption* KPI, an aggregation rule named *Energy Consumption* is needed on the Facilities view. This aggregation rule should be in the folder *RLM*, and it should use the aggregation type *calculate the sum* of the relevant parameter values, and have *Include subview (recursion)* selected. As the expected consumption is measured in kWh, we recommend to also measure the actual consumption in kWh.

## Processes

This tab displays an overview of scheduled activities or processes, depending on whether IDP is used together with DataMiner Process Automation. If Process Automation is not used, the *New* button allows you to schedule a new discovery activity. With DataMiner Process Automation, the *New* button opens the Process Automation wizard.

In the Process Automation wizard, you can create or schedule processes consisting of one or more activities. To do so:

- In the first step of the wizard, specify:

  - The process name.

  - The activation window type: *Single Event* or *Permanent Service*.

  - The activation window: The start time, as well as the stop time or duration in case of a single event.

- In the second step of the wizard:

  - Select an existing process to schedule it again or create a custom process.

  - In the *Start* drop-down box, select whether the process should be executed once (*Instant*) or repeated at regular intervals (*Timer*). If you select *Timer*, you will need to specify a profile and interval for the timer. Note that this drop-down box is only available if a repeat gateway is available in the DMS. If no repeat gateway is available, the process will always be executed once.

  - If you are creating a custom process, click the *Add* *Activity button* to add an activity to the process. You can use the *Delete Activity* button to remove the last activity you have added.

  - For each activity you add, select which activity should be executed. The available choices depend on the preceding activity in the process. For example, after the activity *SLC IDP Discover Data Sources*, you need to select the activity *SLC IDP Provision Element* before any other activities become available.

  - For each activity, select a profile and resource if necessary.

  - When you have selected a profile for an activity, and there are mandatory profile parameters, a value must be assigned to these before you can continue to the next step of the wizard. If there are no mandatory profile parameters, a *Show Details* label is displayed next to the arrow button below the profile. Click the arrow button to view and change the profile parameter values according to your preference. If there are mandatory profile parameters, a *Show All* label is displayed instead, and clicking the arrow button shows any profile parameters for which it is not necessary to assign a value.

  - If a suitable resource is detected for an activity, it will be selected automatically.

- In the final step:

  - Select the profile instance that should be used for the first token of the process. For example, if the first activity is a discovery activity, you must select the profile that will determine the scan range for this activity.

    > [!NOTE]
    > For some processes (e.g. *IDP IS-04 Provision New Nodes* and *IDP IS-04 Update Existing Nodes*), selecting a start token is not possible. These make use of custom scripts instead.

  - The token selection is displayed below the start profile selection. If a suitable profile instance is available for the token, it will be selected automatically. Selecting or customizing a token profile instance in this step allows you to fine-tune the way the token will be handled by Process Automation. You can for instance indicate the priority for the token and the duration it should be allowed to stay in the queue.

  - If a profile instance and resource can be selected automatically, the token section is collapsed.

- When the necessary configuration is done, click *Create* to create the process. The scheduled process will be added to the timeline on the *Processes* > *Schedules* tab and executed at the specified time.

> [!NOTE]
> - If you do not have Process Automation installed but would like to begin using it in an existing IDP setup, install DataMiner SRM, Process Automation and Token activity, and optionally install the Repeat Gateway. Make sure you are using IDP version 1.1.12 or higher. Then run the IDP setup wizard to activate the use of Process Automation.
> - If you are using an older IDP version (prior to IDP 1.1.20), this tab consists of two subtabs: *Schedules*, with the functionality described above, and *Activities*, which the functionality of the later *Admin* > *Activities* > *Overview* page. See [Overview](xref:Admin_activities#overview).

> [!NOTE]
> - Activity settings **can be disabled by default**, depending on the configuration on the *Admin* > *CI Types* > *Activity Management* page. To perform any of these actions for a specific CI Type, make sure the relevant setting on this tab is enabled.
> - Prior to IDP 1.1.11, this tab was called *Workflows*. The *Activities* subtab was called *Automation* prior to IDP 1.1.16.

## Admin

This tab allows you to manage various settings. See [Advanced configuration for Administrators](xref:Advanced_configuration_for_Administrators).

## About

This tab contains links to the IDP Help and to information about the Provisioning API. It also displays DataMiner IDP version information.
