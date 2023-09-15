---
uid: Connector_help_Skyline_PLM_Manager
---

# Skyline PLM Manager

This manager connector will install the **DataMiner Object Model** application used by the **Standard PLM Solution**. This manager is used by the solution to approve or disapprove a planned maintenance request that is triggered by the associated **process automation** flow.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                          | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Installation of PLM DOM application. Support for Standard Skyline PLM Approval. Support for configuration capabilities for a default PLM record creation. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                     |
|-----------|------------------------------------------------------------|
| 1.0.0.x   | PA version 1.2.1, SRM version 1.2.11, DMA version 10.1.2.0 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                             | **Exported Components** |
|-----------|---------------------|-------------------------|---------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | This connector is part of the Standard PLM solution. | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

### PLM DOM application

When the element has been created, the PLM DOM application will be initialized. It will generate the default structure of the PLM application, which will contain the following section and fields:

Section:

- GeneralInformationSectionDefinition

Fields:

- Title
- UTC Start Time
- UTC Stop Time
- Description
- Priority
- PLM State
- Action After Wait
- Auto Approve
- Wait Time
- Resources
- Option Mask
- EPM Supported Level Names
- EPM Allowed Number of Levels

### Approval Flow

When the Standard PLM Solution sends out a Skyline Approval request, a record will be generated in the Pending Approvals overview on the General page. This will create the possibility to either approve or disapprove the request.

Approving or disapproving the request will remove the record from the overview. The approval flow will continue based on the provided feedback.

Based on the configuration applied in the solution, the request will be available for a specific duration. When this duration is exceeded, the request will be canceled and removed from the list.

### Creating and viewing PLM Instances

All the existing PLM instances in the PLM DOM application are displayed in an overview, which shows only the standard structure in a table. Any custom sections that are added to the PLM DOM application will not be visualized there.

It is also possible to create a default PLM instance using the **Create PLM** window. In this window, you will need to specify the minimum configuration to build the record and start the full flow of the Standard PLM Solution.

## Notes

This connector is installed along with the Standard PLM Solution and should only be used with this solution.

### PLM Processes

The solution makes use of 3 **Process Automation flows**, available in the DataMiner module Services:

- SLC PLM Approval Process
- SLC PLM Start Process
- SLC PLM End Process

The activities use the information from the PLM DOM application by providing a placeholder in the parameters of the Node Profile Instance of the activity. It is possible to overwrite or change this, but be aware that this might break the correct functionality of the solution.

The placeholder is formatted in a specific way:

- Retrieving info from the default section (GeneralInformationSectionDefinition) is done by defining *\[DomFieldDescriptor:\<field name\>\]* where \<field name\> is the name of the field in the section that holds the data.
  For example, retrieving the resources is done with *\[DomFieldDescriptor:Resources\]*
- Retrieving info from a field in another section is done by adding the section name in front of the field name, separated by a dot: *\[DomFieldDescriptor:\<section name\>.\<field name\>\]*
  For example, retrieving the technician name that is stored in the section *Admin* is done with *\[DomFieldDescriptor:Admin.Technician\]*

### Running the process flows

Because each process must be able to run on demand, they each require a permanent booking. The name of each booking is fixed:

- Permanent SLC PLM Approval
- Permanent SLC PLM Start Booking
- Permanent SLC PLM End Booking

For the same reason, it is not allowed to rename the **Label** value of the 1st activity after the **Token Activity** in each of the processes.
