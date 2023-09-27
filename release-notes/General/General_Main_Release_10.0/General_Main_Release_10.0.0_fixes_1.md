---
uid: General_Main_Release_10.0.0_fixes_1
---

# General Main Release 10.0.0 - Fixes (part 1)

#### Not possible to assign Visio file to imported view or service \[ID_19280\]\[ID_20207\]

If a service or view had been imported via a .dmimport package, it could occur that it was not possible to assign a Visio file to it.

#### DataMiner Cube - Trending: Enabling or disabling statistics would not update the trend graph \[ID_19358\]

When, in the Statistics window of a trend graph, you enabled or disabled one of the checkboxes (Average, Mean deviation, etc.), in some cases, the trend graph would not be updated unless you forced a redraw by panning or zooming.

#### Service & Resource Management - Service Chain: Problem when restarting an element \[ID_19368\]

When a service chain setup contained a connection property shape, in some cases, an exception could be thrown when you restarted an element in the chain.

#### DataMiner Cube: Function name displayed incorrectly on alarm card \[ID_19583\]

On the alarm card of an alarm with a function impact, it could occur that the name of the function was not displayed correctly if it contained several underscores.

#### Problem with SLAnalytics when opening a trend graph \[ID_19603\]

When you opened a trend graph, in some rare cases, an error could occur in SLAnalytics causing the graph to not show any prediction.

#### Parameters with RTDisplay set to false also processed by Analytics \[ID_19660\]

Up to now, DataMiner Analytics incorrectly also took parameters into account that had RTDisplay set to false, which could cause errors to be displayed in the SLAnalytics logging.

#### Default service card page setting not applied for visual page of SRM service \[ID_19674\]

If the default service card page was set to “Visual page” in the user settings, for an SRM service, it could occur that this setting was not applied.

#### DataMiner Cube: Exception when opening alarm card with service impact from removed SRM service \[ID_19679\]

If there was an alarm on the function DVE of a service booking instance, and the service was deleted at the end of the booking, it could occur that an exception was thrown when you opened the alarm card of one of the alarms affected by this service.

#### Service & Resource Management: Problem with removal of DCF entry point connections \[ID_19728\]

When, in setups with multiple entry points, an entry point connection was removed, in some cases, the connections of all entry points would be removed.

#### DataMiner Cube: Incorrect alarm filter after dragging an item onto the Alarm Console \[ID_19750\]

In some cases, dragging an item onto the Alarm Console would change the alarm filter you applied earlier.

#### Spectrum Analyzer component not loading correctly in HTML5 app \[ID_19812\]

In the HTML5 app, it could occur that the spectrum trace could not be displayed for Spectrum Analyzer components that did not have a reference level or reference scale set.

#### Trending - SLAnalytics: Trend predictions did not take into account the most recent trend data \[ID_19832\]

When you opened a trend graph, in some cases, trend predictions would not take into account the most recent trend data.

#### SLAnalytics: Alarm limits containing exception values could not be parsed correctly \[ID_19911\]

In some cases, alarm limits containing exception values could not be parsed correctly.

#### Problem with SLSNMPAgent process \[ID_20278\]

In some cases, an error could occur in SLSNMPAgent when an element was added, deleted or stopped.

#### Enhanced services did not receive currently active alarms after being restarted \[ID_20328\]

When an enhanced service was restarted (e.g. by editing the protocol), in some cases, it would not receive the currently active alarms when *Monitor Active Alarms* was enabled.

#### DataMiner Connectivity Framework: Problem deleting a connectivity chain throughout a DataMiner System \[ID_20343\]

In some cases, it was not possible to delete a connectivity chain throughout an entire DataMiner System using a DeleteConnectivitySettingsMessage.

#### Service & Resource Management: No enhanced service element created after update protocol ID for existing booking instance \[ID_20430\]

In the Service & Resource Management module, if the protocol ID was updated for an existing booking instance via the *AddOrUpdateReservationInstances* method, it could occur that no corresponding enhanced service element was created.

#### Web Services API v1: GetValuesForCPETopologyField method not returning values \[ID_20483\]

In some cases, it could occur that the *GetValuesForCPETopologyField* method did not return any values, even though values were available.

#### DataMiner Cube: Problem when exporting redundancy group \[ID_20519\]

In some cases, an issue could occur when a redundancy group was exported to a .dmimport package. In particular, when a redundancy group contains a condition involving a virtual primary element from a different redundancy group, that redundancy group will now also be included in the export package.

#### Problem with masking until clearance of parameter or cell \[ID_20553\]

In some cases, when a parameter or cell were set to be masked until an alarm on that parameter or cell was cleared, it could occur that they remained masked even after the alarm was cleared.

#### Not possible to assign alarm template to enhanced service \[ID_20580\]

In some cases, it could occur that it was not possible to assign an alarm template to an enhanced service.

#### DMS Reporter: Incorrect top 10 report if service had elements on different DMAs \[ID_20628\]

If a report was configured to display the top 10 services that spent the largest percentage of time in an alarm state, and the elements in a service were spread over multiple DMAs, it could occur that the report was not generated correctly.

#### Profile Manager: Problem when creating a profile parameter entry \[ID_20670\]

In some cases, an exception could be thrown when a profile parameter entry was created.

#### DataMiner upgrade: Problem when QActions were found without 'encoding' attribute \[ID_20673\]

In some cases, during an DataMiner upgrade, an exception could be thrown when a QAction was found that did not have an “encoding” attribute.

#### Problem when updating a view property with its current value \[ID_20693\]

In some cases, an exception could be thrown when a view property was updated with the value it had before the update.

#### SLAnalytics: Problem when multiple messages were sent simultaneously to SLNet \[ID_20703\]

In some rare cases, an exception could be thrown when multiple messages were sent simultaneously to SLNet in SLAnalytics.

#### Service & Resource Management: Serialization exception when object configuration was specified on service definition node \[ID_20720\]

When an object configuration was specified on a service definition node, this could result in a serialization exception.

#### Failover: Profile Manager data only synchronized at next DataMiner restart \[ID_20825\]

When a Failover switch was performed, in some cases, changes made to Profile Manager data would not be synchronized until the next DataMiner restart.

#### Failover: New service definitions would not be visible in the Service Manager app after a Failover switch \[ID_20832\]

When a Failover switch was performed, in some cases, newly created service definitions would not be visible in the Service Manager app.

#### Element would not go into an error state when the creation of a logger table failed \[ID_20859\]

When the creation of a logger table failed, in some cases, the element in question would not go into an error state.

#### Correlation: No correlated alarm created when using a 'new alarm' correlation action with severity 'Lowest severity of source alarms' \[ID_20917\]

When using a correlation rule with a “new alarm” action and severity set to “lowest severity of source alarms”, in some cases, no correlated alarm would be created when the alarm with the lowest severity was a normal alarm. In this kind of situation, from now on, the second lowest severity will be taken.

#### SLLogCollector process stopped upon DMA restart \[ID_20939\]

Previously, when a DMA was restarted, it could occur that the SLLogCollector process was stopped, causing DMS log information to be lost. This will no longer occur.

#### DataMiner Cube - System Center: Problem with user credentials sharing the same name \[ID_20999\]\[ID_21011\]

When, in System Center, you created a credential in the credential library, up to now, DataMiner Cube would incorrectly only compare the name of the new credential to those of the existing names in the same group. As a result, when another user created a credential with the same name in another group, no error would appear. The DataMiner Agent, on the other hand, would not save the credential.

From now on, when user create a credential of which the name is identical to that of an existing credential, an error will appear.

#### Service & Resource Management: Problem when reserving services and enhanced services \[ID_21007\]

In a DataMiner System, in some cases, IDs of services and enhanced services would be reserved twice due to a synchronization issue.

#### When an alarm filter or a trend filter was changed, the old filter was not added to the recycle bin \[ID_21030\]

When you changed a trend filter or an alarm filter, up to now, the XML file containing the old filter would not be added to the recycle bin.

#### DataMiner Upgrade: Problem with upgrade action that reformats GPIB port settings \[ID_21115\]

In some cases, the upgrade action that reformats GPIB port settings would not process disabled bus addresses incorrectly.

#### Problem with mask state of alarm after deleting and re-adding a row containing a masked cell \[ID_21278\]

When you deleted a table row with a masked cell, added that row again, and then unmasked the masked cell of the new row, the alarm would incorrectly stay masked until an alarm update was generated.

#### Problem when generating an enhanced service protocol \[ID_21283\]

When an enhanced service protocol was generated, in some cases, some of the generated parameters would incorrectly be placed on the same Data Display position.

#### Failover: Problem with incorrect database messages \[ID_21305\]

In a Failover setup without Cassandra or Indexing databases, in some cases, messages related to Cassandra or Indexing databases would incorrectly appear.

#### DataMiner Cube: Problem when choosing to recreate an element after changing its protocol \[ID_21316\]

When, after changing the protocol of an existing element, you chose to make Cube recreate the element by deleting the existing element and then creating a new element with a new element ID, in some cases, the existing element would be deleted, but no new element would be created.

#### Problem with SLElement when a masked element was stopped the moment it was automatically unmasked after a certain period \[ID_21317\]

In some cases, an error could occur in SLElement when an element, which had been masked for a certain period of time, was stopped the moment it was automatically unmasked.

#### Service & Resource Manager: Time zone difference not taken into account when checking for available resources \[ID_21318\]

When a client requested an available resource from the server, the possible time zone difference between client and server was not taken into account, which could lead to incorrect results.

#### DataMiner Cube - Visual Overview: 'ClosePage' option not working on subshape or shape on embedded page \[ID_21481\]

If a subshape within a group or a shape on an embedded page was configured with the *ClosePage* option, it could occur that this option did not work correctly.

#### DataMiner Cube - Trending: Exception values incorrectly taken into account when calculating statistical values \[ID_21593\]

When you opened the statistics window of a trend graph containing exception values, in some cases, those exception values would incorrectly be taken into account when calculating the statistical values (average, minimum, maximum).

#### Mobile Gateway: Problem when setting the cellphone location \[ID_21617\]

In some cases, an exception could be thrown when setting the location of the Mobile Gateway.

#### Sending GetInfoMessage of type 'IndexingConfiguration' incorrectly returned the indexing engine configuration of all DataMiner Agents \[ID_21770\]

When a GetInfoMessage of type “IndexingConfiguration” was sent containing one specific DataMiner ID, the indexing configuration of all DMAs would incorrectly be returned.

From now on, only the indexing configuration of the specified DMA will be returned, except when the DataMiner ID in the GetInfoMessage request was equal to -1.

#### CPE Manager: Empty top filters after item selection in lowest filter \[ID_21821\]

In some cases, it could occur that the top filters of the CPE topology remained empty if an item had been selected in the filter at the lowest level first.

#### DataMiner Cube - Logging: Problem when trying to open a log entry \[ID_21676\]

When you opened the *Logging* window by clicking the *Logging* button in the bottom-right corner of Cube’s login screen, selected a log entry and clicked *Open*, in some cases, the log entry would not be opened.

Also, a number of minor enhancements have been made to the *Logging* window.

#### DataMiner Cube - Logging: Log entry pop-up window not resized when Cube was resized \[ID_21756\]

When, in the *Logging* section of System Center (or the *Logging* window opened on Cube’s login screen), you opened a log entry in a pop-up window, in some cases, that log entry pop-up window would incorrectly keep its same size when you resized DataMiner Cube. From now on, log entry pop-up windows will be resized when you resize DataMiner Cube.

#### DataMiner Cube - Reports: Problem with 'top X' reports \[ID_21778\]

In some cases, in DataMiner Cube, the “top X” reports, which you find e.g. in a view card under *Reports \> More \> Top*, would incorrectly list the “bottom X” items instead of the “top X” items.

#### SNMP polling with V3 HMAC-MD5 or HMAC-SHA authentication algorithms caused memory leak in SLSNMPManager \[ID_21788\]

When SNMP polling was used with V3 HMAC-MD5 or HMAC-SHA authentication algorithms, a memory leak could occur in one of the SLSNMPManager processes.

#### DataMiner Cube - Visual Overview: Clicking a shape configured to perform a parameter set would cause shape text to be copied instead \[ID_21818\]

When a shape displayed some text and was configure to perform a parameter set when clicked, in some cases, clicking that shape would incorrectly cause the text displayed on that shape to be copied rather than cause the parameter set to be executed.

#### Incorrect analytics trend arrows \[ID_21851\]

In some cases, after SLAnalytics was shut down, it could occur that records for the trend arrows were not correctly stored in the database, which could cause Cube to display incorrect trend arrows.

#### DataMiner Cube - Visual Overview: Trend graph would not be properly refreshed when a dynamic placeholder was updated \[ID_21890\]

When, in a data item of type “Parameters” or “ParametersOptions” of a shape displaying a trend graph, a dynamic placeholder was updated, in some cases, the trend graph would not be properly refreshed.

#### No mask comment added to newly created alarms for masked table rows or table row cells \[ID_21927\]

When a new alarm was generated for a masked table row or table row cell, in some cases, no mask comment would be added to that new alarm.

#### Service & Resource Management: Problem with license (number of concurrent bookings) \[ID_21970\]

When the maximum amount of bookings had been scheduled, in some cases, it would not be possible to edit one of those bookings.

#### DataMiner Maps: Dynamic data in \<Detail> tags would be overwritten \[ID_22009\]

In some cases, dynamic data in \<Detail> tags would be overwritten, resulting in incorrect and/or missing placeholder values.

#### Monitoring & Control app: No data in legend for trend graph with gap \[ID_22032\]

In some cases, if a trend graph contained a gap between two trend points, no data was displayed in the legend for that trend graph for a section that was larger than the actual gap.

#### Reporter: Export to Excel/CSV did not contain all rows of a partial table \[ID_22069\]

When, in Reporter, you exported a report to an XLS or CSV file, in some cases, that file would not contain all rows of a partial table. From now on, the exported file will be able to contain up to 1 million rows.

> [!NOTE]
> When you export a report to an HTML or MHT file, that file will display only the first page of a partial table (using the page size configured in the protocol).

#### DataMiner Cube - Service & Resource Management: Caching issue with reservation instances that were more than 21 days in the future \[ID_22091\]

Previously, reservation instances with a start time of more than 21 days in the future were not cached. However, this could result in issues when such an instance was created and then quickly retrieved afterwards. Now the 500 most recently saved instances outside the default cache period of 21 days will be cached too.

#### Problem with alarms not impacting a virtual function \[ID_22127\]

In some cases, alarms would not impact a virtual function without an entry point.

#### DataMiner Cube - CPE: Incorrect table filtering due to deprecated option 'oldFiltering' \[ID_22201\]

In some cases, CPE tables would be filtered incorrectly when using the deprecated option “oldFiltering”.

#### DataMiner Cube - CPE: Opening a CPE object in another chain did not clear all filters of the destination chain before selecting the new item \[ID_22217\]

When you opened a CPE object in another chain using the right-click menu on the CPE diagram item, not all filters would be cleared in the destination chain before the new item was selected.

#### Ticketing: Ticket properties not refreshed after updating a ticket \[ID_22322\]

When you updated a ticket, in some cases, the ticket properties would not get refreshed.

#### DataMiner Agent would not notify the client when objects were unmasked when the masking period elapsed \[ID_22354\]

When, after you had masked a DataMiner object for a period of time, the object and its child items were automatically unmasked when the masking period elapsed, in some cases, the DataMiner Agent would not notify the client application. As a result, the client application would incorrectly continue to show the items as masked.

#### When a DataMiner object was masked for a period of time, not all child object would be unmasked when the masking period elapsed \[ID_22395\]

When you masked a DataMiner object for a period of time, and that object had multiple alarms, in some cases, not all those alarms would be unmasked when the masking period elapsed.

#### Ticketing: Problem when updating a ticket \[ID_22420\]

In some cases, an exception could be thrown when you updated a ticket.

#### DataMiner Cube - Visual Overview: WCF connection timeout caused 'Failed' message to appear after clicking 'Edit in Visio' \[ID_22426\]

When, in Cube, you had clicked *Edit in Visio*, after ten minutes of inactivity, a WCF connection timeout could cause a “Failed” message to appear.

From now on, when you click *Edit in Visio*, a heartbeat mechanism will prevent WCF connections from going into timeout.

#### DataMiner Cube - Cards: 'REPORTS \> More' page missing \[ID_22500\]

When you expanded the *REPORTS* page in a card’s navigation page, in some cases, there was only one subpage named *General*. The other subpage, named *More*, would be missing.

#### Problem with information events not being migrated from MySQL to Cassandra \[ID_22515\]

During a migration from MySQL to Cassandra, in some cases, information events would not get migrated.

#### Problem with topology alarm properties in case of recursive directview/view tables \[ID_22530\]

When a topology cell was defined on a direct view table, in some cases, the alarm properties would not be filled in if view tables defined between the data table and the direct view table.

#### DataMiner Cube: Incorrect sorting of direct view tables and view tables with columns containing data retrieved from other tables \[ID_22537\]

In some cases, direct view tables and view tables with columns containing data retrieved from other tables would be sorted incorrectly.

#### SLAnalytics: Unresolved placeholder in debug log entries \[ID_22612\]

In some cases, debug log entries would incorrectly contain a “%s” placeholder instead of the element ID.

#### Service & Resource Management: Discrete parameters not displayed correctly in contributing services \[ID_22614\]

In a contributing service, it could occur that discrete parameters were not displayed correctly. The way profile parameters are handled in the SRM module has now been enhanced, so that discrete parameters can be included correctly in contributing services. Note that this change could cause some loss of data if you upgrade to this version of DataMiner and then downgrade again.

#### DataMiner Cube: CPE views cards no longer showed child objects after a DELT export had been launched \[ID_22621\]

After a DELT export had been launched, in some cases, the navigation pane of a CPE view card would no longer show any child objects.

#### Service & Resource Management: Duplicate booking instances after midnight sync \[ID_22639\]

A problem could occur when SRM data were synchronized during the daily midnight sync of a DMS, causing duplicate booking instances.

#### Problem when taking a backup containing Elastic data \[ID_22653\]

When taking a backup containing Elastic data, in some cases, a problem could occur when an Elastic index contained a dot (“.”).

#### Child elements were not notified when they exported a parameter impacted by a change to Description.xml or Port.xml \[ID_22654\]

As changes to element files like Description.xml and Port.xml can impact parameters, elements are notified when one of their parameters is impacted by such a file change.

However, up to now, child elements (e.g. DVE elements or virtual functions) would not receive any such file change notification. From now on, child elements will also receive file change notifications when they export parameters that are impacted by a particular file change.

#### Problem after stopping an element that stored data into an Indexing database and restarting the DataMiner Agent \[ID_22656\]

When a DataMiner Agent was restarted after an element that stored data into an Indexing database was stopped, in some cases, an exception could be thrown.

#### Web Services API v1: Problem with DMAParameter.IsTrending \[ID_22684\]

When a parameter had its trending attribute set to “true” in the protocol.xml, in some cases, when that parameter was passed by a web method, its IsTrending property would be “true”, even if it was not being trended in the element in question.

#### Resources app: New properties not available for existing resources \[ID_22693\]

In the Resources app, it could occur that if new properties were created, these were not available for existing resources.

#### DataMiner Cube: Memory leak when opening CPE cards \[ID_22694\]

When you opened a CPE card with a Visio file that showed tables in shapes, but you did not navigate to Visual Overview, in some cases, a memory leak could occur.

#### Service & Resource Management: Problem with Profile Manager when filtered subscriptions were being used \[ID_22698\]

In some cases, the Profile Manager could throw an exception when filtered subscriptions were being used.

#### DataMiner Cube - Alarm Console: Incorrect time range shown when editing a history tab page \[ID_22699\]

When you clicked the pencil icon of a history tab page in order to edit that tab page, in some cases, the time range would be filled in incorrectly.

#### DataMiner Cube - Visual Overview: Problem when closing a Visual Overview \[ID_22711\]

In some cases, an exception could be thrown when you closed a Visual Overview.

#### Service & Resource Management: Problem when trying to open a functions.xml file \[ID_22744\]

Due to a problem with file access rights, in some cases, it would not be possible to manually open a functions.xml file for e.g. debugging purposes.

#### ProfileManagerHelper.GetProfileInstance with empty GUID returned random profile \[ID_22768\]

Previously, if the method *ProfileManagerHelper.GetProfileInstance* passed an empty GUID, a random profile was returned. Now null will be returned in this case.

#### DataMiner Cube - Alarm Console: Problem when grouping or sorting the alarms \[ID_22797\]

When the Alarm Console contained at least two alarm tab pages, and more that 50 alarms per second were received, an error could occur while grouping or sorting the alarms.

#### Inconsistent access to enhanced service elements among the agents in a DataMiner System \[ID_22798\]

In some cases, access to enhanced service elements would be inconsistent among the different agents in a DataMiner System.

#### Problem when updating the Visio file linked to a service hosted on another DMA \[ID_22814\]

In some cases, it could occur that it was not possible to update the Visio file linked to a service hosted on a DMA other than the one you were connected to.

#### Failover: Deleted ticket field resolver would re-appear after a switch-over \[ID_22822\]

When a ticket field resolver was deleted on a Failover system, in some cases, it could re-appear after a switch-over due to a caching problem.

#### Analytics: Mid-term prediction was not shown when polling frequency exceeded 1 minute \[ID_22863\]

In some cases, mid-term prediction would not be shown when the polling frequency exceeded 1 minute.

#### Spectrum Analysis: Problem when sending a SpectrumElementSpecificConfigRequestMessage \[ID_22882\]

When a SpectrumElementSpecificConfigRequestMessage was sent, in some cases, an exception could be thrown when the element.xml file of the spectrum element in question did not contain a \<SpectrumElementSpecificConfig> tag.

#### DataMiner Cube: Cards could get stuck in a 'loading' state when users had not been granted the 'Correlation/UI available' permission \[ID_22908\]

In some cases, cards could get stuck in a “loading” state when users had not been granted the “Correlation/UI available” permission.

#### DataMiner Cube - Security: List of user/group permissions was not sorted alphabetically \[ID_22939\]

When you opened System Center and navigated to the permissions of a particular user or user group, the “Bookings” permission was not displayed at the correct location in the list.

The list of permissions is now again sorted alphabetically.

#### DataMiner Cube - Visual Overview: Columns were not hidden correctly when their width was set to 0 in a 'ColumnWidth' option \[ID_22960\]

When, in a shape data field of type *ParameterControlOptions*, you added a *ColumnWidth* option in which you set the width of a particular column to 0 pixels, in some cases, that column would not be hidden correctly.

#### Reporter: Problem with CPE status report on view tables using advanced naming \[ID_22965\]

When, in Reporter, you generated a CPE status report, in some cases, tables using advanced naming would show primary keys instead of display keys.

Also, in case of custom reports, the DMS_getTableFiltered method would incorrectly return display keys when the tables in question used advanced naming.

#### HTML5 apps: Last column of a list view would incorrectly take up all remaining space \[ID_22993\]

In some cases, the last column of a list view would incorrectly take up all remaining space.

#### DataMiner Cube: Problem during startup when no connection could be made to the internet \[ID_22995\]

When DataMiner Cube was not able to connect to the internet during startup, in some cases, the UI could momentarily become unresponsive.

#### Problem with SLSNMPManager when stopping or deleting a duplicated SMNPv3 element \[ID_23006\]

When one of multiple SNMPv3 elements using identical credentials was stopped or deleted, in some cases, the remaining ones would go into timeout.

#### DataMiner Cube - Visual Overview: Problem when displaying trend graphs \[ID_23041\]

When a trend component on a Visio page was configured to display a trend graph when selecting a table index from a list of table parameter indices, in some cases, no trend graph would be displayed when you selected a table index from the list.

#### Visio: Shapes linked to enhanced service not displayed for some users \[ID_23059\]

In some cases, for an enhanced service that was part of other services, it could occur that linked shapes in Visio were not displayed for users with limited user permissions.

#### Not possible to select different drive for Cassandra installation \[ID_23068\]

In the Cassandra installation/migration wizard, it could occur that it was not possible to change the drive where Cassandra had to be installed.

#### Labels/crosspoints not displayed correctly for exported matrix parameters \[ID_23069\]

In some cases, it could occur that matrix labels and crosspoints were not displayed correctly for exported matrix parameters of virtual functions or DVE child elements. To prevent this, the *Description.xml*, *labels.xml* and *Ports.xml* files of a parent element will now be applied to its child elements.

#### Service & Resource Manager - Profile Manager: Problem during DMS startup \[ID_23070\]

In some cases, Profile Manager could throw an exception while the DataMiner System was starting up.

#### HTML5 apps: App title not always displayed correctly on login screen and/or title bar \[ID_23076\]

In some cases, the app title of an HTML5 app would not be displayed correctly on the login screen and/or the app’s title bar.

#### Problem in SLDataMiner when importing large amount of element data \[ID_23120\]

When a large amount of element data was imported, a problem could occur in the SLDataMiner process.

#### SNMP Manager sending SNMPv3 inform messages stuck in ping mode \[ID_23132\]

If an SNMP Manager in DataMiner was configured to send SNMPv3 inform messages and went into ping mode, it could occur that it remained stuck in this mode.

#### DataMiner Cube: Parameters displayed on dialog boxes had an incorrect parameter description \[ID_23167\]

When a parameter was displayed on a dialog box, in some cases, its parameter description would be incorrect.

#### Various issues with Cube breadcrumbs \[ID_23169\]

A number of issues have been resolved that could occur with the breadcrumbs at the top of cards in DataMiner Cube:

- When an object was renamed, it could occur that the name in the breadcrumbs was not updated.
- When an object had been deleted, it could occur that it was still displayed in the breadcrumbs' drop-down menu.
- For services that only contained excluded devices, it could occur that breadcrumbs were not displayed correctly.
- Breadcrumbs will no longer be displayed in upper case only.

In addition, on a view card, it could occur that the list of elements was not updated if an element was removed from the view while the card was open.

#### End time of masking operation not applied correctly \[ID_23157\]\[ID_23170\]

When a parameter was masked for a limited period of time, it could occur that the end time of the mask operation was not applied correctly.

#### DataMiner Cube - Automation: Window appearing when an Automation script fails had an incorrect caption on a Cube with custom branding \[ID_23171\]

When using a DataMiner Cube with custom branding, up to now, the window that appeared when an Automation script failed would incorrectly have the default “Skyline DataMiner” caption. From now on, on a DataMiner Cube with custom branding, the caption of that window will show the custom product name.

#### DataMiner Cube: Alarm storm prevention incorrectly enabled while being disabled in enforced group settings \[ID_23181\]

When the alarm storm prevention mechanism was enabled in the user settings but disabled in enforced group settings, in some cases, it would incorrectly be enabled.

#### SNMP Managers not respecting resend timer in system with virtual SNMP agent \[ID_23188\]

In a system that had a virtual SNMP agent configured, it could occur that the resend timer of SNMP Managers was not always respected.

#### Visio: PushContextMenu not working correctly with service chain container or a signal path container \[ID_23194\]

If the *PushContextMenu* option was used for shapes like a service chain container or a signal path container, this caused the container to become clickable and then contain all of the context menu items and actions of its children. To avoid this unintended behavior, these container shapes will no longer have any actions of their own.

#### Problem when restoring a backup containing Elastic data \[ID_23197\]

When, after re-installing the Elastic database and starting DataMiner, you took a backup containing Elastic data, in some cases, it would not be possible to restore that backup.

#### Service & Resource Management - Visual Overview: Service chain not displayed correctly \[ID_23205\]

If a Visio drawing displayed a booking service chain with its expected connections, but the booking contained resources that were not linked to an element, it could occur that the chain was not displayed correctly. Now, resources that are not linked to an element will be ignored.

#### DataMiner Cube: Problem with Element migration window \[ID_23237\]

When connected to a DataMiner System with multiple DataMiner Agents, you opened *System Center \> Agents \> Status*, clicked *Migrate*, selected a destination agent and a number of elements, and then clicked either *Migrate* to start migrating the selected elements to the selected agent or *Cancel* to exit the *Element migration* window, in some cases, an exception could be thrown.

#### DataMiner Cube - Backup: No backup made if only Elastic data was selected \[ID_23248\]

Up to now, when you made a custom backup that only contained Elastic data and no Cassandra data, no backup file would be created.

From now on, it is possible to make a backup that only contains Elastic data.

#### DataMiner installation failed when no theme was selected \[ID_23253\]

When DataMiner was installed and no theme had been selected during the setup of the installer, it could occur that the installation failed.

#### DataMiner Cube - Visual Overview: Only one shape used of source/destination shapes with same tag \[ID_23261\]

If shapes in Visio were tagged as a source or destination and multiple shapes had the same tag, only one of them would work as a source or destination. Now all shapes with matching tags will be considered a possible source or destination.

#### DataMiner Cube - Visual Overview: Automatic connection lines generated instead of connectors drawn in Visio \[ID_23295\]

In some rare cases, it could occur that connectors drawn in Visio were replaced by regular connection lines generated by Cube.

#### HTML5 apps: Problem when mouse pointer went outside the Scheduler component \[ID_23302\]

In the HTML5 apps (Dashboards, Jobs, etc.), in some cases, the Scheduler component would not react as expected when moving the mouse pointer away from it.

When you move the mouse pointer away from the Scheduler component and back, from now on, the action will either continue when the mouse button is being pressed or be canceled when the mouse button is no longer being pressed.

#### Incorrect column spans in interactive Automation script in HTML5 applications \[ID_23325\]

If an interactive Automation script was run using a HTML5 DataMiner application, it could occur that the column spans in the script were not correctly applied.
