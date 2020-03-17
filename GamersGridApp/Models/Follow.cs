﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class Follow
    {
        public int ID { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FollowerId { get; set; }

        public User User { get; set; }

        public User Follower { get; set; }

    }
}