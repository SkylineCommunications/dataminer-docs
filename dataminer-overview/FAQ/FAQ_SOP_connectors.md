---
uid: FAQ_SOP_connectors
---

# What are the standard operating procedures for connector deployment?

## Definition of connector

A connector is a virtual real-time representation of the functionalities supported through the remote interface (e.g. API) of the source of information (e.g. an asset, device, or function).

## Connector deployment covered in a deploy program

In a deploy program, by nature, the amount of information integrated in a connector is limited to the functionalities and use cases related to the general goals and objectives of the program.

The connector license includes the development time and internal QA and is made available to a DataMiner platform.

After the handover of the connector, a two-week user feedback window and up to two functional iterations are covered in the deployment of the connector.

The deployed connector results in a standard connector being added to the general catalog.

> [!NOTE]
> A default MVP graphical UI is not part of the connector delivery. In case this is required, a billable engineering budget is to be consumed.

## Additional connector logic

“Additional connector logic” means requests to add extra functionalities that are not supported through the remote interface of the asset/device/function and that are not part of the standard deployment.

In case additional connector logic is required:

- A new task is to be created and set as billable.
- It must be clearly communicated to the user that the required hours of work are to be consumed from the available agile scope-based or time & materials engineering buckets.  
- In case of doubts or in case no time budget is available, contact your Engineering Manager or Account Manager.

## Enhancement connector logic

“Enhancement connector logic” means parameter enhancements within the set of supported functionalities of the remote interface (e.g. show 4 decimals instead of 2, convert octets/sec to kb/sec, normalize parameter name Eb/No to default EbNo, etc.) that improve the usability of the created digital-twin object in general. These are non-billable and part of the default deployment.  

By contrast, adding new parameters (e.g. calculated KQI/KPI) beyond the functionality supported through the remote interface of the third-party asset/device/function is always considered to be "additional connector logic” and consequently billable.

In case of doubt, contact your Engineering Manager or Account Manager.

## Custom connectors

Custom connectors (Custom-DRV, DRV-APL) serve custom user-specific needs. By default, the cost and functionalities are composed as an MVP up to the estimated days of work in the solution backlog and in line with the specified use cases and general goals and objectives of the program.

In the event extra enhancements or functionalities beyond the initial MVP are required:

- In full agreement with the user, Skyline Communications’ Deploy team can consume available time engineering hours from another available engineering bucket.
- In case of doubt, get in touch with your Engineering Manager or Account Manager to seek a solution (e.g. stop, get extra funding, prioritize).

## Connector modifications covered in the Support Plan

If a Skyline Communications signed connector was developed during the deployment of the program and enhanced with “additional connector logic” beyond the capabilities of the remote interface, it is covered in full through the SLA as part of the active program, with the condition that the additional logic was built by Skyline Communications employees solely.

In case someone other than a Skyline Communications employee enhanced the connector (e.g. a DevOps professional), the connector is no longer considered a Skyline signed connector, and hence it is no longer supported in full under the SLA. For the connector to become supportable again, it needs to be verified by Skyline. The hours required for verification are billable and need to be approved up front with the involved stakeholders.

In case of a request to integrate extra functionalities under the SLA that are not yet part of the connector but that are supported through the remote interface, the modification is part of the SLA solely when it is in line with the original deploy use cases and goals and objectives specified during the design and deployment of the program. However, in case these extra functionalities facilitate new use cases that are not in line with the original objectives, you will need to get in touch with your Engineering Manager or Account Manager, as this is to be set as billable.
