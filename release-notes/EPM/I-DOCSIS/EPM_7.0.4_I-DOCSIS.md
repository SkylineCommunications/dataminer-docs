---
uid: EPM_7.0.4_I-DOCSIS
---

# EPM 7.0.4 I-DOCSIS (preview)

> [!IMPORTANT]
> We are still working on this release. Release notes may still be added, modified, or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### CISCO CBR-8 CCAP Platform: Improved bit rate calculations for interfaces [ID_39687]

In the CISCO CBR-8 CCAP Platform connector, the efficiency and accuracy of the bit rate calculation for interfaces has been improved.

#### CISCO CBR-8 CCAP Platform: New DOCSIS 2.0 CM – service group mapping [ID_39752]

For DOCSIS 2.0 and lower, the mapping of CMs to service groups has been updated so the correct service groups and ports used by the CMs will be found. This will prevent CMs with missing information and will ensure that the aggregation operations match across all levels.

### Fixes

#### Overlapping GUI elements on PNM thresholds configuration page [ID_39723]

Previously, on the *Configuration* > *Thresholds Settings* > *PNM* page of the EPM visual overview, GUI elements could overlap when a threshold was modified. The spacing on this page has been adjusted to prevent this issue.
