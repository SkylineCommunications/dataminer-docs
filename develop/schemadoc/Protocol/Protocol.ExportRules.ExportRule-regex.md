---
uid: Protocol.ExportRules.ExportRule-regex
---

# regex attribute

Specifies a regular expression to match particular values.

## Content Type

string

## Parent

[ExportRule](xref:Protocol.ExportRules.ExportRule)

## Examples

In the example below, we search for tags containing "MCR":

```xml
<ExportRule regex="MCR" />
```

For a full match, use the start-of-string anchor "^" and the end-of-string anchor "$":

```xml
<ExportRule table="1000" tag="Protocol/Params/Param/Display/Positions/Position/Page" value="General" regex="^Export Items$"/>
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
