---
uid: Connector_help_SFN_Nim_Data_Reader
---

# SFN Nim Data Reader

The **SFN Nim Data Reader** connector is a CSV parser that can be used to generate specific output strings.

## About

The connector parses a pre-formatted CSV file into the **Import Data Table***.* The user can then set up the configuration for the creation of the output strings. These strings will then be saved to the **Output Data Table***.*

An SFN (Single Frequency Network) is a network where multiple transmitters simultaneously send the same signal over the same frequency. The **SFN Nim Data Reader** connector is used to create a list of all SFN transmitters that are present at the selected site. The output result will also hold the name of all other sites with SFN transmitters that are transmitting the same signal and frequency as the ones located at the selected site.

## Installation and configuration

### Creation

The **SFN Nim Data Reader** connector is a virtual protocol. As such, only the name, protocol and protocol version need to be configured during the creation process.

## Usage

### Import Data Page

On this page, you can select the location of the CSV file to parse and import data from.

In the **Directory Path** parameter, you should fill in the directory where the .csv file to import is stored (by default: Skyline Documents Folder). You should then select the desired CSV file by selecting it in the drop-down list. Clicking the **Load** button will start the parsing and import process.

### Output Data Page

On this page, you can fill in the **Site Name** that should be used to create the desired output string, by setting the **Query Site Name** parameter. The **Query GUID Session var** also needs to be set before the output string can be calculated. This GUID value will be used as primary key for the row added to the **Output Data** table. This row will contain the generated output stream.

Press the **Load** button to generate the output string and add the generated row to the Output Data Table.
