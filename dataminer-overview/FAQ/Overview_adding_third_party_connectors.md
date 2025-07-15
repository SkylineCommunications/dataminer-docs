---
uid: Overview_adding_third_party_connectors
---

# How are third-party connectors added?

On request, anyone can add a connector to the [Catalog](xref:About_the_Catalog_app). See [Registering a Catalog item](xref:Register_Catalog_Item).

1. Complimentary (i.e. free) Skyline Communications service to add a connector to the Catalog:

   - The delivered connector is published "as is" in the Catalog.
   - Skyline does not resolve any CI/CD comments or checks that may arise during the flow execution.
   - Skyline visually identifies the owner as the third-party provider.
   - Optionally, the column on the right in the Catalog can display the following status info: "SLC Quality Gate Pass: NO".

1. Paid Skyline Communications service that verifies the Skyline CI/CD pipeline:

   - Paid service ensures successful passage through the Skyline Jenkins pipeline with all quality gates met.
   - Burn rate: [professional engineering service credits](xref:Professional_service_credits) per starting hour.
   - Goal: pass the CI/CD process without errors.
   - Visualization: Skyline visually identifies the owner as the third-party provider, and optionally, the column on the right in the Catalog can display the following status info: "SLC Quality Gate Pass: Yes".
   - Benefits:
     - The third-party customer has a verified connector available for download.
     - The third-party customer has access to Catalog benefits.

> [!IMPORTANT]
>
> - There is no direct cashback or revenue-sharing model for third-party connectors. However, Skyline Communications’ business partners indirectly benefit from downloads from the Catalog (see [Earning Credits](xref:About_Partner_Program#earning-credits)).
> - Third parties can request to publish a connector directly in the Catalog. However, opting for a paid Skyline Service offers the following benefits:
>
>   - Versioning enabled.
>   - Validation compiles on the latest DataMiner feature release.
>   - SonarQube code analysis.
>   - DIS Validator (publicly available on GitHub).
>   - Automatic checks for breaking changes between versions.
>   - Commercial benefits: For business and technology partners, DataMiner credits are provided in return for effective downloads per month.
