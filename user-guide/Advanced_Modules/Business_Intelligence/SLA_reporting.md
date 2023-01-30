---
uid: SLA_reporting
---

# SLA reporting

To access reporting information on an SLA, go to the legacy *Reports & Dashboards* module, then choose *Business* in the left column. For more information on how to access the module, see [Viewing the built-in reports in the Reporter app](xref:Viewing_the_built-in_reports_in_the_Reporter_app#viewing-the-built-in-reports-in-the-reporter-app).

If there is more than one SLA available, you will then have to choose the SLA you wish to view. You can still select a different SLA afterwards by clicking *CHANGE* in the header to the right of the SLA name.

You can choose between several tabs at the top of the overview screen to access detailed reporting information. Refer to the sections below for more information on each tab:

- [Summary](#summary)

- [Distribution](#distribution)

- [Severities](#severities)

- [Alarms](#alarms)

- [History](#history)

- [Service History](#service-history)

- [Status](#status)

- [Parameter](#parameter)

- [Top](#top)

- [Trending](#trending)

Alternatively, you can also go directly to the URL for a particular type of report:

| Report type     | URL                                                                                                  |
|-----------------|------------------------------------------------------------------------------------------------------|
| Summary         | http://\[MyDataMiner\]/Reports/SLA.asp?element=\[SLA Element Name\]                                  |
| Distribution    | http://\[MyDataMiner\]/Reports/SLA-Distribution.asp?element=\[SLA Element Name\]                     |
| Severities      | http://\[MyDataMiner\]/Reports/SLA-Alarms.asp?element=\[SLA Element Name\]                           |
| Alarms          | http://\[MyDataMiner\]/Reports/SLA-ActiveAlarms.asp?element=\[SLA Element Name\]                     |
| History         | http://\[MyDataMiner\]/Reports/SLA-History.asp?element=\[SLA Element Name\]                          |
| Service history | http://\[MyDataMiner\]/Reports/SLA-HistoryService.asp?element=\[SLA Element Name\]                   |
| Status          | http://\[MyDataMiner\]/Reports/SLA-Status.asp?element=\[SLA Element Name\]                           |
| Parameter       | http://\[MyDataMiner\]/Reports/SLA-Parameter.asp?param=\[Parameter ID\]&element=\[SLA Element Name\] |
| Top             | http://\[MyDataMiner\]/Reports/SLA-TopParams.asp?element=\[SLA Element Name\]                        |
| Trending        | http://\[MyDataMiner\]/Reports/SLA-Trend.asp?param=\[Parameter ID\]&element=\[SLA Element Name\]     |

> [!NOTE]
> The sections below discuss SLA reporting in built-in reports in Cube. However, it is also possible to make custom SLA reports. In particular, the “SLA Historic Service Alarm List” component is designed for such custom reports, though other components may also be used. See [SLA Historic Service Alarm List](xref:Components_for_one_single_element_or_service#sla-historic-service-alarm-list).

## Summary

This tab contains general information on the SLA and the service, as well as a graph showing the distribution of alarms.

## Distribution

This tab contains a detailed graph showing the distribution of alarms over a particular time span. At the top of the screen, you can determine this time span, as well as the severity of alarms that are included in the graph.

## Severities

This tab contains a graphic representation of alarm events and alarm states for the SLA, as well as a timeline showing the worst alarm states.

Use the drop-down menu at the top to choose whether the graphs show information regarding a particular element, SLA availability or SLA compliance.

Use the next drop-down menu to set the time span for which the graphs show information.

## Alarms

This tab shows information about any alarms pertaining to the SLA itself, rather than to the elements or service the SLA applies to.

## History

In this tab, you can generate a report for the history of the SLA.

## Service History

In this tab you can have an SLA recalculated for any period in the past and make the results available in a report.

1. Indicate the start and end time for your report, the severities to be included, the alarm types to be included, and optionally a parameter name filter.

1. Click the *Load* button.

1. Click the *Generate Report* button in the lower right corner.

   The SLA will be recalculated taking into account the current configuration of the SLA, including filters, offline window, etc.

In the report, you will find the following information:

- The monitored service.

- The start and end time of the period represented in the report.

- The total affected time, i.e. the actual total duration of all alarms that occurred in the indicated time span, without corrections.

- The total violation time, i.e. the total duration of all SLA violations that occurred in the indicated time span.

- The minimum availability, i.e. the percentage of time that must be without violations in order for the SLA not to be breached.

- The measured availability, i.e. the percentage of time that the SLA was without violations.

- The deviation, i.e. the difference between the minimum and the measured availability (deviation = measured - minimum availability).

- The number of violations.

- Offline window information.

- Information on filters, if any have been set.

- Outage information: start and end time, duration weight, alarm information.

## Status

In this tab, you will find an overview of all the information pertaining to the SLA, as you would otherwise find by opening the SLA itself.

## Parameter

In this tab, you can generate reports for a particular parameter. To do so, simply select the parameter in the drop-down list.

## Top

In this tab, you can see a list of the 10 parameters that had the most alarm events in a given time span. Determine the time span with the drop-down list at the top of the window.

## Trending

In this tab, you can generate a graph that shows the evolution of a chosen parameter over a particular time period.

Choose the parameter and time period with the drop-down lists at the top of the screen.
