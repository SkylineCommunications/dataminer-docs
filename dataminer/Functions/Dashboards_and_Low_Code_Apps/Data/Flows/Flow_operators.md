---
uid: Flow_operators
---

# Flow operators

An operator is a step within a dashboard or low-code app flow that starts from at least one input and transforms it into a single output.

Below, you can find an overview of the available operators.

> [!NOTE]
> There is a maximum of 10 inputs for one single operator.

## Debounce

Delays the emission of a value until a specified time has passed without receiving another value.

![Debouncing an input value](~/dataminer/images/Flow_OperatorDebounce.gif)<br>
*Debouncing an input value in DataMiner 10.4.12*

This could for example be used to apply a buffer to rapidly changing data (e.g., a [textbox](xref:DashboardTextInput)) that is used in a query (e.g., like in step 4 of the [*Using controls to create a dynamic GQI query* tutorial](xref:Tutorial_Dashboards_Controls_Query#step-4-link-the-text-input-to-the-gqi-query-to-enable-dynamic-filtering)).

### Settings

For this operator, one setting is available, i.e., *Duration*, which defines the duration of the debounce. The duration is expressed in milliseconds and should be between 1 millisecond and 1 day.

## Merge

Merges up to ten inputs into one by forwarding **the most recently updated input** as the output. Whenever an input changes, the **latest** value is emitted by the operator.

![Merging two input values](~/dataminer/images/Flow_OperatorMerge.gif)<br>
*Merging two input values in DataMiner 10.4.12*

This could for example be used to reuse a page or panel by linking it to a flow that takes the latest value of a list of different data.

## Combine

Combines up to ten inputs into one by forwarding **the most recently updated value of each input** as the output. Whenever an input changes, the **combination of all latest values** is emitted by the operator.

![Combining two input values](~/dataminer/images/Flow_OperatorCombine.gif)<br>
*Combining two input values in DataMiner 10.4.12*

You could for example use this for the following purposes:

- Showing the combination of the selection of multiple data in one single component.
- Passing the selection of multiple data to one single action in a low-code app.
