using System;
using System.Collections.Generic;
using System.Text;

namespace FourOutingsRepository
{
    public class OutingsRepository
    {
        private List<Outings> _outingsRepo = new List<Outings>();

        //Create
        public void AddOutingsToList(Outings Outing)
        {
            _outingsRepo.Add(Outing);
        }
        
        //Read
        public List<Outings> GetOutingsList()
        {
            return _outingsRepo;
        }

        //Helper method
        public Double GetOutingsByTypeTotal(OutingType getOutingType)
        {
            Double outingTypeTotal = 0;

            foreach (Outings outing in _outingsRepo)
            {
                if (outing.OutingType == getOutingType)
                {
                   outingTypeTotal += outing.CostOfEvent;
                }
            }
            return outingTypeTotal;
        }

        public Double? GetOutingsTotalCost()
        {
            Double outingsTotal = 0;

            foreach (Outings outing in _outingsRepo)
            {
                outingsTotal += outing.CostOfEvent;
            }
            return outingsTotal;
        }

    }
}
