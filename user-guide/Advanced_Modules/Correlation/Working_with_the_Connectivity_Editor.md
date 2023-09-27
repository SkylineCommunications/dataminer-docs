---
uid: Working_with_the_Connectivity_Editor
---

# Working with the Connectivity Editor

The connectivity editor allows you to create topology chains in order to efficiently locate the root cause of problems. This makes it possible to use DMS Root Cause Analysis (“RCA”): elements or parameters receive an RCA level to indicate the distance to the most probable root cause.

RCA is supported on:

- a collection of elements, virtual functions, or services (chain), or

- a collection of parameters of one specific element (internal chain).

> [!NOTE]
> - Virtual functions are supported in RCA chains from DataMiner 10.1.11/10.2.0 onwards.
> - Virtual function alarms reside on the main element. When multiple virtual functions are defined in different element connectivity chains, the RCA with the highest severity will be shown in the element RCA of the alarm.

In this section:

- [Creating a connectivity chain](xref:Creating_a_connectivity_chain)

- [Creating an internal connectivity chain](xref:Creating_an_internal_connectivity_chain)

- [Managing connectivity chains](xref:Managing_connectivity_chains)

> [!TIP]
> See also:
>
> - [Using the RCA slider](xref:UsingTheRCASlider)
> - [Rui’s Rapid Recap – RCA](https://community.dataminer.services/video/ruis-rapid-recap-rca/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
> - [General Parameters Explained](https://community.dataminer.services/video/general-parameters-explained/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
