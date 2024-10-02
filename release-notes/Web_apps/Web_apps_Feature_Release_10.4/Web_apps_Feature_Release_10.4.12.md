---
uid: Web_apps_Feature_Release_10.4.12
---

# DataMiner web apps Feature Release 10.4.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.12](xref:General_Feature_Release_10.4.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards/Low-Code Apps: GQI sessions will now be executed asynchronously over WebSockets [ID 40416]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

Up to now, after a GQI session had been opened, all necessary pages would be requested synchronously.

From now on, a GQI query will be opened synchronously, after which a first page will be sent to the client over WebSockets without the client having to request it. Then, the client will request and receive all following pages over WebSockets.

When WebSockets are not available, GQI sessions will be executed synchronously as before.

#### Dashboards/Low-Code Apps - GQI components: Query result set is now limited to 100,000 rows [ID 40886]

<!-- MR 10.3.0 [CU20] / 10.4.0 [CU8] - FR 10.4.11 -->

From now on, all GQI components will no longer be allowed to fetch more than 100,000 items in total. When this limit has been reached, a message will be displayed at the bottom of the component.

### Fixes

#### Web APIs: Problem when an exception was thrown while processing a bulk request [ID 40884]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When an exception was thrown while processing a bulk request, in some cases, the web APIs could stop working.
