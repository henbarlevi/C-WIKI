using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Classes
{
    public class Email
    {
        public string subject { get; set; } // "subject": "HI",
        public string from { get; set; }//"from": "jhon-doe",
        public string[] to { get; set; } //"to": [ "person@gmail.com"],
        public string html { get; set; }//"html":"<b>random message </b>"
    }

}
