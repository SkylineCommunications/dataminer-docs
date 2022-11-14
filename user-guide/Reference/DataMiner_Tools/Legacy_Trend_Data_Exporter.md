---
uid: Legacy_Trend_Data_Exporter
---

# Legacy trend data exporter

From DataMiner 10.1.4 onwards, if the NewAverageTrending [soft-launch option](xref:SoftLaunchOptions) is activated, average trending is calculated in a different way that allows better performance. However, with this change, in some specific cases, intervals between two average trend points are no longer guaranteed to be constant. In cases where trend exports are generated and a fixed interval is expected, e.g. when exporting the 5-minute average trending points, this could be an issue. For this purpose, you can use the legacy trend data exporter tool.

> You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/legacy-trend-data-exporter/).

This standalone tool will realign the average trend points in a given .csv file to ensure fixed intervals (see example below).

To use this tool:

1. Generate the input file by exporting it from a DataMiner HTML5 dashboard.

1. Run the executable with the following arguments:

   - The fixed interval (in minutes) that should be used to recalculate the average values.

   - The input file path.

For example: `TrendDataLegacyExporter.exe 5 data.csv`

The resulting file will have the same name, with “.new” added before the file extension. For the example above, for instance, the output filename will be “data.new.csv”.

With these arguments, the example input data below could for instance be converted to the example output data below this.

Example input data:

| **Timestamp** | **Average** |
|---------------|-------------|
| 01/01/2001 00:02:00 | 1 |
| 01/01/2001 00:07:00 | 2 |
| 01/01/2001 00:15:00 | 3 |
| 01/01/2001 00:26:00 | 4 |
| 01/01/2001 00:28:00 | 5 |
| 01/01/2001 00:30:00 | 6 |
| 01/01/2001 00:35:00 | 7 |
| 01/01/2001 00:35:00 | 7 |
| 01/01/2001 00:39:00 | 8 |
| 01/01/2001 00:39:00 | 8 |
| 01/01/2001 00:40:00 | 9 |

Example output data:

| **Timestamp** | **Average** |
|--|--|
| 01/01/2001 00:00:00 | 1 |
| 01/01/2001 00:05:00 | 1.6 |
| 01/01/2001 00:15:00 | 3 |
| 01/01/2001 00:25:00 | 4.2 |
| 01/01/2001 00:30:00 | 6 |
| 01/01/2001 00:35:00 | 7.2 |
| 01/01/2001 00:40:00 | 9 |
