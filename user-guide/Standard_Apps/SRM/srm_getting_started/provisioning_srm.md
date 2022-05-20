---
uid: provisioning_srm
---

# Provisioning the data acquisition and control plane

For an SRM deployment, DataMiner must be connected with all the products that are involved in the delivery of the service. This means that **for each product a connector has to be designed, tested, and deployed**. This will result in a digital twin of all these products within the DataMiner System, enabling the overarching automation process to interact with them.

Install all the connectors you need and provision all the required elements in the DataMiner System. Any information that is important for the monitoring and orchestration must be included in the connectors and accessible for the Automation engine.

**To provision the elements, you can use the [DataMiner IDP app](xref:SolIDP)**. This can not only be used for the initial setup, but also for future maintenance. If a new data source is added in the future, the same provisioning steps can be executed.

When all data sources that need to be integrated into the SRM solution are available as elements in the DataMiner Agent and are communicating correctly, you are ready for the next step of the SRM deployment.
