---
uid: EPM_6.0.1_D-DOCSIS
---

# EPM 6.0.1 D-DOCSIS

## New features

#### Linked alarms for CISCO CBR-8 CCAP Platform Collector, Cisco Manager CIN Platform and Juniper Networks Manager CIN Platform displayed in Alarm Console tab EPM card \[ID_31430\] \[ID_31431\] \[ID_31432\]

When you navigate to an element through the topology and open an EPM card, all relevant alarms that are only present on the element will now be available in the Alarm Console tab of the EPM card. This way you no longer need to go through the Surveyor or through the Alarm Console at the bottom of the screen to see if the element in the EPM topology has any alarms.

This has been done for the CISCO CBR-8 CCAP Platform Collector, Cisco Manager CIN Platform and Juniper Networks Manager CIN Platform connectors, by attaching the System Type and System Name properties to the alarm at connector level.

#### KAFKA topics integration \[ID_31440\]

KAFKA topics have been integrated into EPM D-DOCSIS.

The following three connectors are included in this integration: Generic KAFKA Consumer, Skyline CCAP platform WM and COX CBR-8 Platform D-DOCSIS. The Skyline CCAP platform WM is the intermediary between the Generic KAFKA Consumer and the COX CBR8 Platform

The WM receives requests from the CBR8 platform asking for specific topic data. The WM will then search for the requested data in the files that are created by the Generic KAFKA Consumer. After parsing the data, it creates the provisioning files and sends a response to the CBR8 platform.

In the WM element, a new *Topics* page has been added, where you can find the *Topics Consumption Buffer* table. A new *Topic Settings* page is also available, where you can check and configure topic settings.

The necessary Automation Scripts and Correlation Rules have also been created to support the topic data handling workflow.

#### New MAC State Not Online filter option \[ID_31454\]

On all CM pages, the *MAC State* filter box now has a new *Not Online* option. This option shows all CMs in a MAC state that do not contain the keyword "online". You can also apply this filter by clicking *% CM OFFLINE* on the *Overview* page where applicable.

## Changes

### Enhancements

#### Links added in D-DOCSIS EPM Visual Overview \[ID_31441\]

In the D-DOCSIS EPM Visual Overview, links have now been added to several fields where these were previously missing: CCAP, RPD, Fiber Node, Managing RPD, and various items listed under Connectivity Details.

#### "Connected RPDs" links improved \[ID_31456\]

The *Connected RPDs* links on the Topology pages have been adjusted so that their alarm color now reflects the highest severity present in the *RPD Overview* table. Previously, the alarm color was linked to the Node Leaf element instead.

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
