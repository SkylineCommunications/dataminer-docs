---
uid: KI_Incorrect_date_sorting_in_Bookings_app_with_custom_column_configurations
---

# Incorrect date sorting in Bookings app with custom column configurations

## Affected versions

- SRM setups using a DataMiner version prior to 10.2.0 [CU10]/10.3.1.

- SRM setups using custom column configurations created prior to DataMiner 10.2.0 [CU10]/10.3.1.

## Cause

In older [custom column configurations](xref:Creating_a_list_view#creating-a-new-column-configuration), date-based columns were stored with a *VisualType* value of `String (0)` instead of `DateTime (3)`. As a result, sorting is performed alphabetically rather than chronologically.

## Fix

Install DataMiner 10.2.0 [CU10]/10.3.1.

> [!IMPORTANT]
> Custom column configurations created prior to these versions are not automatically updated and require [manual intervention](#workaround).

## Workaround

Update the affected custom column configurations using one of the following methods:

- Via Cube:

  1. Open the Bookings app.

  1. Right-click the column headers and select *Manage column configuration*.

  1. Clear the affected date keys and select *OK*.

  1. Right-click the column headers and select *Manage column configuration* again.

  1. Re-enable the same keys and click *OK*.

  This rewrites the configuration so the affected columns are stored using the correct DateTime type.

- Via configuration file:

  1. Open the relevant data file located under `C:\Skyline DataMiner\VisualData\Data`.

  1. Locate the affected date keys (for example, `StartTime`).

  1. Update their *VisualType* value from `0 (String)` to `3 (DateTime)`.

  1. Save the file.

  1. Verify in Cube that sorting now behaves as expected.

  1. Repeat these steps for all affected custom configurations.

## Description

When sorting a bookings list that has a [custom column configuration applied](xref:Creating_a_list_view#creating-a-new-column-configuration) by a date-based column, entries may appear in an incorrect order.

For example, a booking starting on July 1st may be listed before a booking starting on June 30th, even when sorting in ascending order by start time.

This occurs because the column is still treated as a String value instead of a DateTime value.
