---
uid: Working_with_the_Monitoring_app
---

# Working with the Monitoring app

The Monitoring app is a web application featuring a user interface similar to that of DataMiner Cube. The app allows you to monitor a DataMiner System from any modern browser. Depending on the size of the screen used to view the app, the app layout can be adjusted in order to allow optimal use of the available space.

You can access the Monitoring app via the [DataMiner landing page](xref:Accessing_the_web_apps#dataminer-landing-page) or from the [*Apps* pane](xref:DataMiner_Cube_sidebar#apps-pane) in DataMiner Cube (from DataMiner 10.2.9/10.3.0 onwards<!-- RN 33944 -->).

The user interface consists of four main components:

![Monitoring app UI](~/dataminer/images/Monitoring_app_UI.png)<br>*Monitoring app in DataMiner 10.4.4*

- [Header bar](xref:Monitoring_app_header_bar) (1)

- [Sidebar](xref:Monitoring_app_sidebar) (2)

- [Alarm Console](xref:Monitoring_app_Alarm_Console) (3)

- [Card area](xref:Monitoring_app_card_pane) (4)

> [!NOTE]
>
> - If WebSockets are supported and available on the server, the app will use a WebSocket connection to retrieve element information. Otherwise, it will fall back to polling every 5 seconds.
> - The Monitoring app can also be made available via a gateway server. See [Dashboard Gateway installation](xref:Dashboard_Gateway_installation).
