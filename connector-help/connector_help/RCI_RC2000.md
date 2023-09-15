---
uid: Connector_help_RCI_RC2000
---

# RCI RC2000

The RCI RC2000 is a Satellite Antenna Controller that allows a dish to find and track a satellite for communication.

## About

With this connector you can monitor and manipulate the antenna using Azimuth, Elevation, Polarisation, and Rotating Feed.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Bus address**: The bus address of the device.

## Usage

### Main View

The Main View page contains all monitored information about a currently tracked satellite. This includes but is not limited to: **Satellite Name and Position, Azimuth , Elevation and Polarization Movement, Azimuth, Elevation, Polarotor and Rotating Feed Position** and **Tracking Voltage.**

### General

This page is very similar to the Main View page but includes an **Alarm Status** and three page buttons with additional information:

- **Device Info**
- **Normalize Alarms**
- **List Satellites**

### Move Position

On this page, you can move the antenna to different satellites or reset the antenna. This can be done in various ways, which are available through different page buttons:

- **Satellite Name:** Point the antenna to a preset satellite using the defined **Satellite Name**. A **Preset table** with preconfigured satellites can also be created in the connector, which will perform a manual set of the Polarisation after automatic movement of the antenna through a satellite name.

  Please note that only the **Polarisation** is used as an extra set if **Preset Table Usage** is enabled, other data in the Preset table (position, azimuth, elevation) are currently only supplied by way of information, not as configuration settings.

  - **Importing from an Excel** file requires the file to have a fixed structure.

    - **Column C** should contain a **formatted name** for the satellite.
    - **Column D** should contain the **Position Value** for the satellite.
    - **Column E** should contain the **Directional Part** of the Position (N, E, S, W).

  - Enter the complete path to the file in the **Excel Path** parameter.

  - Enter the name of the sheet that contains the table with satellite data (only a single sheet can be imported, make sure all necessary data is gathered in one table). The parameter **Excel Sheetname** should hold this name.

  - Enter the columns in this spreadsheet table that contain the **Azimuth, Elevation and Polarisation** (in that order) (default:*MNO*). The **Parabole Columns (Az, El, Pol)** should hold this value.
    For example: *MNO* means:

    - **Column M** contains the **Azimuth.**
    - **Column N** contains the **Elevation.**
    - **Column O** contains the **Polarisation.**

- **Azimuth/Elevation:** Move the antenna by manually entering **Azimuth and Elevation.**

- **Rotating Feed:** Move the antenna by manually rotating the antenna.

- **Polarotor:** Move the antenna by manually changing the **Polarotor Position.**

- **Jog Antenna:** Move the antenna by Indicating a **Jog Direction, Speed and Duration**.

### External Presets

On this page, you can set a **Preset Azimuth, Delta Azimuth, Preset Elevation and Delta Elevation.**
