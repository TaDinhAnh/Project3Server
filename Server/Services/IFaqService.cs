using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IFaqService
    {

        List<Faq> FindAll();
        Faq Find(int idFaq);
        List<Faq> Create(Faq faq);
        List<Faq> Del(int idfaq);
        List<Faq> Update(Faq faq);
    }
}
