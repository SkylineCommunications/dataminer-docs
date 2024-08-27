---
uid: Cube_Feature_Release_10.4.10
---

# DataMiner Cube Feature Release 10.4.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.10](xref:General_Feature_Release_10.4.10).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Visual Overview: Support for dynamic values in AlarmFilter shape data value [ID_40228]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In the AlarmFilter shape data value, dynamic values (e.g. session variables) are now supported.

#### Trending: Enhanced requirements check before displaying the relation learning light bulb in the top-right corner of a trend graph [ID_40396]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Before it displays the relation learning light bulb in the top-right corner of a trend graph, DataMiner Cube has to perform a requirements check.

During that requirements check, up to now, it would use the *GetCCAGatewayGlobalStateRequest* message to check whether the DataMiner System is connected to dataminer.services. From now on, it will use the new *IsCloudConnected* message instead.

#### Cube home page: 'Did you know?' list will now show the 5 latest Dojo blog posts

When you open DataMiner Cube, from now on, the *Did you know?* list will show the 5 latest [DataMiner Dojo blog posts](https://community.dataminer.services/blog/).

Clicking the title of one of those posts, will open the post in a new browser window.

### Fixes

#### Interactive Automation script could become unresponsive while it was waiting for user input [ID_40358]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

While an interactive Automation script was waiting for user input, in some cases, it could become responsive, especially when Cube was connected to a heavily loaded DaaS system.

#### False-positive warning log entry when Services or Profiles module was opened [ID_40385]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When the Services or Profiles module was opened in Cube, a false-positive warning entry could be added to the Cube logging, with the following message:

```txt
Profile and Services - The visio file name was empty or null. Check the response message from the server
```

#### Problem when logging on to a DataMiner System that required an additional logon through a portal [ID_40387]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When you tried to log on via DataMiner Cube to a DataMiner System that required an additional logon through a portal, up to now, the logon would fail because an incorrect response would be passed on to the server. From now on, the correct response will be passed on.

#### Visual Overview: Shapes with ButtonState data would fail to hide as expected [ID_40454]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

Shapes with *ButtonState* data would fail to hide as expected.

#### Services: Problem when trying to edit a service that had been edited previously [ID_40493]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

When, while editing a service, you added an element or another service to that service and applied the changes, it would no longer be possible to edit the service again. When you tried to do so, the service card would be empty.

#### Alarm Console: Problem with the counter showing the number of unread alarms in a tab page [ID_40522]

<!-- MR 10.3.0 [CU19] / 10.4.0 [CU7] - FR 10.4.10 -->

In some cases, the counter showing the number of unread alarms in an alarm tab page could get out of sync.

When you disabled history tracking and marked an alarm as read, the counter would get out of sync as soon as the alarm you marked as read received an update. In some cases, the counter could even show a negative number of alarms.
