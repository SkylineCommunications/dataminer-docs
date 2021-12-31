## SLAnalytics.config

Prior to DataMiner 9.5.5, this file is used to configure settings for the SLAnalytics process. It is located in the folder *C:\\Skyline DataMiner\\Files*.

> [!TIP]
> See also:
> [SLAnalytics](../../part_3/DataminerSystems/DataMiner_processes.md#slanalytics)

> [!NOTE]
> Changes made to the *SLAnalytics.config* file only take effect after a DataMiner restart.

### TimeOfBackup and BackupInterval

These settings determine the interval to back up the current prediction model in the file *Timeseries.models,* located in the folder *C:\\Skyline DataMiner\\Analytics*.

> [!NOTE]
> The *TimeOfBackup* and *BackupInterval* settings are no longer taken into account from DataMiner 9.5.5 onwards. From this version of DataMiner onwards, prediction models are no longer backed up, but instead retrieved from a cache and re-computed in case they are not available in the cache.

Both the *TimeOfBackup* and *BackupInterval *setting can contain a value indicating a number of seconds:

- If both *TimeOfBackup* (X) and *BackupInterval* (Y) contain a positive number of seconds, the first backup will be taken at X seconds after midnight, and the following backups will be taken every Y seconds.

- If *TimeOfBackup* (X) contains a negative number of seconds, and *BackupInterval* (Y) contains a positive number of seconds, the first backup will be taken Y seconds after SLAnalytics has started, and the following backups will be taken every Y seconds.

- *BackupInterval* has to contain a number equal to or greater than 5. If it contains a number smaller than 5, this setting will be disregarded. In that case, if *TimeOfBackup* contains a number of seconds equal to or greater than 0, only one backup will be taken.

### arrowWindowLength and updateArrowTime

Available from DataMiner 9.0.5 onwards. These settings control the behavior of trend prediction icons:

- **arrowWindowLength**: The time window used when calculating which trend icons should be displayed. The arrow icons reflect the parameter behavior during this interval up to the present time. Default value: 3600 seconds (i.e. 1 hour)

- **updateArrowTime**: The time between two updates of the trend icon when an element card stays open. Default value: 300 seconds (i.e. 5 minutes).

### Example of SLAnalytics.config configuration

```xml
<configuration version="1">                 
  <filename>SLAnalytics.config</filename>    
  <PredictionEnabled>1</PredictionEnabled>   
  <MonitoringEnabled>1</MonitoringEnabled>   
  <TimeOfBackup>0</TimeOfBackup>             
  <BackupInterval>86400</BackupInterval>     
  <arrowWindowLength>3600</arrowWindowLength>
  <updateArrowTime>300</updateArrowTime>     
</configuration>                            
```

 
