---
uid: Before_you_begin_to_set_up_a_new_DMS
description: "Before you begin to set up a new cluster, decide which DataMiner Agent will be the primary node during the initial cluster setup."
---

# Before you begin to set up a new cluster

Before you set up a new cluster, decide which DataMiner Agent will be the "primary node" during the initial cluster setup.

The "primary node" has to be added to the cluster first, before all other nodes. From this node, all other nodes in the cluster will copy data during the initial synchronization.

Once the initial synchronization of a newly created cluster has finished, the "primary node" will lose its primary status. In a DataMiner cluster, all nodes are of equal importance.

> [!NOTE]
>
> - During the initial synchronization, some data is copied from the primary node to the other nodes. As such, it is important that the **other nodes are empty**, as otherwise data may be lost and issues may occur. In addition, it is also important that the other nodes have the same software version as the primary node.
> - As local users are synchronized, their passwords are checked against the password policy of the new server. To prevent issues during user sync, make sure the **password policy** across the servers in the cluster is the **same**.
> - Synchronization depends on the server time. It is therefore important that all servers in the cluster are **synchronized to the same NTP server**.
> - For more information about the data that is synchronized among nodes in a cluster, see [Skyline DataMiner folder](xref:Overview_of_the_files_found_in_the_root_folder).
