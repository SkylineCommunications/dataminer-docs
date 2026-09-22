---
metadata_version: 1
uid: AutomationActionAssignDummy
description: "Describe the DataMiner Automation development topic Assign dummy, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# Assign dummy

Assign an automation script's dummy to a specific element by using a variable or a value.

- For a pre-determined element, select Value to select a specific element, and enter the element name or ID.

    ```xml
    <Exe id="2" type="assigndummy">
       <Param protocol="1"></Param>
       <Value>100/200</Value>
    </Exe>
    ```

- For an element determined by a script variable

    ```xml
    <Exe id="3" type="assigndummy">
       <Param protocol="1"></Param>
       <Value ref="param1"></Value>
    </Exe>
    ```

The value of the variable or the directly specified value should contain either the dmaID and elementID formatted as "dmaID/elementID" or the element name.

Required items:

- For pre-determined element: Value
- For script variable: Value@ref
