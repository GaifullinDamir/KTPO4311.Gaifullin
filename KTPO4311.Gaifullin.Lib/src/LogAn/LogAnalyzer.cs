using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTPO4311.Gaifullin.Lib.src.LogAn
{
    internal class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if(fileName.EndsWith(".GDR"))
            {
                return false;
            }
            return true;
        }
    }
}
