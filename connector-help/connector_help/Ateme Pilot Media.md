---
uid: Connector_help_Ateme_Pilot_Media
---

# Ateme Pilot Media

The Ateme Pilot Media enables business logic, metadata-driven automation for media capture, ingestion, management, enrichment, storage, and publishing.

It uses schedule-aware prioritization of workflows to ensure service-level requirements are met while also lowering operational costs.

## About

### Version Info

| **Range**            | **Key Features**                                                                                  | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Regular updates for assets, recordings, and recorders.- Updates on request for asset metadata. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API v1                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Initialization

When you have created an element using this connector, provide the correct credentials and click the log-in button.

Depending on the number of assets etc. on the device, it could take several minutes before all data is loaded for the first time.

## How to use

Metadata is never loaded by default. If certain metadata is required, you can request it using the **Request metadata** button in the assets table. Metadata will be removed after five minutes, to prevent DataMiner from showing outdated information.

On the recordings page, two sliders allow you to define in which time frame the connector should fetch the recordings.

## API

This connector implements an API that can be used to do certain calls from an Automation script.

To send a request, set JSON code to parameter ID 49999. The response will be available in parameter ID 49998.

Each request has a GUID that will be replicated in the response so that each request can be identified.

In the Documents folder for the connector, there is a namespace implementing the different calls. Preferably, this should be used.

The following actions are possible:

| **Action**                                                              | **Example request**                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|-------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Create assets                                                           | { "**Action**": "Create", "**Object**": "Asset", "**Guid**": "Random guid", "**Data**": { "**Name**": "string" }}                                                                                                                                                                                                                                                                                                                                   |
| Delete assets                                                           | { "**Action**": "Delete", "**Object**": "Asset", "**Guid**": "Random guid", "**Data**": { "**Id**": "int" }}                                                                                                                                                                                                                                                                                                                                        |
| Create recordings                                                       | { "**Action**": "Create", "**Object**": "Recording", "**Guid**": "Random guid", "**Data**": { "**Title**": "string", "**AssetId**": "int", "**Channel**": "int", "**Description**": "string", "**StartTime**": "Datetime (as oadate)", "**StopTime**": "Datetime (as oadate)", "**fields**": { "**Field_Name**": "Field_value" } }}                                                                                                                 |
| Delete recordings                                                       | { "**Action**": "Delete", "**Object**": "Recording", "**Guid**": "Random guid", "**Data**": { "**Id**": "int" }}                                                                                                                                                                                                                                                                                                                                    |
| Set and activate metadata settings for an asset.                        | { "**Action**": "Create", "**Object**": "Metadata", "**Guid**": "Random guid", "**Data**": { "**AssetId**": "int", "**Merge**": boolean, "**Values**": { "**metadata_field**": "field_value" } }}                                                                                                                                                                                                                                                   |
| Update recordings (data fields can be dropped if no update is required) | { "**Action**": "Update", "**Object**": "Recording", "**Guid**": "Random guid", "**Data**": { "**Id**": The recordings ID (Required, as string), "**Title**": "string", "**AssetId**": "int", "**Channel**": "int", "**Description**": "string", "**scheduledStartTime**": "Datetime (as oadate)", "**scheduledStopTime**": "Datetime (as oadate)", "**actualStartTime**": "Datetime (as oadate)", "**actualStopTime**": "Datetime (as oadate)", }} |

The response will look like this:

{ "Data" : "String", "Guid" : "request guid", "Status" : "bool"}

Status can be 0 for "failed" and 1 for "succeeded".
