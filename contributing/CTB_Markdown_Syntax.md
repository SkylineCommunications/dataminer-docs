---
uid: CTB_Markdown_Syntax
---

# Markdown syntax

Markdown is a lightweight markup language with plain text formatting syntax. It exists in different "flavors". We make use of DocFX Flavored Markdown (DFM). The easiest way to learn how to work with this is to look at our existing documentation and imitate what you see. You can also find more information about DFM basics below.

For more detailed info about DFM syntax, see [Docs Markdown reference](https://docs.microsoft.com/en-us/contribute/markdown-reference).

## Paragraphs

Each paragraph should be separated from the next paragraph by an empty line. If you do not add this empty line, the paragraphs will be combined into one. For example, the markdown below will be generated as one single paragraph:

```md
My text.
My additional text.
```

This will look like this:

`My text. My additional text.`

To separate these lines into individual paragraphs, an empty line is needed:

```md
My text.

My additional text.
```

> [!NOTE]
> Every page should also end in an empty line.

## Italics and bold

To display text in bold, add two asterisks before and after the text.

For example:

```md
This is an example of **bold** text.
```

To display text in italics, add an asterisk before and after the text.

For example:

```md
This is an example of *italics*.
```

> [!NOTE]
> If you use underscores instead of asterisks to display text in italics, this will also be displayed correctly in our documentation. However, for the sake of consistency, this is not recommended.

## Lists

DFM supports both bulleted and numbered lists. Use numbered lists if the order of the list items is important, for example in a procedure where each list item represents a step of the procedure. Otherwise, use bulleted lists.

To create a bulleted list, add a hyphen at the start of each list item. For example:

```md
- A list item
- Another list item
```

To create a numbered list, add "1. " at the start of each list item. For example:

```md
1. First list item
1. Second list item
```

When the documentation is generated, the numbering will automatically be adjusted to a correctly numbered list.

While it is possible to use "1. ", "2. ", "3. ", etc., we do not recommend this, as it can lead to a lot of needless editing if something is added or removed in an existing numbered list.

> [!NOTE]
> Unlike for regular paragraphs, it is not necessary to leave an empty line between the different items of the same list (although you can do so if you prefer this). However, there must always be an empty line before and after a list.

## Indents

To create an indented paragraph, add spaces before the paragraph. If you want to use indented paragraphs with bulleted or numbered lists, make sure the number of spaces matches the number of characters in front of the list text, so that the text is aligned correctly. For example:

```md
1. First list item

   Indented text in between the list items.

1. Second list item
```

If you use an inconsistent number of spaces, the indentation may not be displayed correctly.

It is also possible to add indented lists and to add indented paragraphs in between those. Just make sure the spacing is always consistent. For example:

```md
1. First main list item

   Indented text in between the list items, introducing another list:

   1. First list item
   1. Second list item

      Indented text in between the list items

   1. Third list item

1. Second main list item
```

## Headings

Headings are indicated with a hash symbol. Add one hash symbol in front of the title at the top of each page. For subsequent headings, use a number of hash symbols corresponding with the header level.

For example:

```md
# Page title: heading level 1

## First sublevel: heading level 2

### Second sublevel: heading level 3

#### Third sublevel: heading level 4.

##### Fourth sublevel: heading level 5.

Paragraph text.
```

Do not skip heading levels. For example, do not use heading level 3 right after heading level 1 while there is no heading level 2 in between.

You can use up to five heading levels on a single page. If you need more levels, you will need to divide your content over several pages.

Headings should always be surrounded by empty lines, so make sure there is an empty line above and below each heading, like in the example above.

## Tables

To create a table, use pipe characters to show the column edges. Each table should have a header row, which is followed by a row where dashes fill in the space between the pipe characters. For example:

```md
| Column name | Another Column name |
|-------------|---------------------|
| Column text | More column text    |
| Column text | More column text   |
```

You can align the pipe characters so that the table also looks like a table in the Markdown source, but this is not necessary. If you specify the table above as follows, it will look exactly the same in the published version of the documentation:

```md
| Column name | Another Column name |
|--|--|
| Column text | More column text |
| Column text | More column text |
```

If table cells contain a lot of text, it can be next to impossible to keep everything neatly aligned in the Markdown source, so in that case this second syntax may be preferable. Just make sure you use the correct number of pipe characters so that your number of columns is the same in each row, otherwise the table will not be generated correctly.

Also note that you can align table columns by using colons. See the following example:

```md
| Fun                  | With                 | Tables          |
| :------------------- | -------------------: |:---------------:|
| left-aligned column  | right-aligned column | centered column |
| $100                 | $100                 | $100            |
| $10                  | $10                  | $10             |
| $1                   | $1                   | $1              |
```

## Code blocks

To display code examples in separate code blocks, place three backquotes (```) above and below those blocks. In addition, next to the three backquotes above the blocks, specify the type of code, e.g. *csharp*, *md*, *xml*, etc.

To display inline code within a paragraph, add a backquote before and after the code.

## Links and cross-references

To add a link, place the link text that should be displayed in square brackets, followed by the link itself in parentheses. For example:

```md
For more detailed info about DFM syntax, see [Docs Markdown reference](https://docs.microsoft.com/en-us/contribute/markdown-reference).
```

To add a cross-reference, i.e. a link to another page in the documentation, use the same format, but specify the link in the format "xref:uid". For example:

```md
See [Basic concepts](xref:BasicConcepts).
```

To find this UID, open the page you want to link to in the repository. Each page has a UID specified at the top. For example, for the current page, this looks like this:

```md
---
uid: contributing
---
```

To add a cross-reference to a header on the same page as the cross-reference itself, do not specify "xref:", but instead add a hash followed by the header text, lowercase without special characters and with hyphens instead of spaces. For example:

```md
If you are unfamiliar with this syntax, refer to [Markdown syntax](#markdown-syntax).
```

To add a cross-reference to a specific header of a different page in the documentation, use the "xref:uid" syntax, followed by a hash and the header text, specified in the same way as for a link on the same page. For example:

```md
See [System components](xref:BasicConcepts#system-components).
```

## Images

To add an image, first place the image in the correct folder in the repository. For example, to add an image for the user guide section of the documentation, add the image in the folder "user-guide/images".

To then display the image in the text, use the following syntax:

```md
![Alt text](~/folder containing the images folder/images/ImageName.png)
```

For example:

```md
![Awards](~/dataminer-overview/images/awards.png)
```

> [!NOTE]
> To upload images, use GitHub Desktop. See [Getting started with your documentation tools](xref:CTB_Documentation_Tools).

> [!IMPORTANT]
> Make sure image names do not contain any spaces; otherwise, the images will not be shown correctly.

## Video

To embed a video, use the following syntax:

```md
> [!Video https://youtube.com/embed/hPi9kv8WKGU]
```

If you use the above-mentioned syntax, the video will always take the full page width. If you want the video to appear in a smaller box, then embed an `<iframe>` element like the one below:

```html
<iframe width="560" height="315" src="https://youtube.com/embed/hPi9kv8WKGU" style="border:none;"></iframe>
```

> [!IMPORTANT]
> If the video you want to embed is a Youtube video, then make sure the URL starts with `https://youtube.com/embed/`. Links like `https://youtu.be/hPi9kv8WKGU` will not work.

## Alerts

It is possible to display special "alert" blocks that focus the reader's attention on something important. The following types of alerts are supported:

```md
> [!NOTE]
> Information that should stand out from the rest of the text.

> [!TIP]
> Optional information that could be helpful. This is for example used for cross-references to sections with other information that may be relevant.

> [!IMPORTANT]
> Essential information that users must definitely keep in mind.

> [!CAUTION]
> Information about possible negative consequences of an action.

> [!WARNING]
> Information about dangerous consequences of an action.
```

These alerts are displayed as follows:

> [!NOTE]
> Information that should stand out from the rest of the text.

> [!TIP]
> Optional information that could be helpful. This is for example used for cross-references to sections with other information that may be relevant.

> [!IMPORTANT]
> Essential information that users must definitely keep in mind.

> [!CAUTION]
> Information about possible negative consequences of an action.

> [!WARNING]
> Information about dangerous consequences of an action.

## Reserved characters

Some characters, such as angle brackets and backslashes, are used as part of the Markdown syntax. If you want to just display these characters, this may not work. Add a backslash in front of such a character to make sure it is displayed correctly.

For example, to make sure `<script name>` is displayed correctly, specify `\<script name>` instead.

This is not necessary in text that is formatted as inline code or as a code block (using backquotes).
