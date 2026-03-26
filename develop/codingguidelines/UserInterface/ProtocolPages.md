---
uid: ConnectorBestPracticesProtocolPages
---

# Protocol pages

## Layout

By default, a maximum of two columns is allowed on a page.

## Look and feel

Vendors typically organize their devices into different product lines or series. The same look and feel must be provided for all protocols for devices belonging to the same product line.

## General page

Each protocol must have a page with the name "General", containing some general parameters (e.g., the device name, the device type, the firmware version, etc.), which must be used as the default page.

## Core functionality pages

A protocol is typically developed for a specific device (e.g., demodulator, integrated receiver/decoder (IRD), etc.). A protocol must reflect the functionality of the device by including a page for each functional block of the device. For example, a protocol for an integrated receiver/decoder should include a page for the receiver and a page for the decoder.

These pages must contain the core parameters of the device, which should be a combination of status parameters and important configuration parameters. The order of these parameters should reflect the internal workflow of the device (e.g., in case of a decoder, first configure the frequency, then the modulation, etc.).

## Web interface page

In case the device has a web user interface, this must be added to the protocol as an embedded object on its own page, so that it can be viewed through the element card. The web interface page must be the last page and it must be preceded by a page separator. The name of this page should be "Web Interface".

> [!TIP]
> See also: [Including web interfaces](xref:Protocol.Display-pageOrder#including-web-interfaces)