---
uid: Connector_help_Hambisana_Appear_TV_Analyzer
---

# Hambisana Appear TV Analyzer

With this protocol, the alarms created by the **Hambisana Appear TV Analyzer** software can be displayed in DataMiner.

## About

This connector makes a connection to the Hambisana database and retrieves the information from the log tables. The log tables are parsed and entries about the same error are matched. The result is a table with all the current unresolved issues.

## Configuration and Installation

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

### Configuration

On the **Configuration** page of the element, the database hostname and credentials must be specified.

The **DB Connection State** parameter will then indicate if the connection is good or not.

## Usage

### Alarm History page

On this page, the **Alarm History Table** displays a history of the alarms on the Hambisana Appear TV Analyzer software.

### Alarm Active page

On this page the **Alarm Active Table** displays the active alarms on the Hambisana Appear TV Analyzer software, i.e. the alarms that have not been resolved.

### Configuration page

On this page, you can fill in the database hostname and credentials. There is also a parameter that indicates the database connection state. (See "Configuration" section above.)
