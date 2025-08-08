---
uid: Regarding_virtual_servers
---

# Regarding virtual servers

The DataMiner software can be run on a virtual server as long as it has sufficient resources available (CPU, memory, hard disk space and throughput, etc.), as indicated in the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

Please note the following:

- For the CPU, it is mainly the PassMark that determines whether the CPU has sufficient power, rather than the number of cores. Make sure you assign enough CPU power to keep the average CPU usage under 50% and the PassMark above the minimum limit indicated above, e.g. 10000. Also, we recommend to avoid oversubscribing.

- As far as memory is concerned, we recommend the same minimum as indicated in the above requirements.

- For the disk, the disk throughput is of vital importance if you are hosting DataMiner databases on it. As these database are very active, you need to ensure there is not only sufficient size on the disk, but also sufficient IO. The following minimum requirements apply at all times for each server:

  - 4 KiB blocks should be 10 MB/s or higher.
  - 512 KiB blocks should be 300 MB/s or higher.
  - The average latency should be lower than 10 ms.

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>We recommend using <a href="xref:STaaS" style="color: #657AB7;">DataMiner Storage as a Service</a> instead of hosting the DataMiner storage yourself.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>
