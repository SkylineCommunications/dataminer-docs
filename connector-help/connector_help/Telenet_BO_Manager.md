---
uid: Connector_help_Telenet_BO_Manager
---

# Telenet BO Manager

Business Overlay (BO) presents the delivered services to Business Customers in real time. A BO customer is typically a large organization that has multiple offices/sites across Belgium (Europe). These sites are interconnected via the Telenet network.

Based on the received alarms, the different customer types and the different types of sites, a correlated conclusion is made for a BO site. For this purpose, a correlation matrix is used that allows Telenet to configure these criteria and conclusions for each type dynamically.

## About

This connector should be used together with the **Telenet BO Provision connector**.

The **Telenet BO Manager** elements are automatically created during the provisioning cycle. For each provisioned BO customer that is not in the Excluded Customer list, an **element** is created.

The BO Manager receives input data and alarms from the TLN BO Provisioning element and supports the following aggregation and correlation functions:

- Managing all alarms, lines and sites of one particular business customer.
- **Aggregating** lines to services.
- Calculating the **correlated status** for the different lines and sites.
- **Exporting** all data of one site to the TLN Site Collector **DVE**.

## Installation and configuration

All Telenet BO Manager elements are automatically created by the Telenet BO Provision.

Because this is a **virtual** protocol, no configuration is necessary in the element wizard.

## Usage

### General Page

On this page, next to the generic info on the BO customer, two buttons can be found:

- **Clear Alarms**: Clears the current alarm info in the Lines table.
- **Recalc. Site Status**: Triggers the calculation of the Line/Service/Site Statuses.

### Alarm Correlation Page

On this page, the path for the Alarm Correlation Matrix can be configured. There are also two buttons that can be used to clear and upload the correlation matrix.

## Notes

More information can be found in the TLN_SE_TLN_SAM_REVxxx.docx document.
