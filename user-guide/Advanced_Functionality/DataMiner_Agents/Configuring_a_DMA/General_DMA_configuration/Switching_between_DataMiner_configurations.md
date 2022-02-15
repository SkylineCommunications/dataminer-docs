---
uid: Switching_between_DataMiner_configurations
---

# Switching between DataMiner configurations on a DMA

For staging, demo and testing purposes, you can maintain different DataMiner configurations on one DataMiner Agent and switch between them in a matter of seconds. If necessary, each of these configurations can use a different DataMiner software version. Note that only one of the configurations can be active at any given time.

When adding a DataMiner configuration to a DMA, you can select

- an upgrade package to add a new, blank installation, or

- a backup package to restore a backup of an existing configuration.

> [!WARNING]
> DataMiner configuration switching should never be enabled on an operational system. Only enable this feature on systems used for staging, demo or testing purposes.

> [!TIP]
> See also: [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility)

## Enabling DataMiner configuration switching on a DMA

1. Take a backup of the *C:\\Skyline DataMiner* folder, and make sure it is not shared.

1. Stop DataMiner Taskbar Utility.

   > [!NOTE]
   > If this tool has never been run on the current DMA, then start it and immediately stop it.

1. Start Notepad.exe as Administrator, and open the following file:

   *C:\\Program Files (x86)\\Skyline Communications\\Skyline Taskbar Utility\\ApplicationSettings.xml*

1. Locate the *\<AdvancedOptions>* tag, and set it to “true”:

   ```xml
   <AdvancedOptions>true</AdvancedOptions>
   ```

1. Locate the *\<ConfigFolderPath>* tag, and set it to the folder that should contain the DataMiner configurations for the DMA. This can for instance be a folder on the D drive. By default, it is set to *C:\\Skyline DataMiner Configs\\*.

   The folder *C:\\Skyline DataMiner* will be linked to the configuration that is currently running, but will not actually contain any data. All configurations will be stored at the configured path.

1. Save the *ApplicationSettings.xml* file.

1. Start DataMiner Taskbar Utility as an Administrator who has full control over the C drive.

1. Right-click DataMiner Taskbar Utility in the notification area, select *Start Using Configs*, and confirm.

   The current contents of the *C:\\Skyline DataMiner* folder and all its subfolders will now be copied to the specified configurations folder.

   > [!NOTE]
   > DataMiner Taskbar Utility will stop the running DataMiner software to make sure that none of the files in *C:\\Skyline DataMiner* are locked. In certain rare cases, however, files can be locked by third-party processes (e.g. anti-virus or even NATS). If this is the case, you will have to kill those processes manually and retry step 7.

## Adding DataMiner configurations to a DMA

1. Right-click DataMiner Taskbar Utility in the notification area, select *Use Config \> Manage Configs ...*

1. In the *Manage Configs* dialog box, click *Add*.

1. In the *Add Config* dialog box, enter the name of the configuration and click either *Blank config* or *Existing config*.

   - If you clicked *Blank config*, then select an upgrade package, and click *Open*.

   - If you clicked *Existing config*, then select a backup package, and click *Open*.

1. Click *Create* to install the package you selected.

> [!NOTE]
> - For a new configuration, it is possible that the files “ConnectionSettings.txt” and “EndPoints.txt” are missing in the *Webpages* folder of a particular configuration. In that case, copy them to this folder from the folder *C:\\Skyline DataMiner Configs\\Skyline DataMiner\\Webpages*.
> - After you have created a new configuration, it is possible that the DMA has problems restarting, so a manual restart is advisable.

## Switching to another DataMiner configuration

- Right-click DataMiner Taskbar Utility in the notification area, click *Use Config*, and select one of the listed DataMiner configurations.
