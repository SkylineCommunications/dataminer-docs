---
uid: Connector_help_Telenet_Topology_Database
---

# Telenet Topology Database

This connector creates a MySQL database table containing the provisioning data, based on the provisioning files of SKIPI.

## About

The table created by this connector contains address and network information on the different NEs. The connector is used by the Telenet BO and Telenet SAM system.

Telenet provides these files via shared folders on the SKIPI Platform (different files per front-end CPE). To configure these folders, go to the General page of the "Telenet Topology Table" element. The processing of the files is executed timer-based every hour and can also be triggered manually by means of the "Execute Now" button.

## Installation and configuration

### Creation

This connector uses a virtual connection and does not need any user information.

### Configuration

On the general page, the CSV files containing the source data can be specified. These files can be located locally or remotely.

When the file is stored remotely on a network share, the credentials to access that share should also be specified.

The path to the cable operator data file should also be configured.

## Usage

### General page

The configuration of this connector is done on this page, as specified above.

In addition, there is also a button that can be used to trigger the processing of the files manually. Once the files have been processed, the status is also displayed on this page.

### Telenet Topology Table page

This page contains the table with the topology data.
