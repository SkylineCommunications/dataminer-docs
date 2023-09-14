---
uid: Connector_help_Generic_Shelter_Access
---

# Generic Shelter Access

This connector provides a mechanism to create database records every time an operator needs to request access to a specific shelter, allowing users to perform requests and authorizations of requests.

## About

This connector is a virtual connector. As such, it does not require any connection to a device.

Users can use the "Request new access" page in order to generate a request to use a shelter. An administrator or supervisor can then approve or reject such a request.

Users can also add shelters to the list of available shelters, using the Shelters Database Table.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not require any input during element creation.

## Usage

### General

This page displays the **Access Log Table.** It also contains page buttons that provide access to subpages where a new access request can be added, accepted or rejected.

### Database

This page displays the **Shelter Database Table**. Via a page button, a new shelter can be added to the database.
