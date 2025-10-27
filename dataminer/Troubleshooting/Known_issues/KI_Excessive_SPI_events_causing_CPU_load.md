---
uid: Excessive_SPI_events_causing_CPU_load
---

# Increased CPU load and degraded performance because of excessive number of SPI events

## Affected versions

10.2 Main and Feature Release versions prior to 10.2.0 [CU6] and 10.2.9.

## Cause

Processes using SPIs would broadcast on the SPI.Discovery subject of the NATS bus on a high-frequency timer. Because the timer was triggered too often, it could occur that DataMiner processes such as SLPort, SLProtocol, or SLWatchDog broadcast an excessive number of events, causing CPU usage to increase and performance to degrade. In extreme cases, this could also cause problems with the involved processes.

## Fix

Install DataMiner 10.2.0 [CU6] or 10.2.9.

## Issue description

Increased CPU load and performance degradation. The following symptoms have for instance been noticed, though it should be noted that if you see such a symptom, this does not necessarily mean that this issue is the cause:

- Increased CPU usage by SLNet.
- Spikes in CPU usage by SLNet.
- Slower system performance because of server resource shortages, e.g. slower booking creation.
