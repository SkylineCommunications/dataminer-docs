---
uid: Managing_the_start_window
---

# Managing the start window of the desktop app

Below you can find more information on the different options available to manage the start window of the DataMiner Cube desktop app.

## Selecting your Cube update track

From DataMiner 10.2.0 \[CU3]/10.2.6 onwards, Cube can automatically update to a more recent version than the DataMiner version installed on the server. This way you can use the latest Cube features as soon as they are released without having to wait for a server upgrade.

In the Cube start window, you can select which Cube update track should be used:

1. Click the cogwheel icon in the lower-right corner of the start window.

1. Select *Settings*.

1. In the *Settings* dialog, select the update track you want to use:

   - **Release**: Use the latest released DataMiner Cube version, so you can enjoy all the latest and greatest features.
   - **Release (delayed 2 weeks)**: Wait to use the latest released DataMiner Cube version until 2 weeks after the release date. This is the default option.

   > [!NOTE]
   > For Skyline employees only, two additional tracks are available for development purposes:
   >
   > - **Preview**: Use a preview of the latest DataMiner Cube version, even if it has not been released yet. This is the default option for Skyline Employees.
   > - **Development**: Use the latest available development version.

1. Click *Save*.

> [!NOTE]
>
> - You can also right-click the tile representing a particular DMS/DMA in the start window and select *Connect using* to select a specific Cube version to connect to that DMS/DMA with.
> - Limitations to the possible Cube versions can be configured in the [system settings](xref:DMA_configuration_related_to_client_applications#managing-client-versions).

## Setting a DMS as the default DMS

To set a DMS as the default DMS to connect to:

1. Hover the mouse pointer over the tile representing this DMS and click “...” in the top-right corner.

1. Select *Set as default* in the pop-up window and click *Save*.

## Changing which DMA in a DMS you connect to

To specify a different DMA in a DMS to connect to:

1. Hover the mouse pointer over the tile representing this DMS and click “...” in the top-right corner.

1. Expand the *Agent* section, select the DMA and click *Save*.

## Connecting to a DMS using arguments

To connect to a DMS using specific arguments:

1. Hover the mouse pointer over the tile representing this DMS and click “...” in the top-right corner.

1. Expand the *Advanced* section, specify the arguments and click *Save*.

For more information on the possible arguments, see [Arguments for DataMiner Cube](xref:Options_for_opening_DataMiner_Cube).

## Configuring whether to connect with HTTPS only

From DataMiner 10.2.6/10.3.0 onwards, you can configure whether Cube should connect to a specific DMS using HTTPS only or whether it can fall back to HTTP if HTTPS is not available.

To do so:

1. Hover the mouse pointer over the tile representing this DMS and click “...” in the top-right corner.

1. Expand the *Advanced* section.

1. In the *Transport* box, select *HTTP or HTTPS* or *HTTPS only*, depending on your preference.

1. Click *Save*.

> [!NOTE]
> From DataMiner 10.4.0 [CU15]/10.5.0 [CU3]/10.5.6 onwards<!--RN 42716-->, if you select *HTTP or HTTPS*, Cube will send both an HTTP request and an HTTPS request in parallel, each with a timeout of 60 seconds. The first successful response will be used, and the other request will be canceled. If the first response is not successful, Cube will fall back on the other request. In earlier versions, Cube will first send an HTTP request with a default timeout of 100 seconds. If that request fails, it will then send an HTTPS request.

## Removing a DMS from the start window

To remove the tile representing a DMS from the start window:

1. Hover the mouse pointer over the tile representing this DMS and click “...” in the top-right corner.

1. Click the garbage can icon in the pop-up window.

From DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!--RN 41203-->, you can also remove tiles by dragging them onto the garbage can icon. Additionally, you can remove all DMS tiles in a group by clicking the ![drag-and-drop](~/dataminer/images/drag-and-drop.png) icon next to the group name and dragging it onto the garbage can icon.

> [!NOTE]
> The garbage can icon becomes visible only after you grab a tile or group and begin dragging it.

## Sorting tiles in groups

From DataMiner 10.2.0/10.1.3 onwards, you can sort the different tiles in the start window in groups.

- If no groups have been created yet, all tiles will be considered to be part of the same group.

- To create a new group, drag a tile out of its current group.

- To name or rename a group, click above the group and enter the name.

- To move a tile to another position or to another group, drag it to its new position.

- From DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!--RN 41203-->, you can reorder groups by clicking the ![drag-and-drop](~/dataminer/images/drag-and-drop.png) icon next to the group name and dragging it to its new position.

## Filtering the displayed tiles

To filter the tiles in the start window:

- Hover the mouse pointer over the looking glass and enter a search string in the search box.

- Alternatively, simply start typing a search string, without going to the search box.

    > [!NOTE]
    > When the filter does not yield any results, you can click the “+” button or press ENTER to immediately add the DMS you were looking for.

## Making DataMiner Cube start up with windows

To specify whether the DataMiner Cube should start up when Windows is started:

1. Click the cogwheel icon in the lower-right corner of the start window.

1. Select or clear the option *Start with Windows*, depending on whether you want Cube to start with Windows or not.

## Viewing logging for the start window

To view logging for the DataMiner Cube start window:

1. Click the cogwheel icon in the lower-right corner of the window.

1. Select *View logging*.

## Managing the software version for the start window

When you connect to a DataMiner server, the correct version of the Cube start window will automatically be downloaded from that server. If an update is installed on the server, that new version of the Cube start window will automatically be used.

The Cube start window also checks the servers you connect to for new software versions. It will also periodically check <https://dataminer.services> for a new version. This check is triggered by a task in Windows Task Scheduler, which is created when the Cube start window is installed. The task is created in the `DataMiner Cube` folder and is named *Update DataMiner Cube_*, followed by the user ID.

This scheduled task can be edited to change the interval or time or to completely disable the background updates (by disabling the task). To reset the task to the default settings, simply delete the task and open the Cube start window. The scheduled task will automatically be created again.

> [!NOTE]
> Background updates (triggered by the Windows Task Scheduler) for the Cube start window have a phased rollout. This means not all clients will be updated at the same time. Different clients will receive the update over a time period of a few days. However, you can force the start window to update to the latest available version by clicking the cogwheel button in the lower-right corner and selecting *Check for updates*.

### Checking the software version of the start window

From DataMiner 10.2.6/10.3.0 onwards, you can check which software version the start window currently uses.

To do so:

1. Click the cogwheel icon in the lower-right corner of the start window.

1. Select *About*.

### Manually triggering an update of the start window

Do one of the following:

- Execute the above-mentioned scheduled task.

- Click the cogwheel icon in the lower-right corner of the start window, and select *Check for updates*.

### Consulting the start window logging

The log files of the start window application can be found in the following location: `%LocalAppData%\Skyline\DataMiner\DataMinerCube\Logs\logYYYYMMDD.txt`

> [!NOTE]
> This is different from the [Cube Logging](xref:Cube_logging).
