using System;
using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class MedicineUtility
    {
        public static SortedDictionary<int,List<Medicine>> medicines = new SortedDictionary<int, List<Medicine>>();
       
       public void AddMedicine(Medicine med)
        {
            //Exception throwing
            foreach(var medicinesByYear in medicines.Values)
            {
                foreach(var medicine in medicinesByYear)
                {
                    if(medicine.Id == med.Id)
                    {
                        throw new DuplicateMedicineException("Medicine already exist");
                    }
                }
            }
            if(med.ExpiryYear <= 0)
                throw new InvalidExpiryYearException("Invalid Expiry Year");


            //Adding the medicine
            if(!medicines.ContainsKey(med.ExpiryYear))
                medicines[med.ExpiryYear] = new List<Medicine>();

            medicines[med.ExpiryYear].Add(med);
        }

        public SortedDictionary<int,List<Medicine>> GetAllMedicines()
        {
            if(medicines.Count == 0)
                throw new MedicineNotFoundException("Medicines Not Found");

            return medicines;
        }


        public void PrintMedicines( SortedDictionary<int,List<Medicine>> medicines){
            foreach(var medicinesByYear in medicines.Values)
            {
                foreach(var medicine in medicinesByYear)
                {
                    Console.WriteLine($"ID : {medicine.Id} | NAME : {medicine.Name} | PRICE : {medicine.Price}  |  EXPIRY : {medicine.ExpiryYear}");
                }
            }
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            if(newPrice < 0)
                throw new InvalidPriceException("New Price of Medicine is not Valid");

            foreach(var medicinesByYear in medicines.Values)
            {
                foreach(var medicine in medicinesByYear)
                {
                    if(medicine.Id == id)
                    {
                        medicine.Price = newPrice;
                        return;
                    }
                }
            }
        }
    }
}
