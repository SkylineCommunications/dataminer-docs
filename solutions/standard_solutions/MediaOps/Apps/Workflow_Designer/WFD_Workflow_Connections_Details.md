---
uid: WFD_Workflow_Connections_Details
---

On top of that, they also have following properties:

- **Type**: At present, only the **Level-based** type is supported. With this type, a connection will be made between the source and the destination based on their levels in the respective virtual signal groups.

- **Subtype**: For level-based connections, several connection execution options are available:

  - **All**: All matching levels between source and destination will be connected.

  - **Predefined subset**: A subset of levels matching between source and destination can be connected. Users can choose from predefined options, such as "all video levels", "all audio levels", "all data levels", or any combination of these (e.g. "all video and all audio levels").

  - **Custom subset**: Only a subset of levels matching between source and destination can be connected, offering flexibiliy beyond the predefined options. This can, for example, allow users to only connect the first audio level between source and destination.

  - **Shuffle**: The content of a level from the source can be connected to a different level on the destination. For example, this allows `Audio 1` and `Audio 2` from the source to be routed to `Audio 3` and `Audio 4` levels on the destination.

- **Execution order**: This value specifies the sequence in which connections defined in a workflow are established during the workflow execution.

- **Execution script**: A script containing custom logic for the execution of the workflow.

> [!NOTE]
> If a workflow is called between a source and a destination that do not contain a sender and a receiver on one of the levels specified in these settings, nothing will be connected.