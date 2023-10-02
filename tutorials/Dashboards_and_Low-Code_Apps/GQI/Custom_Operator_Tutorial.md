---
uid: Custom_Operator_Tutorial
---

# Optimizing your custom operator

In this tutorial, you will learn how to:

- implement optimizations for your custom operator.

- avoid common pitfalls when optimizing custom operators.

You will use a data source that contains people with their age, income, and expenses.

| Name (string) | Age (int) | Income (int) | Expenses (int) |
|--|--|--|--|
| Luiz Nevaeh | 51 | $200,000 | $100,000 |
| Ariah Landon | 82 | $500,000 | $800,000 |
| Kenneth Brodie | 69 | $300,000 | $400,000 |
| ... | ... | ... | ... |

> [!NOTE]
> These are only the first three rows of the actual data source that contains billions more entries.

The custom operator you create will have two functions:

- Creating a new column called "Balance" that contains the difference between the *Income* and *Expenses* values.

- Obfuscating a person's real name by changing the original entries in the *Name* column to initials.

The result will look like this:

| Name | Age | Income   | Expenses | Balance   |
| ---- | --- | -------- | -------- | --------- |
| L.N. | 51  | $200,000 | $100,000 | $100,000  |
| A.L. | 82  | $600,000 | $900,000 | -$300,000 |
| K.B. | 69  | $400,000 | $300,000 | $100,000  |

> [!NOTE]
> This tutorial uses DataMiner version 10.3.2.

> [!TIP]
> See also: [Configuring a custom operator for a query](xref:GQI_Custom_Operator)

## Prerequisites

- DataMiner version 10.2.7/10.3.0 or higher.

- Depending on your DataMiner version, you may need to enable the [*GenericInterface* soft-launch option](xref:Overview_of_Soft_Launch_Options#genericinterface).

  > [!NOTE]
  > Future DataMiner versions may already include this feature. To check the release version of a soft-launch option, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

- A [minus operator](xref:Creating_Minus_Operator)

## Title of the first main step

1. First step

1. Second step

   Result of a step, e.g. "This will open a wizard."<!--  Make sure to use the correct indentation. If you don't use enough spaces, you'll interrupt the list and it will start numbering from 1 again. -->

1. ...

<!-- For information on how to add tables, code blocks, and so on, refer to <https://docs.dataminer.services/CONTRIBUTING.html#markdown-syntax>. -->

## Title of the next main step

1. First step

1. Second step

1. ...

<!-- Add as many subtitles as needed to describe the main steps. -->

## Next steps

<!-- Optionally add this title, with a link to a tutorial that logically follows this one. If there is no such tutorial, leave this out. -->