---
uid: Connector_help_NBCU_Manager
---

# NBCU Manager

This driver will be used to:

- Provide information for ScheduAll booking scheduling from/to NBCU affiliates
- Control round-robin cycle to NBCU affiliates

## About

This driver imports an excel file and fills the tables with the correct information. Each excel sheet contains information that needs to be stored in a certain table. This information will then be used by an automation script.

### Version Info

| **Range**            | **Key Features**    | **Based on** | **System Impact**                      |
|----------------------|---------------------|--------------|----------------------------------------|
| 1.0.0.22\[Obsolete\] |                     |              |                                        |
| 1.0.1.x\[SLC Main\]  | Cassandra Complaint | 1.0.0.22     | Lost Saved data, trending and alarming |

Installation and configuration

### Creation

The creation of elements for this driver is very easy. Only the correct protocol and version need to be selected. After giving the element a unique name, the element will be created.

## Spectrum

Via the **Config SA**. pagebutton, the default values of the spectrum preset needs to be filled in before the spectrum option can be used. The supported spectrum analyzer protocol is Avcom of Verginia RSA-2150B. The elements can be found by using the **Search** button.

## Usage

Excel files which are located in the C:\Skyline DataMiner\Documents\NBCU Manager\\ can be imported on the **import page**.

First, select the correct .xls file from the drop down menu and press the '**Import'** button.

The **status** and **error** parameters will display if the import was successful or not. The date and time of the **last successful import** is also displayed.

The other pages of the driver display the different tables who have been imported.

There are 8 different options:

- **Transponders Table**
- **Encoder Profiles Table**
- **Site Information Table**
- **Band Segment Table**
- **Transponder Table**
- **PUP Encoders Table**
- **VideoShip Playout Table**
- **VideoShip Servers Table**

## Spectrum

Via the spectrum page it is possible to check the existence of the carrier in a trace on a specific Spectrum Analyzer element.

Via the **Search** button it is possible to select the Spectrum Analyzer Element Name. This element will be used to execute the check on.

In order to execute the check of the carrier via the **Calculate** button, the **Center Frequency** and the **Frequency Span** needs to be filled in. Info messages are shown in the **Carrier Message** box. This will also include errors.

**Level1** represents the result of the amplitude difference between the center frequency and the start frequency.

**Level2** represents the result of the amplitude difference between the center frequency and the stop frequency.

When these items are small, one can conclude that there is no carrier and the measured item is noise.

This Spectrum functionality will be used by a custom automation script that will check on a threshold on the **Level1** and **Level2.**

## Version 1.0.1.1

Tables changed:

