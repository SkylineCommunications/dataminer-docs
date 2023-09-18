---
uid: Connector_help_Generic_DataMiner_Log_Reader
---

# Generic DataMiner Log Reader

The Generic DataMiner Log Reader protocol is a DataMiner connector that is used to analyze DataMiner logs and check if a log does or does not contain a specific string.

## About

This is a virtual DataMiner connector that was developed to analyze DataMiner logs. The connector searches through a configurable list of DataMiner logs and checks whether a certain string is present in the log files during a certain period of time. Depending on the configuration, it can raise an alarm if the string is or is not present. The log file, the filter and the maximum or minimum age of the filter string in the log file can be configured.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page contains two main tables: **String Found Alarm Table** and **String Missing Alarm Table**. Both tables have a similar set of columns: **Display Key**, **Log File**, **Filter**, **Age**, **Timestamp**, **Alarm** and **Counter**.

To add or remove entries to and from these tables, a context menu can be used. For each entry, the **Log File** to analyze must be specified, along with the **Filter** string and the maximum or minimum **Age** of the string in the log file. To specify the log file, you can select one of the main DataMiner logs from the drop-down list or insert the full path to a custom log file.

Depending on the table in which the entry is added, an **Alarm** will be raised if the string is or is not present in the log during the specified window of time.

The **Counter** field displays the total number of occurrences of the string in the log file.

This page also includes a configurable **Interval**, which determines the number of minutes between two successive log analyses, and the **Last Update** parameter, which shows the timestamp of the last log analysis.

## Revision History

DATE VERSION AUTHOR COMMENTS
24/05/2018 1.0.0.1 AIG, Skyline Initial version
