---
uid: Changing_an_SLA_into_an_enhanced_service
---

# Changing an SLA into an enhanced service

It is possible to make a modification to the SLA protocol, in order to make the SLA only calculate alarm weights and add alarms to the Active Service Alarms table, but not generate outages. In essence, this reduces the SLA to a kind of enhanced service.

> [!WARNING]
>
> - This configuration option has a serious impact on the functionality of the SLA, and should therefore be applied with extreme care.
> - **Do not enable or disable this option during runtime.**

1. If you are using a version of the Skyline SLA Definition Basic protocol prior to version 3.0.0.3, first add the parameter 2060 to the protocol by copying the following code into the *Protocol.xml* file. This step is not necessary for later versions of the protocol.

   ```xml
   <Param id="2060" save="true" trending="false">
     <Name>enable_enhanced_service_mode</Name>
     <Description>Enhanced Service Mode</Description>
     <Type>read</Type>
     <Information>
       <Text>Enhanced Service Mode</Text>
       <Subtext>
         <![CDATA[Use the SLA as an Enhanced Service.
         No outages will be made. Only the active service alarms are shown.
         Warning!: Though this is faster than just disabling outages.
         Please note that data loss can occur when toggling this setting.
         It is recommended to set this parameter only when the SLA is not in action (no active alarms, no outages).]]>
       </Subtext>
       <Includes>
         <Include>range</Include>
         <Include>steps</Include>
         <Include>units</Include>
         <Include>time</Include>
       </Includes>
     </Information>
     <Interprete>
       <RawType>double</RawType>
       <LengthType>fixed</LengthType>
       <Length>4</Length>
       <Type>double</Type>
       <DefaultValue>0</DefaultValue>
     </Interprete>
     <Measurement>
       <Type>discreet</Type>
       <Discreets>
         <Discreet>
           <Display>Disabled</Display>
           <Value>0</Value>
         </Discreet>
         <Discreet>
           <Display>Enabled</Display>
           <Value>1</Value>
         </Discreet>
       </Discreets>
     </Measurement>
   </Param>
   ```

1. Have an Automation script enable parameter 2060. If necessary, you can also update this parameter using the SLNetClientTest tool. To restore normal SLA functionality, disable parameter 2060.

   > [!WARNING]
   > The DataMiner SLNetClientTest program is an advanced system administration tool that should be used with extreme care (C:\\Skyline DataMiner\\Files\\SLNetClientTest.exe).
