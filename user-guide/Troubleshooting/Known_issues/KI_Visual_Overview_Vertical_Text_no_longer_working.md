---
uid: KI_Visual_Overview_Vertical_Text_no_longer_working
---

# Vertical text in Visual Overview not displayed correctly

## Affected versions

- DataMiner Main Release versions from DataMiner 10.2.0 [CU3] up to 10.3.0 [CU4].
- DataMiner Feature Release versions from DataMiner 10.2.3 up to 10.3.7.

## Cause

A feature introduced in DataMiner 10.2.3 that enables text wrapping and trimming [(RN 32440)](xref:General_Feature_Release_10.2.3#visual-overview-text-wrapping-and-trimming-id-32440) causes vertical text in Visual Overview shapes to be displayed incorrectly. If the latest version of DataMiner Cube is used, this issue can also occur in Main Release versions from DataMiner 10.2.0 [CU3] onwards.

## Fix

Install DataMiner 10.3.0 [CU5]/10.3.8<!--RN 36363-->.

## Workaround

If your DMA is running a 10.2 main release, go to *System Center > System settings > Manage client versions*, and enable *Force the matching release version*.

## Issue description

In Visual Overview, vertical text is not displayed correctly.
