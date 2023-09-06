---
uid: Connector_help_Ziggo_VoD_Transaction_Manager
---

# Ziggo VoD Transaction Manager

This driver generates aggregated tables to give an overview of the Video on Demand transactions.

## About

This driver uses the log files of multiple TraxIS servers to gather information about succesfull transactions.

This driver needs to be on the same DMA as the VoD Workflow Application to be able to get asset information.

### Ranges of the driver

| **Driver Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

## Installation and configuration

### Creation

This driver uses a virtual connection and does not need any user information.

### Configuration

All TraxIS servers need to be configured in the driver. For each server a Network **file path** and the **name** of the log file should be configured.

To be able to read the log files, **credentials** for the network share need to be configured.

## Usage

### Top Purchases

This page shows the **Top 20 Overall Purchases**, the **Top 20 Horizon** **Purchases** and the **TOP 20 D4A Purchases**.

### Average Duration

This page shows the **Top 20 Assets Shortest Average Duration**, the **Top 20 Network ID Shortest Average Duration**, the **Top 20 VoD Node ID Shortest Average Duration**, and all **Assets Stopped Early**.

### Configuration

On this page, all TraxIS servers need to be configured.

The threshold values to configure the **Assets Stopped Early** table can be found on this page as well.
