---
uid: Components_for_multiple_elements_or_services
---

# Components for multiple elements or services

For multiple elements or services, the building blocks described below are available in report templates.

## Aggregation

A graph visualizing the data of one or more aggregation rules. The following options are available:

- You can choose between the following types of graph: a *Trend Graph*, *Bar Graph* or *Pie Graph*.

- For a trend graph, you can choose between different time spans: *Last Hour*, *Last 24 Hours*, *Yesterday*, *Week to Date*, *Month to Date*, *Previous Month*, or *Year to Date*.

- For a trend graph, you can select to include only average trending, or to include minimum and maximum values.

- It is possible to show the graph for a view with or without its subviews. To include subviews, select *Include sub-Views*.

## Alarm Distribution Graph

Graph showing the distribution of alarms over a selected time span, with several options:

- You can choose to show data from the *Last 24 Hours*, *Yesterday*, a *Week to Date* or a *Month to Date*.

- Depending on the selected time range, you can select different possibilities for the average range that will be shown as a reference in the graph.

- It is possible to include only certain severities or element types.

## Alarm List

Overview of an element’s active alarms or history alarms for a selected time span. The following options are available:

- You can choose between different time spans: *Active*, to show only active alarms, *Last Hour*, *Last 24 Hours*, *Yesterday*, *Week to Date*, *Month to Date*, *Previous Month*, or *Year to Date*.

- It is possible to include only certain severities and alarm types.

- In order to only include certain parameters, you can filter on parameter name.

    Use a semicolon to combine several parameters in the filter, e.g. “Audio Output Level;CPU:SLelement.0”. For more information on using filters, see [Using quick filters](xref:Using_quick_filters).

- You can choose to sort the list either by element name or by alarm time.

## Alarm Scatter Graph

Graph comparing the different alarm events versus the alarm states for a selected time span. The following options are available:

- You can choose between many different time spans, or set a custom time span.

- It is possible to include only certain severities or element types.

- To include a textual overview, select *Include Textual Overview*. You can then indicate whether the overview should be sorted by *Name*, *# Events*, or *Duration*.

## DMS Status

General information about the DMS. The displayed information will contain:

- An overview of the total number and the number of active elements and services per DMA.

- An overview of the total number and the number of active elements and services in the DMS.

- DataMiner version number and build ID.

## Elements/Services Container

A container for element-specific information. Within this container, report components for single elements can be added.

## Info Table

A list of DMAs, elements, documents, or elements with their state and active alarm count.

## SLA Historic Service Alarm List

Only applicable for SLA elements. Shows a table with an overview of history service alarms for several SLA elements, with above this a summary of the total affected time and total violation time, the minimum and the measured availability, etc.

The following options are available:

- You can choose between different time spans: *Active*, to show only active alarms, *Last Hour*, *Last 24 Hours*, *Yesterday*, *Week to Date*, *Month to Date*, *Previous Month*, or *Year to Date*.

- It is possible to include only certain severities and alarm types.

- In order to only include certain parameters, you can filter on parameter name.

    Use a semicolon to combine several parameters in the filter. For more information on using filters, see [Using quick filters](xref:Using_quick_filters).

## Status Query

Available from DataMiner 9.5.13 onwards. Overview of parameter states of all included elements. The following options are available:

- In order to add columns with the minimum/maximum/average trending information for some parameters, select *Allow trending avg/min/max to be included*, and select a time span for the trending.

- To add a pie chart for the first parameter in the status query, select *Add pie chart for first parameter*.

## Top 10 States/New Alarm Count

An overview of the elements or services that either had the highest number of alarm events or spent the most time in alarm state. The following options are available:

- You can choose between many different time spans, or set a custom time span.

- It is possible to include only certain severities or element types.

- To include a textual overview, select *Include Textual Overview*. By default this overview will be sorted by rank; however, you can also select the option *Sort textual overview by name instead of rank*.

- The graph can be limited to 10, 20, 30, 40 or 50 elements.
