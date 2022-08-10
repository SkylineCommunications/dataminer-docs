---
uid: IDP_1.0.0
---

# IDP 1.0.0

## New features

#### Skyline Generic Provisioning: API Implementation \[ID_19307\]\[ID_19310\]\[ID_20225\] \[ID_21324\]

A web service has been implemented for the Skyline Generic Provisioning driver. This API includes the following methods:

- **About**: Returns an overview of information about the Solution platform.

  Parameters:

  - Cookie: The access token (required).

- **ConfigureElement**: Configures a particular element

  Parameters:

  - Cookie: The access token (required).
  - DMAId: The DMA ID of the element that is to be configured (required).
  - ElementId: The element ID of the element that is to be configured (required).
  - DMAElementConfiguration array (required), including at least the Name, ProtocolName and ProtocolVersion (for more information on this array, refer to the DataMiner Web Services reference guide).

- **ConfigureView**: Configures a particular view.

  Parameters:

  - Cookie: The access token (required).
  - Id: The ID of the view (required).
  - Name: The name of the view (required).
  - Elements: Array of string in the format DMA ID/Element ID (e.g. 515/124).
  - VisioFile: E.g. Visio.vsdx.
  - ParentViewId.
  - Properties: Array consisting of Name and Value pairs.

- **CreateElement**: Creates a new element.

  Parameters:

  - Cookie: The access token (required).
  - [DMAElementConfiguration](xref:DMAElementConfiguration) array (required), including at least the Name, ProtocolName and ProtocolVersion.

- **CreateView**: Creates a new view.

  Parameters:

  - Cookie: The access token (required).
  - ViewName (required)
  - ParentViewId
  - ParentViewName
  - Elements: Array of string in the format DMA ID/Element ID (e.g. 515/124).
  - Properties: Array consisting of Name and Value pairs.
  - VisioFileName

- **DeleteElement**: Removes one or more elements from the DMA.

  Parameters:

  - Cookie: The access token (required).
  - Dmaeid: List of DMA element IDs, e.g. 515/102;505/141 (required).

- **DeleteView**: Removes the specified views from the DMA.

  Parameters:

  - Cookie: The access token (required).
  - ViewIds: The IDs of the views that should be deleted, e.g. 12;23 (required).
  - ViewNames: The names of the views that should be deleted, e.g. View 1;View 2 (required).

- **GetElementConfiguration**: Returns the configuration of the element.

  Parameters:

  - Cookie: The access token (required).
  - DMAId: The DMA ID of the element (required).

- **GetElements**: Returns element information for the DMA.

  Parameters:

  - Cookie: The access token (required).
  - ProtocolName: The protocol for which element information should be returned.
  - Dmaeid: List of DMA element IDs, e.g. 515/102;505/141.

- **GetStructure**: Returns information on the view structure on the DMA.

  Parameters:

  - Cookie: The access token (required).
  - RootViewID: The ID of the root view for which view structure information should be retrieved.

- **GetViews**: Returns information on the views on the DMA.

  Parameters:

  - Cookie: The access token (required).
  - RootViewID: The ID of the root view for which views information should be retrieved.

- **Logging**: Returns logging information of the Solution platform.

  Parameters:

  - Cookie: The access token (required).

- **Login**: Allows you to log in to the API, using the username and password of a user account with the appropriate rights on the DMA hosting the *Skyline Generic Provisioning* element.

  Parameters:

  - Password (required)
  - Username (required)
  
  Returns: AccessToken (i.e. a token to be used for other requests)

- **Pause**: Pauses the solution platform manager element.

  Parameters:

  - Cookie: The access token (required).

- **ReplaceView**: Moves an element to a particular view.

  Parameters:

  - Cookie: The access token (required).
  - Dmaeid: The DMA element ID (required).
  - ToViewId: The ID of the view to which the element is moved (required).
  - FromViewId: The ID of the view from which the element is moved.

- **SetVisioForViews**: Sets a particular Visio file for one or more views.

  Parameters:

  - Cookie: The access token (required).
  - ViewIds: The IDs of the views for which the Visio file will be set, e.g. 12;23 (required).
  - VisioFileName: The complete file name of the Visio file, e.g. Visio.vsdx (required).

- **Start**: Starts the Solution platform manager element.

  Parameters:

  - Cookie: The access token (required).

- **Status**: Returns status information of the solution platform.

  Parameters:

  - Cookie: The access token (required).

- **Stop**: Stops the Solution platform manager element.

  Parameters:

  - Cookie: The access token (required).

- **Update**: Starts the update procedure.

  Parameters:

  - Cookie: The access token (required).

> [!NOTE]
> The methods all return an extra "Timestamp" tag, which mentions the date and time of the request and response.

#### Configuration of IP ranges per DMA \[ID_20165\]\[ID_20372\]

It is now possible to configure which DMA can host devices in a particular IP range. The provisioning API can then create new devices on specific DMAs based on their IP.

This can be configured on the page *Admin* > *Provisioning* of the IDP app (available via the following icon: ![Provisioning icon](~/release-notes/images/IDP_Provisioning.png)).

On this page, the IP ranges are displayed in the table *Configured IP Ranges*. This table displays the start IP, the end IP and the DMA name for each configured IP range. If one of the IP ranges is selected in the table, more detailed information is displayed above the table, including the DMA ID for the IP range. Next to the table header, a “+” button is available, which can be used to add an IP range. If an IP range is selected, a “-” button becomes available next to this, which can be used to remove the selected IP range.

Finally, the *Fallback Agent* control on this page allows you to configure the default hosting Agent.

#### Solution components management \[ID_20450\]

On the *Components* data display page of the *Skyline Infrastructure Discovery And Provisioning* element, you can now find the *Solution Components* table. This table lists the different components of the IDP Solution, and the elements in the DMS that are used for these components.

If multiple elements are available that could serve as a particular component, you can select to use a different element. If an element is automatically assigned, for example because the element that was previously assigned has been removed, the Solution will select the element of which the name is most similar to the previous element. If no element with a similar name is found, the first matching element in active state will be assigned.

Because this means that elements can now be dynamically assigned as components in the Solution, any references in the Solution have been adjusted so that they do not use a static element name to refer to the components.

The following components are supported:

- Discovery: Skyline IDP Discovery protocol
- Provisioning: Skyline Generic Provisioning protocol
- Inventory: Skyline DataMiner Infrastructure DB protocol
- RLM: Generic Rack Layout Manager protocol

#### Discovered elements overview \[ID_20605\]\[ID_20766\]

When devices are discovered by the IDP Solution, they are listed in the *Discovered Elements* table, on the *Discovered* tab of the IDP app. The index of this table is a combination of the IP address and profile type. The *First Discovery Time* column displays the time when a device was initially discovered. If the same device is discovered again, the *Last Discovered Time* is updated for this device.

In the *Proposed Element Name* column of the table, an element name will be proposed for each discovered device, which can be modified by the user. In case the user specifies a name that contains forbidden characters or a name that is not unique, a pop-up message will notify the user that this is not allowed. In case there already is a managed element for a device in the table, changing the element name will no longer be allowed.

#### Adding, editing or removing elements in a rack \[ID_20824\]

On the *Infrastructure* tab of the IDP app, the *Devices to show* table contains a list of devices discovered in the system. This table can be used to assign devices to racks. Above the table, a toggle button allows you to display either assigned devices or unassigned devices in the table.

If you select an unassigned device, a "+" button will become available above the table. Clicking this button starts a wizard that allows you to assign the device to a particular rack. The wizard will first allow you to customize the rack size. Then you can select where the rack is located. Depending on the configured levels, you may be able to select a location, building, floor, room, aisle and rack. If only one level is available, it is filled in automatically. Finally, you can select the slot where the device is placed. The wizard only allows you to select one of the unoccupied slots.

If you select an assigned device in the table, the "+" button will also be available. Clicking the button will allow you to make changes to the rack layout configuration for the device.

Finally, if you select an unassigned device in the table, an additional "-" button will become available above the table. Clicking this button will start a wizard that allows you to unassign the device.

#### IDP solution setup wizard \[ID_20923\]\[ID_20942\]

A new interactive Automation script, *IDP_SetupWizard*, is now available, which allows you to perform the initial setup after the IDP package has been deployed in a new system.

The script will take you through the following steps to configure the system:

1. View creation and configuration
2. Element creation
3. Creation of an API user
4. Elements and dashboards configuration

For the last step, two subscripts are used:

- The subscript *IDP_SetupWizard_DashboardConfiguration* will link compatible IDP dashboards to the DMA ID and element ID of the generated elements.
- The subscript *IDP_SetupWizard_ElementConfiguration* will apply pre-configured parameter settings to the generated elements.

#### IDP Activity Scheduler \[ID_21184\]

In the IDP Solution setup wizard, you can now select whether you wish to use the Activity Scheduler feature.

If this feature is enabled, the *Admin* tab of the IDP app displays a ![Scheduler icon](~/release-notes/images/IDP_Scheduler.png) icon in the top-right corner, which opens the Scheduler subtab. This tab displays a timeline with all scheduled activities and a *New* button, which allows you to schedule a new discovery activity.

The Activity Scheduler can also be enabled or disabled after the initial setup phase via the *Activity Scheduler* parameter on the *Settings* data display page of the *Skyline Infrastructure Discovery And Provisioning* element.

#### Presets for device discovery \[ID_21208\]\[ID_21209\]\[ID_21112\]

The IDP application can now use a preset, which determines which provisioning templates are used for particular IP ranges. A preset consists of a name, one or more IP ranges and one or more provisioning templates.

In the IDP app, on the *Admin* > *Discovery* tab (available via the following icon: ![Discovery icon](~/release-notes/images/IDP_Discovery.png) ), the selected preset is displayed and a different preset can be selected.

On the *Discovered* tab of the IDP app, it is possible to start either a custom discovery or a discovery using the selected preset. Starting a custom discovery will launch the script *IDP_ManagePresets*, where you can create and edit presets and then run a discovery. Starting a discovery with a selected preset will launch the script *IDP_DiscoverByPreset*, which will run a discovery using the selected preset displayed on the *Admin* > *Discovery* tab. Note that this script does not necessarily need to be started in the app, but could also for example be run by a scheduled task.

#### New Skyline IDP Discovery driver \[ID_21222\]

A new driver *Skyline IDP Discovery* is available, which supports the discovery and provisioning of devices using SNMP, HTTP and HTTPS.

#### RLM properties automatically generated \[ID_21365\]

When the *Generic Rack Layout Manager* starts up, the properties used for this part of the IDP Solution are now automatically generated if they do not yet exist. These are the properties used by the Rack Layout Manager:

- Location Name
- Location Building
- Location Floor
- Location Room
- Location Aisle
- Location Rack
- Location Rack Position
- Location Rack Units
- Location Device Visibility
- Location Slot
- Asset Model
- Location City
- Location Region
- Location Country
- Location Geo Location Known
- Location Geo Latitude
- Location Geo Longitude
- Location Geo Elevation
- Location Rack Side
- Energy Expected Consumption
- Energy Peak Consumption
- Deployment Type
- Deployment Status
- Deployment Installation Date
- Deployment End Of Warranty Date
