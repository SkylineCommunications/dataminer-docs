---
uid: Visio_style_guide
---

# Visio style guide

In this style guide, you can find a number of formatting conventions as well as information about the standard DataMiner stencils and Skyline icons.

Applying these conventions and using these standard stencils and icons will ensure your Visio drawings are designed according to the DataMiner house style.

> [!NOTE]
> The conventions listed in this section should be considered recommendations. They are in no way mandatory.

## Conventions

### Colors

#### Color palettes​

##### Default DataMiner color palette

​<span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(0,67,115);">0,67,115</span>
​<span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(0,114,198);">0,114,198*</span>
​<span style="padding:5px;width:200px;text-align:center;color:black;background-color:rgb(229,229,229);">229,229,229</span>

*ThemeAccentColor​

##### Custom​ color palette

<span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(100,125,125);">100,125,125</span>
​<span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(160,177,135);">160,177,135</span>
​<span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(50,135,155);">50,135,155</span>
​<span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(190,170,135);">190,170,135</span>

> [!NOTE]
> When configuring color palettes, think of people with visual impairments (e.g. color blindness).

#### Alarm colors​

These are the default alarm colors used in a DataMiner System.

| Alarm type/severity | Default color |
| ------------------- | ------------- |
| Not monitored, error, notice, information​ | <span style="padding:5px;width:200px;text-align:center;color:black;background-color:rgb(204,204,204);">204,204,204</span> |
| Normal | <span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(22,198,12);">22,198,12</span> |
| Warning | <span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(59,120,255);">59,120,255</span> |
| Minor | <span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(97,214,214);">97,214,214</span> |
| Major | <span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(245,210,40);">245,210,40</span> |
| Critical | <span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(240,50,65);">240,50,65</span> |
| Timeout | <span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(255,155,15);">255,155,15</span> |
| Initial​ | <span style="padding:5px;width:200px;text-align:center;color:black;background-color:rgb(242,242,242);">242,242,242</span> |
| Masked | <span style="padding:5px;width:200px;text-align:center;color:white;background-color:rgb(136,23,152);">136,23,152</span> |​

> [!NOTE]
> You can change the default alarm colors in the DataMiner.xml file. See [Changing the default alarm colors](xref:Changing_the_default_alarm_colors)

#### Changing colors

You are allowed to

- lighten or darken colors by a maximum of 20 percent​
- use transparency​

> [!NOTE]
> When changing colors, make sure they are compatible with the Skyline Black theme.

### Font

Default font: Segoe UI​

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

*Except short words such as "the" and "of" if they are not the first word.

### Alignment

Parallel lines, images, parameters, etc. must be neatly aligned with each other.

## Stencils

Microsoft Visio allows the use of so-called stencil files, which contain a collection of template shapes that can be dragged onto a drawing.

Skyline provides the following DataMiner stencil files that will help you design Visio drawings according to the DataMiner house style:

- [Icons](#icons)
- [Buttons](#buttons)
- [KPI](#kpi)

Typically, a Visio shape will consist of a number of different shapes, grouped together, each with a number of shape data fields. These fields are used to configure DataMiner functionality when a drawing is used in Visual Overview. Previously, the person who designed a drawing had to keep track of which shape data fields were configured in which shapes. When adding a shape from a DataMiner stencil, you only have to enter the group-level shape data. All other shape data in the underlying child-level shapes will be added automatically by means of macros. Note that the names of automatically added shape data fields will all start with an underscore character.

### Icons

The Icons stencil contains all icons found on the [Skylicons](https://skyline.be/skylicons/) website.

Icons can be used

- next to a title​
- in a KPI​
- on action buttons​
- in diagrams
- ...

See also [Skylicons](#skylicons)

### Buttons

The Buttons stencil contains three types of buttons that can be placed on Data pages.

- [Action buttons](#action-buttons)
- [Toggle buttons](#toggle-buttons)
- [Link buttons](#link-buttons)

#### Action buttons

Clicking an action button will cause an action to be performed immediately. Use this type of button to change the value of e.g. a parameter or a session variable, to launch a non-interactive Automation script, etc.

Action buttons are rounded rectangles.

#### Toggle buttons

A toggle button is used to switch between two values/states.

It is represented as a slider with text on its left or its right (depending on the button's alignment). This text can either be supplied by read parameter values or be custom text configured for each of the states.

The color of a toggle button should be set to the ThemeAccentColor.

#### Link buttons

A link button is used to open a pop-up window containing auxiliary information, to start an interactive Automation script, etc.

Link buttons are rectangles of which the button text will always end with an ellipsis ("..."). This ellipsis will indicate that further action will be necessary after clicking the button.

#### Additional remarks regarding buttons

As to text on buttons

- Use short, clear words.
- Preferably use one word only.

    If necessary​, use up to a maximum of three words. If a longer description is needed, use a tooltip.

When multiple buttons belong to the same context​, consider grouping them under a label

### KPI

The KPI stencil contains the following building blocks. Each will show read-only representations of a collection of parameters.

- Single parameters (with or without icons)
- Parameter list (normal/compact/multi)
- Connection blocks to be used in diagrams

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
> All shapes available in the KPI stencil refer to one element. This means that all parameters shown in the list have to belong to the same element. If you want to refer to a parameter belonging to another element, you can customize the shape.

### Where to find the DataMiner stencils

DataMiner upgrade packages always contain the latest versions of the DataMiner stencils. During a DataMiner upgrade, the latest versions of the DataMiner stencils will be installed automatically.

If you want to download a zip package with the latest versions of the DataMiner stencils, go to [Skylicons](https://skyline.be/skylicons/), and click **download visio stencil** in the website's header bar.

### Additional remarks regarding the DataMiner stencils

- When working with stencils in Visio, make sure the stencils are open in the *Shapes* task pane and that macros are enabled.
- When you edit a Visio drawing from within DataMiner Cube, the stencils will be loaded automatically. In Microsoft Visio, you will find them in the list of stencils under *DataMiner*.
- In some cases, no *DataMiner* section will be available in the list of stencils the first time you open a Visio drawing after upgrading to a newer DataMiner version. If so, exit Microsoft Visio and open it again.

## Skylicons

All standard Skyline icons can be downloaded from the [Skylicons](https://skyline.be/skylicons/) website in PNG or SVG format.

You can download a single icon, or you can download the full icon pack by clicking **click here to download the full pack** above the icon overview.

> [!TIP]
>
> - To request the XAML version of an icon, send an email to [devops@skyline.be](mailto:devops@skyline.be).
> - To request a new icon or to request an update of an existing icon, send an email to [team.marketing@skyline.be](mailto:team.marketing@skyline.be).

## More information

A wide range of Visio examples can be found in the [use case library](https://community.dataminer.services/use-cases/) on DataMiner Dojo.

Also on DataMiner Dojo, you can find a [DataMiner Inspire video](https://community.dataminer.services/video/dataminer-inspire-the-new-dataminer-stencils-style-guide/) on how to use the DataMiner stencils.
