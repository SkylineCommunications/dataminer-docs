---
uid: Security_must_haves
---

# Security: Must-have requirements to validate new products

This page provides an overview of the security-related requirements that new products must meet before you can consider purchasing them and deploying them in your operation.

- **Limitation of deployments of products**: Where possible, the number of products deployed in an ICT environment must be limited to simplify the operation and to reduce both the attack surface and the efforts required for validation, updates, contracting, risk assessment, etc. Both the business and operational needs therefore have to be consolidated into a limited set of products and technologies as much as reasonably possible. Each new product that is introduced inevitably increases the attack surface and the cost of maintaining a secure operation.

- **Hardening procedures**: Deployed products must have well-documented steps relating how to harden their setup in order to minimize the attack surface.

- **Identity & Access Management (IAM)**: To enable Single-Sign-On (SSO) and centralized user and group authentication, each product introduced in the environment must support full integration with Active Directory, Azure Active Directory (Entra ID), as well other LDAP-compatible directories such as OpenLDAP. This must include support for SSPI and SAML, with the option of using multifactor authentication (MFA).

- **Roles-based access control and permissions (RBAC)**: This must be implemented for both users and groups defined in Active Directory or Azure Active Directory (Entra ID), in order to support the setup of Least Privilege Access profiles for users and to optimize the overall security posture, in line with Zero Trust best practices.

  - High granularity of permissions in the software for all individual features and capabilities, supporting the setup of Least Privilege Access profiles for users (e.g., adding elements, deleting elements, changing alarm thresholds, etc.) to maximize the security posture. Each individual software feature or capability should have an associated permission.

  - Ability to define which users have access to which underlying elements managed by the software (e.g., user A can access element X and Y in read/write mode, they can access element Z in read-only mode, and element Q is not visible or accessible for that user).

  - Ability to limit access for critical element controls to a limited set of users within the group of users that can access those elements in read/write mode (e.g., users A, B, and C can fully access, read, and control element X, but the reboot and reset function of element X can only be controlled by user A and not by users B and C).

- **Audit trailing**: Each product introduced in the environment must provide continuous real-time audit trailing, easily accessible via both an intuitive UI (supporting real-time updates, time-stamping, easy sorting, filtering, exporting, etc.) and an API (to pass to a SIEM solution), which provides detailed insights on all relevant activities in the product. This must in the very least include the following:

  - All user authentication and authorization activities, e.g., which user logged in, any failed log-in attempts, from which client machine, etc.

  - All changes in the configuration and setup of the product performed by users, e.g., which items were added, updated, or deleted by users, etc.

  - All resources/functions/modules in the product accessed by a user.

  - All actions performed by a user while using the product, e.g., which workflows were triggered by a user, step-by-step details of the execution of workflows, etc.

  - All interactions of the product with other third-party products and systems, e.g., which settings were performed on third-party products and systems, what was the outcome of that interaction, etc.

- **APIs**: All APIs must comply with the following requirements:

  - **Secured by API key or token-based authorization** based on strong authentication methods such as OAuth 2.0 or JSON Web Tokens (JWT), with support for token rotation.

  - **Methods are provided for all features, capabilities, and functionality** of the product offered, so that all actions and data available through the product UIs can be integrated into automation procedures.

  - **Rate limiting**: All APIs must be protected with rate limiting to prevent abuse or mitigate the impact of it.

  - **API customization and personalization**: For each consumer of an API, it must be possible to have separate tokens and to provide that consumer with everything needed while also explicitly excluding anything that is not needed. In other words, the API methods can be tailored to the exact needs of each individual consumer.

  - **Audit trailing**: Detailed audit trailing must be available for any and all interactions with the APIs.

- **Independent security audit**: The vendor must submit a full security audit report performed by an independent third-party security audit specialist, which must include comprehensive penetration testing of both the offered products and the general ICT infrastructure of the vendor itself.

- **Third-party components and libraries**: The vendor must submit a full list of all third-party components and libraries used in its products.

- **Interaction with third-party products**: For interactions with third-party products (e.g., in case of monitoring and control software products), the proposed solution must include the following:

  - Support for the most secure interface method available on the third-party product (e.g., SNMPv3, HTTPS, etc.).

  - Secure credentials vault: To interface with third-party products, credentials are often required in order to authenticate. These credentials must be saved in a secure dedicated vault that needs to be part of the offered product or at least be professionally encrypted when stored.
