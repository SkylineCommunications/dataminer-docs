---
uid: Working_with_trend_icons
---

# Working with trend icons

> [!NOTE]
>
> - This feature requires [Storage as a Service](xref:STaaS) or a [self-hosted Cassandra-compatible database](xref:Supported_system_data_storage_architectures).
> - You can enable or disable this feature via *System Center* > *System settings* > *analytics config*.

The DataMiner Analytics software analyzes the behavior of numeric parameters in real time. A visual summary of the most recent trend is shown in the form of a *trend icon* next to a trended parameter on a data page.

Please note the following regarding these icons:

- The selection of a particular icon is based on the trend data behavior within a configurable time interval. By default, this time interval is set to 3600 seconds. Prior to DataMiner 10.0.9/10.1.0, this is specified in the *arrowWindowLength* parameter in the file *C:\\Skyline DataMiner\\Files\\SLAnalytics.config*. From DataMiner 10.0.9/10.1.0 onwards, the time interval can be configured via *System Center* > *System settings* > *analytics config* > *Minimum window duration*.

- When an element card stays open, the icon will be updated at regulars intervals. By default, icons are updated every 300 seconds. Prior to DataMiner 10.0.9/10.1.0, this is specified in the *updateArrowTime* parameter in the file *C:\\Skyline DataMiner\\Files\\SLAnalytics.config*. From DataMiner 10.0.9/10.1.0 onwards, the length of the update interval can be configured in *System Center* > *System settings* > *analytics config* > *Arrow update interval*.

- In case [Behavioral Anomaly detection](xref:Working_with_behavioral_anomaly_detection) is available, an icon may show the occurrence of a certain type of change point. If a change point is considered anomalous, the icon is displayed in red.

- If you hover the mouse pointer over these icons, a tooltip will display additional information.

- The calculation of trend icons requires the storage of average trend data. To limit memory usage, from DataMiner 10.4.2/10.5.0 onwards<!--RN 38041-->, the number of trended parameters for which trend icons are calculated is limited to at most 250,000 trended parameters per DMA.

## Available trend icons

The following icons can be displayed next to a trended parameter on a data page:

| Icon   | Description     |
|--------|-----------------|
| ![Trend graph icon](~/user-guide/images/StandardTrendGraphIcon.png) | Standard trend graph icon |
| ![Upward arrow icon](~/user-guide/images/ArrowRight60.png) | Upward arrow  |
| ![Downward arrow icon](~/user-guide/images/ArrowRight120.png)  | Downward arrow  |
| ![Flat arrow icon](~/user-guide/images/ArrowRight.png)  | Flat arrow  |
| ![Upward level shift icon](~/user-guide/images/LevelShiftIncrease.png) ![Red upward level shift icon](~/user-guide/images/LevelShiftIncreaseRed.png) | Upward level shift |
| ![Downward level shift icon](~/user-guide/images/LevelShiftDecrease.png) ![Red downward level shift icon](~/user-guide/images/LevelShiftDecreaseRed.png) | Downward level shift |
| ![Upward trend change icon](~/user-guide/images/ArrowTrendChangeUp.png) ![Red upward trend change](~/user-guide/images/ArrowTrendChangeUpRed.png) | Upward trend change |
| ![Downward trend change icon](~/user-guide/images/ArrowTrendChangeDown.png) ![Red downward trend change](~/user-guide/images/ArrowTrendChangeDownRed.png) | Downward trend change |
| ![Variance increase icon](~/user-guide/images/ArrowVarianceChangeUp.png) ![Red variance increase icon](~/user-guide/images/ArrowVarianceChangeUpRed.png) | Variance increase |
| ![Variance decrease icon](~/user-guide/images/ArrowVarianceChangeDown.png) ![Red variance decrease icon](~/user-guide/images/ArrowVarianceChangeDownRed.png) | Variance decrease |
| ![Upward outlier icon](~/user-guide/images/ArrowOutlierUp.png) ![Red upward outlier icon](~/user-guide/images/ArrowOutlierUpRed.png) | Upward outlier |
| ![Downward outlier icon](~/user-guide/images/ArrowOutlierDown.png) ![Red downward outlier icon](~/user-guide/images/ArrowOutlierDownRed.png) | Downward outlier |
| ![Flatline icon](~/user-guide/images/ArrowFlatline.png) ![Red flatline icon](~/user-guide/images/ArrowFlatlineRed.png) | Flatline |