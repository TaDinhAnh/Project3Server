﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
namespace Server.Services
{
    public interface IPerformerService
    {
        List<Performer> FindAll();
        Performer Find(int idPerformer);
        string Create(Performer performer);
        string Del(int idPerformer);
        string Update(Performer performer);
    }
}