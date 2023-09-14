---
uid: Connector_help_UPC_Nederland_B2B_CPE_Aggregator
---

# UPC Nederland B2B CPE Aggregator

This connector is used to automatically gather and process the **Availability** parameter of the **Cisco ISR** elements.

## About

This connector will retrieve the **Availability** parameter of the **Cisco ISR** elements and will group the retrieved parameters by the **Region** property of the **Cisco ISR** elements to make an average calculation and determine the minimum value.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page contains the **Region Table**. This table has 5 columns:

- **Region:** The index.
- **Avg Availability CCM:** Displays the average value per region of the **Availability** parameter of the current calendar month. The summary column header displays the average value.
- **Min Availability CCM:** Displays the minimum value of the **Availability** parameter that is found for this region. The summary column header displays the minimum value.
- **Element Name Min Availability:** Displays the element name that has this minimum value. If there are more elements that have this minimum value, then the first element found by the connector will be filled in.
- **CPE Count:** Displays the number of **Cisco ISR** elements that are in this region. The summary column header displays the sum.
