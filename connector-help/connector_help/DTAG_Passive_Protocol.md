---
uid: Connector_help_DTAG_Passive_Protocol
---

# DTAG Passive Protocol

The **DTAG Passive Protocol** is a virtual connector designed to show information about the created element.

A common situation where this protocol is used is in an environment with passive devices (i.e. devices without an interface to communicate with), where you still want to point out to the users in DataMiner that these devices exist and are present. In such cases you can create an element using this passive protocol, so you have an instance of the device available in the DataMiner system even though there is no means of communicating with the device.

## About

The connector will query the DMS about this element every minute. This way it's not necessary to restart the element after editing its settings.

## Installation and configuration

### Creation

This connector uses a virtual connection and does not need any user information.

## Usage

### General

This page shows the element's information. All parameters are read-only, except **Element Additional Info**. The latter can be used to add additional information.
