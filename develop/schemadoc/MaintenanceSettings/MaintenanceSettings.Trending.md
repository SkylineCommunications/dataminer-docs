---
uid: MaintenanceSettings.Trending
---

# Trending element

Specifies settings related to trending.

## Parents

[MaintenanceSettings](xref:MaintenanceSettings)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [updateTrendIndices](xref:MaintenanceSettings.Trending-updateTrendIndices) | boolean |  |  |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[EDCurves](xref:MaintenanceSettings.Trending.EDCurves) | [0, 1] | Deprecated. Specified the maximum number of trend graphs that could be loaded simultaneously in Element Display. |
| &#160;&#160;[SDCurves](xref:MaintenanceSettings.Trending.SDCurves) | [0, 1] | Deprecated. Specified the maximum number of trend graphs that could be loaded simultaneously in System Display. |
| &#160;&#160;[TimeSpan](xref:MaintenanceSettings.Trending.TimeSpan) | [0, 1] | Configures the period during which the "real-time trending" records have to be kept in the database. |
| &#160;&#160;[TimeSpan1DayRecords](xref:MaintenanceSettings.Trending.TimeSpan1DayRecords) | [0, 1] | Customizes the interval of the 1-day "average trending" records. |
| &#160;&#160;[TimeSpan1HourRecords](xref:MaintenanceSettings.Trending.TimeSpan1HourRecords) | [0, 1] | Customizes the interval of the 1-hour "average trending" records to be something other than the default 1 hour. |
| &#160;&#160;[TimeSpan5MinRecords](xref:MaintenanceSettings.Trending.TimeSpan5MinRecords) | [0, 1] | Customizes the interval of the 5-minute "average trending" records to be something other than the default 5 minutes. |
| &#160;&#160;[TimeSpanSpectrumRecords](xref:MaintenanceSettings.Trending.TimeSpanSpectrumRecords) | [0, 1] | Determines the period during which spectrum trend data has to be kept in the database. |
| &#160;&#160;[WarningLevel](xref:MaintenanceSettings.Trending.WarningLevel) | [0, 1] | **Obsolete**. Configured a trending warning message in the now obsolete Element Display and System Display applications. |
