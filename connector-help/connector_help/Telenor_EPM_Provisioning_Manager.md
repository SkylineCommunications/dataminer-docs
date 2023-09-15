---
uid: Connector_help_Telenor_EPM_Provisioning_Manager
---

# Telenor EPM Provisioning Manager

This connector is used to process the Telenor source files and, based on these files, generate new provision files that will be used by the [Telenor EPM Manager](xref:Connector_help_Telenor_EPM_Manager).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

On the **Configurations** page, provide the path to the shared LPI and DataSources folders along with the credentials to access these.

## How to Use

On the **General** page, you can specify a county to generate the files. To do so, use the drop-down menu **Counties to Generate Files** and select the desired county. After that, click the button **Generate Telenor Files**, and the connector will process and generate the files.

If the source files contain errors (you can configure rules for this on the **Validation Rules** page), the connector will not generate the provisioning files. However, if you want to accept the risk and generate new files based on those source files anyway, you can use the option **Force Generate Telenor Files**.

On the **Source Files History** page, you can find an overview of all previous provisioning attempts.
