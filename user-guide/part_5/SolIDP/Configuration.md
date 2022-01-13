## Configuration

The *Configuration* subtab of the *Admin* tab consists of the following pages:

- **Network Shares**: Allows you to modify the credentials and path for the configuration archive, the credentials for the working directories, and the working directories list. In the working directories list, you can specify a working directory on the network shares for each hosting DMA. Working directories temporarily contain files during a configuration update. A working directory must be available for each DMA in the DMS.

- **Purge Settings**: Allows you to configure the automatic cleanup of the configuration archive and check the KPIs related to the automatic cleanup.

    - **By disk usage**: Allows you to set a limit on how much space the backups use on the disk and verify how much space they currently use.

    - **By total number of backups**: Allows you to set a limit on the total number of backups and verify how many backups are currently in the archive.

    - **By number of backups per device**: Allows you to set a limit on the number of backups per device and verify how many devices are currently in the archive.

    > [!NOTE]
    > - When one of these limits is enabled, it is checked whenever a backup is added to the configuration archive. The oldest backups are always removed first.
    > - If purging happens based on the total number of backups or the number of backups per element, only full configuration backups are taken into account. However, if it happens based on disk usage, the size of all files (including the extra files used for change detection) is taken into account.
    > - Alarm monitoring and trending can be enabled for the KPIs.

- **Backup**: Lists the supported file extensions for visualizations. By default, the XML and TXT extensions are listed. If a file has an extension that is not listed here, the *Show content* action on the *Configuration* > *Backups* tab and the *Compare* action on the *Configuration* > *Compare* tab will result in an error.

    Below this is a table that allows you to enable or disable backups for specific configuration backup types. When you start a configuration backup, only the enabled types will be available. If all types are disabled, a notification will be displayed instead.
