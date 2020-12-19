using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace TwoClaimRespository
{
    public class ClaimsRepositiory
    {
       private Queue<Claim> _claimRepo = new Queue<Claim>();

        public void AddContentToQue(Claim newClaim)
        {            
            _claimRepo.Enqueue(newClaim);
        }
        public void CopyContentQue(Queue<Claim> localQueue)
        {
            Queue<Claim> copyOfClaim = new Queue<Claim>(localQueue);
            foreach(Claim ind in copyOfClaim)
            {
                _claimRepo.Enqueue(ind);
            }
        }
        public Queue<Claim> GetQueue()
        {
            return _claimRepo;
        }

    }
}
