---
uid: Connector_help_Generic_sFlow_Agent
---

# Generic sFlow Agent

The purpose of this driver is to analyze the information received via **sFlow** packets to give network operators a better understanding of the flows of **data crossing the network**.

## About

**Every minute**, the driver reads the files from the **Collector driver**. It then processes these packets and writes the information to a table.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: Agent IP.

SNMP Settings:

- **Port number**: 161
- **Get community string**: public
- **Set community string**: private

## Usage

### Flows Overview

This is the **default page** of the driver. It contains the **Flows Table**, which contains all the **sflow packets** for a user-specified period of time.
