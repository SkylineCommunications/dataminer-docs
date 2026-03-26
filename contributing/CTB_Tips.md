---
uid: CTB_Tips
---

# Tips for writing documentation

To allow easier editing and ensure consistency with the rest of the documentation, keep the following things in mind when you write a new section in the documentation.

## Use numbered lists for procedures

When you add a procedure that consists of several steps, use a **numbered list**, and make sure each list item corresponds with one step in the procedure. This way the user will have a clear overview of the different steps.

If you want to add information related to a step that is not actually something the user needs to do (e.g., the result of a step), add this as an indented paragraph in the list.

For example:

1. Click *Add*.

   A pop-up window will open.

1. Fill in the boxes in the pop-up window.

> [!TIP]
> In your list, just use the prefix "1." for each item. The list will automatically be updated to the correct numbering when the documentation is generated. Creating lists this way allows you to add items in the list without having to manually alter the numbering for every item that follows them. See also the [Microsoft Docs Contributor Guide](https://learn.microsoft.com/en-us/contribute/markdown-reference#numbered-list).

## Only use numbered lists when needed

Only use numbered lists if the order of each list item is important. If you for instance want to enumerate several things, but their order does not matter, use a **bulleted list** (using the prefix "-" for each item).

## Avoid contractions

Avoid contractions (e.g., you're, they're, it's). In formal documentation, these are not usually used.

## Use italic type for UI text

Exact references to text in the UI are usually displayed in italic type. This can help to avoid confusion, as otherwise it may not always be clear which part of the text is a UI reference.

For example: "Below *Exclusions*, click *Add exclusion* and select either *Protocol* or the name of the app."

## Use double quotation marks except in titles

In accordance with the [Microsoft style guide](https://docs.microsoft.com/en-us/style-guide/punctuation/quotation-marks), double quotation marks are used in our documentation instead of single quotation marks.

However, there is one exception to this. Because DocFX cannot handle double quotation marks in titles, try to avoid quotation marks in them as much as possible or use single quotation marks if you cannot do without.

## Think twice about screenshots

Be careful when you use screenshots of the DataMiner Cube UI, as these can get outdated quickly. For this reason, do not use screenshots if this has no added value.

If you do add a screenshot, ideally there should be some indication of the version of the software displayed in the screenshot, so it is clear if the screenshot is outdated.

## Address the reader directly

Avoid writing about your reader as "the user", but instead use "you".

The only time when "the user" is appropriate is when whoever you are writing for will create or configure something for another user, and it is that other user you want to indicate.

**Examples:**

- *You can find more information on DataMiner Dojo.* (Instead of *The user can find more information on DataMiner Dojo.*)

- *When you add a text input component to a dashboard, the user of the dashboard will be able to select data.*
