using System;

public class Address
{
    private string StreetAddress { get; set; }
    private string City { get; set; }
    private string StateOrProvince { get; set; }
    private string Country { get; set; }

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        StreetAddress = streetAddress;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.Trim().Equals("USA", StringComparison.OrdinalIgnoreCase) ||
               Country.Trim().Equals("United States", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{StreetAddress}\n{City}, {StateOrProvince}\n{Country}";
    }
}