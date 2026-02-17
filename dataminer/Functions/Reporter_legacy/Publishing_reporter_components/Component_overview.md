---
uid: Component_overview
---

# Component overview

This section contains an overview of the Reporter components you can publish on a website:

- [Alarm distribution graph](#alarm-distribution-graph)

- [Alarm states vs. alarm count scatter graph](#alarm-states-vs-alarm-count-scatter-graph)

- [Alarm states pie graph](#alarm-states-pie-graph)

- [Alarm states time line](#alarm-states-time-line)

- [Alarm types pie graph](#alarm-types-pie-graph)

- [New alarm count graph](#new-alarm-count-graph)

- [Spectrum monitor buffer](#spectrum-monitor-buffer)

- [Spectrum monitor traces](#spectrum-monitor-traces)

- [Trend graph](#trend-graph)

## Alarm distribution graph

A graph showing the alarm distribution in a particular time range.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

Alarm distribution graph of an element:

```txt
createAlarmDistributionUrl(element, distriType, avgType, width, height, distriTypeParam, view)
```

Alarm distribution graph of a service:

```txt
createServiceAlarmDistributionUrl(service, distriType, avgType, width, height, distriTypeParam, view)
```

### Parameters

| Parameter       | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
|-----------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| element         | The name of the element.<br> Set to *ALL_ELEMENTS* to view the total distribution for all elements.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| service         | The ID of the service. Format: *DmaID/ServiceID*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| distriType      | The type of graph. Default: *DISTRIBUTION_DAY*<br> -  If distriType is set to *DISTRIBUTION_GIVEN_WEEKDAY*, *distriTypeParam* can hold a number from 1 to 7 (1 equals Sunday).<br> -  If distriType is set to *DISTRIBUTION_GIVEN_MONTHDAY*, *distriTypeParam* has to be set to the day number. The current date decreased with one month will be taken as day number 1. As a result, this is limited to 31 days.<br> See also: [Alarm distribution graph types](xref:Constants#alarm-distribution-graph-types) |
| avgType         | The average type.<br> See also: [Time period](xref:Constants#time-period)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| width           | The width of the graph (optional, default: 300 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| height          | The height of the graph (optional, default: 220 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| distriTypeParam | The day to be shown if *distriType* is set to *DISTRIBUTION_GIVEN_WEEKDAY* or *DISTRIBUTION_GIVEN_MONTHDAY*.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| view            | The name of view by which to filter the data.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |

## Alarm states vs. alarm count scatter graph

A graph showing a comparison of the different alarm events versus the alarm states.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

```txt
createAlarmScatterUrl(width, height, state, view)
```

### Parameters

| Parameter | Description                                                                             |
|-----------|-----------------------------------------------------------------------------------------|
| width     | The width of the graph (optional, default: 300 px).                                     |
| height    | The height of the graph (optional, default: 220 px).                                    |
| state     | The alarm state filter.<br> See also: [Alarm severities](xref:Constants#alarm-severities) |
| view      | The name of view by which to filter the data.                                           |

## Alarm states pie graph

A graph showing what percentage of the time an element or a service was in each of the alarm states.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

Alarm states pie graph for an element:

```txt
createAlarmStatesUrl(element, width, height, span)
```

Alarm states pie graph for a service:

```txt
createServiceAlarmStatesUrl(service, width, height, span)
```

### Parameters

| Parameter | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| element   | The name of the element.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| service   | The ID of the service. Format: *DmaID/ServiceID*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| width     | The width of the graph (optional, default: 300 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| height    | The height of the graph (optional, default: 220 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| span      | Time span.<br> Possible values (strings):<br> -  *DAY* (last 24 hours)<br> -  *HOUR* (last hour)<br> -  *12HOURS* (last 12 hours)<br> -  *WEEK* (week to date)<br> -  *MONTH* (month to date)<br> -  *PREVMONTH* (previous month)<br> -  *YESTERDAY* (yesterday)<br> -  *YEAR* (year to date)<br> Note: When the span argument is omitted or empty, *DAY* will be used by default. |

## Alarm states time line

A graph showing a time line with the most severe alarm states of an element or a service during the last 24 hours.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

Alarm states time line for an element:

```txt
createTimelineUrl(element, width, height, span)
```

Alarm states time line for a service:

```txt
createServiceTimelineUrl(service, width, height, span)
```

### Parameters

| Parameter | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| element   | The name of the element.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| service   | The ID of the service. Format: *DmaID/ServiceID*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| width     | The width of the graph (optional, default: 300 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| height    | The height of the graph (optional, default: 220 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| span      | Time span.<br> Possible values (strings):<br> -  *DAY* (last 24 hours)<br> -  *HOUR* (last hour)<br> -  *12HOURS* (last 12 hours)<br> -  *WEEK* (week to date)<br> -  *MONTH* (month to date)<br> -  *PREVMONTH* (previous month)<br> -  *YESTERDAY* (yesterday)<br> -  *YEAR* (year to date)<br> Note: When the span argument is omitted or empty, *DAY* will be used by default. |

## Alarm types pie graph

A graph showing the amount of new alarms of an element or a service, grouped by alarm severity.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

Alarm types pie graph for an element:

```txt
createNewAlarmsUrl(element, width, height, span)
```

Alarm types pie graph for a service:

```txt
createServiceNewAlarmsUrl(service, width, height, span)
```

### Parameters

| Parameter | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| element   | The name of the element.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| service   | The ID of the service. Format: *DmaID/ServiceID*                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| width     | The width of the graph (optional, default: 300 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| height    | The height of the graph (optional, default: 220 px).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| span      | Time span.<br> Possible values (strings):<br> -  *DAY* (last 24 hours)<br> -  *HOUR* (last hour)<br> -  *12HOURS* (last 12 hours)<br> -  *WEEK* (week to date)<br> -  *MONTH* (month to date)<br> -  *PREVMONTH* (previous month)<br> -  *YESTERDAY* (yesterday)<br> -  *YEAR* (year to date)<br> Note: When the span argument is omitted or empty, *DAY* will be used by default. |

## New alarm count graph

A bar graph showing the top X worst elements based on either alarm state or alarm amount.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

Top X of the worst elements based on alarm state:

```txt
createTopStatesUrl(amount, width, height, view, state)
```

Top X of the worst elements based on alarm amount:

```txt
createTopNewUrl(amount, width, height, view, state)
```

### Parameters

| Parameter | Description                                                                             |
|-----------|-----------------------------------------------------------------------------------------|
| amount    | The maximum number of devices to be displayed in the graph.                             |
| width     | The width of the graph (optional, default: 300 px).                                     |
| height    | The height of the graph (optional, default: 220 px).                                    |
| view      | The name of view by which to filter the data.                                           |
| state     | The alarm state filter.<br> See also: [Alarm severities](xref:Constants#alarm-severities) |

## Spectrum monitor buffer

The image of the most recent spectrum analyzer trace that was measured by a particular spectrum analyzer monitor script.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

```txt
createSpectrumBufferUrl(element, width, height, monitor, traceId)
```

### Parameters

| Parameter | Description                                                                                        |
|-----------|----------------------------------------------------------------------------------------------------|
| element   | The name of the element.                                                                           |
| width     | The width of the graph (optional, default: 600 px).                                                |
| height    | The height of the graph (optional, default: 450 px).                                               |
| monitor   | The ID of the spectrum monitor (which is displayed when you edit the monitor).                     |
| traceId   | The ID of the trace.<br> Format: measurementpointName>traceName (as defined in the monitor script) |

## Spectrum monitor traces

The image of the spectrum analyzer trace that was measured by a particular spectrum analyzer element at the time the image was requested.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

```txt
createSpectrumRTUrl(element, width, height, measpt, preset)
```

### Parameters

| Parameter | Description                                                                                                                                                                                                                                                                                                         |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| element   | The name of the element.                                                                                                                                                                                                                                                                                            |
| width     | The width of the graph (optional, default: 600 px).                                                                                                                                                                                                                                                                 |
| height    | The height of the graph (optional, default: 450 px).                                                                                                                                                                                                                                                                |
| measpt    | The ID of the measurement point.<br> -  You can find the measurement point IDs in the [measurement point configuration window](xref:Configuring_measurement_points#the-measurement-point-configuration-window).<br> -  Use -1 when no measurement point needs to be used. |
| preset    | The name of the public preset to be used.<br> Instead, you can also specify an inline preset definition. See [Inline preset definition](#inline-preset-definition)                                                                                                                                                  |

### Example of a generated URL

```txt
http://ipAddress/reports/graphs/SpectrumRT.asp?
element=element&
measpt=-1&
preset=inline:freqstart:450000;freqstop:500000000
```

### Inline preset definition

Syntax:

```txt
inline:property1:value1;property2:value2;...
```

Property names

- amountPoints

- detectMode

- firstMixerInput

- freqCenter (Hz)

- freqSpan (Hz)

- freqStart (Hz)

- freqStop (Hz)

- inputAtten

- preamp

- scaleType

- sweep (default: auto)

- rbw (default: auto)

- refLevel (default: 0 dBm)

- refScale (default: 10)

- vbw (default: auto)

> [!NOTE]
> When you specify an inline preset definition, you have to define at least the following properties:
> - freqStart and freqStop, or
> - freqCenter and freqSpan.

## Trend graph

A graph showing trending information for a particular parameter.

> [!NOTE]
> When an error occurs (e.g., no data available), a redirect to *nograph.gif* will occur.

### Syntax

```txt
createTrendGraphUrl(element, param, trendType, width, height, showMinMax)
```

### Parameters

| Parameter  | Description                                                                                                                                                                                                                                                     |
|------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| element    | The name of the element.                                                                                                                                                                                                                                        |
| param      | The ID of the parameter.                                                                                                                                                                                                                                        |
| trendType  | The type of trend graph. Default: TREND_HOUR<br> See also: [Trend graph types](xref:Constants#trend-graph-types)                                                                                                                                                  |
| width      | The width of the graph (optional, default: 300 px).                                                                                                                                                                                                             |
| height     | The height of the graph (optional, default: 220 px).                                                                                                                                                                                                            |
| showMinMax | Whether or not the graph has to show minimum and maximum values:<br> -  1 = Show minimum and maximum<br> -  0 = Only show average |
