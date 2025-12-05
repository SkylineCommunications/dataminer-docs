---
uid: Asset_Connections
---

# Asset Connections

There are two types of Connections: Data and Power Connections. User can open these by selecting the button “Open Connections” on the Asset details:

![Asset Details Side Panel - Connections dropdown](~/solutions/images/Asset_Manager_Asset_Details_Side_Panel_Connections_Dropdown.png)

As mentioned before on the Device Type section, these options are affected by the tags defined on the Device Type.

While all assets can have a power connection (as a Destination), to be able to be a source for a power connection, they need to have a device type with the tag “Power Provider”.

Regarding the Data Connection, assets with device tag “Accepts Data Connection” can create data connections as sources and destinations:

![Create Data Connection Wizard](~/solutions/images/Asset_Manager_Create_Data_Connection_Wizard.png)

The user will need to define the cable type used for this connection. When selecting a Power connection, only cable types categorized as Power will be shown. For Data connections, all cable types are displayed except those exclusively categorized as Power.

Will also need to select a Source and Destination asset, but the list of ports will only be displayed if the asset has ports with a Port Type that has the previously selected cable under their Compatibility Cable Type list.

When selecting the asset, the user needs to first filter per asset class and can, if needed, filter further using the Name Filter. Assets with the state Not Available and Disposed aren’t displayed.

Once a port is selected and used for a connection, it will no longer be available to establish new connections for it.
