---
uid: Connector_help_Zabbix_Platform_-_Host
---

# Zabbix Platform - Host

Zabbix is software that monitors numerous parameters of a network as well as the health and integrity of servers.

## About

This is an **HTTP** connector that connects to the Zabbix API to retrieve data from the Zabbix platform. The Zabbix API is a web-based API and is shipped as part of the web front end. It uses the JSON-RPC 2.0 protocol. This connector is created by the **Zabbix platform** connector. For more information on the device, refer to <https://www.zabbix.com/documentation/3.0/manual/api>.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

The element using this protocol is **automatically created** by the parent connector (Zabbix platform). The name of the element consists of the name of the parent connector + host.

### Configuration

To be able to retrieve data from the API, the **Username,** **Password** and **URL** must be provided on the Configuration page of the parent element.

## Usage

### General

This page displays information about the host.

### Triggers

This page displays all the **triggers** that occur on the current host.
