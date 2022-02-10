---
uid: EmBER
---

# EmBER

EmBER stands for Embedded Basic Encoding Rules and is a subset of BER, an encoding standard.

It provides encoding rules for common data types like integer, strings, etc. and for sequence and set container types.

EmBER uses a TLV (Type, Length and Value) system to specify what kind of data is currently present in the encoded data buffer.

An encoded value always contains two tags, the outer or application tag, which defines the meaning or semantics of the data, and the inner tag, which indicates the type of the encoded object.

For types with primitive encoding (Boolean, Integer, Octet String, Real, UTF8String, Relative Object Identifier), the tagging environment is explicit. For types with constructed encoding (Sequence and Set), implicit tagging is often used for the inner tag. Besides the tag, the length of the encoded data is stored.

Therefore, every object being encoded contains an outer Tag, an outer Length, an inner Tag, an inner Length and a Value (in short TLTLV).

Ember supports the following BER types: Boolean, Integer, Real, UTF8String, Octet String, Null, Set, Sequence, Relative Object Identifier.
