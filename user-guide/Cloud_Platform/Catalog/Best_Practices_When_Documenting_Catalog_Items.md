---
uid: Best_Practices_When_Documenting_Catalog_Items
---

# Best practices when documenting Catalog items

On this page, you will find more information about writing documentation for your Catalog item. In order to have a consistent, clear and uniform Catalog, we recommend following the best practice.

> [!IMPORTANT]
> Basic principle to follow: The Catalog should contain the sales pitch / value proposition for your Catalog item! Technical or detailed documentation should reside on another location.

## Overview of the Catalog item structure

When creating items for the DataMiner Catalog, focus on showcasing the value of each solution in a concise and engaging way, while keeping the technical details to a minimum. Follow this structure to ensure clarity and consistency:

1. Overview
1. Key Features
1. Visuals
   1. Note: Visual representations are not considered a seperate section but should be blended in the text.
1. Optional: Use Cases
1. Optional: Prerequisites
1. Optional: Other Technical reference sections which potentially link to public docs.
1. Support: Include a support sentence, e.g., "For additional help, reach out to support at [techsupport@skyline.be](mailto:techsupport@skyline.be).

## Overview

**Purpose:** Summarize the value proposition of the item, explaining why customers should deploy it. Address the problem it solves and its primary benefits.

**Format:** 1 introductory paragraph with up to 3 supporting paragraphs, 3-4 sentences each.

**Do's**

- Begin with a concise **introductory paragraph** focused on the solution’s value.
- Add **up to 3 additional paragraphs** elaborating on features or key use cases.
- Keep the tone **professional**, focused on **motivating** user adoption.
- Highlight important points with **bold text**.
- **Organize content** from broad benefits to specific features and practical applications.
- Use **accessible language** for both technical and non-technical readers.
- Make use of visual **[Alerts](xref:CTB_Markdown_Syntax#alerts)** where applicable.

**Don'ts**

- Avoid **excessive technical detail**; link to reference documentation instead.
- Refrain from jargon or **overly complex language** that could obscure the message.

## Visuals

**Purpose:** Enhance the text by showcasing a key feature or advantage with visuals. This is not an individual section, but should be part inline your Overview, Key Feature and Use Cases.

**Format:** Supported formats (e.g., PNG, GIF, SVG) should be added to the ‘Images’ folder within the `manifest.zip` file.

**Do's**

- Include **up to 3 visuals** to support key points.
- Ensure visuals are **clear, focused, and free from irrelevant elements**.
  - When showing a table, make sure to hide irrelevant columns.
  - Only show items that contribute and part of the Catalog item.
- Maintain **high quality** resolution.
- Keep GIFs **concise** (around 10 seconds) and **focused** on demonstrating a specific feature or action.
- When creating GIFs, make sure to take sufficient **time between each click** or visual change so that the changes do not disturb the user too much.

**Don'ts**

- Only show DataMiner card **tabs** if necessary for understanding a feature.
- Avoid blurry or pixelated visuals — **quality is key**.
- Avoid **unnecessary open panels**, collapsing elements like the Alarm Console when they don’t add value.
- Avoid **unnecessary blank space** by resizing your screen when taking a screen capture.
- Make sure to not show any **confidential data** by pixelating or blurring the data. Keep data that is not sensitive to still have a good representation.

## Key Features

**Purpose:** **Product-centric**. Outline the main features that distinguish the item, focusing on functionality and unique benefits.

**Format:** Maximum of 5 features, quality over quantity.

**Do's**

- Use direct, **benefit-oriented** language.
- Ensure each feature relates to **customer value**.
- Use **action verbs** (e.g., "Monitor," "Track").
- Prioritize features that **differentiate** your solution.

**Don'ts**

- Avoid **excessive detail** or vague descriptors like "high-performance" without specific context.
- Avoid adding key feature that **do not specifically relate to your solution**, but is general to DataMiner (e.g. The benefits of having alarms on your equipment which is exposed by a key feature of DataMiner, i.e. alarm templates.).

## Use Cases

> [!NOTE]
> Depending on the size and complexity of your Catalog item, you can decide to blend (or exclude) some sections related to Overview, Key Features and Use Cases.

**Purpose:** **Customer-centric**. Demonstrate practical, real-world scenarios where the solution provides value.

**Format:** Provide a link to a [DOJO Use Case](https://community.dataminer.services/use-cases/) or include 2-3 bullet points.

**Do's**

- Connect examples to common **customer challenges** (e.g., remote connectivity, high data usage).
- Use **specific, relatable examples**, such as “Monitor remote satellite terminals in real-time.”

**Don'ts**

- Avoid **hypothetical scenarios**; ensure examples are relevant to the typical user base, showing the value ot this solution.
- Do not **duplicate** points covered in the **Key Features** section.

## Prerequisites

**Purpose:** List essential technical requirements needed for deployment.

**Format:** 1-3 concise bullet points, limited to necessary information.

**applicable requirements**:

To most of the items below, you can evaluate if there is a maximum and/or minimum version.

- DataMiner version
- DxM version
- Licenses (e.g. DOM, SRM)
- Web version
- DataMiner Cube version
- Soft-Launch Flags
- Requirements from components included in the package

**Do's**

- Clearly list **essential requirements** (e.g., software versions, API access).
- Be direct and **specific** about version numbers, required permissions, or additional licenses needed for the solution to work.
  - If there is a specific DataMiner version dependency, make sure to include **both main and feature release**. If the cumulative update of the Main Release is irrelevant, you can leave it away (e.g. DataMiner 10.2.5/10.3.0).

**Don'ts**

- Avoid **installation or configuration steps**; link to comprehensive documentation instead.
- Avoid listing every **small technical dependency** — focus only on the essentials.
- If the minimum version of the DataMiner version dependency of the Catalog Item is **below the current supported DataMiner version**, we should not bother including it.

## Technical Reference

**Purpose:** Direct users to detailed technical documentation, as the Catalog should focus on high-level information.

**Format:** Link to technical documentation using the designated URL field in the manifest. Next to this, you can also use the [Note alert](xref:CTB_Markdown_Syntax#alerts) with a link within your description.

**Do's**

- Use **consistent** naming conventions, e.g., ‘Installing…’, 'Working with…'.
- Use a **public Link** for additional technical resources (e.g. [docs.dataminer.services](https://docs.dataminer.services) for standard solution published by Skyline Communications).
- Use aka links to link to docs.dataminer.services. This way, if something changes to the structure of the documentation, the links can easily be updated.

**Don'ts**

- Don't include tricks or flows that shouldn't be followed by the user.
- Don't add **redundant information** that is available somewhere else.
- Avoid documenting features that are **frequently changing** and not too important to document (e.g. UI).
- Avoid listing every **small technical dependency** — focus only on the essentials.
