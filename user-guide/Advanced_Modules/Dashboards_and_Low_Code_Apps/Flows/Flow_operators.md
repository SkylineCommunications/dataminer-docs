---
uid: Flow_operators
---

# Operators

An operator is a step within a flow that starts from at least one input and transforms it to a single output. The following operators are available:

## Debounce

Delays the emission of a value until a specified time has passed without receiving another value.

![Debouncing an input value](~/develop/images/Flow_OperatorDebounce.gif)<br>
*Debouncing an input value*

### Settings
- Duration: Defines the duration of the debounce. 
 
   > [!NOTE]
   > The duration is expressed in milliseconds and should be between 1 millisecond and 1 day.

### Examples

- Applying a buffer to a rapidly changing feed (e.g. a [textbox](xref:DashboardTextInputFeed)) that is [used in a query](xref:Tutorial_Dashboards_Controls_And_Feeds_Query#step-4-replace-the-static-filter-value-with-a-feed).

## Merge

Merges multiple inputs into one by forwarding *the most recently updated input* as the output. Whenever any input changes, the *latest* value is emitted by the operator. 

![Merging two input values](~/develop/images/Flow_OperatorMerge.gif)<br>
*Merging two input values*

   > [!NOTE]
   > There is a maximum of 10 inputs for one single operator.

### Examples

- Reusing a page or panel by linking it to a flow that takes the latest value of a list of different feeds.

## Combine

Combines multiple inputs into one by forwarding *the most recently updated value of each input* as the output. Whenever any input changes, the *combination of all latest values* is emitted by the operator. 

![Combining two input values](~/develop/images/Flow_OperatorCombine.gif)<br>
*Combining two input values*

   > [!NOTE]
   > There is a maximum of 10 inputs for one single operator.

### Examples

- Showing the combination of multiple feeds their selection into one single component.
- Passing the selection of multiple feeds to one single action in LCA.