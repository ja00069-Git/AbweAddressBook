﻿namespace AbweAddressBook.Models;

/// <summary>
///     The category class.
///     Jabesi Abwe
///     02/08/2024
/// </summary>
public class Category
{
    /// <summary>
    ///     Gets or sets the category identifier.
    /// </summary>
    /// <value>
    ///     The category identifier.
    /// </value>
    public int CategoryId { get; set; }

    /// <summary>
    ///     Gets or sets the name.
    /// </summary>
    /// <value>
    ///     The name.
    /// </value>
    public string? Name { get; set; } = string.Empty;
}