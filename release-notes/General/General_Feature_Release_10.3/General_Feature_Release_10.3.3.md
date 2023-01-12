---
uid: General_Feature_Release_10.3.3
---

# General Feature Release 10.3.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.3](xref:Cube_Feature_Release_10.3.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### Dashboards app - GQI: New data sources [ID_35027]

In the Generic Query Interface, the following new data sources are now available:

- Get trend data patterns
- Get trend data pattern events
- Get behavioral change events

#### DataMiner Object Models: New field descriptors [ID_35278]

<!-- MR 10.4.0 - FR 10.3.3 -->

Two new field descriptors have been added to the DataMiner Object Models:

- GroupFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user group.

- UserFieldDescriptor: Can be used to define that a field should contain the name of a DataMiner user. There is a *GroupNames* property that can be used to define which groups the user can be a part of.

## Changes

### Enhancements

#### Security enhancements [ID_34894]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

A number of security enhancements have been made.

#### SLLogCollector: Multiple instances can now be run simultaneously [ID_35204]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Multiple instances of the SLLogCollector tool can now be run simultaneously.

#### Web apps: Enhanced color picker [ID_35276]

<!-- MR 10.4.0 - FR 10.3.3 -->

A number of enhancements have been made to the color picker.

#### Errors received from the web API after sending a GetConnection call will now be logged in SLNet.txt [ID_35313]

<!-- MR 10.4.0 - FR 10.3.3 -->

From now on, when SLNet receives an error from the web API after sending a *GetConnection* call, it will log the request and the response in the *SLNet.txt* log file.

#### SLAnalytics - Behavioral anomaly detection: Suggestion events and alarm events for a DVE child element will now be generated on that same DVE child element [ID_35332]

<!-- MR 10.4.0 - FR 10.3.3 -->

When a behavioral anomaly was detected on a DVE child element, up to now, the suggestion event or the alarm event would be generated on the parent element. From now on, it will be generated on the child element instead.

### Fixes

#### Problem with SLLog when logging large entries regarding failed Elasticsearch query requests/responses [ID_35037]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Up to now, an error could occur in SLLog when adding large entries regarding failed Elasticsearch query requests/responses.

#### When a direct view table was updated, the wrong columns could be updated in the source element [ID_35075]

<!-- MR 10.4.0 - FR 10.3.3 -->

When a direct view table was updated while one of the source elements was stopped, due to a column translation issue, the wrong columns could be updated in that source element the moment it was started again.

#### GQI: Problem when fetching two queries using an external data source with a custom argument of which the ID was set to "Type" [ID_35242]

<!-- MR 10.3.0 - FR 10.3.3 -->

When two queries using an external data source with a custom argument of which the ID was set to "Type" had to be fetched, only one of the two queries would get fetched when the only difference between them was the value of the custom argument.

#### Dashboards app: Problem when trying to open a shared dashboard [ID_35271]

<!-- MR 10.4.0 - FR 10.3.3 -->

When users tried to open a shared dashboard, in some cases, they would unexpectedly be presented with a login screen due to a permission issue.

Workaround: Recreate the faulty shared dashboard.

#### SLDataGateway could end up with an excessive number of HealthMonitor.Refresh threads [ID_35286]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In some cases, the SLDataGateway process could end up with an excessive number of *HealthMonitor.Refresh* threads.

#### DataMiner Object Models: Permission checks for DOM modules requiring view permission 'None' were too strict [ID_35305]

<!-- MR 10.3.0 - FR 10.3.3 -->

If a DOM module is created without specifying *SecuritySettings*, the view permission is set to "None".

Up to now, the check to determine whether a user had the view permission set to "None", would only return true for the Administrator or users in the Administrator group. From now on, when the required view permission is "None", permission checks will no longer be performed.
