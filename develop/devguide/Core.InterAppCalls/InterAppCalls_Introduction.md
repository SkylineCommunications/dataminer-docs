---
uid: InterAppCalls_Introduction
keywords: InterAppCalls, InterApp
---

# About the InterApp framework

The InterApp framework, available through the NuGet package [Skyline.DataMiner.Core.InterAppCalls.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.InterAppCalls.Common), provides a C# message and response architecture that can be used in several ways:

- From element to element and back.
- From Automation script to element and back.
- From application on the same server to element and back.

Using InterApp calls provides you with:

- The ability to send a message to an element.
- The ability to wait for a return message.
- The ability to send many messages in a bulk call.
- A user-friendly and flexible way to define any class you want as a message.
- The ability to balance maintainability versus messaging speed as needed for your project.

The InterApp framework is mainly intended to be used within large projects where inter-element or inter-Automation communication is required, so you can adjust source and destination code to create and parse the messages.

## Requirements

### DataMiner requirements

There are currently two ranges of the InterApp framework:

1.0.X: This range requires at least DataMiner version 10.1.0.
1.1.X: This range requires at least DataMiner version 10.4.0.

Note that using DataMiner **10.3.12 or higher is highly recommended** is highly recommended, as this version introduces significant efficiency increases, as illustrated in the metrics below.

   ![small-medium size messages graph](~/develop/images/InterApp_Metrics_SmallMedium.png)

   ![huge size messages graph](~/develop/images/InterApp_Metrics_Huge.png)

### Connector requirements

Two parameters have been reserved to be used in every protocol that wants to communicate with the InterApp classes. However, you can add additional different custom parameters within a project if you have control over every protocol and Automation script used in it. This can be efficient in situations where there are many external sources requiring responses from a single element. A few extra receiver-return parameters can reduce traffic in the DataMiner System.

The following two parameters must always be added and processed:

```xml
<Param id="9000000" trending="false">
   <Name>interApp_receive</Name>
   <Description>Inter App Receiver</Description>
   <Information>
      <Subtext>Contains the raw serialized InterApp Command (InterAppCall or Message) sent from an external source.</Subtext>
   </Information>
   <Type>read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
   <Display>
      <!--Used for Inter App communication.-->
      <RTDisplay onAppLevel="true">true</RTDisplay>
   </Display>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
<Param id="9000001" trending="false">
   <Name>interApp_return</Name>
   <Description>Inter App Return</Description>
   <Information>
      <Subtext>Contains the raw serialized Message that serves as a response to an external source.</Subtext>
   </Information>
   <Type>read</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
   <Display>
      <!--Used for Inter App communication.-->
      <RTDisplay onAppLevel="true">true</RTDisplay>
   </Display>
   <Measurement>
      <Type>string</Type>
   </Measurement>
</Param>
```
