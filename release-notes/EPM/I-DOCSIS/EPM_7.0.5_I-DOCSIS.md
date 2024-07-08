---
uid: EPM_7.0.5_I-DOCSIS
---

# EPM 7.0.5 I-DOCSIS (preview)

> [!IMPORTANT]
> We are still working on this release. Release notes may still be added, modified, or moved to a later release. Check back soon for updates!

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### Add_New_CCAP_Pair script now only shows DMAs with back-end element for selection as CCAP element host [ID_40025]

When a single CCAP pair is added using the *Add_New_CCAP_Pair* script, only DMAs where back-end elements are running will now be shown as possible hosts for the CCAP element, since this is a requirement in the EPM I-DOCSIS architecture.

#### Generic DOCSIS CM Collector: Enhanced debug logging [ID_40137]

In the Generic DOCSIS CM Collector connector, logging of QAction 1700 will now also include the number of rows that are to be deleted.
