---
uid: Exporting_a_trend_graph
---

# Exporting a trend graph

To export a trend graph:

1. Right-click the graph and select *Export to CSV*.

   This will open an export window.

1. If you are exporting a graph where several curves are displayed, at the top of the export window, select which curves you want to include in the export.

1. Under *Data to be exported*, select whether all data should be included ("*Everything*") or a custom dataset. For a custom dataset, you can select the type of trending (e.g. real-time, 5-minute interval, 60-minute interval) and the time span.

1. Optionally, select additional options for the export. From DataMiner 10.2.2/10.3.0 onwards, these options are available in an expandable *Advanced options* section.

   - *Line graph instead of block graph*: Exports one value per timestamp, which will allow you to draw a line graph. Values in the export are shifted so that they are located in the middle of each time slot. So, for instance, if you have a point at 09:05:00 and at 09:10:00, the export will contain one point at 09:07:30. If you do not select this option, two values are exported per timestamp, which will allow you to draw a block graph. From DataMiner 10.2.2/10.3.0 onwards, this option does not include intermediary points in the export. To include those, select *Fixed interval*.

   - *Fixed interval*: Available from DataMiner 10.2.2/10.3.0 onwards. Select this option to have data points distributed equally and to ignore gaps smaller than the average trending interval.

     >[!NOTE]
     >This option is only available for double, number or analog parameters, and only for average trend data. This means that type *5-minute interval* or *60-minute interval* must be selected under *Data to be exported*.

   - *Exclude gaps*: Select this option to skip any gaps in the trend data in the export. This option is automatically selected if *Fixed interval* is selected.

1. Click *Save*.
