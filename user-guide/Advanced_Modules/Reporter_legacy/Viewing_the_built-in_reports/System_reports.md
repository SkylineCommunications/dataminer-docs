---
uid: System_reports
---

# System reports

The *System* page consists of several tabs:

| Tab | Description |
|--|--|
| Summary | Shows an overview of your DMAs and an alarm distribution graph. Click *More Distribution Graphs* to go to the *Distribution* tab. |
| Distribution | An alarm distribution graph that can be set to include particular severities and element types, in a particular time range. You can choose to show data from the *Last 24 Hours*, *Yesterday*, a *Week to Date* or a *Month to Date*. Depending on the selected time range, you can also choose an average range to show in the graph as a reference. |
| Top | Overview of the elements that generated the most alarms and were in an alarm state for the longest period of time. The graphs can be set to include particular severities and element types, in a particular time range. For the time range, a wide range of options is available, including a custom time range. |
| Scatter | Shows a comparison of the different alarm events versus the alarm states. The graph can be set to include particular severities and element types, in a particular time range. For the time range, a wide range of options is available, including a custom time range. |
| Alarms | Lists all active alarms in your DMS. You can select to include all severities, or only some of the severity levels. |
| History | Overview of alarms in a custom time range. It is possible to include only certain severities and alarm types. You can also filter on parameter name, using wildcards if necessary. E.g. if you use the filter *CPU:s\**, only alarms for the parameter CPU with index starting with “s” will be shown. |
| Elements | Lists all elements in your DMS, each with their current alarm status, and a link to open the element card in a separate window. You can select to view all elements, or only the elements that are currently active. |
| Documents | Lists all documents available in your DMS. |
| Query | Shows a status report for a number of parameters from all elements based on a selected protocol. |
| Templates | Links to the custom report templates section. See [Creating report templates](xref:Creating_report_templates). |
| Bookings | Available on systems with the appropriate Service & Resource Management licenses. See [Booking reports](xref:Booking_reports). |

To go directly to the report types above, use the following URLs, replacing \[MyDataMiner\] with the hostname or IP of your DMA.

| Report type  | URL                                                    |
|--------------|--------------------------------------------------------|
| Summary      | http://\[MyDataMiner\]/Reports/System.asp              |
| Distribution | http://\[MyDataMiner\]/Reports/Alarms-Distribution.asp |
| Top          | http://\[MyDataMiner\]/Reports/Alarms.asp              |
| Scatter      | http://\[MyDataMiner\]/Reports/Alarms-Scatter.asp      |
| Alarms       | http://\[MyDataMiner\]/Reports/ActiveAlarms-List.asp   |
| History      | http://\[MyDataMiner\]/Reports/HistoricAlarms.asp      |
| Elements     | http://\[MyDataMiner\]/Reports/Elements.asp            |
| Documents    | http://\[MyDataMiner\]/Reports/Documents.asp           |
| Query        | http://\[MyDataMiner\]/Reports/StatusQuery.asp         |
| Templates    | http://\[MyDataMiner\]/Reports/ManageTemplates.asp     |
| Bookings     | http://\[MyDataMiner\]/Reports/SRM.asp                 |

> [!NOTE]
> On systems using a Cassandra database or equivalent, the number of alarms that can be displayed in a report is limited to 100,000.
