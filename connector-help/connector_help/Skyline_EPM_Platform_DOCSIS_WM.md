---
uid: Connector_help_Skyline_EPM_Platform_DOCSIS_WM
---

# Skyline EPM Platform DOCSIS WM

The Skyline EPM Platform DOCSIS WF is a configuration manager protocol that converts input CSV files for the passives into new CSV files that are compatible with the Skyline EPM Platform solution.

## About

### Version Info

| **Range** | **Key Features**                                                                           | **Based on** | **System Impact** |
|-----------|--------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version. Creates compatible CSV files for nodes, amplifiers, taps and subscribers. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                               | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- The *EPMBeToWm* and *WmToEPMBe* Automation scripts - Skyline EPM Platform DOCSIS | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

For a **Skyline EPM DOCSIS WM** element to function, the **Skyline EPM Platform** solution and a **Passive Retrieval** element (e.g. Telefonica por Cable S.A de C.V. Geomarketing DB) must be installed in the DMS. The EPM solution and Passive Retrieval elements create the necessary input CSV files.

In addition, the following scripts must be installed: **EPMBeToWm** and **WmToEPMBe.** These are required for the communication between the **Skyline EPM Platform DOCSIS** back end and the **Skyline EPM Platform DOCSIS WF** element.

Two Correlation rules must be created to activate each of these Automation scripts:

- Both Correlation rules must **accept information events**.
- The first Correlation rule must have the alarm filter **Parameter description (by protocol)** equal to *Skyline EPM Platform DOCSIS* on the parameter *Workflow on change event.* This rule must activate the script **EPMBeToWm**.
- The second Correlation rule must have the alarm filter **Parameter description (by protocol)** equal to *Skyline EPM Platform DOCSIS WM* on parameter *BE on change event.* This rule must activate the script **WmToEPMBe**.

For more information on how to configure Correlation rules, refer to [DataMiner Correlation](xref:correlation).

Finally, to begin using the **Skyline EPM Platform DOCSIS WF** element, go to the **Configuration page** of the element and define the file import and export settings. This configuration must be the same as defined in the **Skyline EPM Platform** solution.

## How to use

When everything has been configured correctly as described in the "Initialization" section above, the Skyline EPM DOCSIS WM element will be able to receive requests to create the compatible passives CSV files from a back-end element of the **Skyline EPM Platform** solution.
It can create compatible node, amplifier, tap and subscriber CSV files.

On the **General** page, the **Workflow Table** is displayed. This table contains the latest workflow requests that have been made by the **back-end** element with their results.

The compatible CSV files can be found in the subfolder **CCAP Platform WM** of the folder that is defined in the import/export settings.
