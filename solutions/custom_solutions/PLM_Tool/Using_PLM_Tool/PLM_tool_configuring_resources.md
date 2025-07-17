---
uid: PLM_tool_configuring_resources
---

# Configuring resources

On the Planned Maintenance tool's *Configuration* page, you find two essential configuration tables. These tables are crucial for validating the entered resource's status as a valid entity during the creation process. Set up these resource validation configuration tables before creating maintenance events.

The ***Resource Types* table** delimits the supported resources.

![Configuring resources](~/dataminer/images/Configuring_resources2.png)

To configure a new PLM resource type:

1. Click *Add Type*.

1. Choose a name for the resource type. We recommend choosing a descriptive name that ensures intuitive use of the app.

1. Select *OK*.

> [!NOTE]
>
> - To edit one of the resource types, click the pencil icon next to the type name.
> - To delete one of the resource types, click the *Delete* button in the *Delete Button* column of the resource type.

The ***Resource Subscribers* table** allows the PLM tool to reference both table and standalone parameters for the specified protocol.

![Configuring resources 2](~/dataminer/images/Configuring_resources.png)

To configure a new PLM resource subscriber:

1. Click *Add Resource Subscriber*.

1. In the pop-up window, specify the following information:

   - Select the **type of resource** you want to use. The list of of available resource types consists of the ones listed in the *Resource Types* table.

   - Enter a valid **protocol name**. Ensure that this name matches the case-sensitive protocol name in Cube exactly.

   - Enter a valid **protocol version** that is in use. Ensure this version matches the protocol version in Cube exactly.

   - Enter the **parameter ID** (PID) for the parameter that correlates to the resource being created.

     > [!NOTE]
     > You can use a **table PID**, a **column PID**, or an ID of a **standalone parameter**.
     >
     > - If a **table PID** is provided, the resource name is validated as a **primary key or display key**.
     > - If a **column PID** is used, the validation looks for matching values within the specified column.

1. Select *OK*.
