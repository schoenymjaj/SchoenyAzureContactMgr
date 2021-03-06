﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SchoenyAzureContactMgr.Models
{

    public class GameType : IEntity
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(maximumLength: 60, MinimumLength = 4)]
        [Display(Name = "Type")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(maximumLength: 200, MinimumLength = 5)]
        public string Description { get; set; }

        public string AnotherTextField { get; set; }

        public bool UsedFlag { get; set; }

        public string Comment { get; set; }

        public DateTime? DateCreated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Game> Games { get; set; }


    }

}