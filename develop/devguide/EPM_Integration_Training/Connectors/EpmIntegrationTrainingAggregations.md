---
uid: EpmIntegrationTrainingAggregations
---

# Aggregate and merge actions

## Aggregate actions

Because of the way the EPM architecture is structured, it allows the calculation of many aggregated KPIs. This is done using [aggregation](xref:LogicActionAggregate) actions.

For example:

```xml
<Action id="8004">
    <Name>aggregateRegionNumberEndpoints</Name>
    <On id="7005">parameter</On>
    <Type options="groupby:2;type:sum;return:8004;ignoreValues:-1,2/-1;threaded;avoidZeroInResult;defaultValue:8004,-1">aggregate</Type>
</Action>
```

Aggregation actions are used to aggregate data from within the same element. For example, BE elements will aggregate the Region KPIs from the Sub-Region table as all the information is in the element.

> [!NOTE]
> For recursive and many-to-many relations, aggregation operations can be done by removing the *groupBy* option. The *groupBy* option is not necessary if a valid relation is found, but it is added to reduce the load on the system.

## Merge actions

If KPI data is located outside of the element, e.g. Network KPIs (located at the FE) aggregated from the Region KPIs (located at the BE level), then [merge](xref:LogicActionMerge) actions are used.

These actions are an extension of aggregation actions. A merge request is sent out to multiple elements, and then the responses are "merged" together to set the table.

For example:

```xml
<Action id="9003">
    <Name>mergeNetworkNumberEndpoints</Name>
    <On>protocol</On>
    <Type options="remoteElements:801;trigger:19003;type:sum;destination:9003;mergeResult;limitresult:9001;defaultValue:9003,-1">merge</Type>
</Action>
```

This action is like an aggregation action, but instead of being applied to a column that it retrieves data from, it is applied to a protocol. Also important is that *remoteElement* points to a *columnPid* containing all the BE elements, and the *trigger* option denotes a parameter ID that will be triggered to initiate the merge request.

The flow of the receiver of the merge request is as follows:

1. Parameter:

   ```xml
   <Param id="19003">
       <Name>mergeNetworkNumberEndpoints</Name>
       <Description>Merge Network Number Endpoints</Description>
       <Type>write</Type>
       <Interprete>
           <RawType>numeric text</RawType>
           <Type>double</Type>
           <LengthType>next param</LengthType>
       </Interprete>
   </Param>
   ```

1. Trigger:

   ```xml
   <Trigger id="19003">
       <Name>onChangeNetworkNumberEndpoints</Name>
       <On id="19003">parameter</On>
       <Time>change</Time>
       <Type>action</Type>
       <Content>
           <Id>19003</Id>
       </Content>
   </Trigger>
   ```

1. Action:

   ```xml
   <Action id="19003">
       <Name>aggregateNetworkNumberEndpoints</Name>
       <On id="8004">parameter</On>
       <Type options="groupby:2;type:sum;threaded;ignoreValues:-1,2/-1">aggregate</Type>
   </Action>
   ```

The action is an aggregation action, and there is no need to add the return option, as the BE elements should not set their tables with this information. All that should happen is that the KPIs are calculated and then sent to the FE.
