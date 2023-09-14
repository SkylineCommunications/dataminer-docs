---
uid: Connector_help_Generic_XML_File_Reader
---

# Generic XML File Reader

This connector can be used to read the content of an XML file and also to validate it according to a provided XSD schema.

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

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

After you have specified a valid folder name and a file name, click **Check***,* and the content of the specified XML is retrieved. If any tag was left open in the file, the status of the file will indicate a failure.

You can also validate the XML to a provided schema. If all the elements are in order, **File Schema Validation** will be *OK*.
