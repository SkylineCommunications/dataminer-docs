---
uid: InterAppCalls_Introduction
keywords: InterAppCalls, introduction, InterApp
---

# InterApp

InterApp, available through the NuGet package [Skyline.DataMiner.Core.InterAppCalls.Common](https://www.nuget.org/packages/Skyline.DataMiner.Core.InterAppCalls.Common), provides a C# message and response architecture that can be used:

- From element to element and back.
- From Automation script to element and back.
- From external application to element and back.

Its main features are:

- The ability to send a message to an element.
- The ability to wait for a return message.
- The ability to send many messages in a bulk call.
- A user-friendly and flexible way to define any class you want as a message.
- The ability to balance maintainability versus messaging speed as needed for your project.

Its main purpose is for use within large projects where inter-element or inter-automation communication is required, where you can adjust source and destination code to create and parse the messages.

## Requirements

### DataMiner requirements

- The InterApp classes require DataMiner 10.1.0 or higher to function correctly.

### Automation script requirements

- DataMiner version 10.1.0 or higher is required.

### Protocol requirements

- Two parameters were reserved to be used in every protocol that wants to communicate with the InterApp classes. However, you can add additional different custom parameters within their own project if you have control over every protocol and Automation script used in it. This can be efficient in situations where there are many external sources requiring responses from a single element. A few extra receiver-return parameters can reduce traffic in the DataMiner system.

    The following two parameters must always be added and processed by the developer:

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
