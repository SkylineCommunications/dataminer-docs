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

#### Dashboards app: Enhanced error handling when sharing dashboards [ID 40946]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When an error occurs while you are sharing a dashboard, in some cases, the "Failed saving WAF rules" message will appear.

From now on, when that message appears, the cause of the error will be added to the web API logs.

### Fixes

#### Web APIs: Problem when an exception was thrown while processing a bulk request [ID 40884]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When an exception was thrown while processing a bulk request, in some cases, the web APIs could stop working.

#### Low-Code Apps: Web component would not be initialized correctly after it had received an update [ID 40893]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In some cases, a Web component would not be initialized correctly after it had received an update.

#### Dashboards/Low-Code Apps - Table, Maps, Grid & Timeline components: Templates did not allow any interaction when the component was loading [ID 40909]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

In case of a Table, Map, Grid or Timeline component, the templates did not allow any interaction when the component was loading. Also, feeds and conditions would not be updated.

#### Web apps: Authentication page would show 'A username is required' message although user name and password were filled in [ID 40925]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When, on the authentication page, you clicked *Log on* while your user name and password were both filled in, in some cases, the "A username is required." message would incorrectly appear. When you then clicked *Log on* again, the logon request would succeed.

#### Dashboards/Low-Code Apps - GQI: Problem when arguments of ad hoc data sources were set to empty strings [ID 40932]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When a required argument of an ad hoc data source was set to an empty string, up to now, the empty string would incorrectly not be seen as a valid value. Hence, queries using that ad hoc data source would not get executed.

From now on, arguments of ad hoc data sources will be allowed to have an empty string as value.

#### Dashboards app - State component: Problem when loading parameter data [ID 40949]

<!-- MR 10.3.0 [CU21] / 10.4.0 [CU9] - FR 10.4.12 -->

When parameter data was loaded into a *State* component, the dashboard could get stuck in an infinite loop.
