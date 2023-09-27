---
uid: General_Main_Release_10.1.0_CU13
---

# General Main Release 10.1.0 CU13

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLElement: Enhanced performance when resolving table relationships \[ID_32176\]

Due to a number of enhancements, overall performance of SLElement has increased when resolving table relationships.

#### DataMiner Cube: Enhanced performance when reloading protocols after a protocol update \[ID_32315\]

Due to a number of enhancements, overall performance has increased when reloading protocols after a protocol update.

#### Filtered subscriptions will now be processed similarly to non-filtered subscriptions \[ID_32399\]

Filtered subscriptions will now be processed similarly to non-filtered subscription, regardless of whether the element in question is hosted on the local DMA or a remote DMA.

#### DataMiner Cube - Users/Groups: Permissions needed to edit group membership \[ID_32456\]

When opening their user card, from now on, users will only be able to edit group membership if they have the following permissions:

- Administrator permission, or
- Limited administrator permission as well as “Edit all groups” or “Edit own groups” permission

> [!NOTE]
> Users only need to have the “Edit own groups” permission to be able to configure a group of which they are a member.

#### Dashboards app - Parameter page component: WebSocket subscriptions will now be used for parameter tables when possible \[ID_32476\]

When a parameter table is being displayed in a parameter page component, when possible, the underlying table component will now make use of WebSocket subscriptions.

#### DataMiner backups will now by default also include SSL certificates and EPMConfig.xml files \[ID_32504\]

Full backups and configuration backups will now by default also include the EPMConfig.xml files and all certificates used by protocols for encrypted communication with devices.

#### DataMiner Cube - Correlation: Using hidden elements when creating correlation rules \[ID_32510\]

When creating a correlation rule in the Correlation app, it is now possible to use a hidden element in both the *Alarm Filter* section and the *Rule Condition* section.

#### Enhanced performance when stopping SNMP elements \[ID_32523\]

Due to a number of enhancements, overall performance has increased when stopping SNMP elements.

#### Dashboards app - Parameter feed: 'Selected only' toggle button has been removed \[ID_32541\]

Up to now, a parameter feed had a *Selected only* toggle button that allowed you to show or hide items that were not selected. Now, this toggle button has been removed.

Also, when a dashboard is loaded with an initial selection (either configured or in the URL), the selected items will now always appear at the top of the list.

#### DataMiner Cube - Data Display: Row filter will now be shown when opening the alarm template, trend template or information template for a particular parameter table row \[ID_32555\]

When, in Data Display, you drill down to a specific row of a parameter table, you can open the alarm template, trend template or information template for that specific row. From now on, if a filter was configured for the table row in question, it will also be shown in the UI.

#### DataMiner Cube - Automation: SaveAutomationScriptXmlMessage will now be used when importing, saving and updating Automation scripts \[ID_32557\]

Up to now, when an Automation script was imported, the file would not be processed in the same way as when an Automation script was saved or updated. From now on, the same SaveAutomationScriptXmlMessage will be used when importing, saving and updating Automation scripts.

#### Protocols: Allow for different remote element sources in view table columns \[ID_32579\]

When setting up remote columns, up to now, all columns had to refer to the same parameter containing a list of remote elements (e.g. “view=:x:y:z”, where x is the ID of the parameter containing the remote element IDs). From now on, it is possible to have two sets of elements referenced by different columns within the same view table.

In the following example, parameters 201 and 301 each contain a list of remote elements, and both can be used within the same view table (in different ColumnOption tags).

```xml
<ColumnOption idx="3" pid="2004" type="retrieved" options=";view=:201:1000:3"/>
<ColumnOption idx="4" pid="2005" type="retrieved" options=";view=:301:1000:4"/>
```

#### Service & Resource Management: Updated exceptions thrown when the time range of a child ReservationInstance or child ReservationDefinition is invalid \[ID_32581\]

The following exception messages have been enhanced.

##### Exception thrown when the time range of a child ReservationInstance is invalid

This message now includes the ID, the name and the time range of both the parent and the child.

```txt
The TimeRange of the child is not within the boundaries of the parent ReservationInstance (Child: '{Child Name}' ({Child ID}) has range '{Child Range}' & Parent: '{Parent Name}' ({Parent ID}) has range '{Parent Range}')
```

##### Exception thrown when the time range of a child ReservationDefinition is invalid

This message now includes the ID, the name and the time range of both the parent and the child. For the child, the offset has now also been added.

```txt
The timing of the child is not within the boundaries of the parent ReservationDefinition (Child: '{Child Name}' ({Child ID}) has timing with duration '{Child Timing Duration}' and offset '{Child offset}' & Parent: '{Parent Name}' ({Parent ID}) has timing with duration '{Parent Timing Duration}')
```

#### Hanging threads in SLNet will now be logged in SLHangingCalls.txt \[ID_32582\]

Up to now, hanging threads in SLNet would be logged in the SLNet.txt file. From now on, these will be logged in the new SLHangingCalls.txt file instead (without the stack trace).

This file will by default be refreshed every 5 minutes.

#### Enhanced performance when uploading DataMiner upgrade packages \[ID_32597\]

Due to a number of enhancements, overall performance has increased when uploading DataMiner upgrade packages.

#### DataMiner Cube - Spectrum analysis: Additional logging to help pinpoint monitor failures \[ID_32605\]

When, on a spectrum element card, you select *View buffer* in the *monitors* tab of the ribbon, the selection boxes should contain all available monitor buffers.

In DataMiner Cube, additional logging is now available to help pinpoint monitor execution failures by providing information about the monitor buffers that will be shown based on the backend buffer response.

#### DataMiner Cube: Information templates will only show the read parameter in case of a toggle button \[ID_32610\]

Up to now, for a write parameter configured as a toggle button, an information template would show two parameters: a read parameter and a write parameter. From now on, toggle buttons will be treated as regular parameters. In an information template, only the read parameter (of type discreet) will be shown.

#### Enhanced performance of the interprocess communication between SLDataGateway and SLAnalytics \[ID_32653\] \[ID_32709\]

Due to a number of enhancements, overall performance of the interprocess communication between SLDataGateway and SLAnalytics has increased.

#### Server processes will now use InvariantCulture \[ID_32665\] \[ID_32912\]

Up to now, server processes like SLNet used the default system locale. If this locale was a language other than English, all internal .NET Framework exception stack traces and log messages would be generated in that language, making it harder to interpret or analyze them. From now on, the server processes will now force their threads to use the CultureInvariant culture by default.

> [!NOTE]
> SLManagedAutomation and SLManagedScripting will continue to use the default system locale.

#### DataMiner Cube - Automation: Specifying an offset value will now be optional in case of a Set action \[ID_32743\]

When, in an Automation script, you configured a Set action for which an offset value could be specified, up to now, it was mandatory to specify that offset value. From now on, specifying an offset value will be optional. Either select “with value offset” and enter a value, or select “without value offset”.

Default: “without value offset”

### Fixes

#### SNMP forwarding: Problem when deleting an SNMP manager and immediately creating an identical one \[ID_32406\]

When you deleted an SNMP manager of type SNMPv3 and then immediately created an identical one, in some rare cases, an exception of type “Float Invalid Operation” would be thrown.

#### DataMiner Cube - Services app: Expand/collapse button in front of a service profile definition would disappear when you expanded or collapsed the service profile definition node \[ID_32439\]

When, in the Profiles tab of the Services app, you expanded or collapsed a service profile definition node in the tree on the left, the expand/collapse button in front of that service profile definition would incorrectly disappear. In other words, there was no way to reverse the expand/collapse action.

#### DataMiner Cube - Data Display: Not possible to open the alarm template or trend template of a parameter that was not trended \[ID_32449\]

When, in Data Display, you drill down to a parameter of an element, you can configure the alarm and trend templates for that specific parameter. When you tried to configure the alarm template or the trend template of a parameter that can be trended but wasn’t, up to now, it would incorrectly not be possible to open the alarm template or trend template of that specific parameter.

#### DataMiner Cube - Profiles app: Problem when trying to retrieve mediation snippets and service profiles on a system without ElasticSearch database \[ID_32488\] \[ID_32539\]

When you tried to open the Profiles app on a DataMiner System with a Service Manager license that did not have an ElasticSearch database, the app would fail to initialize when attempting to retrieve mediation snippets and service profiles. From now on, the presence of an ElasticSearch database will be checked before trying to retrieve mediation snippets and service profiles.

> [!NOTE]
> On systems without an ElasticSearch database, it is not possible to configure mediation snippets.

#### Stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements \[ID_32498\]

Up to now, in some cases, stopping an SNMPv3 element could have a negative impact on the overall performance of other SNMPv3 elements.

#### Problem when trying to delete a protocol \[ID_32522\]

In some cases, an error could occur when you tried to delete a protocol.

#### DataMiner Cube - Visual Overview: Problem with initial page selection \[ID_32527\]

When you assign a Visio drawing to a view or a service, you can specify a default page. This initial page selection would no longer work.

Also, when the *How to show element card Data pages* setting was set to “Show in drop-down box”, initial page selection would no longer work.

#### SLProtocol would leak memory when using a 'change after response' trigger \[ID_32572\]

When using a “change after response” trigger, SLProtocol would leak memory on every incoming response. See the following example.

```xml
<Trigger id="2">
  <On id="1">parameter</On>
  <Time>change after response</Time>
  <Type>action</Type>
  <Content>
    <Id>2</Id>
  </Content>
</Trigger>
```

#### Elasticsearch: Problem when using a filter that checked whether a string was empty \[ID_32586\]

In some cases, Elasticsearch would return an incorrect number of records when a query contained a filter that checked whether a string was empty in combination with other filters.

#### Memory leak in SLNet caused by GQI queries \[ID_32589\]

In DataMiner versions up to and including 10.1.12, GQI queries would cause a memory leak in SLNet.

#### Miscellaneous small fixes \[ID_32655\]

A number of miscellaneous, small fixes have been made.

#### Serial protocols: Length check would incorrectly take into account the data before the header \[ID_32669\]

Up to now, when a payload with data before the header was received (e.g. aaaa\<header>payloadwithfixedlength), the data before the header would correctly be stripped off before forwarding the payload to the protocol, but the length check would incorrectly take that data into account.

#### SLNetClientTest: Problems with 'Agent Connections' window \[ID_32679\]

When, in the SLNetClientTest tool, you opened the *Agent Connections* window (by selecting *Diagnostics \> Connections \> View DMA Connections*),

- Agents could incorrectly display a “Disconnected” state while actually being connected.

- The “Calls From” column could incorrectly display “(not available)”.

#### DataMiner Cube - Asset Manager: UI could become unresponsive when the database configuration was being retrieved \[ID_32766\]

When, in DataMiner Cube, you opened the Asset Manager app, in some cases, the UI could become unresponsive when the database configuration was being retrieved.
