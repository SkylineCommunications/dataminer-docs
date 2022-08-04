---
uid: ClassLibraryMonitors
---

# DMS Monitors

The Monitor Extension methods provide stable logic to handle eventing. They encapsulate DataMiner subscriptions and handle all correct cleanup and stability guidelines, leaving a developer free to focus on what must happen when an event is triggered.

Currently, the supported methods provide the ability to monitor changes in the full DMS and trigger a C# method to run for:

- Standalone parameter value changes.
- Table cell value changes.
- Table value changes (full table).
- Parameter alarm level changes.
- Table cell alarm level changes.
- Single element alarm changes.
- Single element name changes.
- All elements (DMS-level) alarm changes.
- All elements (DMS-level) name changes.
- Service alarm level changes.
- Service state changes.

More information is available in the following sections:

- <xref:ClassLibraryMonitorsRequirements>
- <xref:ClassLibraryMonitorsGettingStarted>
- <xref:ClassLibraryMonitorsCleanupRules>
- <xref:ClassLibraryMonitorsStartingAStartedMonitor>
- <xref:ClassLibraryMonitorsStoppingAStoppedMonitor>
