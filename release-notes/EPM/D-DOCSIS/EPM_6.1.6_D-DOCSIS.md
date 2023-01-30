---
uid: EPM_6.1.6_D-DOCSIS
---

# EPM 6.1.6 D-DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

\-

## Changes

### Enhancements

#### Dashboard URL enhancements [ID_34201]

Dashboard URLs in the EPM Solution have been updated to use a new JSON structure so that they load preselected data faster. This will also prevent issues where temperature data was not preselected in the dashboards.

### Fixes

#### Visual Overview: Shape linked to EPM entity had incorrect alarm severity color [ID_34535]

When a shape was linked to an EPM entity via the *SystemName* and *SystemType* properties, it could occur that the alarm severity color in Visual Overview was incorrect.

#### Incorrect or missing manufactory data in Inventory Table [ID_34536]

For the Inventory Table, the solution did not take into account that some devices report the Vendor ID while others report the Manufacturer Name. As a result, manufactory data could be missing or incorrect in the table. The information templates have been updated to prevent this.

#### Exposer option overused in EPM connectors [ID_34537]

Up to now, the Exposer option was used excessively in the EPM connectors in order to display the Node/Core Leaf information, which could cause issues such as the DMA going into the "Refused" state.

To resolve this, all Exposer options involving tables that are not actively monitored were removed. Previously exposed tables that were used for navigation purposes (e.g. Sensors) have been moved to the top navigation menu in Visual Overview. In every case where a link in the visual overview resulted in navigation to a data page, this will now navigate to a visual overview page instead.
