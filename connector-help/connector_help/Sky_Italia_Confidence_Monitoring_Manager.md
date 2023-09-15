---
uid: Connector_help_Sky_Italia_Confidence_Monitoring_Manager
---

# Sky Italia Confidence Monitoring Manager

The connector detects and lists into a table the Services in a DMA.

## About

This is a **Virtual** connector, that **every 12h** detects every Service (excluding the ones containing "Main", "Backup" or "All Services") and lists them and the defined properties in the Service Table.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

The connector contains only 1 page.

### General

The General page shows the **Service Table** with the following properties (columns) for each service:

- Primary IP LAN Main
- Primary IP LAN Backup
- Secondary IP LAN Main
- Secondary IP LAN Backup
- Main Encoder Slot
- Backup Encoder Slot
- Main Decoder Slot
- Backup Decoder Slot
- Multicast A
- Multicast B
- Multicast C
- Multicast D

The page also contains a **Refresh** button, which allows to perform a service detection whenever the user clicks on it, and an **Auto Remove** toggle button which if set to On, removes automatically services that are no longer being detected.
