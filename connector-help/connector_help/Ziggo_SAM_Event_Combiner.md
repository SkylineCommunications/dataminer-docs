---
uid: Connector_help_Ziggo_SAM_Event_Combiner
---

# Ziggo SAM Event Combiner

This connector is used to correlate alarms of specific trap receivers

## About

The **Ziggo SAM Event Combiner** connector correlates multiple alarms from two or more elements that use the **UPC Nederland Expert Cluster Trap Receiver** connector v1.0.0.12 or later.

The correlation is based on the technical path (**Trigger IVR** parameter) of the alarms. The correlation will match multiple alarms when one or more B2B alarms can be grouped under an HFC alarm, i.e., the technical path of the B2B alarm is at the same level or it is a child node of the HFC alarm.

The result of the correlation will be sent back to the respective trap receiver elements that will (via correlation rule) create a correlated alarm involving all grouped base alarms and edit the **B2B_impact** and **Event Tag** properties, accordingly.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page displays two tables, corresponding to alarms with two different types of **Trigger IVR**:

- **B2B Alarms table**
- **HFC Alarms table**

The type of the **Trigger IVR** must be defined in the trap receiver elements (**UPC Nederland Expert Cluster Trap Receiver** connector v1.0.0.12 or later) on the parameter called **Trigger IVR Type.** The correlation will be performed between the alarms of both tables.Each table describes the **Severity**, **Trigger IVR**, **Matching Status,** **Cluster** and **DMA ID** of each alarm. The **Matching Status** is the **Correlated** **Trigger IVR** (result of the correlation process that will be sent to the correspondent trap receiver element). The **Cluster** and **DMA ID** columns show the name and DataMiner ID of the trap receiver element the alarm came from.
