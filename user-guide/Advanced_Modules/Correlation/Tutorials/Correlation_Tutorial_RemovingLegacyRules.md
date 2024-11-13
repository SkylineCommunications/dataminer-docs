---
uid: Correlation_Tutorial_RemovingLegacyRules
---

# Removing Legacy Correlation Rules

As of DataMiner 10.5.x, the Legacy Correlation Engine is End of Life (see [Software support life cycles](xref:Software_support_life_cycles)).

Upgrading to such a version will not be allowed if there are still rules present for this engine.

In this tutorial, you will learn how to remove these rules.

> [!NOTE]
> If configured rules are still relevant to your setup, look into rebuilding the rules in the [Correlation Engine](xref:Adding_a_new_Correlation_rule) before deleting the legacy rules.

## Prerequisites

- A DataMiner System that running a version before 10.5.1 / 10.6.0

## Steps

- [Open DataMiner Cube](xref:Using_the_desktop_app)
- Navigate to the [Correlation rule editor](xref:Managing_Correlation_rules) (apps > *Correlation*)
- In the filter box above the list of existing rules, type "**(Deprecated)**"
- Legacy rules will show up as as "***Name of rule* (Deprecated)**"
- Go over these rules one by one and delete them
