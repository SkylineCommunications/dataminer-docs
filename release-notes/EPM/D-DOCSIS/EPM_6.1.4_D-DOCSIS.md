---
uid: EPM_6.1.4_D-DOCSIS
---

# EPM 6.1.4 D-DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Fan tray and power supply monitoring added to CCAP visual [ID_33649]

Monitoring of the fan trays and power supply modules has been added to the CCAP visual. The number of power supply modules on the visual will match the number of installed power supplies in that CCAP.

#### 'All' filter option added to table drop-down filters [ID_33739]

An *All* filter option has been added to all table drop-down filters, so that users can clear specific filters without using the *Clear* button, which clears all active filters.

#### COX CBR-8 Platform D-DOCSIS: Linecard Redundancy Status added [ID_36072]

The COX CBR-8 Platform D-DOCSIS connector will now display the Linecard Redundancy Status, so that the failover state of the device can be taken into account. It is possible to configure alarm monitoring on this parameter.

#### Option to refresh data on RPD and Node Segment Overview pages [ID_36074]

On all RPD and Node Segment Overview pages, you can now refresh the data and request all cable modem data related to the selected RPD. There is also a status indicator, and the time when the report was last requested is displayed.

#### Description column added to Spine Interfaces pages [ID_36076]

On the *Interfaces* page of any Spine, a new *Description* column has been added.

## Changes

### Enhancements

#### CCAP link added to RPD and Node Segment visuals [ID_33645]

A link to the CCAP has been added to the *RPD* and *Node Segment* visuals. In addition, the device symbols in other navigation links throughout the EPM Solution have been adjusted.

#### Improved CM manufacturer info [ID_33646]

The OUI file from which the connectors read the cable modem (CM) manufacturer information has been updated. As this file now has new entries, all CMs will now have a manufacturer associated with them, including those where the manufacturer was previously indicated as *Unknown*.

#### Uniform MAC address throughout EPM Solution [ID_33710]

The MAC address format throughout the EPM Solution and across the different collectors has been made more uniform. The octets in the MAC address are now always separated by a colon. This way, you can now copy a MAC address and search for it throughout EPM, since its format will always be the same.

#### RPD Association page removed from RPD and Node Segment visuals [ID_33736]

The *RPD Association* page has been removed from the *RPD* and *Node Segment* visuals.

#### MLD status removed from Core Leaf visuals [ID_33737]

The MLD status has been removed from the *Core Leaf* visuals.

#### Improved CM MAC search parsing [ID_33738]

CM MAC search parsing has been improved to account for MACs separated by hyphens or using any combination of colon, period, or hyphen to separate the bytes.

#### Removed unnecessary table headers [ID_33894]

Table headers that were unnecessary or not useful to the user, such as average or percent values that disregard the calculation weight, have been removed.

#### Dashboards: "Last Updated" changed to "Last Overall System Update" [ID_33895]

To make it more clear where the data in EPM dashboards comes from, the *Last Updated* label in the dashboards has been changed to *Last Overall System Update*.

#### Topology page removed from Hub visual overview [ID_33896]

To prevent issues where too many RPAs are present and it becomes difficult to show them, the *Topology* page has been removed from the Hub visual overview.

#### Parameter access levels adjusted [ID_33897]

The access levels of write parameters in the EPM connectors have been adjusted so that regular operators will not have access to them. The write parameters now require access level 1, whereas operators only have access level 3.

#### Additional status information in visual overview [ID_34069]

<!-- For fix part of RN, see fixes -->

In the *RPD Details*, a link has been added to the *Partial OFDM CM* KPI. In addition, new columns with the *DS Service Status*, *US Service Status*, and *OFDM Status* have been added to the CM tables in visual overview.

#### Skyline CCAP Platform EPM visual overview improvements [ID_34070]

On the *CCAP/CM* page of the *Skyline CCAP Platform* EPM visual overview, a new status filter box has been added. It allows you to select the option *All* to clear the filter, and the option *Not Operational* to filter out all CMs that are considered offline. In addition, links on the *CCAP/Overview* page have been updated to filter on status instead of MAC state.

#### Performance improvement through SLElement utilization improvements [ID_34309]

To improve performance, several changes have been implemented to reduce the amount of memory used by the SLElement process. As a result of these, the solution will load faster and be more stable.

These changes include:

- The removal of all unnecessary monitored parameters.
- More efficient buffer cleanup logic.
- Removal of the *Counters History* column in the *CmUpstream* table of the Cox CBR-8 Platform D-DOCSIS connector.

#### MLD status alarm monitoring removed from Core Leaf [ID_35132]

MLD status alarm monitoring is now disabled on Core Leaf level.

#### CM Upstream table no longer displayed [ID_36018]

To improve performance, the CM Upstream table will no longer be displayed.

#### Enhanced EPM messaging [ID_36019]

To increase scalability in systems with a larger number of elements, EPM D-DOCSIS will no longer handle ID requests ad hoc. Instead it will perform this logic based on a timer and using batches of files, so that it can run the logic less frequently and update the entire system more quickly.

#### Improved performance – Workflow Managers no longer need to send messages to front end [ID_36067]

To improve performance, messages no longer need to be sent from the Workflow Managers to the EPM front end.

#### Remote view filtering in Skyline CCAP Platform EPM connector [ID_36068]

To improve view lookup speed as well as the overall performance of the system, the remote view filtering feature has been integrated in the Skyline CCAP Platform EPM connector.

#### Skyline CCAP Platform WM: Improved handling of Kafka Topics [ID_36069]

The Skyline CCAP Platform WM element will now only read a Kafka Topic file once and service all the collectors it manages. This will increase the efficiency of data handling and improve performance.

#### CM level removed [ID_36070]

To improve stability and scalability, the CM level (i.e. the CPE level) has been removed from the EPM D-DOCSIS Solution. Relations are still established for aggregation, but they are gathered at the collector level instead of at the CM level.

#### New Kafka Topic with Cable Modem data [ID_36073]

A new Kafka Topic with data specific to the Cable Modem has been added to the EPM D-DOCSIS Solution. The new data points will be used for new KPIs at the CM, RPD, and Node Segment level.

### Fixes

#### Ceeview link on RPD Topology page not working [ID_33612]

On the *RPD Topology* page, it could occur that the Ceeview link did not function correctly.

#### Market utilization filter issue [ID_33647]

In the *Utilization* tab of the Market topology level, when you filtered the DOCSIS QAM and OFDM upstream and downstream utilization using either the "\>=" or the "\<=" filter, it could occur that the other filter continued to be applied in the background, so that the two filters were applied to the table at the same time. Now when a specific filter is selected, only that filter is applied to the table, even if the alternative filter has a value filled in.

#### Temperature graph in RPD dashboard did not show selected time period [ID_33648]

In the RPD dashboard, if a different time period was selected, the graph for the *Temperature* component continued to display the values for the last 24 hours.

#### Incorrect interfaces status in RPA visual overview [ID_33898]

In the visual overview of an RPA element, it could occur that the RPA interfaces status was incorrect.

#### Incorrect OFDM Status [ID_34069]

<!-- For enhancement part of RN, see enhancements -->

Up to now, it could occur that the *OFDM Status* was not correct, as the logic did not properly use the *CM Impaired Channels* table to find out if an impaired channel was an OFDM or QAM channel. The logic has been adjusted. As part of this, the "Active" OFDM status no longer exists, and the "OK" and "Partial" status have been introduced to identify CMs without any impaired OFDM channels and CMs with at least one impaired OFDM channel, respectively.

#### Incorrect US ATDMA info in RPD details [ID_34714]

Up to now, the US ATDMA section (previously known as the US QAM section) included calculations of OFDMA upstream channels in the impaired channels table, leading to incorrect counts and percentages. The logic has now been adjusted to only include ATDMA channels, and the information templates have also been updated to reflect this change.

#### Problem with table-cell navigation in Relation Name column [ID_34715]

In the Interfaces tables for all devices, table-cell navigation in the Relation Name column did not work as desired. Now the System Type and System Name are properly separated in the Visual Overview configuration, so that navigation is possible to all EPM levels.

#### PIM neighbors data not correctly retrieved [ID_35028]

In some cases, it could occur that PIM neighbors data was not correctly retrieved. This happened specifically when the device had been running for less than 24 hours. This caused the PIM Node Leaf table to be empty and the PIM Status to be set to "Fail".

#### Hub list in Market visual overview not shown completely [ID_35029]

In the Market visual overview, if there were several hubs under a market, it could occur that the hub list was cut off at the bottom.

#### Incorrect offline RPDs metric on Node Leaf level [ID_35162]

When there were offline RPDs associated with a node leaf, the percentage calculation for offline RPDs in the node leaf visual overview could be incorrect. The relevant aggregation operations have been reviewed to prevent this, and EPM relations have been added on connector level to make the calculations more efficient.

#### Restarting Skyline CCAP Platform WM element could cause corrupted file [ID_36066]

When the Skyline CCAP Platform WM element was restarted while it was writing a file, the file could get corrupted, which would break subsequent workflows.

#### Generic Kafka Consumer: Incorrect timestamp in file name caused files to be ignored by Workflow Manager [ID_36071]

If not much data was retrieved during a polling cycle, it could occur that the timestamp in a file name was older than the actual file creation time. This could cause the Workflow Manager to ignore certain files in some circumstances. To prevent this, the timestamps will now align with the file creation time.

#### Negative longitude/latitude value not shown for Cox CBR 8 on Node Segments page [ID_36079]

Previously, if a longitude or latitude value for a CBR 8 was negative, this was displayed as N/A on the Node Segments page. Now all values will be shown, even negative ones.

#### Smart PHY issue causing outdated data to be displayed [ID_36080]

In some cases, a problem with Smart PHY could cause no new file to be exported, so that outdated data were displayed in the system.

#### CBR 8 data retrieved through CLI command not visualized correctly [ID_36081]

It could occur that the information in the CBR 8 that was retrieved through the CLI command was not visualized correctly, so that users had to manually update the data in order to see the correct information.
