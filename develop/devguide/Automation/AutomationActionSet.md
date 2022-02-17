---
uid: AutomationActionSet
---

# Set

Sets a parameter, memory position or script variable.

- Setting a parameter to a fixed value:

    ```xml
    <Exe id="2" type="set">
       <Param protocol="1">65001</Param>
       <Value offset="0">1</Value>
    </Exe>
    ```

- Setting a parameter to the value of a script variable:

    ```xml
    <Exe id="2" type="set">
       <Param protocol="1">65001</Param>
       <Value ref="param1" offset="0"></Value>
    </Exe>
    ```

- Setting a memory position to a fixed value.

    ```xml
    <Exe id="2" type="set">
       <Type>memory</Type>
       <MemoryPos>1:0</MemoryPos>
       <Value offset="0">10</Value>
    </Exe>
    ```

- Setting a memory position to the value of a script variable.

    ```xml
    <Exe id="2" type="set">
       <Type>memory</Type>
       <MemoryPos>1:0</MemoryPos>
       <Value ref="param1" offset="1"></Value>
    </Exe>
    ```

- Setting a script variable to a fixed value.

    ```xml
    <Exe id="2" type="assign" destvar="param1">
       <Value offset="0">10</Value>
    </Exe>
    ```

- Setting a script variable to the value of another script variable.

    ```xml
    <Exe id="2" type="assign" destvar="param1">
       <Value ref="param2" offset="0"></Value>
    </Exe>
    ```
