---
uid: AssetManager_Connections
---

# Connections

Assets can have two types of connections, data and power connections, depending on how their device type is configured (see [Adding a device type](xref:AM_Configuring_device_types#adding-a-device-type)):

- While all assets can function as a **destination** for a **power connection**, they need to have a device type with the tag *Power Provider* to be able to be a **source** for a power connection.

- To function as the source or destination for a **data connection**, assets need to have a device type with the tag *Accepts Data Connection*.

The Connections page of the Asset Manager app provides an overview of all the connections that have been created, with several ways to filter the list of connections.

![Connections page](~/solutions/images/Asset_Manager_Connections_Page.png)

At the top, several buttons are available:

- With the **Add Power Connection** and **Add Data Connection** buttons at the top, you can create connections in the same way as from the Asset details pane. (See [Configuring asset connections](xref:Configuring_asset_connections).)

- The **Connection Panels** button in the top-right corner opens a connection panel view that provides a visual overview of all the connections established between assets that have the device type "Connection Panel" and "regular" assets:

  ![Connection panel view](~/solutions/images/Asset_Manager_Connection_Panel_View.png)

- If this is enabled in the [app settings](xref:App_Settings), the **Connection History** button shows a list of all the recent changes to connections.
