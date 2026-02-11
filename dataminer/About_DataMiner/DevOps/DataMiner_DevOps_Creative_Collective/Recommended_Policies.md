---
uid: Recommended_Policies
description: Recommended policies of the DevOps Creative Collective include open-source mindset, minimum dependencies, proper documentation, and demo capabilities.
---

# Recommended policies

- **Open-Source Mindset**: DataMiner Solutions are managed by the PO with an Open-Source mindset, sharing the complete solution with the broader community, wherever possible and permitted. The PO welcomes input and contributions to the solution by anybody in the community.

- **Fork or contribute**: By default, unless explicitly stated otherwise by the PO of a solution, users can utilize DataMiner Solutions as is, and should they wish to modify or further evolve it, they have two options:

  - Users can choose to permanently fork the solution, making it their own. However, in this case, they will not be able to benefit from future updates to the original DataMiner solution.

  - Users can collaborate with the PO and submit contributions for an iteration on the original DataMiner solution. In this scenario, they can benefit from future updates made by others to that DataMiner solution.

- **Minimum dependencies**: DataMiner Solutions are always designed with minimum dependencies, encompassing all required components that could be relevant. For instance, if a no-code app was designed for a specific product integrated in DataMiner, the package will also include the connector for that product, precisely matching the version used for developing the no-code app. Any solution, to the extent possible, will also include automated checks for any prerequisites before full installation and deployment on a target DataMiner System. This could include verifying the minimum DataMiner core version and the availability of specific optional core licenses required, among others.

- **Individual components**: All components that are part of a DataMiner Solution, which are potentially relevant by themselves (such as a GQI custom operator or an ad-hoc data source), should be published separately, in addition to being included in the solution package. This ensures the maximization of their value, allowing for the potential use of those components in a different context.

- **Registration & documentation**:  All solutions should be added to the Catalog with the proper required information (such as name, description, type, status, version, etc.).

- **Documentation - quality & security – scale – distributed architecture**: All solutions should adhere to commonly accepted quality and security-related standards and norms, should consider scaling for larger deployments and the expectation to run on a DataMiner distributed multi-node architecture, and should be accompanied by proper documentation (including user documentation, developer documentation, dependencies, known limitations, and scale considerations).

- **Demonstration & simulation capabilities**: As solutions could have dependencies on the underlying architecture and the availability of specific live data sources, if feasible, solutions should incorporate built-in demo and simulation capabilities. This can be achieved through simulated elements, mockup ad hoc data sources, or publicly available ad hoc data sources, facilitating the evaluation and adoption by users.
