---
uid: Configuration
---

# Configuration

The *Configuration* subtab of the *Admin* tab consists of the pages detailed below.

## Network Shares

### DataMiner Configuration Archive

The DataMiner Configuration Archive is a network share used by IDP to store configuration backups. The following settings need to be configured:

- **Domain**: The domain of the account used to connect to the network share.
- **Username**: The name of the account used to connect to the network share.
- **Password**: The password corresponding with the username.
- **Path**: The network path to the configuration archive.

The **Connection Status** is *Connected* when the configured credentials can be used to connect to the network path. Otherwise, it is *Disconnected*.

### File Transfer Credentials

These are the credentials IDP will be use to transfer files between IDP and other servers in the network. This includes working directories.

The credentials are required in the following cases:

- When configuration backups are performed by exchanging a file location. In this case, the credentials you specify must allow full control over the file location.
- When configuration updates are performed. In this case, the credentials must allow full control over the shared locations of the working directories.

The following settings need to be configured:

- **Domain**: The domain of the account used to transfer files.
- **Username**: The name of the account used to transfer files
- **Password**: The password corresponding with the username.

> [!NOTE]
> Prior to IDP 1.1.20, the file transfer credentials are mentioned under *Working Directories*.

### Working Directories

In the working directories list, you can specify a working directory on the network shares for each hosting DMA. Working directories temporarily contain files during a configuration update. A working directory must be available for each DMA in the DMS.

For each working directory in the DMS, the following settings need to be configured:

- **Share Location**: The network path that identifies how other servers can access the working directory, e.g. *\\\ZIINE-H66-G02\\workingDir*. This must always be configured.
- **Local Directory**: The path of the working directory on the hosting DMA, e.g. *C:\\data\\working_directory*. This must always be configured.

In the list of working directories, aside from the settings configured above, the following information is also displayed for each working directory:

- **Agent Name**: The name of the hosting DMA e.g. *ZIINE-H66-G02*.
- **Directory Status**: This status is *Available* when the working directory is accessible via the specified share location and the specified file transfer credentials are valid. Otherwise, it is *Not Available*.

## Purge Settings

On this page, you can configure the automatic cleanup of the configuration archive and check the KPIs related to the automatic cleanup.

- **By disk usage**: Allows you to set a limit on how much space the backups use on the disk and verify how much space they currently use.

- **By total number of backups**: Allows you to set a limit on the total number of backups and verify how many backups are currently in the archive.

- **By number of backups per device**: Allows you to set a limit on the number of backups per device and verify how many devices are currently in the archive.

> [!NOTE]
> - When one of these limits is enabled, it is checked whenever a backup is added to the configuration archive. The oldest backups are always removed first.
> - If purging happens based on the total number of backups or the number of backups per element, only full configuration backups are taken into account. However, if it happens based on disk usage, the size of all files (including the extra files used for change detection) is taken into account.
> - Alarm monitoring and trending can be enabled for the KPIs.

## Backup

This page lists the supported file extensions for visualizations. By default, the XML and TXT extensions are listed. If a file has an extension that is not listed here, the *Show content* action on the *Configuration* > *Backups* tab and the *Compare* action on the *Configuration* > *Compare* tab will result in an error.

Below this is a table that allows you to enable or disable backups for specific configuration backup types. When you start a configuration backup, only the enabled types will be available. If all types are disabled, a notification will be displayed instead.
