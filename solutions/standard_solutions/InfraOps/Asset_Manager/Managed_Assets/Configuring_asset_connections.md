---
uid: Configuring_asset_connections
---

# Configuring asset connections

Assets can have two types of connections, data and power connections, depending on how their device type is configured (see [Connections](xref:AssetManager_Connections)).

To configure these connection from the [*Asset details* pane](xref:Managed_Assets#configuring-asset-details), select *Open Connections* > *Power Connections* or *Data Connections*.

![Asset details connections dropdown](~/solutions/images/Asset_Manager_Asset_Details_Side_Panel_Connections_Dropdown.png)

This will open a pane where you can add power or data connections and customize the power ports or data ports of the asset compared to the default configuration from the asset class.

When you click the button to add a connection, you will then need to specify the necessary information. For example, for a data connection, the following window will be displayed:

![Create data connection wizard](~/solutions/images/Asset_Manager_Create_Data_Connection_Wizard.png)

You will have to select at least the **source** and **destination** asset as well as the **cable type**:

- For a power connection, only cable types categorized as "Power" will be shown. For data connections, all cable types except those exclusively categorized as "Power" will be displayed.
- For the source and destination asset, you will only be able to select assets with a port type that has the selected cable type configured as a compatible cable (see [Configuring port types](xref:AM_Configuring_port_types)).
- To select a source or destination asset, you will first need to filter per asset class, and, if possible, filter further using the name filter. Assets with the state "Not Available" or "Disposed" will not be displayed.
- Once a port has been selected and used for a connection, it will no longer be available to establish new connections.

<!-- TBD: what is the purpose of the other fields in the wizard? -->