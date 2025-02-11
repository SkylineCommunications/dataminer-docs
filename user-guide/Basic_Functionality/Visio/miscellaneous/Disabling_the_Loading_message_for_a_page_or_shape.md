---
uid: Disabling_the_Loading_message_for_a_page_or_shape
---

# Disabling the indication that a page or shape is loading

When data linked to a page or shape is retrieved in Visual Overview, an indication can be displayed that the page is loading. In some cases, this can be inconvenient, for example when a shape is linked to a parameter that may or may not exist. Therefore, it is possible to use the *EnableLoading* option to determine whether this is indicated for a page or for a particular shape.

From DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!--RN 41517-->, child shapes inherit the *EnableLoading* setting that was set on shape or page level, unless explicitly overridden at the child shape level.

To configure this setting, add a shape data field of type **Options** to the page or to the shape, and set its value either to *EnableLoading=True* to enable the indication that it is loading or to *EnableLoading=False* to disable it.

| Shape data field | Value                                                                                               |
|------------------|-----------------------------------------------------------------------------------------------------|
| Options          | *EnableLoading=True* or *EnableLoading=False* |

Examples:

- To make sure no "loading" indication is shown for a shape linked to a parameter that might not exist, add a shape data field of type **Options** to the shape in question, and set its value to *EnableLoading=False*.

- To make sure the "loading" indication is only displayed for one particular shape on a page, do the following:

  - Add a shape data field of type **Options** to the page, and set its value to *EnableLoading=False*.

  - Add a shape data field of type **Options** to the shape, and set its value to *EnableLoading=True*.

> [!NOTE]
> From DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!--RN 41517-->, once shape loading reaches the two-minute timeout or if you cancel loading by clicking the "X" button on the loading bar, you can consult the debug logs to identify which shapes are still pending. You can then disable loading indicators for these specific shapes by setting the *EnableLoading* option to "false," which will significantly reduce the loading time.
