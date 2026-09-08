---
uid: SDM_Relationships_1.0.0
description: "Find out about SDM Relationships 1.0.0, including the initial release of the Relationships Solution for modeling DataMiner object relationships."
---

# SDM Relationships 1.0.0

## New features

### Relationships Solution added [ID 46196]

The Relationships Solution introduces a Standard Data Model (SDM) for storing and managing relationships between DataMiner objects.

The following core models are registered automatically at install time:

- **Entity Descriptor**: Represents an object, such as an element or service, that participates in a relationship. It includes metadata such as display name, model name, and solution ID.
- **Relation**: Captures a directed connection between two entities, with a status that reflects whether both endpoints are active.

This model provides a consistent, reusable foundation for any solution that needs to track dependencies, model hierarchies, or associate related objects within a DataMiner System. By centralizing relationship data in a shared SDM, multiple solutions can read from and write to the same graph without duplicating models or creating conflicting data stores.

When you upgrade, any prior registration under the legacy solution identifier is cleaned up automatically to ensure a consistent state.

### Relationships low-code app for browsing relationships [ID 46197]

A pre-built **Relationships** low-code app is bundled in the solution package and deployed automatically during installation.

You can open this app to browse all relationship records in your DataMiner System and review the entities involved, without writing scripts or custom queries.
