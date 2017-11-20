//D2575
//Due 9/11/16
//Lab 1
//Course Section: 76
//This program initiates an array and then searches it using LINQ queries, and displays according to what is selected 
//in the LINQ query and what is set to display in the loop that follows.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class LinqTest
    {
        public static void Main(string[] args)
        {
            string thisQuery = "This is query: ";
            // initialize array of invoices
            Invoice[] invoices = {
                new Invoice( 83, "Electric sander", 7, 57.98M ),
                new Invoice( 24, "Power saw", 18, 99.99M ),
                new Invoice( 7, "Sledge hammer", 11, 21.5M ),
                new Invoice( 77, "Hammer", 76, 11.99M ),
                new Invoice( 39, "Lawn mower", 3, 79.5M ),
                new Invoice( 68, "Screwdriver", 106, 6.99M ),
                new Invoice( 56, "Jig saw", 21, 11M ),
                new Invoice( 3, "Wrench", 34, 7.5M ) };

            // Display original array
            Console.WriteLine("Original Invoice Data\n");
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------");

            foreach (Invoice inv in invoices)
                Console.WriteLine(inv);

            Console.WriteLine();//Just space for better look.
            Console.WriteLine();

            Console.WriteLine(thisQuery + "A"); //start query A
            var queryA =
               from e in invoices //grab variable from array
               orderby e.PartDescription //orderby a specific part of the array
               select e; //grab everything in the array
            foreach (var element in queryA) //start display of queryA
                Console.WriteLine(element); //actually writes out each record

            Console.WriteLine();//more space
            Console.WriteLine();

            Console.WriteLine(thisQuery + "B");//start query B
            var queryB =
                from x in invoices
                orderby x.Price
                select x;
            foreach (var element in queryB)
                Console.WriteLine(element);

            Console.WriteLine();//more space
            Console.WriteLine();

            Console.WriteLine(thisQuery + "C");//start query C
            var queryC =
                from x in invoices
                orderby x.Quantity
                select new { x.PartDescription, x.Quantity };//selecting specific pieces (part description and quantity) of each record from the array
            foreach (var element in queryC)
            { Console.WriteLine("Part Description = " + element.PartDescription + ", Quantity = " + element.Quantity); }

            Console.WriteLine();//more space
            Console.WriteLine();

            Console.WriteLine(thisQuery + "D");//start query D
            var queryD =
                from x in invoices
                let total = (x.Quantity*x.Price) // storing the product of quantity*price in the variable called "total"
                orderby total
                select new { x.PartDescription, InvoiceTotal = total }; //selecting only the part description and invoice total (total variable) to display
            foreach(var element in queryD)
            { Console.WriteLine("Part Description = " + element.PartDescription + ", Invoice Total = " + element.InvoiceTotal); }

            Console.WriteLine();//more space
            Console.WriteLine();

            Console.WriteLine(thisQuery + "E");//start query E
            var queryE =
                from total in queryD
                where total.InvoiceTotal >= 200 && total.InvoiceTotal <= 500
                select total;
            foreach (var element in queryE)
                Console.WriteLine("Part Description = " + element.PartDescription + ", Invoice Total = " + element.InvoiceTotal);
        }
    }
}
