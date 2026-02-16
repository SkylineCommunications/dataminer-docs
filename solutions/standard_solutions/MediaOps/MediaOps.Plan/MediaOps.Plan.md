---
uid: MediaOps.Plan
---

# Plan

## Applications

MediaOps Plan is available in the [Catalog](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) as a package containing multiple low-code apps. Using these apps within media operations simplifies the customization of user experiences. For instance, a booking team may opt to view schedule timelines for all tasks, while an MCR team typically prefers a sorted list of tasks, with the earliest upcoming job displayed at the top of the list.

These are the out-of-the-box DataMiner applications that are currently included in the MediaOps.Plan installation package:

<div class="row">
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/MediaOps.Plan/Apps/People_Organizations.html" title="People & Organizations" target="_self"><img src="~/solutions/images/mo_PeopleOrganizations.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/MediaOps.Plan/Apps/MO_Resource_Studio.html" title="Resource Studio" target="_self"><img src="~/solutions/images/mo_ResourceStudio.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/MediaOps.Plan/Apps/MO_Workflow_Designer.html" title="Workflow Designer" target="_self"><img src="~/solutions/images/mo_WorkflowDesigner.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/MediaOps.Plan/Apps/MO_Scheduling.html" title="Scheduling" target="_self"><img src="~/solutions/images/mo_Scheduling.svg" style="width:100%"></a>
  </div>
</div>

> [!TIP]
> Check out the [MediaOps course](https://community.dataminer.services/courses/mediaops/) to learn more about MediaOps. If you are part of the [DevOps Professional Program](xref:DataMiner_Devops_Professionals), you will score some DevOps Points too.

## Installing MediaOps Plan

To install MediaOps Plan:

1. Look up the [MediaOps.Plan package](https://catalog.dataminer.services/details/1b67a623-4ca6-4d25-8b3d-ed4e39496a75) in the DataMiner Catalog.

    > [!TIP]
    > For details about the changes introduced in each version, refer to the [release notes](xref:MediaOps_RNs_index).

1. Check the prerequisites mentioned in the [release notes](xref:MediaOps_RNs_index) matching the package version, and make sure your system meets these prerequisites.

1. When all prerequisites are met, click the *Deploy* button.

   > [!TIP]
   > For more details on deploying items from the Catalog, see [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

During the installation, the following steps will automatically be executed:

1. Prerequisite check.
1. Install/Update automation scripts.
1. Install/Update applications.
1. Install/Update DOM definitions.
1. Initialize the system (fresh install).
1. Migration actions (if any).
1. Cleanup actions (if any).

Migration and cleanup actions are defined in the install package and will depend on the version you install. To make sure that these actions do not keep growing indefinitely over the different versions, the **migration and cleanup actions are cleaned in every major version** (e.g. from 1.x.x to 2.x.x).

> [!IMPORTANT]
> When upgrading MediaOps.Plan, to make sure all migration and cleanup actions take place, **first upgrade to the latest version of your current major version** before moving to the next major version, without skipping a major version.
