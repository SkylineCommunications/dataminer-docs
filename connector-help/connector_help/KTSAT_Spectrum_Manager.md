---
uid: Connector_help_KTSAT_Spectrum_Manager
---

# KTSAT Spectrum Manager

The KTSAT Spectrum Manager is used to automatically route an RF signal to a spectrum analyzer when alarms are raised.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **General** page, in the **Spectrum Analyzer Element** box, fill in the name of the spectrum analyzer element that should be managed by the KTSAT Spectrum Manager.

## How to Use

The **System** page displays the following tables:

- **Stations**: The list of stations defined in the system. Stations can be added or removed via the right-click menu. Each station can be linked to a preset.
- **Modems:** The list of modems available in the system. Modems can be added or removed via the right-click menu. Each modem can be associated with at most one station.
- **Correlation Rules**: The list of Correlation rules available in the system. Each rule can be associated with one or multiple modems.
- **Presets:** The list of spectrum presets defined in the system.

When a Correlation rule is triggered, the **Trigger** column in the **Correlation Rules** table will be set to *Active* for that rule. All the modems linked to that Correlation rule will have their entry in the **Trigger** column set to *Active*, and all the stations managing those modems will also have their entry in the **Trigger** column set to *Active*.

In the **Stations** table, the **State column** can be *Active* or *Not Active* for a specific station. When a station is active, the corresponding spectrum preset will be applied to the spectrum analyzer.

At most one station can be active at any time. The **Auto Control** and **Round Robin** parameters on the **General** page are used to decide which station is active. The decision procedure works as follows:

- **Auto Control** is set to *Enabled:*

  - At least one station is currently triggered by a Correlation rule. The station with the lowest priority will be set to *Active*.

  - No station is currently triggered:

    - **Round Robin** is set to *Enabled*: The manager will set each station to *Active* one after the other*.*
    - **Round Robin** is set to *Disabled*: All the stations will be set to *Not Active*.

- **Auto Control** is set to *Disabled:*

  - **Round Robin** is *Enabled*: The manager will set each station to *Active* one after the other*.*
  - **Round Robin** is *Disabled*: All the stations will be set to *Not Active*.

When **Auto Control** is disabled, you can manually select which station is active by clicking the **Select** button on the station row.
