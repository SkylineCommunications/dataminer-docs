---
uid: Connector_help_Telefonía_por_Cable_S.A._de_C.V._Bandwidth_Aggregator
---

# Telefon¡a por Cable S.A. de C.V. Bandwidth Aggregator

This virtual driver aggregates the sum of the Tx and Rx bandwidth of interfaces from Cisco Management elements.

## About

This driver retrieves the Tx and Rx bitrate from a list of interfaces of Ciscio Management elements, and calculates the sum for all the interfaces.

On the configuration page, new interfaces can be added to the list of interfaces from which the Tx and Rx bitrate is obtained.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

This driver uses a virtual connection and does not require any input during element creation.

## Usage

### Main

This page displays the total **sum** of the **Receive** and **Transmit Bandwidth**.

### Config

This page contains the list of the interfaces selected from the Cisco Management elements on which the aggregate function should be performed.

You can add interfaces to the list using the **Add New Interface** button.
