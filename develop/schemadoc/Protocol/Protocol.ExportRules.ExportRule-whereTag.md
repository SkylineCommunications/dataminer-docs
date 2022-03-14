---
uid: Protocol.ExportRules.ExportRule-whereTag
---

# whereTag attribute

Specifies, together with the whereValue attribute, a condition so the export rule will only be applied if the condition is met.

## Content Type

string

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Examples

Example:

```xml
<ExportRule table="*" whereTag="Protocol/Params/Param/Name" whereValue="My param" />
```

Example:

- Position element 1:

  ```xml
    <Position>
      <Page>Export Items</Page>
      <Row>1</Row>
     <Column>0</Column>
  </Position>
  ```

- Position element 2:

  ```xml
  <Position>
      <Page>Export Items Details</Page>
      <Row>2</Row>
      <Column>1</Column>
  </Position>
  ```

- Export rule:

  ```xml
  <ExportRule table="1000" tag="Protocol/Params/Param/Display/Positions/Position/Page" value="General" regex="Export Items"/>
  ```

- Result:
  - Position element 1:

    ```xml
    <Position>
        <Page>General</Page>
        <Row>1</Row>
        <Column>0</Column>
    </Position>
    ```

  - Position element 2:

     ```xml
    <Position>
        <Page>General Details</Page>
        <Row>2</Row>
        <Column>1</Column>
    </Position>
     ```
