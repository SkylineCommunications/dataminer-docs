---
uid: Connector_help_Sydney_Trains_GPS_Tracking
---

# Sydney Trains GPS Tracking

The **Sydney Trains GPS Tracking** connector reads out one of the **XML** files with **GPS** information about the trains and sends the announcements that should be made to the **Sittig DVA** interface.

## About

There are 2 XML files that are used by this connector to check when an announcement should be made in which station:

- **Real time running file**: is the prefered file to use, but is only when it has been updated within the last 10 minutes
- **Station time table file**: is used when the real time running file was not update in the last 10 minutes

Both files are the same format, but the real time running file can contain extra information about delays etc.
The **Sydney Trains GPS Tracking** connector will read these files and will send an announcement request to the Sittig DVA interface when:

- A train arrives to a station in the **next 20 minutes**
- A train arrives to a station in the **next 10 minutes**
- **Every 10 minutes** until a train has left the station

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Sittig DVA v0202            |

## Installation and configuration

### Creation

#### Smart-Serial Main connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: *localhost* (DataMiner acts as server)
  - **IP port**: \[The DataMiner IP port used by Sittig DVA to send requests to. *Default 7531*.\]

### Configuration of files

Before the connector can start reading the files, they first need to be configured. The entire **path** to the file needs to be specified for the connector to be able to read the file.

The files need to be configured on the **Configuration** page:

- **Static Timetable File**
- **Real Time Running File**

If there are any errors reading the files, then this error will be displayed in the **status** of each file. Note that the connector will always try to first read and process the real time file, before trying the static one.

### Configuration of stations

All **stations** that are read out from the XML files, are added to the **Stations** table (Stations popup accessible via **Configuration** page). When a station is first found, it will be added to the table, but will be *disabled*, meaning that no announcements will be made to that station. To enable it, **Supported** needs to be set to true and the **Acronym** should also be configured, because that is used by the **Sittig DVA** to actually schedule the announcement for the correct station.

### Configuration of muting

It's possible to **mute certain services**, either for the *current day* only or *open dated* (until it's manually cleared). This can be configured on the **Configuration** page.

Entries can be added by **right-clicking** in the table.

## Usage

### Announcements

The **Announcements** table contains all announcements that were recently sent to the **Sittig DVA**. The **Move Announcement To History After** parameter can be used to configure when the announcements should be moved from the **Announcements** table to the **Announcements History** table.

The **Announcements History** table can be accessed via the button at the bottom of the **Announcements** page. The **Remove Announcement From History After** page can be used to **permanently remove** an announcement from the **Announcements History** table.

### Connection

The **Connections** page displays the **state** of the connection to the Sittig DVA.

### Configuration

The **Configuration** page is used to configure the files, stations and some extra configurations available in the connector.
