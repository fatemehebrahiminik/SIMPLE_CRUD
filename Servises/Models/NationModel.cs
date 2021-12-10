using System;
using System.Collections.Generic;
using System.Text;

namespace Servises.Models
{
  public  class NationModel
    {
        public int Id { set; get; }
        /// <summary>
        /// for example IR, US
        /// </summary>
        public string NationType { set; get; }
        /// <summary>
        /// for example +98, +1
        /// </summary>
        public string NationCode { set; get; }
        /// <summary>
        /// US(+1)
        /// IR(+98)
        /// </summary>
        public string NationTypeDesc { set; get; }
    }
}
