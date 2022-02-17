---
uid: AutomationActionGet
---

# Get

Retrieves a parameter or memory value.

- Retrieving a parameter

    ```xml
    <Exe id="2" type="get" destvar="param1">
       <Param protocol="1">300</Param>
       <Value offset="0"></Value>
    </Exe>
    ```

  - Param: Parameter ID
  - Param@protocol: Dummy element
  - Value@offset: The offset

- Retrieving a memory value

    ```xml
    <Exe id="2" type="get" destvar="param1">
       <Type>memory</Type>
       <MemoryPos>1:1</MemoryPos>
       <Value offset="0"></Value>
    </Exe>
    ```

  - Type: "memory"
  - MemoryPos: The position of the entry to get in the memory file.
  - Value@offset: The offset.
