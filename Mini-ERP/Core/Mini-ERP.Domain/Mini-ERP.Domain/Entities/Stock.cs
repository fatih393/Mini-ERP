using Mini_ERP.Domain.Entities.Common;
using Mini_ERP.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_ERP.Domain.Entities
{
    public class Stock: BaseEntitiy
    {
        public ProductName ProductName { get; set; }

        public decimal Quantity { get; set; }

        public Unit Unit { get; set; }

        public int? ReferenceId { get; set; }

        public ReferenceType ReferenceType { get; set; }

        public DateTime LastUpdated { get; set; }




        /* {"message", new RenderedMessageColumnWriter() },
        {"message_template", new MessageTemplateColumnWriter() },
        {"level", new LevelColumnWriter() },
        {"time_stamp", new TimestampColumnWriter() },
        {"exception", new ExceptionColumnWriter() },
        {"log_event", new LogEventSerializedColumnWriter() },
        {"user_name", new UserNameColumnWriter() }
        })*/


     /*   public string Message { get; set; }
        public string Lavel { get; set; }
        public DateTime time_stamp { get; set; }
        public string Exeption { get; set; }
        public string Logevent { get; set; }
        public string user_name { get; set; }*/
    }
}
