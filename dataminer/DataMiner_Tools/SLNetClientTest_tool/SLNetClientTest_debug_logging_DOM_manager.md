---
uid: SLNetClientTest_debug_logging_DOM_manager
---

# Enabling or disabling debug logging for a DOM manager

From DataMiner 10.5.0 [CU2]/10.5.5 onwards<!--RN 42504-->, you can manually enable or disable debug logging for individual DOM managers. This allows you to collect more detailed logs for troubleshooting or analysis when needed. By default, debug logging is disabled.

> [!NOTE]
> Enabling debug logging may significantly increase the amount of logging that is written to disk.

You can enable or disable debug logging using the SLNetClientTest tool:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Apps* > *DataMiner Object Model*.

   This will open the *ModuleSettings* window, which lists the different DOM managers.

1. Select the DOM manager you want to open and click *Open*.

1. Open the *Maintenance* tab.

   In the *Debug Logging* section, you can see the current debug logging status ("disabled" or "enabled"). By default, logging is disabled.

1. Choose one of the following options:

   - *Enable*: Adds or updates an override for the log file of the current DOM manager, setting all log levels to 6 (debug level).

   - *Reset*: Removes any existing override for the log file of the current DOM manager, regardless of the tool that added it. Logging reverts to the default level.

> [!NOTE]
> The status will show "enabled" when a level-6 override is present. If all log files are already at level 6 by default, the status will still show "disabled" until an override is explicitly applied.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
