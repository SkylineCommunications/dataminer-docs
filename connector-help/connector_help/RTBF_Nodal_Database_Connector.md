---
uid: Connector_help_RTBF_Nodal_Database_Connector
---

# RTBF Nodal Database Connector

The **RTBF Nodal Database Connector** connector is used as an interface between the **WFM** and the offload data in the database.

## About

The WFM can send commands to request sessions/activities between a start and stop time. The connector connects to the database and retrieves the appropriate information from the activity table.

The WFM can also send a second command to ask all the details of a specific activity. The information is passed to the WFM in XML format using a set on a parameter.

The connector also makes it possible to clean up the database, so that any data older than a given time will be deleted.

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the database

On the "General" page, database credentials need to be configured.

## Usage

### General page

The parameters on this page are used by the WFM to request and gather data from the Nodal offload database.

**Database information** needs to be configured on this page.

### DB Cleanup page

On this page, you can clean up the database. Data older than the time defined in the **Time to Keep** parameter will be deleted.

The following database tables are affected:

- slnodal_actions
- slnodal_activity
- slnodal_activity_singledays
- slnodal_validatedactivity
