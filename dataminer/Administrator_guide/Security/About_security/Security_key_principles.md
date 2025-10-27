---
uid: Security_key_principles
---

# Security: General key principles and best practices

## Attack Surface Reduction

**Attack Surface Reduction (ASR)** encompasses a set of practices aimed at minimizing the potential vulnerabilities and attack points within a private IT ecosystem, including compute, networking, and software applications. A larger attack surface increases the opportunities for malicious actors to gain unauthorized access. An attacker only needs a single weak link that they can pivot from to elevate privileges and compromise high-profile targets. This means that the introduction of a single product that is inferior from a security perspective can compromise the entire infrastructure.

You can reduce your attack surface by reducing the complexity of the deployments within your infrastructure. This can be achieved by limiting the deployment of different products from different vendors as much as reasonably possible, and by **consolidating business and operational needs into a single product as much as possible**, as opposed to deploying a multitude of different products from different vendors to address those needs.

In addition to this, it is important to keep the attack surface of the deployed products in mind as well. Ideally, when deciding on which products to deploy, your preference should go towards products that have a well-documented and regularly updated guide on how to harden and reduce the attack surface of the deployed product.

## Zero Trust Architecture

**Zero Trust Architecture (ZTA)** is another common practice applied today. It stipulates that no entity, whether inside or outside the organization’s private infrastructure, can be trusted by default. The principle is often referred to as "never trust, always verify". While in the past, gaining access to the private infrastructure often meant that you enjoyed a certain level of trust and freedom to move laterally throughout that infrastructure, Zero Trust now emphasizes more strict access controls and continuous verification of all users and devices, regardless of their location and prior authentication.

## User Authentication

Everything starts with solid authentication of the users in your operational environment. In the past, many products relied on built-in standalone solutions for this, but in today’s world it is an absolute must to rely on professional solutions. It should therefore be mandatory for all deployed products to be integrated with a centralized professional directory service and identity management system (e.g. Microsoft Active Directory). Any product with standalone security, not integrated with a centralized professional solution, should be avoided at all cost.

## Least Privilege Access

The principle of **Least Privilege Access (LPA)** is now also an absolute must. This principle and practice involves granting users or systems the minimum level of access and permissions necessary to perform their required tasks, limiting the potential damage that can be caused by compromised accounts or systems.

Whereas identity verification and associated capabilities like MFA and DAC can be easily be achieved by ensuring that all deployed products are fully integrated with common industry-standard directory services products, such as Active Directory or Azure Active Directory (Entra ID), LPA requires a more detailed set of specific requirements for products to comply with. The most important one is the granularity and quality of its **Access Control (AC)** capabilities.

## Role-Based Access Control

**Role-Based Access Control (RBAC)** is a very popular method to manage access to systems by assigning rights to roles or groups rather than individual users. In light of LPA, it is essential to make sure that a sufficiently fine-grained set of permissions is available on any of your deployed products to model all required roles for your organization. LPA demands that for each role, those users will be able to perform the exact activities that they need, but no more than that. Therefore, for example, solutions accommodating only a limited fixed choice of pre-defined roles (e.g. user, view-only, and admin) should no longer be accepted or deployed.

## Secure APIs

Another vital consideration within the context of LPA involves the use of APIs. In a highly interconnected world with an ever-growing need for more sophisticated automation, products should only be considered if they come with a full-fledged API that offers a broad range of methods, supporting interaction with all features, capabilities, and functions of that product. However, while in the past APIs provided all their methods unconditionally to authorized users, this is no longer acceptable in an LPA context. It is now an absolute must for products to provide the means to only expose the exact functionality that API consumers require, and nothing more than that.

In a Zero Trust environment with a strong focus on security, authentication for access to APIs must also be based on tokens or API keys, rather than user accounts. Token-based authentication does not rely on server-side sessions or user accounts, so that it is more scalable and easier to manage in large-scale ecosystems. Furthermore, you can make tokens revocable and expirable, which is more challenging with classic user accounts. Above all, tokens reduce the attack surface by eliminating the need to deal with passwords and potential vulnerabilities tied to account management. Tokens can leverage strong authentication methods that have been proven to work, such as OAuth 2.0 or JSON Web Tokens (JWT), and that support token rotation.

## Data encryption

**Data in Transit Encryption (DITE)** and **Data at Rest Encryption (DARE)** define that all data should be subject to strong encryption, both in transit (i.e. while being transmitted or transferred over a network) to protect against eavesdropping and interception, and at rest (i.e. when stored on physical or digital storage devices such as hard drives, databases, files, or cloud storage) to protect against unauthorized access in case the storage media is breached, lost, or stolen. As each product is likely to store and transmit data, this results in very specific requirements for all individual products deployed.

## SecOps

Considering the significant importance of security, many organizations now run a continuous **Security Operations Center (SOC)**, leveraging specialized **Security Information and Event Management (SIEM)** software tools. Security Information Management (SIM) is responsible for collecting, aggregating, and analyzing log data and other information from various sources within the organization’s private infrastructure. Security Event Management (SEM) focuses on real-time monitoring and analysis of security events and incidents, by correlating data from various sources to identify potential security threats or anomalies. SIEM platforms typically provide functions for real-time monitoring, log management, thread detection, incident response, compliance reporting, and forensic analysis. SIEM has become a critical component within many organizations’ cybersecurity strategy. It is therefore very important that all deployed products can provide relevant data to the SIEM platform. This includes both log files about their internal functioning and a very detailed audit trail for all relevant activities within the context of each product (e.g. users logging in, changes in settings or configuration, etc.).

## Supply Chain Level Attack

**Supply Chain Level Attack (SCLA)** is another area that represents a growing threat and hence increasingly requires attention. SCLA occurs when a threat actor infiltrates and compromises a supplier, manufacturer, or service provider, with the objective to gain access to the systems or data of a target organization further down the supply chain. Whereas there are limitations for organizations to address this from a technological perspective, the risks must be mitigated through rigorous Supply Chain Level of Assurance (SLOA) and Third-Party Assurance (TPA). These are used to assess and provide confidence in the security and integrity of suppliers and third-party partners in the supply chain.

> The most notable supply chain attack in recent years was the [2020 incident where hackers managed to insert malicious code into the SolarWinds Orion software](https://www.simplilearn.com/tutorials/cryptography-tutorial/all-about-solarwinds-attack#:~:text=More%20than%2018%2C000%20customers%20of,were%20affected%20by%20this%20attack.). This had a very wide-reaching impact, affecting a substantial number of organizations and systems, including very high-profile government agencies, private companies, and critical infrastructure providers. Another example is the well-documented [TV5 Monde cyber incident in June 2015](https://www.bbc.com/news/technology-37590375), which resulted in a complete shutdown of TV5 Monde’s broadcast for several hours. This also involved a supply chain attack as one of its elements.

Assurance involves evaluating and verifying the level of professionalism and maturity in the field of software development and security practices, policies, track record, and more of the vendors that you consider purchasing products from. While you can do this in many ways (e.g. verifying presence of dedicated security professionals, secure coding practices, incident response plans, etc.), one of the most efficient methods is to rely on third-party security experts to perform a comprehensive hands-on security audit and penetration testing of the supplier. The outcome of such an audit is much more valuable than any administrative audit and compliance. The audit has two important perspectives, namely the quality of the product itself with respect to security, and the overall security posture of the organization and its infrastructure (i.e. what is the risk the private infrastructure of that organization being breached).
