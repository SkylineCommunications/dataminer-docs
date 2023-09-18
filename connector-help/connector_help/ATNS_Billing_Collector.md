---
uid: Connector_help_ATNS_Billing_Collector
---

# ATNS Billing Collector

With this virtual **ATNS Billing Collector** connector, it is possible to centralize voice, ATN and AFTN (serial) data statistics from all the DMPs. These statistics will be processed per day and will be pushed into the local sldmsDma DB.

## About

The **ATNS Billing Collector** connector must be installed on a DMA that has access to all the data ZIP files created by the **ATNS Billing Statistics** elements on the DMPs.

The voice, data and serial data statistics will be processed and put in a database. These database entries will be used in a standalone application to create custom reports.

### Version Info

This connector does database queries to the local DataMiner database and is not compatible with Cassandra.

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

#### Virtual connection

This is a virtual connector. No user input is required during the creation of the element.

### Configuration

To make sure this connector works correctly, fill in the **configuration** parameters on the **Configurations** **page**.

## Usage

### Configurations Page

This page contains all the configuration parameters to set up the billing collector. The parameter **Remote Central Server Path** is used to define where the zipped statistics files from the DMP Billing Statistics elements can be found. This location is the same for all DMPs and the DMA.

The **Remote Central User Name**, **Domain** and **Password** parameters must be filled in if you need to log on explicitly to read out the zipped files.

The parameter **Last Get Midnight Files Date** is a debug value that indicates the next day that needs to be processed. The parameter **Keep Database Entries** is a configuration parameter that defines for how many hours the database entries need to exist.

## Notes

This connector is designed to work together with the ATNS Billing Statistics connector. The remote central folder must be accessible for both the DMPs and the central DMA. When the zipped files have been processed, they are moved to a folder named "DELETED".

All data stored in the database will be processed by an external application to create custom reports of the voice and data traffic.
