# Working with the Connectivity Editor

The connectivity editor allows you to create topology chains in order to efficiently locate the root cause of problems. This makes it possible to use DMS Root Cause Analysis (“RCA”): elements or parameters receive an RCA level to indicate the distance to the most probable root cause.

RCA is supported on:

- a collection of elements, virtual functions, or services (chain), or

- a collection of parameters of one specific element (internal chain).

> [!NOTE]
> -  Virtual functions are supported in RCA chains from DataMiner 10.1.11/10.2.0 onwards.
> -  Virtual function alarms reside on the main element. When multiple virtual functions are defined in different element connectivity chains, the RCA with the highest severity will be shown in the element RCA of the alarm.

In this section:

- [Creating a connectivity chain](Creating_a_connectivity_chain.md)

- [Creating an internal connectivity chain](Creating_an_internal_connectivity_chain.md)

- [Managing connectivity chains](Managing_connectivity_chains.md)

> [!TIP]
> See also:
> -  [Using the RCA slider](../../part_2/alarms/Working_with_the_Alarm_Console.md#using-the-rca-slider) 
> -  *<https://community.dataminer.services/video/ruis-rapid-recap-rca/>* 
>
