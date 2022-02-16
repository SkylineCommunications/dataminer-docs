---
uid: Visio_styleguide
---

# Visio styleguide

In this styleguide, you can find a number of formatting conventions as well as information about the standard DataMiner stencils and Skyline icons.

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

Microsoft Visio allows the use of so-called stencil files. Each stencil file contains a collection of template shapes that can be dragged onto a drawing.

Skyline provides the following DataMiner stencil files that will help you design Visio drawings according to the DataMiner house style:

- Icons 
- Buttons
- KPI

Typically, a Visio shape will consist of a number of different shapes, grouped together, each with a number of shape data fields. These fields are used to configure DataMiner functionality when a drawing is used in Visual Overview. Previously, the person who designed a drawing had to keep track of which shape data fields were configured in which shapes. When adding a shape from a DataMiner stencil, you only have to enter the group-level shape data. All other shape data in underlying child-level shapes will be added automatically. Note that the names of automatically added shape data fields will all start with an underscore character.

### Icons

The icons stencil contains all icons found on the [Skylicons](https://skyline.be/skylicons/) website.

See also [Skylicons](#skylicons)

### Buttons

The buttons stencil contains three types of buttons that can be placed on Data pages.

#### Action button

Clicking an action button will cause an action to be performed. Use this type of button to change the state of e.g. a parameter, to launch an interactive Automation script, etc.

Action buttons are rounded rectangles.

#### Toggle button

A toggle button is used to switch between two states.

It is represented as a slider with text on its left or its right (depending on the alignment). This text can either be supplied by read parameter values or be custom text.

#### Link button

A link button will open a pop-up window containing a message.

Link buttons are rectangles of which the button text will always end with an ellipsis ("...").

### KPI

The KPI stencil contains the following building blocks. Each will show read-only representations of a collection of parameters.

- Single parameters (with or without icons)
- Parameter list (normal/compact/multi)
- Connection blocks

> [!NOTE]
> All shapes available in the KPI stencil refer to one element. This means that all parameters shown in the list have to belong to the same element. If you want to refer to a parameter belonging to another element, you can customize the shape.


The most important thing to check. Is the stencil open in the 'Shapes task pane' in Visio? If not, you will have to open it. If it was open, then it might be useful to check if the Button stencil is open. Sometimes the reference gets broken when both stencils are open. In general, there's no problem if you first open the KPI stencil. The best thing to do here is close all stencils, and reopen them.




### Where to find the DataMiner stencils

To download a package with the latest versions of the DataMiner stencils, go to [Skylicons](https://skyline.be/skylicons/), and click **download visio stencil** in the website's header bar.

DataMiner upgrade packages always contain the latest versions of the DataMiner stencils.

## Skylicons

All standard Skyline icons can be downloaded from the [Skylicons](https://skyline.be/skylicons/) website in PNG, XAML or SVG format (either duotone or monotone).

To request a new icon or to request an update of an existing icon, send an email to [team.marketing@skyline.be](mailto:team.marketing@skyline.be).

By clicking **download visio stencil** in the header bar of the [Skylicons](https://skyline.be/skylicons/) website, you can download a package with the latest versions of the DataMiner stencils. One of those stencils contains the entire collection of Skyline icons.

## More information

A wide range of Visio examples can be found on [DataMiner Dojo](https://community.dataminer.services/use-cases/).
