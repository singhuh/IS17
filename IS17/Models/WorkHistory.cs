//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IS17.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class WorkHistory
    {
        public int WorkHistoryId { get; set; }
        [Required]
        [Display(Name = "M#")]
        public string MNumber { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Company Name")]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Job Title")]
        public Nullable<int> TitleId { get; set; }
        [Display(Name = "Job Title")]
        public string TitleName { get; set; }
        [Display(Name = "Job Start Date")]
        public System.DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> FTE { get; set; }
        public Nullable<int> Compensation { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual StudentAlum StudentAlum { get; set; }
        public virtual Title Title { get; set; }
    }
}
