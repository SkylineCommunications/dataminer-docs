---
uid: Using_DataMiner_Maps
---

# Using DataMiner Maps

DataMiner Maps can be displayed in a web browser, in an MS Visio file, and in a DataMiner dashboard (accessed either directly or through a Dashboard Gateway):

- [Displaying a DataMiner map in a web browser](xref:Displaying_a_DataMiner_map_in_a_web_browser)

- [Displaying a DataMiner Map in a DataMiner dashboard](xref:Displaying_a_DataMiner_Map_in_a_DataMiner_dashboard)

- [Switching map configurations by means of JavaScript](xref:Switching_map_configurations_by_means_of_JavaScript)

> [!NOTE]
>
> - When you open DataMiner Maps for the first time, you will have to log on. Your session will stay active until you close your internet browser. Prior to DataMiner 10.5.0 [CU21]/10.6.0 [CU9]/10.6.12<!--RN 46714-->, if you open DataMiner Maps from within DataMiner Cube or in a dashboard, you are logged on automatically. However, in recent DataMiner versions, automatic login is no longer possible after a client or server restart. To avoid having to authenticate each time you navigate to a map, we recommend displaying maps in a dashboard or low-code app using the [maps component](xref:DashboardMaps).
> - It is possible to make a debug console window open when a Map is opened. To do so, add “console=true” to the Map URL. For example: <br>`https://[DMA]/maps/map.aspx?config=[configuration file]&console=true`.
