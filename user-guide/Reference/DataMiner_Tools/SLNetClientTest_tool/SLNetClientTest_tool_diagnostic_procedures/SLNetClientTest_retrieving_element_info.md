---
uid: SLNetClientTest_retrieving_element_info
---

# Retrieving general information about elements

In some cases, it can be useful to retrieve information about elements via SLNetClientTest tool. This can for instance be the case in case you want to find the element ID for the hidden *Skyline Generic Aggregator* element of a DMA, as it can be difficult to find this information in a different way.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select *GetLiteElementInfo*.

1. Configure the fields of the message according to your preferences.

   - You can for example set *IncludeAggregatorElements* and *IncludeHidden* to true to get info for the hidden aggregator elements in the system.

   - In the *NameFilter* field, you can specify a filter with an asterisk (`*`) wildcard in order to only retrieve information for elements matching that filter, e.g. `Skyline Generic Aggregator DMA*`.

1. Click *Send Message*.

1. Select the top message in the *Properties* pane.

   The retrieved information will be displayed in the pane on the right.
