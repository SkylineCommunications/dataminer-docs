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

- Two parameters:

  ```xml
  <Param id="1">
      <Name>My param</Name>
      <Positions>
          <Position>
              <Page>General</Page>
              <Row>0</Row>
             <Column>0</Column>
          </Position>
      </Positions>
  </Param>
  <Param id="2">
      <Name>Other param</Name>
      <Positions>
          <Position>
              <Page>General</Page>
              <Row>1</Row>
              <Column>0</Column>
          </Position>
      </Positions>
  </Param>
  ```

- Export rule:

  ```xml
  <ExportRule table="*" tag="Protocol/Params/Param/Display/Positions/Position/Row" value="2" whereTag="Protocol/Params/Param/Name" whereValue="My param" />
  ```

- Result:

  ```xml
  <Param id="1">
      <Name>My param</Name>
      <Positions>
          <Position>
              <Page>General</Page>
              <Row>2</Row>
              <Column>0</Column>
          </Position>
      </Positions>
  </Param>
  <Param id="2">
      <Name>Other param</Name>
      <Positions>
          <Position>
              <Page>General</Page>
              <Row>1</Row>
              <Column>0</Column>
          </Position>
      </Positions>
  </Param>
  ```
