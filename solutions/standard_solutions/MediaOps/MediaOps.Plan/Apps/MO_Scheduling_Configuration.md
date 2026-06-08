---
uid: MO_Scheduling_Configuration
description: Learn how to configure capabilities, capacities, configurations, and automated actions for resource pools, workflows, and jobs using the Scheduling Configuration dialog.
---

# Scheduling configuration

The scheduling configuration dialog allows you to define which capabilities, capacities, and configurations a resource should have when it is selected from a resource pool. It also allows you to configure automated actions (orchestration scripts) that run when a job starts or ends.

This dialog is available in the [Resource Studio](xref:MO_Resource_Studio), [Workflow Designer](xref:MO_Workflow_Designer), and [Scheduling](xref:MO_Scheduling) apps.

## Opening the scheduling configuration dialog

Depending on the app you are using, you can open the dialog in different ways:

- **Resource Studio**: Go to the *Resource Pools* page, click the `...` button in the row of a resource pool, and select *Scheduling Config*. This opens the *Edit Resource Pool Parameters* dialog.

- **Workflow Designer**: Click the pencil icon in the row of a workflow to open the *Edit* panel. Select a node in the workflow, then click the *Configure* button. To edit the global scheduling configuration of the workflow, click the *Configure* button at the top of the panel. This opens the *Select Configuration* dialog.

- **Scheduling**: Click the pencil icon to open the *Edit* panel of a job. In the *Nodes* table, click the icon in the *Config Status* column. To edit the global configuration of the job, click the *Edit job config* button above the *Nodes* table. This opens the *Select Configuration* dialog.

## Scheduling configuration dialog layout

The dialog consists of two main areas:

- **Left side**: The scheduling configuration, which consists of three sections: [Capabilities](#capabilities), [Capacities](#capacities), and [Configurations](#configurations).

- **Right side**: The [automated actions](#automated-actions) (orchestration scripts), which allow you to configure scripts that run at specific moments during the lifecycle of a job.

### Capabilities

[Capabilities](xref:MO_Resource_Studio#capabilities) give a qualitative description of a resource, making it clear what it can be used for. When capabilities are configured in the scheduling configuration, only resources that match all defined capabilities can be selected from the resource pool.

To add a capability:

1. In the *Capabilities* section, use the dropdown at the bottom to select the capability you want to assign.

1. Select the checkbox next to the capability to enable value selection.

1. Select the required value from the dropdown.

To remove a capability, click the **X** button next to it.

### Capacities

[Capacities](xref:MO_Resource_Studio#capacities) define how a resource can be used, measured numerically. When capacities are configured, only resources that have sufficient remaining capacity can be selected from the resource pool.

To add a capacity:

1. In the *Capacities* section, use the dropdown at the bottom to select the capacity you want to assign.

1. Select the checkbox next to the capacity to enable value input.

1. Enter the required numeric value.

To remove a capacity, click the **X** button next to it.

### Configurations

Configurations are additional settings that are applied to the resource when a job runs, but they do not have an impact on the resource selection. Use configurations for any parameters that need to be passed to the resource but should not limit which resources are available.

To add a configuration:

1. In the *Configurations* section, use the dropdown at the bottom to select the configuration you want to assign.

1. Select the checkbox next to the configuration to enable value input.

1. Enter the required value (text, numeric, or a discrete value from a dropdown, depending on the configuration type).

To remove a configuration, click the **X** button next to it.

### Automated actions

If [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) is deployed alongside MediaOps Plan, on the right side of the dialog, you can configure automated actions (i.e., orchestration scripts). These are automation scripts that execute at specific moments during the lifecycle of a job. Four orchestration events are available:

- **Pre-roll Start**: Executes when the pre-roll phase starts, before the actual job start time.
- **Pre-roll Stop**: Executes when the pre-roll phase ends (i.e. at the job start time).
- **Post-roll Start**: Executes when the post-roll phase starts (i.e. at the job end time).
- **Post-roll Stop**: Executes when the post-roll phase ends, after the actual job end time.

To configure an automated action:

1. Expand the section for the orchestration event you want to configure.

1. Select the *Execute Script* checkbox to enable script execution for this event.

1. In the dropdown, select the automation script you want to execute.

1. Configure the input parameters for the script, if any.

   These may include:

   - **Script input elements**: DataMiner element selections required by the script.
   - **Script input parameters**: Free-form parameters expected by the script.

## Mandatory parameters and full configuration

Capabilities, capacities, and configurations can be configured as mandatory in Resource Studio. This is indicated by a ✋ icon in the scheduling configuration dialog. All mandatory parameters must have a value configured. Additionally, all input arguments of the automated actions (if any) must be provided.

Only when all mandatory parameters and all automated action inputs are fully defined, is a node considered fully configured. This is reflected in the UI by the hand icon disappearing from the node.

All nodes and job-level configuration must be fully configured before you can confirm a job. Once a job is confirmed, you can only update the job in a way that keeps everything fully configured. If an update were to leave mandatory parameters incomplete, you can return the job to the tentative state first.

## Dynamic parameter linking

As from MediaOps Plan version 1.6.0, when configuring a resource pool in Resource Studio, or configuring a workflow in the Workflow Designer or Scheduling app, you can dynamically link parameter values to other data sources. Instead of manually entering fixed values for capabilities, capacities, configurations, or orchestration script inputs, you can configure a link to dynamically resolve the value from another source, such as a resource property, capability, capacity, configuration, or job property.

The value is automatically determined on job update based on the linked source. The UI shows a placeholder indicating where the value comes from.

### Configuring a parameter link

1. While you are editing a workflow or configuring a resource pool, click the 🔗 (link) button next to the parameter you want to link.

   The parameter can be a capability, capacity, configuration, or orchestration script input.

   If the parameter is not yet linked, the button has a neutral style. If it is already linked, the button appears highlighted (call-to-action style) and its tooltip shows the current link target.

1. In the *Configure Link* dialog, select the [link type](#available-link-types) from the dropdown at the top.

1. If the selected [link type is node-scoped](#node-scoped-link-types), in the node dropdown, select the node whose data you want to reference.

   Depending on the link type, a second dropdown will appear where you can select the specific target (e.g., which property, which capability, which capacity, etc.).

1. Click the *Link* button to confirm.

   The parameter field in the configuration dialog will now show a placeholder indicating the linked source.

### Removing a parameter link

1. While you are editing a workflow or configuring a resource pool, locate the linked parameter (recognizable by the highlighted 🔗 button and placeholder text).

1. Click the 🔗 (link) button next to the parameter.

1. In the *Configure Link* dialog, click *Unlink*.

   This button is only shown for parameters that are currently linked. It will return the parameter to manual-entry mode and remove the link.

### Available link types

The available link types depend on the parameter category being configured. Each link type resolves to a specific value or object within the workflow, job, or node context.

| Link type | Description | Available for |
|--|--|--|
| Resource Name | Resolves to the name of the resource assigned to a node. | Configuration parameters and orchestration script inputs |
| Resource Property | Resolves to a specific property value of the assigned resource. | Configuration parameters, orchestration script inputs, and orchestration script elements |
| Resource Linked Object ID | Resolves to the linked object ID of the assigned resource. | Configuration parameters, orchestration script inputs, and orchestration script elements |
| Capability Parameter | Resolves to the value of a capability configured on a node. | Capability parameters, configuration parameters, and orchestration script inputs |
| Capacity Parameter | Resolves to the value of a capacity configured on a node. | Capacity parameters, configuration parameters, and orchestration script inputs |
| Configuration Parameter | Resolves to the value of a configuration parameter on a node. | Capability parameters, capacity parameters, configuration parameters, and orchestration script inputs |
| Job Name | Resolves to the name of the job. | Configuration parameters and orchestration script inputs |
| Job Property | Resolves to a custom property defined on the job. | Capability parameters, configuration parameters, orchestration script inputs, and orchestration script elements |

### Node-scoped link types

The following link types are node-scoped, meaning that a specific workflow node (or the workflow itself) must be selected to determine where the value should be resolved from:

- Resource Name
- Resource Property
- Resource Linked Object ID
- Capability Parameter
- Capacity Parameter
- Configuration Parameter
