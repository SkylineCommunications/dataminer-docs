---
uid: Connector_help_Aritech_Access
---

# Aritech Access

With this connector, it is possible to read log files from **Aritech Access** devices.

## About

The Aritech Access is a virtual connector that reads the access log file and reports that are in the last passage in each location defined in **Location** parameters.

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

### File Reader

To retrieve the formatted values from files, the path to the file has to be filled in. This is done with the page button **File Properties.** on any of the **Main View** pages.
An example of the path is *C:\Folder1\File.txt.*

## Usage

### Main View Pages

These pages display the last access logged in each location.

It is also possible to change the name of one location by pressing the page button **Set Location.** and changing the desired location.

### List Page

A list of the last lines of the log file can be found on this page. It is also possible to see how many hours ago the file was last changed in the parameter **Time in Hours of Last File Modification,** and to see how many hours ago the file last had a new log line added in the parameter **Time in Hours of Last Content Modification**.

Each file line will be read and its content will be added in the table.
