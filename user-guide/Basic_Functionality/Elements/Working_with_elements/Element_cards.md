---
uid: Element_cards
---

# Element cards

To open an element card, click an element in the Surveyor. You can also open elements in other ways, for example by right-clicking an element on a view card and selecting *Open*.

> [!NOTE]
> If you expand a service in the Surveyor and click one of its child elements, the service card will be displayed instead, with the data page of this particular element selected. See [Service card pages](xref:Service_card_pages).

Element cards can look quite different depending on the element protocol. However, the following characteristics return for all cards.

- By default, the header of an element card shows a breadcrumb trail. You can navigate to a parent item by clicking it in the breadcrumb trail, and you can click the triangle to the right of an item to drill down to its child items.

- The footer of an element card consists of different sections:

  - *measurements/s*: The number of measurements per second done for this element.

  - *24h availability*: Double-click this section to view detailed availability information in the Scheduler module.

  - *Last 24h alarm state*: Shows the alarm state for the last 24 hours. Double-click this section to view reports on the element’s alarm state.

  If an element is in timeout, locked or paused, a status message will be displayed on top of these sections.

  > [!NOTE]
  > Depending on your user settings, the breadcrumb trail and/or card footer may not be displayed. See [Card settings](xref:User_settings#card-settings).

- In the navigation pane on the left, a tree view is displayed with all the available pages.

  The items in this tree view and the parameters shown on the card depend on the element protocol. However, all cards share the following pages:

  - **VISUAL**: One or more Visual Overview pages, which show a graphic representation of the element. These pages can be completely customized in Visio.

  - **DATA**: One or more data display pages, determined by the element protocol.

  - **ALARMS**: An overview of the alarms for this element, displayed in the default Alarm Console layout. See [Working with the Alarm Console](xref:Working_with_the_Alarm_Console).

  - **TICKETS**: Displays any tickets related to the element. Only available on DMAs using DataMiner 9.0.4 or higher with a Ticketing license.

  - **REPORTS**: A graphic representation of the alarm distribution, alarm events, alarm states, and a timeline. You can set the period for which data are shown to the last 24 hours, one week to date, or one month to date. For more information, see [Viewing the reports page on a card](xref:Viewing_the_reports_page_on_a_card).

  - **DASHBOARDS**: Links to the legacy DMS Dashboards app.

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.12 onwards, the legacy Dashboards app can be disabled using the soft-launch option *LegacyReportsAndDashboards*. See [Soft-launch options](xref:SoftLaunchOptions).

  - **DOCUMENTS**: Displays documents that have been made available either on the DMS in general or for this particular element protocol. See [Documents](xref:About_the_Documents_module).

  - **NOTES**: Page where short notes can be added to elements. For more information, see [Card navigation pane](xref:Working_with_cards_in_DataMiner_Cube#card-navigation-pane).

    > [!NOTE]
    > For dynamic virtual elements., this page is only supported for the parent element, not for child elements.

  - **GENERAL PARAMETERS**: General parameters for the element, such as its lock status, number of alarms, connection state, etc. See [General parameters](xref:General_parameters).

  - **ANNOTATIONS**: Page where more extensive annotations can be added and viewed. With the pencil icon on this page, you can open an HTML editor that allows you to add text, hyperlinks, pictures, etc. to the annotations. There is also an icon that can be used to print the annotations, and an icon to refresh the annotations page.

    > [!NOTE]
    > From DataMiner 10.2.0/10.1.12 onwards, annotations can be disabled using the soft-launch option *LegacyAnnotations*. See [Soft-launch options](xref:SoftLaunchOptions).

  - **HELP**: Help page for the protocol of the element. This page is only displayed if such a help page is available for the protocol (from DataMiner 9.5.7 onwards).

  > [!NOTE]
  > Many protocols include a web interface page as one of the data pages. However, such a web interface is only accessible when the client machine has network access to the product. Web interface pages are hidden to users who do not have the user permission [*General* > *Elements* > *Data Display* > *Device webpage access*](xref:DataMiner_user_permissions#general--elements--data-display--device-webpage-access).
