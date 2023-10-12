---
uid: MOP_Downgrading_a_DMS
---

# Downgrading a DMS

The procedure below outlines the best ways to downgrade a DMS. The recommended way is using a virtual machine snapshot, but you can also downgrade via DataMiner. Follow the instructions below carefully to ensure maximum availability of your system.

Downgrading may be required in case unexpected issues occur after an update. In most cases, if this occurs we recommend that a full investigation is done by the Skyline team first. However, if a very urgent resolution is required, a downgrade can be considered.

## Requirements

### For a downgrade with VM snapshot restore

- A snapshot must be created before you start an update. Make sure the snapshot is ready before you start the update.
- Make sure the snapshot is taken as shortly before the upgrade as possible to minimize data loss.

### For a downgrade with DataMiner

- Access to the servers with administrator rights is required. A connection should be available that is dedicated completely or partially to this procedure, via VPN or local network.
- A valid DataMiner upgrade package with the target DataMiner version must be available.

## Procedure

### Downgrade with VM snapshot restore (preferred)

We recommend downgrading with a **virtual machine snapshot**. This will fully reset the state of the server back to a known stable state, automatically transferring configuration and database files. It also requires fewer actions than a DataMiner downgrade.

The exact method to do this depends on your setup and is beyond the scope of this procedure. Refer to the documentation for your virtual machine setup instead.

Note that if there is a separate **database VM**, a snapshot will potentially also need to be restored, since a major DataMiner update could affect the database schema.

For remote database clusters, please follow the **in-house procedures** to roll back the data/schema in order to restore your data. For example, restoring Cassandra snapshots may be preferable over restoring a VM snapshot.

### Downgrade with DataMiner

1. Download the DataMiner upgrade package for the version you want to downgrade to. Upgrade packages can be downloaded from [DataMiner Dojo](https://community.dataminer.services/downloads/).

1. Perform the upgrade procedure with this package as described in [Upgrading a DMA/DMS](xref:MOP_Upgrading_a_DMA_DMS).

1. Only when downgrading from **DataMiner 10.3.8 or higher to DataMiner 10.3.4, 10.3.5, 10.3.6, or 10.3.7**, execute the following extra steps **on each of the DMAs** in the cluster to make sure the DMAs are able to start up after the downgrade.

   1. Wait for the downgrade to have "completed". The upgrade status will keep showing "Starting up (xx%)" at this stage.

   1. [Stop the DataMiner Software](xref:Starting_or_stopping_a_DMA_using_DataMiner_Taskbar_Utility).

   1. Open the Windows *Add or remove programs* window.

   1. Uninstall the following programs:

      1. *DataMiner StorageModule* (version 3.0.3 or higher).

      1. *DataMiner UserDefinableApiEndpoint* (version 2.0.0 or higher).
 
   1. Go to the folder `C:\Skyline DataMiner\tools\ModuleInstallers` on the DMA and re-install the following programs:

      1. *DataMiner StorageModule* (version 1.0.1 or lower).

      1. *DataMiner UserDefinableApiEndpoint* (version 1.1.1 or lower).

   1. Start the DataMiner software.

> [!NOTE]
> If you need to go back several major DataMiner versions, e.g. from DataMiner 10.2.0 to DataMiner 9.6.0, we recommend downloading a package for every major version you are downgrading to. For example, to downgrade from DataMiner 10.2.0 to DataMiner 9.6.0, you will need a package for 9.6.0, 10.0.0, and 10.1.0. You will then first need to install DataMiner 10.1.0, then DataMiner 10.0.0, and then DataMiner 9.6.0 to complete the downgrade.

## Time estimate

### For a downgrade with VM snapshot restore

The timing for a VM snapshot restore depends on your specific setup.

### For a downgrade with DataMiner

The timing for a downgrade is similar to that for a DataMiner upgrade. See [Upgrading a DMA/DMS](xref:MOP_Upgrading_a_DMA_DMS).
