---
uid: Connector_help_VOO_Scheduler
---

# VOO Scheduler

The **VOO Scheduler** creates and monitors **scheduler tasks**.

## About

This connector creates **scheduler tasks** based on a CSV file and keeps track of them by using a default **Automation script**.

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

## Usage

### General

This page displays the general settings and provides an overview of the imported CSV file.

The **Error Logging File Path** folder contains .txt files in the format *\<CSV File Name\>-Error.txt* with information about why a CSV file has not been imported.

The parameter **Occultation Max Time Duration** determines the maximum timespan between the start and stop Automation script. When the CSV file contains at least one entry that has a greater time span, the file will not be imported and no tasks will be created.

### Active Tasks

This page shows an overview of all tasks that are scheduled or ongoing.

### History Tasks

This page shows an overview of all tasks that have been finished or removed.

## Notes

### Automation Script

This connector uses **automation script VOO Task Scheduler**.

### CSV File

The CSV file must contain at least 2 lines: a header line and a date line.

#### Header

RefOccultation;Channel;Date Debut;Heure Debut;Date Fin;Heure Fin;Script Debut;dummy element 1\dummy element 2...;Script Fin;dummy element 1...

The header is fixed, with the exception of the Automation script dummy elements. Those must be equal to the Automation script that contains the most dummy elements.

#### Data

- **RefOccultation:** Line number starting from 1.
- **Channel:** Channel name.
- **Date Debut:** Date when the first Automation script will be executed in format yyyy/MM/dd.
- **Heure Debut:** Hour when the first Automation script will be executed in format HH:mm:ss.
- **Date Fin:** Date when the last Automation script will be executed in format yyyy/MM/dd.
- **Heure Fin:** Hour when the last Automation script will be executed in format HH:mm:ss.
- **Script Debut:** Name of the first Automation script that needs to be executed.
- **Dummy element 1\\..:** Name of the dummy elements that the first Automation script will use. Fill in *NA* when there are no elements on a certain position.
- **Script Fin:** Name of the last Automation script that needs to be executed.
- **Dummy element 1\\..:** Name of the dummy elements that the last Automation script will use. Fill in *NA* when there are no elements on a certain position.

#### Verification

Before the **VOO Scheduler** will create the tasks mentioned in the CSV file, it will be validated based on the points below:

- All fields must be filled in and the data format must be correct.
- The start date/time must be lower than the end date/time and have a minimum offset of 5 minutes in the future since the import button was pressed.
- The difference between start and end date/time must be lower than the **Occultation Max Time Duration**.
- The CSV file name must be unique.
- The CSV file may not contain any duplicate entries or already scheduled tasks with the same data.
