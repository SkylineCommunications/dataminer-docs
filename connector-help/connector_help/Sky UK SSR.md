---
uid: Connector_help_Sky_UK_SSR
---

# Sky UK SSR

This driver can be used to obtain a list of "services" (e.g. TV shows, movies, etc.), each with its own information about duration, genre, name and subtitle.

## About

### Version Info

| **Range**            | **Key Features**                                                                                        | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version**NOTE**: From version 1.0.0.5 onwards, the minimum required DataMiner version is 9.0.2. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V5                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device e.g. 10.66.53.102
- **IP port**: The IP Port of the device e.g. *80*

### Configuration

Make sure .NET 4.0 is installed. This is required for the driver to be able to function correctly.

## How to Use

If you click the **Retrieve Events** button on the **SSR** page, the driver will create an HTTP request to obtain the information through a JSON configuration and fill the SSR table with the retrieved elements. Because of the size of the data, it can take several seconds for the table to be filled after the request is sent.

The following data pages are available in the element:

- **SSR**: Contains the aforementioned SSR table and Retrieve Events button. The SSR table displays information such as the Service Key, Service Name, Start Date Time, Duration, Programme Name, Genre, SubGenre, Parental Rating, Pay Per View Wide Screen, Subtitle, Subtitle Hearing, New Show, Letterbox, Link, Blackout, Copy Protect and Sound.
- **Current Events**: Contains a table with all the current programs on each channel. If no TV channel is transmitting, the row will display "NA". There is a button to clear all the "NA" rows in the table at the same time, and a button in each row of the **Delete Event** column to delete that specific row.
- **Genre**: Allows you to define a default delay value for all genres/sub-genres. There is a button that will get all the possible Genre and Sub-Genre values and add them in a table with the default delay value. All the delays in the table are editable.
- **Sub-Genre**: Displays a table with all sub-genres and the corresponding (editable) delays.
- **Pub Service List**: Contains a table with all the sports services replicated on the Pub Service for a given day.
- **Bouquet Services**: Displays a tree view with the different services for each bouquet/sub-bouquet.
