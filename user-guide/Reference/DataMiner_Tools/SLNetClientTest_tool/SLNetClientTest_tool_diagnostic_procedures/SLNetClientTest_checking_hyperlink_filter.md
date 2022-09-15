---
uid: SLNetClientTest_checking_hyperlink_filter
---

# Checking a hyperlink filter

From DataMiner 9.5.7 onwards, filters can be specified with a *filterElement* attribute in Hyperlink tags in *Hyperlinks.xml*. In the SLNetClientTest tool you can test such filters:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Offline Tools* > *FilterElementChecker*.

1. Specify the filter in the *Filter as string* section.

1. On the right, specify the object that has to match the filter.

1. Click *Check Filter* to check whether the filter is valid and matches the specified object.

> [!TIP]
> See also: [filterElement](xref:Hyperlinks_xml#filterelement)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
