﻿using DreamWallHub.Infrastructure.Data.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DreamWallHub.Infrastructure.Data
{
    public class Comment
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [ForeignKey(nameof(Review))]
        public string ReviewId { get; set; }
        public Review Review { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

    }
}
