---
uid: Cube_Feature_Release_10.6.1
---

# DataMiner Cube Feature Release 10.6.1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU22] and 10.5.0 [CU10].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.1](xref:General_Feature_Release_10.6.1).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.1](xref:Web_apps_Feature_Release_10.6.1).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### SPI log entries containing the duration of an SRM server call will now include either the number of objects or the requested object ID [ID 44014]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

From now on, SPI log entries containing the duration of an SRM server call will now include either the number of objects or the requested object ID.

#### System Center: Query executor and indexing engine settings will no longer be available when the DMS is using STaaS [ID 44018]

<!-- MR 10.4.0 [CU22] / 10.5.0 [CU10] / 10.6.0 [CU0] - FR 10.6.1 -->

When Cube is connected to a DataMiner System using STaaS:

- In the *Tools* section of *System Center*, the query executor will no longer be available.
- In the *Search & indexing* section of *System Center*, the indexing engine settings will no longer be available.

Also, when an exception is thrown when Cube tries to use the MigrationManagerHelper, an error will now be logged in the Cube logging.

### Fixes

*No fixes have been added yet.*
