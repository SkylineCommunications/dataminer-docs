# I-DOCSIS branch 6.0.0

## New features

\-

## Changes

### Enhancements

#### DS/US channel file structure exported by Casa Systems connector \[ID_31060\]

The Casa Systems connector now exports a new file structure for the DS/US channels so that the Generic CM Collector and Skyline EPM connectors can ingest this to show contextual data for the DS/US ports, DS/US service groups, and the service groups in general. This way, they will be able to show actual channel data instead of using data from cable modem instances of the channels.

#### DS/US channel file structure exported by Cisco CBR-8 connector \[ID_31061\]

The Cisco CBR-8 connector now exports a new file structure for the DS/US channels so that the Generic CM Collector and Skyline EPM connectors can ingest this to show contextual data for the DS/US ports, DS/US service groups, and the service groups in general. This way, they will be able to show actual channel data instead of using data from cable modem instances of the channels.

#### DS/US channel file structure exported by Cisco CMTS connector \[ID_31104\]

The Cisco CMTS connector now exports a new file structure for the DS/US channels so that the Generic CM Collector and Skyline EPM connectors can ingest this to show contextual data for the DS/US ports, DS/US service groups, and the service groups in general. This way, they will be able to show actual channel data instead of using data from cable modem instances of the channels.

### Fixes

#### Issues in Arris E6000 connector \[ID_31063\]

Several issues have been fixed in the Arris E6000 connector:

- An error in QAction 101 could flood the logging, making it difficult to read other issues.

- Some tables could keep growing infinitely.

- When the device was still polling, duplicate entries could occur.

#### Generic DOCSIS CM Collector: Width and Frequency not correctly displayed for CM QAM US Channel \[ID_31105\]

When CM QAM US Channel information was updated, it could occur that the Frequency and Width were not set to the correct values from the QAM US Channel.

#### Generic DOCSIS CM Collector: Width and Frequency not correctly displayed for CM QAM US/DS Channel \[ID_31106\]

When CM QAM US/DS Channel information was updated, it could occur that the Frequency and Width were not set to the correct values from the QAM US/DS Channel.



# D-DOCSIS branch 6.0.0

## New features

#### Ceeview Interface connector \[ID_31110\]

The Cox Ceeview Platform connector now communicates with COX's Ceeview Apigee API to fetch information on managed remote PHY devices.

## Changes

### Enhancements

#### Ping, Trace and other pop-up pages adjusted to EPM Topology Visual Overview \[ID_30955\]

The Ping, Trace and other pop-up pages have been adjusted to work with the EPM Topology Visual Overview.

#### Navigation through topology now stays within EPM environment \[ID_31107\]

When you navigate through the topology in the EPM visual overview, you will now always remain within the EPM environment instead of going to elements in the Surveyor.

#### Alarm monitoring for over-utilized DPA links \[ID_31109\]

Alarm monitoring and trending has been added for DPA links that are over-utilized in Visual Overview. In addition, N/A will now be shown if these are not applicable.

### Fixes

#### DCF link filtering not correctly creating/removing corrections \[ID_30833\]\[ID_30834\]

When DCF link filtering was used, it could occur that this did not show the right connections. The DCF logic in the Automation script for connectivity discovery and in the Cox IDP EPM Connectivity connector has now been improved to prevent this.

#### “Connected RPDs” links updated \[ID_30954\]

The *Connected RPDs* links in the topology have been updated to lead to the Node Leaf RPD Association pages.

#### Cisco Manager CIN Platform: Missing/incomplete data in Spine Temperature table \[ID_31108\]

It could occur that data was missing or incomplete in the Spine Temperature table.
