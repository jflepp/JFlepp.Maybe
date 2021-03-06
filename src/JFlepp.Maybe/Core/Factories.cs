﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFlepp.Functional
{
    /// <summary>
    /// Provides functions for creating <see cref="Maybe{T}" />s.
    /// </summary>
    public static partial class Maybe
    {
        /// <summary>
        /// Creates a new none instance of <see cref="Maybe{T}" />.
        /// </summary>
        /// <returns>A new none instance of <see cref="Maybe{T}" />.</returns>
        public static Maybe<T> None<T>() => new Maybe<T>();

        /// <summary>
        /// Creates a new some instance of <see cref="Maybe{T}" />.
        /// </summary>
        /// <param name="value">The value of the <see cref="Maybe{T}" />.</param>
        /// <returns>A new some instance of <see cref="Maybe{T}" />.</returns>
        public static Maybe<T> Some<T>(T value) => new Maybe<T>(value);

        /// <summary>
        /// Convert a potentially null value to an option.
        /// </summary>
        /// <param name="value">The input value.</param>
        /// <returns>The result option.</returns>
        /// <FSharp>
        /// let ofObj value = match value with null -> None | _ -> Some value
        /// // val ofObj : value:'a -> 'a option when 'a : null
        /// </FSharp>
        /// <Implementation>
        /// Maybe{T} OfObject{T}(T value) => (value == null) switch
        /// {
        ///     true => Some(value),
        ///     _ => None{T}(),
        /// };
        /// </Implementation>
        public static Maybe<T> FromObject<T>(T value) => (value == null) switch
        {
            false => Some(value),
            _ => None<T>(),
        };
    }
}
