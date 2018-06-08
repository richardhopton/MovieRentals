using System;
using System.Collections.Generic;

namespace MovieRentals
{
  public class Customer
  {
    private String _name;
    private List<Rental> _rentals = new List<Rental>();

    public Customer(String name)
    {
      _name = name;
    }

    public void AddRental(Rental arg)
    {
      _rentals.Add(arg);
    }

    public String Statement()
    {
      double totalAmount = 0;
      String result = "Rental Record for " + _name + "\n";

      foreach (var each in _rentals)
      {
        double thisAmount = 0;

        switch (each.getMovie().getPriceCode())
        {
          case Movie.REGULAR:
            thisAmount += 2;
            if (each.getDaysRented() > 2)
              thisAmount += (each.getDaysRented() - 2) * 1.5;
            break;
          case Movie.NEW_RELEASE:
            thisAmount += each.getDaysRented() * 3;
            break;
          case Movie.CHILDRENS:
            thisAmount += 1.5;
            if (each.getDaysRented() > 3)
              thisAmount += (each.getDaysRented() - 3) * 1.5;
            break;
        }

        // show figures for this rental
        result += "\t" + each.getMovie().getTitle() + "\t" + thisAmount.ToString() + "\n";
        totalAmount += thisAmount;
      }

      // add footer lines
      result += "Amount owed is " + totalAmount.ToString() + "\n";

      return result;
    }
  }
}
