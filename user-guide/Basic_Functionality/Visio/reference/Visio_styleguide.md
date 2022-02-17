---
uid: Visio_style_guide
---

# Visio style guide

In this style guide, you can find a number of formatting conventions as well as information about the standard DataMiner stencils and Skyline icons.

Applying these conventions and using these standard stencils and icons will ensure your Visio drawings are designed according to the DataMiner house style.

## Conventions

### Colors

#### Color palettes​

- DataMiner colors​

    - ThemeAccentColor​

- Custom​ color palettes

    - Not related/similar to the DataMiner colors above​
    - Be aware of color blindness​

#### Alarm colors​

- Not monitored, error, notice, information​
- Normal​
- Warning​
- Minor​
- Major​
- Critical​
- Timeout​
- Initial​
- Masked​

#### Changing colors

You are allowed to

- lighten or darken colors (max. 20 percent)​
- use transparency​

Dark Theme compatible​

### Fonts

Segoe UI​

- Preferably in one of the following colors:

    - Black (with or without transparency)​
    - White​
    - ThemeAccentColor​

- Only use the following variants:

    - Semilight
    - Regular
    - Semibold

### Casing

#### Upper case​ (i.e. all letters of all words are capitalized​)

- Titles​
- Buttons​
- Real-time parameters​

#### Title case​ (i.e. all words start with a capital*)

- Parameters​
- Info labels​
- Fields that can contain dynamic values​

* Except short words such as "the" and "of" if they are not the first word.

### Alignment

Parallel lines and images must be neatly aligned with each other.

**Example 1**

**Example 2**

## Stencils

Microsoft Visio allows the use of so-called stencil files, which contain a collection of template shapes that can be dragged onto a drawing.

Skyline provides the following DataMiner stencil files that will help you design Visio drawings according to the DataMiner house style:

- [Icons](#icons) 
- [Buttons](#buttons)
- [KPI](#kpi)

Typically, a Visio shape will consist of a number of different shapes, grouped together, each with a number of shape data fields. These fields are used to configure DataMiner functionality when a drawing is used in Visual Overview. Previously, the person who designed a drawing had to keep track of which shape data fields were configured in which shapes. When adding a shape from a DataMiner stencil, you only have to enter the group-level shape data. All other shape data in the underlying child-level shapes will be added automatically by means of macros. Note that the names of automatically added shape data fields will all start with an underscore character.

### Icons

The Icons stencil contains all icons found on the [Skylicons](https://skyline.be/skylicons/) website.

See also [Skylicons](#skylicons)

### Buttons

The Buttons stencil contains three types of buttons that can be placed on Data pages.

#### Action button

Clicking an action button will cause an action to be performed immediately. Use this type of button to change the state of e.g. a parameter, to launch an interactive Automation script, etc.

Action buttons are rounded rectangles.

#### Toggle button

A toggle button is used to switch between two states.

It is represented as a slider with text on its left or its right (depending on the button's alignment). This text can either be supplied by read parameter values or be custom text configured for each of the states.

#### Link button

A link button will open a pop-up window containing auxiliary information.

Link buttons are rectangles of which the button text will always end with an ellipsis ("...").

### KPI

The KPI stencil contains the following building blocks. Each will show read-only representations of a collection of parameters.

- Single parameters (with or without icons)
- Parameter list (normal/compact/multi)
- Connection blocks

If you want to replace an icon in a KPI, do the following:

1. Open the *Icon* stencil by clicking *More Shapes* in the *Shapes* task pane.
1. Select the correct icon and drag it onto the Visio page.
1. Delete the existing icon in the KPI block.
1. Select the colored *ParamAlarmLayer* shape, and while pressing CTRL, select the new icon.
1. In the *Home* tab of the Visio ribbon, go to *Align*, click *Align Center* and then *Align Middle*. The icon should now be in the correct spot.
1. Select the icon again, go to *Home > Line* in the Visio ribbon, and select line color "White" (or optionally 254,255,255).
1. Click a random location in the Visio drawing to unselect the icon shape.
1. Click the KPI shape, and while pressing CTRL, select the new icon shape.
1. Go to *Home > Group* in the Visio ribbon, and click *Add to Group*.

> [!NOTE]
> - All shapes available in the KPI stencil refer to one element. This means that all parameters shown in the list have to belong to the same element. If you want to refer to a parameter belonging to another element, you can customize the shape.
> - When working with stencils in Visio, make sure the stencils are open in the *Shapes* task pane and that macros are enabled.

### Where to find the DataMiner stencils

DataMiner upgrade packages always contain the latest versions of the DataMiner stencils. During a DataMiner upgrade, the latest versions of the DataMiner stencils will be installed automatically.

If you want to download a zip package with the latest versions of the DataMiner stencils, go to [Skylicons](https://skyline.be/skylicons/), and click **download visio stencil** in the website's header bar.

## Skylicons

All standard Skyline icons can be downloaded from the [Skylicons](https://skyline.be/skylicons/) website in PNG, XAML or SVG format.

To request a new icon or to request an update of an existing icon, send an email to [team.marketing@skyline.be](mailto:team.marketing@skyline.be).

By clicking **download visio stencil** in the header bar of the [Skylicons](https://skyline.be/skylicons/) website, you can download a package with the latest versions of the DataMiner stencils. One of those stencils contains the entire collection of Skyline icons.

## More information

A wide range of Visio examples can be found in the [use case library](https://community.dataminer.services/use-cases/) on DataMiner Dojo.
