---
uid: Facilities_Page
description: Go to the Sites and Facilities page of the Facility Manager app to create, edit, and delete sites, facilities, floors, and rooms.
---

# Sites & Facilities

The Sites & Facilities page of the Facility Manager app allows you to create, edit, and delete sites and facilities. It displays an overview of the configured sites and facilities on a map, based on defined geographic coordinates (latitude and longitude).

This page is where you will typically begin your configuration by first [adding sites](#adding-a-new-site) and then [adding facilities](#adding-a-new-facility). You can then continue by adding floors and rooms on the [Floors & Rooms page](xref:Rooms_Page).

![Sites & Facilities page](~/solutions/images/Facility_Manager_Facilities_Page.png)

> [!NOTE]
> To take full advantage of the map component, you will need to configure a valid Google Maps API key on the *About* page of the app.

## Adding a new site

1. In the header bar of the Sites & Facilities page, click *New Site*.

1. Specify the name and ID of the site.

1. Click *Save*.

1. In the *Sites* table, click the details button (ⓘ) for the site.

   This will open the *Site details* pane.

1. Click the pencil icon in the section you want to edit, and configure the metadata you want.

   You can configure the site's description, latitude, longitude, country, city, address, and zip code.

1. When the site is fully configured, click the *Activate* button.

   As long as this button has not been clicked, the site is considered a draft. After it has been clicked, you can remove the site again by clicking the *Deprecate* button.

## Adding a new facility

1. In the header bar of the Sites & Facilities page, click *New Facility*.

1. Specify the following information:

   - The name of the facility.
   - The facility type: *Building*, *Container*, or *Truck*.
   - The ID of the facility.

1. Click *Save*.

1. In the *Facilities* table, click the details button (ⓘ) for the facility.

   This will open the *Facility details* pane.

1. Click the pencil icon in the section you want to edit, and configure the metadata you want.

   You can configure the facility's site, description, latitude, longitude, country, city, address, and zip code.

1. When the facility is fully configured, click the *Activate* button.

   As long as this button has not been clicked, the facility is considered a draft. After it has been clicked, you can remove the facility again by clicking the *Deprecate* button.
