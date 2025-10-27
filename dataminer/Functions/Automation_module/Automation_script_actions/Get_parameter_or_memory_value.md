---
uid: Get_parameter_or_memory_value
---

# Get parameter or memory value

For this script action, you must first indicate what is to be retrieved: a parameter or a memory value. The further configuration options depend on this first choice.

## For a parameter get

1. In the first underlined field, keep *Parameter* selected.

1. Click the next field to either add an existing dummy element or create a new dummy element.

   > [!NOTE]
   > For more information on creating dummy elements, see [Creating a dummy](xref:Script_variables#creating-a-dummy).

1. Choose the parameter to be retrieved. For a dynamic table parameter, also specify the index.

1. Specify the destination variable.

> [!NOTE]
> This functionality can also be used to get the value of a matrix crosspoint. To do so, specify the parameter as “matrix \[matrix size\]” and select the input and output.

## For a memory value get

1. In the first underlined field, select *Memory value*.

1. Click the next field and either add an existing memory file or create a new memory file.

   > [!NOTE]
   > For more information on creating memory files, see [Creating a memory file](xref:Script_variables#creating-a-memory-file).

1. In the next underlined field, specify the number of the value that is to be retrieved.

1. Click the final underlined field and either specify an existing script parameter, or create a new one.

   > [!NOTE]
   > For more information on creating script parameters, see [Creating a parameter](xref:Script_variables#creating-a-parameter).
