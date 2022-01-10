## Accessing trend information from a card

On the data side of element cards, service cards and (for aggregation) view cards, trended parameters are indicated with a trending icon.

On a DMA using a Cassandra database, these trending icons can be displayed differently depending on the predicted trend:

| Trend icon                                                                     | Description                                                                                                                                                                                                                                                       |
|--------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ![](../../images/Trend_icon_increase.png) | The predicted trend value is increasing. Hover over the icon to view the rate of increase.                                                                                                                                                                        |
| ![](../../images/trend_icon_decrease.png) | The predicted trend value is decreasing. Hover over the icon to view the rate of decrease.                                                                                                                                                                        |
| ![](../../images/trend_icon_stable.png)   | The predicted trend remains stable.                                                                                                                                                                                                                               |
| ![](../../images/trend_icon_unknown.png)  | The trend behavior cannot be predicted, either because there is insufficient data, or because there is too much uncertainty in the direction of the trend during the past hour.<br> On a DMA that does not use a Cassandra database, only this icon is displayed. |

> [!NOTE]
> -  Behavior is calculated for single-value parameters and table parameters. In case of partial tables, behavior is only calculated for the rows of the first page.
> -  In the first hour after starting the SLAnalytics process, DataMiner has insufficient data to determine parameter behavior. This means that behavior arrows will only appear at least an hour after the SLAnalytics process was started.
> -  The behavior of the arrows can be configured in the file *SLAnalytics.config*. See [SLAnalytics.config](../../part_7/SkylineDataminerFolder/SLAnalytics_config.md#slanalyticsconfig).
> -  You can enable or disable trend prediction icons via *System Center* > *System settings* > *analytics config*. That page also allows you to configure the minimum window duration these icons are based on and the update interval for the icons.

To access more detailed trend information for a parameter:

1. On the element card data page containing this parameter, double-click the parameter, or click the trend icon next to it. Alternatively, you can also right-click the parameter and select *Open*.

    At this point, the trending information for the last 24 hours is loaded in the main graph, and the information for the past week is loaded in the preview graph below that.

2. Optionally, switch between different time spans for the main trend graph by clicking the buttons in the top-right corner:

    - *Custom*: Available from DataMiner 10.2.1/10.3.0 onwards. Opens a pop-up box where you can specify a custom start and end time for the trend graph.

    - *Last 24 Hours*

    - *Week to Date*

    - *Month to Date*

3. To return to the card, click *Up to Data Display*.
