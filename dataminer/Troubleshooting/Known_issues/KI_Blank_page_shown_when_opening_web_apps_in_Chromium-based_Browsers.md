---
uid: KI_Blank_page_shown_when_opening_web_apps_in_Chromium-based_Browsers
---

# Blank page shown when opening web applications directly in Chromium-based browsers

## Affected versions

All DataMiner versions.

## Cause

Following an update to the Chromium engine, a regression was introduced that affects Angular applications that use their own service workers. When a page is opened directly via a deep link, the application may fail to load correctly, causing the browser to display a blank page.

This issue is not specific to DataMiner web applications and also affects other Angular-based applications running in Chromium-based browsers (such as Microsoft Edge and Google Chrome).

## Fix

This issue will automatically be fixed when the browser is updated to Chromium version M143 or higher.

## Workaround

Reload the page when a blank screen occurs, or open the direct link in a different browser.

## Description

When dashboards, low-code apps, or pages in the Catalog are opened directly via a link in a Chromium-based browser (such as Microsoft Edge or Google Chrome), the page may occasionally load as a blank screen instead of displaying the application.
