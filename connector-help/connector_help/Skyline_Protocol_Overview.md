---
uid: Connector_help_Skyline_Protocol_Overview
---

# Skyline Protocol Overview

With the **Skyline Protocol Overview** driver you can parse multiple protocol files and then apply different **filters** on them so you find the protocols with the wanted specifications.

## About

### Version Info

| Range | Key Features | Based on | System Impact |
|--|--|--|--|
| 1.0.0.x [SLC Main]<br/> 1.0.1.X | Initial version. Parse XML version history; Metric on number of found matches; Support for XPath filters; Refresh more efficient; Cancel buttons; Search case-insensitive; Support code library in detection for manipulation external elements; Add indexed items - Class Library & Community Class Library | \-<br/> 1.0.0.5 | \-<br/> - |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

Workflow on startup:

(step 1 & 2 are executed automatically every 15 minutes, cancel in Protocols page)

1. Directories, select a directory that has an SVN structure. (Note: default is filled in. Pointing at a directory that is updated every 15 minutes)
1. Protocols, Click Refresh & Wait
1. Create a Filter in Filters... and Apply
1. Protocols Table should now show the filtered results.

Notes:

1. Some of the files found in the directory may have parsing errors. These files are indicated in the Files Table.
1. The Files page contains the Export functionality for the hidden full table of Protocols (Raw)
1. The driver does not force an SVN Update, it only parses the file system.
1. The driver does executes automatically parses all directories & files every 15 minutes.
1. Files that were not modified after the last parse are not parsed again.

Features:

- Directories

  - Selection of one or multiple directories on any server of your network that holds the full or a partial SVN Protocol file structure.
  - Selection of only parsing the last version of every major range.
  - Selection of a Filter to filter out specific files or folders.
  - Parsing can be done parallel or serial (Enabling/ Disabling happens on General page)

- Files

  - Individual status of every File, indicating correct or incorrect parsing, last parsed time and last modified time of the file.
  - Files where Date Last Parsed is later than Date Modified are not parsed again. Old parsing information is reused.

- Protocols

  - The results of the filters will be shown in the Protocols Table

  - The refresh button consists of 4 stages:

    - Parse All Directories
    - Parse All Files
    - Calculate Weights
    - Calculate Metrics

  - You can cancel the refresh but this can take a couple of seconds. You can see the Cancel Mode and Refresh Status on the Protocols page. If the Cancel Mode is turned on the refresh is busy canceling and the refresh status shows which stage is being executed/cancelled.

- Protocols Filters

  - You can apply multiple filters at the same time (with and/or operators).

  - Search Locations

    - Indexed: The values of the indexed filters are generated while parsing the files.

      - Identifier

      - Name

      - Version

      - Weight and Comment Generation from analyzed protocols.

      - Many columns indicating the presence of specific protocol features:

        - Connection Types (SNMP, Serial, http, ...)

        - If the driver is a Spectrum Analyzer

        - Parameter, QuickAction Line, Triggers, Actions, Sessions, Pairs Count

        - Count of unique developers

        - Last Developer

        - Most influential developer

        - The presence of:

          - DCF
          - DVEs
          - Tree controls
          - Matrices
          - SLNet subscriptions
          - External Element Communication
          - Data distribution
          - Element Connections
          - Tree controls
          - SNMP Traps
          - CSV Parsing
          - Database SQL Parsing
          - JSON Parsing
          - LINQ to XML Parsing
          - Object Serialization
          - Multithreaded Timers
          - Bitrate Calculations
          - Multiple SLProtocol Threads
          - Alarm Normalization
          - Base Packages
          - Custom Packages

    - Not Index: The values of the not indexed filters are generated while applying the filter, so the driver files are read again then.

      - The results will show the rule numbers and the context where the filter found its matches in the driver files.
      - You can use the cancel button for the not indexed searches.

  - Usage of Search Type:

    - Think about which search type you could use for which search location (e.g. greater than only with numeric search locations)

    - XPath:

      - Can only be used with the '--Full Driver-- (Not Indexed)' search location. When clicking the XPath Search Type, an XPath example is filled in in the Search Value Cell.
      - Example: */Protocol/Params/Param\[@id='1'\]*
      - Case Sensitivity only applies to the text after *='* and before *'*
