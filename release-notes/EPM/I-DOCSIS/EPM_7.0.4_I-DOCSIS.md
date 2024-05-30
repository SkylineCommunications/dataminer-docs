---
uid: EPM_7.0.4_I-DOCSIS
---

# EPM 7.0.4 I-DOCSIS (preview)

> [!IMPORTANT]
> We are still working on this release. Release notes may still be added, modified, or moved to a later release. Check back soon for updates!

## New features

#### Trend component added to OFDM(A) dashboards [ID_39800]

The OFDM(A) dashboards in the node segment folder and service group folder now include a detailed trend graph of the channel utilization of the selected channel in the OFDM(A) table. By default, the first row is selected.

A time picker has also been added at the top of the dashboards so that users can customize the time range of the displayed trend data. This will provide better insight into channel usage patterns and will help users identify anomalies.

## Changes

### Enhancements

#### CISCO CBR-8 CCAP Platform: Improved bit rate calculations for interfaces [ID_39687]

In the CISCO CBR-8 CCAP Platform connector, the efficiency and accuracy of the bit rate calculation for interfaces has been improved.

#### CISCO CBR-8 CCAP Platform: New DOCSIS 2.0 CM – service group mapping [ID_39752]

For DOCSIS 2.0 and lower, the mapping of CMs to service groups has been updated so the correct service groups and ports used by the CMs will be found. This will prevent CMs with missing information and will ensure that the aggregation operations match across all levels.

#### Unnecessary hyphens removed from PNM parameter names [ID_39799]

On the visual overview pages related to PNM, unnecessary hyphens have been removed from the parameter names where appropriate. For example, the parameter *Pre-Main-Tap to Total Energy Ratio (Pre-MTTER) Threshold* has been renamed to *Pre-Main Tap to Total Energy Ratio (PreMTTER) Threshold*. The same change has also been implemented for the *Non-Main-Tap Energy Ratio (NMTER) Threshold* and *Post-Main-Tap to Total Energy Ratio (Post-MTTER) Threshold* parameters. This change has been implemented in the visual overview of the front end and that of the collectors.

### Fixes

#### Overlapping GUI elements on PNM thresholds configuration page [ID_39723]

Previously, on the *Configuration* > *Thresholds Settings* > *PNM* page of the EPM visual overview, GUI elements could overlap when a threshold was modified. The spacing on this page has been adjusted to prevent this issue.
