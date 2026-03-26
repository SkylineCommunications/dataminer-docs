---
uid: Protocol.Params.Param.Dashboard.DashboardOptions.DashboardOption-name
---

# name attribute

Specifies the name of the option.

## Content Type

|Item|Facet value|Description|
|--- |--- |--- |
|***string restriction***|||
|&nbsp;&nbsp;Enumeration|activeContainer||
|&nbsp;&nbsp;Enumeration|advancedLayout||
|&nbsp;&nbsp;Enumeration|container||
|&nbsp;&nbsp;Enumeration|css||
|&nbsp;&nbsp;Enumeration|height||
|&nbsp;&nbsp;Enumeration|panelAdvancedLayout||
|&nbsp;&nbsp;Enumeration|panelButtonName||
|&nbsp;&nbsp;Enumeration|panelButtonOperation||
|&nbsp;&nbsp;Enumeration|panelButtonPossibleOperations||
|&nbsp;&nbsp;Enumeration|panelButtonType||
|&nbsp;&nbsp;Enumeration|panelSelection||
|&nbsp;&nbsp;Enumeration|width||
|&nbsp;&nbsp;Enumeration|xpos||
|&nbsp;&nbsp;Enumeration|ypos||

## Parent

[DashboardOption](xref:Protocol.Params.Param.Dashboard.DashboardOptions.DashboardOption)


## Reamrks

Possible values:

- **activeContainer**: Determines which container is to be displayed by the dashboard. For this option, type should be set to pid and the tag should contain the ID of the parameter that allows the user to select the active container.
- **advancedLayout**: Allows the user to specify the layout of the button using a JSON string. For example:
  - For a button with custom HTML:

  ```json
  {"buttonLayout":{"alignHorizontal":"Left","alignVertical":"Center","html":"<div class='buttoncontainer'><div class='button'>Button</div></div>"}, "version":"1.0.0.0"}
  ```

  - For a rotate button:

  ```json
  {"rotateButtonLayout":{"sliderOrientation":"Horizontal"},"version":"1.0.0.0"}
   ```

  > [!NOTE]
  > Using the HTML class toggled, you can determine what the button will look like when it is interacted with. Using the HTML class locked, you can determine what the button will look like when it is locked.

- **container**: Determines the container the button is located in.
- **css**: Determines the CSS to apply to HTML content of buttons. For this option, type should be set to pid and the tag should contain the PID of the parameter that contains the CSS.

  > [!NOTE]
  > To apply a different CSS to a specific button, you can specify this in line in the advancedLayout JSON.

- **height**: Determines the height of the button (in percent).
- **panelAdvancedLayout**: Allows the user to specify the general layout of the panel using a JSON string. For this option, type should be set to pid and the tag should contain the PID of the parameter that contains the JSON string.
- **panelButtonName**: Determines the name of the button.
- **panelButtonOperation**: Displays the different buttons, which are the same for all rows. The next option, panelButtonPossibleOperations, will determine which of these buttons are used.
- **panelButtonPossibleOperations**: Allows the user to specify which operations are possible with the button. For rotate buttons, 4 types of increments are possible. For example:

  ```
  click, largedecrease;smalldecrease;smallincrease;largeincrease
  ```

- **panelButtonType**: Determines the type of button. The user will be able to select one of the following three types:
  - Simple
  - Advanced - HTML. The advancedLayout option should be used to further configure a button of this type.
  - Rotate
- **panelSelection**: Specifies the different selected panels. The contents of the referred parameter should be a semicolon-separated list of DMAID/ElementID/ParameterID (e.g., "346/532084/100;346/114/157").
- **width**: Determines the width of the button (in percent).
- **xpos**: Determines the position of the button on the X-axis (in percent).
- **ypos**: Determines the position of the button on the Y-axis (in percent).
