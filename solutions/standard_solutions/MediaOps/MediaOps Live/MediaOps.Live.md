---
uid: MediaOps.Live
---

# Live

## Applications

MediaOps Live is available in the [Catalog](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) as a package containing multiple low-code apps.

These are the out-of-the-box DataMiner applications that are included in the MediaOps Live installation package:

<div class="row">
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/MediaOps.Live/Apps/MO_Virtual_Signal_Groups.html" title="Virtual Signal Groups" target="_self"><img src="~/solutions/images/mo_VirtualSignalGroups.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/MediaOps.Live/Apps/MO_Control_Surface.html" title="Control Surface" target="_self"><img src="~/solutions/images/mo_ControlSurface.svg" style="width:100%"></a>
  </div>
  <div class="column">
  <a href="/solutions/standard_solutions/MediaOps/MediaOps.Live/Apps/MO_Orchestration_Events.html" title="Orchestration Events" target="_self"><img src="~/solutions/images/mo_OrchestrationEvents.svg" style="width:100%"></a>
  </div>
</div>

## Installing MediaOps.Live

To install MediaOps Live:

1. Look up the [MediaOps Live package](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) in the DataMiner Catalog, and make sure your system meets the mentioned prerequisites.

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
> When upgrading MediaOps.Live, to make sure all migration and cleanup actions take place, **first upgrade to the latest version of your current major version** before moving to the next major version, without skipping a major version.
