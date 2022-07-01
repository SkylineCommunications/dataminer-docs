---
uid: Automatic_cleanup_of_alarm_recordings_folder
---

# Automatic cleanup of alarm recordings folder

When spectrum monitors generate an alarm, they create an alarm recording and store it in the folder *C:\\Skyline DataMiner\\Spectrum Alarm Recordings\\*.

By default, that folder has a maximum size of 250MB. However, if necessary, this maximum size can be changed in *Maintenancesettings.xml*.

## Clean-up procedure

When the folder *C:\\Skyline DataMiner\\Spectrum Alarm Recordings\\* is full, DataMiner will automatically remove recordings using a particular algorithm.

Each time a new alarm recording has been stored in the above-mentioned folder, DataMiner will check the total size of all files in the folder. If that total size exceeds the configured maximum size, DataMiner will execute the following steps until the total size of all files in the folder is less than the configured maximum size.

1. Remove all alarm recordings for alarms that have an ID that is less than the smallest alarm ID in the database.

1. Remove all alarm recordings for alarms of severity “Warning”, unless they are less than 2 weeks old.

1. Remove all alarm recordings for alarms of severity “Minor”, unless they are less than 2 weeks old.

1. Remove all alarm recordings for alarms of severity “Major”, unless they are less than 2 weeks old.

1. Remove all alarm recordings for alarms of severity “Critical”, unless they are less than 2 weeks old.

1. Remove all alarm recordings, unless they are less than 2 weeks old.

1. Remove all alarm recordings for alarms of severity “Warning”, unless they are less than 1 day old.

1. Remove all alarm recordings for alarms of severity “Minor”, unless they are less than 1 day old.

1. Remove all alarm recordings for alarms of severity “Major”, unless they are less than 1 day old.

1. Remove all alarm recordings for alarms of severity “Critical”, unless they are less than 1 day old.

1. Remove all alarm recordings, unless they are less than 1 day old.

> [!NOTE]
>
> - Unless they are deleted in step 1, alarm recordings that are less than 1 day old are never removed. This means that, in some cases, the total size of the folder’s contents can temporarily exceed the configured maximum size.
> - Names of alarm recordings include the alarm severity. Example: 0006221671.t=critical.dat

> [!TIP]
> See also: [MaintenanceSettings.xml](xref:MaintenanceSettings_xml)
