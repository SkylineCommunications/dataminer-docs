---
uid: Connector_help_SES_S.A._Antenna_Position_Checker_Service_Definition
---

# SES S.A. Antenna Position Checker Service Definition

The **SES S.A. Antenna Position Checker Service Definition** is a service definition that can be used to monitor the position of antennas.

## About

The **SES S.A. Antenna Position Checker Service Definition** allows the user to monitor the azimuth and elevation deviation of an antenna. The service calculates the deviation by comparing the real position of the antenna with the theoretical position.

The real position is obtained from a **SatService sat-nms MNC** or **Intorel Visionic** element that monitors the antenna, whereas the theorical position is retrieved from the **Intelsat IESS-412 Earth Station Pointing Data Calculator** element.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Usage

### General

This page displays the **Elevation Deviation** and **Azimuth Deviation** of the antenna. These parameters are calculated by subtracting the theoretical position of the antenna from the real position.

The theoretical elevation and azimuth values are retrieved from the **Antenna Table** of the **Intelsat IESS-412 Earth Station Pointing Data Calculator** element. This table also displays the **ACU** column, which indicates the Antenna Controller Unit that contains the real position of the antenna. The real elevation and azimuth values are obtained from the **Antenna Controllers Table** of the **SatService sat-nms MNC** element or **Parameter Table** of the **Intorel Visionic** element that is monitoring the antenna.

The page also contains the **Service Severity** parameter, which displays the current alarm state of the service.

### Elements

This page contains the **Service Element Status Table**, which displays information about the element that are included in the service.
