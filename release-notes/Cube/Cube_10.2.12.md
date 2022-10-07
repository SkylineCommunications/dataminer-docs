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

*No other features have been added to this version yet.*

## Changes

### Enhancements

*No enhancements have been added to this version yet.*

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
