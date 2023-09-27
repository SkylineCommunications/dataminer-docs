---
uid: SLNetClientTest_changing_service_template_child_limitations
---

# Changing the service template child element and child service limitations

By default, when over 50 services are about to be created by a service template, or the template’s generated services contain over 20 elements, a warning appears that must be acknowledged within 5 minutes, as otherwise the service generation will be aborted.

However, it is possible to change this limit using the SLNetClientTest tool. To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Next to *Option values for*:

   - To change the limit for the total number of services created by a service template, select *ServiceTemplateWarnCount*.

   - To change the limit for the total number of elements in generated services, select *ServiceTemplateWarnElementCount*.

    The value for the selected setting will then be displayed.

1. Right-click the displayed record and select *Edit value*.

1. Enter the new value and click *OK*, then click *OK* to close the *SLNet Options* window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
