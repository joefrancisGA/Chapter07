using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain.ValueObjects
{
    public class City : Value<City>
    {
        public string Value { get; }

        public City()
        {
        }

        private City(string value)
        {
            Value = value ?? throw new ArgumentException("City name must be specified");
        }

        public static City Create(string city)
        {
            return new City(city);
        }

        public static implicit operator string(City city)
        {
            return city.Value;
        }

        public static explicit operator City(string city)
        {
            return new City(city);
        }
    }
}