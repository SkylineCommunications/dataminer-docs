---
uid: Remote_PHY_Monitoring_Components
---

# Remote PHY Monitoring Components

## System Connectors

At the moment only one system connector is supported and required:

- [Vecima RPM](https://catalog.dataminer.services/details/connector/6797)

## Automation scripts
The Remote PHY Monitoring Solution uses the following automation scripts:

- **CreateVecimaRpmElement:**  Since we only support the *Vecima RPM* driver at the moment, this automation script is responsible for creating a Vecima RPM element on the first deployment or when there is none Vecima RPM element in the system.

	
## Low-code apps
The Remote PHY Monitoring Solution includes the following low-code apps:

- **R-PHY Monitoring:** This low-code app gives the user the possibility to monitor all Remote PHY nodes presented in the system in a simple way.
- **R-PHY Analog & RF:** Low-code app taht monitor the analog and RF KPIs for all the Remote PHY nodes presented in the system.
This web application has the intention to allows on-site technicians to have a remote visility into how the vecima R-PHY node/s are performing during onsite installation/troubleshooting.

> [!NOTE]
> All elements related to the low-code apps should run in the **Production** version.

