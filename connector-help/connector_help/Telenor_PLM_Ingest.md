---
uid: Connector_help_Telenor_PLM_Ingest
---

# Telenor PLM Ingest

This connector is used as a bridge between a third-party tool and the **Standard PLM Solution**. It is designed to ingest Telenor requests into the solution.

Via a test page, you can generate an example of the formatted request.

## About

### Version Info

| **Range**            | **Key Features**                                                                                       | **Based on** | **System Impact** |
|----------------------|--------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Ingest of Telenor PLM JSON request. Generation of a test ingest request of a single trunk (FiberLink). | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                           |
|-----------|------------------------------------------------------------------|
| 1.0.0.x   | PA version 1.2.1, SRM version 1.2.11, DataMiner version 10.1.2.0 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**      | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | See "Notes" section below. | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The Telenor request must be set in the parameter **PLM Ingest JSON** (PID 60). This will initiate the Automation script **Telenor Norway PLM Ingest** via a specific endpoint script. This script will make sure the Standard PLM Solution will handle the request.

Typically the parameter is set using the **SetParameter SOAP call** available in the DataMiner API: *http://\<host name or IP\>/api/v1/soap.asmx?op=SetParameter*

### Generating an example request

Via the **Test** page, you can generate a test request using minimum information. This generated JSON request can be copied and set into the PLM Ingest JSON parameter on the General page to trigger the entire PLM process flow.

The **Fiber Link ID** must be the ID of a fiber link that can be associated with a **FiberLink resource**. These can be found (and created) in the **DataMiner Resources module**.

For example, setting the Fiber Link ID parameter on the Test page to the value *81002631* will apply the PLM flow on the resource with the name "FiberLink 81002631".

The target resource must have the **properties** **EPM Level** and **EPM Name**. For example:

- EPM Level: *RHE*
- EPM Name: *Oslo*

## Notes

This connector requires the **Standard PLM Solution** to be installed and works in combination with the Automation scripts **Telenor Norway PLM Ingest, Telenor Norway PLM Ingest Save EndPoint, Telenor Norway PLM Ingest Edit EndTime EndPoint, Telenor Norway PLM Ingest Cancel EndPoint**. It will translate the ingested JSON request to a **PLM DOM instance**.
