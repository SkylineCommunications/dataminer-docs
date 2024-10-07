---
uid: Using_flows
---

# Flows

**Flows** allow you to modify the behavior of one or more data objects <!--(or variables) TODO: add once variables are available--> by applying a series of operators. Similar to GQI (Graphical Query Interface), operators are chained together and applied to the data object step by step until a final value is reached, which is then passed to all consumers.

## Data Sources

Flows always start from at least one existing data source. The following data sources can be used to initiate a flow:

- **Feeds**: Live or static data inputs, such as text inputs or other widgets providing data.
- **Another Flow**: Flows can be chained, using the output of one flow as the input for another.
<!--(Variables) TODO: add once variables are available-->

## Operators

Operators can be used to manipulate these data sources in the way you like. A list of all operators can be found [here](xref:Flow_operators).