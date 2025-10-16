---
uid: EPM_7.0.4_I-DOCSIS
---

# EPM 7.0.4 I-DOCSIS

## New features

#### Trend component added to OFDM(A) dashboards [ID 39800]

The OFDM(A) dashboards in the node segment folder and service group folder now include a detailed trend graph of the channel utilization of the selected channel in the OFDM(A) table. By default, the first row is selected.

A time picker has also been added at the top of the dashboards so that users can customize the time range of the displayed trend data. This will provide better insight into channel usage patterns and will help users identify anomalies.

## Changes

### Enhancements

#### CISCO CBR-8 CCAP Platform: Improved bit rate calculations for interfaces [ID 39687]

In the CISCO CBR-8 CCAP Platform connector, the efficiency and accuracy of the bit rate calculation for interfaces has been improved.

#### CISCO CBR-8 CCAP Platform: New DOCSIS 2.0 CM – service group mapping [ID 39752]

For DOCSIS 2.0 and lower, the mapping of CMs to service groups has been updated so the correct service groups and ports used by the CMs will be found. This will prevent CMs with missing information and will ensure that the aggregation operations match across all levels.

#### Unnecessary hyphens removed from PNM parameter names [ID 39799]

On the visual overview pages related to PNM, unnecessary hyphens have been removed from the parameter names where appropriate. For example, the parameter *Pre-Main-Tap to Total Energy Ratio (Pre-MTTER) Threshold* has been renamed to *Pre-Main Tap to Total Energy Ratio (PreMTTER) Threshold*. The same change has also been implemented for the *Non-Main-Tap Energy Ratio (NMTER) Threshold* and *Post-Main-Tap to Total Energy Ratio (Post-MTTER) Threshold* parameters. This change has been implemented in the visual overview of the front end and that of the collectors.

#### QAM Channel and OFDM Channel dashboards now use trend component [ID 39909]

The QAM Channel and OFDM Channel dashboards now use a trend component instead of a GQI graph, so that the graph displayed in the dashboards is more similar to a Cube trend graph.

#### Harmonic CableOS: Improved interfaces information retrieval [ID 39921]

An improvement has been implemented to the way data is retrieved in the interface tables for the Harmonic CableOS connector, resulting in more reliable and consistent bitrate calculations. The utilization percentages calculations and error rates calculations have also been updated.

#### Automation scripts placed in dedicated folder during deployment [ID 39922]

When the EPM package is deployed, all its Automation scripts are now placed in an I-DOCSIS folder instead of at the root level of the Automation module.

#### Skyline EPM Platform and Skyline EPM Platform DOCSIS information templates updated [ID 39933]

In the Skyline EPM Platform information template, several parameters on the service group level have been renamed to match with the other levels:

- *Number CM DOCSIS 2.0* has been renamed to *Number DOCSIS 2.0*.
- *Number CM DOCSIS 3.0* has been renamed to *Number DOCSIS 3.0*.
- *Number CM DOCSIS 3.1* has been renamed to *Number DOCSIS 3.1*.

In addition, a new information template has been added for the Skyline EPM Platform DOCSIS connector in order to match the naming convention used in the Skyline EPM Platform connector.

### Fixes

#### Overlapping GUI elements on PNM thresholds configuration page [ID 39723]

Previously, on the *Configuration* > *Thresholds Settings* > *PNM* page of the EPM visual overview, GUI elements could overlap when a threshold was modified. The spacing on this page has been adjusted to prevent this issue.

#### EPM dashboards with GQI queries not working correctly with recent DataMiner versions [ID 39766]

When EPM dashboards using GQI queries were used in recent DataMiner versions, it could occur that the queries did not work correctly. The dashboards have now been updated to prevent this.

#### Generic DOCSIS CM Collector: RTE caused by SLProtocolExt call [ID 39923]

Because of the use of the *SLProtocolExt* interface to retrieve keys from the CM QAM DS Channel table, long wait times could be encountered in the Generic DOCSIS CM Collector connector, which could cause a runtime error in DataMiner. The connector has now been enhanced to prevent this.

#### Card structure different when opened from the Alarm Console or from the topology [ID 39934]

Previously, when an EPM alarm was opened from the Alarm Console, the displayed parameters were not organized in the same way as when the same card was opened from the topology. This has been adjusted, and parameters have been grouped into boxes, so that the page structure will now be the same regardless of where it is opened from.
