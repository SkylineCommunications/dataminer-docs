---
uid: Connector_help_Generic_Sun_Outage
---

# Generic Sun Outage

This connector monitors possible sun outages based on the position and orientation of an earth station. It can also show when the next outages are likely to occur.

## About

Based on the position and orientation of an earth station and the current UTC date and time, an outage angle is calculated to determine if there is a possibility of sun interference on the communication between the earth station and the satellite.

Earth stations can be fixed or steerable, and in the latter case the orientation is updated based on another element via element subscriptions.

> [!NOTE]
> The Generic Sun Outage connector is based on requirements and calculations provided by other clients and is designed to provide approximate, best-effort notifications and estimates of when a sun outage may occur.

### Version Info

| **Range**     | **Description**                                                                             | **DCF Integration** | **Cassandra Compliant** |
|----------------------|---------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                            | No                  | Yes                     |
| 1.0.1.x              | Implemented logic that allows dynamic adding of earth stations and satellites via CSV file. | No                  | Yes                     |
| 1.0.2.x \[SLC Main\] | Changed the primary key for the Outages table to be numerical.                              | No                  | Yes                     |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page displays an overview of the earth stations and satellites monitored by this connector, with the parameters **Monitored Stations**, **Active Outages**, and **Satellites.**

### Earth Stations

This page displays an overview of all the configured earth stations, with their position, their orientation and the current outage angle.

Via the **New Earth Station** page button, you can add a new earth station. To do so:

- Specify an **identifiable description** and **location**, as well as the **frequency band** and **dish size**.
- For fixed earth stations, fill in the **latitude and longitude** of the earth station and the **longitude for the satellite**.
  For steerable earth stations, configure the **latitude and longitude** of the earth station and the **protocol** and **element** that will be subscribed to for orientation changes.

Via the **Outage Overview** column in the Earth Station table, you can **add or remove** earth stations in the tree control on the **Outage Overview** page. Refer to the **Tree Control Config section** for more information.

Note: **Latitude and longitude** are determined **based on the compass direction**. For latitude, deg N represents positive values and deg S represents negative values. For longitude, deg E represents positive values and deg W represents negative values.

### ES Subscribers

This page displays an overview of all the configured earth station subscribers. It shows the protocol **Name**, the **Version**, and the parameter IDs used to calculate the sun outage, such as the **Azimuth**, **Elevation**, and **Satellite** parameters. The subscribers are used to retrieve the orientation changes for steerable earth stations.

Via the **New ES Subscriber** page button at the bottom of the page, you can add a new earth station subscriber.

### Satellites

On this page, you can configure geostationary satellites that can be used to determine the azimuth and elevation values of fixed earth stations.

Via the **Add New Satellite** page button at the bottom of the page, you can add a satellite by entering the **Name,** **Longitude**, and **Longitude Direction**

Note: **Longitude** is determined **based on the compass direction**. Longitude deg E represents positive values and deg W represents negative values.

### Outages

This page displays a table with all the predicted future outages for the configured earth stations, which includes the following information:

- Earth station description and location parameters
- Satellite
- Outage start and end date and time (**UTC time**)
- Time until the outage occurs

The outage information can be updated with the **Update** button below the table.

### Outage Overview

On this page, a tree control is available. Per configured earth station, it displays an entry with all the relevant information, including a table with the corresponding future outages.

Note that the tree control **does not contain any configurable parameters.**

### Configuration

This page contains all the configuration parameters that are related to the functionality of the connector. The page consists of two main functionality sections: **General Settings** and **Tree Control Config.**

#### General Settings

In this section, you can enable or disable three different pages: **Earth Stations Config**, **Satellites Config**, and **Tree Overview Info**. The page also includes the page button for **Outage Config.**

- **Earth Stations Config:** This subpage consists of two main sections:

  - **Earth Stations Config**: Contains the parameters that allow you to configure **automatic polling** of **earth stations** via a **CSV file**. In this section, you can enable or disable the **Update Status**, which enables or disables automatic polling, you can specify the path where the CSV file can be found, and you can also set the timer for how frequently the Earth Station table will be updated via the CSV file. This section also displays the status of the earth station retrieval process. With the **Apply** button, you can manually poll the earth stations from the CSV at any time.

  - **Earth Stations Options**: This section includes a number of configuration parameters that make the protocol more robust:

    - **Reflection Mode**: This parameter determines how the table will be updated. There are three modes:

      - *Manual*: This mode does not override the data in the table with that from the CSV file and does not update the CSV file with manually added entries from the table. This means that all data is kept in the table, but there is no sync operation.

      - *Auto Delete*: This mode overrides the Earth Stations Overview table with the data from the CSV file every time the import logic is applied. **This is the default mode**.

      - *Auto Sync*: This mode keeps the data in the Earth Stations Overview table and the CSV file in perfect sync. This means that the file and table data will mirror each other at all times.

    - **Auto Delete Delay**: This parameter is associated with the "Auto Delete" reflection mode. This allows you to delay the time when a record in the table is removed after it is no longer present in the CSV file. ***Real-time* is the default value**.

    - **Delete All Removed**: Performs a one-time sweep through the Earth Stations Overview table and deletes all earth stations that are not present in the CSV file.

    - **Sync All Data**: Performs a one-time sweep through the Earth Stations Overview table and the CSV file and syncs all the data so that the file and the table mirror each other.

- **Satellites Config**: This subpage consists of two main sections:

- **Satellites Config**: Contains the parameters that allow you to configure **automatic polling** of **satellites** via a **CSV file**. In this section, you can enable or disable the **Update Status**, which enables or disables automatic polling, you can specify the path where the CSV file can be found, and you can also set the timer for how frequently the satellites table will be updated via the CSV file. This section also displays the status of the satellite retrieval process. With the **Apply** button, you can manually poll the satellites from the CSV at any time.

  - **Satellites Options**: This section includes a number of configuration parameters that make the protocol more robust:

    - **Reflection Mode**: This parameter determines how the table will be updated. There are three modes:

      - *Manual*: This mode does not override the data in the table with that from the CSV file and does not update the CSV file with manually added entries from the table. This means that all data is kept in the table, but there is no sync operation. **This is the default mode**.

      - *Auto Delete*: This mode overrides the Satellites Overview table with the data from the CSV file every time the import logic is applied.

      - *Auto Sync*: This mode keeps the data in the Satellites Overview table and the CSV file in perfect sync. This means that the file and table data will mirror each other at all times.

  - **Auto Delete Delay**: This parameter is associated with the "Auto Delete" reflection mode. This allows you to delay the time when a record in the table is removed after it is no longer present in the CSV file. ***Real-time* is the default value.**

  - **Delete All Removed**: Performs a one-time sweep through the Satellites Overview table and deletes all satellites that are not present in the CSV file.

  - **Sync All Data**: Performs a one-time sweep through the Satellites Overview table and the CSV file and syncs all the data so that the file and the table mirror each other.

- **Tree Overview Info**: This page contains the information that is used on the **Outage Overview page**, in the **Earth Stations table** and in the **Outages Table**. Only **earth stations** that are **enabled** will be displayed in this table, and only the **outages** for those earth stations will be displayed in the **Outages Table** on this page. For more information on the Outage Overview, refer to the Tree Control Config section below.

- **Outage Config**: This subpage allows you to configure the following settings:

  - **Visibility Threshold**: The earth station elevation value below which it is considered not to have visibility on a given satellite. (By default 0§.)

  - **Number of Cycles**: The number of equinoxes for which the future outages should be calculated. (By default 2.)

#### Tree Control Config

This section allows you to configure the following settings:

- **Overview**: Allows you to **enable/disable** the ability to add **earth stations** to the **Earth Stations Tree Control** table (on the **Tree Overview Info** page).
- **Disable All:** This button sets all cells in the Outage Overview column in the Earth Station table to *Disabled*, effectively removing the earth stations from the **Earth Stations Tree** table.
- **Enable All:** This button sets all cells in the Outage Overview column in the Earth Station table to *Enabled*, effectively adding the earth stations to the **Earth Stations Tree** table.
- **Overview Limit:** Allows you to specify how many rows can be added to the **Earth Stations Tree table.**
