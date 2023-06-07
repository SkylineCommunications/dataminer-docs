---
uid: Regarding_virtual_servers
---

# Regarding virtual servers

The DataMiner software can be run on a virtual server as long as it has sufficient resources available (CPU, memory, hard disk space and throughput, etc.), as indicated in the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

Please note the following:

- For the CPU, it is mainly the PassMark that determines whether the CPU has sufficient power, rather than the number of cores. Make sure you assign enough CPU power to keep the CPU usage under 50% and the PassMark above the minimum limit indicated above, e.g. 10000. Also, we recommend to avoid oversubscribing.

- As far as memory is concerned, we recommend the same minimum as indicated in the above requirements.

- For the disk, the disk throughput is of vital importance. As there will be a very active database on the disk, you need to ensure there is not only sufficient size on the disk, but also sufficient IO. The following minimum requirements apply at all times for each server:

    - 4 KiB blocks should be 10 MB/s or higher.
    - 512 KiB blocks should be 300 MB/s or higher.
    - The average latency should be lower than 10 ms.
