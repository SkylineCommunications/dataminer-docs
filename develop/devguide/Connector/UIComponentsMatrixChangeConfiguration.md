---
uid: UIComponentsMatrixChangeConfiguration
---

# Dynamically changing matrix configuration

Using the NotifyDataMinerQueued type 128 (NT_UPDATE_PORTS_XML) call, the configuration of a matrix can dynamically be changed. For a detailed description on how to dynamically change the matrix options from a QAction, see NT_UPDATE_PORTS_XML (128).

When a configuration change is performed using this method, the change is stored in the XML file that is referred to in the link attribute of the Measurement.Type tag.

For example, consider the following matrix parameter:

```xml
<Param id="4000">
  <Name>matrixData_Matrix</Name>
  <Description>Matrix</Description>
  <Type options="dimensions=64,64;columntypes=4001:0-63">array</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>double</Type>
  </Interprete>
  <Display>
     <RTDisplay>true</RTDisplay>
     <Positions>…</Positions>
  </Display>
  <Measurement>
     <Type link="ports.xml" options="matrix=64,64,0,1,0,64">matrix</Type>
     <Discreets>…</Discreets>
  </Measurement>
</Param>
```

This defines a 64x64 matrix.

When updating the matrix size to an 8x8 matrix, using the following call:

```csharp
int agentId = 400; // For DELT compatibility.
int elementId = 200;

int parameterId = 4000;
int changeType = 9;

string updateConfig = changeType + ";" + elementId + ";" + parameterId + ";" + agentId;

int inputCount = 8;
int outputCount = 8;

string updateValue = inputCount + ";" + outputCount;

protocol.NotifyDataMinerQueued(128, updateConfig, updateValue);
protocol.SendToDisplay(parameterId);
```

In that case, the XML file will state "8;8" as the value for the physicalSize attritube:

```xml
<Discreets xmlns="http://www.skyline.be/protocol" physicalSize="8;8">…</Discreets>
```
