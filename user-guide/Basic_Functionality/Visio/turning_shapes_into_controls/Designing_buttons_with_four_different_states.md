---
uid: Designing_buttons_with_four_different_states
---

# Designing buttons with four different states

> [!TIP]
> For a how-to video, see [Visio – Customizing mouseover effects on a view object](https://community.dataminer.services/video/visio-customizing-mouseover-effects-on-a-view-object/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

In Visio, you can design buttons with four different states:

- Normal,
- MouseOver,
- Pressed, and
- Disabled.

To create such a button, do the following:

1. Create four identical shapes.
1. Add a shape data field of type **ButtonState** to each of those shapes, giving each field one of the above-mentioned values.
1. Stack those four shapes on top of each other, and group them.

> [!NOTE]
>
> - For the disabled state to work, the linked shape must have the shape data **Options** with value "AllowControlDisable". See [Dynamically disabling a parameter control](xref:Turning_a_shape_into_a_parameter_control#dynamically-disabling-a-parameter-control).
> - For an example, see [Ziine](xref:ZiineDemoSystem) > *Visual Overview Design Examples* view > *[controls > BUTTON]* page.

## Creating a toggle button

It is possible to combine a button with four different states with SHOW/HIDE actions in order to create a toggle button.

To create a toggle button, a shape data field of type **ButtonState** with value "Pressed" is combined with shape data field of type **Parameter**, to which a SHOW/HIDE action has been added.

If the button is clicked, this will trigger the SHOW/HIDE action once. The condition for the SHOW/HIDE action is then evaluated afterwards, and depending on the parameter value returned by the server, the SHOW/HIDE action may be applied again. As such, as soon as you click the button, the "Pressed" state is applied, but the show/hide condition may still change afterwards.

### Example

| Shape data field | Value         |
| ---------------- | ------------- |
| ButtonState      | Pressed       |
| Parameter        | 1\|SHOW;=2;=1 |

> [!NOTE]
>
> - This kind of toggle button can only be used to set a parameter, not to e.g. execute an Automation script. In other words, always add a shape data field of type **Execute** on group level of which you set the value to "Set\|..."
> - If you click *Cancel* in the confirmation box, the "Pressed" state is reset.

> [!TIP]
> See also: [Basic conditional shape manipulation actions](xref:Basic_conditional_shape_manipulation_actions)
