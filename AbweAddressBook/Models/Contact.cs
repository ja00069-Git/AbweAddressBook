using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AbweAddressBook.Models;

/// <summary>
/// The contact class.
/// Jabesi Abwe
/// 02/07/2024
/// </summary>
public class Contact
{
    /// <summary>
    /// Gets or sets the contact identifier.
    /// </summary>
    /// <value>
    /// The contact identifier.
    /// </value>
    public int ContactId { get; set; }

    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>
    /// The first name.
    /// </value>
    [Required(ErrorMessage = "Please enter your fist name")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Numbers and special characters are not allowed in the first name.")]
    public string? FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>
    /// The last name.
    /// </value>
    [Required(ErrorMessage = "Please enter your last name")]
    [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
        ErrorMessage = "Numbers and special characters are not allowed in the last name.")]
    public string? LastName { get; set; }

    /// <summary>
    /// Gets or sets the name of the nick.
    /// </summary>
    /// <value>
    /// The name of the nick.
    /// </value>
    public string? NickName { get; set; }

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    /// <value>
    /// The phone number.
    /// </value>
    [Required(ErrorMessage = "Please enter your phone number")]
    [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Please enter a valid phone number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the date created.
    /// </summary>
    /// <value>
    /// The date created.
    /// </value>
    public DateTime? DateCreated { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the category identifier.
    /// </summary>
    /// <value>
    /// The category identifier.
    /// </value>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category.
    /// </summary>
    /// <value>
    /// The category.
    /// </value>
    [ValidateNever] public Category Category { get; set; } = null!;
    public string Slug => FirstName?.Replace(" ", "-").ToLower() + "-" + LastName?.Replace(" ", "-").ToLower();
}