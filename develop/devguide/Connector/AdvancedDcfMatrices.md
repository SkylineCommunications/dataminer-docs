---
uid: AdvancedDcfMatrices
---

# DCF and matrices

DCF supports matrix UI components, i.e. you can refer to a matrix parameter in the dynamicId attribute (see dynamicId), which will result in the DCF Connections table being filled in with all the connections of the matrix.

```xml
<ParameterGroups>
   <Group id="1" name="Matrix" type="inout" dynamicId="70" dynamicIndex="*" />
</ParameterGroups>
```

Using the dynamicIndex attribute (see dynamicIndex), it is possible to specify which inputs and outputs should be considered interfaces.

You can specify a separate filter for the matrix inputs and outputs, dynamicIndex="x,y", where x represents the filter for the outputs and y represents the filter for the inputs.

> [!NOTE]
> The filtering happens on the index, not on the label of the input or output.

When the type attribute (see type @) is set to "inout", DCF interfaces will be created for all matching inputs and outputs.

Alternatively, it is possible to introduce two groups, one of type "in" and the other of type "out" (feature introduced in DataMiner 9.0.0 (RN 10661)):

```xml
<ParameterGroups>
   <Group id="2" name="MatrixInputs" type="in" dynamicId="70" dynamicIndex="*" />
   <Group id="3" name="MatrixOutputs" type="out" dynamicId="70" dynamicIndex="*" />
</ParameterGroups>
```

This allows more freedom in naming the interfaces.
