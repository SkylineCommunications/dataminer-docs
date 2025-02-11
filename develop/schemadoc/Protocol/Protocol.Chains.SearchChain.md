---
uid: Protocol.Chains.SearchChain
---

# SearchChain element

<!-- RN 15490, RN 15595, RN 1614 -->

Defines a search chain in a CPE environment.

## Parent

[Chains](xref:Protocol.Chains)

## Attributes

| Name                                          | Type   | Required | Description                             |
|-----------------------------------------------|--------|----------|-----------------------------------------|
| [name](xref:Protocol.Chains.SearchChain-name) | string | Yes      | Specifies the name of the search chain. |

## Children

| Name                                                            | Occurrences | Description |
|-----------------------------------------------------------------|-------------|-------------|
| ***All***                                                       |             |             |
| &nbsp;&nbsp;[Display](xref:Protocol.Chains.SearchChain.Display) | [0, 1]      |             |
| &nbsp;&nbsp;[Tabs](xref:Protocol.Chains.SearchChain.Tabs)       | [0, 1]      |             |

## Remarks

To use a search chain field, users should enter something in the field and then click the *Search* button, after which all rows matching all fields will be returned.

It is possible to define multiple result tables and fields for these result tables. Fields for different tables that have the same name will be displayed as a single field. The field will result in a filter on the result table on the PID as defined for this field on this table in the protocol.

For each search field, it is also possible to define suggestions.

> [!NOTE]
> If multiple fields with the same field name are used within a particular chain (in multiple tabs, for example), the suggestions for those identical fields only have to be configured once.

## Examples

```xml
<Chains filters="vertical">
   <SearchChain name="Search">
      <Tabs>
         <Tab tablePid="1000">
            <Fields>
               <Field columnPid="1002" name="Name">
                  <Suggestions>
                     <State>enabled</State>
                     <MaxResult>10</MaxResult>
                     <MinChars>3</MinChars>
                  </Suggestions>
               </Field>
            </Fields>
         </Tab>
         <Tab tablePid="1500">
            <Fields>
               <Field columnPid="1502" name="Name"/>
               <Field columnPid="1504" name="Room Code"/>
            </Fields>
         </Tab>
      <Tab tablePid="1600">
      <Fields>
         <Field columnPid="1602" name="Name"/>
      </Fields>
      </Tab>
         <Tab tablePid="1700">
            <Fields>
               <Field columnPid="1702" name="Name"/>
               <Field columnPid="1708" name="MAC Address">
                  <Substitutions>
                     <Substitution>
                        <Regex>
                           <Input>([A-Fa-f0-9]{2})([:-]?)(?=[A-Fa-f0-9])</Input>
                           <Output>$1:</Output>
                        </Regex>
                     </Substitution>
                  </Substitutions>
                  <Validation>
                     <ErrorMessage>Not a valid MAC address</ErrorMessage>
                     <Regex>([A-Fa-f0-9]{2}[:-]?){5}[A-Fa-f0-9]{2}</Regex>
                  </Validation>
               </Field>
            </Fields>
         </Tab>
      </Tabs>
   </SearchChain>
   ...
</Chains>
```
