---
uid: Web_apps_Feature_Release_10.5.10
---

# DataMiner web apps Feature Release 10.5.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU19] and 10.5.0 [CU7].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.10](xref:General_Feature_Release_10.5.10).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.10](xref:Cube_Feature_Release_10.5.10).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Monitoring app: Navigation from Visual Overview now goes to Visual page instead of Data page [ID 43430]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When a shape linked to an element, service, or view was clicked in Visual Overview in the Monitoring app, it opened the Data page for the object instead of the Visual page. Now it will open the Visual page, so that the Monitoring app now has the same behavior as Cube.

#### GQI DxM: Improved performance when handling extensions [ID 43479]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

An enhancement has been implemented to the way the GQI DxM deals with extensions. This will improve performance and also prevent possible performance issues in case a large number of active GQI extension libraries are used, for example when many extension libraries are activated by the Copilot DxM.

### Fixes

#### GQI DxM: MessageBroker/SLNet not reconnected immediately after app settings change [ID 43386]

<!-- MR 10.5.0 [CU7] - FR 10.5.10 -->

When the app settings for the GQI DxM are modified, the MessageBroker and SLNet connection of the DxM will now be restored immediately. Previously, the reconnect only happened either after functionality attempted to access the connection or when the automatic reconnection was triggered, which happens once per minute. This will prevent the following possible issues that could previously occur:

- When GQI DxM functionality attempted to use the MessageBroker connection while it was disconnected, a deadlock situation could occur that blocked MessageBroker subscriptions.
- When you changed the GQI app settings while a reconnect was already progress, the connection could use a combination of old and new settings.

#### Dashboards app: PDFs would fail to get generated when a browser tab was closed [ID 43449] [ID 43475]

<!-- MR 10.4.0 [CU19] / 10.5.0 [CU7] - FR 10.5.10 - note that 43475 reverts the RN in 10.4.0 CU18/10.5.0 CU6/10.5.9, and it was then added again in the current versions without a separate record -->

Each open browser tab has its own WebSocket channel. When such a channel is closed, the Web API checks whether certain resources need to be cleaned up.

Up to now, when a single channel was closed, all temporary PDF files would incorrectly be removed for all connections. As a result, if any PDF was being generated when a channel was closed, that generation would fail.

#### Dashboard components rendered twice when generating PDF [ID 43490]

<!-- 10.4.0 [CU19] / MR 10.5.0 [CU7] - FR 10.5.10 -->

When a PDF was generated based on a dashboard, it could occur that some components were rendered twice, because they were interpreted both as a feed and as a regular component, which caused the generation time to take much longer than necessary. Now if a component is in the regular components group, it will not also be added in the feed components group, reducing the time it takes to generate the PDF.
