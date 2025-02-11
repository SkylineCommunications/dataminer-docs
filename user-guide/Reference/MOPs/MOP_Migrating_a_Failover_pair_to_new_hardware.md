---
uid: MOP_Migrating_a_Failover_pair_to_new_hardware
---

# Migrating a Failover pair to new hardware in an existing cluster

The procedure below details how you can migrate a pair of Failover DMAs to new hardware in an existing cluster consisting of multiple Agents. After the procedure, both DMAs should be running just like before, but on new servers.

## Requirements

Access to the DMAs with administrator rights. This requires a connection dedicated completely or partially to this procedure, via VPN or local network.

## Procedure

### Check the system requirements

#### Prerequisites

- Remote access to the system
- Credentials with administrator rights

#### Steps

1. Connect to the servers that will host the new DMAs using the designated VPN or host PC.
1. Check if the basic system requirements for a new DataMiner installation are met. For more information, see [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

### Set up the new pair of DMAs

#### Prerequisites

- The new servers meet DataMiner system requirements
- DataMiner ISO files and upgrade packages are available on the servers
- The servers are available in a standalone network

#### Steps

1. Complete a full backup with database of the main DMA in the Failover pair. We recommend to make sure recent backups of all DMAs in the cluster are available as well.
1. As an additional safety, copy the `ProgramData/Cassandra` folder of the main DMA and the *Views.xml* file of each server. The latter can be used to resolve issues in case the Surveyor structure is different after the migration.
1. Modify the DataMiner backup package as follows:

    1. Change the extension from *.dmbackup* to *.zip*.
    1. Open the compressed archive and remove the file *DMS.xml*.
    1. Change the package extension back to *.dmbackup*.

1. Install a fresh copy of DataMiner on the new hardware:

    1. Make sure the server is in a **standalone network**.
    1. Use the **same DataMiner ID** as the DMA this server will replace.
    1. Use the **same DataMiner version** as the DMA this server will replace.

1. Follow the procedure to acquire a license for the new DMAs. For more information, see [Obtaining a DataMiner license](xref:DataminerLicenses). You will only be able to continue once the licenses have been successfully installed.

### Load the configuration from the old Failover pair to the new pair

#### Prerequisites

- DataMiner has been correctly installed on the new servers as described in the previous section
- The backup package of the old primary DMA is available on the new primary server

#### Steps

1. Take screenshots of the root view elements list on the old primary DMA to see the element state of each element.

1. Remove the old Failover pair from the cluster and shut down the servers.

   See [Removing a DataMiner Agent from a DataMiner System](xref:Removing_a_DataMiner_Agent_from_a_DataMiner_System).

1. Optionally, replace the IPs in the new Failover pair with those of the old pair.

1. Load the backup package from the old primary DMA onto the new primary DMA.

   See [Restoring a DMA using the DataMiner Taskbar Utility](xref:Restoring_a_DMA_using_the_DataMiner_Taskbar_Utility).

1. Confirm that the new DMA and elements are running fine.

1. Set the DMS name in the new DMA and add it to the cluster.

   See [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent).

1. Check if the other DMAs in the cluster can see the new Agent and if the views structure in the Surveyor remains the same.

1. If you see issues with the Surveyor structure, replace the *Views.xml* files with the copies you made earlier and restart the DMAs.

1. Check with the screenshots of the root view element list that you took in the first step to ensure the elements in the new pair are in the same element states.

1. Configure Failover on the new Agent.

   See [Failover configuration in Cube](xref:Failover_configuration_in_Cube).

1. Test the Failover setup by switching back and forth between the online and offline DMAs, and checking if both DMAs are visually the same.

## Time estimate

| Item | Activity | Duration |
|------|----------|----------|
| 1    | Check the system requirements. | 10 min. (outside maintenance window) |
| 2    | Set up the new DMA pair        | 1 hour (outside maintenance window)  |
| 3    | Migrate the Failover pair      | 4 hours |
