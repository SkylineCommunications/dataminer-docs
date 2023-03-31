---
uid: General_Main_Release_10.4.0_highlights
---

# General Main Release 10.4.0 – Highlights - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Highlights

#### Interactive Automation scripts: New button style 'CallToAction' [ID_34904]

<!-- MR 10.4.0 - FR 10.3.1 -->

In an interactive Automation script launched from a dashboard or a low-code app, you can now apply the *CallToAction* style to a button.

When you apply this style to a button

- the background color of the button will be the color of the app,
- the color of the text on the button will be white, and
- the button will have a shadow.

To set the style of a button in an interactive Automation script, set the *Style* property of the button's *UIBlockDefinition* to the name of the style. All supported styles are available via `Style.Button`.

Alternatively, you can also pass a button style directly to the `AppendButton` method on an `UIBuilder` object.

> [!NOTE]
>
> - Up to now, `StaticText` blocks already supported a number of styles. Those styles are now also available via `Style.Text`: *Title1*, *Title2* and *Title3*.
> - The *CallToAction* style will only be applied in interactive Automation scripts launched from a web app. It will not be applied in interactive Automation scripts launched from Cube.
