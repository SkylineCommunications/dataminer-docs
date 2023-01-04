---
uid: Resources_module_UI_overview
---

# Resources module UI overview

The module consist of a pane on the left, listing resource pools, and a pane on the right with three tabs, *resources*, *properties* and *occupancy*.

- The *Pools* pane contains a list of pools, i.e. collections of resources that have something in common. For example, microphones, headphones, audio mixers, etc. can be grouped together in a resource pool named “Audio equipment”. Pools can be added, edited and deleted with three buttons at the bottom of the pane.

  > [!NOTE]
  > From DataMiner 9.5.4 onwards, this pane has been redesigned. It is no longer explicitly named the *Pools* pane, and also displays the cloud and module level above the pools.

- The *Resources* tab lists resources, i.e. objects that can be used to achieve something.

  - You can link resources to DataMiner elements, or they can refer to places (e.g. meeting rooms), persons, frequency bands, etc. If a resource is linked to an element, a link icon will be displayed next to the resource name.

  - From DataMiner 10.2.0/10.1.5 onwards, three subtabs are displayed when a resource is selected.

    - The *general* tab shows the name, status, concurrency, capacity and capability configuration of the resource.

    - The *device* tab shows the linked function and element configuration.

    - The *properties* tab shows an overview of all resource properties. Properties can be added, edited and deleted with three buttons in the lower right corner.

    - When you make changes to the configuration, click the *Save* button in the lower right corner to save your changes.

    - At the bottom of the list of resources, two buttons are available that allow you to add or delete resources.

  - Prior to DataMiner 10.1.5: An expandable *Properties* panel at the bottom of the pane allows you to view more details on a selected resource. Resources can be added, edited and deleted with three buttons in the lower right corner. An additional button next to these allows you to add a virtual function as a resource.

  > [!NOTE]
  > When you try to delete a resource that is in use or is about to be in use, a warning message will be displayed. However, keep in mind that only bookings that are displayed according to the latest zoom level in the *timeline* or *occupancy* tab are taken into account for this.

- In the *Properties* tab, properties and resource property definitions can be defined for a selected pool.

  - *Pool properties* make it easier to filter through pools and find the pool you are looking for.

  - *Resource property definitions* allow you to define properties for all resources in a selected pool, optionally limiting the values of the properties. For example, you could configure a resource property definition named “Location” and limit its possible values to the available floors of a building.

- From DataMiner 9.5.4 to DataMiner 9.6.3, an additional *Occupancy* tab is available, which shows a timeline that illustrates when particular resources are reserved. Like in the main timeline tab of Scheduler, here too you can activate follow mode or zoom to a particular time span via the right-click menu.

From DataMiner 10.3.0/10.3.2 onwards, the *Resources* tab and the *Occupancy* tab have a filter box that allow you to filter on resource name. When you enter text in the filter box, a list with suggestions will appear. When you select another resource pool while text is present in the filter box, the *Resources* tab and the *Occupancy* tab of that newly selected resource pool will automatically be filtered. To clear the filter, click the *Clear* button or delete the text in the filter box.

> [!NOTE]
> When an item in the *Resources* tab or the *Occupancy* tab gets updated while a filter is applied, that item will only be shown if it matches the filter after the update.

Booking resources can be done via Automation scripts. By means of an embedded Resource Manager component in Visio, you can create an overview of the bookings. See [Embedding a Resource Manager component](xref:Embedding_a_Resource_Manager_component).

> [!NOTE]
>
> - A special ResourceManager API allows integration of the *Resources* module in third-party applications.
> - The *Resources* module has a dedicated log file, which contains among others information regarding the creation, the modification and the deletion of bookings. You can find this log file in System Center, under *Logging* > *dataminer* > *Resource Manager.*
