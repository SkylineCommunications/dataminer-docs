---
uid: srm_concepts
---

# SRM framework concepts

DataMiner Service and Resource Management makes use of many dedicated DataMiner components to configure the management and orchestration of services end to end. This section provides a high-level overview of these components and explains how they can be used.

Before you [set up and configure an SRM system](xref:srm_getting_started), it is essential that you understand what these different components are and what their purpose is.

A distinction is made between "SRM definitions" and "SRM instantiations". An SRM definition determines what an object will be like. You could compare it to a class. The actual object based on the SRM definition is called an SRM instantiation. For example, a connector, which is considered an SRM definition, defines how to communicate. The element that is created based on that connector is considered an SRM instantiation.

The tables below summarize the components and their scope.

- [SRM definitions](xref:srm_definitions)

  | | Resource Automation | Resource Scheduling | Resource Orchestration | Service Orchestration |
  |--|---------------------|---------------------|------------------------|-----------------------|
  | [Connector](xref:srm_definitions#connector) | Yes | Yes | Yes | Yes |
  | [Virtual function](xref:srm_definitions#virtual-function) | Yes | Yes | Yes | Yes |
  | [Profile parameter](xref:srm_definitions#profile-parameter) | Yes | Yes | Yes | Yes |
  | [Profile definition](xref:srm_definitions#profile-definition) | Yes | Yes | Yes | Yes |
  | [Service definition](xref:srm_definitions#service-definition) | No | No | No | Yes |
  | [Service profile definition](xref:srm_definitions#service-profile-definition) | No | No | No | Yes |

- [SRM instantiations](xref:srm_instantiations)

  | | Resource Automation | Resource Scheduling | Resource Orchestration | Service Orchestration |
  |--|---------------------|---------------------|------------------------|-----------------------|
  | [Element](xref:srm_instantiations#element) | Yes | Yes | Yes | Yes |
  | [Virtual function resource](xref:srm_instantiations#virtual-function-resource) | Yes | Yes | Yes | Yes |
  | [Resource pool](xref:srm_instantiations#resource-pool) | Yes | Yes | Yes | Yes |
  | [Profile instance](xref:srm_instantiations#profile-instance) | Yes | Yes | Yes | Yes |
  | [Service profile instance](xref:srm_instantiations#service-profile-instance) | No | No | No | Yes |
  | [Booking](xref:srm_instantiations#booking) | No | Yes | Yes | Yes |
  | [Contributing booking](xref:srm_instantiations#contributing-booking) | No | No | No | Yes |
  | [Virtual platform](xref:srm_instantiations#virtual-platform) | No | Yes | Yes | Yes |

- [SRM scripting](xref:srm_scripting)

  | | Resource Automation | Resource Scheduling | Resource Orchestration | Service Orchestration |
  |--|---------------------|---------------------|------------------------|-----------------------|
  | [Profile-Load Script (PLS)](xref:srm_scripting#profile-load-script-pls) | Yes | Yes | Yes | Yes |
  | [Life cycle Service Orchestration (LSO) script](xref:srm_scripting#life-cycle-service-orchestration-lso-script) | No | No | No | Yes |
  | [Data Transfer Rules (DTR)](xref:srm_scripting#data-transfer-rules-dtr) | No | No | No | Yes |
  | [Custom events](xref:srm_scripting#custom-events) | No | No | No | Yes |
  | [Contributing conversion script](xref:srm_scripting#contributing-conversion-script) | No | No | No | Yes |
  | [Created booking script](xref:srm_scripting#created-booking-script) | No | No | No | Yes |

> [!NOTE]
> The concepts explained in this section are the main concepts used within the SRM framework, which builds on the core DataMiner SRM functionality to provide a versatile toolset to manage services and resources. For more information on SRM concepts in the context of the core SRM functionality, see [Concepts](xref:Concepts1).
