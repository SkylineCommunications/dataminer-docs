---
uid: ST_Specifying_root_cause_info
---

# Specifying root cause information in a service template

In the *RCA* tab of a service template card, you can indicate the relationship between the elements in the service, so that alarms will contain root cause information.

To determine an RCA chain in a service template:

1. In the *RCA* tab, click the button *Start configuring RCA connectivity chain*.

1. In the box that appears in the middle of the tab, select the child element you want to start from.

1. Right-click the box and:

   - Select *Add parent* to add a child element higher in the chain.

   - Select *Add child* to add a child element lower in the chain.

1. In the additional box, select the correct child element.

1. Repeat from step 3 until all the necessary elements have been added to the chain.

   If you add an element too many, you can delete it again from the chain by right-clicking the box and selecting *Delete*.

> [!NOTE]
> You can only determine an RCA chain if a service template has at least two child elements.

> [!TIP]
> See also: [Working with the Connectivity Editor](xref:Working_with_the_Connectivity_Editor)
