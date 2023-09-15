---
uid: Connector_help_Telenor_Weather_Station_Logging
---

# Telenor Weather Station Logging

The **Telenor Weather Station Logging** connector saves weather statistics and makes it possible to view them for a requested period of time.

## About

The **Telenor Weather Station Logging** connector reads in the log files from a selected directory and processes them. All the data will be stored and the user can then request that data for a selected period of time. While the parameter itself only displays the latest value received, all data is displayed in a graph when you go to the trending of the parameter.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

Before the element can retrieve information, the **User**, **Domain** and **Password** to connect to a certain location have to be filled in on the **Configuration** page. On the **Locations** page, the path where the data can be retrieved has to be specified.

## Usage

### General page

On this page, a number of parameters display information about the weather station logging. More logged data can be accessed via the four page buttons (**Tipping Bucket**, **Hail**, **Rain** and **Wind**).

### Configuration page

On this page, you can specify a local file directory to which the log files will be copied and where they will be stored. To do so, fill in the path in the **Local** **Workfolder** parameter.

You can also fill in the **credentials** to enable access to the file locations specified in the **Location** **Mapping** **Table** on the **Locations** page, as described in the "Configuration" section above.

In addition, you can specify the interval for logging data to the database, by setting the **Logging** **Time** **Interval** **parameter** to a particular value. When no value is set for this parameter, *5 minutes* will be used by default.

The **Interval** **Time** **Files** parameter can also be set. This value represents the time between two logs in a logfile, e.g. *10 seconds*.

### File Table page

With the first parameter on this page, **Number of Monitored Files**, you can configure how many files can be shown in the **File** **Table**.

The **File Table** displays information about a number of files from the selected file directory.

When you click the **Refresh Button**, the files in the **File Table** are refreshed and shown up to the number of files specified in the **Number of Monitored Files** parameter.

### Locations page

On the **Locations** page, you can add a file location by entering a location in the **Add** **New** **Location** parameter.

On this page, you can see the added file locations where the connector will get the log files, as well as set new locations. You can choose to enable or disable all locations, set the polling time, set the Max Healthy Time or remove a location.
