---
uid: The_legacy_Monitoring_Control_app_user_interface
---

# The legacy Monitoring & Control app user interface

Prior to DataMiner 10.0.0/10.0.2, the primary web application to monitor a DMS is the Monitoring & Control app. From DataMiner 10.0.0/10.0.2 onwards, this app is deprecated and replaced by a new Monitoring app. See [The Monitoring app user interface](xref:The_Monitoring_app_user_interface).

The DataMiner Monitoring & Control app features a user interface similar to that of DataMiner Cube, with a header bar, a navigation pane, an Alarm Console and a card area.

> [!CAUTION]
> If you use a DataMiner version prior to DataMiner 10.1.7, we strongly advise that you use HTTPS when you use DataMiner client applications over public internet. If you do not do so, all information – including logon credentials – is sent as plain, unencrypted text over the internet. From DataMiner 10.1.7 onwards, client-server communication is encrypted by default. See also: [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).

> [!TIP]
> See also:
>
> - [Accessing the legacy Monitoring & Control app](xref:Accessing_the_legacy_Monitoring_Control_app#accessing-the-legacy-monitoring--control-app)
> - [Mobile Gateway](xref:MobileGateway)

## Monitoring & Control app header bar

The header bar contains the following icons:

- User icon ![User icon](~/user-guide/images/Icon_mobile_user.png)

  Use this icon and select *Sign out* or *Log out* to log off (depending on the DataMiner version). Depending on the available space on the screen, your username may be displayed instead of this icon. From DataMiner 9.5.5 onwards, this icon provides access to the *Settings* page as well. This page allows you to configure the following settings:

  - *WebSockets*: Determines whether a WebSocket connection can be used.

  - *Card pages*: Determines which page is displayed by default when an element, service or view card is opened. However, note that setting *Visual page* as the default page can cause reduced performance.
  
  From DataMiner 9.6.11 onwards, this icon also provides access to the *Contacts* option, which displays information on contacts that are currently connected to the DMS.

- Help icon ![Help icon](~/user-guide/images/Icon_mobile_help.png)

  Use this icon and select *Help* to open the DataMiner Help. Alternatively, you can select *About* to view information on the version of the server API and the client application.

- Communication icon ![Communication icon](~/user-guide/images/Icon_mobile_comm.png)
  
  Use this icon to view information on the server communication, and to get a list of the Agents in the DMS and their status.

- Contacts icon ![Contacts icon](~/user-guide/images/Icon_mobile_contacts.png)

  Use this icon to view information on contacts that are currently connected to the DMS, either via the Monitoring & Control app or via a different DataMiner app. Available from DataMiner 9.6.6 onwards. Note that from DataMiner 9.6.11 onwards, this information is instead available via the user icon.

## Monitoring & Control app navigation pane

The collapsible navigation pane contains a search box, as well as the following icons:

- Surveyor icon ![Surveyor icon](~/user-guide/images/Icon_mobile_surveyor.png)

  Use this icon to access the Surveyor pane. This pane contains a tree view similar to that in the DataMiner Cube Surveyor.

- Recent items icon ![Recent items icon](~/user-guide/images/Icon_mobile_recent.png)

  Use this icon to access a list of recently accessed elements, services or views. This list is stored server-side, and also contains any recent and pinned items from DataMiner Cube. Use the pin icon to place items in the *Pinned* section at the top of the list, and the x icon to remove any pinned items from this section.

- Nearby items icon ![Nearby items icon](~/user-guide/images/Icon_mobile_nearby.png)

  Use this icon to access a list of nearby items.

- Modules icon ![Modules icon](~/user-guide/images/Icon_mobile_apps.png)

  Use this icon to access the legacy Reports & Dashboards module or the Trending module.

  - For more information on Reports & Dashboards, see [DMS Reporter](xref:reporter) and [DMS Dashboards](xref:dashboards).

  - For more information on trending in the Monitoring & Control app, see [Monitoring & Control app trending](#monitoring--control-app-trending). |

## Monitoring & Control app Alarm Console

A collapsible Alarm Console pane at the bottom provides an overview of the alarms in the DMS, similar to the Alarm Console in Cube.

- The three default alarm tabs are displayed: active alarms, information events and masked alarms.

  > [!NOTE]
  > The information events displayed in the app are limited to events that occurred in the last 24 hours

- At the bottom, an alarm bar shows a summary of the alarm information in the active alarms tab.

- You can filter the alarms by entering characters in the filter box in the lower right corner, or by using the buttons indicating the different severities. To remove the filters again, use the *Clear filters* button.

- From any of the alarms in the console, an alarm card with detailed information can be opened.

## Monitoring & Control app card pane

Depending on the type of item you opened, different features will be available in the card pane.

For all card types:

- Use the arrow icon in the top left corner to go back to a previous card, if possible.

- On the left, a side panel is displayed that can be used to access different card pages.

For element cards:

- Two fields in the header bar can be used to change the element *State*, and to *Mask* or *Unmask* the element.

For element and service cards:

- In the card side panel, you can select different pages, or view alarms, reports, dashboards or notes.

- If trending has been enabled for a parameter, a graph icon is displayed next to the parameter, which can be used to gain quick access to the *Trending* module.

- A wrench icon next to a parameter can be used to access detailed information on the parameter as well as controls to change the parameter value.

For view cards:

- From the card side panel, you can access a list of elements, services, SLAs or other items in the view, which can be filtered. In addition, you can also access alarms, reports, dashboards, aggregation, histograms and notes.

For CPE cards:

- The layout of CPE cards is similar to the layout of such cards in DataMiner Cube. See [Working with the Experience and Performance Management interface](xref:Working_with_the_Experience_and_Performance_Management_interface).

- The side panel contains filters that can be used to drill down to specific items.

For spectrum analyzer cards (available from DataMiner 9.5.5 onwards):

- These cards can display a spectrum trace in SVG format if WebSockets have been enabled (via the user icon \> *Settings*).

  > [!NOTE]
  >
  > - WebSockets also need to be enabled on the server and client machine for this to work. In addition, the server requires at least Microsoft .NET Framework 4.5.
  > - WebSockets are automatically enabled from DataMiner 9.6.5 onwards.

- The *Info* panel displays spectrum parameters and measurement points.

- Multiple measurement points can be set using a URL parameter, for example:

    ```txt
    http://localhost/?element=271/20&measpt=[comma-separated list of measurement point IDs]
    ```

- An inline preset can be loaded using a URL parameter, for example:

    ```txt
    http://localhost/?element=271/20&preset=[inline preset specified in the same format as used in DataMiner Cube]
    ```

    By default, the preset of the last session will be loaded first.

- The *Settings* panel allows you to set spectrum parameters manually, and to display the minimum or maximum trace.

## Monitoring & Control app trending

In the Monitoring & Control app, the *Trending* module can be accessed from the trending icon next to a trended parameter, or from the apps list.

- With the *Trending* and *Histogram* buttons in the top left corner you can switch between displaying trend graphs or histograms.

- One or more parameters can be added to a graph or histogram in the parameters panel. If this panel is collapsed, use the *Parameters* button to open it.

  To add parameters to the trend graph:

  - Click *Add parameter*.

  - Select the element, the parameter, and optionally the index in the drop-down lists.

  - Repeat the steps above to add additional parameters.

  - Use the drop-down list under *Display* to determine how a parameter is displayed in the graph:

    - *Hide*: Keeps the parameter from being displayed. This allows you to quickly show or hide parameters in the graph.

    - *Auto*: Default mode. The trend parameter will automatically be placed on the next suitable axis.

    - *New axis*: The trend parameter is displayed in the next suitable graph with an empty axis.

    - *New graph*: The trend parameter is displayed in a new graph.

    > [!NOTE]
    > You can display the same parameter more than once in different graphs, for instance to compare and combine the parameter with several other parameters at the same time.

- Use the buttons in the top right corner to select the time period for which trending is displayed: *Hour*, *Day*, *Week*, *Month* or *Year*. Depending on the size of the screen, you may need to use the *Parameters* button to view these buttons.

- If a trend graph contains any exception values, these are displayed at the bottom of the graph.

> [!NOTE]
> You can also access histograms directly from a view card or from a CPE card.
