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

### Fixes

#### Problem with SLLog when logging large entries regarding failed Elasticsearch query requests/responses [ID_35037]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

Up to now, an error could occur in SLLog when adding large entries regarding failed Elasticsearch query requests/responses.

#### GQI: Problem when fetching two queries using an external data source with a custom argument of which the ID was set to "Type" [ID_35242]

<!-- MR 10.3.0 - FR 10.3.3 -->

When two queries using an external data source with a custom argument of which the ID was set to "Type" had to be fetched, only one of the two queries would get fetched when the only difference between them was the value of the custom argument.

#### SLDataGateway could end up with an excessive number of HealthMonitor.Refresh threads [ID_35286]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In some cases, the SLDataGateway process could end up with an excessive number of *HealthMonitor.Refresh* threads.
