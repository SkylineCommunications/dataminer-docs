---
uid: Remote_PHY_Monitoring_components
---

# Remote PHY Monitoring components

## System connectors

At the moment only one system connector is supported and required:

- [Vecima RPM](https://catalog.dataminer.services/details/7c9f527a-f11a-4ad8-a940-501297a0a865)

## Automation scripts

The Remote PHY Monitoring Solution uses the following Automation script:

- **CreateVecimaRpmElement**: This Automation script is responsible for creating a Vecima RPM element on the first deployment or when there is no Vecima RPM element in the system.

## Low-code apps

The Remote PHY Monitoring Solution includes the following low-code apps:

- **R-PHY Monitoring:** This low-code app allows you to easily monitor all Remote PHY nodes in the system.

- **R-PHY Analog & RF:** This low-code app monitors the analog and RF KPIs for all the Remote PHY nodes in the system. This allows on-site technicians to have remote visibility on how the Vecima R-PHY nodes are performing during on-site installation or troubleshooting.

> [!NOTE]
> All elements related to the low-code apps (i.e. the Vecima RPM elements) must use the **Production** version of the connector.
