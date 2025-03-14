---
uid: WFD_Workflow_Connections_Details
---

On top of that, they also have following properties:

- **Type**: At present, only the **Level-based** type is supported. With this type, a connection will be made between the source and the destination based on their levels in the respective virtual signal groups.

- **Subtype**: Within a level-based connection, there are several options for the exact connection execution:

  - **All**: All matching levels between source and destination will be connected.

  - **Predefined subset**: A subset of levels matching between source and destination can be connected. Users can choose between a number of predefined options, including "all video levels", "all audio levels", "all data levels", or any combination of these (e.g. all video and all audio levels).

  - **Custom subset**: Only a subset of levels matching between source and destination can be connected, which goes beyond the options available for a predefined subset. This can, for example, allow users to only connect the first audio level between source and destination.

  - **Shuffle**: The content of a level from the source can be connected to a different level on the destination. This can, for example, be used to connect the content of levels Audio 1 and Audio 2 on the source to levels Audio 3 and Audio 4 on the destination.

- **Execution order**: This number determines the order in which the different connections defined in a workflow will be set up during the workflow execution.

- **Execution script**

> [!NOTE]
> If a workflow is called between a source and a destination that do not contain a sender and a receiver on one of the levels specified in these settings, nothing will be connected.