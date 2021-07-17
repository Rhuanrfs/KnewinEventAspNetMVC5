using KnewinEventAsp.Service.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnewinEventAsp.Service.Services
{
    public class Teste: ITeste
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "Teste", " OK" };
        }
    }
}
