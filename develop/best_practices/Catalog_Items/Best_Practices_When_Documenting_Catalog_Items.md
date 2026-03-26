---
uid: Best_Practices_When_Documenting_Catalog_Items
keywords: documentation, catalog item, description, connector help, solution help
---

# Best practices when documenting Catalog items

On this page, you will find more information about writing documentation for your Catalog item. In order to have consistent, clear, and uniform documentation in the Catalog, we recommend following these best practices.

The main principle to keep in mind is that the documentation in the Catalog should be **attractive and clearly present the value** of the Catalog item.

As the documentation shown in the Catalog should be concise and not include a lot of technical details, you can add a link (see *documentation_url* in the [Manifest file](xref:Register_Catalog_Item#manifest-file)) to direct users to more detailed documentation. For substantial solutions developed by Skyline, this technical documentation is typically located under [DataMiner Solutions](xref:solution_index). For smaller items, this could be a link to markdown pages in the public source code repository. If the source code is open source, you can also provide a link using the *source_code_url* field in the [Manifest file](xref:Register_Catalog_Item#manifest-file).

> [!NOTE]
> For more details regarding connector documentation, please refer to [our connector documentation guidelines](xref:Connector_help_pages).

## Catalog item documentation structure

When you create documentation for an item in the Catalog, focus on showcasing the value of the item in a concise and engaging way, while keeping the technical details to a minimum. Use this structure to ensure clarity and consistency, and make sure to [include visuals](#visuals) in your text:

1. [About](#about-section)

1. [Key Features](#key-features-section)

1. [Use Cases](#use-cases-section) *(optional)*

1. [Prerequisites](#prerequisites-section) *(optional)*

1. [Technical Reference](#technical-reference-section) *(optional)*

   Link to public documentation for more extensive info when necessary.

> [!NOTE]
> Depending on the size and complexity of your Catalog item, you can combine or exclude some sections. For example, for a very simple item you could leave out the Use Cases section but mention this information under Key Features.

## Visuals

**Purpose:** Enhance the *Overview*, *Key Features*, and *Use Cases* sections where appropriate by showcasing key features or advantages with visuals.

**Format:** Add the images to the *Images* folder within the `manifest.zip` file. For a list of the supported image formats, see [Registering a Catalog item](xref:Register_Catalog_Item#body).

**Do's:**

- Include **up to 3 visuals** to support key points.
- Ensure visuals are **clear, focused, and free from irrelevant elements**.
  - When showing a table, make sure to hide irrelevant columns.
  - Only show items that are relevant for and clearly show the Catalog item.
- Use **high-quality** resolution.
- Keep GIFs **concise** (at most 10 seconds) and **focused** on demonstrating a specific feature or action.
- When creating GIFs, make sure to take sufficient **time between each click** or visual change so that the changes do not disturb the user too much.

**Don'ts:**

- Only show DataMiner **card tabs** if necessary to help understand a feature.
- Avoid blurry or pixelated visuals — **quality is key**.
- Avoid **unnecessary open panels**. Collapse panels like the Alarm Console if these do not add value.
- Avoid **unnecessary blank space** by resizing the window when taking a screen capture.
- Make sure not to show any **confidential data**. Blur any sensitive data, but keep the data that is not sensitive visible to still have a useful image.

## About section

**Purpose:** Summarize what makes the item valuable and why users should deploy it. Address the problems it solves and its primary benefits.

**Format:** A relatively short piece of text that is easy to read and understand.

**Do's:**

- Limit the content to the **essentials**, and keep it short and well organized. When required for clarity, you can optionally divide the text over a few paragraphs.
- Keep the tone **professional**, focused on **motivating** user adoption.
- Highlight important points with **bold text**.
- **Organize content** from broad benefits to specific features and practical applications.
- Use **accessible language** for both technical and non-technical readers.
- Make use of visual **[alerts](xref:CTB_Markdown_Syntax#alerts)** where applicable.

**Don'ts:**

- Avoid **excessive technical details**; link to reference documentation instead.
- Avoid jargon or **overly complex language** that could obscure the message.
- Avoid **excessive** amounts of **bold text and/or alerts**, as these then lose their purpose of drawing the reader's attention.
- Do not refer to **generic DataMiner benefits** such as alarming and trending. Instead focus on the value this specific item brings.
- Do not **duplicate** points mentioned in the **Key Features** and **Use Cases** sections.

## Key Features section

**Purpose:** **Product-centric**. Outline the main features that distinguish the item, focusing on functionality and unique benefits.

**Format:** Maximum of 5 features. Focus on those features that are most relevant for the user: quality over quantity.

**Do's:**

- Use direct, **benefit-oriented** language.
- Ensure that each feature relates to **specific value** for the user.
- Use **action verbs** (such as "Monitor", "Track", etc.).
- Prioritize features that **differentiate** the item.

**Don'ts:**

- Avoid **excessive detail** or vague descriptors like "high-performance" without specific context.
- Avoid adding key features that **do not specifically relate to the item**, but that are general to DataMiner (for example, the benefits of having alarms for your equipment, which is already a key feature of DataMiner itself).

## Use Cases section

**Purpose:** **User-centric**. Demonstrate practical, real-world scenarios where the solution provides value.

**Format:** Typically, the package is designed to solve specific problems for users. Explain this clearly with accompanying visuals. Optionally, provide a link to a [use case on DataMiner Dojo](https://community.dataminer.services/use-cases/).

**Do's:**

- Connect examples to **common challenges** that users face (e.g., remote connectivity, high data usage).
- Use **specific, relatable examples**, such as "Monitor remote satellite terminals in real-time".

**Don'ts:**

- Avoid **hypothetical scenarios**. Make sure the examples are relevant to the typical user base, showing the value of the item.
- Do not **duplicate** points covered in the **Key Features** section.

## Prerequisites section

**Purpose:** List essential technical requirements needed for deployment.

**Format:** Use concise bullet points, limited to information that is strictly necessary.

**Applicable requirements**: Mention the following requirements if they apply for the package:

- **Minimum/Maximum DataMiner version**:
  - Only mention the minimum DataMiner version if it is a [**currently supported** DataMiner version](xref:Software_support_life_cycles).
  - Mention **both the Feature Release and Main Release version**. As users can be on the Main Release or on the Feature Release track, only adding one of these will be a problem for users who are on the other track.
  - If the DataMiner **Web** version or **Cube** version requirement is different from the server version, mention this separately.
- **Minimum/Maximum DxM version**
- **Licenses** (for example, DOM, SRM)
- **Soft-launch options**
- Requirements for components included in the package

**Do's:**

- Clearly list **essential requirements** (for example, software versions, API access).
- Be direct and **specific** about version numbers, required permissions, or additional licenses needed for the item to work.

**Don'ts:**

- Avoid **installation or configuration steps**. Link to comprehensive documentation instead.
- Avoid listing every **small technical dependency**. Focus only on the essentials.

## Technical Reference section

**Purpose:** Provide links to detailed technical documentation, as the Catalog should focus on high-level information only.

**Format:** Link to technical documentation using the designated URL field in the manifest. If relevant, use a ["Note" alert](xref:CTB_Markdown_Syntax#alerts) with a link in your description.

**Do's:**

- Use **consistent** naming conventions, such as "Installing ...", "Working with ...".
- Use a **public link** for additional technical resources (e.g., [docs.dataminer.services](https://docs.dataminer.services) for standard solutions published by Skyline Communications).
- If you link to docs.dataminer.services as a Skyline employee, use "aka" redirect links. This way, if something changes to the structure of the documentation, the links can easily be updated.

**Don'ts:**

- Do not include procedures that should not be followed by the user.
- Do not add **redundant information** that is already available somewhere else. If relevant, link to that information instead.
- Avoid documenting features that **change frequently** and are not that important to document (e.g., UI).
- Avoid listing every **small technical dependency**. Focus only on the essentials.
