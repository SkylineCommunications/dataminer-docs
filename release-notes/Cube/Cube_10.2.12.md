---
uid: Cube_Feature_Release_10.2.12
---

# DataMiner Cube Feature Release 10.2.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.2.12](xref:General_Feature_Release_10.2.12).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### Trending: When trending a parameter, related parameters can now be added through light bulb icon [ID_34432]

<!-- MR 10.3.0 - FR 10.2.12 -->

When trending a parameter, you can now add related parameters by clicking the light bulb icon in the top-right corner of the trend. In doing so, you will get an overview of suggested parameters that are related to the currently displayed parameter trend.

## Changes

### Enhancements

#### Visual Overview: New toggle buttons added to Buttons stencil [ID_34426]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 [CU0] -->

The Buttons stencil now contains the following additional buttons:

- *tb-var-l* (button on left side, text on right side, logic based on session variable, configurable session variable scope)
- *tb-var-r* (button on right side, text on left side, logic based on session variable, configurable session variable scope)

Other changes made to the Buttons stencil:

- Buttons *abtn-automation* and *lbtn-automation* have been combined into one button *btn-automation*.
- Button *btn-popup* now has configurable window settings.

#### Trending - Behavioral anomaly detection: Enhanced detection of flatline changes [ID_34487]

<!-- MR 10.3.0 - FR 10.2.12 -->
<!-- Not added to 10.3.0 -->

Because of a number of enhancements, overall accuracy when detecting flatline changes has increased, especially in the following cases:

- When an element becomes inactive or is paused.
- When an element is deleted.
- When a table parameter is no longer active.

Any alarm or suggestion events created for flatline changes will now close sooner when one of the above-mentioned situations occurs.

### Fixes

#### DataMiner Cube - Spectrum Analysis: Problem with measurement point option 'Invert spectrum' [ID_34552]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When you had selected the *Invert spectrum* option while configuring a measurement point, in some cases, that option would incorrectly not be applied.

#### DataMiner Cube - Data Display: Parameter controls displaying a write parameter of type DateTime would incorrectly not take into account the format of the current culture as defined in the regional settings of DataMiner Cube [ID_34575]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

A parameter control displaying a write parameter of type DateTime would incorrectly not take into account the format of the current culture as defined in the regional settings of DataMiner Cube. As a result, the read and write parameters would be formatted differently.

#### Trending: Problem when duplicating table parameters with different values [ID_34591]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When duplicating a table parameter in the legend of a trend graph, the graph would not be displayed if the duplicate parameter did not have the same index value as the original parameter.

#### Trending: Table would be cleared of all data after refreshing [ID_34592]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When triggering a refresh of a trend chart, the data and axes on the line chart would disappear for a short period of time without first verifying whether there was any new incoming data. If the incoming data equals null, the graph should not be redrawn and should remain visible.

#### Visual Overview: Dynamically generated shapes sorted by custom property value would not be displayed in the correct order [ID_34617]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a large number of shapes generated based on child items in a view were sorted by a custom property value, in some rare cases, those shapes would not be displayed in the correct order.
