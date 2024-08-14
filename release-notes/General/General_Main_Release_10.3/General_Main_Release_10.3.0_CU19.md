---
uid: General_Main_Release_10.3.0_CU19
---

# General Main Release 10.3.0 CU19 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Caching of protocol signature information will enhance overall performance during a DataMiner startup [ID_39468]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.7 -->

Information regarding protocol signature validation will now be cached. This will considerably enhance overall performance during a DataMiner startup.

#### Automation: Using the Engine.Sleep method in an Automation script could affect other scripts [ID_40104]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, using the *Engine.Sleep* method in an Automation script could cause issues that would affect other scripts. This has now been resolved.

### Fixes

#### Problem in SLDataMiner when redundancy groups were configured to switch based on connectivity [ID_40118]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When redundancy groups were configured to switch based on connectivity, it could occur that the signals sent to SLDataMiner contained duplicates. In a system with a heavy load, this could cause too many of these to be sent, which would cause a memory leak in the SLDataMiner process and eventually caused the process to crash.

Performance improvements have now been implemented to avoid sending duplicate signals and to better process the signals. A throttling mechanism has also been implemented: in case SLDataMiner detects that too many signals are being sent, the DCF calculation will be slowed down to allow the system to catch up. In the logging, this will be mentioned in *SLConnectivity.txt* like in the example below:

```txt
07/04 09:13:32.713|SLNet.exe|Log|INF|0|174|Received throttle request to slowdown DCF path calculation current value: 5000 ms

2024/07/04 09:15:34.019|SLNet.exe|Log|INF|0|172|Received stop throttle request to resume normal DCF path calculation current value: 1000 ms

07/04 09:13:32.713|SLNet.exe|Log|INF|0|174|Received throttle request to slowdown DCF path calculation current value: 5000 ms

2024/07/04 09:16:29.462|SLNet.exe|Log|INF|0|175|Received throttle request to slowdown DCF path calculation current value: 25000 ms

2024/07/04 09:22:51.732|SLNet.exe|Log|INF|0|54|Received stop throttle request to resume normal DCF path calculation current value: 1000 ms
```

#### Changes implemented with parameter-specific template editors not saved correctly [ID_40125]

<!-- MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.10 -->

When you changed the alarm or trend template for a table parameter (e.g. by going to the templates tab on the parameter card), it could occur that the wrong line from the template was edited. For example, if a template contained exactly one line for a column in a table, and that line was configured with the filter "SL*", the parameter template editor would show the configuration corresponding to the line in the template with the filter even if that line was not applicable for the current cell. Now, instead an empty template configuration will be shown, corresponding to the filter "\*". When you edit and save this configuration, a new line with filter "\*" will be added to the template.

In addition, when there were two or more lines in the trend template for a table parameter, but none were applicable for the current cell for which you edited the trend template, the parameter template editor would show and create a new line in the template corresponding to an empty filter, instead of to the filter "\*". This has now also been fixed.

Finally, if you changed the information template for a parameter, and the information template did not contain a line for the current parameter, the ID was not saved correctly. In addition, for table parameters, a line with an empty filter would be saved, instead of the filter "\*".
