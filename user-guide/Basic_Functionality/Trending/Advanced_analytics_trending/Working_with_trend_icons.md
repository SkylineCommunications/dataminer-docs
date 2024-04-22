---
uid: Working_with_trend_icons
---

# Working with trend icons

The DataMiner Analytics software analyzes the behavior of numeric parameters in real time. A visual summary of the most recent behavior is shown in the form of a **trend icon** next to a trended parameter on a data page.

## Prerequisites

- This feature requires [Storage as a Service](xref:STaaS) or a [self-hosted Cassandra-compatible database](xref:Supported_system_data_storage_architectures).

- You can enable this feature via *System Center* > *System settings* > *analytics config*.

## Available trend icons

The following icons can be displayed next to a trended parameter on a data page:

| Trend icon | Description |
|:--:|--|
| ![Trend graph icon](~/user-guide/images/StandardTrendGraphIcon.png) | The default icon. |
| ![Upward arrow icon](~/user-guide/images/ArrowRight60.png) | The trend is increasing. |
| ![Downward arrow icon](~/user-guide/images/ArrowRight120.png)  | The trend is decreasing. |
| ![Flat arrow icon](~/user-guide/images/ArrowRight.png)  | The trend remains stable.  |
| ![Upward level shift icon](~/user-guide/images/LevelShiftIncrease.png) ![Red upward level shift icon](~/user-guide/images/LevelShiftIncreaseRed.png) | An upward level shift was detected. |
| ![Downward level shift icon](~/user-guide/images/LevelShiftDecrease.png) ![Red downward level shift icon](~/user-guide/images/LevelShiftDecreaseRed.png) | A downward level shift was detected. |
| ![Upward trend change icon](~/user-guide/images/ArrowTrendChangeUp.png) ![Red upward trend change](~/user-guide/images/ArrowTrendChangeUpRed.png) | An upward trend change was detected. |
| ![Downward trend change icon](~/user-guide/images/ArrowTrendChangeDown.png) ![Red downward trend change](~/user-guide/images/ArrowTrendChangeDownRed.png) | A downward trend change was detected. |
| ![Variance increase icon](~/user-guide/images/ArrowVarianceChangeUp.png) ![Red variance increase icon](~/user-guide/images/ArrowVarianceChangeUpRed.png) | A variance increase was detected. |
| ![Variance decrease icon](~/user-guide/images/ArrowVarianceChangeDown.png) ![Red variance decrease icon](~/user-guide/images/ArrowVarianceChangeDownRed.png) | A variance decrease was detected. |
| ![Upward outlier icon](~/user-guide/images/ArrowOutlierUp.png) ![Red upward outlier icon](~/user-guide/images/ArrowOutlierUpRed.png) | An upward outlier was detected. |
| ![Downward outlier icon](~/user-guide/images/ArrowOutlierDown.png) ![Red downward outlier icon](~/user-guide/images/ArrowOutlierDownRed.png) | A downward outlier was detected. |
| ![Flatline icon](~/user-guide/images/ArrowFlatline.png) ![Red flatline icon](~/user-guide/images/ArrowFlatlineRed.png) | A flatline was detected. |

Please note the following regarding these icons:

- Behavior is calculated for single-value parameters and table parameters. For [partial tables](xref:Table_parameters#partial-tables), behavior is only calculated for the rows of the first page. For rows on subsequent pages, behavior is calculated only when those pages are accessed.

- The selection of a particular icon is based on the trend data behavior within a configurable time interval. By default, this time interval is set to 3600 seconds. Prior to DataMiner 10.0.9/10.1.0, this is specified in the *arrowWindowLength* parameter in the file *C:\\Skyline DataMiner\\Files\\SLAnalytics.config*. From DataMiner 10.0.9/10.1.0 onwards, the time interval can be configured via *System Center* > *System settings* > *analytics config* > *Minimum window duration*.

- During the initial time interval after the start of the SLAnalytics process, DataMiner may lack sufficient data to determine the behavior of certain parameters. In such cases, only the default trend icon will be displayed for those parameters during this period.

- When an element card remains open, the icon will update at regular intervals. By default, icons are updated every 300 seconds. From DataMiner 10.0.9/10.1.0 onwards, you can configure the update interval in *System Center* > *System settings* > *analytics config* > *Arrow update interval*. Prior to DataMiner 10.0.9/10.1.0, this setting is specified by the *updateArrowTime* parameter in the *C:\\Skyline DataMiner\\Files\\SLAnalytics.config* file.

- If [Behavioral Anomaly detection](xref:Working_with_behavioral_anomaly_detection) is available, an icon may indicate the occurrence of a particular type of change point. **If a change point is considered anomalous, the icon is displayed in red.**

- If you hover the mouse pointer over these icons, a tooltip will display additional information.

- The calculation of trend icons requires the storage of average trend data. To limit memory usage, from DataMiner 10.4.2/10.5.0 onwards<!--RN 38041-->, the number of trended parameters for which trend icons are calculated is limited to at most 250,000 trended parameters per DMA.

- If the current behavior cannot be determined, whether because of the feature being disabled, insufficient data, or significant uncertainty in the trend direction over the past interval, a default icon will be displayed. On a DMA that uses a legacy MySQL database, only this icon is displayed.
