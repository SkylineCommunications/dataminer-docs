---
uid: Custom_branding
---

# Custom branding

## Introduction

All DataMiner software issued for third parties with a co-branding agreement is shipped with a custom brand theme.

### What's inside a custom brand theme?

If you want Skyline to provide you with a custom brand theme, then please send us the following:


| Image and information | For more information, see... |
| --------------------- | ---------------------------- |
| Cube login logo | “Cube login logos” on page 5 |
| Product logo | “Product logo” on page 7 |
| Custom background image (optional) | “Custom background” on page 8 |
| Corporate accent colors | “Accent colors” on page 9 |
| Contact information | “Contact information” on page 11 |

## Cube login logos

Two login logos should be provided:

- one that fits a dark background, and
- one that fits a light background.

### Width & height

- Height: 30 px
- Width: Scales with the aspect ratio, and should not exceed 10:1 (i.e. max. 300 px).
- Mandatory white space: None

### Color

The background color of the login logos should match the theme color.

### File format

- png, or
- jpg

### Default Cube login screens

#### Dark background

#### Light background

### Login screen will show the DataMiner logo by default

If you do not provide custom login logos, then the login screen will show the DataMiner logo by default.

## Product logo

### Width & height

- Total height: 32 px, including white space.
- Total width: max. 300 px.
- White space: 9px at the top and 9px at the bottom.

### Color

The background color of the product logo should match the accentColor background.

See also: “Accent colors” on page 9

### File format

- png, or
- jpg

### Default product logo

### 'Powered by' labels

By default, the product logo in the top-left corner of the Cube screen and the footer in the About box will include a "Powered by DataMiner" label.

If one or both of those labels should not be displayed, ask your Technical Account Manager to disable the *PoweredBy visible on Main* and/or *PoweredBy visible on About* options.

## Custom background

As to background, there are three possibilities:

- an image,
- a color, or
- a combination of an image and a color.

> [!NOTE]
> When you opt for a background image, and the background color of that image is not identical to the theme's default background color, then specify a custom background color that is identical to the background color of the image.

### Image

- Subtle, light background image
- Height: 1050 px
- Width: 1680 px
- 72 ppi
- png or jpg

### Color

- Subtle, light, solid color

### Combination of image and color

The image can be

- stretched, or
- positioned top/right/bottom/left

### Default background

By default, no background image is used.

## Accent colors

By default, DataMiner Cube comes with two themes: **Skyline Mixed** and **Skyline Black**.

> [!NOTE]
> When asking Skyline for a custom brand theme, then please indicate on which theme you want that custom theme to be based: "Skyline Mixed", "Skyline Black" or both.

See below for an overview of the colors used in both Skyline themes.

### accentColor

The general accent color.

- Mixed theme: HEX #0072C6, RGB 0-114-198
- Black theme: HEX #0072C6, RGB 0-114-198
	
Examples:

- Header
- System Center sections
- Alarm Console footer background

### accentDarkColor

The background color of the Surveyor side bar, the Surveyor tabs, and the toggle buttons in the Alarm Console footer.

- Mixed theme: HEX #004373, RGB 0-67-115
- Black theme: HEX #004373, RGB 0-67-115

### accentLightColor

The background color of search result lists, selection boxes, and navigation buttons.

- Mixed theme: HEX #9DC3E6, RGB 157-195-230
- Black theme: HEX #9DC3E6, RGB 157-195-230

Examples:

- Background of search result list in Alarm Console
- Background of filtered dynamic tables
- Background of filtered element list in view cards

### accentFilterColor

The background color of toggle buttons.

- Mixed theme: HEX #2A8AD4, RGB 42-138-212
- Black theme: HEX #2A8AD4, RGB 42-138-212
 
Examples:

- Background of selected toggle buttons in Alarm Console
- Background of Surveyor tabs while hovering over them
- Background of Alarm Console search buttons while hovering over them

### accentColorText

The text color used when the background has the accent color.

- Mixed theme: HEX #FFFFFF, RGB 255-255-255
- Black theme: HEX #FFFFFF, RGB 255-255-255
		
Example:

- Text color of selected sections and tiles in System Center

### accentTextColor

The text color used when the background has the theme’s background color (white/black).

- Mixed theme: HEX #0072C6, RGB 0-114-198
- Black theme: HEX #9DC3E6, RGB 157-195-230
	
Example:

- Titles on the Cube home page

### accentInvertTextColor

The text color used when the background color is inverted.

- Mixed theme: HEX #B4D3EF, RGB 180-211-239
- Black theme: HEX #B4D3EF, RGB 180-211-239
		
Example:

- Text color in Surveyor search result list

> [!NOTE]
> - **accentFilterColor** needs to be a color that works well in combination with a dark background as the one used in the Surveyor and the Alarm Console footer.
> - **accentTextColor** needs to be a color that works well in combination with either the default theme color or the custom background image/color.

## Contact information

In a custom brand theme, the contact information in the General tab page of the DataMiner Cube About box will also be customized:

| Information                  | Default                                       |
|------------------------------|-----------------------------------------------|
| Company name                 | Skyline Communications N.V.                   |
| Product name                 | DataMiner                                     |
| Company website              | <www.skyline.be>                              |
| Company email                | <info@skyline.be>                             |
| TechSupport name             | DataMiner Technical Support                   |
| TechSupport address (line1)  | Ambachtenstraat 33                            |
| TechSupport address (line 2) | B-8870 Izegem                                 |
| TechSupport address (line 3) | Belgium                                       |
| TechSupport website          | <www.skyline.be/Contact/TechnicalSupport.htm> |
| TechSupport email            | <techsupport@skyline.be>                      |
| Extranet link                | <dcp.skyline.be>                              |
| Online collaboration link    | <www.skyline.be/meeting.exe>                  |

> [!NOTE]
> If a custom product name is specified, this will also replace the DataMiner tab name in the Logging app and the "(DataMiner)" root in the tree view pane of the Resources app.

### Default contact info
