---
uid: Web_apps_Feature_Release_10.6.12
description: "Release notes for DataMiner web apps Feature Release 10.6.12, with new features, enhancements, and fixes planned for this preview release."
---

# DataMiner web apps Feature Release 10.6.12 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.12](xref:General_Feature_Release_10.6.12).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.12](xref:Cube_Feature_Release_10.6.12).

## Highlights

*No highlights have been selected yet.*

## New features

### Web API: OpenAPI and AsyncAPI specifications will now be available on each DataMiner Agent [ID 46653]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

On each DataMiner Agent, OpenAPI 3.1 and AsyncAPI 3.1 specifications will now be available in the following folders:

- `C:\Skyline DataMiner\API\docs\http.json`
- `C:\Skyline DataMiner\API\docs\ws.json`

The specifications describe supported HTTP operations, request and response schemas, enum values, WebSocket messages, and subscriptions.

## Changes

### Enhancements

#### Security enhancements [ID 45477]

<!-- 45477: MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

A number of security enhancements have been made.

### Fixes

#### GQI DxM: PaToken DOM Instance IDs could not be filtered correctly [ID 46616]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

Up to now, when the PaToken data source was queried using the GQI DxM, the DOM Instance ID column would incorrectly return the string representation of a `DomInstanceId` object instead of the GUID value. As a result, filtering on this column did not work correctly.

From now on, the column will expose the correct GUID value and will support filtering for PaTokens both with and without a DOM Instance ID.

#### Dashboards/Low-Code Apps - Time range component: Time range could revert after a trigger was activated [ID 46685]

<!-- MR 10.5.0 [CU21] / 10.6.0 [CU9] - FR 10.6.12 -->

When a *Trigger* component was linked to a *Time range* component, up to now, when the *Trigger* component was activated, the *Time range* component could revert to an older range. A manually entered range could also change.

From now on, when a *Trigger* component is activated, the time range specified in the linked *Time range* component will be preserved.
