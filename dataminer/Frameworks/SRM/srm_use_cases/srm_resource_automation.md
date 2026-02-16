---
uid: srm_resource_automation
---

# Resource Automation

*Maximize efficiency and reliability when configuring resources.*

With Resource Automation, which is available **out of the box**, you can **apply a configuration to a resource at any time**, without scheduling or resource management.

With a **click of a button**, a complex configuration can quickly and reliably be applied to a resource. In cases where a very specific order is needed to apply multiple configurations to the network inventory, or in cases where transactional behavior is required (e.g., rollback in case erroneous configurations are reported), automation is required. This ensures not only that the sequences are repeated in a consistent manner, but also that the managed inventory can handle the speed and performance required to execute multiple configuration changes at once.

Increasingly high on the agenda of any ICT media and broadband enterprise is **security**. With Resource Automation, **SecOps procedures and playbooks can easily be automated**. For example, if a resource is configured to go online, the IP data ports can be enabled (Admin = ON). Similarly, if a resource is configured to go offline, DataMiner can shut down IP ports (Admin = OFF), remove host policies and ACL entries, and much more. Secure operations are the result of automated operations.

For a DevOps team, Resource Automation requires little effort. They only need to define which operational parameters they want to group together in a profile and create an automation script that translates this profile into individual commands for a DataMiner connector. This script is called a **Profile-Load Script (PLS)**. The profile data is independent of the underlying technology, but the automation is tuned separately for each technology. This means that for each connector, a specific PLS must be implemented.

In case a resource has been reserved for a booking that is already active, triggering Resource Automation for that same resource could potentially affect the service associated with that booking. In this case, the framework will notify the end user about the conflict.

Some examples of where Resource Automation will be a perfect fit:

- Routing the output of a service to a multiviewer.
- Switching between main and backup TX chains.
- Ad-hoc configuration of a device for testing purposes.
- Configuration of a multiviewer layout.
- Tuning an IRD.

> [!TIP]
> See also: [Automatically configure your resources](https://www.youtube.com/watch?v=yEEE6dYsfoA) ![Video](~/dataminer/images/video_Duo.png)
