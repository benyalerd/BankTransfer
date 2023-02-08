using BankTransferDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransferData.Model
{
    public class Customer
    {
        [DataNames("ID")]
        public int Id { get; set; }

        [DataNames("FIRST_NAME")]
        public string FirstName { get; set; }

        [DataNames("LAST_NAME")]
        public string LastName { get; set; }

        [DataNames("CITIZEN_ID")]
        public string CitizenId { get; set; }
    }
}
