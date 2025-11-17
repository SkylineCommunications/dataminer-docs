---
uid: Verify_No_Annotations
---

# Verify No Annotations

From DataMiner 10.6.0/10.6.1 onwards, the *VerifyNoAnnotations* prerequisite check is included in upgrade packages.<!-- RN 44124 --> This check verifies that the [*LegacyAnnotations* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyannotations) is disabled, as the legacy Annotations feature will no longer function after an upgrade to 10.6.0/10.6.1 or higher.

From DataMiner 10.6.0/10.6.1 onwards, the **annotations** on [element cards](xref:Element_cards), [view cards](xref:View_cards), and [service cards](xref:Service_card_pages) are **End of Life**.<!-- RN 44136 -->

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)

## Fixing a failing prerequisite check

If the *VerifyNoAnnotations* check fails, you will need to disable the [*LegacyAnnotations* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyannotations).

This will **remove all existing annotations**, and you will no longer be able to access them.
