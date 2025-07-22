---
uid: Creating_a_custom_report_template_in_an_ASP_editor
---

# Creating a custom report template in an ASP editor

To create a custom report template from scratch, do the following:

1. In your ASP editor, enter the following base structure:

   ```xml
   <%@ Language="JScript" %>
   <!-- #include file="Templates.inc.asp" -->
   <%
   // generate web page here
   %>
   ```

1. Under the *// generate webpage here* line, start writing your ASP code.

   > [!TIP]
   > See also:
   > [Passing parameters](#passing-parameters)<br> [Including external files in a report template](xref:Including_external_files_in_a_report_template)

1. Save the template.

> [!TIP]
> See also:
> [Importing a custom report template made in a third-party editor](xref:Importing_a_custom_report_template_made_in_a_third-party_editor#importing-a-custom-report-template-made-in-a-third-party-editor)

## Passing parameters

Depending on the method that is called, parameters can be passed in a number of different ways.

### Passing regular parameters

Regular parameters can be passed like this:

```txt
template.doSomething("some string", 123)
```

### Passing name/value pairs

Name/value pairs have to be passed as objects of type “AssocArray”:

```txt
template.doSomething(
    new AssocArray(
        'start', 0,
        'element', 'ALL_ELEMENTS',
        'state', stateType,
        'includedElementTypes', includedElementTypes
    )
);
```

### Passing parameters using associative arrays

A clean way of passing parameters is by using JavaScript associative arrays:

```txt
template.doSomething(
    {
        start: 0,
        element: 'ALL_ELEMENTS',
        state: stateType,
        includedElementTypes: includedElementTypes
    }
);
```

## Example of a custom report template

```xml
<%@ Language="JScript" %>
<!-- #include file="Templates.inc.asp" -->
<%
  Response.Write('<table>');
  Response.Write('<tr>' +
  '<th>Element Name</th>' +
  '<th>Description</th>' +
  '<th>ID</th>' +
  '<th>Type</th>' +
  '<th>Protocol</th>' +
  '<th>Alarm Template</th>' +
  '<th>Amount of open alarms</th>' +
  '<th>Polling Type</th>' +
  '<th>Polling IP Address</th>' +
  '<th>Polling IP Port</th>' +
  '</tr>');
  for (var iElement = 0; iElement < template.getAmountOfElements(); iElement++)
  {
    oElement = template.getElementInfo(iElement);
    Response.Write('<tr>');
    Response.Write('<td>' + oElement.getFullName() + '</td>');
    Response.Write('<td>' + oElement.getDescription() + '</td>');
    Response.Write('<td>' + oElement.getDMAID() + '/' + oElement.getID() + '</td>');
    Response.Write('<td>' + oElement.getType() + '</td>');
    Response.Write('<td>' + oElement.getProtocolId() + '</td>');
    Response.Write('<td>' + oElement.getAlarmTemplate() + '</td>');
    Response.Write('<td>' + oElement.getAmountOpenAlarms() + '</td>');
    Response.Write('<td>' + oElement.getPollingType() + '</td>');
    Response.Write('<td>' + oElement.getPollingIP() + '</td>');
    Response.Write('<td>' + oElement.getPollingPort() + '</td>');
    Response.Write('</tr>');
  }
  Response.Write('</table>');
%>
```
