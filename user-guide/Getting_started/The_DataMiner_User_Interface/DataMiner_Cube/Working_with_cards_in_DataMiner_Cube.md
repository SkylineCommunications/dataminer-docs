---
uid: Working_with_cards_in_DataMiner_Cube
---

# Working with cards in DataMiner Cube

## DataMiner Pulse

When no docked cards are open, the card pane in DataMiner Cube displays the “DataMiner Pulse” home page.

On this page, you can find:

- A list of recent items on the left-hand side. Any pinned items are displayed at the top of the list, separated from the rest of the list with a line.

- The alarm distribution of the last day.

- News items related to DataMiner. Depending on your user permissions, this may include information about protocol updates or DataMiner software updates.

- Weather information. Only available up to DataMiner 9.6.0/9.6.4. Up to DataMiner 9.5.11, this is only displayed if a location can be established (e.g. via the *Location* service in Windows 10). From DataMiner 9.5.12 onwards, you can select a location yourself via the location icon next to the *Weather* title.

- A link to the landing page for the DataMiner web apps on the right-hand side.

> [!NOTE]
>
> - Depending on your user permissions, some of these items may not be displayed.
> - From DataMiner 9.6.1 onwards, the Cube user settings allow you to customize which information is shown on this page. See [Cube settings](xref:User_settings#cube-settings).

## Card types

There are many different types of cards, such as:

- Element cards

  For more information on element cards, see [Element cards](xref:Element_cards).

- Service cards

  For more information on service cards, see [Service cards](xref:Service_cards).

- View cards

  For more information on view cards, see [View cards](xref:View_cards).

- Alarm cards

  For more information on alarm cards, see [Alarm cards](xref:Alarm_cards).

- User cards

  For more information on user cards, see [Managing users](xref:Managing_users).

- Spectrum analyzer cards

Depending on the protocol used, many more types of cards are possible, such as Carrier Management cards for carrier monitoring elements, or CPE Manager cards (see [Experience and Performance Management](xref:EPM)).

## Card navigation pane

On the left side of view cards, service cards and element cards, a navigation pane is displayed.

You can collapse and expand this pane with the arrow button in the top-right corner of the pane. You can also change the size of the pane by dragging its edge.

The pane consists of a tree view with several fixed nodes:

- **VISUAL**: Contains all available Visual Overview pages.

  > [!NOTE]
  >
  > - A Visual Overview page can contain multiple tabs. If there are too many tabs to display them all on the screen, a “...” icon will be displayed. To open one of the tabs that are not displayed, you can click this icon and select the tab from the drop-down list.
  > - As you can also access these tabs from the card navigation pane, it is possible to hide them in Visual Overview by means of the *Show tab pages* user setting. For more information, see [Visual Overview settings](xref:User_settings#visual-overview-settings).
  > - If a Visual Overview page contains a background image, the header bar and navigation pane will be hidden after 3 seconds without mouse movement. Simply move the mouse again to make them reappear.
  > - Whether zooming in and out on a Visual Overview page is possible depends on the configuration of the page in Visio. See [EnableZoom](xref:Overview_of_page_and_shape_options) and [DisableZoom](xref:Overview_of_page_and_shape_options).

- **DATA**: Contains all available Data Display pages.

  > [!NOTE]
  >
  > - Optionally, a Data Display page selector can be displayed on an element card, in addition to or instead of the tree view in the navigation pane. See [Card settings](xref:User_settings#card-settings).
  > - If you open a subpage of a Data Display page by selecting it in the card navigation pane instead of by clicking a page button, the subpage is opened in the same card, and at the top, a button “Up to \[parent page name\]” is displayed, which allows you to quickly go to the parent page.
  > - Element protocols can be configured to hide one or more Data Display pages depending on a parameter value.
  > - Prior to DataMiner 9.6.7, a view has a DATA node with pages listing the items within the view. From DataMiner 9.6.7 onwards, this node is called “BELOW THIS VIEW” instead.

- **ALARMS**: Displays an overview of all alarms on the selected item.

  > [!NOTE]
  > If this page is open, the card’s header bar menu contains an additional item, *Alarm Console*, with the same settings as in the Alarm Console menu. For more information, see [Alarm Console settings](xref:AlarmConsoleSettings).

- **REPORTS**: Displays graphical reports of the alarm distribution, alarm events, alarm states, and alarms on a timeline.

- **DASHBOARDS**: Displays the legacy *Dashboards* app.

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.12 onwards, the legacy Dashboards app can be disabled using the soft-launch option *LegacyReportsAndDashboards*. See [Soft-launch options](xref:SoftLaunchOptions).

- **NOTES**: Allows users to add short notes to DataMiner items:

  - Each note can have a title, a description and an expiration date.

  - Each note can be removed with the x in its top-right corner.

  - Expired notes are only displayed if you select *Show expired notes* in the top-right corner of the card. They are then displayed in a different color, so you can clearly see the difference with the notes that are not expired.

- **ANNOTATIONS**: Displays more extensive comments on DataMiner items. With the pencil icon on this page, you can open an HTML editor that allows you to add text, hyperlinks, pictures, etc. to the annotations. There is also an icon that can be used to print the annotations, and an icon to refresh the annotations page.

  > [!NOTE]
  > From DataMiner 10.2.0/10.1.12 onwards, annotations can be disabled using the soft-launch option *LegacyAnnotations*. See [Soft-launch options](xref:SoftLaunchOptions).

Depending on the type of cards, more nodes may be available, e.g. *AGGREGATION* on view cards.

> [!NOTE]
>
> - When you select a page in the card navigation pane while holding down the SHIFT key, that page will be selected in every open card.
> - While the navigation pane is collapsed, if you click the VISUAL or the DATA node, the last open Visual Overview or Data Display page will be displayed. To expand the navigation pane and select a different page, simply click the node again.
> - For custom element applications, by default no card navigation pane is displayed. However, it is possible to open this pane by selecting the option *Show card side panel* in the card header menu.
> - The card navigation pane is only available from DataMiner version 9.0 onwards. In earlier versions of DataMiner, there is instead a rotate button that allows the user to change between a “Visual Overview” side of the card and a “Data Display” side.

## Card header bar menu

When you click the hamburger button in the top-left corner of a card, a shortcut menu with several commands is opened.

- **Back**: Goes to the previous open card. From DataMiner 10.0.10 onwards, this option goes to the previous open page, which can be on the same card.

- **Forward**: Goes to the next open card. From DataMiner 10.0.10 onwards, this option goes to the next open page, which can be on the same card.

- **Undock**: Opens the card in a separate, undocked window.

- **Dock**: Returns a card that was opened in a separate window to the main Cube window.

- **Pin this card**: Select this option to keep the card opened in the same position when other cards are opened. To unpin the card, click this option again. See [Pinning cards](#pinning-cards).

- **Close card**: Closes the card in question.

- **Device discovery**: Only available on view cards. See [Locating devices in your system to add to your DMS](xref:Locating_devices_in_your_system_to_add_to_your_DMS).

- **Visual overview**: Allows you to set different Visio files for the card’s Visual Overview pages. See [Switching between different Visio files](xref:Managing_Visio_files_linked_to_protocols#switching-between-different-visio-files).

- **Close other cards**: Closes all cards except the one you have clicked.

- **Close all docked cards**: Closes all cards that have been opened in the main Cube window, instead of in a separate window.

- **Close all undocked cards**: Closes all cards that have been opened in a separate window.

- **Close all cards**: Closes all cards.

> [!NOTE]
>
> - Depending on the type of card, more options can be available. These are discussed in detail in the sections of the help related to the item in question.
> - If some of these options are not available for you, it is possible that you do not have the necessary permissions to use them.

## Opening cards

By default, if you left-click items in the Surveyor using a card layout other than the tab layout, each new card you open will replace the previous open, docked card. You can then navigate between the cards with the back and forward commands.

- If only an undocked card is open when you open a new card, opening a new card will not replace the contents of the undocked card. The card will instead be opened as a new, docked card.

- If a card is open on a particular page, and a new card is opened to replace that first card, DataMiner Cube will open the new card on the page that is most similar to the page that was open in the first card. However, unless there is an exact match, if a default page has been defined in the protocol, that default page will be displayed instead.

- Width and collapsed/expanded state of the card navigation pane are remembered across cards. When you open a new card, the card navigation pane will be displayed in the same way as in the previous card.

However, you can also open items in a new card next to any cards that are already open, if you:

- Click an item with the middle mouse button in the Surveyor or on a view card,

- Hold *Ctrl* when you click an item in the Surveyor,

- Select *Open in new card* in the item’s right-click menu.

> [!NOTE]
> There is a limit to the number of cards, docked or undocked, that can be open on each side of the Cube. By default this number is set to 16, but it can be changed in the user settings. If you try to open more cards, a message will appear, telling you that the maximum number has been reached and you must close a card to continue.

## Changing the card layout

To change the card layout on the fly, drag the edge of a card to adjust its size.

To select a preconfigured Cube card layout:

- From DataMiner 10.0.0/10.0.2 onwards: Click the user icon in the top-right corner of the Cube UI and select *Change layout*. This will open a side panel where you can select a card layout.

- Using a DataMiner version prior to DataMiner 10.0.0/10.0.2: Click the card layout icon to the right of the user name and DMS time in the Cube header bar, and select the card layout you want.

The following layout options are available:

| Card layout | Description |
|--|--|
| Proportional | The size of the displayed cards is adapted so that they all have the same size. |
| Master left | One large card on the left is the master, all other open cards are shown proportionally to the right of it. |
| Master right | One large card on the right is the master, all other open cards are shown proportionally to the left of it. |
| Master top | One large card at the top is the master, all other open cards are shown proportionally below it. |
| Master bottom | One large card at the bottom is the master, all other open cards are shown proportionally above it. |
| Tab layout | The different open cards are shown in a row of tabs at the top of the screen. Click a tab to switch to that card. |
| Reset card layout | Resets any manual changes to the card layout, so that the cards again have the size determined by the selected card layout. This option is only available from the Cube header bar. |

> [!TIP]
> If you use the tab layout, from DataMiner 10.2.9/10.3.0 onwards, you can quickly close a tab by clicking the tab header with the middle mouse button. <!-- RN 34791  -->

## Dragging cards

It is possible to drag a card, by left-clicking and dragging the top edge of the card to its destination.

You can drag a card:

- If more than one card is open, to make the cards switch place. This can for instance be done in a Master/Detail card layout, to change which card is the master.

- If a maximized card is open above other cards, to drag the maximized card aside and check what is below it.

- To undock a card, by dragging it out of the workspace.

## Undocking cards

There are several ways to undock cards:

- Drag an open card out of the workspace.

- Hold *Shift* when you click an item in the Surveyor.

- Select *Open in new undocked card* in an item’s right-click menu.

If you open a different card from inside an undocked card, it will replace the undocked card in the same window.

## Pinning cards

To keep a card open in the same position when other cards are opened, it is possible to pin the card.

To do so, right-click the card header bar and select *Pin this card*.

To unpin the card again, right-click the card header bar and clear the selection from *Pin this card*.

> [!NOTE]
>
> - On a pinned card, no close button is available, so that you cannot close the card by accident. However, you can still close the card by selecting *Close card* in the header bar context menu.
> - If you use the tab layout, an additional option is available in the header bar context menu: *Use small pinned tabs*. If you select this option, pinned cards will have smaller tabs that only display the item’s icon.
