---
uid: Cube_Feature_Release_10.3.5
---

# DataMiner Cube Feature Release 10.3.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.4](xref:General_Feature_Release_10.3.5).

## Highlights

*No highlights have been selected for this release yet*

## Other features

## Changes

### Enhancements

#### Cube will now by default connect using gRPC when connecting to a cloud-connected DataMiner Agent with a remote access URL [ID_35779]

<!-- MR 10.4.0 - FR 10.3.5 -->

When you connect to a cloud-connected DataMiner Agent with a remote access URL ending in `*.dataminer.services`, Cube will now by default connect using gRPC.

#### No longer possible to create pattern matching tags that include predicted trend information [ID_35861]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When viewing a trend graph with a trend prediction (i.e. predicted trend information beyond the "Now" line), it will no longer be possible to create pattern matching tags that include predicted trend data.

In other words, when you select a section of a trend graph that is either partly or entirely past the "Now" line, you will not be able to save the tag.

### Fixes

#### Cube could start to consume excessive CPU cycles whenever an operation took a long time or a deadlock occurred [ID_35614]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

Whenever an operation took a long time or a deadlock occurred, up to now, Cube could start to consume excessive CPU cycles.

#### Problems when Cube was configured to connect using gRPC [ID_35615]

<!-- MR 10.3.0 [CU2] - FR 10.3.5 -->

When you had configured DataMiner Cube to connect using gRPC (by specifying `type=GRPCConnection` in the *ConnectionSettings.txt* file), the following issues could occur:

- The *About* and *Logging* windows would not be available on the login screen if .NET Remoting had been disabled on the DataMiner Agent.

- In some cases, Cube would become unresponsive when retrieving the user thumbnail pictures. These will now be retrieved in the background.

#### Alarm Console: It could take a long time for an active alarms tab to load on a system with a large number of masked alarms [ID_35843]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

Due to a caching issue, on a system with a large number of masked alarms, it could take a long time for an active alarms tab to load.

#### Alarm Console: Base alarm updates would not be shown when the active alarms tab was filtered [ID_35845]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

In a filtered active alarms tab, in some cases, a base alarm will match the filter while the correlated alarm will not. In that case, the base alarm will be shown while the correlated alarm will not.

However, up to now, when a base alarm was updated, the update would not be reflected in the Alarm Console until the filter was removed.

#### DataMiner Cube - Visual Overview: [ServiceDefinitionFilter] placeholder would incorrectly not be resolved when used in a table row filter [ID_35923]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

When, in a shape data field of type *ParameterControlOptions*, you had specified a table row filter that included a `[ServiceDefinitionFilter]` placeholder (e.g. "TableRowFilter:101=[ServiceDefinitionFilter]"), that placeholder would incorrectly not be resolved, causing the linked table control to be empty when filtered.

#### Spectrum analysis: Problem when opening a spectrum element with an empty username [ID_35927]

<!-- MR 10.2.0 [CU14]/10.3.0 [CU2] - FR 10.3.5 -->

An error could occur when you tried to open a spectrum element of which the username was set to NULL.

Also, an exception could be thrown when you tried to copy spectrum settings to the Windows clipboard.
