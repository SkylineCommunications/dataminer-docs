---
uid: Connector_help_Meinberg_Element_Manager
---

# Meinberg Element Manager

The **Meinberg Element Manager** provides an overview of the Meinberg equipment and view structure.

For all the equipment, KPIs are retrieved such as the device state, model, firmware version, uptime, etc.

## About

### Version Info

| **Range**            | **Key Features**         | **Based On** | **System Impact**                                                                            |
|----------------------|--------------------------|--------------|----------------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Initial version.         | \-           | Minimum required DataMiner version is **10.0.13.0 - 9857** due to internal licenses feature. |
| 1.0.1.x              | Compatible with IDP 1.2. | 1.0.0.1      | \-                                                                                           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                                                                                                                                                                                                                                    |
|-----------|---------------------|-------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | DataMiner protocols:[Meinberg LANTIME Modular](/Driver%20Help/Meinberg%20LANTIME%20Modular.aspx)[Meinberg LANTIME Non-Modular](xref:Connector_help_Meinberg_LANTIME_Non-Modular)DataMiner Automation scripts:Meinberg_SetupWizardMeinberg_Manager_ConfigurationRule_CreationMeinberg_Manager_Coordinates_ConfigurationMeinberg_Manager_Coordinates_Clear                                                                             |
| 1.0.1.x   | No                  | Yes                     | DataMiner protocols:[Meinberg LANTIME Modular](/Driver%20Help/Meinberg%20LANTIME%20Modular.aspx)[Meinberg LANTIME Non-Modular](xref:Connector_help_Meinberg_LANTIME_Non-Modular)DataMiner Automation scripts:Meinberg_SetupWizard_RunMeinberg_Manager_ConfigurationRule_CreationMeinberg_Manager_Coordinates_ConfigurationMeinberg_Manager_Coordinates_ClearMeinberg_Inventory_Manage_ImsModuleMeinberg_Inventory_Unmanage_ImsModule |

## Configuration

### Initialization

To install and configure the Meinberg Element Manager, run the *Meinberg_SetupWizard* Automation script.

## How to Use

### Inter App

On the **Inter App** page, an overview is provided that allows you to track the inter application communication and the related handlers.

#### Inter App Communication

Overview of the inter application communication events and messages.

The state of a communication object indicates whether it is waiting to be processed, being processed, executed successfully, or failed.

#### Inter App Handlers

Overview of the inter application handlers of the received events and messages.

Every communication object will be represented by a related handler. The handler is responsible for taking the necessary actions depending on the related communication object.
