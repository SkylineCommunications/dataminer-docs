---
uid: Feed_Link
---

# Feed linking

From DataMiner 10.3.10 onwards, [Dashboards](xref:newR_D) and [Low-Code Apps](xref:Application_framework) supports the usage of linking feeds through a textual syntax in some of the features. It allows dynamically referencing feed values from a Low-Code App or dashboard in text. Check the documentation of a feature to know wether or not it supports this new syntax.

## The syntax

Creating feed references inside textual settings requires the following format:

`{FEED.Source name.Feed name.Category name.Data type.Property name}`

1. **FEED**: a fixed keyword to indicate the variable represents a feed link.

1. **Source name**: the name of the Low-Code app page or panel, e.g. "Page 1".

1. **Feed name**: the name of the feed, e.g. "Table 3".

1. **Category name**: the part of the feed that will contain the data, e.g. "Selected rows".

1. **Data type**: the type of data, e.g. "Elements".

1. **Property name**: the property of the fed data that should be used, e.g. "Protocol Name".

> [!TIP]
> The name of each part can be found in the *FEEDS* data source of the edit panel's *DATA* tab.

> [!NOTE]
> Any part of this syntax that contain spaces should be typed between quotes.

## Example

My element `{FEED."Page 1"."Dropdown 3"."Selected item".Elements.Name}` is from protocol `{FEED."Page 1"."Dropdown 3"."Selected item".Elements."Protocol Name"}`.

Above example would result in something like "*My element Localhost is from protocol Microsoft Platform*".
