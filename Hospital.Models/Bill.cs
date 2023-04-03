using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int BillNumber { get; set; }
        public ApplicationUser Patient { get; set; }
        public Insurance Insurance { get; set; }
        public int DoctorCharge { get; set; }
        public decimal MedicienCharge { get; set; }
        public decimal RoomCharge { get; set; }
        public decimal Operationcharge { get; set; }
        public int NoOfDays { get; set; }
        public int NursingCharge { get; set; }
        public decimal Advance { get; set; }
        public decimal TotalBill { get; set; }
    }
}
