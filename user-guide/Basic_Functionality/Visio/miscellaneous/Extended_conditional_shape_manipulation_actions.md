---
uid: Extended_conditional_shape_manipulation_actions
---

# Extended conditional shape manipulation actions

To apply conditional shape manipulation actions to any type of linked shape, or to combine multiple conditions, a different configuration is required than for the basic conditional shape manipulation actions.

> [!NOTE]
>
> - These kinds of conditional shape manipulation actions must be configured on shapes linked to an element, service or view. However, note that from DataMiner 10.0.13 onwards, the *Show*, *Hide*, *FlipX*, *FlipY* and *Enabled* actions are supported on shapes that are not linked to an element, service or view. The same goes for the *Collapse* action, available from DataMiner 10.1.8 onwards. For the *Enabled* action, the shape does have to be clickable.
> - For more information on the more limited basic conditional shape manipulation actions, see [Basic conditional shape manipulation actions](xref:Basic_conditional_shape_manipulation_actions).
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[misc > MANIPULATION]* page.

## Configuring the shape data fields

Depending on the action or actions you want to apply, create the following shape data fields:

- **Blink**: Makes a shape blink when the condition is true.

- **Collapse**: Available from DataMiner 10.1.8/10.2.0 onwards. Hides a shape when the condition is true, without actually removing the shape.

  > [!NOTE]
  > This can be convenient as an alternative to the **ChildrenFilter** shape data, as it will keep all shapes in memory instead of removing and recreating them, allowing better performance but leading to more memory usage. It can also be convenient in a grid layout, as a collapsed shape will not take up room in a grid, unlike a shape hidden using **Hide** shape data.

- **Enabled**: Enables user interaction when the condition is true.

- **FlipX**: Makes a shape flip horizontally when the condition is true.

- **FlipY**: Makes a shape flip vertically when the condition is true.

- **Hide**: Makes a shape disappear when the condition is true.

- **Highlight**: Highlights the shape when the condition is true.

- **Show**: Makes a shape appear when the condition is true.

As the value for the above-mentioned shape data fields, you need to enter a single condition or multiple conditions combined into one. Regardless of whether a single or multiple conditions are used, each condition has to be assigned an alias.

### Single condition

```txt
Alias-"Alias"|"Target"|"What"|"Condition"
```

### Multiple conditions combined

```txt
"Logical expression"-"Alias1"|"Target"|"What"|"Condition"
                            -"Alias2"|"Target"|"What"|"Condition"
                            -"Alias3"|"Target"|"What"|"Condition"
                            -...
```

### Condition components

- **Logical expression**: The expression that combines the defined aliases using "and", "or", "(", ")" or "not". Example: \<A>or\<B>

- **Alias**: A, B, C, ...

- **Target**: The object to which the action should be applied. Use the following syntax (optionally using wildcards or placeholders):

  - For an element: *Element:[Element name or ID]*
  - For a service: *Service:[Service name or ID]*
  - For a view: *View:[View name or ID]*
  - For a connection (see [Conditional manipulation of connection shapes](#conditional-manipulation-of-connection-shapes): *Connection*
  - For an EPM object (supported from DataMiner 10.2.9/10.3.0 onwards), the following are supported:

    - *SystemType=[system type];SystemName=[system name]*
    - *SystemType=[system type]*
    - *SystemName=[system name]*

  - Depending on a value: *Value*

  The default target is *Element*, so if only a name or ID is specified, without a preceding keyword, this will be considered an element name or ID.
  
  If the target is set to *Value*, the "What" condition component has to contain the value to be evaluated. The latter can also be a placeholder referring to a session variable.

- **What**: Can be configured as follows:

  - *ALARMLEVEL*
  - *NAME:* *\[Name of the element, view or service specified in the Target\]*
  - *PARAMETER:* \[Parameter ID\]

    Alternatively, you can specify the parameter ID without the prefix, as a reference without prefix will by default be interpreted as a parameter reference.

    To use a column parameter, append the primary key (or display key) to the parameter ID, separated by either a comma or colon.

    - *[Parameter ID]:[Primary key]*
    - *[Parameter ID],[Primary key]*

  - *PROPERTY:* *\[Property name\]*
  - *Protocol* (from DataMiner 9.6.4 onwards)
  
  > [!NOTE]
  > From DataMiner 9.0.2 onwards, it is also possible to use statistics in this part of the condition. See [Using statistics in the condition](#using-statistics-in-the-condition).

- **Condition**: The condition that determines whether the shape manipulation is applied. If you want to check if the specified "What" matches with a regular expression, start the condition with "Regex=", followed by the regular expression.

  Multiple conditions can be combined within this part of the condition, using a semicolon. In that case, each condition should include an operator and a value. The complete condition component will only function correctly if all conditions within it are correctly configured.

  For an overview of the supported operators in the condition, see [Condition operators](xref:Basic_conditional_shape_manipulation_actions#condition-operators). However, note that if the target is an EPM object, only the operators =, !=, >, >=, <, and <= are supported.

### Using an asterisk in a condition

Up to DataMiner 9.5.4, when an asterisk ("\*") is used in shape data to refer to an element, view or service, the asterisk is replaced with the first element ID, view ID or service ID that is found from the parent shape upwards, but the current shape is not checked.

From DataMiner 9.5.4 onwards, however, the current shape is checked as well. This for example allows you to use asterisk characters in a *Show* condition specified in a top-level shape.

For backwards compatibility, if you want asterisk characters to be resolved from the parent shape, you can add the "StartResolvingFromParent" option. See [StartResolvingFromParent](xref:Overview_of_page_and_shape_options).

## Changing the separator character in the condition

To change the separator character in part of the condition, you must add the \[sep:XY\] option in the first position of that part of the condition. For example:

```txt
<A>or<B>or<C>-[Sep:|^]A^Highlight Element 00^Property:ServiceType^Regex=.*[Var:CheckBoxes].*-[Sep:|^]B^Highlight Element 00^Name^Regex=.*[Var:SearchQuery].*-[Sep:|^]C^Highlight Element 00^Property:Color^[Var:ColorVar]
```

However, in order to replace the – separators, the separator replacement option must be placed in the first position of the shape data value. For example:

```txt
[sep:-^]<A>^A|Element:myElement|Name|Regex=.*[var:myVar].*
```

In addition, from DataMiner 9.5.13 onwards, it is possible to use the \[sep:XY\] option in the *condition* part of the shape data. Normally, if this part contains a semicolon, it will be interpreted to consist of several conditions. This behavior can only be adapted by specifying the \[sep:XY\] option immediately before the condition. For example:

```txt
<A>-A|Element:MyElement|Parameter:1|[Sep:;$]=a;b
```

> [!TIP]
> See also: [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters)

## Using statistics in the condition

From DataMiner 9.0.2 onwards, you can use alarm statistics in the "What" part of the condition. The following table lists the available items, and indicates whether they can be used to retrieve data for a view, a service or an element.

| Statistical data      | View | Service | Element | EPM object |
| --------------------- | ---- | ------- | ------- |------------|
| #CriticalElements     | X    | X       |         |            |
| #MajorElements        | X    | X       |         |            |
| #MinorElements        | X    | X       |         |            |
| #WarningElements      | X    | X       |         |            |
| #NormalElements       | X    | X       |         |            |
| #TimeoutElements      | X    | X       |         |            |
| #NoticeElements       | X    | X       |         |            |
| #ErrorElements        | X    | X       |         |            |
| #MaskedElements       | X    | X       |         |            |
| #TotalElements        | X    | X       |         |            |
| #TotalElementsInAlarm | X    | X       |         |            |
| #CriticalServices     | X    |         |         |            |
| #MajorServices        | X    |         |         |            |
| #MinorServices        | X    |         |         |            |
| #WarningServices      | X    |         |         |            |
| #NormalServices       | X    |         |         |            |
| #TotalServices        | X    |         |         |            |
| #TotalServicesInAlarm | X    |         |         |            |
| #CriticalAlarms       | X    | X       | X       | X          |
| #MajorAlarms          | X    | X       | X       | X          |
| #MinorAlarms          | X    | X       | X       | X          |
| #WarningAlarms        | X    | X       | X       | X          |
| #NormalAlarms         | X    | X       | X       | X          |
| #TimeoutAlarms        | X    | X       | X       | X          |
| #NoticeAlarms         | X    | X       | X       | X          |
| #ErrorAlarms          | X    | X       | X       | X          |
| #MaskedAlarms         | X    | X       | X       |            |
| #TotalAlarms          | X    | X       | X       | X          |

> [!NOTE]
>
> - #NormalAlarms can only be used if, in the *MaintenanceSettings.xml* file, the *\<AutoClear>* tag is set to "false".
> - On a DMA with a Ticketing module, you can also use the placeholder *#Tickets* to create a condition based on the number of tickets. This is possible for views, services and elements. From DataMiner 9.5.3 onwards, you can also add a domain name to the placeholder to only take the tickets from a particular domain into account. For example *#Tickets:Internal*.

## Specifying a default return value

By default, if the condition cannot be evaluated (e.g. because the element or parameter does not exist), it always returns false. However, from DataMiner 9.5.5 onwards, you can specify that the condition must return "true" when it cannot be evaluated.

To do so, add "DefaultReturnValue=True" to the condition.

For example, with the configuration below, if the A condition cannot be evaluated because the element does not exist, "true" will be returned, and the shape will be shown.

| Shape data field | Value                                                                         |
| ---------------- | ----------------------------------------------------------------------------- |
| Show             | \<A>-A\|Element:NonExistingElement\|Parameter:1\|\>0\|DefaultReturnValue=True |

> [!NOTE]
> The DefaultReturnValue option is placed in the same position as a possible calculation option, e.g. *Min*, *Max*, *Concat* or *Avg*. To combine these options, use a semicolon (";"). See also: [Conditional manipulation of connection shapes](#conditional-manipulation-of-connection-shapes).

## Conditional manipulation of connection shapes

When conditional shape manipulation actions are defined on connection property shapes, there are additional possibilities for the "What" field of the condition.

> [!NOTE]
> Connection property shapes are shapes that have an **Options** shape data field with the value "ConnectionProperty:PropertyName". See [Displaying connection properties](xref:Options_for_displaying_DCF_connections#displaying-connection-properties).

The following conditions can be defined:

- *Does a connection property have a specific string value?*

  This condition will be true if a connection property has a specific string value. If a line represents multiple connections, the different values of that same property will be concatenated. Example:

  | Shape data field | Value                                  |
  | ---------------- | -------------------------------------- |
  | Options          | ConnectionProperty:State               |
  | Show             | A\|Connection\|Property:State\|=Active |

- *Is a connection highlighted?*

  This condition will be true if the connection is either highlighted or not. Example:

  | Shape data field | Value                                |
  | ---------------- | ------------------------------------ |
  | Options          | ConnectionProperty:Bandwidth         |
  | FlipX            | A\|Connection\|IsHighlighted\|=false |

- *Is the mouse pointer on a connection?*

  This condition will be true if the mouse pointer is either on the connection or not. Example:

  | Shape data field | Value                             |
  | ---------------- | --------------------------------- |
  | Options          | ConnectionProperty:Bandwidth      |
  | FlipY            | A\|Connection\|IsMouseOver\|=true |

- *Does a connection property have a specific numeric value?*

  This condition will be true if a connection property is greater or smaller than a specific value. For lines that represent multiple connections, you can specify the calculation that has to be made with the different values of that same property. The default calculation is *Sum*, but you can also specify *Min*, *Max*, *Concat* and *Avg*. Note that when you use *Concat*, the result will no longer be a numeric value but a string value (e.g. \<value1>, \<value2>). Example:

  | Shape data field | Value                                    |
  | ---------------- | ---------------------------------------- |
  | Options          | ConnectionProperty:Speed                 |
  | Highlight        | A\|Connection\|Property:Speed\|\>=5\|Max |

## Examples

Single conditions:

```txt
<A>-A|57/2|1|<0
<B>-B|57/3|510,1|<0
<C>-C|number|PROPERTY:Class|=A
<D>-D|VIEW:2|PROPERTY:Class|=A
<E>-E|Service:serv|PROPERTY:Class|=A
<F>-F|Element:number|ALARMLEVEL|>=MINOR
<G>-G|Element:MyElement|Protocol|=MyProtocolName
<H>-H|Element:MyElement|Parameter:1|<0
<I>-I|Element:MyElement|Parameter:510,1|<0
<J>-J|VIEW:2|ALARMLEVEL|>=MINOR
<K>-K|Service:serv|ALARMLEVEL|>=MINOR
```

Multiple conditions combined:

```txt
<A>or<B>or<C>or<D>or<E>or<F>or<G>or<H>-A|57/2|1|<0-B|57/3|510,1|<0
-C|number|PROPERTY:Class|=A-D|VIEW:2|PROPERTY:Class|=A
-E|Service:serv|PROPERTY:Class|=A-F|Element:number|ALARMLEVEL|>=MINORG|
VIEW:2|ALARMLEVEL|>=MINOR-H|Service:serv|ALARMLEVEL|>=MINOR
```

```txt
<A>and<B>and<C>and<D>and<E>and<F>and<G>and<H>-A|57/2|1|<0-
B|57/3|510,1|<0-C|number|PROPERTY:Class|=A-D|VIEW:2|PROPERTY:Class|=AE|
Service:serv|PROPERTY:Class|=A-F|Element:number|ALARMLEVEL|>=MINORG|
VIEW:2|ALARMLEVEL|>=MINOR-H|Service:serv|ALARMLEVEL|>=MINOR
```

Multiple conditions combined with the "condition" part of the shape data:

```txt
<A>-A|Element:MyElement|Parameter:1|!=a;!=b
```

Conditions using alarm statistics:

```txt
<A>-A|Element:myElement|#CriticalAlarms|>=10
<A>-A|View:myView|#CriticalElements|>0
<A>and<B>-A|Service:myService|#TotalAlarms|=0-B|Element:myElement|#TimeoutAlarms|=0
<A>or<B>-A|View:myView|#MinorServices|>0-B|Element:myElement|Property:Enabled|=true
```

Conditions using the target "Value":

```txt
<A>-A|Value|10|<=20
<A>-A|Value|5|>2
<A>-A|Value|[var:MyVar01]|>=[var:MyVar02]
```

Condition with EPM target (supported from DataMiner 10.2.9/10.3.0 onwards):

```txt
<A>-A|SystemType= Cable;SystemName=SF Cable1|#TotalAlarms|>0
```
