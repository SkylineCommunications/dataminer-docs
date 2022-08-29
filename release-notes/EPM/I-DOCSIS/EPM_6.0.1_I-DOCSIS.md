---
uid: EPM_6.0.1_I-DOCSIS
---

# EPM 6.0.1 I-DOCSIS

## New features

#### Integration of QAM US/DS Channels tables further refined \[ID_31433\]

The integration of the QAM US/DS Channels tables has been refined, so that channel parameter values are not necessarily immediately based on the first occurrence within the respective CM QAM US/DS Channels tables.

Depending on their operational meaning, parameters will be determined as follows:

- First Valid Occurrence: The first occurrence of valid data for the given parameter for the channel is taken from the source table. If no valid value found, N/A is displayed instead.
- Average: The average of valid values for the given parameter is calculated from the source table. If no valid value found, N/A is displayed instead.
- Contextual Calculation: The value is calculated contextually for the given table. For example, the *NMTER Alarm Status* will be determined based on the NMTER value and not based on the first occurrence of the channel in the source table.

#### Reflection Distance Threshold removed \[ID_31436\]

The *Reflection Distance Threshold* is now no longer displayed or taken into account. The *Reflection Distance Alarm Status* in the US Channels tables is also no longer available.

#### UI improvements \[ID_31438\]

A number of changes have been implemented to the EPM user interface.

Cable Modem adjustments:

- A new parameter *DS Rx Power Status* is now available.
- The *DS Power Status* parameter has been renamed to *US Tx Power Status*. The tooltip of this parameter has also been enhanced.
- The *US Power Status* parameter has been renamed to *US Rx Power Status*. The tooltip of this parameter has also been enhanced.
- *Group Delay and Reflection Distance* has been renamed to *Group Delay or Reflection Distance*.

Adjustments related to CM QAM US Channels and QAM US Channels:

- The *TX US Power* parameter has been renamed to *US Tx Power*. The tooltip of this parameter has also been enhanced.
- The *Rx Power* parameter has been renamed to *US Rx Power*. The tooltip of this parameter has also been enhanced.
- The *US Time Offset* parameter has been added.

Adjustments related to CM QAM DS Channels and QAM DS Channels:

- The *Rx Power* parameter has been renamed to *DS Rx Power*. The tooltip of this parameter has also been enhanced.

#### Generic DOCSIS CM Collector improvements \[ID_31460\]

Several improvements have been implemented in the Generic DOCSIS CM Collector connector:

- On the *Threshold Settings* page, similar thresholds are now grouped together.
- Existing threshold parameters have been repurposed with adjusted names, tooltips, ranges and default values.
- The following new threshold parameters have been added: *Downstream Channel Minimum* and *Downstream Channel Maximum Rx Power Level*.
- An apply button has been added to all threshold groups for ad-hoc processing of the thresholds.
- New threshold execution settings are available, which allow the user to control how frequently the threshold logic is executed.
- A new parameter, *DS Rx Power Status*, has been added, and the descriptions and tooltips of other status parameters within the CM table have been adjusted.
- A new *US Time Offset* parameter has been added to the US Channels tables.
- The descriptions and tooltips of parameters in the QAM Channels table have been adjusted.
- A *General* page has been added, with basic information about how many entities are managed within the connector. This includes an *Apply* button to update these parameters ad hoc.

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
