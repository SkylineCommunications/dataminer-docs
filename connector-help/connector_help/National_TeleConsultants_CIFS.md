---
uid: Connector_help_National_TeleConsultants_CIFS
---

# National TeleConsultants CIFS

With the **NTC CIFS** connector, you can monitor the state of the **SMB/CIFS mounts**.

## About

The CIFS connector periodically polls one or more SMB/CIFS mounts to retrieve status information about the share. By default, this happens every 30 seconds.

## Installation and configuration

### Creation

This connector uses a virtual connection and does not need any user input.

## Usage

### CIFS Shares

On this page, you can configure and **Add Filters** on **Drives** that are to be polled. The Drive is selected using **UNC-Paths**, and in the other columns the **Authentication** can be filled in.

The page contains a page button called **Export/Import**. This leads to a page where the current configuration can be **exported** into a .csv file, and where configurations can be **imported** from .csv files. Please make sure that the **Path** is filled in with a valid folder path and that it ends with the name and extension of the file.

### Disk Info

This page provides the result table of all correctly configured **Filters**. The **Total Space**, **Free Space** and **Usage** are displayed here, along with the **Total Files,** which shows the number of files that correspond with the selected filter, and the **Total Directories**, which corresponds to the number of directories under the chosen location (without taking the File Filter into account). The age of the oldest file is also displayed in the column **Oldest File Age**, indicated in minutes up till the present moment.

## Notes

- The current maximum number of filters should not exceed *200*. However, if this is insufficient, a connector modification can be done to increase this number.
- Be careful when determining the **Filter** and **Path**: make sure there are no symbolic links or mounted drives that link back to themselves to form an infinite loop. Every Filter has a time-out time of maximum 6 minutes before failing and logging an error.
