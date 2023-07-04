---
uid: Cube_Feature_Release_10.3.9
---

# DataMiner Cube Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.9](xref:General_Feature_Release_10.3.9).

## Highlights

*No highlights have been selected yet.*

## Other new features

*No features have been added to this release yet.*

## Changes

### Enhancements

#### Errors or alarms will no longer be generated at startup when the DMS does not include an indexing engine [ID_36590]

<!-- MR 10.4.0 - FR 10.3.9 -->

From now on, when the DataMiner System does not include an indexing engine, no run-time errors or alarms of type "Notice" will be generated for ServiceManager, TicketingManager, ResourceManager and ProfilesManager at startup.

Also, when you open the *Profiles*, *Resources* or *Bookings* app in Cube, a message will now appear, saying that the DataMiner System does not include an indexing engine.

### Fixes

#### DataMiner Cube: Report or dashboard would not be selected after 'Email', 'Upload to FTP' or 'Upload to shared folder' action was initialized [ID_36631]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In *Automation*, *Correlation* and *Scheduler*, you can select a report of a dashboard in an *Email*, *Upload to FTP* or *Upload to shared folder* action. When such an action was initialized, in some rare cases, the report or dashboard would not be automatically selected.
