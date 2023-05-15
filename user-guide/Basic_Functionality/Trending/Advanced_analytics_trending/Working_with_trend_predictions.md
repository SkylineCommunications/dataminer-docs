---
uid: Working_with_trend_predictions
---

# Working with trend predictions

> [!NOTE]
>
> - This feature requires a general database of type “Cassandra”.
> - Predictions are not available for discrete and string parameters.
> - From DataMiner 9.5.13 onwards, trend predictions can be disabled in the user settings. See [Trending settings](xref:User_settings#trending-settings).
> - You can enable or disable this feature via *System Center* > *System settings* > *analytics config.*

> [!TIP]
> For a how-to video, see [Trending – Trend predictions in DataMiner](https://community.dataminer.services/video/trending-trend-predictions-in-dataminer/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

If the DataMiner Agent uses a Cassandra database, trend graphs can show how the value of a parameter in the graph is most likely to evolve in the future.

The current point in time is displayed with a vertical dashed line marked as “Now”. This line is updated every 2 seconds. The trend prediction starts from the “Now” line.

The predicted trend is displayed as a line surrounded by three shaded areas:

- The largest shaded area shows how the parameter will evolve with 95 % probability

- The middle area shows the evolution with 90 % probability, and

- The smallest area shows the evolution with 80 % probability.

> [!NOTE]
>
> - The probability percentages are based on the assumptions made at the moment the graph is generated. If the behavior of the data changes afterwards, the probability may need to be adjusted.
> - If a recurring pattern is found, the predicted trend is based on this pattern. Otherwise, the predicted trend should be considered as the average future value.

Different types of trend prediction can be displayed, each in a different style.

From DataMiner 10.0.12 onwards:

- High-precision prediction is displayed as a dotted line.

- Short-term prediction is displayed with short dashes.

- Mid-term prediction is displayed with long dashes.

- Long-term prediction is displayed with slightly longer dashes

Prior to DataMiner 10.0.12:

- Short-term prediction is displayed as a dotted line.

- Mid-term prediction is displayed with short dashes.

- Long-term prediction is displayed with long dashes.

- Full-term prediction, which is based on either daily data points or a server-side aggregated set of one-hour data points, is also displayed with long dashes. (Available from DataMiner 10.0.11 onwards.)

To select which trend prediction type is used, from DataMiner 10.2.9/10.3.0 onwards, right-click the trend graph, select *Trend prediction* in the right-click menu, and then select the desired prediction type. In earlier DataMiner versions, use the drop-down list in the top-right corner.

From DataMiner 10.2.9/10.3.0 onwards, if one or more of the trend prediction types are not available, they will no longer appear in the right-click menu. In earlier DataMiner versions, a warning icon is displayed. If you hover over that icon, a tooltip will show which type or types cannot be displayed. If none of the trend prediction types are available, the tooltip will explain why.

You can either select one of the available trend prediction types, or select "Auto". Auto mode will automatically switch between the different trend prediction types as you zoom in and out on the graph.

> [!NOTE]
>
> - If the displayed area of the graph only contains past trend information, the selector with the trend prediction mode will no longer be displayed.
> - The first time the prediction exceeds a particular alarm threshold, this is indicated with a triangle-shaped marker. If multiple trends are displayed, you can hover over the alarm marker to see a tooltip indicating which trend will trigger the alarm.
> - Parameter changes will change the underlying models for the prediction in real time, and predictions may change when the trend graph is shown at a later moment in time. If because of the parameter changes the underlying model is considered not to be stable enough, the prediction for a certain level may be removed.
> - When you change the prediction type to *Auto*, or change it from *Auto* to one of the other options, any other open trend charts will also be updated to that setting.
> - The DataMiner process responsible for trend predictions is SLAnalytics. For more information, see [SLAnalytics](xref:DataMiner_processes#slanalytics).
