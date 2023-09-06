---
uid: Connector_help_British_Telecom_-_Elemental_Controller_Application
---

# British Telecom - Elemental Controller Application

The Elemental Controller Application is used to **control the Channels on both the Elemental Live and Elemental Conductor**.

This **enables the users to step away from the conductor** and only use this application in combination with the Elemental Live (headless) encoders.

## About

### Version Info

| **Range**            | **Key Features**                         | **Based on** | **System Impact** |
|----------------------|------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version: Conductor Cluster Table | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

This application contains one General page.

General

The General page contains a the **Conductor Cluster Table** that contains the Conductor identification and allows to enable or disable event management through the visual overview page.

A subpage **Add Conductor** that can be accessed via pagebutton on the bottom of the page, and allows the user to add new entries on the Conductor Cluster Table.
