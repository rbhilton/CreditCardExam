using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CreditCardExam.Models
{
    public class Repository
    {
        public static CustAndTrans getCustAndTrans(int id)
        {
            CustAndTrans custAndTrans = new CustAndTrans();
            custAndTrans.customer = DataModel.getCustomer(id);
            custAndTrans.customers = DataModel.getCustomers();
            custAndTrans.transactions = DataModel.getTransactions();

            return custAndTrans;
        }

        public static List<CCTrans> getTransactions()
        {
            return DataModel.getTransactions();
        }
    }

    public class CustAndTrans
    {
        [Key]
        public int custId { get; set; }
        public Customer customer { get; set; }
        public List<Customer> customers { get; set; }
        public List<CCTrans> transactions { get; set; }

        public CustAndTrans()
        {
            this.customer = new Customer();
            this.customers = new List<Customer>();
            this.transactions = new List<CCTrans>();
        }
    }
}