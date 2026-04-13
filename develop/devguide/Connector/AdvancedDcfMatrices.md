---
uid: AdvancedDcfMatrices
---

# DCF and matrices

DCF supports matrix UI components, i.e., you can refer to a matrix parameter in the [dynamicId](xref:Protocol.ParameterGroups.Group-dynamicId) attribute, which will result in the DCF Connections table being filled in with all the connections of the matrix.

```xml
<ParameterGroups>
   <Group id="1" name="Matrix" type="inout" dynamicId="70" dynamicIndex="*" />
</ParameterGroups>
```

Using the [dynamicIndex](xref:Protocol.ParameterGroups.Group-dynamicIndex) attribute, it is possible to specify which inputs and outputs should be considered interfaces.

You can specify a separate filter for the matrix inputs and outputs, dynamicIndex="x,y", where x represents the filter for the outputs and y represents the filter for the inputs.

> [!NOTE]
> The filtering happens on the index, not on the label of the input or output.

When the [type](xref:Protocol.ParameterGroups.Group-type) attribute is set to "inout", DCF interfaces will be created for all matching inputs and outputs.

Alternatively, it is possible to introduce two groups, one of type "in" and the other of type "out"<!--  RN 10661 -->:

```xml
<ParameterGroups>
   <Group id="2" name="MatrixInputs" type="in" dynamicId="70" dynamicIndex="*" />
   <Group id="3" name="MatrixOutputs" type="out" dynamicId="70" dynamicIndex="*" />
</ParameterGroups>
```

This allows more freedom in naming the interfaces.
