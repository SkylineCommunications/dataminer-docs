---
uid: Using_the_EPM_filter_section
---

# Using the EPM filter section

You can drill down to specific information by means of the filter section:

- Depending on the protocol, there can be several filter boxes for each chain.

- To navigate to a particular object, select items in the filter boxes, starting with the top box, until you reach the item in question.

- When you clear a filter, if there is any previous filter, it is reapplied. To clear this “history”, click *Clear all*.

- When available, after you have selected an item, additional clickable fields may appear next to the filter box, such as *KPIs* or *CPEs*. When you click such a field, a new window will be opened with detailed information.

- In a KPI window, the right-click menu allows you to copy values from the KPI list.

> [!NOTE]
> When multiple selections are made in the filter boxes, prior to DataMiner 10.2.9/10.3.0, only the last selected box is taken into account to load further possible selections for other fields. However, as fields further down in the topology can also be directly related to fields in higher levels, from DataMiner 10.2.9/10.3.0 onwards, all selections are taken into account.
>
> For example, if a topology contains a *CCAP Core* field and a *Node Leaf* field lower in the topology, and a value is selected for both, in earlier DataMiner versions only the *Node Leaf* selection is taken into account for the possible selections in the *RPD* field further down in the topology, whereas in DataMiner 10.2.9/10.3.0, the *CCAP Core* selection will also be taken into account if the *RPD* field is related to both fields.
