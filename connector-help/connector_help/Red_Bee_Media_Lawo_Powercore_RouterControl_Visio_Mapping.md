---
uid: Connector_help_Red_Bee_Media_Lawo_Powercore_RouterControl_Visio_Mapping
---

# Red Bee Media Lawo Powercore RouterControl Visio Mapping

This protocol is to be used with the *Lawo Powercore RouterControl* Visio file to have a mapping between the selected output from the Grass Valley Audio Live and the parameters from the Lawo Powercore protocol.

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

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On startup or via the refresh button, 3 files will be generated in the "C:\Skyline DataMiner\Documents\Red Bee Media Lawo Powercore RouterControl Visio Mapping" folder. These files (DSP, MonoMix and StereoMix) will be empty with the csv headers already available.

When changes are made to the CSV files, you can use the Refresh button on the UI to read out the files and fill in the tables.

## Notes

This is to be used specifically with the *Lawo Powercore RouterControl* Visio file for Red Bee Media.
