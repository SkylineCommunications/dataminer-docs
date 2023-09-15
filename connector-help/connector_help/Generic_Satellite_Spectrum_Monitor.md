---
uid: Connector_help_Generic_Satellite_Spectrum_Monitor
---

# Generic Satellite Spectrum Monitor

## About

This protocol was created to connect with a particular **database** and with certain elements.

The database contains information that is needed for the protocol to create **presets**, **spectrum scripts** and **spectrum monitors**. The spectrum scripts also do calls to an Automation script, which does sets on the ACU, Beacon Receiver and RF Switch element. The monitor then stores the trace in the history database. This makes it possible to cross reference outages with history spectrum traces.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page provides an overview of the elements that can be selected to be used in the spectrum monitoring. It also contains configuration parameters that can be used to configure the database connection.

### Database

This page displays the data present in the tables retrieved from the database.
