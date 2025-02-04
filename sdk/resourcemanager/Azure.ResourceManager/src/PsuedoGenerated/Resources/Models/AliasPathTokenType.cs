// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> The type of the token that the alias path is referring to. </summary>
    public readonly partial struct AliasPathTokenType : IEquatable<AliasPathTokenType>
    {
        private readonly string _value;

        /// <summary> Determines if two <see cref="AliasPathTokenType"/> values are the same. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public AliasPathTokenType(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string NotSpecifiedValue = "NotSpecified";
        private const string AnyValue = "Any";
        private const string StringValue = "String";
        private const string ObjectValue = "Object";
        private const string ArrayValue = "Array";
        private const string IntegerValue = "Integer";
        private const string NumberValue = "Number";
        private const string BooleanValue = "Boolean";

        /// <summary> The token type is not specified. </summary>
        public static AliasPathTokenType NotSpecified { get; } = new AliasPathTokenType(NotSpecifiedValue);
        /// <summary> The token type can be anything. </summary>
        public static AliasPathTokenType Any { get; } = new AliasPathTokenType(AnyValue);
        /// <summary> The token type is string. </summary>
        public static AliasPathTokenType String { get; } = new AliasPathTokenType(StringValue);
        /// <summary> The token type is object. </summary>
        public static AliasPathTokenType Object { get; } = new AliasPathTokenType(ObjectValue);
        /// <summary> The token type is array. </summary>
        public static AliasPathTokenType Array { get; } = new AliasPathTokenType(ArrayValue);
        /// <summary> The token type is integer. </summary>
        public static AliasPathTokenType Integer { get; } = new AliasPathTokenType(IntegerValue);
        /// <summary> The token type is number. </summary>
        public static AliasPathTokenType Number { get; } = new AliasPathTokenType(NumberValue);
        /// <summary> The token type is boolean. </summary>
        public static AliasPathTokenType Boolean { get; } = new AliasPathTokenType(BooleanValue);
        /// <summary> Determines if two <see cref="AliasPathTokenType"/> values are the same. </summary>
        public static bool operator ==(AliasPathTokenType left, AliasPathTokenType right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AliasPathTokenType"/> values are not the same. </summary>
        public static bool operator !=(AliasPathTokenType left, AliasPathTokenType right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AliasPathTokenType"/>. </summary>
        public static implicit operator AliasPathTokenType(string value) => new AliasPathTokenType(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AliasPathTokenType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AliasPathTokenType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
