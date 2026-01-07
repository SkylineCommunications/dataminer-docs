---
uid: Troubleshooting_DaaS
---

# Troubleshooting – DaaS

[DataMiner as a Service (DaaS)](xref:DaaS_hosting) is a cloud-hosted DataMiner deployment managed by Skyline. While most investigation steps are similar to those of an on-premises setup, there are some key differences because of Skyline hosting the environment.

> [!NOTE]
> Proactive monitoring via [CDMR](xref:CDMR) tracks the availability of a DaaS system by checking the ability to log in on a DaaS system. If a login attempt fails, an automatic ticket is created and assigned to DataMiner Support.

> [!IMPORTANT]
> This page outlines the typical starting points for investigating issues with a DaaS setup and is intended for **internal use by Skyline teams** such as DataMiner Support.

## Investigation steps

To begin an investigation on a DaaS setup:

1. Connect to the setup via Remote Desktop.

   > [!TIP]
   > For more information, refer to [TechSupport's internal guide](https://internaldocs.skyline.be/DevDocs/DaaS/Troubleshooting/AccessDaaSResources.html) on how to connect to a DaaS setup *(link for Skyline employees only)*.

1. Verify whether the DataMiner System is running.

1. Attempt to log in locally via DataMiner Cube.

1. If login is successful, check if the system is responsive.

1. If the system is responsive, check if the cloud tunnel is down.

1. If the tunnel is down, follow the steps under [Investigating dataminer.services connection issues](xref:Cloud_Connection_Issues) and contact the Skyline Cloud team for further assistance.
