---
metadata_version: 1
uid: XmlAutomationNegative
description: "A deterministic negative Automation XML fixture used to test explicit acceptance of schema-invalid examples."
area: develop
content_type: example
authority: illustrative
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: not_applicable
review_date: not_applicable
compatibility:
  uid: stable
  url: stable
---

# Negative Automation fixture

```xml complete negative
<?xml version="1.0" encoding="utf-8"?>
<DMSScript xmlns="urn:fixture:automation" options="not-a-number">
  <Name>Invalid fixture</Name>
</DMSScript>
```
