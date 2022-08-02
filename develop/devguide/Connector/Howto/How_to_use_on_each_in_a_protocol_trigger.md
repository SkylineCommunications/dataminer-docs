---
uid: How_to_use_on_each_in_a_protocol_trigger
---

# How to use 'on each' in a protocol trigger

This article details how to implement and use the *on each* feature of a trigger defined in a protocol.

## User skills required

- Basic knowledge of protocols.
- Basic knowledge of how to use DataMiner Cube.

## What is a protocol trigger?

A protocol trigger is used to start a flow when a certain condition is met. This condition can be a click of a button, a change of a value, a response having been retrieved, etc. It can also be forced via logic in a QAction.

The definition of a trigger will commonly contain an indication of when it should run. This is done by combining `On` and `Time`.

- **On**: The root of the trigger, e.g. a parameter.
- **Time**: The condition the root must have to activate the trigger, e.g. a change.

For example, when the reconnect button (parameter ID 13) is clicked, a flow needs to run (action ID 50):

Definition of the trigger:

```xml
<Trigger id="13">
   <Name>onBtnClickReconnect</Name>
   <On id="13">parameter</On>
   <Time>change</Time>
   <Type>action</Type>
   <Content>
      <!--Run reconnect Flow-->
      <Id>50</Id>
   </Content>
</Trigger>
```

Definition of the action that will initiate the flow in the group with ID 50:

```xml
<Action id="50">
   <Name>runTelnetLogin</Name>
   <On id="50">group</On>
   <Type>execute</Type>
</Action>
```

## What is the 'on each' feature?

With the *on each* feature, the trigger will run as soon as any of the root sources (e.g. a parameter) meet the trigger requirements (e.g. a change) **and** there is **no other trigger** defined for this root source with the same requirements.

This means it will act like an *IF NOT – THEN* statement. If there is no trigger with *On id = x + Parameter change*, the *on each* trigger will run. Otherwise, it will be skipped and the dedicated trigger for that parameter will run.

To use this feature, replace the ID value with *each*:

```xml
<On id="each">...</On>
```

For more information on triggers, see [](xref:Protocol.Triggers).

## How to

The example below shows an integration that needs to run a **common** flow after receiving a supported "allowed" serial response, and an **exception** flow after receiving a supported "bad" response, e.g. when a data source returns the message "Unknown command" or "Bad format".

Trigger ID 1000 will run for all the responses except the responses with ID 1 and 2:

```xml
<Trigger id="1000">
   <Name>afterEachResponse</Name>
   <On id="each">response</On>
   <Time>after</Time>
   <Type>action</Type>
   <Content>
      <!--Run Common flow-->
      <Id>1000</Id>
   </Content>
</Trigger>
<Trigger id="1001">
   <Name>afterUnknownCommandResponse</Name>
   <On id="1">response</On>
   <Time>after</Time>
   <Type>action</Type>
   <Content>
      <!--Run Exception flow-->
      <Id>1001</Id>
   </Content>
</Trigger>
<Trigger id="1002">
   <Name>afterBadFormatResponse</Name>
   <On id="2">response</On>
   <Time>after</Time>
   <Type>action</Type>
   <Content>
      <!--Run Exception flow-->
      <Id>1001</Id>
   </Content>
</Trigger>
```

A trigger using different requirements does not count as the exception on the *on each*. For example, the above-mentioned trigger ID 1000 will still run after response ID 10, as the definition below runs before response 10. The requirement is different, so the *on each* is not skipped.

```xml
<Trigger id="2010">
   <Name>beforeTemperatureResponse</Name>
   <On id="10">response</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <!--Do something-->
      <Id>2010</Id>
   </Content>
</Trigger>
```
