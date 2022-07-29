# I-DOCSIS branch 6.0.1

## New features

#### Integration of QAM US/DS Channels tables further refined \[ID_31433\]

The integration of the QAM US/DS Channels tables has been refined, so that channel parameter values are not necessarily immediately based on the first occurrence within the respective CM QAM US/DS Channels tables.

Depending on their operational meaning, parameters will be determined as follows:

- First Valid Occurrence: The first occurrence of valid data for the given parameter for the channel is taken from the source table. If no valid value found, N/A is displayed instead.

- Average: The average of valid values for the given parameter is calculated from the source table. If no valid value found, N/A is displayed instead.

- Contextual Calculation: The value is calculated contextually for the given table. For exam­ple, the *NMTER Alarm Status* will be determined based on the NMTER value and not based on the first occurrence of the channel in the source table.

#### Reflection Distance Threshold removed \[ID_31436\]

The *Reflection Distance Threshold* is now no longer displayed or taken into account. The *Reflection Distance Alarm Status* in the US Channels tables is also no longer available.

#### UI improvements \[ID_31438\]

A number of changes have been implemented to the EPM user interface.

Cable Modem adjustments:

- A new parameter *DS Rx Power Status* is now available.

- The *DS Power Status* parameter has been renamed to *US Tx Power Status*. The tooltip of this parameter has also been enhanced.

- The *US Power Status* parameter has been renamed to *US Rx Power Status*. The tooltip of this parameter has also been enhanced.

- *Group Delay and Reflection Distance* has been renamed to *Group Delay or Reflection Dis­tance*.

Adjustments related to CM QAM US Channels and QAM US Channels:

- The *TX US Power* parameter has been renamed to *US Tx Power*. The tooltip of this parame­ter has also been enhanced.

- The *Rx Power* parameter has been renamed to *US Rx Power*. The tooltip of this parameter has also been enhanced.

- The *US Time Offset* parameter has been added.

Adjustments related to CM QAM DS Channels and QAM DS Channels:

- The *Rx Power* parameter has been renamed to *DS Rx Power*. The tooltip of this parameter has also been enhanced.

#### Generic DOCSIS CM Collector improvements \[ID_31460\]

Several improvements have been implemented in the Generic DOCSIS CM Collector connector:

- On the *Threshold Settings* page, similar thresholds are now grouped together.

- Existing threshold parameters have been repurposed with adjusted names, tooltips, ranges and default values.

- The following new threshold parameters have been added: *Downstream Channel Minimum *and *Downstream Channel Maximum Rx Power Level*.

- An apply button has been added to all threshold groups for ad-hoc processing of the thresholds.

- New threshold execution settings are available, which allow the user to control how fre­quently the threshold logic is executed.

- A new parameter, *DS Rx Power Status*, has been added, and the descriptions and tooltips of other status parameters within the CM table have been adjusted.

- A new *US Time Offset* parameter has been added to the US Channels tables.

- The descriptions and tooltips of parameters in the QAM Channels table have been adjusted.

- A *General* page has been added, with basic information about how many entities are man­aged within the connector. This includes an *Apply* button to update these parameters ad hoc.

## Changes

### Enhancements

#### CM-level parameters in Generic DOCSIS CM Collector no longer available for monitoring \[ID_31453\]

As parameters at CM level in the Generic DOCSIS CM Collector should not be monitored, these are now no longer available for monitoring. This includes the CM US QAM and CM DS QAM tables.

#### Directory path adjustments \[ID_31463\]

All directory paths used in the Skyline EPM Platform element will now point to the parent folder containing the relevant subfolder (e.g. DOCSIS, GPON, etc.), instead of directly to the subfolder.

### Fixes

#### Negative infinity values in CM QAM and QAM tables \[ID_31439\]

In some cases, negative infinity values could occur in CM QAM and QAM tables.

#### Incorrect ratio in CM QAM US Channel table + old rows not removed \[ID_31477\]

In some cases, it could occur that the corrected ratio and the uncorrected ratio in the CM QAM US Channel table were incorrectly displayed as zero. In addition, it could occur that old rows in the QAM US Channels table were not removed.

# D-DOCSIS branch 6.0.1

## New features

#### Linked alarms for CISCO CBR-8 CCAP Platform Collector, Cisco Manager CIN Platform and Juniper Networks Manager CIN Platform displayed in Alarm Console tab EPM card \[ID_31430\] \[ID_31431\] \[ID_31432\]

When you navigate to an element through the topology and open an EPM card, all relevant alarms that are only present on the element will now be available in the Alarm Console tab of the EPM card. This way you no longer need to go through the Surveyor or through the Alarm Console at the bottom of the screen to see if the element in the EPM topology has any alarms.

This has been done for the CISCO CBR-8 CCAP Platform Collector, Cisco Manager CIN Platform and Juniper Networks Manager CIN Platform connectors, by attaching the System Type and System Name properties to the alarm at connector level.

#### KAFKA topics integration \[ID_31440\]

KAFKA topics have been integrated into EPM D-DOCSIS.

The following three connectors are included in this integration: Generic KAFKA Consumer, Skyline CCAP platform WM and COX CBR-8 Platform D-DOCSIS. The Skyline CCAP platform WM is the intermediary between the Generic KAFKA Consumer and the COX CBR8 Platform

The WM receives requests from the CBR8 platform asking for specific topic data. The WM will then search for the requested data in the files that are created by the Generic KAFKA Consumer. After parsing the data, it creates the provisioning files and sends a response to the CBR8 platform.

In the WM element, a new *Topics* page has been added, where you can find the *Topics Consumption Buffer* table. A new *Topic Settings* page is also available, where you can check and configure topic settings.

The necessary Automation Scripts and Correlation Rules have also been created to support the topic data handling workflow.

#### New MAC State Not Online filter option \[ID_31454\]

On all CM pages, the *MAC State* filter box now has a new *Not Online* option. This option shows all CMs in a MAC state that do not contain the keyword "online". You can also apply this filter by clicking *% CM OFFLINE* on the *Overview* page where applicable.

## Changes

### Enhancements

#### Links added in D-DOCSIS EPM Visual Overview \[ID_31441\]

In the D-DOCSIS EPM Visual Overview, links have now been added to several fields where these were previously missing: CCAP, RPD, Fiber Node, Managing RPD, and various items listed under Connectivity Details.

#### "Connected RPDs" links improved \[ID_31456\]

The *Connected RPDs* links on the Topology pages have been adjusted so that their alarm color now reflects the highest severity present in the *RPD Overview* table. Previously, the alarm color was linked to the Node Leaf element instead.

In addition, these links will now also allow you to navigate to the RPD association table of the corresponding Node Leaf on the Topology page.

#### Improved table filters \[ID_31457\]

Table filters will now be applied server side whenever possible to ensure that all retrieved data is filtered correctly. Any filters that are still applied client side are marked with the "\[Client\]" label to make this clear to the user. Client-side filters are only applied on partial views (i.e. the first 100 rows) of a table, or on each page of the paginated search result.

For the most accurate results, we recommend to first apply server-side filters, and then to refine those results with client-side filters.

#### Navigation to child levels in Hub Overview improved \[ID_31458\]

Navigation to child elements in the Hub Overview will now always keep the user within the EPM environment.

In addition, to allow a more generic approach, these child elements are now filtered by means of the “ENTITY TYPE” property instead of the protocol name.

### Fixes

#### Filtering on numeric column not working correctly \[ID_31451\]

In a DataMiner System using DataMiner 10.0.12 or higher, it could occur that filtering an EPM Visual Overview on a numeric column did not work correctly.

#### EPM Visual Overview not loaded correctly when opening multiple cards in non-tab Cube layout \[ID_31452\]

When a Cube layout other than the tab layout was used, if you made more than one topology selection, it could occur that the Visual Overview on the corresponding EPM cards was not loaded correctly.

#### Incorrect filter in CM table \[ID_31454\]

In some cases, a filtering issue could cause CMs to be shown incorrectly in the CM table.

#### Missing topology links after opening element \[ID_31455\]

In some cases, after a new element card was opened, it could occur that the Topology page was not loaded correctly so that some links were missing.

#### Incorrect links in System Info section \[ID_31458\]

In the System Info section, it could occur that some links did not work correctly.

#### Missing chassis images for spine elements \[ID_31459\]

When you navigated to a spine element in the Quick Topology Chain, it could occur that chassis images were missing.
