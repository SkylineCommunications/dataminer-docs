---
uid: Connector_help_National_TeleConsultants_Activity_Tracking_Report
---

# National TeleConsultants Activity Tracking Report

This connector retrieves information from the database about the actions performed by users on the current alarms, and generates **manual** or **automated** reports according to some configurable parameters. In order to correctly schedule the automated **reports**, an automation script has to be created (can be downloaded along with the connector).

## About

The connector uses SLNet calls to run an SQL query with configurable parameters that either outputs as a table that can be exported to a .CSV file or to a .CSV directly via an automation. The connector allows to configure the list of DMAs that will be monitored (in case of a cluster) and the list of users and actions that will be included in the report.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| **Range** | **Device Firmware Version**           |
|------------------|---------------------------------------|
| 1.0.0.x          | DataMiner db schema for version 8.5.x |

## Installation and configuration

### Creation

There's no need of any kind of special configuration while creating the element. The connection information and other misc params shall be provided later.

### Configuration of ...

The minimum information necessary to run any report is the list of DMAs to be monitored. This is located in the **Configuration** page. You can add the ids of the DMAs, plus, optionally a description. The particular report parameters such as actions/users to be considered and start and end dates can be configured in the pages **Manual** and **Automated Report**, as described later on.

## Usage

Manual Report

This page allows you to generate a report **on demand** and export it to .CSV. It's required that you input the start and end date of the report and (optionally) the actions and users to be searched. If you leave the latter blank, all users or actions will be queried. To add new entry to users and actions tables, right click on them an select the add action. The results will be displayed on the **Manual Report Results** page (so you can see the table full-width). If you want to export the results, the **Report File Name** parameter should be filled with a valid location.

Manual Report Results

This page shows the results of a manually generated report. You can also see the problems (if any) during the generation.

Automated Report

Allows you to schedule a new report. Since **its execution is periodic**, there's no a fixed end date, but a placeholder instead and a timespan calculated from that placeholder. You can also choose if the timespan is measured in days or hours. You can customize the configuration parameters of the schedule task that will be created (and you can edit at any time in the **DM's Automation** section). It's important to note that the automation script included with the protocol is installed first, and its name matched with the one provided by the user in this page. The output reports will be created according to the **Automated Report Location** path set in the page **Configuration**.

Configuration

This page allows you to configure the DMAs to be monitored and the location of the files corresponding to the automated reports.

Queue

Shows the queue of pending reports to be generated. You can delete reports from the queue.

## Notes

The **automated reports** are created in the path set in the **Configuration** page using the prefix *automatic_report\_* and the time of execution. Watch the log files for potential problems periodically.
