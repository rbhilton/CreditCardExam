using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CreditCardExam.Models
{
    public class DataModel
    {
        public static Customer getCustomer(int id)
        {
            CreditCardDbContext db = new CreditCardDbContext();
            Customer customer = db.customers.Find(id);
            return customer;
        }

        public static List<Customer> getCustomers()
        {
            CreditCardDbContext db = new CreditCardDbContext();
            List<Customer> customers = db.customers.ToList();
            return customers;
        }

        public static List<CCTrans> getTransactions()
        {
            CreditCardDbContext db = new CreditCardDbContext();
            List<CCTrans> transactions = db.transactions.ToList();
            return transactions;
        }
    }

    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public String emailAddress  { get; set; }
        public String firstName { get; set; }
        public String lastName { get; set; }
        public Decimal balance { get; set; }
    }

    [Table("CCTrans")]
    public class CCTrans
    {
        [Key]
        public int Id { get; set; }
        public DateTime transDate { get; set; }
        public String transDesc { get; set; }
        public Decimal transAmt { get; set; }
        public int custId { get; set; }
    }

    public class CreditCardDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<CCTrans> transactions { get; set; }
    }
}