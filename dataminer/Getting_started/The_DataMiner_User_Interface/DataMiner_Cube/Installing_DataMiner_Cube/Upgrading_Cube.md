---
uid: Upgrading_Cube
---

# Upgrading DataMiner Cube

When a new DataMiner Feature Release or Main Release version becomes available, the same Cube version will be included in both upgrade packages. For example, the Cube version included with DataMiner 10.5.12 is the same as that included in the 10.4.0 [CU21] and 10.5.0 [CU9] upgrade packages.

From DataMiner 10.2.0 [CU3]/10.2.6 onwards, Cube can also automatically update to a more recent version than the DataMiner version installed on the server. This way you can use the latest Cube features as soon as they are released without having to wait for a server upgrade. In the start window, you can configure the [update track](#selecting-your-cube-update-track) you want to use.

However, note that in some cases, automatic updates will not be possible:

- If a [deployment method](xref:DataMiner_Cube_deployment_methods) is used that does not support automatic updates.
- If [automatic updates are blocked via the Cube System Center](xref:DMA_configuration_related_to_client_applications#managing-client-versions), forcing the use of the version included in the server upgrade package or of a specific preferred Cube version.
- If the difference between the deployed server version and the Cube version is more than two major versions. For example, if you have DataMiner 10.3.0 installed on the server, you will not be able to deploy Cube upgrades for DataMiner 10.6.x.

## Selecting your Cube update track

In the [Cube start window](xref:Cube_start_window), you can select which Cube update track should be used:

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
> You can also right-click the tile representing a particular DMS/DMA in the start window and select *Connect using* to select a specific Cube version to connect to that DMS/DMA with.

## Cube start window upgrades

The start window for DataMiner Cube, which functions as a separate "launcher" application, has an upgrade track of its own.

You can trigger a manual update of the start window by clicking its cogwheel button and selecting *Check for updates*.

However, the start window will also update automatically:

- When you connect to a DataMiner server, the Cube start window checks the server for new software versions and automatically downloads them if they are available.
- The start window will periodically check <https://dataminer.services> for a new version. This check is triggered by a task in Windows Task Scheduler, which is created when the Cube start window is installed. The task is created in the `DataMiner Cube` folder and is named *Update DataMiner Cube_*, followed by the user ID.

The scheduled task used for periodic updates can be edited to change the interval or time or to completely disable the background updates (by disabling the task). To reset the task to the default settings, delete the task and open the Cube start window. The scheduled task will automatically be created again.

> [!NOTE]
> Background updates (triggered by the Windows Task Scheduler) for the Cube start window have a phased rollout. This means that not all clients will be updated at the same time. Different clients will receive the update over a time period of a few days. However, when you trigger a manual update with the *Check for updates* option, this will always update to the latest available version.
