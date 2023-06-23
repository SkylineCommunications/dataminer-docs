---
uid: EPM_1.0.3_VSAT
---

# EPM 1.0.3 VSAT - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Verizon iDirect Evolution Platform Collector: Hub Return Network column added to Linecard Table [ID_36566]

In the Verizon iDirect Evolution Platform Collector connector, a new Hub Return Network column has been added to the Linecard Table, between the Hub Forward Network and Name[IDX] columns.

#### Verizon iDirect Evolution Platform Collector: New and updated ATDMA carrier parameters [ID_36567]

In the Verizon iDirect Evolution Platform Collector connector, the following columns/KPIs have been added to the Hub Return Overview and Carrier Table:

- *Active ICG ID*: Active composition group ID based on the current active composition group, which can vary with ATDMA carriers.
- *Active ICG FM*: Active composition group figure of merit based on the current active composition group, which can vary with ATDMA carriers.
- *Payload*: Payload size in bytes.
- *Target C/No*: Calculated target C/No based on the current active composition group and carrier.

In addition, the following parameters have been updated:

- *Fecrate*: Current FEC rate based on the current active composition group and carrier.
- *Modulation Name*: Current modulation based on the current active composition group and carrier.
- *Carrier Type*: The type of carrier.

## Changes

### Enhancements

#### iDirect Evolution Platform Collector: MODCOD reference for hub return carriers updated [ID_36471]

The MODCOD reference for hub return carriers has been updated.

#### Generic Sun Outage: Outages Table primary key changed from string to integer-based values [ID_36565]

In the Generic Sun Outage connector, the primary key of the Outages Table (parameter ID 600) now uses integer-based values instead of string values. The values consist of the ID concatenated with the epoch time of the start of the outage.

### Fixes

#### Verizon iDirect Evolution Platform Collector: BUC Table empty [ID_36640]

Elements using the Verizon iDirect Evolution Platform Collector connector did not show any information in the BUC Table.

#### Verizon iDirect Evolution Platform Collector: Current state not indicated in Remotes Overview tables [ID_36673]

In the Remotes Overview tables of Verizon iDirect Evolution Platform Collector elements, the *Current State* column could incorrectly show "Not initialized".
