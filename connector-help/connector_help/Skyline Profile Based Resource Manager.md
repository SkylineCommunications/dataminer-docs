---
uid: Connector_help_Skyline_Profile_Based_Resource_Manager
---

# Skyline Profile Based Resource Manager

The purpose of this connector is to generate one-on-one **function resources** based on **profile instances**.

Via this way it is possible to use **resources** that are pre-configured based on the **profile instance** data, across different **service definitions**.

## About

### Version Info

| **Range**           | **Key Features**                                                                                     | **Based on** | **System Impact** |
|---------------------|------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x\[SLC Main\] | Generation of DataMiner Function Resources based on Profile Instances linked to a selected function. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

A function.xml must be assigned to this connector. Each function will be linked to a **Profile Definition** existing on the system.For a correct working it is required to create one element per desired function.

In the element, select the required **function** type to which the resource should be linked. This will act as a filter and search on the **DataMiner System** for linked **Profile Instances**. For each **Profile Instance** a **Resource** can be created based on the settings in the Config page. By default a sync with the system data is minute and the auto generation is disabled.

### Redundancy

There is no redundancy defined.

## How to use

The **General** page provides on overview of the properties the resource should use. Via the **Function Type** you can select one of the available functions linked to the connector. For example: *Satellite Channel* It will act as a filter to search all existing **Profile Instances** linked to the functions **Profile Definition**. The result of this search is shown in the table.

The **Resource Pool** and **Resource Concurrency** are used to indicate where the resource must be stored (the pool) and how many times the resource can be used at the same time.

From a resource point of view it is useful to know to what profile instance it is linked. For this purpose it is possible to select a **Profile Capability.** This reflects the Profile Instance Parameter that will be used to store the name of the profile instance name in.

### Creating resources

This can be done in different ways.

- A manual action by pressing the create button per profile instance, this will create/update the resource for the selected profile instance.
- A manual action by pressing the sync now button in the config page, this will create/update all the resources.
- Automatically by enabling the Auto Update in the config page, this will create/update all the resources as soon as there is a change.

The resource will be created/updated when:

- Linked profile instance name is changed
- Resource pool is changed
- Resource concurrency is changed
- Profile Capability is changed

The resource will be removed when the profile instance is removed.Note that this will only occur when the *Sync Now* button was pressed or the **Auto update** is enabled.

## Notes

More info on how to functions can be found in the [DataMiner help](https://help.dataminer.services/dataminer/DataMinerUserGuide/part_4/SRM/Functions_XML_files.htm?rhhlterm=functions&rhsyns=%20#XREF_43440_Uploading_a)

This connector is to be used in SRM environments.
