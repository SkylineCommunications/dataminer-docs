---
uid: LogicUseCase2
---

# Use case: Internal flow – element startup

By means of a practical example, this page will illustrate the overall concept of the internal flow when a DataMiner element starts up. The example uses a protocol definition with multiple timers. The purpose of the timer content is independent of the startup sequence.

## The use case

To explain the flow, a practical example is used. Imagine a protocol definition containing three different timers:

- 10 seconds containing Group 1, Group 2 and Group 3
- 15 minutes containing Group 4 and Group 5
- 1 hour containing Group 6

Each of these use the feature to start the timer after the element has started up: initial="true".

```xml
<Timer id="1">
    <Name>Fast Timer (10s)</Name>
    <Time initial="true">10000</Time>
    <Interval>75</Interval>
    <Content>
        <Group>1</Group>
        <Group>2</Group>
        <Group>3</Group>
    </Content>
</Timer>
```

After the element is started up, we would like to verify and configure some items. For example, verify if a user selected a custom configuration (via a parameter) before the element was stopped, or if a default configuration needs to be selected. This selection (parameter) is saved.

> [!NOTE]
> This example is used to keep the explanation of the startup sequence simple. The specific behavior to verify if a user has already selected something can also be obtained via the <DefaultValue> in the parameter.

The parameter:

```xml
<Param id="100" trending="true" save="true">
    <Name>selectedConfiguration</Name>
    <Description>Configuration</Description>
    <Type>read</Type>
    <Information>
        <Subtext>Select the configuration that needs to be applied.</Subtext>
    </Information>
    ...
```

The trigger:

```xml
<Trigger id="1">
    <Name>After Startup</Name>
    <On>protocol</On>
    <Time>after startup</Time>
    <Type>action</Type>
    <Content>
        <Id>1</Id>
    </Content>
</Trigger>
```

The content of the action will be explained later (see [phase 3](#phase-3-element-is-operational) below).

## The startup sequence explained

### The diagram

The diagram below shows the full startup flow from manually starting a stopped element until it is up and running. Each phase will be explained in more detail.

![Internal flow diagram](~/develop/images/InternalFlow_ElementStartup1.png)

### Phase 1: Configuration

When an element starts up, multiple items need to be initialized to have a correctly working component in DataMiner. You can see this in the element log file. Here is short snippet:

```txt
<DateTime>|SLProtocol - 18568 - |2108|CProtocol::InitFunc|CRU|0|ReadSettings
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|Log elementInProtocol
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeDefinitions
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeParameters
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|LoadOthersAndExceptions
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Simulation
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Element data
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::LoadElementDataSinglePIDs|CRU|-1|Querying elementdata
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Reading item data
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Begin processing parameters
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Find ids
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Removing duplicates
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Initializing hash table
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|Loading parameters
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitializeParameters|CRU|-1|done Loading parameters
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeCommands
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeResponses
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializePairs
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeGroups
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeTimers
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeTriggers
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeActions
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeQActions
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|Cleaning QAction Instances
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::InitFunc|CRU|0|InitializeSessions
...
```

In addition, any stored data needs to be retrieved and the parameters have to be loaded. Below you can find another example of what this looks like in the element log file:

```txt
<DateTime>|SLDataMiner.exe - <ElementName>|17912|CElement::Start|DBG|-1|Starting protocol...
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::Start|CRU|-1|Starting SLElement
<DateTime>|SLElement.exe|33076|CElement::StartFunc|CRU|-1|** Starting
<DateTime>|SLElement.exe|33076|CElement::Start2|CRU|-1|** Read DB
<DateTime>|SLElement.exe|33076|CElement::ReadDB|CRU|-1|** Read DB [latch]
<DateTime>|SLElement.exe|33076|CElement::ReadDB|CRU|-1|** Read DB [active alarms]
<DateTime>|SLElement.exe|33076|CElement::LoadProtocol|CRU|-1|** Read Templates
<DateTime>|SLElement.exe|33076|CElement::LoadProtocol|CRU|-1|** Read Templates
<DateTime>|SLElement.exe|33076|ElementStarter::LoadDescriptionParameters|CRU|-1|** Loading parameters from description.xml.
<DateTime>|SLElement.exe|33076|ElementStarter::LoadProtocolParameters|CRU|-1|** Loading parameters from protocol's xml.
<DateTime>|SLElement.exe|33076|ElementStarter::LoadControlProtocolParameters|CRU|-1|** Loading parameters from element control protocol.
...
```

### Phase 2: Element is started (not ready)

At some point, the element is started up. This does not mean that it is already up and running and available for interaction. It means the initialization is done.

If you compare this with driving a car, you are now at the stage where the engine is running. You are not yet driving. There are a few more things to do before it is safe to hit the road.

The moment the first phase is finished, the element log file will contain this line:

```txt
<DateTime>|SLElement.exe|33076|CElement::StartFunc|CRU|-1|** Start Complete
```

At this stage, multiple things will be triggered:

- Starting of the timer threads in case there are timers defined.
- Starting of the protocol thread(s). At this point, SLWatchdog will detect the element’s existence.

From the element log:

```txt
<DateTime>|SLElement.exe|33076|CElement::StartFunc|CRU|-1|** Start Complete
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::StartFunc|CRU|-1|LoadProperties returnes. 0x00000000
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::Start|CRU|-1|Initializing Port
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::Start|CRU|-1|Starting Timers
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::StartTimers|CRU|0|Starting protocol thread.
<DateTime>|SLProtocol - 18568 - <ElementName>|2108|CProtocol::Start|CRU|-1|Starting Protocol done
<DateTime>|SLDataMiner.exe - <ElementName>|17912|CElement::Start|DBG|-1|Complete.
```

Looking at this use case, there are two items to consider:

- A trigger will run when the protocol is started up.
- The timers will execute their content when the element is started up.

#### Trigger after startup

As soon as the protocol is started up, this trigger will run.

Note that this is **before** the threads are started.

```xml
<Trigger id="1">
    <Name>After Startup</Name>
    <On>protocol</On>
    <Time>after startup</Time>
    <Type>action</Type>
    <Content>
        <Id>1</Id>
    </Content>
</Trigger>
```

To compare this again with the car: the trigger to do something is when the engine is running. At that point, you could hit the gas and … drive right into your garage door. Before you start to drive and interact with the world, you need to validate a few things: you want to drive forward, not backward, you don’t want to hit anything, etc. It’s only when this is OK that you can start driving.

In this case, “driving” represents the custom logic you want to run. This means that the safest time to start the logic is **after** the startup of the protocol is completed.

The last thing the startup sequence does is start the protocol thread. After this, it is safe to run logic that will interact with DataMiner. So all you need to do to run your logic safely is add a group to the execution queue and wait until it is run. (See [phase 3](#phase-3-element-is-operational) for more details.)

```xml
<Action id="1"> 
    <Name>After Startup Group</Name> 
    <On id="10">group</On> 
    <Type>execute next</Type> 
</Action> 
```

![Internal flow diagram](~/develop/images/InternalFlow_Timers1.png)

#### Timers are started

Each defined timer will run a timer thread and the content will be moved to the execution queue.

![Internal flow diagram](~/develop/images/InternalFlow_Timers2.png)

In this use case, all timer threads will start at the same time and move their content to the queue. Only when the protocol thread is started, will the groups be executed.

To make sure that the custom logic is executed before all of these groups, the “after startup trigger” will need to move to the top of the queue.

### Phase 3: Element is operational

To detect if all is safe, the “after startup trigger” should add a group to the execution queue. It will stay there until the protocol thread is started. Since this is the last thing the startup flow does before it is completed, we can be sure the content is executed when the element is operational.

The content of the group will contain or trigger the custom logic we want to run. In this use case, it is a QAction run via parameter 2, which will validate the content of parameter 100. If it’s not yet configured (nothing is stored in the database), a default value will be set.

The action run via the “after startup trigger” will add a group at the top of the queue:

```xml
<Action id="1">
    <Name>After Startup Group</Name>
    <On id="2">group</On>
    <Type>execute next</Type>
</Action>
```

The group will run another action once the protocol thread is activated:

```xml
<Group id="2">
    <Name>After Startup</Name>
    <Description>After Startup</Description>
    <Type>poll action</Type>
    <Content>
        <Action>2</Action>
    </Content>
</Group>
```

The action will force a change on the parameter with ID 2, causing a QAction to run.

```xml
<Action id="2">
    <Name>After Startup QAction</Name>
    <On id="2">parameter</On>
    <Type>run actions</Type>
</Action>
```