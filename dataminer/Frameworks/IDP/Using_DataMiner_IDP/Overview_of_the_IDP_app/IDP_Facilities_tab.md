---
uid: IDP_Facilities_tab
---

# Facilities tab

This tab displays an overview of the levels in the infrastructure, with KPIs and a table that allows you to easily navigate to the rack of the managed devices.

> [!NOTE]
> The *Expected* and *Actual Energy Consumption* KPIs are aggregated on all the different levels of the facilities. On this overview tab, the total values are displayed.
>
> - The *Expected Energy Consumption* is based on the element property *Energy Expected Consumption*. This property can be supplied in the CI Type definition or via the update properties script.
> - To calculate the *Actual Energy Consumption* KPI, an aggregation rule named *Energy Consumption* is needed on the Facilities view. This aggregation rule should be in the folder *RLM*, and it should use the aggregation type *calculate the sum* of the relevant parameter values, and have *Include subview (recursion)* selected. As the expected consumption is measured in kWh, we recommend to also measure the actual consumption in kWh.
