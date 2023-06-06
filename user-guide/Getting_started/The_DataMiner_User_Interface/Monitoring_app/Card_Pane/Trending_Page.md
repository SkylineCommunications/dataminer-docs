---
uid: Trending_Page
---

# Trending page

The trending page allows you to view a trend graph or histogram for a parameter. You can access the page by clicking the *View trending* option on an [element card](xref:Element_Cards).

From DataMiner 10.3.3/10.4.0 onwards, the header of a trending page shows a breadcrumb trail. Navigate back to the element card item by clicking it in the breadcrumb trail.

From DataMiner 10.3.4/10.4.0 onwards, you can easily switch between the [trend graph](#trend-graphs) and [histogram](#histograms) for the parameter by clicking the corresponding icons in the top-right corner of the trending page: <!-- RN 35501 -->

- ![Trending](~/user-guide/images/Trending.png) : Displays the trend graph for the parameter.

- ![Histogram](~/user-guide/images/Histogram.png) : Displays to the histogram for the parameter.

Prior to DataMiner 10.3.4/10.4.0, you can switch between the trend graph and histogram for the parameter by clicking the checkbox next to *Trending* or *Histogram*.

## Trend graphs

The time span for a trend graph can be configured:

- From DataMiner 10.3.4/10.4.0 onwards: The time range buttons in the top-right corner of the trending page allow you to select one of the preset time ranges: 1 day (last 24 hours), 1 week (last 7 days), 1 month (last 30 days), 1 year (last year), and 5 years (last 5 years). <!-- RN 35595 -->

- Prior to DataMiner 10.3.4/10.4.0: On the left of the trend card, the time span for the trend graph can be configured. <!-- RN 35705 -->

> [!NOTE]
> From DataMiner 10.2.0 [CU10]/10.3.1 onwards, the Monitoring app also supports trend graphs for string parameters.

## Histograms

On the left, you can configure the following settings:

- *Relative frequency*: Determines whether the frequency on the Y-axis should be shown in percent.
- *Use custom intervals*: Allows you to specify a custom number of intervals and interval range.

Prior to DataMiner 10.3.5/10.4.0, the time span for a histogram can also be configured on the left.

From DataMiner 10.3.5/10.4.0 onwards, you can use the time range buttons in the top-right corner of the page to select one of the preset time ranges: 1 day (last 24 hours), 1 week (last 7 days), 1 month (last 30 days), 1 year (last year), and 5 years (last 5 years). <!-- RN 35733 -->
