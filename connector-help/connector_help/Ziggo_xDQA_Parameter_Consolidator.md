---
uid: Connector_help_Ziggo_xDQA_Parameter_Consolidator
---

# Ziggo xDQA Parameter Consolidator

This virtual connector gathers information from elements using the **SA xDQA24** and the **CISCO RFGW-1-D** connectors.

## About

This connector calculates statistics based on values gathered from elements using the **SA xDQA24** and the **CISCO RFGW-1-D** connectors.

## Installation and configuration

### Creation

This is a virtual connector, so during element creation no particular settings are necessary.

### Configuration

Once the element has been created, a .csv file containing the element names and the associated NITs (Network ID) has to be imported.

To do so, click the **Import NITs** button on the **General** page.

## Usage

### General

On this page, a list of the different **Service Areas** can be found together with some **Bandwidth Usage** values.

It contains page buttons to the following subpages:

- **Ports Usage**: For each port, this page displays the port usage for the current time, the last 4 weeks, the last 2 months and the last year.
- **Top 10**: Displays the top 10 bandwidth usage service areas for the last week, the last month and the last year.
