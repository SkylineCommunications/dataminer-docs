---
uid: Overview_of_page_and_shape_options
---

# Overview of page and shape options

Using a shape data field of type **Options**, you can configure a number of page and shape options.

- Used on page level, it allows you to configure specific page settings.

- Used on shape level, it allows you to configure specific shape settings.

- If you specify several options, separate them by means of pipe characters (“\|”).

- The different available options are detailed in the sections below.

> [!NOTE]
> For most shape data, it is possible to specify a different separator using the \[sep:XY\] option. See [About using separator characters](xref:Linking_a_shape_to_a_SET_command#about-using-separator-characters).

## ActivePathHighlighting

Page-level option

Used in order to highlight DCF connectivity chains configured in a *Connectivity.xml* file.

See [Highlighting connections from a Connectivity.xml chain](xref:Options_for_highlighting_DCF_connections#highlighting-connections-from-a-connectivityxml-chain).

## Alarmtimelines

Shape-level option.

Used in order to embed an alarm timeline component.

See [Embedding an alarm timeline component](xref:Embedding_an_alarm_timeline_component).

## Alarmtimelines\|EmptyText=

Shape-level option.

Used with an alarm timeline component in order to display custom text when no timelines are displayed. See [Embedding an alarm timeline component](xref:Embedding_an_alarm_timeline_component).

## Alarmtimelines\|AllowEmptyDynamicValues

Shape-level option.

Used with an alarm timeline component in order to display the component even when some timeline bands have no data.

See [Embedding an alarm timeline component](xref:Embedding_an_alarm_timeline_component).

## AllowCentralConnectivity

Shape-level option.

Used to redirect connections to non-existing interfaces of a parent shape to the center of this parent shape.

See [Automatically linking interfaces to subshapes](xref:Automatically_displaying_external_and_internal_connections#automatically-linking-interfaces-to-subshapes).

## AllowControlDisable

Shape-level option.

Used to completely disable a parameter control shape.

 See [Dynamically disabling a parameter control](xref:Turning_a_shape_into_a_parameter_control#dynamically-disabling-a-parameter-control).

## AllowDynamicShapeType=ParameterControl

Shape-level option.

Used to allow dynamic shape behavior of parameter control shapes from DataMiner 9.0.0 CU5 onwards.

See [Allowing dynamic shape behavior](xref:Turning_a_shape_into_a_parameter_control#allowing-dynamic-shape-behavior).

## AllowInheritance=False

Shape-level option.

Available from DataMiner 10.0.11 onwards. By default, child shapes of an *Element* or *View* shape automatically inherit the shape data of the parent shape. In cases where you want to e.g. link a child shape to another service or element, you can use this option to disable this automatic inheritance.

> [!NOTE]
>
> - This renders the option *NoCopyElementProperty* obsolete, since this option does the same thing for *Element* shapes only.
> - From DataMiner 10.0.0 \[CU14\]/10.1.0 \[CU3\]/10.1.6 onwards, this option can also be used for element shapes that are a child of another element shape, to ensure that these do not inherit the service context of the parent if they have no service context of their own. This inheritance does not occur prior to DataMiner 10.0.0 \[CU13\]/10.1.0 \[CU2\]/10.1.5.

## ArrangeMode

Page-level option.

When rearranging dynamically positioned shapes in a Visio drawing using drag and drop, by default you have to click the *Apply* button to save the changes. However, if you add the page-level “*ArrangeMode=Immediate*” option, the new position of a shape is saved as soon as you drop that shape onto the page.

See [Re-arranging dynamically positioned shapes](xref:Re-arranging_dynamically_positioned_shapes#re-arranging-dynamically-positioned-shapes).

## AutoClosePopup

Shape-level option.

If, in a shape, you set a shape data field of type **VdxPage** to “*PageName\|Popup*” to have a page of a Visio drawing displayed in a pop-up window, then you can use this option to have that pop-up window closed automatically when a shape is clicked inside that pop-up.

See [Making a shape display a particular page of the current Visio drawing](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing).

## BorderVisibility

Shape-level option.

Used in order to display a border around embedded webpages.

See [BorderVisibility](xref:Linking_a_shape_to_a_webpage#bordervisibility).

## CardVariable

Page- and shape-level option.

Used to limit the scope of a session variable to the current card.

See [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable).

## ClipToBound

Page-level option.

Available from DataMiner 9.5.5 onwards. Use this option to keep the page canvas from expanding automatically when the *NoAutoScale* option has been added.

See [NoAutoScale](xref:Overview_of_page_and_shape_options).

## ClosePage

Shape-level option.

Available from DataMiner 9.6.1 onwards. Use this option to automatically close the page containing the shape after the shape’s main action has been executed.

See [Optional configuration](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing#optional-configuration).

## CollapseEmptyRowsAndColumns=True

Shape-level option.

Available from DataMiner 10.0.0/10.0.2 onwards. Use this option to avoid gaps in the visualization of a service instance.

See [Generating the connectivity chain for an SRM service instance](xref:Generating_the_connectivity_chain_for_an_SRM_service_instance).

## ConnectionLinesOnBackground

Page-level option.

Used to draw all connection lines in the background.

See [Placing connection lines in the background or in the foreground](xref:Options_for_displaying_DCF_connections#placing-connection-lines-in-the-background-or-in-the-foreground).

## ConnectionLinesOnForeground

Page-level option.

Used to draw all connection lines in the foreground.

See [Placing connection lines in the background or in the foreground](xref:Options_for_displaying_DCF_connections#placing-connection-lines-in-the-background-or-in-the-foreground).

## ConnectionProperty:*\[PropertyName\]*

Shape-level option.

Used in order to display connection properties, or to allow conditional shape manipulation based on connection properties.

See [Displaying connection properties](xref:Options_for_displaying_DCF_connections#displaying-connection-properties) and [Conditional manipulation of connection shapes](xref:Extended_conditional_shape_manipulation_actions#conditional-manipulation-of-connection-shapes).

## ConnectionPropertyHighlighting

Page-level option.

Deprecated. Use “ActivePathHighlighting” instead.

See [Highlighting connections from a Connectivity.xml chain](xref:Options_for_highlighting_DCF_connections#highlighting-connections-from-a-connectivityxml-chain).

## ConnectivityLines

Page-level option.

Used in order to visualize connectivity using manually drawn lines.

See [Using existing lines as connectivity lines](xref:Options_for_displaying_DCF_connections#using-existing-lines-as-connectivity-lines).

## Control=Button

Shape-level option.

Use this option to turn a shape into a button that looks and behaves like a default DataMiner Cube button, supporting features like hover, etc.

## Control=TextBlock

Shape-level option.

Use this option to turn a shape into a Cube-style text block, inheriting the default Cube font and font size.

See [Creating a text block control](xref:Creating_a_text_block_control).

## DefaultAlarmLevel

Shape-level option.

Use this option to set a custom default alarm level for a shape linked to an alarm filter.

See [Linking a shape to an alarm filter](xref:Linking_a_shape_to_an_alarm_filter).

## DisableConnectivity

Shape-level option.

Used in order to hide the connections of a particular element.

See [Hiding all connections of an element](xref:Options_for_displaying_DCF_connections#hiding-all-connections-of-an-element).

## DisableParameterSubscription

Shape-level option.

Available from DataMiner 9.5.2 onwards. Used when retrieving the value of a table parameter using a subscription filter, in order to avoid situations where this value is incorrectly resolved as a parameter ID to subscribe on.

See [Retrieving and showing the value of a table parameter using a subscription filter](xref:Linking_a_shape_to_an_element_parameter#retrieving-and-showing-the-value-of-a-table-parameter-using-a-subscription-filter).

## DisableZoom

Page-level option.

Use this option if you do not want users to be able to zoom in or out.

> [!NOTE]
> From DataMiner 9.0 onwards, zooming is disabled by default on any Visual Overview pages that contain an embedded web browser control. However, it can be enabled again with the EnableZoom option. See [EnableZoom](xref:Linking_a_shape_to_a_webpage#enablezoom).

## DisposeWebBrowserWhenNotSelectedPage=\[true/false\]

Shape-level option.

By default, DataMiner Cube disposes of embedded web browser controls when you change pages in a Visio drawing. If you want to override this default behavior, add a shape data field of type **Options** to the shape containing the web browser control, and set its value to “*DisposeWebBrowserWhenNotSelectedPage=false*”. As a result, the web browser control will only be disposed of when you close the card.

See [DisposeWebBrowserWhenNotSelectedPage](xref:Linking_a_shape_to_a_webpage#disposewebbrowserwhennotselectedpage).

## DropOnly

Shape-level option.

Use this option on the target shape of a drag-and-drop operation, in order to make sure that the shape is not clickable.

See [Triggering an action when a shape is dragged onto another shape](xref:Triggering_an_action_when_a_shape_is_dragged_onto_another_shape).

## DynamicUnits=\[true/false\]

Shape-level option.

Available from DataMiner 10.0.9 onwards. Can be added to shapes displaying parameter values. Set this option to true to convert large values to more legible values with a different unit (e.g. to convert 1000 Mb to 1 Gb). The following units are converted out of the box: bytes (B), bits (b), bits per second (bps), bytes per second (Bps) and Kibibytes (kiB). For other units, the dynamic conversion must be defined in the element’s protocol.

From DataMiner 10.3.0/10.2.3 onwards, this feature can instead be enabled by the *DynamicUnits* [soft-launch option](xref:SoftLaunchOptions), and you can use the *DynamicUnits=\[true/false\]* option on a shape to override the default behavior determined by the soft-launch option.

## DynamicZoom

Page-level option.

Use this option to enable dynamic zooming when shapes are positioned dynamically.

See [Enabling dynamic zoom on dynamically positioned shapes](xref:Enabling_dynamic_zoom_on_dynamically_positioned_shapes).

## EmptyValue=

Shape-level option.

Used in order to display a particular text on a shape representing a parameter, when the parameter is not initialized.

See [Showing the parameter value in shape text](xref:Linking_a_shape_to_an_element_parameter#showing-the-parameter-value-in-shape-text).

## EnableConnectionOverview

Shape-level option.

Used in order to display a pop-up box with more information about connection properties when a connection is clicked.

See [Displaying DCF connection property information](xref:Options_for_displaying_DCF_connections#displaying-dcf-connection-property-information).

## EnableLoading

Page- and shape-level option.

Used in order to determine whether DataMiner should indicate if a page or shape is loading.

See [Disabling the indication that a page or shape is loading](xref:Disabling_the_Loading_message_for_a_page_or_shape).

## EnableViewConnectivity

Shape-level option.

Used in order to connect views with DCF connections.
See [Enabling view connections](xref:Options_for_displaying_DCF_connections#enabling-view-connections).

## EnableZoom

Page-level option.

Use this option to make it possible to zoom in and out on a page.

See [EnableZoom](xref:Linking_a_shape_to_a_webpage#enablezoom).

## ExactLevelMatch

Page- and shape-level option.

Used in order to limit access to a particular page or shape to users with a particular access level.

See [Making a shape or page visible only for a particular access level](xref:Making_a_shape_or_page_visible_only_for_a_particular_access_level).

## ExecuteSetsOnInit

Page-level option.

Used in order to have commands in an **Execute** field performed each time a card is opened.

See:

- [Configuring a page to update parameters on session variable changes](xref:Configuring_a_page_to_update_parameters_on_session_variable_changes)

- [Configuring a page to update a session variable when another session variable changes](xref:Configuring_a_page_to_update_a_session_variable_when_another_session_variable_changes)

## FixedWidth=\<px>\|MinWidth=\<px>\|MaxWidth=\<px>\|FixedHeight=\<px>\|...

Page-level option.

If you want to restrict the size of a particular page of a Visio drawing, you can use the six following options, separated by pipe characters:

```txt
FixedWidth=<px>|MinWidth=<px>|MaxWidth=<px>|FixedHeight=<px>|MinHeight=<px>|MaxHeight=<px>
```

> [!NOTE]
>
> - When the maximum size is reached, the content is centered on the card.
> - When the minimum size is reached, the content is shown in a scroll viewer.
> - When page scrollbars are visible, you can use the mouse wheel to scroll the page. Use CTRL+Scroll to zoom.

## FollowInput

Shape-level option.

Used in order to make a series of interconnected shapes to take on a specific color by default.

See [Making connections inherit alarm colors](xref:Options_for_displaying_DCF_connections#making-connections-inherit-alarm-colors).

## FollowInterfacePathColor

Page-level option.

Used to make connections inherit the alarm color of the interfaces.

See [Making connections inherit alarm colors](xref:Options_for_displaying_DCF_connections#making-connections-inherit-alarm-colors).

## FollowPathColor

Page-level option.

Used to make connections inherit the alarm color of the elements they connect.

See [Making connections inherit alarm colors](xref:Options_for_displaying_DCF_connections#making-connections-inherit-alarm-colors).

## FollowPathColorFill

Shape-level option.

Used to fill a shape in a connectivity chain with the highlight color.

See [Making connections inherit alarm colors](xref:Options_for_displaying_DCF_connections#making-connections-inherit-alarm-colors).

## ForceFullTable

Shape-level option.

Available from DataMiner 9.5.1 onwards. Used to override the default table loading behavior when dynamically positioning shapes.

See [Overriding the default table loading behavior](xref:Positioning_shapes_dynamically1#overriding-the-default-table-loading-behavior).

## ForcePropertyFromPage

Shape-level option.

Use this option to make all \[property:...\] placeholders refer to properties of the object to which the Visio file is linked.

See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

## ForcePropertyFromParent

Shape-level option.

Use this option if you want *\[this view\]*, *\[this service\]*, *\[this element\]*, *\[this ViewID\]*, *\[this ServiceID\]*, *\[this ElementID\]*, and *\[this reservationID\]* placeholders for child shapes to refer to the view, service, element, or reservation specified in their parent shape, instead of the one linked to the entire Visio drawing.

See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

## ForcePropertyFromShape

Shape-level option.

Used to make all \[property:...\] placeholders refer to properties of the object to which a shape is linked.

See [Placeholders for variables in shape data values](xref:Placeholders_for_variables_in_shape_data_values).

## ForcePropertyFromVisioLinkedObject

Shape-level option.

Deprecated. Use [ForcePropertyFromShape](#forcepropertyfromshape) instead.

## FullElementState

Shape-level option.

Available from DataMiner 9.5.3 onwards. Used in case a child element of a child service is displayed in the Visual Overview of a parent service, in order to display the full alarm state of the child element, instead of only the alarm state of the element parameters included in the child service.

## Hidden

Page-level option.

Used to deny DataMiner access to a particular page of a Visio drawing. When a page is marked as “hidden”, it is not displayed in Visual Overview, and it is not available in the tree view of a card navigation pane. It can, however, still be displayed in (pop-up) windows that are opened as a result of someone clicking a shape to which a shape data field of type **VdxPage** has been added.

See [Making a shape display a particular page of the current Visio drawing](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing) and [Conditionally showing or hiding a page of a Visio drawing](xref:Conditionally_showing_or_hiding_a_page_of_a_Visio_drawing).

## Hidden=...\|Visible=...

Page-level option.

Used in order to show or hide a Visio page depending on conditions.

See [Conditionally showing or hiding a page of a Visio drawing](xref:Conditionally_showing_or_hiding_a_page_of_a_Visio_drawing).

## HideAlarmsThatAreCurrentlyCorrelated

Shape-level option.

When shapes are generated representing alarms, use this option in order to not generate shapes for correlated alarms.

See [Generating shapes that represent alarms](xref:Generating_shapes_that_represent_alarms).

## HideConnectionLines

Page-level option.

When connectivity has been defined in a drawing, you can use the “*HideConnectionLines*” option to hide the connections between the shapes in a connectivity chain.

## HideWhenScheduled

Shape-level option.

Use this option if you want a shape to be hidden when the element to which it is linked is about to be used in a scheduled Automation script. This way, you can prevent users from changing something to an element that is about to be used in a scheduled Automation script.

## HighlightAnimation

Shape-level option.

Available from DataMiner 9.5.12 onwards. Used in order to display an animated shape on a highlighted connection.

See [Displaying an animated shape on highlighted connections](xref:Options_for_highlighting_DCF_connections#displaying-an-animated-shape-on-highlighted-connections).

## HighlightPath

Page-level option.

Use this option to highlight a chain when a shape or connection in the chain is clicked. Alternatively, you can also use this option along with the "ConnectivityLines" option in order to visualize connectivity using manually drawn lines.

See [Using existing lines as connectivity lines](xref:Options_for_displaying_DCF_connections#using-existing-lines-as-connectivity-lines) and [Controlling highlighting when using physical connectors](xref:Options_for_highlighting_DCF_connections#controlling-highlighting-when-using-physical-connectors).

## HighlightShapesOnly

Page-level option.

Use this option to make sure only shapes are highlighted, and not the connections between them.

See [Applying highlighting to shapes only](xref:Options_for_highlighting_DCF_connections#applying-highlighting-to-shapes-only).

## HighlightStyle

Shape-level option.

Use this option to specify the highlight style for DCF connections.

See [Customizing the highlight style](xref:Options_for_highlighting_DCF_connections#customizing-the-highlight-style) and [Conditional shape highlighting](xref:Conditional_shape_highlighting).

## HighlightTarget

Shape-level option.

Used in order to apply conditional highlighting styles to DCF connections.

See [Conditionally applying a highlight style](xref:Options_for_highlighting_DCF_connections#conditionally-applying-a-highlight-style).

## HorizontalScrollbarVisibility

Shape-level option.

Available from DataMiner 9.5.1 onwards. Allows you to configure the behavior of the horizontal scrollbar of a text block control.

See [Creating a text block control](xref:Creating_a_text_block_control).

## HoverType=Geometry

Page- and shape-level option.

Available from DataMiner 9.5.14 onwards. Allows you to specify a different hover style for shapes.

See [Configuring the hover area of a shape](xref:Configuring_the_hover_area_of_a_shape).

## IgnoreInternalConnections

Page-level option.

Available from DataMiner 9.5.1 onwards. Used in order to ignore the internal structure of elements for path highlighting.

See [Ignoring internal connections](xref:Options_for_highlighting_DCF_connections#ignoring-internal-connections).

## IgnoreUnsetValues

Shape-level option.

Used when linking a shape to a calculation involving multiple parameters, in order to show a calculated value even if not all parameter values are available.

See [Linking a shape to a calculation involving multiple parameters](xref:Linking_a_shape_to_a_calculation_involving_multiple_parameters).

## InlineVisioContextMenuVisible

Shape-level option.

By default, when you right-click a Visio drawing displayed in a shape, the shortcut menu of the Visio drawing containing that shape will appear. If you want a Visio drawing inside a shape to have its own shortcut menu, add a shape data field of type **Options** to the shape displaying the Visio drawing, and set its value to “*InlineVisioContextMenuVisible*”.

See [Making a shape display a particular page of the current Visio drawing](xref:Making_a_shape_display_a_particular_page_of_the_current_Visio_drawing).

## InlineVdx

Shape-level option.

Use this option to turn a shape into a tab control that displays all pages of a Visio drawing.

See [Turning a shape into a tab control that displays pages of a Visio file](xref:Turning_a_shape_into_a_tab_control_that_displays_pages_of_a_Visio_file).

## InlineVdx\|ApplyShapeBackground

Shape-level option.

Use this option to turn a shape into a tab control that displays all pages of a Visio drawing.

See [Turning a shape into a tab control that displays pages of a Visio file](xref:Turning_a_shape_into_a_tab_control_that_displays_pages_of_a_Visio_file).

## InterfaceConnectionLinesOnBackground

Page-level option.

Used in order to draw external connection lines in the background, and internal connection lines in the foreground of a drawing.

See [Placing connection lines in the background or in the foreground](xref:Options_for_displaying_DCF_connections#placing-connection-lines-in-the-background-or-in-the-foreground).

## InterfaceParameter:\<paramID>

Shape-level option.

Used to link a shape to an interface that is created dynamically based on protocol table data.

See [Linking shapes to dynamically created interfaces](xref:Automatically_displaying_external_and_internal_connections#linking-shapes-to-dynamically-created-interfaces).

## InternalConnectionGroup

Shape-level option.

Used to assign group names to shapes, so that internal connections are automatically drawn between parent shapes that share the same group name.

See [Automatically linking interfaces to subshapes](xref:Automatically_displaying_external_and_internal_connections#automatically-linking-interfaces-to-subshapes).

## InternalInterfaceHopping

Shape-level option.

Used to display connections when some interfaces are missing.

See [Displaying connections when some interfaces are missing](xref:Options_for_displaying_DCF_connections#displaying-connections-when-some-interfaces-are-missing).

## LinkConnectionProperty=X;Y

Shape-level option.

Available from DataMiner 9.5.9 onwards. Used to link DCF connection properties.

See [Linking connection properties](xref:Options_for_displaying_DCF_connections#linking-connection-properties).

## LineAnimationInterval

Shape-level option.

Available from DataMiner 9.5.12 onwards. Used in order to configure the interval of an animation on a highlighted connection.

See [Displaying an animated shape on highlighted connections](xref:Options_for_highlighting_DCF_connections#displaying-an-animated-shape-on-highlighted-connections).

## LineAnimationSpeed

Shape-level option.

Available from DataMiner 9.5.12 onwards. Used in order to configure the speed of an animation on a highlighted connection.

See [Displaying an animated shape on highlighted connections](xref:Options_for_highlighting_DCF_connections#displaying-an-animated-shape-on-highlighted-connections).

## LineProperty

Shape-level option.

Used in order to only apply certain highlight style properties to DCF connections.

See [Applying only certain highlight style properties](xref:Options_for_highlighting_DCF_connections#applying-only-certain-highlight-style-properties).

## LinkingOnly

Shape-level option.

Used to link a shape to a spectrum analyzer parameter without displaying a spectrum thumbnail.

See [Keeping a shape from turning into a spectrum thumbnail](xref:Linking_a_shape_to_an_element_parameter#keeping-a-shape-from-turning-into-a-spectrum-thumbnail).

## MaxHops=

Shape-level option.

Available from DataMiner 9.5.1 onwards. Determines the maximum number of hops that are displayed when a signal path is automatically generated.

See [Generating the DCF signal path of a particular element and interface](xref:Generating_the_DCF_signal_path_of_a_particular_element_and_interface).

## MaxShapes=

Shape-level option.

Available from DataMiner 9.5.1 onwards. Determines the maximum number of parent element shapes in a single column when a signal path is automatically generated.

See [Generating the DCF signal path of a particular element and interface](xref:Generating_the_DCF_signal_path_of_a_particular_element_and_interface).

## NavigationUIVisibility

Shape-level option.

Used to display a *Back* and *Forward* button in embedded webpages.

See [NavigationUIVisibility](xref:Linking_a_shape_to_a_webpage#navigationuivisibility).

## NoAlarmColorFill

Shape-level option.

If you specify this option, the shape will not be filled with the current alarm color of the element, view, service, etc. to which it is linked.

This option also disables any default alarm blinking behavior on the shape. Blinking conditions specified on the shape itself are not affected. If, for example, you specified a show/hide condition in a shape linked to an element, you can also add the *NoAlarmColorFill* option to that shape to prevent interference of default alarm blinking with the show/hide functionality.

This option can also be specified on subshapes.

## NoAutoScale

Page-level option.

Use this option if you do not want the Visio drawing to automatically take the size of the card. In the *NoAutoScale* mode, the zoom factor of the Visio drawing will be set to 100 percent and scrollbars will appear when the size of the card is smaller than the size of the Visio drawing.

It is good practice to use this option on Visio pages that contain controls (parameter controls, *SetVar* controls, charts, etc.). That way, you can prevent any scaling issues involving those controls.

> [!NOTE]
> If this option is added on a page where shapes are positioned dynamically, the page canvas will automatically be expanded so that all dynamically positioned shapes are visible, with an extra margin of 10 pixels. To avoid this default behavior, specify the *ClipToBound* option. See [ClipToBound](#cliptobound).

## NoCenter

Page-level option.

If you use this option, the Visio page will not be centered on the card. Instead, it will be aligned top-left.

## NoCopyElementProperty

Shape-level option.

Obsolete from DataMiner 10.0.11 onwards. Use the [AllowInheritance=False](#allowinheritancefalse) option instead.

By default, child shapes of a Visio shape that is linked to a service or an element automatically inherit the element shape data of the parent shape. In cases where you want to e.g. link a child shape to another service or element, you can use the *NoCopyElementProperty* option to disable this automatic inheritance.

## NoDefaultContextMenu

Shape-level option.

If you want to disable the default right-click menu of a shape, then add a shape data field of type **Options** to the shape, and set its value to “*NoDefaultContextMenu*”.

## NoDragText

Shape-level option.

Used on a shape to make sure no text message appears when the shape is dragged.

See [Triggering an action when a shape is dragged onto another shape](xref:Triggering_an_action_when_a_shape_is_dragged_onto_another_shape).

## NoDuplicate

Shape-level option.

Available from DataMiner 9.5.1 onwards. Used to keep a shape from being duplicated when generating the DCF signal path.

See [Generating the DCF signal path of a particular element and interface](xref:Generating_the_DCF_signal_path_of_a_particular_element_and_interface).

## NoHighlightFillStyle

Shape-level option.

Used in order to make a shape in a connectivity chain ignore the highlighting fill style when it is highlighted.

See [Ignoring the highlight style](xref:Options_for_highlighting_DCF_connections#ignoring-the-highlight-style).

## NoHighlightLineStyle

Shape-level option.

Used in order to make a shape in a connectivity chain ignore the highlighting line style when it is highlighted.

See [Ignoring the highlight style](xref:Options_for_highlighting_DCF_connections#ignoring-the-highlight-style).

## NoHighlightTextStyle

Shape-level option.

Used in order to make a shape in a connectivity chain ignore the highlighting text style when it is highlighted.

See [Ignoring the highlight style](xref:Options_for_highlighting_DCF_connections#ignoring-the-highlight-style).

## NonElementProtocol

Page- and shape-level option.

When you are configuring a large number of shapes linked to different elements, but you do not need any element-specific formatting from files like *description.xml*, *informations.xml*, or *port.xml*, you can use the shape option “*NonElementProtocol*” to enhance the overall performance of the Visio drawing.

This option can be used in shapes linked to elements, parameters, matrices, session variables, parameter summaries, and parameter controls. From DataMiner 9.0.1 onwards, this option can also be used on a page, so that it is applied to all shapes on that page.

> [!NOTE]
>
> - In case of grouped shapes, this property should only be specified on the main shape, except if you use dynamic placeholders in the subshapes (e.g. \[param:...\], \[property:...\], etc.).
> - From DataMiner 9.0.2 onwards, this option can also be applied system-wide. See [Activating the NonElementProtocol option system-wide](xref:Configuration_of_DataMiner_processes#activating-the-nonelementprotocol-option-system-wide).
> - From DataMiner 9.0.3 onwards, this option can be used with a “*=True*” or “*=False*” suffix, so that it can be easily enabled or disabled.
> - A shape-level *NonElementProtocol* option will override a page-level *NonElementProtocol* option, and a page-level *NonElementProtocol* option will override the system-level *NonElementProtocol* option in the *MaintenanceSettings.xml* file.

## NoSelectionFilters

Shape-level option.

Available from DataMiner 9.5.1 onwards. Used in order to disable the automatic subscription filter when using dynamic shape positioning or dynamic shape generation in an EPM environment.

See [Disabling the automatic selection filter in an EPM environment](xref:Positioning_shapes_dynamically1#disabling-the-automatic-selection-filter-in-an-epm-environment) and [Generating shapes based on table rows](xref:Generating_shapes_based_on_table_rows).

## OpenInNewCard

Shape-level option.

If a shape is linked to an element, a service, a view or a redundancy group, then you can use the “*OpenInNewCard*” option to make that element, service, view or redundancy group open in a new card.

See [Having the Visio drawing opened in a new card](xref:Linking_a_shape_to_an_element_a_service_or_a_redundancy_group#having-the-visio-drawing-opened-in-a-new-card).

## OverridePageName=

Page-level option.

Available from DataMiner 10.2.11/10.3.0 onwards. Allows you to override the name of a Visio page.

You can for example use this to have multiple pages with the same name in DataMiner, as Microsoft Visio itself does not allow the creation of multiple pages with the same name. However, note that components that display Visio page names may then also display these duplicate page names.

> [!NOTE]
>
> - Always use the actual page name when referring to a particular page in options like e.g. VdxPage, NavigatePage, InlineVdx, etc. Referring to the override name will not work in such cases.
> - This option is not supported for Visio drawings displayed in DataMiner web apps.

## PageScale

Shape-level option.

Available from DataMiner 9.5.4 onwards. Used in order to disable rescaling of a shape when dynamic zooming is used.

See [Disabling rescaling of a particular shape](xref:Enabling_dynamic_zoom_on_dynamically_positioned_shapes#disabling-rescaling-of-a-particular-shape).

## PageVariable

Page- and shape-level option.

Used to limit the scope of a session variable to the current page.

See [Turning a shape into a control to update a session variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable).

## PositionOnCenterOfRotation

Shape-level option.

Available from DataMiner 9.5.12 onwards. Used to position shapes dynamically based on the rotation center of the shape instead of the physical center.

See [Positioning shapes based on their rotation point](xref:Positioning_shapes_dynamically1#positioning-shapes-based-on-their-rotation-point).

## PropertyFilter=\[PropertyName\]=\[PropertyValue\]

Shape-level option.

When linking a Visio shape to all child items of a view or service (using “\[auto\]” in a shape data field of type **Element**), you can use this option to specify that a particular shape should only be used to represent items of which the specified property has the specified value. This can be an element property, a service property, or a view property.

## Protocol=\[ProtocolName:Version\]

Shape-level option.

Used when connection properties are configured to be displayed, in order to place the property shapes on top of interface/connection intersections.

See [Displaying connection properties](xref:Options_for_displaying_DCF_connections#displaying-connection-properties).

## ProtocolFilter=\[ProtocolName\]

Shape-level option.

When linking a Visio shape to all child items of a view or service (using “\[auto\]” in a shape data field of type **Element**), use this option if a particular shape should only be used to represent elements based on the specified protocol.

## PushContextMenu

Shape-level option.

Used in order to extend the shortcut menu of a container shape with shortcut menu items from its child shapes.

See [Extending a container shape shortcut menu with child shape shortcut menu items](xref:Grouping_shapes#extending-a-container-shape-shortcut-menu-with-child-shape-shortcut-menu-items).

## RefreshButtonVisibility

Shape-level option.

Used in order to add a refresh button to an embedded webpage.

See [RefreshButtonVisibility](xref:Linking_a_shape_to_a_webpage#refreshbuttonvisibility).

## ResolveWithDCF

Shape-level option.

Used to dynamically link an element to a shape based on DCF connection info.

See [Linking a shape to an element based on DCF connections](xref:Linking_a_shape_to_an_element_based_on_DCF_connections).

## RetrieveInternalConnectivity

Shape-level option.

Available from DataMiner 9.5.3 onwards. Used to subscribe to internal connections when dynamic positioning is used.

See [Subscribing to internal connections when using dynamic positioning](xref:Options_for_displaying_DCF_connections#subscribing-to-internal-connections-when-using-dynamic-positioning).

## Selectable

Shape

Used in order to disable a shape's default hyperlink behavior, so that it can be selected instead.

See [Making shapes selectable](xref:Making_shapes_selectable).

## SelectionHighlighting

Shape-level option.

Available from DataMiner 10.0.3 onwards. Used to disable path highlighting when a connection line is clicked.

See [Disabling path highlighting when a connection line is clicked](xref:Options_for_highlighting_DCF_connections#disabling-path-highlighting-when-a-connection-line-is-clicked).

## SelectionVar=

Page-level option.

Makes the text of a “Selectable” shape get copied to a session variable when that shape is clicked.

See [Making a selectable shape get copied to a session variable](xref:Making_shapes_selectable#making-a-selectable-shape-get-copied-to-a-session-variable).

## ShowWhenScheduled

Shape-level option.

Use this option if you want a shape to be shown when the element to which it is linked, is about to be used in a scheduled Automation script. This way, you can for example visually warn users not to change anything to an element that is about to be used in a scheduled Automation script.

## SingleSignOn

Shape-level option.

Available from DataMiner 9.5.6 onwards. Used to always pass an authentication ticket to an embedded webpage, regardless of the content of the URL.

See [SingleSignOn](xref:Linking_a_shape_to_a_webpage#singlesignon).

## SkipAsHost

Shape-level option.

Used to make DataMiner ignore a parent shape when determining the element on which a command should be executed.

See [Making subshapes execute parameter sets or Automation scripts on the element linked to the parent shape](xref:Grouping_shapes#making-subshapes-execute-parameter-sets-or-automation-scripts-on-the-element-linked-to-the-parent-shape).

## StartResolvingFromParent

Shape-level option.

Available from DataMiner 9.5.4 onwards. Up to DataMiner 9.5.4, when an asterisk ("\*") is used in shape data to refer to an element, view or service, the asterisk is replaced with the first element ID, view ID or service ID that is found from the parent shape upwards, but the current shape is not checked. From DataMiner 9.5.4 onwards, however, the current shape is checked as well. If, for reasons of backwards compatibility, you want the asterisk character to be resolved from the parent shape, add the *StartResolvingFromParent* option to the shape that has to retrieve the element, view or service reference.

> [!NOTE]
> If no element or service reference can be found in either of the parent shapes, the element or service to which the Visio file is assigned will be used to resolve the asterisk.

## StraightLines

Shape-level option.

Available from DataMiner 9.5.1 onwards. Use this option to draw connection lines using a pathing algorithm.

See [Using a pathing algorithm to display connection lines](xref:Options_for_displaying_DCF_connections#using-a-pathing-algorithm-to-display-connection-lines).

## TabControlStyle=2

Shape-level option.

Available from DataMiner 9.5.14 onwards. Use this option to configure an alternative style for tab controls.

See [Turning a shape into a tab control that displays pages of a Visio file](xref:Turning_a_shape_into_a_tab_control_that_displays_pages_of_a_Visio_file).

## Template

Shape-level option.

Available from DataMiner 9.5.8 onwards. See [Dynamically selecting shape templates for dynamically positioned shapes](xref:Positioning_shapes_dynamically1#dynamically-selecting-shape-templates-for-dynamically-positioned-shapes).

## UseIE

Shape-level option.

Available from DataMiner 10.0.10 onwards. Allows you to embed an Internet Explorer web browser control. However, note that this browser is **deprecated** and using this option is therefore not recommended.

See [UseIE](xref:Linking_a_shape_to_a_webpage#useie).

## UseChrome

Shape-level option.

Available from DataMiner 9.6.3 onwards. Allows you to embed a Chromium web browser control.

See [UseChrome](xref:Linking_a_shape_to_a_webpage#usechrome).

## UseEdge

Shape-level option.

Available from DataMiner 10.1.11/10.2.0 onwards. Allows you to embed an Edge web browser control.

See [UseEdge](xref:Linking_a_shape_to_a_webpage#useedge).

## UseLoginCredentials

Shape-level option.

Use this option if you want to pass on the user credentials of the current user to a web page displayed inside a shape.

See [UseLoginCredentials](xref:Linking_a_shape_to_a_webpage#uselogincredentials).

> [!NOTE]
> This feature only works when you have logged on to DataMiner Cube explicitly using Basic Authentication (i.e. with a username and a password). It will not work when you have logged on with your Windows user credentials.

## UseResource

Shape-level option.

Available from DataMiner 10.2.0/10.1.10 onwards. See [Linking a shape to a resource](xref:Linking_a_shape_to_a_resource).

## VerticalScrollbarVisibility

Shape-level option.

Available from DataMiner 9.5.1 onwards. Allows you to configure the behavior of the vertical scrollbar of a text block control.

See [Creating a text block control](xref:Creating_a_text_block_control).

## Visible

Page-level option.

Used to make a page of Visio drawing visible depending on a property or parameter.

See [Depending on the current value of a parameter or a property](xref:Conditionally_showing_or_hiding_a_page_of_a_Visio_drawing#depending-on-the-current-value-of-a-parameter-or-a-property).

## WorkSpaceVariable

Page- and shape-level option.

Available from DataMiner 9.5.9 onwards. Used to limit the scope of a session variable to the current card.

See [Indicating the scope of the variable](xref:Turning_a_shape_into_a_control_to_update_a_session_variable#indicating-the-scope-of-the-variable).

## #RRGGBB=ThemeForeground\|#RRGGBB=ThemeAccentColor\|#RRGGBB=ThemeBackground

Page-level option.

Use this option if you want to link the colors in a Visio drawing to the colors used in the DataMiner Cube theme.

To do so, you have to specify three colors on page level:

- The foreground color

- The background color

- The accent color

Example:

```txt
#000000=ThemeForeground|#FF0000=ThemeAccentColor|#FFFFFF=ThemeBackground
```

If you specify the value above, in a theme with a light background, black text and shapes will be displayed on a white background, while in a theme with a dark background, the colors will be reversed. In other words, all items in the drawing that use the colors specified in the option will be assigned the theme color.
