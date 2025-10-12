---
uid: SchemaMaintenanceSettings
---

# MaintenanceSettings Schema

MaintenanceSettings XML Schema.

## Root element

[MaintenanceSettings](xref:MaintenanceSettings)

## Example

This is an example of a DataMiner.xml file:

```xml
<MaintenanceSettings>
  <AlarmSettings
      serviceTimeoutMode="displayTimeout"
      viewTimeoutMode="displayBoth">
    <AlarmsPerParameter recurring="true">60</AlarmsPerParameter>
    <Blinking blinkInterval="1000" blankInterval="200" enabled="true" />
    <MaxFreezeAlarms>1000</MaxFreezeAlarms>
    <MaxFreezeTime>60000000</MaxFreezeTime>
    <UseCreationTimeAsMainTime>true</UseCreationTimeAsMainTime>
    <AutoClear>true</AutoClear>
  </AlarmSettings>
  <AutoElementLock time="5000">TRUE</AutoElementLock>
  <BackupSettings method="takebackup">...</BackupSettings>
  <DMSRevision>
    <StartTime>00:00:00</StartTime>
    <StartTime>12:00:00</StartTime>
    ...
  </DMSRevision>
  <Documents>
    <MaxSize>20</MaxSize>
  </Documents>
  <Logging>
    <MaxSize>10</MaxSize>
  </Logging>
  <ProtocolSettings>
    <ExecutionVerification timeout="5000">True</ExecutionVerification>
  </ProtocolSettings>
  <RecycleBinSize>50</RecycleBinSize>
  <Spectrum>
    <AlarmRecordings maxDirSize="500" />
  </Spectrum>
  <Surveyor>
    <ViewStatistics>[#TotalAlarms] Active Alarms</ViewStatistics>
    <ServiceStatistics>[#TotalAlarms] Active Alarms</ServiceStatistics>
    <ElementStatistics>[#TotalAlarms] Active Alarms</ElementStatistics>
  </Surveyor>
  <SLNet>...</SLNet>
  <Trending>
    <EDCurves></EDCurves>
    <SDCurves></SDCurves>
    <TimeSpan1HourRecords window="60" />
    <TimeSpan5MinRecords window="5" />
    <WarningLevel></WarningLevel>
  </Trending>
  <WatchDog>
    <EMail active="FALSE" />
    <TimeoutTime>5</TimeoutTime>
    <Errors>2</Errors>
    <Actions restartElementOnProtocolRTE="true">Alarm;switch</Actions>
    <FailoverOnRTE>
      <SkipRTE process="SLDataMiner.exe" thread="Database Offload Thread [local]" />
      <SkipRTE process="SLDataMiner.exe" thread="Database cleaning" />
    </FailoverOnRTE>
  </WatchDog>
  <Network bitRateTracking="true"/>
</MaintenanceSettings>

```
