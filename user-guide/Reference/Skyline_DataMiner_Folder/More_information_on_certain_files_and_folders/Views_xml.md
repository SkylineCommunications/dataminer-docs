---
uid: Views_xml
keywords: enhanced view
---

# Views.xml

*Views.xml* contains the views configuration of the DataMiner System. For each view, it contains a `<View>` element defining that view in detail.

In normal circumstances, you will never need to configure anything directly in this file, as this can be fully configured via Cube.

However, there is one exception to this: to enhance a view so that it displays all the data pages of a specific element, the *enhancedElement* attribute has to be added the view. Alternatively, instead of changing this directly in *Views.xml*, you can use SLNetClientTest tool. For detailed information, see [Enhanced view configuration](xref:Enhanced_view_configuration). Note that this feature is currently mainly used for EPM, but it is not limited to EPM.
