---
uid: srm_resource_automation
---

# Resource Automation

With Resource Automation, users can apply a configuration to a resource at any time, without scheduling or resource management.

With a click of a button, a complex configuration can quickly and reliably be applied to a resource. The configuration is applied using a Profile-Load Script (PLS). The PLS translates a preset into individual sets on a connector. For each connector, a specific PLS must be implemented.

In case a resource has been reserved for a booking that is already active, triggering Resource Automation for that same resource could potentially affect the service associated with that booking. In this case, the framework will notify the end user about the conflict.

Examples:

- Routing the output of a service to a multiviewer.
- Switching between main and backup TX chains.
- Ad-hoc configuration of a device for testing purposes.
- Configuration of a multiviewer layout.
- Tuning an IRD.
