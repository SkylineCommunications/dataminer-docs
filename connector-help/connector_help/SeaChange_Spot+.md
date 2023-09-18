---
uid: Connector_help_SeaChange_Spot+
---

# SeaChange Spot+

The **SeaChange Spot+** makes it possible to monitor the state of the HAdb System and Failover Services.

## About

The Spot+ connector periodically polls both the primary and backup HAdb database servers to retrieve status information about the health of the SeaChange Failover Services. By default, this happens every 30 seconds.

This data is used to identify the primary and backup systems in the SeaChange Spot system and their status.

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not need any user input during creation.

### Extra Configuration

In order to poll the databases, the **primary and secondary HADB Connection String** must be filled in. These can be found on the **General** page.
(e.g. Server=*192.168.XX.XX;Database=HAdb;User Id=XXXX;Password=XXXX;*)

## Usage

### General Page

On this page, you can view information about the **Primary and Secondary connection** to request data about the system, in the **Timeout and Timeout Message** parameters**.**

It is also on this page that the **Primary and Secondary Connection Strings** have to be filled in.

### SeaChange HAdb

This page provides an overview of all the retrieved **Paired Systems** (Main-Backup) and their status.
