---
uid: Set_parameter_memory_position_or_variable
---

# Set parameter, memory position or variable

For this script action, you must first indicate what is to be set: parameter, memory position or variable. The further configuration options depend on this first choice.

## For a parameter set

1. In the first underlined field, keep *Parameter* selected.

1. Next to *Parameter*, click the underlined field to either add an existing dummy element or create a new dummy element.

   > [!NOTE]
   > For more information on creating dummy elements, see [Creating a dummy](xref:Script_variables#creating-a-dummy).

1. Click the next underlined field to select the parameter that is to be set.

1. For the next underlined field, either:

   - Keep *Value* selected, and specify the value, or

   - Click the *Value* field to select *Variable* instead, and select the variable.

1. Optionally, if the parameter is a number, click the field next to *offset* and specify an offset value.

> [!NOTE]
> This functionality can also be used to set a matrix crosspoint. In this case, the parameter is “matrix \[matrix size\]”, and you must specify a fixed value of the format *input x -> output y (connected)*.

## For a memory position set

1. Click the default *Parameter* field to select *Memory position* instead.

1. Click the next field and either add an existing memory file or create a new memory file.

   > [!NOTE]
   > For more information on creating memory files, see [Creating a memory file](xref:Script_variables#creating-a-memory-file).

1. In the next field, specify the position of the memory file that should be set.

1. For the next underlined field, either:

   - Keep *Value* selected, and specify the value, or

   - Click the *Value* field to select *Variable* instead, and select the variable.

1. Optionally, click the field next to *offset* and specify an offset value.

## For a variable set

1. Click the default *Parameter* field to select *Variable* instead.

1. In the next field, either specify an existing script parameter, or create a new one.

    > [!NOTE]
    > For more information on creating script parameters, see [Creating a parameter](xref:Script_variables#creating-a-parameter).

1. For the next underlined field, either:

    - Keep *Value* selected, and specify the value, or

    - Click the *Value* field to select *Variable* instead, and select the variable.

1. If necessary, click the *offset* field to specify an offset value. From DataMiner 10.1.0 \[CU13], 10.2.0 \[CU1] and 10.2.4 onwards, by default, *without value offset* is displayed. Click that field to switch it to *with value offset* and then specify the value.
