using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartyStarter.Models
{


    public class MediaReader
    {
        public Guid Id { get; set; }
        public virtual List<MediaReaderFormat> Formats { get; set; }
        public virtual List<Peripheral> Peripherals { get; set; }
    }
}
