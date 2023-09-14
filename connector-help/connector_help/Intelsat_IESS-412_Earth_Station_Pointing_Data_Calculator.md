---
uid: Connector_help_Intelsat_IESS-412_Earth_Station_Pointing_Data_Calculator
---

# Intelsat IESS-412 Earth Station Pointing Data Calculator

This connector can be used to calculate the position of a spacecraft or satellite, as well as the direction towards any selected spacecraft or satellite that an earth station is pointing. The calculation method is based on the 11 parameters approximation method as specified by the IESS-412 document/specification. The position is calculated in terms of the azimuth and elevation for a certain antenna, satellite and sites.

## About

All configuration data that is needed for the calculations can be retrieved by CSV imports or can be manually entered using the context menu of the tables.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Sites

This page displays a table listing all the sites or **ground stations**. For each site, the **Latitude**, **Longitude** and **Height Above Sea Level** are mentioned**.**

Sites can be added and removed via the context menu of the table or via CSV import. This is the header of the CSV file: Site;Latitude;Longitude;Height Above Sea level.

### Satellites

This page displays a table listing all the **Satellites** the system has access to. The table contains the following information: **Satellite Name, I11 File Name, Epoch time, I11 Data valid Until, Time Since Last Update,** **Latitude** and **Longitude.**

Satellites can be added and removed via the context menu of the table or via CSV import. This is the header of the CSV file: Satellite;i11FileName.

It is important to configure the correct **I11 File Name** for each satellite in this table. The file location or path where the connector looks for these I11 files can be specified below the table (**I11 File Location**). When the configured I11 File Name is found in that location, the remaining parameters in the table (I11 Data Set Valid until, Time Since Last I11 File Update, Latitude and Longitude) will automatically be calculated and displayed as long as the I11 file is valid. In case the file is no longer valid, "NA" will be displayed.

### Antennas

This page displays a table listing all the **Antennas**. For each antenna, the **Site** where the antenna is located and the **Satellite** it is pointed at should be configured. When this is done, and as long as the I11 file for the satellite is still valid, the **Azimuth and Elevation** parameters are calculated. When a site is removed or a satellite is removed, "Not Found" will be displayed in the corresponding column for the antenna.

Antennas can be added and removed via the context menu of the table or via CSV import. This is the header of the CSV file: Antenna;Site;Satellite

This page contains one page button:

- **Import Errors**: Opens a subpage displaying all the antenna import errors and the reason why they were not set correctly.
