//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookMaster3000.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookCustomers
    {
        public int ID { get; set; }
        public string BookKey { get; set; }
        public string CustomerID { get; set; }
        public System.DateTime IssueDate { get; set; }
        public System.DateTime UntilDate { get; set; }
        public bool IsReturned { get; set; }
        public Nullable<System.DateTime> ReturnDate { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
