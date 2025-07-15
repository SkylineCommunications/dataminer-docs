---
uid: SLNetClientTest_changing_log_levels
---

# Changing the log levels for a log file

In DataMiner Cube, you can [change the log levels](xref:DataMiner_logging#changing-log-levels) for all displayed files on the *Logging* page in System Center. However, not all log files are displayed there. To change the log levels for files that are not displayed in Cube, you need to use the SLNetClientTest tool.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select *UpdateLogFileSettingsMessage*.

1. In the box next to *LogConfig*, click the "..." button.

1. Expand *LogConfig*, select the *DebugLevel*, *ErrorLevel*, and *InfoLevel* you want, and specify the name of the log file.

   For example:

   ![UpdateLogFileSettingsMessage configuration in SLNetClientTest tool](~/user-guide/images/SLNetClientTest_UpdateLogFileSettingsMessage.png)<br>
   *UpdateLogFileSettingsMessage configuration in SLNetClientTest tool in DataMiner 10.3.6*

1. Click *Send Message*.

> [!NOTE]
> Logging requires resources from your DataMiner Agent (CPU and HD usage), so be careful with the higher log levels like *Everything* and *Development*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
