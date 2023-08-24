---
uid: DataMiner_Cube_tips_tricks
---

# DataMiner Cube tips & tricks

This section lists tips and tricks on how to use DataMiner Cube, including the tips displayed on the DataMiner Pulse homepage.

## About alarms

- Too many alarms in your Alarm Console? Adding conditions in the alarm template can help you reduce unnecessary alarms. See [Using conditions in an alarm template](xref:Using_conditions_in_an_alarm_template).

- You can drag and drop an element, service or view to the Alarm Console to instantly create an alarm tab linked to it. See [Applying an alarm filter by dragging an item onto the Alarm Console](xref:ApplyingAlarmFiltersInTheAlarmConsole#applying-an-alarm-filter-by-dragging-an-item-onto-the-alarm-console).

- Would you like to get a list of alarms in Word or Excel? Just drag them from the Alarm Console and drop them onto your Word or Excel document.

    > [!NOTE]
    > If you drag a list of more than 100 items to an application like Word or Excel, only the first 100 items will be copied.

- Do you want to see more information in your Alarm Console? Add extra columns. Those can even contain action buttons to quickly mask or acknowledge an alarm. [Changing the column layout in an alarm tab](xref:ChangingTheAlarmConsoleLayout#changing-the-column-layout-in-an-alarm-tab).

- Did you know DataMiner can make alarms blink as long as they are not acknowledged? [Making alarms without owner blink](xref:Making_alarms_without_owner_blink).

- Want to see which alarms were active in your system at a certain point in time? Use the history slider in the Alarm Console. See [Active alarms tab timeline](xref:WorkingWithTheAlarmConsoleHistorySlider#active-alarms-tab-timeline).

- Want to know which elements, parameters or severities appear most frequently in your active or history alarms? Click the *Statistical view* icon in the alarm bar. See [Using the statistical view](xref:ChangingTheAlarmConsoleLayout#using-the-statistical-view).

- Did you know the alarms right-click menu can be extended with additional items, such as hyperlinks, or options to start a program or script? See [Adding a custom command to the Alarm Console shortcut menu](xref:Adding_a_custom_command_to_the_Alarm_Console_shortcut_menu).

- Would you like to group alarms in the Alarm Console differently? Disable *Automatically group according to arrangement* to customize grouping, even combining multiple fields. See [Alarm Console settings](xref:AlarmConsoleSettings).

- Want to make sure an alarm only shows in the Alarm Console if it has been active for a while, instead of just for a couple of seconds? Use the *Delay* option. See [Alarm Console settings](xref:AlarmConsoleSettings).

## About shortcuts

- Would you prefer to display the Cube sidebar on the right? Press Ctrl+Alt+Shift+Right arrow. Want to put it back on the left? Use the same key combination, but with the Left arrow key.

- You can use shortcuts in Cube. Have you ever used Ctrl+Q to access the quick menu, or Ctrl+M to open a menu? See [Using keyboard navigation](xref:Using_keyboard_navigation).

- Want to open an item in an undocked card without using a context menu? Hold the Shift key while you click or double-click to open the item. For more shortcuts, see [Undocking cards](xref:Working_with_cards_in_DataMiner_Cube#undocking-cards).

- Want to open an item in a new card without using a context menu? Hold the Ctrl key while you click or double-click to open the item. See [Opening cards](xref:Working_with_cards_in_DataMiner_Cube#opening-cards).

- Need help? Press F1. See [Using keyboard navigation](xref:Using_keyboard_navigation).

## About workspaces

- Want to quickly open a new element in an existing card? Drag the element from the Surveyor onto the card header. See [Dragging cards](xref:Working_with_cards_in_DataMiner_Cube#dragging-cards).

- Cube workspaces support multiple screens. Take cards, drag them to your different screens and save your workspace. Then load the workspace and check out the result! See [Working with workspaces](xref:Working_with_workspaces).

- Have you used Cube's tab layout yet? You can access the card layout options via a button in the Cube header. You can also pin a tab page to keep it open at all times. See [Changing the card layout](xref:Working_with_cards_in_DataMiner_Cube#changing-the-card-layout).

- Here's a quick way to get a card into a separate window: just click the header and drag it out of Cube. Handy to show something on a second screen, for example. See [Dragging cards](xref:Working_with_cards_in_DataMiner_Cube#dragging-cards).

- Workspaces can also contain alarm tab pages. Just drag the tabs you want out of the Alarm Console, and click *Dock to workspace* in the top right corner.

## About the Surveyor

- Did you know that you can drag views, elements, services and SLAs directly from DataMiner Cube onto emails or open documents? You can do this from the Surveyor, but also from a view card data page or from a Visual Overview. See [Surveyor](xref:Main_Cube_UI_components_prior_to_DataMiner_10#surveyor).

- Would you like the Surveyor to display more information in the blink of an eye? Check out the Icons settings, by clicking the user button in the header and selecting *Settings* > *Icons*. See [Special icon settings](xref:Main_Cube_UI_components_prior_to_DataMiner_10#special-icon-settings).

- The Surveyor can be enriched with statistics, such as the number of alarms in a view. See [Displaying alarm statistics in the Surveyor](xref:Displaying_alarm_statistics_in_the_Surveyor).

- Would you like to have certain elements, views, services or apps easily available? Pin them in the recent activity list (also available in the Monitoring app). [Recent items](xref:Main_Cube_UI_components_prior_to_DataMiner_10#recent-items).

- Do you want to copy several elements from one view to another? Select them on the source view card and drag them to the target view in the Surveyor in drag-and-drop editing mode.

## About trending

- To quickly add more parameters to a trend graph, drag an element from the Surveyor and drop it onto the graph. Configure which parameters to add in the pane at the bottom. See [Accessing trend information from the Trending module](xref:Accessing_trend_information_from_the_Trending_module).

- Want to display a custom Y-axis range in a trend graph, instead of the range automatically determined by Cube? Right-click the graph and select *Y-axis settings*. This can for instance be useful to get a different perspective on the graph. See [Using the trending right-click menu](xref:Using_the_right-click_menu).

- Have you made a complicated trend graph with multiple parameters, and would you like to easily retrieve it again later? Save it as a trend group. See [Working with trend groups](xref:Working_with_trend_groups).

## Miscellaneous

- With the advanced options to open a DMS from the Cube start window, you can customize which view or app is initially shown – and you can do even much more than that! See [Arguments for DataMiner Cube](xref:Options_for_opening_DataMiner_Cube).

- Want to get alerts for a particular element, service or view? Right-click it in the Surveyor and select *Actions* > *Alert me*. See [Configuring notifications directly from the Alarm Console or Surveyor](xref:Configuring_notifications_directly_from_the_Alarm_Console_or_Surveyor).

- Want to have a user manual at hand when you work with a particular device? Add it in the *Documents* section of the element card. You can also add hyperlinks and email addresses. See [About the Documents module](xref:About_the_Documents_module).

- Use properties to add information to a view, element or service, such as a class defining a gold, silver or bronze service. These properties can also be displayed in the Surveyor. See [Adding a custom property to an item](xref:Managing_element_properties#adding-a-custom-property-to-an-item).

- Want to add a quick note to an element? Go to the *Notes* page in the card navigation pane. You can also do this for services and views. See [Card navigation pane](xref:Working_with_cards_in_DataMiner_Cube#card-navigation-pane).

- Want to quickly copy a table to an email or spreadsheet? Right-click the table in Data Display and select *Copy table*. See [Table parameters](xref:Table_parameters).
