---
uid: Web_apps_Main_Release_10.3.0_CU1
---

# DataMiner web apps Main Release 10.3.0 CU1 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU1](xref:General_Main_Release_10.3.0_CU1).

### Enhancements

### Fixes

#### Web apps: An invalid value entered into a text box would incorrectly be replaced by the last valid value that was entered [ID_35489]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 -->

When you entered an invalid value into a text box, an error message would be displayed for a very short moment, and the invalid value would incorrectly be replaced by the last valid value that was entered.

#### Low-code apps: Sidebar would incorrectly be displayed when there was only one visible page [ID_35544]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Up to now, whether the sidebar was displayed or not would incorrectly depend on the number of pages. From now on, it will depend on the number of visible pages. In other words, the sidebar will only be displayed when there are at least two visible pages.

#### Low-code apps: Clock components in a published low-code app would incorrectly only update when you moved the mouse [ID_35554]

<!-- MR 10.2.0 [CU13]/10.3.0 [CU1] - FR 10.3.4 -->

Clock components in a published low-code app would incorrectly only update when you moved the mouse.

#### Web apps: No longer possible to clear a radio button group [ID_35603]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 [CU0] -->

It would incorrectly no longer be possible to clear a radio button group.

#### Web apps: Auto-complete control could clear its content while you were entering a value [ID_35623]

<!-- MR 10.3.0 [CU1] - FR 10.3.3 [CU0] -->

In some cases, an auto-complete control could clear its content while you were entering a value.
