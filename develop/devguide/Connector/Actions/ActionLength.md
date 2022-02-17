---
uid: LogicActionLength
---

# length

Can be used on command and responses

## On command

This action calculates the length of the command as defined in the length parameter of the command.

For commands, this action can be used to set the length of the command.

> [!NOTE]
> The length action needs to be performed after the make command action.

### Attributes

#### On@id

The ID(s) of the command(s).

## On response

This action will calculate the length of the response as defined in the length parameter of the response.

For responses, the length action will check all parameters of type "length" in the response. For each of these parameters, it will verify whether the value received for this parameter in the response corresponds with the calculated length in the Length tag. For example, consider the following length parameter used in a response:

### Attributes

#### On@id

The ID(s) of the response(s).


## Examples

```xml
<Trigger id="3">
   <Name>BeforeCommandTrigger</Name>
   <On id="each">command</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>3</Id><!-- MakeCommand -->
      <Id>5</Id><!-- GetCommandLength-->
   </Content>
</Trigger>
<Action>
   <Name>GetCommandLength</Name>
   <On>command</On>
   <Type>length</Type>
</Action>
```

Example on response:

Consider the following length parameter used in a response:

```xml
<Param id="300" trending="false">
   <Name>responseCLengthField</Name>
   <Description>Length Field</Description>
   <Type>length</Type>
   <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>fixed</LengthType>
      <Length>2</Length>
      <Type>double</Type>
   </Interprete>
   <Length>
      <Content>
         <Param>3</Param>
      </Content>
   </Length>
</Param>
```

In the example above, the length action will verify whether the length of the fourth parameter in the response (`<Param>3</Param>`), corresponds with the value for this parameter in the response.

> [!NOTE]
> In case the Length tag is missing in the parameter of type “length”, then the sum of the length of all parameters will be taken (except of these of type "length") and compared to the value received for this parameter.

DataMiner will then compare this calculated value with the value sent in the response of the device. When the two values differ, a length error will be generated.

Note that the length action needs to be performed after the read response action (For more information, refer to Composing responses).

```xml
<Trigger id="3">
   <Name>BeforeResponseTrigger</Name>
   <On id="each">response</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>4</Id><!-- ReadResponse -->
      <Id>6</Id><!-- GetResponseLength-->
   </Content>
</Trigger>
<Action>
   <Name>GetResponseLength</Name>
   <On>response</On>
   <Type>length</Type>
</Action>
```
