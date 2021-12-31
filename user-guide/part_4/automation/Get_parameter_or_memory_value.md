## Get parameter or memory value

For this script action, you must first indicate what is to be retrieved: a parameter or a memory value. The further configuration options depend on this first choice.

#### For a parameter get

1. In the first underlined field, keep *Parameter* selected.

2. Click the next field to either add an existing dummy element or create a new dummy element.

    > [!NOTE]
    > For more information on creating dummy elements, see [Creating a dummy](Script_variables.md#creating-a-dummy).

3. Choose the parameter to be retrieved. For a dynamic table parameter, also specify the index.

4. Specify the destination variable.

> [!NOTE]
> This functionality can also be used to get the value of a matrix crosspoint. To do so, specify the parameter as “matrix \[matrix size\]” and select the input and output.

#### For a memory value get

1. In the first underlined field, select *Memory value*.

2. Click the next field and either add an existing memory file or create a new memory file.

    > [!NOTE]
    > For more information on creating memory files, see [Creating a memory file](Script_variables.md#creating-a-memory-file).

3. In the next underlined field, specify the number of the value that is to be retrieved.

4. Click the final underlined field and either specify an existing script parameter, or create a new one.

    > [!NOTE]
    > For more information on creating script parameters, see [Creating a parameter](Script_variables.md#creating-a-parameter).
    >
