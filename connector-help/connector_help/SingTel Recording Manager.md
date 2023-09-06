---
uid: Connector_help_SingTel_Recording_Manager
---

# SingTel Recording Manager

The Singtel Recording Manager collects information from the SingTel Event Manager and Ateme Pilot Media elements.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

## How to use

On the **Setting** page of this connector, you can configure the **Singtel Event Manager Source** and the **Ateme Pilot Media Source** to retrieve the Event Overview table data and update the recording states. In addition, you can define the scripts that will be launched when you click the **Actions** button in the Event Overview and Recording Overview tables, respectively.

## API

This connector implements an API that can be used to run certain calls from an Automation script.

To send a request, a JSON string has to be set to the parameter with ID 49999. The response will be available in the parameter with ID 49998. Each request has a GUID that will be replicated in the response so that each request can be identified.

In the documents folder for the connector, there is a namespace implementing the different calls. Preferably, this should be used.

The following actions are possible:

| **Action**                 | **Example request**                                                                                                                                                                                                                                                                                     |
|----------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Create recording           | { "**Action**": "Create", "**Object**": "Recording", "**Guid**": "Random guid", "**Data**": { "**Id**": "int", "**Title**": "string", "**Ird**": "string", "**Recorder**": "string", "**StartTime**": "Datetime (as oadate)", "**StopTime**": "Datetime (as oadate)", "**EventId**": "int", }}          |
| Update recording           | { "**Action**": "Update", "**Object**": "Recording", "**Guid**": "Random guide", "**Data**": { "**Id**": "int", "**Title**": "string", "**Ird**": "string", "**Recorder**": "string", "**StartTime**": "Datetime (as oadate)", "**StopTime**": "Datetime (as oadate)", "**EventId**": "int", }}         |
| Update or Create recording | { "**Action**": " UpdateOrCreate", "**Object**": "Recording", "**Guid**": "Random guid", "**Data**": { "**Id**": "int", "**Title**": "string", "**Ird**": "string", "**Recorder**": "string", "**StartTime**": "Datetime (as oadate)", "**StopTime**": "Datetime (as oadate)", "**EventId**": "int", }} |
| Delete recording           | { "**Action**": " Delete", "**Object**": "Recording", "**Guid**": "Random guid", "**Data**": { "**Id**": "int", }}                                                                                                                                                                                      |

The response will look like this:

{ "Data" : "String", "Guid" : "request guid", "Status" : "bool"}

Status can be 0 for "failed" and 1 for "succeeded".
