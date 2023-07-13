---
uid: SRM_1.2.32
---

# SRM 1.2.32

> [!NOTE]
> This version requires that **DataMiner 10.3.2.0 – 12627 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### New Factor field to multiply capacity in SRM_AddDcfInterfacesAsResources script [ID_36587]

In the script *SRM_AddDcfInterfacesAsResources*, which creates network interface resources, you can now multiply the capacity by a fixed value in order to not use the full capacity of the link.

For this purpose, a new *Factor* field has been introduced in the *CapacityLink* class. When this field is filled in, the capacity value will be multiplied by the specified value. To divide by a value, use a value between 0 and 1.

For example:

`{"ColumnId":2815,"ProfileParameterName":"Bitrate", "Factor": 0.75}`

## Changes

### Enhancements

#### Improved performance of Profile-Load Scripts [ID_36665]

An unnecessary *ResourceManager.GetResource* call is now avoided, resulting in improved performance of Profile-Load Scripts. The resource is now cached in the LSO script, and the Profile-Load Scripts can retrieve it from the cache.

### Fixes

#### Start events running twice for contributing booking starting in the past with late conversion [ID_36515]

If late conversion was enabled for a contributing booking, it could occur that the start events ran twice when the booking was confirmed and the start date was in the past.

#### Incorrect exception when booking with regular resource was started [ID_36522]

When a booking with at least one regular resource was started, an exception could incorrectly be included in the log file.

#### Pre-roll stage removed from ongoing booking [ID_36532]

When the pre-roll stage of a booking was already over, and a user adjusted the time of the booking by specifying a correct start time but no pre-roll time, this caused the pre-roll stage of the booking to be removed, causing the start events to be scheduled again.

To prevent this issue, an InvalidOperationException will now be thrown if a request like this is done.

#### Error when exporting full SRM configuration [ID_36614]

If the full SRM configuration was exported and it included a protocol with a long name that exported more than one function, an error could occur:

```text
System.IO.IOException: Cannot create a file when that file already exists.
   at System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
   at System.IO.Directory.InternalMove(String sourceDirName, String destDirName, Boolean checkHost)
   at Skyline.DataMiner.Library.Solutions.SRM.Configuration.Exporters.FunctionExporter.MoveFilesToExportFolder()
   at Skyline.DataMiner.Library.Solutions.SRM.Configuration.Exporters.FunctionExporter.Export(Boolean createPackage, IProgress`1 progress)
   at Skyline.DataMiner.Library.Solutions.SRM.Configuration.Exporters.ServiceDefinitionsFunctionsExporter.Export(IEnumerable`1 serviceDefinitions)
   at Skyline.DataMiner.Library.Solutions.SRM.Configuration.Exporter.Export()
   at Skyline.DataMiner.Library.Solutions.SRM.BookingManager.ExportConfiguration()
   at SRM.ExportFullConfiguration.Script.Run(Engine engine)
```

This was caused by the truncation of the function name to cope with the limitations of the path length in Windows, which could cause two functions to have the same path. The truncation will now be done differently to prevent this issue: only the capital letters from the protocol name will be kept.

#### LSO script not executed when booking life cycle already matched service state event [ID_36681]

When an external event was scheduled during a particular booking stage but only effectively got fully executed during the next booking stage, this could cause a problem for bookings that left the failure state while the next booking stage was already ongoing but before the event was executed. The LSO script was not triggered because the SRM framework incorrectly assumed that the event had already been executed. This issue will now be prevented.
