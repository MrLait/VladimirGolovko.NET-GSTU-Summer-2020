﻿using SQLServer.Task6.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    [Table("Groups")]
    public class Groups : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}