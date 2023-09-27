---
uid: General_Main_Release_10.1.0_CU10
---

# General Main Release 10.1.0 CU10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_31784\]

A number of security enhancements have been made.

#### SLLogCollector will now also collect the NATS log and configuration files \[ID_31238\]

SLLogCollector will now also collect the log and configuration files from the NATS\\nats-account-server and NATS\\nats-streaming-server.

#### Security: New NATS installations will no longer open IP port 8222 \[ID_31422\]

During a NATS installation, from now on, only ports 4222 and 6222 will be opened. IP port 8222 will be left closed.

#### DataMiner Cube: Enhanced performance when logging in \[ID_31541\]

Due to a number of enhancements, overall performance has increased when logging in to Cube.

#### DataMiner Cube - EPM: Enhanced handling of hidden Data Display pages of EPM elements \[ID_31567\]

When the Alarm Console contained an alarm on a parameter of an EPM element with hidden Data Display pages\*, and the user had configured that the Data Display of the parameter had to be displayed when double-clicking the element, up to now, double-clicking the alarm would open a popup with the trend graph. From now on, the alarm card will be opened instead. If users want to access the trend information of the parameter in question, they can click the parameter name.

*\*If the “CPEOnly” option is specified in the protocol of an EPM element, the Data Display pages of that element are hidden for all users except administrators.*

#### Enhanced polling of SNMP tables using MultipleGetBulk and MultipleGetNext \[ID_31715\]

In DataMiner versions prior to 10.1.11, when MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm could get stuck into an infinite loop. That problem was fixed in DataMiner version 10.1.11, but now, the MultipleGetBulk/MultipleGetNext polling mechanism has received a more thorough overhaul.

#### SLA management: Enhanced automatic SLA data clean-up \[ID_31729\]

A number of enhancements have been made with regard to automatic SLA data clean-up.

### Fixes

#### DataMiner Connectivity Framework: Virtual functions would incorrectly inherit interfaces from the main element \[ID_30715\]

By default, the interfaces of a virtual function are the interfaces defined in the functions.xml file. Up to now, in some cases, virtual functions would also incorrectly inherited the interfaces of the main element.

#### SLLogCollector could fail to take process dumps \[ID_31213\]

In some rare cases, SLLogCollector could fail to take process dumps.

#### SLLogCollector would incorrectly stop collecting files when a file could not be copied \[ID_31220\]

When SLLogCollector would fail to collect a file from a remote server, in some cases, it would stop collecting log files. From now on, when it fails to collect a certain file, it will log the failure but continue to collect log files.

#### Service & Resource Management: No bookings could be retrieved when bookings were being created \[ID_31357\]

When bookings were being retrieved while bookings were being created, in some cases, no bookings would get retrieved.

From now on, the getResourcesMessage, the getResourcePoolsMessage and the getReservationsMessage will be allowed to skip the ResourceManager queue.

#### Protocols: Export rules would fail to parse values containing escaped XML characters \[ID_31362\]

When, in a protocol, values contained escaped XML characters (e.g. \<Description>Measurements \> 5\</Description>), the export rules would fail to parse those values and the generated DVE or Virtual Function protocol would only have some or none of the export rules applied.

#### Jobs app: Jobs would be retrieved using a query that contained an incorrect time filter \[ID_31365\]

When you opened the Jobs app, in some cases, the jobs would be retrieved using a query that contained an incorrect time filter.

#### ProfileManager module could get stuck during its initialization routine \[ID_31367\]

In some rare cases, the ProfileManager module could get stuck during its initialization routine.

#### Problem with SLElement when performing alarm level linking calculations \[ID_31404\]

In some cases, an error could occur in SLElement when performing alarm level linking calculations.

#### Alarm limit updates for column parameters would contain invalid data \[ID_31415\]

When alarm monitoring of type “rate” was used to monitor a column parameter, alarm limit change events would contain invalid data.

From now on, alarm limit change events will only be sent for standalone parameters and column parameters that are exported as standalone parameters in a virtual function or DVE child element.

#### DataMiner Cube - Correlation: Incorrect background color when creating or opening an analyzer or a correlation rule \[ID_31482\]

When, in the Correlation app, you created or opened an analyzer in the Analyzers tab or you created or opened a legacy correlation rule in the Correlation rules tab, the tab would incorrectly have a gray background.

#### DataMiner Cube: Problem when opening a specific page of a card \[ID_31490\]

In some cases, it would no longer be possible to open a specific page of a card.

#### DataMiner Cube: Incorrect display value could be displayed when discreet values and display values overlapped \[ID_31497\]

When the discreet values and the display values of a certain parameter overlapped, in some cases, an incorrect display value could be displayed.

#### Web Services API v1: Problem when using GetTableForParameterFiltered or GetTableForParameterSorted to retrieve part of a parameter table \[ID_31504\]

When the GetTableForParameterFiltered orGetTableForParameterSorted method was used to retrieve part of a parameter table by specifying a non-zero start index and a specific number of rows, in some cases, not all requested rows would be returned.

#### DataMiner Cube: Problem when the version history of a protocol included a version that was incorrectly based on itself \[ID_31508\]

In some cases, DataMiner Cube would become unresponsive when you changed the protocol of an element to a protocol of which the version history included a version that was incorrectly based on itself. From now on, a warning will appear when you try to change the protocol of a element to a protocol with an incorrect version history.

#### Problem when interpreting cell content wrapped in quotes while importing CSV files \[ID_31511\] \[ID_31522\]

When a CSV file was imported, up to now, SLDataMiner would incorrectly interpret cell content wrapped in quotes. For example, if quoted cell content contained a separator character, it would incorrectly be interpreted as a separator.

From now on, cell content will be parsed as follows:

- When no quotes are present, the cell will not have its spaces trimmed. When quotes are present around the cell's data, spaces will be trimmed outside of the quotes.

- Quotes inside a cell are expected to be escaped by another quote. Example: “A “”value”” inside a cell”.

- When there are quotes inside a cell, it is not allowed to have anything besides spaces outside of the quotes. The cell will be parsed as if no quotes are used and the first separator will close the cell. See the following example.

    | If you import... | cell 1 will contain... | cell 2 will contain... | cell 3 will contain... |
    |--------------------|------------------------|------------------------|------------------------|
    | “0,1m”, “0,5”m,    | 0,1m                   | “0                     | 5”m                    |

- Each imported object is expected to be a single element (besides the headers). Providing a string that contains a newline (\\n) for a property is possible, but carriage returns are removed (\\r) and tabs (\\t) are converted to spaces.

> [!NOTE]
> When you import a CSV file via DataMiner Cube, DataMiner Cube will send the imported data to the DataMiner Agent without performing any kind of preprocessing.

#### SLPort would leak a socket when executing an action of type 'open' via a socket that had already been opened \[ID_31512\]

When an action of type “open” was executed on a smart-serial interface via a socket that had already been opened, SLPort would leak a socket as well as a port in the ephemeral port range. This would eventually lead to a situation in which no more ports were available and no more sockets could be created. From now on, SLPort will close the socket when it receives an action of type “open” on a socket that is already open.

#### Dashboards app - GQI: Problem when migrating 'start from' queries \[ID_31544\]

When you opened a query that was created using an older GQI version, and that query was configured to start from another query, in some cases, it would incorrectly be migrated to the current GQI version.

Also, in some cases, a server query would not be translated correctly to a client query.

#### DataMiner Cube - Visual Overview: Child shapes of type alarm could lose data when scrolling through them \[ID_31547\]

When you scrolled through a large number of automatically generated shapes that represented alarms, in some cases, information displayed on those shapes would incorrectly disappear.

#### DataMiner Cube - Alarm Console: Problem when clearing an alarm while alarms were grouped by service \[ID_31549\]

When, in one of the tab pages in the Alarm Console, alarms were grouped by service, in some cases, an exception could be thrown when an alarm listed in more than one group was cleared.

#### DataMiner Cube - Data Display: Pressing a button inside a tree control would pass an incorrect row key \[ID_31554\]

When you pressed a button inside a tree control, in some cases, an incorrect row key would be passed to the command in question.

#### DataMiner Cube: Trend icons could stay hidden until Data Display was resized \[ID_31555\]

In Data Display, in some cases, trend icons next to parameters could incorrectly stay hidden until Data Display was resized.

#### DataMiner Cube: Parent view(s) of element, service or redundancy group created in one Cube session would be expanded in the Surveyor of another Cube session \[ID_31558\]

When, in a particular Cube session, a new element, service or redundancy group was created, in some cases, the Surveyor in other Cube session would incorrectly expand the parent view(s) of that new element, service or redundancy group.

#### Problem when run-time errors occurred in identically named process threads \[ID_31564\]

When, in a single process, multiple threads have a run-time error, those errors are grouped into one alarm tree. However, some threads have names that are not unique. When multiple identically named threads had a run-time error, all associated alarms would be generated simultaneously with the same value. This would cause SLElement to generate additional, incorrect alarms and SLWatchdog to not properly close those alarms.

#### Jobs app: Problem when changing the type of a field that was being used in a job filter \[ID_31565\]

When you changed the type of a custom section field that was being used a job filter, in some cases, that field would incorrectly still be used as a filter, even when it was not possible to use that type of field as a filter.

#### DataMiner Cube - Settings: Changes made in 'Alarm Console \> Card-specific' section would incorrectly not get applied \[ID_31566\]

In the *Alarm Console \> Card-specific* section of the *Settings* app, you can configure which alarm tabs should be shown on element, service and view cards. Up to now, when you made changes to the settings on that page, those changes would incorrectly not get applied.

#### DataMiner Cube - Service templates: Generated services missing from the list \[ID_31576\]

In some cases, the *Service Templates* app would incorrectly not list generated services of which the ID was identical to that of generated services found on other DataMiner Agents.

#### Problem with SLDataMiner when deleting an alarm template or a trend template \[ID_31583\]

In some rare cases, an error could occur in SLDataMiner when an alarm template or a trend template was deleted.

#### bypassProxy option would incorrectly not be taken into account in case of a websocket connection \[ID_31584\]

When the bypassproxy option had been set in a bus address field, this setting would incorrectly not be taken into account in case of a websocket connection.

From now on, when the bypassproxy option is specified for a websocket connection, the HTTP handshake to set up the websocket connection will not go through the configured proxy server.

#### Jobs app: Preset field values would not be filled in when a newly created job template was applied \[ID_31585\]

When you applied a newly created job template, in some cases, preset field values would incorrectly not be filled in.

#### DataMiner Cube: Problem when creating an element of type SNMPv3 when the UI language was not set to English \[ID_31588\]

When Cube’s UI language was set to a language other than English, an error could be thrown when you tried to create an element of type SNMPv3.

#### DataMiner Cube - Alarm cards: Services were not sorted naturally \[ID_31607\]

When you opened an alarm card, in some cases, the services affected by the alarm would incorrectly not be sorted naturally.

#### Jobs app: Job templates linked to a job domain were not deleted when the job domain was deleted \[ID_31616\]

In some cases, job templates linked to a job domain would incorrectly not be deleted when the job domain in question was deleted.

#### DataMiner Cube - Visual Overview: Embedded page would incorrectly not show DCF connections \[ID_31627\]

When you opened a visual overview with only one visible page containing an embedded hidden page with DCF connections, in some cases, those DCF connections would incorrectly not be shown.

#### DataMiner Cube - Sidebar: Some applications and modules would not be translated correctly when the UI language was changed \[ID_31633\]

In the *Apps* pane of Cube’s sidebar, some applications and modules would not be translated correctly when you changed the UI language.

#### Memory leak in SLProtocol when a fill array or fill column method passed along empty or null values \[ID_31634\]

In some cases, SLProtocol could leak memory when a fill array or fill column method was called on the protocol object passing along empty or null values for a cell.

#### Problem when SLWatchDog was copying log files to the Minidump folder \[ID_31652\]

When an error of type “thread problem” occurs, the contents of the C:\\Skyline DataMiner\\Logging folder is compressed into a zip file, which is then placed in the C:\\Skyline DataMiner\\Logging\\Minidump folder. During this action, in some cases, a lock inside the SLWatchdog process would accidentally delay the start-up of elements.

#### DataMiner Cube: Problem when refreshing a log file after scrolling down \[ID_31662\]

When, in the *Logging* section of *System Center*, you opened a log file, scrolled down beyond the first 50 KB of data, and then refreshed the file, the vertical scroll position would incorrectly not be restored.

#### DataMiner Cube - Settings: Turning an alarm tab of type 'sliding window' into a normal alarm tab would cause this change to be reverted as soon as another change was made to it \[ID_31664\]

When, in the group settings, you added an alarm tab of type “sliding window” and enforced it, as soon as a user had turned this tab into a normal alarm tab, the slightest change made to the tab afterwards would cause the tab to be changed back into a tab of type “sliding window”.

#### DataMiner Cube - Alarm Console: Problem when alarm tabs were grouped by property \[ID_31673\]

When an alarm tab was grouped by property, in some cases, DataMiner Cube could become unresponsive, especially on systems with high alarm traffic.

#### DataMiner Cube - Scheduler: Creating a task could fail on client machines with culture set to 'Finnish' \[ID_31712\]

In DataMiner Cube, creating a task in the Scheduler app could fail when the culture of the client machine was set to “Finnish”.

#### DataMiner Cube: Element, service and view cards on a saved workspace would not show the correct page when the workspace was opened \[ID_31718\]

When you opened a saved workspace, in some cases, open element, service or view cards would not show the correct page.

#### DataMiner Cube - EPM: Zoom buttons on trend graph popup would incorrectly be displayed twice \[ID_31719\]

When you opened an EPM trend graph popup from a KPI on an EPM card, in some cases, the zoom buttons would incorrectly be displayed twice.

#### Dashboards app: Problem when listing the parameters of a selected element \[ID_31737\]

When, in a dashboard, you selected an element, in some cases, an “Index was outside the bounds of the array” error could be thrown when a linked parameter component tried to list all parameters of the element you selected.

#### DataMiner Cube - Trending: Problem when opening a histogram \[ID_31745\]

In some cases, an exception could be thrown when you opened a histogram.

#### SLAnalytics - Automatic incident tracking: Problem when trying to parse invalid element IDs \[ID_31820\]

When a view contained invalid element IDs, up to now, an exception would be thrown. From now on, when SLAnalytics was not able to parse an element ID, an error will be added to the SLAnalytics log file.
