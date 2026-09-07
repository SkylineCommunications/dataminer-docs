---
uid: LogicExamples
---

# Examples

The following examples illustrate how protocol components can be combined in order to implement functionality.

- Periodically retrieving a MIB variable
- Periodically incrementing a parameter value
- Executing a QAction after startup

## Periodically retrieving a MIB variable

In order to periodically retrieve a MIB variable, a timer needs to be defined and set to the desired interval (e.g., 10s). Then a [Group](xref:Protocol.Groups.Group) is defined of type "poll", containing a [Param](xref:Protocol.Params.Param) to be polled. The parameter definition includes the [OID](xref:Protocol.Params.Param.SNMP.OID) of the variable that must be retrieved via SNMP.

```mermaid
flowchart LR
    subgraph timerBox["Timer 1"]

        G1["Group 1"]
    end
    subgraph groupBox["Group 1"]

        S1["Param 1"]
    end
    subgraph paramBox["Param 1"]
    end

    G1 --> groupBox
    S1 --> paramBox

    classDef infoText fill:none,stroke:none,color:#FFFFFF
    classDef infoTextBlack fill:none,stroke:none,color:#000000
    class groupDesc,sessionDesc infoText
    class timerDesc infoTextBlack

    style timerBox fill:#EFF6FF,stroke:#DBEAFE,color:#000000
    style groupBox fill:#2563EB,stroke:#1E40AF,color:#FFFFFF
    style paramBox fill:#1E3A8A,stroke:#172554,color:#FFFFFF
    style G1 fill:#2563EB,stroke:#1E40AF,color:#FFFFFF
    style S1 fill:#1E3A8A,stroke:#172554,color:#FFFFFF
```

## Periodically incrementing a parameter value

The following diagram shows the components needed to let a parameter increment its value every 10 seconds. In this example, an [Action](xref:Protocol.Actions.Action) of type [increment](xref:LogicActionIncrement) is used on a parameter.

```mermaid
flowchart LR
    subgraph timerBox["Timer 1"]

        G1["Group 1"]
    end
    subgraph groupBox["Group 1"]

        S1["Action 1"]
    end
    subgraph actionBox["Action 1"]
        C1["Param 1"]
    end

    subgraph paramBox["Param 1"]
    end

    G1 --> groupBox
    S1 --> actionBox
    C1 --> paramBox

    classDef infoText fill:none,stroke:none,color:#FFFFFF
    classDef infoTextBlack fill:none,stroke:none,color:#000000
    class groupDesc,sessionDesc infoText
    class timerDesc infoTextBlack

    style timerBox fill:#EFF6FF,stroke:#DBEAFE,color:#000000
    style groupBox fill:#2563EB,stroke:#1E40AF,color:#FFFFFF
    style actionBox fill:#1E3A8A,stroke:#172554,color:#FFFFFF
    style paramBox fill:#f3f4f6,stroke:#172554,color:#000000
    style G1 fill:#2563EB,stroke:#1E40AF,color:#FFFFFF
    style S1 fill:#1E3A8A,stroke:#172554,color:#FFFFFF
    style C1 fill:#f3f4f6,stroke:#172554,color:#000000
```

## Executing a QAction after startup

The following example illustrates how to execute logic defined in a QAction after a DMA element has completely started. First, a [Trigger](xref:Protocol.Triggers.Trigger) is defined triggering after startup (`<Time>after startup</Time>`) of the protocol (`<On>protocol</On>`). This trigger will execute an [Action](xref:Protocol.Actions.Action) that adds Group 2 to the group execution queue.

This Group in turn executes an action of type [run actions](xref:LogicActionRunActions) on Param 2. Actions of type `run actions`  execute the QAction linked with the specified parameter (via the [QAction@trigger](xref:Protocol.QActions.QAction-triggers)).

By using a group, we ensure that the QAction will be executed after the main protocol thread has started.

```mermaid
flowchart LR
    subgraph triggerBox["Trigger 1"]
        A1["Action 1"]
    end
    subgraph action1Box["Action 1"]
        G1["Group 2"]
    end
    subgraph groupBox["Group 2"]
        A2["Action 2"]
    end
    subgraph action2Box["Action 2"]
        P1["Param 2"]
    end
    subgraph qactionBox["QAction 2"]
    end

    A1 --> action1Box
    G1 --> groupBox
    A2 --> action2Box
    P1 --> qactionBox

    classDef infoText fill:none,stroke:none,color:#FFFFFF
    classDef infoTextBlack fill:none,stroke:none,color:#000000
    class groupDesc,sessionDesc infoText
    class timerDesc infoTextBlack

    style triggerBox fill:#EFF6FF,stroke:#DBEAFE,color:#000000
    style action1Box fill:#2563EB,stroke:#1E40AF,color:#FFFFFF
    style groupBox fill:#1E3A8A,stroke:#172554,color:#FFFFFF
    style action2Box fill:#f3f4f6,stroke:#f3f4f6,color:#000000
    style qactionBox fill:#d1d5db,stroke:#d1d5db,color:#000000
    style A1 fill:#2563EB,stroke:#1E40AF,color:#FFFFFF
    style G1 fill:#1E3A8A,stroke:#172554,color:#FFFFFF
    style A2 fill:#f3f4f6,stroke:#172554,color:#000000
    style P1 fill:#d1d5db,stroke:#d1d5db,color:#000000
```

```xml
<Protocol>
  <Params>
	<Param id="2">
		<Name>AfterStartup</Name>
		<Description>After Startup</Description>
		<Type>dummy</Type>
	</Param>
  </Params>
  <Triggers>
	<Trigger id="1">
		<Name>After Startup</Name>
		<On>protocol</On>
		<Time>after startup</Time>
		<Type>action</Type>
		<Content>
			<Id>1</Id>
		</Content>
	</Trigger>
  </Triggers>
  <Actions>
	<Action id="1">
		<Name>After Startup Group</Name>
		<On id="2">group</On>
		<Type>execute next</Type>
	</Action>
	<Action id="2">
		<Name>After Startup QAction</Name>
		<On id="2">parameter</On>
		<Type>run actions</Type>
	</Action>
  </Actions>
  <Groups>
	<Group id="2">
		<Name>After Startup</Name>
		<Description>After Startup</Description>
		<Type>poll action</Type>
		<Content>
			<Action>2</Action>
		</Content>
	</Group>
  </Groups>
  <QActions>
    <QAction id="2" name="After Startup" encoding="csharp" triggers="2" />
        ...
    </QAction>
  </QActions>
</Protocol>
```
