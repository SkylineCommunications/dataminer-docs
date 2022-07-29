# I-DOCSIS branch 6.1.0

## New features

#### CCAP decoupled from Generic DOCSIS CM Collector connector \[ID_32627\]

To improve performance, the CCAP connection and all associated logic have been removed from the Generic DOCSIS CM Collector connector. Parameters that were filled in based on CCAP data have also been removed.

In addition, a number of new parameters have been introduced:

- *SNMP Interval* and *Virtual Interval*: These parameters allow you to configure the frequency at which the different SNMP and virtual are polled, respectively.

- Virtual Execution Time: This parameter shows how long it takes for a command to be exe­cuted on the virtual interface.

#### Improvements related to the decoupling of CCAPs from the CM collector \[ID_32630\]

To further support the removal of CCAPs from the CM collector, the CM Overview, CM US QAM, CM DS QAM, QAM US and QAM DS tables have been adjusted to reflect the fact that CCAPs have been decoupled from the CM collector.

In addition, in the Arris E6000 CCAP Platform, Casa Systems CCAP Platform, CISCO CBR-8 CCAP Platform and Huawei 5688-5800 CCAP Platform connectors, the following new parameters have been introduced:

- *SNMP Fast Interval*, *SNMP Slow Interval* and *Virtual Interval*: These parameters allow you to configure the frequency of fast and slow polling for the SNMP interface and the polling fre­quency for the virtual interface, respectively.

- Various interface status parameters, such as *SNMP Fast Status*, *SNMP Fast Last Update* and *SNMP Fast Execution Time*, which allow you to monitor how long it takes for the connector to process commands for each interface.

## Changes

### Enhancements

#### Multiple I-DOCSIS front-end enhancements \[ID_32629\]

Multiple enhancements have been implemented to the I-DOCSIS front end:

- A message buffer was implemented to better handle multiple requests from the CCAPs and to allow requests to be handled per element.

- To improve performance, InterApp calls are now used for communication between different DataMiner components.

- Multiple tables have been adjusted to reflect the fact that CCAP data has been decoupled from the CM collectors.

- Collector registration has been adjusted. Now the IDs for CCAP and CM collector are both placed in the table, in the format CCAPDataMinerID/CCAPElementID\|CMCollectorData­MinerID/CMCollectorElementID.

#### Multiple I-DOCSIS back-end enhancements \[ID_32631\]

Multiple enhancements have been implemented to the I-DOCSIS back end:

- A message buffer was implemented to better handle multiple requests from the CCAPs and to allow requests to be handled per element.

- To improve performance, InterApp calls are now used for communication between different DataMiner components.

- Multiple tables have been adjusted to reflect the fact that CCAP data has been decoupled from the CM collectors.

- Collector registration has been adjusted. Now the IDs for CCAP and CM collector are both placed in the table, in the format CCAPDataMinerID/CCAPElementID\|CMCollectorData­MinerID/CMCollectorElementID.

- A back-end registration table has been added, which makes it possible to map view tables.

#### New messaging Automation scripts using InterApp communication \[ID_32632\]

The existing EPM messaging logic using Correlation and Automation has been replaced with 3 new Automation scripts that use InterApp communication:

- *CcapToEpmFe*: This script is triggered by a CCAP and sends an InterApp message to the front-end element.

- *EpmFeToEpmBe*: This script is triggered by the front end and sends an InterApp message to the back-end element.

- *EpmBeToCcapPair*: This script is triggered by the back end and sends an InterApp message to one or more collector pairs (CCAP/CM collector).

### Fixes

\-

# D-DOCSIS branch 6.1.0

## New features

#### "Putty" renamed to "Terminal" and edit button added \[ID_32298\]

In the EPM user interface, the "Putty" label has been changed to "Terminal". In addition, a pencil button has been added that allows you to access the DITT Registrations table and edit rows.

#### RPD status trending \[ID_32536\]

All known RPD status information is now added to the relevant table as discrete values, so that it is possible to activate trending on this information and view historical data. The status information has also been added to the RPD dashboard as a trended parameter.

#### Automatic updates of EPM tables in Visual Overview \[ID_32537\]

All EPM tables shown in Visual Overview are now updated every 30 seconds so that they continuously show the most recent data.

#### New EPM configuration script \[ID_32538\]

A new script has been created that configures DataMiner with front-end element data, so that it does not need to perform a search of all elements to find the front-end manager. The EPM front end will start the script on startup to ensure that the front end is configured correctly.

## Changes

### Enhancements

#### Filters can no longer be collapsed and expanded \[ID_32045\]

To prevent possible issues, the filters on the left side of the EPM UI can no longer be collapsed and expanded. They will now always be displayed.

#### Improved cable modem contextuality for core leaf and node leaf entities \[ID_32342\]

The core leaf and node leaf entities in the EPM topology will now have a direct relation to the lowest entities in the topology, the cable modems. Previously, these entities inherited the cable modems from the attached hub, but now only the cable modems that have a valid relation to them will be shown. This allows more contextuality and aggregated KPIs from the cable modems to the core lead and node leaf.

#### Visual overview enhancements \[ID_32343\]

The following enhancements were implemented in the EPM visual overview:

- The filter names on the CM, RPD Association, and Utilization pages have been adjusted to match column names, so that it is clearer which filter filters which column.

- The CCAP Overview and RPD Overview Sessions links now lead to the L2TP page of the respective CCAP to show L2TP sessions, instead of the RPD sessions page.

- Additional filters have been introduced for the Status column on the RPD Association page. These are now the available filters: Online, Offline, GcpRedirected, Configured, and Other.

- It is no longer possible to navigate to the same device page from the device, as this could cause loading issues. These breadcrumbs now only allow you to copy the name of the cur­rent device page.

#### Hub child shapes now added based on custom property \[ID_32711\]

In the hub visual overview, when a child shape is added below the hub, a custom property will now be used to determine which device it is. This way elements can be shown more dynamically than if this is done based on the device name configured by the user.

#### Loading banner removed from EPM visual overviews \[ID_32712\]

The loading banner has been removed from the EPM visual overviews, as it continued to be displayed all the time while data was being filtered in the background.

#### CM thresholds improvement \[ID_32710\]

On the *Configuration* > *Settings* page of the CISCO CBR-8 CCAP Platform Collector and the Cox CBR-8 Platform D-DOCSIS connectors, a new *Apply Thresholds* button is available that allows you to apply any changes you have implemented to the threshold settings. When you do so, the related KPIs will immediately be updated, so that you do not have to wait until the next polling cycle.

In addition, the Cable Modem Timing Offset calculation has been adjusted so that the values are more specific to the interface they relate to.

### Fixes

#### Cox Smart PHY: Interface State not initialized \[ID_32344\]

When the Cox Smart PHY element or the DMA restarted, it could occur that the Interface State was not initialized, which could prevent the element from polling.

#### Node utilization calculation excluded virtual channels \[ID_32345\]

When node utilization was calculated, virtual channels were filtered out while these actually should be included. Now all available channel information is used in the calculation.

#### IPv6 addresses not displayed correctly in L2TP Sessions tables \[ID_32477\]

In the L2TP Sessions tables, it could occur that IPv6 addresses were not displayed correctly.

#### Discrepancy between number of RPDs served and RPD Association Table \[ID_32535\]

Up to now, there could be a discrepancy between the number of RPDs served and the information in the RPD Association Table. Now the RPD-related KPIs at node leaf level will be more precise and match what is shown in the RPD Association Table, so that it will show a minimum of rows equal to the number of RPDs served.
