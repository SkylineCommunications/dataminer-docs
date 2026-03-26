---
uid: UIComponentsMatrixParameters
---

# Matrix parameters

Creating a matrix requires a parameter of type "array" and measurement type "matrix". For the read parameter the child tags RawType, LengthType and Type of the Interprete tag must always be set to "other", "next param", and "double", respectively.

```xml
<Param id="4000">
  <Name>matrix</Name>
  <Description>Matrix</Description>
  <Type options="dimensions=64,64;columntypes=4001:0-63">array</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>double</Type>
  </Interprete>
  ...
  <Measurement>
     <Type link="ports.xml" options="matrix=64,64,0,1,0,64">matrix</Type>
     <Discreets>
        <Discreet>
           <Display>Input 1</Display>
           <Value>1</Value>
        </Discreet>
     ...
     </Discreets>
  </Measurement>
  ...
</Param>
```

For the write parameter, the child tags RawType, LengthType and Type of the Interprete tag must always be set to "other", "next param" and "string", respectively (because of the data format being sent by DataMiner).

```xml
<Param id="4010">
  <Name>matrix</Name>
  <Description>Matrix</Description>
  <Type options="dimensions=64,64;columntypes=4001:0-63">write</Type>
  <Interprete>
     <RawType>other</RawType>
     <LengthType>next param</LengthType>
     <Type>string</Type>
  </Interprete>
  ...
  <Measurement>
     <Type>matrix</Type>
  </Measurement>
</Param>
```

Two options are always specified:

- "dimensions", specifying the matrix dimensions.
- "columntypes", referring to another parameter and defining the type of the column. The child tag Type of the Interprete tag of the referred parameter must always be set to "double". The child tags RawType and LengthType of the Interprete tag of the referred parameter must be configured so this can hold a numeric value.

  For example:

  ```xml
  <Param id="4001" trending="false">
      <Name>matrixColumnType</Name>
      <Description>Matrix Column Type</Description>
      <Type>read</Type>
      <Interprete>
          <RawType>numeric text</RawType>
          <LengthType>next param</LengthType>
          <Type>double</Type>
      </Interprete>
  </Param>
  ```

  Or:

  ```xml
  <Param id="4001" trending="false">
      <Name>matrixColumnType</Name>
      <Description>Matrix Column Type</Description>
      <Type>read</Type>
      <Interprete>
          <RawType>unsigned number</RawType>
          <LengthType>fixed</LengthType>
          <Length>1</Length>
          <Type>double</Type>
      </Interprete>
  </Param>
  ```

The measurement type contains matrix options, e.g., `options="matrix=256,256,1,1,0,256"`. This has the following meaning: Number of Inputs, Number of Outputs, Minimum Connected Inputs per Output, Maximum Connected Inputs per Output, Minimum Connected Output per Input, Maximum Connected Output per Input.

The attribute `link="ports.xml"` contains a file name used to store the changed input/output names. This file is located in the folder `C:\Skyline DataMiner\Elements\[Element Name]`.

The inputs and outputs must be defined as discrete entries.
