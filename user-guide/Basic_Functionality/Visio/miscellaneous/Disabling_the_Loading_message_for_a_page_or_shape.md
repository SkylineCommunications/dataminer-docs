---
uid: Disabling_the_Loading_message_for_a_page_or_shape
---

# Disabling the Loading message for a page or shape

When data linked to a page or shape is retrieved in Visual Overview, a “Loading” message is displayed. In some cases, this can be inconvenient, for example when a shape is linked to a parameter that may or may not exist. Therefore, it is possible to use the *EnableLoading* option to determine whether the message is displayed for a page or for a particular shape.

To do so, add a shape data field of type **Options** to the page or to the shape, and set its value either to “*EnableLoading=True*” to enable the “Loading” message or to “*EnableLoading=False*” to disable the message.

| Shape data field | Value                                                                                               |
|------------------|-----------------------------------------------------------------------------------------------------|
| Options          | *EnableLoading=True* or *EnableLoading=False* |

Examples:

- To make sure no “Loading” message appears for a shape linked to a parameter that might not exist, add a shape data field of type **Options** to the shape in question, and set its value to “*EnableLoading=False*”.

- To make sure the “Loading” message only appears for one particular shape on a page, do the following:

    - Add a shape data field of type **Options** to the page, and set its value to “*EnableLoading=False*”.

    - Add a shape data field of type **Options** to the shape, and set its value to “*EnableLoading=True*”.
