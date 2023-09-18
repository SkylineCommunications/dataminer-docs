---
uid: Connector_help_Inmarsat_Gateway_-_Terminal
---

# Inmarsat Gateway - Terminal

This connector represents one terminal of the Inmarsat Gateway connector.

## About

This connector is **automatically generated** by the connector Inmarsat Gateway.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | API ICD V2.07               |
| 1.0.1.x          | API ICD V2.07               |
| 2.0.0.x          | API LCD V2.07               |
| 2.0.1.x          | API SDD V0.8                |

## Installation and configuration

This connector is automatically created by the parent connector Inmarsat Gateway with the corresponding range.

## Usage

### General

This is the default page of the **DVE**. It contains general information about the terminal.

### Location

This page contains all the **location metrics** for the specific terminal.

For the virtual elements, the **Average Speed** and **Heading** are displayed. These are calculated based on the **current** **and** **previous** **latitude** **and** **longitude** coordinates, which the connector receives on a regular basis.

### Beams

This page displays the **Beam ID** that the terminal is **currently** **connected** with. It also contains the **Beams Changes Table**, which contains all the changes of the beam ID, including the **time** when the beam ID has changed, the **new beam ID** and the **previous beam ID**.

### Remote Status

This page contains all the other **status metrics** for the specific terminal, such as **downstream SNR** and **upstream C/N0**.

In addition, the **Operational State Changes Table** displays all the changes of the operational state of the terminal, including the **time** when the operational state has changed, the **new** **operational state** and the **previous operational state**.

Several parameters are calculated based on retrieved data, such as **Antenna Azimuth**, **Antenna Relative Azimuth** and **Antenna Elevation**.

### Traffic Statistics

This page contains all the statistics concerning the **data traffic** for the specific terminal. It also contains the **most important SSPC data**.

### Remote Statistics

This page contains all the other statistics for the specific terminal.

### Historical Statistics

This page contains all historical statistics for the specific terminal.

### Service Plans

This page contains a table with all the **service plans** for the specific terminal.

### SSPCs

This page contains a table with all the **SSPCs** **and the status and statistics** for each **service plan**.

### Events

This page contains a table with all the events for the specific terminal.

### NSD

This page contains three tables with data retrieved via the **SSH** connection (in versions 1.0.0.x to 2.0.0.x of the connector), namely the **Virtual Routing and Forwarding Table**, **IP Interfaces Table** and **NSD Parameters Table**.
