---
uid: Connector_help_SES_S.A._Telenor_Sites
---

# SES S.A. Telenor Sites

SES makes use of uplink sites at Telenor and wants to see uplink information from the SES system on the SES DMS. In order to do that, Telenor has made some elements available on a remote DMA to retrieve data from.

## About

This connector takes uplink status data from Telenor and retrieves it for monitoring on the SES DMS.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### HTTP main connection:

This connector uses the DataMiner SOAP HTTP interface and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the remote DMA.
- **IP port**: The IP port of the destination, by default *80*.

### Configuration of HTTP Authentication

The credentials and ID of the remote DMA must be entered on the **General** page, and then applied using the **Connect** button. This will then generate a connection token that will be used for all future requests, or until the credentials are changed.

## Usage

### General

The **Username,** **Password,** and **DMA ID** must be provided on this page. The **Connect** button must be pressed the first time the element is set up.

Via a page button, you can edit the **Element IDs** of the various elements on the remote DMA.

### NIT-60

The status information related to the **NIT** uplink can be found on this page, including the **Summary Faults**.

### HFS-01

The status information related to the **HFS** uplink can be found on this page, including the **Summary Faults**.

### Weather

**Air Temperature** and **Rain Intensity** of the **NIT-60** and **HFS-01 uplinks** can be found on this page.

### CapMon-Monics

The **ULK-EIRP** values for the **NIT-60** and **HFS-01 uplinks** are on this page.
