//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Teknorix_proj.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Employee
    {
        public int emp_id { get; set; }
        public string emp_fname { get; set; }
        public string emp_lname { get; set; }
        public string emp_gender { get; set; }
        public string emp_address { get; set; }
        public string emp_phone_no { get; set; }
        public string emp_mobile_no { get; set; }
        public string emp_desgn_id { get; set; }
        public string dept_id { get; set; }
        public string searchBy { get; set; }
        public string search { get; set; }
        public string JsonVar { get; set; }


        public virtual Department Department_Tbl { get; set; }
    }
}
