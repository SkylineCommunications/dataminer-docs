---
uid: VerifyNoLegacyCorrelation
---

# Verify No Legacy Correlation

From DataMiner 10.5.1/10.6.0 onwards<!--RN 40834-->, the *VerifyNoLegacyCorrelation* prerequisite check is included in upgrade packages. This check verifies that no legacy correlation rules still exist on your DataMiner System before upgrading, as these will no longer work after the upgrade.

From DataMiner 10.5.x onwards, correlation rules created using the legacy System Display engine are *End of Life*. These are correlation rules that were either created in System Display or in Cube via *Advanced* > *Old engine* > *Add rule*.

> [!TIP]
> See also: [DataMiner functionality evolution and retirement](xref:Software_support_life_cycles#dataminer-functionality-evolution-and-retirement)

## Fixing a failing prerequisite check

If the *VerifyNoLegacyCorrelation* check fails, there are still legacy correlation rules in the system. Remove these to fix the failing prerequisite check:

1. In DataMiner Cube, open the Correlation module (via apps > *Correlation*).

1. In the filter box above the list of existing rules, type `(Deprecated)`.

   All legacy rules in the system will be listed, with the suffix *(Deprecated)*.

1. If any of the legacy rules are still relevant to your setup, [rebuild the rules as regular correlation rules](xref:Adding_a_new_Correlation_rule).

1. Delete each of the legacy rules by right-clicking them and selecting *Delete*.
