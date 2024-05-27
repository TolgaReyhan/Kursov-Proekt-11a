using Data;
using Data.Models;
using System.Linq;

namespace Business
{
    public class BankBusiness
    {
            private BankDbContext bankContext;
            public List<Bank> GetAll()
            {
                using (bankContext = new BankDbContext())
                {
                    return bankContext.Banks.ToList();
                }
            }
            public Bank Get(int id)
            {
                using (bankContext = new BankDbContext())
                {
                    return bankContext.Banks.Find(id);
                }
            }
            public void Add(Bank product)
            {
                using (bankContext = new BankDbContext())
                {
                    bankContext.Banks.Add(product);
                    bankContext.SaveChanges();
                }
            }
            public void Update(Bank product)
            {
                using (bankContext = new BankDbContext())
                {
                    var item = bankContext.Banks.Find(product.Id);
                    if (item != null)
                    {
                        bankContext.Entry(item).CurrentValues.SetValues(product);
                        bankContext.SaveChanges();
                    }
                }
            }
            public void Delete(int id)
            {
                using (bankContext = new BankDbContext())
                {
                    var product = bankContext.Banks.Find(id);
                    if (product != null)
                    {
                        bankContext.Banks.Remove(product);
                        bankContext.SaveChanges();
                    }
                }
            }
    }
}
