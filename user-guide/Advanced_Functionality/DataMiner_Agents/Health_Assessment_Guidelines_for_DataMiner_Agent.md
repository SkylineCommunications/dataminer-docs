---
uid: Health_Assessment_Guidelines_for_DataMiner_Agent
---

# Health assessment guidelines for DataMiner Agents

Monitoring the health of a DataMiner Agent requires attention for several key metrics, including but not necessarily limited to processor load, physical memory and commit charge, disk space, disk busy time, network throughput, threads, virtual bytes, handles, database queue, etc.

While it is not possible to provide an exact definition for when a DMA reaches its limits, the following guidelines should be considered for individual metrics.

## Guidelines

### Processor Load

The average CPU level should not exceed 60%.

If it does exceed 60%, the DMA will indicate a warning. If the average CPU level exceeds 80%, the alarm state of the DMA will be set to critical.

### Physical Memory & Commit Charge

A minimum of 25% of physical memory should be available on average.

If less than 25% is available, the DMA will indicate a warning. If less than 12.5% of physical memory is available, the alarm state of the DMA will be set to critical.

### Disk Space

A minimum of 10 GB of space should be available for a system in full operation.

If less than 10 GB is available, the DMA will indicate a warning. If less than 5 GB of space is available, the alarm state of the DMA will be set to critical.

### Disk Busy Time

The disk busy time should be less than 40% on average.

If it does exceed 40%, the DMA will indicate a warning. If the disk busy time exceeds 70%, the alarm state of the DMA will be set to critical.

### Avg. Disk sec/Transfer

The Avg. Disk sec/Transfer rate should be lower than 10 ms.

If it becomes more than 10 ms, the DMA will indicate a warning. If the Avg. Disk sec/Transfer rate exceeds 20 ms, the alarm state of the DMA will be set to critical.

> [!NOTE]
> Failing to operate within the above guidelines may cause operational problems with your DataMiner system, which are not covered under warranty or maintenance and support.

## Remarks

- We recommended checking with Skyline Communications for a system health assessment whenever any of the above-mentioned metrics reaches the specified threshold.

- Breaches of individual metrics do not necessarily translate to an overall system overload. Certain configuration changes or architecture changes can sometimes effectively return the system to normal.

- Typically, we also recommend configuring DataMiner to monitor its own servers, and to dispatch a comprehensive email report every 24 hours with trend information about some of the key metrics such as CPU, memory, etc.
