---
uid: Verify_No_Annotations
---

# Verify No Annotations

From DataMiner 10.6.0 onwards, the *VerifyNoAnnotations* prerequisite check is included in upgrade packages. This check verifies that the LegacyAnnotations soft-launch flag is disabled before upgrading, as the legacy Annotations feature is end of life and will no longer function after the upgrade.

From DataMiner 10.6.0 onwards, the [Element-](xref:Element_cards), [View-](xref:View_cards) and [Service Card Annotations](xref:Service_card_pages) are *End of Life*.

[!IMPORTANT]
After disabling the LegacyAnnotations soft-launch flag, all existing annotations will be removed and will no longer be accessible.

## Fixing a failing prerequisite check

If the *VerifyNoAnnotations* check fails, The *LegacyAnnotations* soft-launch flag is still enabled.