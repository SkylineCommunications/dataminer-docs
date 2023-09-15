---
uid: Connector_help_Telenor_MSNW_Service_Definition
---

# Telenor MSNW Service Definition

The **Telenor MSNW Service Definition** is a Service Definition used to provide a combined alarm severity for two underlying Tunnel services.

## About

This is a **Service Definition** for **MSNW Services**.

**MSNW Services** are used to represent **MSNW Circuits** in a Nimbra environment.

## Creation

When creating the service using this Service Definition, you don't need to configure any specific settings.
You only have to add the **Telenor MSNW Service Definition** as the Service Definition to the service.

## Usage

### General Page

The **General** page displays parameters such as:

- **MSNW Circuit Severity**

### Admin

The **Admin** page displays a table with the included services and elements:

- **Alias / Element Name**: Name of the service child.
- **Severity**: Alarm severity of the service child.
- **State**: Indicates whether the service child is *Included* or *Excluded* in the service.
- **Calculated**: Combined **State** and **Severity**.
