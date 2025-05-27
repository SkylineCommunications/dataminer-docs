---
uid: ConnectionsSerialPairs
---

# Pairs

Once commands and responses have been created, these can be grouped into pairs. A pair typically contains a command and the response that is expected from the device after sending that command. Another typical scenario is to have a pair containing one command and multiple responses (See [Defining multiple responses in a pair](#defining-multiple-responses-in-a-pair)). It is also possible to just add a command to a pair without specifying a response. This can be done for example in case no response is expected back from the device.

Multiple pairs can be defined in a protocol (in the Pairs tag), each defined using a Pair tag with a unique identifier.

```xml
<Pair id="1">
   <Name>GetStatusPair</Name>
   <Content>
      <Command>1</Command>
      <Response>1</Response>
  </Content>
</Pair>
```

This pair can then be added to a group which in turn is added to a timer. In the following example, the timer will add the group to the group execution queue at the specified interval.

![Timer executing a pair](~/develop/images/Connection_Types_-_Pairs_Building_Blocks.svg)

> [!NOTE]
>
> - The number of pairs in a group should be limited to 10.
> - An example protocol "SLC SDF Serial - Pairs" is available in the [Protocol Development Guide Companion Files](https://community.dataminer.services/documentation/protocol-development-guide-companion-files/).

## Clearing responses

Suppose two pairs are defined, where each pair consists of a command and a response. The two responses use the same parameter A:

![Two responses using the same parameter](~/develop/images/two_responses_using_same_parameter.svg)

In addition, two triggers are defined, one after response 1 and another one after response 2. Both triggers trigger the execution of a QAction that processes the value of parameter A. Now consider the following sequence:

1. Suppose command 1 is sent and the device sends a response back matching response 1 and parameter A receives value "A". Now the trigger triggers and when the value of the parameter is retrieved in the QAction, "A" is returned.
1. Next, command 2 is sent and the device sends a response back matching response 2 and parameter A receives value "D". Now the trigger triggers and when the value of the parameter is retrieved in the QAction, "D" is returned.
1. Now command 1 is sent again and the device sends back the same response as in step one. Now the trigger will again go off, but when the value of parameter A is retrieved in the QAction, "D" is returned instead of the expected value "A". This is because DataMiner keeps responses in memory. As response 1 in step 3 was identical to response 1 in step 1, the response parameters (parameter A in this case) were not updated.

In order to obtain the correct behavior in this case, it is important to clear responses via an action "clear response".

> [!NOTE]
> Typically, different responses will not reuse the same parameters.

> [!TIP]
> See also: [Change-based event handling](xref:InnerWorkingsChangeBasedEventHandling)

## Defining multiple responses in a pair

In case multiple responses are defined in a pair, DataMiner will try to match an incoming response with the defined responses in the order in which they are defined in the pair.

When working with multiple responses, it is important to perform a "clear response" action triggered by an "after response" trigger. In case a response matches, all other responses must be cleared.

The following example illustrates why the other response(s) need to be cleared upon matching a response. Consider a pair consisting of one command and two responses. Response 1 matches a device response indicating the command succeeded while response 2 matches a device response indicating an error occurred. Parameter C is a status parameter displayed on a page indicating whether commands sent to the device succeed or not and gets updated on a change of either parameter A or B.

![Pair with two responses, response 1 matches](~/develop/images/Pair_with_two_responses_1.svg)

Now suppose a command has been sent to the device and the device responds the command succeeded. Therefore, response 1 matches and parameter A receives value "OK".

The next command that is sent to the device fails. Consequently, response 2 matches and parameter C gets updated indicating "Error".

![Pair with two responses, response 2 matches](~/develop/images/Pair_with_two_responses_2.svg)

The following command that is executed again succeeds. However, as response 1 has not been cleared when a response matching response 2 has been received, parameter A already holds value "OK" and therefore parameter C will not get updated as there is no change event.

![Pair with two responses, response 1 matches again](~/develop/images/Pair_with_two_responses_3.svg)

In the example above, response 1 should be cleared upon matching response 2 and vice versa. The following protocol fragment illustrates how to clear response 1 after receiving response 2:

```xml
<Action id="1">
   <Name>Clear Response</Name>
   <On id="1">response</On>
   <Type>clear</Type>
</Action>

<Trigger id="2">
   <Name>After Response Trigger</Name>
   <On id="2">response</On>
   <Time>after</Time>
<Type>action</Type>
   <Content>
      <Id>1</Id>
   </Content>
</Trigger>
```
