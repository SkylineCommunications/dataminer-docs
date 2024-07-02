---
uid: InterAppCalls_GettingStarted
---

# Getting Started

> [!NOTE]
> An example connector "Skyline Example InterAppCalls" is available in the [SkylineCommunications/SLC-C-Example_InterAppCalls](https://github.com/SkylineCommunications/SLC-C-Example_InterAppCalls) GitHub repository.

Begin by checking and applying everything to meet the DataMiner, DIS, connector and optional Automation script requirements.

Now there are 4 steps for development:

- [Creating an API with messages that define the data you want to share.](xref:InterAppCalls_GettingStarted_CreatingApi)
- [Creating executors that define how to process a message.](xref:InterAppCalls_GettingStarted_CreatingExecutor)
- [Receiving a call.](xref:InterAppCalls_GettingStarted_ReceivingCall)
- [Sending a call.](xref:InterAppCalls_GettingStarted_SendingCall)

## Connector requirements

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
