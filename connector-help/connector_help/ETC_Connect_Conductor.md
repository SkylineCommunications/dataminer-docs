---
uid: Connector_help_ETC_Connect_Conductor
---

# ETC Connect Conductor

The **ETC Connect Conductor** is a **virtual** connector that is used to get data from a PostgreSQL database.

## About

The connector receives data from the database and creates DVEs based on the information received.

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not need any user information.

### Configuration

There are some extra configurations that need to be done before the connector can work correctly. To set these, go to the connector's **Configuration** page. For more information, refer to the **Usage \> Configuration** section of this document.

## Usage

### System Log

This page displays two tables: the **Message Extended Table** and the **Event Information Table**. These both contain information about the health of the system.

### ETC Controllers

On this page, the **Discovery Lookup Table** is displayed, which contains all information for the DVEs.

### Configuration

This page contains the **configuration** that can be changed by the user. The following settings should be set before any data can be polled: **DB Server, DB Username, DB Password.**
