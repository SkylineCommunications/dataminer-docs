---
uid: LogicUseCase3
---

# Use case: Internal flow – QActions

By means of practical examples, this page will illustrate the overall concept of the internal flow when an element uses a protocol definition that needs to interact with scripting (QActions). This concept can be applied as a basic structure on any definition.

## The use cases

To explain the flow, several practical examples are used. These will also show some pitfalls that need to be considered when designing the QAction (C#) architecture.

Note that to uphold the best possible performance, the interaction between processes must be reduced to a minimum. One of the use cases indicates that it is possible to run a QAction from a QAction. Even when this is feasible or seems necessary, it is better to stay within SLScripting and run the logic right away instead of passing via SLProtocol. You can achieve this by making shared code available in a precompiled QAction and importing it in the QAction at hand.

```xml
<QAction id="1" name="Precompiled Code" encoding="csharp" options="precompile">
...
</QAction>
<QAction id="2" name="Process New Alarms" encoding="csharp" triggers="2" dllImport="[ProtocolName].[ProtocolVersion].QAction.1.dll">
...
</QAction>
<QAction id="3" name="Process New Events" encoding="csharp" triggers="3" dllImport="[ProtocolName].[ProtocolVersion].QAction.1.dll">
...
</QAction>
```

QActions 2 and 3 will only contain the core structure to execute the goal, while QAction 1 will contain the functionality to make it happen. The benefit of this is that both QAction 2 and 3 can reuse overlapping functionality without the need to trigger QAction 1 via SLProtocol.

## The diagram

The diagram will cover only one SLProtocol process. At runtime, multiple processes will be running, each handling multiple elements.

> [!NOTE]
> By default, this is independent of the assigned protocol definition, but it is possible to configure DataMiner to have [one SLProtocol process per running protocol definition](xref:Configuration_of_DataMiner_processes#configuring-a-separate-slprotocol-process-for-every-protocol-used).

There is always a main entry point available for handling incoming requests from any queue. For any additional connection, an extra entry point is generated. If an incoming request is busy, the entry point will be blocked for any other interactions.

Note that by default, each of these entry points will link to the main queue that is processed via the protocol thread. With an extra feature defined in the protocol definition, it is possible to create extra queues for a specific entry point (connection).

Imagine the protocol definition has two connections defined. By adding the feature below, three queues can be used to process logic in parallel of each other.

```xml
<Threads>
    <Thread connection = "0"/> <!--Queue via MAIN EntryPoint-->
    <Thread connection = "1"/> <!--Queue via 2nd EntryPoint-->
    <Thread connection = "1001"/> <!--Extra Queue via MAIN EntryPoint -->
</Threads>
```

![Internal flow diagram](~/develop/images/InternalFlow_QActions1.png)

## The flow explained

### Case 1: Group running a QAction when a button is clicked

Imagine you need to run a specific piece of logic every hour. For example, copying files from one location to another. Another feature is a button to create a new folder in a specific location.

It is possible that a user will click the “Create New Folder” button at the same time as the recurring logic is running. The diagram below describes what happens when the definition follows these two flows:

**Recurring copy files feature:**

- Timer (1h) > Group (poll action) > Action (run actions) > Parameter (ID = 11) > QAction 1 (CopyFiles method)

**Create new folder feature:**

- Parameter (ID = 10) > QAction 1 (CreateFolder method)

Note that the timer thread is not included in the diagram. It will move the group at the bottom of the MAIN queue. Since the last group the timer needs to add is of type poll (we only have 1 group that is of type poll action), the timer will wait until this group is removed from the queue before adding the group(s) defined in its content again.

By way of example, let’s take a timer of 1 second with 2 groups in its content. The actual execution of the 2 groups takes up 5 seconds. When the last defined group in the timer’s content is of type poll, the timer will wait until this is done even when the defined timing was 1 second. This results in the timer moving the 2 groups to the queue every 5 seconds instead of every 1 second, avoiding an overflow of the queue.

```xml
<Timer id="1">
    <Name>Very Fast Timer (1s)</Name>
    <Time initial="true">1000</Time>
    <Interval>75</Interval>
    <Content>
        <Group>1</Group> <!--Do something for 2 seconds-->
        <Group>2</Group><!--Do something for 3 seconds-->
    </Content>
</Timer>
```

**Conclusion**: The recurring copy files feature is currently active, causing the SET to wait until it is finished.

![Internal flow diagram](~/develop/images/InternalFlow_QActions2.png)

### Case 2: User click initiates a logical flow that triggers a new flow

This use cases contains a very dangerous pitfall. With this structure, it is possible to generate an endless loop if the logic in the QAction is badly formed.

Important: Sets done on parameters from within a QAction are always considered as change events, even when the parameter value does not change. Because of this, the QAction that uses the parameter as trigger will be initiated.

We will use the same case of creating a folder and syncing files. Imagine that we also need to sync the files after creating a new folder. We could do this by forcing a change event on the parameter 11 so it would run the SyncFiles method.

> [!NOTE]
> It is better to run the SyncFiles method right away and not via protocol, to reduce the required interaction between different processes.

The QAction is defined like this:

```xml
<QAction id="1" name="Create folder and-or Sync Files" encoding="csharp" triggers="10;11">
```

Logic:

- On change event of parameter 10, the folder is created, and a set is done on parameter 11.
- On change event of parameter 11, the files are synced.

![Internal flow diagram](~/develop/images/InternalFlow_QActions3.png)

As shown in the diagram, an extra instance of QAction 1 will be generated (depth 1) when the set is done on the parameter.

Imagine the C# code run via parameter 10 (create folder) looks like this:

```csharp
CreateFolder(folderName);
// Force sync.
protocol.SetParameter(11, "Run");
// Validate.
ValidateSync();
```

The set on the parameter will run a new instance of QAction 1 to sync the files. Only after this is done, will the code move to the next part: ValidateSync.

![Internal flow diagram](~/develop/images/InternalFlow_QActions4.png)

When this is done, the set of the user is removed from the (set) queue of the SetParamThread.

![Internal flow diagram](~/develop/images/InternalFlow_QActions5.png)

An alternative to this use case would be to execute the sync via the (group) queue of the protocol thread. Syncing could take some time and the user interaction should not be blocked because of it.

- User clicks button: Create the folder right away.
- Once the folder is created, add a to-do to sync. This would be a trigger > action that will execute a group.

As soon as the group is in the queue, the user’s click is finished, and another SET can be handled. For example, create another folder. The logic could detect this and indicate that a sync is already on the to-do list instead of adding another lengthy operation, making the whole process more efficient and smooth.

### Case 3: Two users clicking at the same time on different elements

Each element can be considered to run in its own container regardless of the protocol definition it is using. The diagram below shows two different elements using the same protocol definition. When two users make a change at the same time, the corresponding logic for each element will run independently from each other.

![Internal flow diagram](~/develop/images/InternalFlow_QActions6.png)
