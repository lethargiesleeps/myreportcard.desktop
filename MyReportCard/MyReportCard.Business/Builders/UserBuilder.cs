using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using MyReportCard.Data.Models;

namespace MyReportCard.Business.Builders;

/// <summary>
/// This class returns a User object to be serialized. Although, the application should never need to create more than one user by default
/// </summary>
public class UserBuilder : IBuildable
{
    private readonly User _user;

    /// <summary>
    /// Default constructor for UserBuilder, sets CreationDate to current Date.
    /// </summary>
    public UserBuilder()
    {
        _user = new User()
        {
            CreationDate = DateTime.Now
        };
    }
    /// <summary>
    /// Sets the name of the user.
    /// </summary>
    /// <param name="name">String with name value of user.</param>
    /// <returns>The current UserBuilder</returns>
    public UserBuilder SetName(string name)
    {
        _user.Name = name;
        return this;
    }
    /// <summary>
    /// Sets creation date of user using DateTime.
    /// </summary>
    /// <param name="dateTime">The DateTime object.</param>
    /// <returns>The current UserBuilder instance.</returns>
    public UserBuilder SetCreationDate(DateTime dateTime)
    {
        _user.CreationDate = dateTime;
        return this;
    }
    /// <summary>
    /// Sets the user's term list if one is already created elsewhere.
    /// </summary>
    /// <param name="terms">A list of term objects</param>
    /// <returns>The current UserBuilder instance.</returns>
    /// <exception cref="ArgumentNullException">Throws exception if argument is null.</exception>
    public UserBuilder SetTerms(List<Term> terms)
    {
        if (terms is null || terms.Count <= 0) throw new ArgumentNullException(nameof(terms));
        _user.Terms = terms;
        return this;
    }
    /// <summary>
    /// Sets the user's term list if one is already created elsewhere as an array.
    /// </summary>
    /// <param name="terms">An array of terms.</param>
    /// <returns>The current UserBuilder instance.</returns>
    /// <exception cref="ArgumentNullException">Throws exception if argument is null.</exception>
    public UserBuilder SetTerms(Term[] terms)
    {
        if (terms is null || terms.Length <= 0) throw new ArgumentNullException(nameof(terms));
        _user.Terms = new List<Term>();
        foreach (var term in terms)
            _user.Terms.Add(term);
        return this;
    }
    /// <summary>
    /// Adds a term to the user's list.
    /// </summary>
    /// <param name="term">A term object.</param>
    /// <returns>The current UserBuilder instance.</returns>
    /// <exception cref="ArgumentNullException">Throws exception if argument is null.</exception>
    public UserBuilder AddTerm(Term term)
    {
        if(term is null) throw new ArgumentNullException(nameof(term));
        _user.Terms ??= new List<Term>();
        _user.Terms.Add(term);
        return this;
    }

    /// <summary>
    /// Builds and returns user.
    /// </summary>
    /// <returns>The user object</returns>
    public object BuildAndGetObject() => (User)_user;

}