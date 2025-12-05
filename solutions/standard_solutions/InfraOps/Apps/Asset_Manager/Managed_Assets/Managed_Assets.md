---
uid: Managed_Assets
---

# Managed Assets

After configuring the necessary Assets Classes, users can create Assets.

Same as the Asset Classes, users can import their Assets via CSV file. Otherwise, manual creation is available be pressing the top right button “Create Asset”:

![Managed Asset Page](~/solutions/images/Asset_Manager_Managed_Asset_Page.png)

To create an Asset, the following needs to be inserted:

- Asset ID and Asset Name: Unique ID and Name for the Asset

- Asset Class

The newly created asset will inherit all the configuration from its Asset Class, and it’s created with the state “Not Available”. Overview of all available Asset States:

![Asset state diagram](~/solutions/images/Asset_Manager_Asset_State_Diagram.png)

While the state of the Asset is “Not Available”, the user can still edit everything on the Asset Information, except for the Asset Class.

Once the user changes the state to “Available”, the Asset ID is no longer editable, but now the user can define a location for the Asset.

After setting to “Available”, the Asset can go to “In Planning” and the “Build Plan Ready” states.

To move to the next state which is “Installed”, the user will need an installation user and date. This can be configured in the asset details, Lifecycle section.

Once these details are configured, the user changes the state to “Installed”, it will no longer be possible to change the installation user and date:

![Asset Lifecycle Wizard](~/solutions/images/Asset_Manager_Asset_Lifecycle_Wizard.png)

Also, when moving an asset to installed state, it will no longer be possible to define the location, even if no location is defined. The user will need to set the asset state to “In Planning” to be able to configure the location.

The “final” state is “In Service”. To easily change it, just click the state on the table to list the options available:

![Asset State context menu](~/solutions/images/Asset_Manager_Asset_State_Context_Menu.png)

From any state, the user can set the asset state to “In Transit” or “In Repair”.

When setting to “In Transit”, the user will be prompted to insert the destination:

![Asset Destination Location Wizard](~/solutions/images/Asset_Manager_Asset_Destination_Location_Wizard.png)

This information is displayed in the Asset details panel:

![Asset Details side panel](~/solutions/images/Asset_Manager_Asset_Details_Side_Panel.png)

Once the user changes to any other available state, the location defined on the Destination Information will be removed and placed on the Location Information section.
