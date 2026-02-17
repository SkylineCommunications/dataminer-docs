---
uid: Encoding_and_decoding_of_character_sets_in_text_messages
---

# Encoding and decoding of character sets in text messages

### Encoding

When sending a text message, Mobile Gateway uses the following 7-bit encoding by default:

- GSM 03.38 7-bit default alphabet encoding

- GSM 03.38 7-bit extended character set (€\[\]\*^{}\|\~)

#### UCS-2 16-bit encoding

The moment Mobile Gateway finds a character that is not present in the GSM 7-bit table (e.g., the lowercase c with cedilla “ç”), it re-encodes the entire message using the UCS-2 16-bit encoding (which represents most Latin and Eastern characters). In that case, the maximum message length is reduced from 160 code units to 70 code units.

### Decoding

When receiving a text message, Mobile Gateway uses the following decodings:

- GSM 03.38 7-bit default alphabet with extended character set

- GSM 03.38 8-bit data decoding using the default alphabet

- UCS-2 16-bit decoding
