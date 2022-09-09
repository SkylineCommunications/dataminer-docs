---
uid: Configuration
---

# Configuration

The *Configuration* subtab of the *Admin* tab consists of the pages detailed below.

## Network Shares

### DataMiner Configuration Archive

The DataMiner Configuration Archive is a network share which is used by IDP to store the configuration backups. The below settings need to be configured: 

- **Domain** holds the domain of the account 
- **Username** holds the name of the account 
- **Password** holds the password of the account 
- **Path** is the network path to the configuration archive

The **Connection Status** can be either *Connected* or *Disconnected*. It will be *Connected* if the configured credentials can be used to connect to the network path.


### File Transfer Credentials

These are the credentials IDP will be use to transfer files between IDP and other servers in the network. This includes working directories. 

The credentials are required 

- when configuration backups are performed by exchanging a file location. In that case the credentials need to have full control over the file location.   These are required when configurati configuration backups are 
- or when configuration updates are performed. In that case, the credentials need to have full control over the shared locations of the working directories.

The below settings need to be configured:

- **Domain** holds the domain of the account 
- **Username** holds the name of the account 
- **Password** holds the password of the account 


Note that prior to IDP 1.1.20, the file transfer credentials are mentioned under *Working Directories*.

### Working Directories

In the working directories list, you can specify a working directory on the network shares for each hosting DMA. Working directories temporarily contain files during a configuration update. A working directory must be available for each DMA in the DMS.

For each working directory in the DMS, the be

- **Agent Name** contains the name of the hosting DMA e.g. *ZIINE-H66-G02*
- **Share Location** needs to be configured and is the network path and identifies how other servers can access the working directory *\\\ZIINE-H66-G02\\workingDir*
- **Local Directory** needs to be configured and is the path on the hosting DMA of the working directory e.g. *C:\\data\\working_directory*
- **Directory Status** can be either *Available* or *Not Available*. It will be *Available* when the working directory is accessible via the Share Location and if the File Transfer Credentials are valid.




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
