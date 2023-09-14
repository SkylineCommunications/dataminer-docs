---
uid: Connector_help_ATNS_Billing_Statistics
---

# ATNS Billing Statistics

With this virtual **ATNS Billing Statistics** connector, it is possible to centralize voice, ATN and AFTN (serial) data statistics. These statistics will be zipped in a file and placed on a central location.

## About

The **ATNS Billing Statistics** connector must be installed on a DMP in order to collect all the voice, data and serial data statistics. These statistics will be processed by the **ATNS Billing Collector** element on a central DMA.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

#### Virtual connection

This is a virtual connector. No user input is required during the creation of the element.

### Configuration

To make sure this connector works correctly, fill in all the **configuration** parameters on the **Statistics** **page**.

## Usage

### Statistics Page

This page contains all the configuration parameters to set up the billing statistics. The parameters **FTP File Name**, **FTP Server User Name**, **FTP Password** and **Local File Location Folder (Temp)** must be filled in to retrieve all the correct FTP files for the voice statistics (elements using the connector CEFD Memotec NetPerformer SDM9220-9230).

ATN and AFTN data is retrieved from elements using the connectors CEFD Memotec NetPerformer SDM9220-9230 and CEFD Memotec NetPerformer SDM8400.

The parameter **Remote Central Server Path** is used to define where the zipped statistics file will be placed. This location is the same for all DMPs and the DMA.

The **Remote Central User Name**, **Domain** and **Password** parameters must be filled in if you need to log on explicitly to do the remote copy.

The parameter **Last Get Midnight Files Date** is a debug value that indicates the next day that needs to be processed.

## Notes

This connector is designed to work together with the ATNS Billing Collector connector. The remote central folder must be accessible for both the DMPs and the central DMA.

The Billing Statistics connector retrieves from elements using the **CEFD Memotec NetPerformer SDM9220-9230** and **CEFD Memotec NetPerformer SDM8400** connectors. On those elements, the **Create ATNS Statistics** parameter must be enabled. If it is not enabled, these elements will only save data from the last day, while the ATNS Statistics elements need this information to be stored until it is processed.
