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
| Cube login logo | [Cube login logos](#cube-login-logos) |
| Product logo | [Product logo](#product-logo) |
| Custom background image (optional) | [Custom background](#custom-background) |
| Corporate accent colors | [Accent colors](#accent-colors) |
| Contact information | [Contact information](#contact-information) |

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

![Dark background](~/user-guide/images/Logon_Dark.png)

#### Light background

![Light background](~/user-guide/images/Logon_Light.png)

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

![Default product logo](~/user-guide/images/ProductLogo_Default.png)

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

- Mixed theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(0,114,198);">HEX #0072C6, RGB 0-114-198</span>

- Black theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(0,114,198);">HEX #0072C6, RGB 0-114-198</span>

Examples:

- Header
- System Center sections
- Alarm Console footer background

### accentDarkColor

The background color of the Surveyor side bar, the Surveyor tabs, and the toggle buttons in the Alarm Console footer.

- Mixed theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(0,67,115);">HEX #004373, RGB 0-67-115</span>

- Black theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(0,67,115);">HEX #004373, RGB 0-67-115</span>

### accentLightColor

The background color of search result lists, selection boxes, and navigation buttons.

- Mixed theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(157,195,230);">HEX #9DC3E6, RGB 157-195-230</span>

- Black theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(157,195,230);">HEX #9DC3E6, RGB 157-195-230</span>

Examples:

- Background of search result list in Alarm Console
- Background of filtered dynamic tables
- Background of filtered element list in view cards

### accentFilterColor

The background color of toggle buttons.

- Mixed theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(42,138,212);">HEX #2A8AD4, RGB 42-138-212</span>

- Black theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(42,138,212);">HEX #2A8AD4, RGB 42-138-212</span>
 
Examples:

- Background of selected toggle buttons in Alarm Console
- Background of Surveyor tabs while hovering over them
- Background of Alarm Console search buttons while hovering over them

### accentColorText

The text color used when the background has the accent color.

- Mixed theme: <span style="padding:2px;width:200px;text-align:center;color:black;border:1px solid black;background-color:rgb(255,255,255);">HEX #FFFFFF, RGB 255-255-255</span>

- Black theme: <span style="padding:2px;width:200px;text-align:center;color:black;border: 1px solid black;background-color:rgb(255,255,255);">HEX #FFFFFF, RGB 255-255-255</span>
		
Example:

- Text color of selected sections and tiles in System Center

### accentTextColor

The text color used when the background has the theme’s background color (white/black).

- Mixed theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(0,114,198);">HEX #0072C6, RGB 0-114-198</span>

- Black theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(157,195,230);">HEX #9DC3E6, RGB 157-195-230</span>
	
Example:

- Titles on the Cube home page

### accentInvertTextColor

The text color used when the background color is inverted.

- Mixed theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(180,211,239);">HEX #B4D3EF, RGB 180-211-239</span>

- Black theme: <span style="padding:2px;width:200px;text-align:center;color:white;background-color:rgb(180,211,239);">HEX #B4D3EF, RGB 180-211-239</span>
		
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
| Company website              | `www.skyline.be`                              |
| Company email                | `info@skyline.be`                             |
| TechSupport name             | DataMiner Technical Support                   |
| TechSupport address (line1)  | Ambachtenstraat 33                            |
| TechSupport address (line 2) | B-8870 Izegem                                 |
| TechSupport address (line 3) | Belgium                                       |
| TechSupport website          | `www.skyline.be/Contact/TechnicalSupport.htm` |
| TechSupport email            | `techsupport@skyline.be`                      |
| Extranet link                | `dcp.skyline.be`                              |
| Online collaboration link    | `www.skyline.be/meeting.exe`                  |

> [!NOTE]
> If a custom product name is specified, this will also replace the DataMiner tab name in the Logging app and the "(DataMiner)" root in the tree view pane of the Resources app.

### Default contact info

![Default contact info](~/user-guide/images/ContactInfo_Default.png)
