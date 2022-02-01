---
uid: Service_reports
---

# Service reports

To view report information on the *Service* page, you first have to select a service. You can still select a different service afterwards by clicking *CHANGE* to the right of the service name in the header.

The *Service* page contains 5 tabs:

| Tab          | Description                                                                                                                                                                                                                                                                                                                                                                                                                                     |
|--------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Summary      | Shows service information and any annotations for the service.                                                                                                                                                                                                                                                                                                                                                                                  |
| Distribution | An alarm distribution graph that can be set to include particular severities in a particular time range. You can choose to show data from the *Last 24 Hours*, *Yesterday*, a *Week to Date* or a *Month to Date*. Depending on the selected time range, you can also choose an average range to show in the graph. |
| Severities   | Overview of alarm events and alarm states, in a selected time range. For the time range, a wide range of options is available, including a custom time range.                                                                                                                                                                                                                                                                                   |
| Alarms       | Lists all active alarms on the service.                                                                                                                                                                                                                                                                                                                                                                                                         |
| History      | Overview of alarms in a custom time range. It is possible to include only certain severities and alarm types. You can also filter on parameter name, using wildcards if necessary.                                                                                                                                                                                                                                                              |
| Top          | Overview of the elements that generated the most alarms in a selected time range. For the time range, a wide range of options is available, including a custom time range.                                                                                                                                                                                                                                                                      |

To go directly to the report types above, use the following URLs, replacing \[MyDataMiner\] with the hostname or IP of your DMA.

| Report type  | URL                                                                           |
|--------------|-------------------------------------------------------------------------------|
| Summary      | http://\[MyDataMiner\]/Reports/Service.asp?service=\[ServiceID\]              |
| Distribution | http://\[MyDataMiner\]/Reports/Service-Distribution.asp?service=\[ServiceID\] |
| Severities   | http://\[MyDataMiner\]/Reports/Service-Alarms.asp?service=\[ServiceID\]       |
| Alarms       | http://\[MyDataMiner\]/Reports/Service-ActiveAlarms.asp?service=\[ServiceID\] |
| History      | http://\[MyDataMiner\]/Reports/Service-History.asp?service=\[ServiceID\]      |
| Top          | http://\[MyDataMiner\]/Reports/Service-TopParams.asp?service=\[ServiceID\]    |

> [!NOTE]
> For the service history report, you can determine the time span for the report in two ways:
> - By specifying the history duration (in hours), e.g. *http://\[MyDataMiner\]/Reports/Service-History.asp? action=gethistory&service=\[Service ID\]&history-duration=\[Number of hours\]*
> - By specifying the history start and end time, e.g. *http://\[MyDataMiner\]/Reports/Service-History.asp? action=gethistory&history-start=\[start time\]&history-end=\[end time\]&service=\[Service ID\]*
>
