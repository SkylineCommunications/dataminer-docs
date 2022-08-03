---
uid: IDP_1.1.2
---

# IDP 1.1.2

## New features

#### IDP app: Removing a scan range \[ID_22725\]

On the *Admin* > *Discovery* page of the IDP app, you can now remove a selected scan range. When you select a scan range, a list of the activities related to that scan range will be displayed. Above the list of scan ranges, a "–" button will be displayed. Clicking this button will remove the scan range. In case the scan range has ongoing activities, these will first need to be stopped before you can remove the scan range.

On the *Scan Range Overview* data page of the IDP app, a button is now also available that can be used to remove all scan ranges at once. However, a scan range with ongoing activities will not be removed by this button.

#### IDP app: New Provisioning \> Pending tab \[ID_22774\]

The *Provisioning* tab of the IDP app now has a new *Pending* subtab, which contains an overview of the elements that are available in the system but not yet managed by the IDP Solution. The subtab displays when the list of elements was last refreshed and contains a *Refresh* button that allows you to update the list. The list is also updated when the IDP app starts up.

If the detected IP address and CI type are filled in for a selected element in the overview, you can click *Add* to add the element to the managed elements.

## Changes

### Enhancements

#### DataMiner IDP element now includes DataMiner build information \[ID_22687\]

The DataMiner IDP element now contains information on the DataMiner build that is used to run the IDP Solution (e.g. 9.6.0.0-8538). This information is available on the *Version* data page of the element. On this page, the *Version-Aware* table also contains information on the minimum required version for particular IDP features.

#### Improved handling of scan ranges \[ID_22696\]

Previously, when the name of an existing scan range was modified, this could cause scheduled discovery activities to no longer refer to the correct scan range. Now discovery activities will refer to the ID of the scan range instead of its name.

#### Skyline Generic Provisioning API reviewed \[ID_22760\]

The Skyline Generic Provisioning API has been reviewed. Several unused methods (*Logging*, *Pause*, *Start*, *Status*, *Stop* and *Update*) have been removed, and methods that perform very similar operations (i.e. *getStructure* and *getViews*) have been consolidated.

#### IDP Activity Manager: Back button added \[ID_22810\]

In the wizard to create a new IDP activity, a "Back" button is now available that allows you to return to the first screen.

#### Skyline IDP Discovery: Thread status information \[ID_22836\]

On the *Settings* page of the IDP Discovery element, the status of the discovery threads is now displayed. The following status values are possible:

- 0: Suspended
- 1: Waiting
- 2: Running

#### IDP app: Software and Configuration tabs now in sync with managed elements \[ID_22839\]

When an element is removed from the inventory, this change is now reflected in the tables on the *Software* and *Configuration* tabs of the IDP app.

#### Generic Rack Layout Manager: Protocols Table no longer includes internal DataMiner protocols \[ID_22857\]

The *Protocols Table* of the Rack Layout Manager element will now no longer include protocols used for the internal functionality of DataMiner and the DataMiner Solutions, such as Skyline SLA Definition Basic, Skyline Generic Provisioning, etc.

### Fixes

#### Not possible to remove managed element \[ID_22657\]

In some cases, it could occur that it was not possible to remove an element in the *Managed Elements* table.

#### Configuration not applied correctly to provisioned elements \[ID_22663\]

In some cases it could occur that when elements were provisioned, the parameter sets configured in the provisioning files were not applied.

#### Generic Rack Layout Manager: Not possible to assign element with long name to rack position \[ID_22792\]

When an element had a long name, it could occur that it was not possible to assign it to a rack position.

#### Generic Rack Layout Manager: Deleted properties were not created again \[ID_22833\]

If a property that is used by the Rack Layout Manager was removed, the property was not recreated when the RLM element was restarted. Now it will be recreated both after a restart of the RLM element and after any login of the RLM element in the API.
