---
uid: MediaOps_Plan_2.0.0
---

# MediaOps Plan 2.0.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.4/10.7.0 or higher.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.1.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes.

## New features

#### Select Configuration dialog now shows simplified operator view [ID 45838]

Up to now, when you configured a node, job, or workflow, the *Select Configuration* dialog always displayed every available detail at once, including linked parameters, all automated-action events, the selected scripts, and linked input arguments. For day-to-day operations, this often resulted in a cluttered overview where the values that actually needed attention could be hard to find.

From now on, the *Select Configuration* dialog will open in a simplified operator view by default. In this view, the following items are hidden to keep the focus on the parameters you can act on:

- Linked (capability, capacity, or configuration) parameters
- Automated actions that are disabled or that do not have a script selected
- The selected scripts
- Linked input arguments

A new *Show all details* checkbox has been added at the top of the dialog. When you enable this option, the dialog switches to the full engineer view, showing the complete configuration again, including all of the items listed above.

In addition, when there is nothing to configure in the operator view, the dialog now displays a message indicating that you can enable *Show all details* to see all parameters and events.

> [!NOTE]
> This change only affects which information is displayed. It has no impact on the configurations themselves or on any previously configured values.

## Changes

### Enhancements

#### DevPack: API enhancement to improve type-checking and casting for Capacity and Configuration classes [ID 45715]

New helper methods have been introduced for safe type-checking and casting of Capacity and Configuration instances to their specific derived types, with comprehensive XML documentation.

- In **Capacity.cs**, the following methods have been added:

  - IsNumberCapacity
  - IsRangeCapacity

- In **Configuration.cs**, the following methods have been added:

  - IsNumberConfiguration
  - IsDiscreteNumberConfiguration
  - IsTextConfiguration
  - IsDiscreteTextConfiguration

#### Scheduling/Workflow Designer: Shuffled connection configuration simplified [ID 45884]

When you configure a connection in a workflow or job between two nodes, you can shuffle parts of the connection based on levels. This shuffled connection setup has now been simplified. The *Predefined Subset* and *Custom Subset* options have been removed, and only two options remain:

- **All**: Connect all levels straight (for example, Audio1 -> Audio1, Audio2 -> Audio2).
- **Shuffle**: Define a custom shuffle by selecting the source level per destination level.

#### DOM ImportExport script renamed for naming consistency [ID 45887]

For naming consistency throughout the solution, the *DOM ImportExport* script has been renamed to *MOP DOM ImportExport*.

#### MediaOps Live events now only created for confirmed jobs [ID 45894]

MediaOps Plan now creates events in MediaOps Live only for confirmed jobs.

Previously, events could also be created for jobs in the *Draft* or *Tentative* status, which increased the workload and introduced unnecessary edge cases.

With this change:

- Events are created only when a job is confirmed.
- If a confirmed job is moved back to *Tentative*, its corresponding events are automatically removed from MediaOps Live.

This simplifies event management and ensures that MediaOps Live reflects only confirmed jobs.

#### Scheduling/Workflow Designer: Swapping to a different pool now prompts to keep or reset node configuration [ID 45924]

When you swap a resource or resource pool node to a different pool in the Workflow Designer or directly on a job, MediaOps Plan now detects whether the new pool has a different scheduling configuration.

If differences are found, you now get a prompt to choose one of the following options:

- **Keep**: Keep the node's current configuration and automated actions.
- **Revert**: Reset the node configuration and automated actions to match the new pool.

Previously, swapping pools silently kept the old configuration, which could leave a node with settings that no longer matched its new pool. Now you decide explicitly, at the moment of the swap.

#### Improved parameter link configuration [ID 45975]

The dialog used to dynamically link parameter values (capabilities, capacities, configurations, and orchestration script input) has been improved to make linking faster and more intuitive:

- **Shorter, clearer labels**: Several labels in the dialog have been shortened for faster configuration. For example, *Select the type of link you want to configure:* is now *Link to type:*, and *Select the node to link to:* is now *Link to:*. The target labels have likewise been simplified to *Property:*, *Capability:*, *Capacity:*, and *Configuration:*.

- **Smart default target**: The *Link to* target is now preselected based on the link type. Node-scoped links default to the current node ("*This node*"), while job- or workflow-scoped links (capability, capacity, and configuration parameters) default to the job/workflow scope.

- **Pre/post relationship indicators**: In the node list, each node now indicates how it relates to the current node. A node connected into the current node is labeled "*(pre)*", a node that the current node connects to is labeled "*(post)*", and a node for which both apply is labeled "*(pre/post)*". This makes it easier to pick the correct node when configuring links across a workflow.

### Fixes

#### DevPack: Resource reservations could appear to start before job confirmation [ID 45889]

When you confirmed a job with a start time in the past (which then ran automatically), node start and stop times remained anchored to that past start time. As a result, resources could appear reserved from before the reservation actually existed. This issue has now been fixed: on confirmation, past node start times are moved forward to the confirmation time so resource usage reflects the actual reserved window.

#### Scheduling: Deprecated organizations shown when creating jobs or editing job owner [ID 45981]

Previously, deprecated organizations could be shown when a new job was created or the ownership of a job was edited.

This issue has now been fixed, and deprecated organizations are no longer shown.

#### Scheduling: Unexpected pop-up message when opening node configuration of recurring job [ID 46006]

When you opened the scheduling configuration of a node in a recurring workflow, it could occur that some input parameters were not correctly linked. As a result, an unexpected pop-up message appeared, prompting you to provide values for the missing parameters.

This issue has been resolved. The scheduling configuration dialog is now correctly displayed in read-only mode, as intended.
