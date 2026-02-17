---
uid: Disabling_the_Loading_message_for_a_page_or_shape
---

# Disabling the indication that a page or shape is loading

When data linked to a page or shape is retrieved in Visual Overview, an indication can be displayed that the page is loading. In some cases, this can be inconvenient, for example when a shape is linked to a parameter that may or may not exist. Therefore, it is possible to use the *EnableLoading* option to determine whether this is indicated for a page or for a particular shape.

If set at the page level, the *EnableLoading* setting will be inherited by all top-level shapes, unless explicitly overridden at the shape level. From DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!--RN 41517-->, child shapes will also inherit this setting when it is applied at the page level or on a top-level shape, unless it is overridden.

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
> From DataMiner 10.4.0 [CU12]/10.5.0/10.5.3 onwards<!--RN 41517-->, once shape loading reaches the two-minute timeout or if you cancel loading by clicking the "X" button on the loading bar, you can consult the debug logs to identify which shapes are still pending. For example, if a shape is linked to a parameter that does not exist, it might remain in a loading state indefinitely. Once you have identified these shapes, you can disable their loading indicators by setting the *EnableLoading* option to "false". This ensures that the loading indication accurately reflects which shapes are genuinely waiting for data and which do not require a loading indication.
