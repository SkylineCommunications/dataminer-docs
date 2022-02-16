---
uid: Configuring_text_wrapping_and_trimming
---

# Configuring a shape's text wrapping and trimming

If a shape is linked to an object, you can configure the wrapping and trimming of the text displayed in the shape. This feature is available from DataMiner 10.3.0/10.2.3 onwards.

To configure this, add a shape data field of type **TextStyle**, and set its value to “TextWrapping=...” and/or “TextTrimming=...”. If you specify both options, separate them with a pipe character (“\|”).

For example:

| Shape data field | Value |
|-----------------|-------|
|TextStyle         | TextWrapping=Wrap\|TextTrimming=WordEllipsis

**TextWrapping** determines if and how the text is wrapped. It can be set to the following values:

- **NoWrap**: The text will not wrap onto a new line, unless one was explicitly configured with a line break. Text that exceeds the bounds of the shape width or height will not be shown.

- **Wrap**: The text will automatically wrap onto a new line when the width of the shape is exceeded. The text past the boundaries of the shape height will not be shown.

- **WrapWithOverflow**: The text will automatically wrap onto a new line when the width of the shape is exceeded. The text can be shown past the boundaries of the shape height. (Default behavior.)

**TextTrimming** determines what happens when the text does not fit in the shape and has to be cut off. It can be set to the following values:

- **CharacterEllipsis**: The text will be cut off at the point where it no longer fits, and “...” will be added to indicate that there is more text than fits in the shape.

- **WordEllipsis**: The text will be cut off at the nearest full word when it no longer fits, and “...” will be added to indicate that there is more text than fits in the shape.

- **None**: The text will be cut off when it does not fit, but no “...” will be displayed. (Default behavior.)

> [!NOTE]
> When TextWrapping is set to its default value (i.e. “WrapWithOverflow”), the text will always be fully displayed, so setting TextTrimming to “CharacterEllipsis” or “WordEllipsis” will have no effect.
