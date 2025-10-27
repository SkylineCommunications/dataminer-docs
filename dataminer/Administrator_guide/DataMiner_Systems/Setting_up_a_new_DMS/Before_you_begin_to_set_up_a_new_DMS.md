---
uid: Before_you_begin_to_set_up_a_new_DMS
---

# Before you begin to set up a new DMS

Before you set up a new DataMiner System (DMS), decide which DataMiner Agent will be the “primary DMA” during the initial DMS setup.

The “primary DMA” has to be added to the DMS first, before all other DMAs. From this DMA, all other DMAs in the DMS will copy data during the initial synchronization.

Once the initial synchronization of a newly created DMS has finished, the “primary DMA” will lose its primary status. In a DMS, all are of equal importance.

> [!NOTE]
>
> - During the initial synchronization, some data is copied from the primary DMA to the other DMAs. As such, it is important that the **other DMAs are empty**, as otherwise data may be lost and issues may occur. In addition, it is also important that the other DMAs have the same software version as the primary DMA.
> - As local users are synchronized, their passwords are checked against the password policy of the new server. To prevent issues during user sync, make sure the **password policy** across the servers in the DMS is the **same**.
> - Synchronization depends on the server time. It is therefore important that all servers in the DMS are **synchronized to the same NTP server**.
> - For more information about the data that is synchronized among DMAs in a DMS, see [Skyline DataMiner folder](xref:Overview_of_the_files_found_in_the_root_folder).
